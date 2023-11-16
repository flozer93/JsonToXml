using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JsonToXml
{
    internal static class AssemblyInfo
    {
        public static string Company { get { return GetExecutingAssemblyAttribute<AssemblyCompanyAttribute>(a => a.Company); } }
        public static string Product { get { return GetExecutingAssemblyAttribute<AssemblyProductAttribute>(a => a.Product); } }
        public static string Copyright { get { return GetExecutingAssemblyAttribute<AssemblyCopyrightAttribute>(a => a.Copyright); } }
        public static string Trademark { get { return GetExecutingAssemblyAttribute<AssemblyTrademarkAttribute>(a => a.Trademark); } }
        public static string Title { get { return GetExecutingAssemblyAttribute<AssemblyTitleAttribute>(a => a.Title); } }
        public static string Description { get { return GetExecutingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }
        public static string Configuration { get { return GetExecutingAssemblyAttribute<AssemblyConfigurationAttribute>(a => a.Configuration); } }
        public static string FileVersion { get { return GetExecutingAssemblyAttribute<AssemblyFileVersionAttribute>(a => a.Version); } }
        public static Version Version { get { return Assembly.GetExecutingAssembly().GetName().Version; } }
        public static string VersionFull { get { return Version.ToString(); } }
        public static string VersionMajor { get { return Version.Major.ToString(); } }
        public static string VersionMinor { get { return Version.Minor.ToString(); } }
        public static string VersionBuild { get { return Version.Build.ToString(); } }
        public static string VersionRevision { get { return Version.Revision.ToString(); } }
        private static string GetExecutingAssemblyAttribute<T>(Func<T, string> value) where T : Attribute
        {
            T attribute = (T)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(T));
            return value.Invoke(attribute);
        }
    }
    internal class cmd_helper
    {
        internal static void PrintUsage()
        {
            Console.WriteLine(AssemblyInfo.Product + ' ' +  AssemblyInfo.Version);
            Console.WriteLine(AssemblyInfo.Copyright);
            Console.WriteLine();
            Console.WriteLine(AssemblyInfo.Description);
            Console.WriteLine();
            Console.WriteLine("If no Parameters are set the Configuration will be used.");
            Console.WriteLine();
            Console.WriteLine("Parameter:");
            Console.WriteLine();
            Console.WriteLine("  -sourcedir        If set the Config will be ignored");
            Console.WriteLine("  -targetdir        Required if sourcedir is set");
            Console.WriteLine("                    ");
            Console.WriteLine("  -archivedir       Optional.If not set the sourcefiles will be deleted after.");
            Console.WriteLine("");
            Console.WriteLine("  -? or /?          Displays this text.");
        }
    }
}
