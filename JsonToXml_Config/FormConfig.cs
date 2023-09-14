using System;
using System.IO;
using System.Windows.Forms;

namespace JsonToXml_Config
{
    public partial class FormConfig : Form
    {
        private string AppPath = "";
        private string ConfigFile = "";

        public FormConfig()
        {
            InitializeComponent();
            this.readConfig();
        }

        private void readConfig()
        {
            this.AppPath = Path.GetDirectoryName(Application.ExecutablePath);
            this.ConfigFile = Path.Combine(this.AppPath, ConfigurationSettings.ConfigFileName);
            ConfigurationSettings.LoadConfig(this.ConfigFile);

            this.Tb_JsonToXmlXmlPath.Text = ConfigurationSettings.JsonToXmlXmlPath;
            this.Tb_JsonToXmlArchiveJsonPath.Text = ConfigurationSettings.JsonToXmlArchiveJsonPath;
            this.Tb_JsonToXmlJsonPath.Text = ConfigurationSettings.JsonToXmlJsonPath;
            if (ConfigurationSettings.JsonToXmlUseConverter)
            {
                this.Cb_JsonToXmlUseConverter.Checked = true;
            }
        }

        private void writeConfig()
        {
            ConfigurationSettings.JsonToXmlXmlPath = PathMod(this.Tb_JsonToXmlXmlPath.Text);
            ConfigurationSettings.JsonToXmlJsonPath = PathMod(this.Tb_JsonToXmlJsonPath.Text);
            ConfigurationSettings.JsonToXmlArchiveJsonPath = PathMod(this.Tb_JsonToXmlArchiveJsonPath.Text);
            ConfigurationSettings.JsonToXmlUseConverter = this.bJsonToXmlUseConverter();

            ConfigurationSettings.SaveConfig(this.ConfigFile);
        }

        //private string PathMod(string stringP)
        public string PathMod(string stringP)
        {
            if (!stringP.EndsWith("\\"))
            {
                return stringP + "\\";
            }
            else
                return stringP;
        }

        public bool bJsonToXmlUseConverter()
        {
            if (Cb_JsonToXmlUseConverter.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Btn_SaveConfig_Click(object sender, EventArgs e)
        {
            this.writeConfig();
        }

        private void Btn_SaveExit_Click(object sender, EventArgs e)
        {
            this.writeConfig();
            this.Close();
        }
    }
}