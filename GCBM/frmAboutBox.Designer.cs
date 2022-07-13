
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GCBM.Properties;

namespace GCBM
{
    partial class frmAboutBox
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(frmAboutBox));
            this.tableLayoutPanel = new TableLayoutPanel();
            this.logoPictureBox = new PictureBox();
            this.labelProductName = new Label();
            this.labelVersion = new Label();
            this.labelCopyright = new Label();
            this.labelCompanyName = new Label();
            this.textBoxDescription = new TextBox();
            this.okButton = new Button();
            this.tabControl1 = new TabControl();
            this.tpGCBM = new TabPage();
            this.tbTranslator = new TabPage();
            this.lbl_DataAtualizacao = new Label();
            this.lblAboutCurrentLanguage = new Label();
            this.lblAboutTranslator = new Label();
            this.lblAboutVersion = new Label();
            this.lblAboutProgramName = new Label();
            this.tbGameTDB = new TabPage();
            this.rtbAboutGameTDB = new RichTextBox();
            this.pbGameTDB = new PictureBox();
            this.tbThanks = new TabPage();
            this.rtbAboutThanks = new RichTextBox();
            this.tbDonate = new TabPage();
            this.pbDonations = new PictureBox();
            this.rtbAboutDonations = new RichTextBox();
            this.tableLayoutPanel.SuspendLayout();
            ((ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpGCBM.SuspendLayout();
            this.tbTranslator.SuspendLayout();
            this.tbGameTDB.SuspendLayout();
            ((ISupportInitialize)(this.pbGameTDB)).BeginInit();
            this.tbThanks.SuspendLayout();
            this.tbDonate.SuspendLayout();
            ((ISupportInitialize)(this.pbDonations)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // logoPictureBox
            // 
            resources.ApplyResources(this.logoPictureBox, "logoPictureBox");
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            resources.ApplyResources(this.labelProductName, "labelProductName");
            this.labelProductName.Name = "labelProductName";
            // 
            // labelVersion
            // 
            resources.ApplyResources(this.labelVersion, "labelVersion");
            this.labelVersion.Name = "labelVersion";
            // 
            // labelCopyright
            // 
            resources.ApplyResources(this.labelCopyright, "labelCopyright");
            this.labelCopyright.Name = "labelCopyright";
            // 
            // labelCompanyName
            // 
            resources.ApplyResources(this.labelCompanyName, "labelCompanyName");
            this.labelCompanyName.Name = "labelCompanyName";
            // 
            // textBoxDescription
            // 
            resources.ApplyResources(this.textBoxDescription, "textBoxDescription");
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.TabStop = false;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = DialogResult.Cancel;
            this.okButton.Name = "okButton";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpGCBM);
            this.tabControl1.Controls.Add(this.tbTranslator);
            this.tabControl1.Controls.Add(this.tbGameTDB);
            this.tabControl1.Controls.Add(this.tbThanks);
            this.tabControl1.Controls.Add(this.tbDonate);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tpGCBM
            // 
            this.tpGCBM.Controls.Add(this.tableLayoutPanel);
            resources.ApplyResources(this.tpGCBM, "tpGCBM");
            this.tpGCBM.Name = "tpGCBM";
            this.tpGCBM.UseVisualStyleBackColor = true;
            // 
            // tbTranslator
            // 
            this.tbTranslator.Controls.Add(this.lbl_DataAtualizacao);
            this.tbTranslator.Controls.Add(this.lblAboutCurrentLanguage);
            this.tbTranslator.Controls.Add(this.lblAboutTranslator);
            this.tbTranslator.Controls.Add(this.lblAboutVersion);
            this.tbTranslator.Controls.Add(this.lblAboutProgramName);
            resources.ApplyResources(this.tbTranslator, "tbTranslator");
            this.tbTranslator.Name = "tbTranslator";
            this.tbTranslator.UseVisualStyleBackColor = true;
            // 
            // lbl_DataAtualizacao
            // 
            resources.ApplyResources(this.lbl_DataAtualizacao, "lbl_DataAtualizacao");
            this.lbl_DataAtualizacao.Name = "lbl_DataAtualizacao";
            // 
            // lblAboutCurrentLanguage
            // 
            resources.ApplyResources(this.lblAboutCurrentLanguage, "lblAboutCurrentLanguage");
            this.lblAboutCurrentLanguage.Name = "lblAboutCurrentLanguage";
            // 
            // lblAboutTranslator
            // 
            resources.ApplyResources(this.lblAboutTranslator, "lblAboutTranslator");
            this.lblAboutTranslator.Name = "lblAboutTranslator";
            // 
            // lblAboutVersion
            // 
            resources.ApplyResources(this.lblAboutVersion, "lblAboutVersion");
            this.lblAboutVersion.Name = "lblAboutVersion";
            // 
            // lblAboutProgramName
            // 
            resources.ApplyResources(this.lblAboutProgramName, "lblAboutProgramName");
            this.lblAboutProgramName.Name = "lblAboutProgramName";
            // 
            // tbGameTDB
            // 
            this.tbGameTDB.Controls.Add(this.rtbAboutGameTDB);
            this.tbGameTDB.Controls.Add(this.pbGameTDB);
            resources.ApplyResources(this.tbGameTDB, "tbGameTDB");
            this.tbGameTDB.Name = "tbGameTDB";
            this.tbGameTDB.UseVisualStyleBackColor = true;
            // 
            // rtbAboutGameTDB
            // 
            this.rtbAboutGameTDB.BackColor = Color.White;
            this.rtbAboutGameTDB.BorderStyle = BorderStyle.None;
            resources.ApplyResources(this.rtbAboutGameTDB, "rtbAboutGameTDB");
            this.rtbAboutGameTDB.Name = "rtbAboutGameTDB";
            this.rtbAboutGameTDB.ReadOnly = true;
            // 
            // pbGameTDB
            // 
            this.pbGameTDB.Image = Resources.GameTDB_400;
            resources.ApplyResources(this.pbGameTDB, "pbGameTDB");
            this.pbGameTDB.Name = "pbGameTDB";
            this.pbGameTDB.TabStop = false;
            this.pbGameTDB.Click += new EventHandler(this.pbGameTDB_Click);
            this.pbGameTDB.MouseEnter += new EventHandler(this.pbGameTDB_MouseEnter);
            // 
            // tbThanks
            // 
            this.tbThanks.Controls.Add(this.rtbAboutThanks);
            resources.ApplyResources(this.tbThanks, "tbThanks");
            this.tbThanks.Name = "tbThanks";
            this.tbThanks.UseVisualStyleBackColor = true;
            // 
            // rtbAboutThanks
            // 
            this.rtbAboutThanks.BackColor = Color.White;
            this.rtbAboutThanks.BorderStyle = BorderStyle.None;
            resources.ApplyResources(this.rtbAboutThanks, "rtbAboutThanks");
            this.rtbAboutThanks.Name = "rtbAboutThanks";
            this.rtbAboutThanks.ReadOnly = true;
            // 
            // tbDonate
            // 
            this.tbDonate.Controls.Add(this.pbDonations);
            this.tbDonate.Controls.Add(this.rtbAboutDonations);
            resources.ApplyResources(this.tbDonate, "tbDonate");
            this.tbDonate.Name = "tbDonate";
            this.tbDonate.UseVisualStyleBackColor = true;
            // 
            // pbDonations
            // 
            this.pbDonations.Image = Resources.donate;
            resources.ApplyResources(this.pbDonations, "pbDonations");
            this.pbDonations.Name = "pbDonations";
            this.pbDonations.TabStop = false;
            this.pbDonations.Click += new EventHandler(this.pbDonations_Click);
            this.pbDonations.MouseEnter += new EventHandler(this.pbDonations_MouseEnter);
            // 
            // rtbAboutDonations
            // 
            this.rtbAboutDonations.BackColor = Color.White;
            this.rtbAboutDonations.BorderStyle = BorderStyle.None;
            resources.ApplyResources(this.rtbAboutDonations, "rtbAboutDonations");
            this.rtbAboutDonations.Name = "rtbAboutDonations";
            this.rtbAboutDonations.ReadOnly = true;
            // 
            // frmAboutBox
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAboutBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpGCBM.ResumeLayout(false);
            this.tbTranslator.ResumeLayout(false);
            this.tbTranslator.PerformLayout();
            this.tbGameTDB.ResumeLayout(false);
            ((ISupportInitialize)(this.pbGameTDB)).EndInit();
            this.tbThanks.ResumeLayout(false);
            this.tbDonate.ResumeLayout(false);
            ((ISupportInitialize)(this.pbDonations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private PictureBox logoPictureBox;
        private Label labelProductName;
        private Label labelVersion;
        private Label labelCopyright;
        private Label labelCompanyName;
        private TextBox textBoxDescription;
        private Button okButton;
        private TabControl tabControl1;
        private TabPage tpGCBM;
        private TabPage tbGameTDB;
        private TabPage tbThanks;
        private TabPage tbDonate;
        private PictureBox pbGameTDB;
        private RichTextBox rtbAboutGameTDB;
        private RichTextBox rtbAboutThanks;
        private RichTextBox rtbAboutDonations;
        private PictureBox pbDonations;
        private TabPage tbTranslator;
        private Label lblAboutTranslator;
        private Label lblAboutVersion;
        private Label lblAboutProgramName;
        private Label lblAboutCurrentLanguage;
        private Label lbl_DataAtualizacao;
    }
}
