using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using JsonToXml_Config;
using NLog;
using System.Reflection;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
//Integrate Logging

namespace JsonToXml_Lib
{
    public class JsonToXml
    {
        private const string LogConfigFileName = "NLog.config";
        //private static Boolean loggingEnabled = File.Exists(System.IO.Directory.GetCurrentDirectory() + @"\NLog.config");
        //private static Boolean loggingEnabled = File.Exists(Environment.CurrentDirectory + @"\NLog.config");
        //private static Boolean loggingEnabled = File.Exists(Environment.CurrentDirectory + @"\" + LogConfigFileName);
        //private static Boolean loggingEnabled = File.Exists(Path.Combine(Environment.CurrentDirectory, LogConfigFileName));
        //private static Boolean loggingEnabled = File.Exists(Path.Combine(Assembly.GetEntryAssembly().Location, LogConfigFileName));
        private static string AppPath()
        {
            string lstr = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (lstr.ToLower().StartsWith("file:"))
                lstr = new Uri(lstr).LocalPath;
            return lstr;
        }
        private static Boolean loggingEnabled = File.Exists(Path.Combine(AppPath(), LogConfigFileName));
        //private static Boolean loggingEnabled = File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), LogConfigFileName));

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public static Boolean CheckConfig()
        {
            return ConfigurationSettings.CheckConfig();
        }
        public static void RunJsonToXmlWithOutConfig(string sourcedir, string targetdir, string archivedir)
        {
            if (string.IsNullOrEmpty(sourcedir) || string.IsNullOrEmpty(targetdir))
            {
                DoLogError(string.Format("Parameter not valid:\n sourcedir: {0}\n archivedir: {1}", sourcedir, archivedir));
                throw new ArgumentException();
            }
            try
            {
                LoopJson(sourcedir, targetdir, archivedir);
            }
            catch (Exception ex)
            {
                DoLogError(ex.ToString());
            }
        }

        public static void RunJsonToXmlWithConfig()
        {
            try
            {
                try
                {
                    ConfigurationSettings.LoadConfig();
                    if (!ConfigurationSettings.JsonToXmlUseLogging)
                    {
                        loggingEnabled = false;
                    }
                }
                catch (Exception ex)
                {
                    DoLogError($"{ex.Message}");
                    DoLogWarn($"No Config found!");
                    throw ex;
                }

                if (string.IsNullOrEmpty(ConfigurationSettings.JsonToXmlJsonPath) || string.IsNullOrEmpty(ConfigurationSettings.JsonToXmlJsonPath))
                {
                    string exString = string.Format("Config not valid:\nJsonToXmlJsonPath:{0}\nJsonToXmlJsonPath:{1}", ConfigurationSettings.JsonToXmlJsonPath, ConfigurationSettings.JsonToXmlJsonPath);
                    DoLogError(exString);
                    throw new Exception();
                    //throw new Exception(exString);
                }
                else
                {
                    DoLogDebug("RunJsonToXmlWithConfig - LoopJson");
                    LoopJson(ConfigurationSettings.JsonToXmlJsonPath, ConfigurationSettings.JsonToXmlXmlPath, ConfigurationSettings.JsonToXmlArchiveJsonPath);
                }
            }
            catch (Exception ex)
            {
                DoLogError(ex.ToString());
                throw ex;
            }
        }

        private static void LoopJson(string sourcedir, string targetdir, string archivedir)
        {
            DirectoryInfo di = new DirectoryInfo(sourcedir);
            foreach (var file in di.GetFiles())
            {
                try
                {
                    string filename = file.Name.Replace(file.Extension, "");
                    if (ConvertJsonToXml(targetdir, file.FullName, filename))
                    {
                        if (!string.IsNullOrEmpty(archivedir))
                        {
                            file.MoveTo(archivedir + file.Name);
                            DoLogInformation("Archived: " + archivedir + file.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    DoLogError(ex.ToString());
                }
            }
        }

        private static bool ConvertJsonToXml(string targetdir, string jsonfile, string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(jsonfile))
                {
                    string xmlfile = targetdir + filename + ".xml";
                    if (!WriteXml(reader, xmlfile))
                        return false;
                }
                DoLogInformation("Converted: " + jsonfile);
                return true;
            }
            catch (Exception ex)
            {
                DoLogError(ex.ToString());
                return false;
            }
        }
        private static bool WriteXml(StreamReader reader, string xmlfile)
        {
            /*==================================================*/
            //Todo:
            //
            // - Newtonsoft.Json.Linq.JObject to dataTable
            // - 
            /*==================================================*/

            XDocument xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", ""));
            XElement root = new XElement("Root");
            root.Name = "Result";
            string jsonstring = reader.ReadToEnd();
            var dataTable = ConvertJsonToDataTable(jsonstring);
            try
            {
                /*
                //++ Debug
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(jsonstring);
                DataTable dataTable = dataSet.Tables[0];
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(row["id"] + " - " + row["item"]);
                }
                Console.ReadLine();
                //-- Debug
                JArray jsonArray = JArray.Parse(jsonstring);
                DataTable dataTable = new DataTable();
                dataTable = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                */
                root.Add(
                         from row in dataTable.AsEnumerable()
                         select new XElement("Record",
                                             from column in dataTable.Columns.Cast<DataColumn>()
                                             select new XElement(column.ColumnName, row[column])
                                            )
                       );

                xmlDoc.Add(root);
                xmlDoc.Save(xmlfile);

                return true;
            }
            catch (Exception ex)
            {
                DoLogError(dataTable.GetType().ToString());
                DoLogError(ex.ToString());
                throw new Exception("Error: " + dataTable.GetType().ToString());
                return false;
            }
        }
        private static DataTable ConvertJsonToDataTable(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<DataTable>(jsonString);
            }
            catch
            {
                return null;
            }
        }
        private static bool ConvertJsonToXml_o(string targetdir, string jsonfile, string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(jsonfile))
                {
                    string xmlfile = targetdir + filename + ".xml";

                    XDocument xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", ""));
                    XElement root = new XElement("Root");
                    root.Name = "Result";
                    string jsonstring = reader.ReadToEnd();

                    var dataTable = JsonConvert.DeserializeObject<DataTable>(jsonstring);
                    
                    root.Add(
                             from row in dataTable.AsEnumerable()
                             select new XElement("Record",
                                                 from column in dataTable.Columns.Cast<DataColumn>()
                                                 select new XElement(column.ColumnName, row[column])
                                                )
                           );

                    xmlDoc.Add(root);
                    xmlDoc.Save(xmlfile);
                }
                DoLogInformation("Converted: " + jsonfile);
                return true;
            }
            catch (Exception ex)
            {
                DoLogError(ex.ToString());
                return false;
            }
        }
        private static void DoLogInformation(string message)
        {
            if (loggingEnabled)
            {
                _logger.Info(message);
            }
        }
        private static void DoLogWarn(string message)
        {
            if (loggingEnabled)
            {
                _logger.Warn(message);
            }
        }
        private static void DoLogError(string message)
        {
            if (loggingEnabled)
            {
                _logger.Error(message);
            }
        }
        private static void DoLogDebug(string message)
        {
            if (loggingEnabled)
            {
                _logger.Debug(message);
            }
        }
    }
}