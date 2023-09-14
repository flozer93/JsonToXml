using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using JsonToXml_Config;
using NLog;
//Integrate Logging

namespace JsonToXml_Lib
{
    public static class JsonToXml
    {

        public static void RunJsonToXmlWithOutConfig(string sourcedir, string targetdir, string archivedir)
        {
            if (string.IsNullOrEmpty(sourcedir) || string.IsNullOrEmpty(targetdir))
            {
                throw new ArgumentException();
            }
            try
            {
                LoopJson(sourcedir, targetdir, archivedir);
            }
            catch { }
        }

        public static void RunJsonToXmlWithConfig()
        {
            try
            {
                ConfigurationSettings.LoadConfig();
                if (string.IsNullOrEmpty(ConfigurationSettings.JsonToXmlJsonPath) || string.IsNullOrEmpty(ConfigurationSettings.JsonToXmlJsonPath))
                {
                    throw new Exception();
                }
                else
                {
                    LoopJson(ConfigurationSettings.JsonToXmlJsonPath, ConfigurationSettings.JsonToXmlXmlPath, ConfigurationSettings.JsonToXmlArchiveJsonPath);
                }
            }
            catch { }
        }

        private static void LoopJson(string sourcedir, string targetdir, string archivedir)
        {
            DirectoryInfo di = new DirectoryInfo(sourcedir);
            foreach (var file in di.GetFiles())
            {
                try
                {
                    string filename = file.Name.Replace(file.Extension, "");
                    ConvertJsonToXml(targetdir, file.FullName, filename);
                    if (!string.IsNullOrEmpty(archivedir))
                    {
                        file.MoveTo(archivedir + file.Name);
                    }
                }
                catch //(Exception ex)
                {
                }
            }
        }

        private static void ConvertJsonToXml(string targetdir, string jsonfile, string filename)
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
            }
            catch //(Exception ex)
            {
            }
        }
    }
}