using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace JsonToXml_Config
{
    partial class FormConfig
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.Btn_SaveConfig = new System.Windows.Forms.Button();
            this.Btn_SaveExit = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Cb_JsonToXmlUseLogging = new System.Windows.Forms.CheckBox();
            this.L_JsonToXmlArchiveJsonPath = new System.Windows.Forms.Label();
            this.Tb_JsonToXmlArchiveJsonPath = new System.Windows.Forms.TextBox();
            this.Cb_JsonToXmlUseConverter = new System.Windows.Forms.CheckBox();
            this.L_JsonPath = new System.Windows.Forms.Label();
            this.L_XmlPath = new System.Windows.Forms.Label();
            this.Tb_JsonToXmlJsonPath = new System.Windows.Forms.TextBox();
            this.Tb_JsonToXmlXmlPath = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_SaveConfig
            // 
            resources.ApplyResources(this.Btn_SaveConfig, "Btn_SaveConfig");
            this.Btn_SaveConfig.Name = "Btn_SaveConfig";
            this.Btn_SaveConfig.UseVisualStyleBackColor = true;
            this.Btn_SaveConfig.Click += new System.EventHandler(this.Btn_SaveConfig_Click);
            // 
            // Btn_SaveExit
            // 
            resources.ApplyResources(this.Btn_SaveExit, "Btn_SaveExit");
            this.Btn_SaveExit.Name = "Btn_SaveExit";
            this.Btn_SaveExit.UseVisualStyleBackColor = true;
            this.Btn_SaveExit.Click += new System.EventHandler(this.Btn_SaveExit_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Cb_JsonToXmlUseLogging);
            this.tabPage1.Controls.Add(this.L_JsonToXmlArchiveJsonPath);
            this.tabPage1.Controls.Add(this.Tb_JsonToXmlArchiveJsonPath);
            this.tabPage1.Controls.Add(this.Cb_JsonToXmlUseConverter);
            this.tabPage1.Controls.Add(this.L_JsonPath);
            this.tabPage1.Controls.Add(this.L_XmlPath);
            this.tabPage1.Controls.Add(this.Tb_JsonToXmlJsonPath);
            this.tabPage1.Controls.Add(this.Tb_JsonToXmlXmlPath);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Cb_JsonToXmlUseLogging
            // 
            resources.ApplyResources(this.Cb_JsonToXmlUseLogging, "Cb_JsonToXmlUseLogging");
            this.Cb_JsonToXmlUseLogging.Name = "Cb_JsonToXmlUseLogging";
            this.Cb_JsonToXmlUseLogging.UseVisualStyleBackColor = true;
            // 
            // L_JsonToXmlArchiveJsonPath
            // 
            resources.ApplyResources(this.L_JsonToXmlArchiveJsonPath, "L_JsonToXmlArchiveJsonPath");
            this.L_JsonToXmlArchiveJsonPath.Name = "L_JsonToXmlArchiveJsonPath";
            // 
            // Tb_JsonToXmlArchiveJsonPath
            // 
            resources.ApplyResources(this.Tb_JsonToXmlArchiveJsonPath, "Tb_JsonToXmlArchiveJsonPath");
            this.Tb_JsonToXmlArchiveJsonPath.Name = "Tb_JsonToXmlArchiveJsonPath";
            // 
            // Cb_JsonToXmlUseConverter
            // 
            resources.ApplyResources(this.Cb_JsonToXmlUseConverter, "Cb_JsonToXmlUseConverter");
            this.Cb_JsonToXmlUseConverter.Name = "Cb_JsonToXmlUseConverter";
            this.Cb_JsonToXmlUseConverter.UseVisualStyleBackColor = true;
            // 
            // L_JsonPath
            // 
            resources.ApplyResources(this.L_JsonPath, "L_JsonPath");
            this.L_JsonPath.Name = "L_JsonPath";
            // 
            // L_XmlPath
            // 
            resources.ApplyResources(this.L_XmlPath, "L_XmlPath");
            this.L_XmlPath.Name = "L_XmlPath";
            // 
            // Tb_JsonToXmlJsonPath
            // 
            resources.ApplyResources(this.Tb_JsonToXmlJsonPath, "Tb_JsonToXmlJsonPath");
            this.Tb_JsonToXmlJsonPath.Name = "Tb_JsonToXmlJsonPath";
            // 
            // Tb_JsonToXmlXmlPath
            // 
            resources.ApplyResources(this.Tb_JsonToXmlXmlPath, "Tb_JsonToXmlXmlPath");
            this.Tb_JsonToXmlXmlPath.Name = "Tb_JsonToXmlXmlPath";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // FormConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Btn_SaveExit);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Btn_SaveConfig);
            this.Name = "FormConfig";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button Btn_SaveConfig;
        private Button Btn_SaveExit;
        private TabPage tabPage1;
        private CheckBox Cb_JsonToXmlUseConverter;
        private Label L_JsonPath;
        private Label L_XmlPath;
        private TextBox Tb_JsonToXmlJsonPath;
        private TextBox Tb_JsonToXmlXmlPath;
        private TabControl tabControl1;
        private Label L_JsonToXmlArchiveJsonPath;
        private TextBox Tb_JsonToXmlArchiveJsonPath;
        private CheckBox Cb_JsonToXmlUseLogging;
    }
}
