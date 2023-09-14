using System;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Xml;

namespace JsonToXml_Config
{
    public class ConfigurationSettings
    {
        public const string ConfigFileName = "settings.config";
        public static NameValueCollection AppSettings;
        private static XmlDocument oXml = new XmlDocument();

        public static void LoadConfig()
        {
            string str = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), ConfigFileName);
            if (str.ToLower().StartsWith("file:"))
                str = new Uri(str).LocalPath;
            ConfigurationSettings.LoadConfig(Path.GetFullPath(str));
        }

        public static void LoadConfig(string ConfigFile)
        {
            ConfigurationSettings.AppSettings = new NameValueCollection();
            try
            {
                if (System.IO.File.Exists(ConfigFile))
                    ConfigurationSettings.oXml.Load(ConfigFile);
                else
                    ConfigurationSettings.oXml.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?><configuration><appSettings></appSettings></configuration>");
                foreach (XmlNode xmlNode in ConfigurationSettings.oXml.GetElementsByTagName("appSettings"))
                {
                    foreach (XmlNode childNode in xmlNode.ChildNodes)
                        ConfigurationSettings.AppSettings.Add(childNode.Attributes["key"].Value, childNode.Attributes["value"].Value);
                }
            }
            catch
            {
                ConfigurationSettings.oXml.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?><configuration><appSettings></appSettings></configuration>");
            }
        }

        public static void SaveConfig() => ConfigurationSettings.SaveConfig(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), ConfigFileName));

        public static void SaveConfig(string ConfigFile)
        {
            try
            {
                ConfigurationSettings.oXml.Save(ConfigFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ReadAppSetting(string key)
        {
            string str;
            try
            {
                str = ConfigurationSettings.AppSettings[key];
            }
            catch
            {
                str = "";
            }
            return str;
        }

        public static string ReadSecureAppSetting(string key) => new Secret().Decrypt(ConfigurationSettings.ReadAppSetting(key));

        public static void WriteAppSetting(string key, string value)
        {
            try
            {
                ConfigurationSettings.AppSettings.Remove(key);
            }
            catch
            {
            }
            ConfigurationSettings.AppSettings.Add(key, value);
            XmlNodeList elementsByTagName = ConfigurationSettings.oXml.GetElementsByTagName("appSettings");
            bool flag = false;
            foreach (XmlNode xmlNode in elementsByTagName)
            {
                foreach (XmlNode childNode in xmlNode.ChildNodes)
                {
                    try
                    {
                        if (childNode.Attributes[nameof(key)].Value == key)
                        {
                            childNode.Attributes[nameof(value)].Value = value;
                            flag = true;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            if (flag)
                return;
            XmlElement element = ConfigurationSettings.oXml.CreateElement("add");
            XmlAttribute attribute1 = ConfigurationSettings.oXml.CreateAttribute(nameof(key));
            attribute1.Value = key;
            element.Attributes.Append(attribute1);
            XmlAttribute attribute2 = ConfigurationSettings.oXml.CreateAttribute(nameof(value));
            attribute2.Value = value;
            element.Attributes.Append(attribute2);
            elementsByTagName.Item(0).AppendChild((XmlNode)element);
        }

        public static void WriteSecureAppSetting(string key, string value)
        {
            Secret secret = new Secret();
            ConfigurationSettings.WriteAppSetting(key, secret.Encrypt(value));
        }

        public static string JsonToXmlJsonPath
        {
            get => ConfigurationSettings.ReadAppSetting(nameof(JsonToXmlJsonPath));
            set => ConfigurationSettings.WriteAppSetting(nameof(JsonToXmlJsonPath), value);
        }

        public static string JsonToXmlXmlPath
        {
            get => ConfigurationSettings.ReadAppSetting(nameof(JsonToXmlXmlPath));
            set => ConfigurationSettings.WriteAppSetting(nameof(JsonToXmlXmlPath), value);
        }

        public static string JsonToXmlArchiveJsonPath
        {
            get => ConfigurationSettings.ReadAppSetting(nameof(JsonToXmlArchiveJsonPath));
            set => ConfigurationSettings.WriteAppSetting(nameof(JsonToXmlArchiveJsonPath), value);
        }

        public static Boolean JsonToXmlUseConverter
        {
            get => Convert.ToBoolean(ConfigurationSettings.ReadAppSetting(nameof(JsonToXmlUseConverter)));
            set => ConfigurationSettings.WriteAppSetting(nameof(JsonToXmlUseConverter), Convert.ToString(value));
        }
    }
}