using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JsonToXml_Lib;
using static System.Net.Mime.MediaTypeNames;

namespace JsonToXml
{
    internal class Program
    {
        private static string GetParamValue(string[] args, string param)
        {
            bool flag = false;
            for (int index = 0; index < args.Length; ++index)
            {
                if (flag)
                    return args[index];
                if (args[index] == param)
                    flag = true;
            }
            return (string)null;
        }

        private static bool GetParamPresence(string[] args, string param)
        {
            for (int index = 0; index < args.Length; ++index)
            {
                if (args[index] == param)
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            try
            {
                if (Program.GetParamPresence(args, "-?") || Program.GetParamPresence(args, "/?"))
                {
                    cmd_helper.PrintUsage();
                }

                if (Program.GetParamPresence(args, "-checkconfig"))
                {
                    if (JsonToXml_Lib.JsonToXml.CheckConfig())
                    {
                        Console.WriteLine("Config found");
                        //++ Debug
                        string LogConfigFileName = "NLog.config";
                        string AppPath()
                        {
                            //Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), LogConfigFileName);
                            string lstr = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                            if (lstr.ToLower().StartsWith("file:"))
                                lstr = new Uri(lstr).LocalPath;
                            return lstr;
                        }
                        Console.WriteLine(AppPath());
                        Console.WriteLine(Path.Combine(AppPath(), LogConfigFileName));
                        //-- Debug
                    }
                    else
                    {
                        Console.WriteLine("No config found!");
                    }
                }

                if ((Program.GetParamPresence(args, "-sourcedir")) || (Program.GetParamPresence(args, "-targetdir")))
                {
                    string SourceDir = Program.GetParamValue(args, "-sourcedir");
                    string TargetDir = Program.GetParamValue(args, "-targetdir");
                    string ArchiveDir = Program.GetParamValue(args, "-archivedir");

                    if (string.IsNullOrEmpty(SourceDir) || string.IsNullOrEmpty(TargetDir))
                    {
                        if (string.IsNullOrEmpty(SourceDir))
                        {
                            throw new Exception("Error: -sourcedir is required");
                        }
                        if (string.IsNullOrEmpty(TargetDir))
                        {
                            throw new Exception("Error: -targetdir is required");
                        }
                    }
                    else
                    {
                        JsonToXml_Lib.JsonToXml.RunJsonToXmlWithOutConfig(SourceDir, TargetDir, ArchiveDir);
                    }
                }

                if (!Program.GetParamPresence(args, ""))
                {
                    try
                    {
                        JsonToXml_Lib.JsonToXml.RunJsonToXmlWithConfig();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }
        }
    }
}
