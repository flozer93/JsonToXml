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
            this.Btn_SaveConfig = new System.Windows.Forms.Button();
            this.Btn_SaveExit = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.Btn_SaveConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SaveConfig.Location = new System.Drawing.Point(713, 415);
            this.Btn_SaveConfig.Name = "Btn_SaveConfig";
            this.Btn_SaveConfig.Size = new System.Drawing.Size(75, 23);
            this.Btn_SaveConfig.TabIndex = 6;
            this.Btn_SaveConfig.Text = "Save";
            this.Btn_SaveConfig.UseVisualStyleBackColor = true;
            this.Btn_SaveConfig.Click += new System.EventHandler(this.Btn_SaveConfig_Click);
            // 
            // Btn_SaveExit
            // 
            this.Btn_SaveExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SaveExit.Location = new System.Drawing.Point(609, 415);
            this.Btn_SaveExit.Name = "Btn_SaveExit";
            this.Btn_SaveExit.Size = new System.Drawing.Size(98, 23);
            this.Btn_SaveExit.TabIndex = 8;
            this.Btn_SaveExit.Text = "Save and Exit";
            this.Btn_SaveExit.UseVisualStyleBackColor = true;
            this.Btn_SaveExit.Click += new System.EventHandler(this.Btn_SaveExit_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.L_JsonToXmlArchiveJsonPath);
            this.tabPage1.Controls.Add(this.Tb_JsonToXmlArchiveJsonPath);
            this.tabPage1.Controls.Add(this.Cb_JsonToXmlUseConverter);
            this.tabPage1.Controls.Add(this.L_JsonPath);
            this.tabPage1.Controls.Add(this.L_XmlPath);
            this.tabPage1.Controls.Add(this.Tb_JsonToXmlJsonPath);
            this.tabPage1.Controls.Add(this.Tb_JsonToXmlXmlPath);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Json to Xml";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // L_JsonToXmlArchiveJsonPath
            // 
            this.L_JsonToXmlArchiveJsonPath.AutoSize = true;
            this.L_JsonToXmlArchiveJsonPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_JsonToXmlArchiveJsonPath.Location = new System.Drawing.Point(6, 66);
            this.L_JsonToXmlArchiveJsonPath.Name = "L_JsonToXmlArchiveJsonPath";
            this.L_JsonToXmlArchiveJsonPath.Size = new System.Drawing.Size(114, 13);
            this.L_JsonToXmlArchiveJsonPath.TabIndex = 116;
            this.L_JsonToXmlArchiveJsonPath.Text = "Json Archive Path:";
            // 
            // Tb_JsonToXmlArchiveJsonPath
            // 
            this.Tb_JsonToXmlArchiveJsonPath.Location = new System.Drawing.Point(129, 63);
            this.Tb_JsonToXmlArchiveJsonPath.Name = "Tb_JsonToXmlArchiveJsonPath";
            this.Tb_JsonToXmlArchiveJsonPath.Size = new System.Drawing.Size(633, 20);
            this.Tb_JsonToXmlArchiveJsonPath.TabIndex = 117;
            // 
            // Cb_JsonToXmlUseConverter
            // 
            this.Cb_JsonToXmlUseConverter.AutoSize = true;
            this.Cb_JsonToXmlUseConverter.Location = new System.Drawing.Point(9, 348);
            this.Cb_JsonToXmlUseConverter.Name = "Cb_JsonToXmlUseConverter";
            this.Cb_JsonToXmlUseConverter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cb_JsonToXmlUseConverter.Size = new System.Drawing.Size(151, 17);
            this.Cb_JsonToXmlUseConverter.TabIndex = 115;
            this.Cb_JsonToXmlUseConverter.Text = "Use Json to Xml Converter";
            this.Cb_JsonToXmlUseConverter.UseVisualStyleBackColor = true;
            this.Cb_JsonToXmlUseConverter.Visible = false;
            // 
            // L_JsonPath
            // 
            this.L_JsonPath.AutoSize = true;
            this.L_JsonPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_JsonPath.Location = new System.Drawing.Point(6, 14);
            this.L_JsonPath.Name = "L_JsonPath";
            this.L_JsonPath.Size = new System.Drawing.Size(67, 13);
            this.L_JsonPath.TabIndex = 1;
            this.L_JsonPath.Text = "Json Path:";
            // 
            // L_XmlPath
            // 
            this.L_XmlPath.AutoSize = true;
            this.L_XmlPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_XmlPath.Location = new System.Drawing.Point(6, 40);
            this.L_XmlPath.Name = "L_XmlPath";
            this.L_XmlPath.Size = new System.Drawing.Size(66, 13);
            this.L_XmlPath.TabIndex = 3;
            this.L_XmlPath.Text = "XML Path:";
            // 
            // Tb_JsonToXmlJsonPath
            // 
            this.Tb_JsonToXmlJsonPath.Location = new System.Drawing.Point(129, 11);
            this.Tb_JsonToXmlJsonPath.Name = "Tb_JsonToXmlJsonPath";
            this.Tb_JsonToXmlJsonPath.Size = new System.Drawing.Size(633, 20);
            this.Tb_JsonToXmlJsonPath.TabIndex = 2;
            // 
            // Tb_JsonToXmlXmlPath
            // 
            this.Tb_JsonToXmlXmlPath.Location = new System.Drawing.Point(129, 37);
            this.Tb_JsonToXmlXmlPath.Name = "Tb_JsonToXmlXmlPath";
            this.Tb_JsonToXmlXmlPath.Size = new System.Drawing.Size(633, 20);
            this.Tb_JsonToXmlXmlPath.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 397);
            this.tabControl1.TabIndex = 7;
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_SaveExit);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Btn_SaveConfig);
            this.Name = "FormConfig";
            this.Text = "Config";
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
    }
}
