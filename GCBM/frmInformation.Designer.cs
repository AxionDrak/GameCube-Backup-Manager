
using System.ComponentModel;
using System.Windows.Forms;

namespace GCBM
{
    partial class frmInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformation));
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbLanguageBanner = new System.Windows.Forms.ComboBox();
            this.tbDescriptionBanner = new System.Windows.Forms.TextBox();
            this.tbLanguageBanner = new System.Windows.Forms.TextBox();
            this.tbDeveloperBanner = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbDataApploader = new System.Windows.Forms.TextBox();
            this.tbDeveloper = new System.Windows.Forms.TextBox();
            this.tbRegion = new System.Windows.Forms.TextBox();
            this.tbIDGame = new System.Windows.Forms.TextBox();
            this.tbGameInternalName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFileFormat = new System.Windows.Forms.TextBox();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.pbBanner);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cbLanguageBanner);
            this.groupBox3.Controls.Add(this.tbDescriptionBanner);
            this.groupBox3.Controls.Add(this.tbLanguageBanner);
            this.groupBox3.Controls.Add(this.tbDeveloperBanner);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cbLanguageBanner
            // 
            resources.ApplyResources(this.cbLanguageBanner, "cbLanguageBanner");
            this.cbLanguageBanner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguageBanner.FormattingEnabled = true;
            this.cbLanguageBanner.Name = "cbLanguageBanner";
            // 
            // tbDescriptionBanner
            // 
            resources.ApplyResources(this.tbDescriptionBanner, "tbDescriptionBanner");
            this.tbDescriptionBanner.BackColor = System.Drawing.Color.White;
            this.tbDescriptionBanner.Name = "tbDescriptionBanner";
            this.tbDescriptionBanner.ReadOnly = true;
            // 
            // tbLanguageBanner
            // 
            resources.ApplyResources(this.tbLanguageBanner, "tbLanguageBanner");
            this.tbLanguageBanner.BackColor = System.Drawing.Color.White;
            this.tbLanguageBanner.Name = "tbLanguageBanner";
            this.tbLanguageBanner.ReadOnly = true;
            // 
            // tbDeveloperBanner
            // 
            resources.ApplyResources(this.tbDeveloperBanner, "tbDeveloperBanner");
            this.tbDeveloperBanner.BackColor = System.Drawing.Color.White;
            this.tbDeveloperBanner.Name = "tbDeveloperBanner";
            this.tbDeveloperBanner.ReadOnly = true;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.tbDataApploader);
            this.groupBox2.Controls.Add(this.tbDeveloper);
            this.groupBox2.Controls.Add(this.tbRegion);
            this.groupBox2.Controls.Add(this.tbIDGame);
            this.groupBox2.Controls.Add(this.tbGameInternalName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // tbDataApploader
            // 
            resources.ApplyResources(this.tbDataApploader, "tbDataApploader");
            this.tbDataApploader.BackColor = System.Drawing.Color.White;
            this.tbDataApploader.Name = "tbDataApploader";
            this.tbDataApploader.ReadOnly = true;
            // 
            // tbDeveloper
            // 
            resources.ApplyResources(this.tbDeveloper, "tbDeveloper");
            this.tbDeveloper.BackColor = System.Drawing.Color.White;
            this.tbDeveloper.Name = "tbDeveloper";
            this.tbDeveloper.ReadOnly = true;
            // 
            // tbRegion
            // 
            resources.ApplyResources(this.tbRegion, "tbRegion");
            this.tbRegion.BackColor = System.Drawing.Color.White;
            this.tbRegion.Name = "tbRegion";
            this.tbRegion.ReadOnly = true;
            // 
            // tbIDGame
            // 
            resources.ApplyResources(this.tbIDGame, "tbIDGame");
            this.tbIDGame.BackColor = System.Drawing.Color.White;
            this.tbIDGame.Name = "tbIDGame";
            this.tbIDGame.ReadOnly = true;
            // 
            // tbGameInternalName
            // 
            resources.ApplyResources(this.tbGameInternalName, "tbGameInternalName");
            this.tbGameInternalName.BackColor = System.Drawing.Color.White;
            this.tbGameInternalName.Name = "tbGameInternalName";
            this.tbGameInternalName.ReadOnly = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.tbFileFormat);
            this.groupBox1.Controls.Add(this.tbFilePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tbFileFormat
            // 
            resources.ApplyResources(this.tbFileFormat, "tbFileFormat");
            this.tbFileFormat.BackColor = System.Drawing.Color.White;
            this.tbFileFormat.Name = "tbFileFormat";
            this.tbFileFormat.ReadOnly = true;
            // 
            // tbFilePath
            // 
            resources.ApplyResources(this.tbFilePath, "tbFilePath");
            this.tbFilePath.BackColor = System.Drawing.Color.White;
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pbBanner
            // 
            resources.ApplyResources(this.pbBanner, "pbBanner");
            this.pbBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.TabStop = false;
            // 
            // frmInformation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInformation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnClose;
        private GroupBox groupBox3;
        private PictureBox pbBanner;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private ComboBox cbLanguageBanner;
        private TextBox tbDescriptionBanner;
        private TextBox tbLanguageBanner;
        private TextBox tbDeveloperBanner;
        private GroupBox groupBox2;
        private TextBox tbDataApploader;
        private TextBox tbDeveloper;
        private TextBox tbRegion;
        private TextBox tbIDGame;
        private TextBox tbGameInternalName;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private GroupBox groupBox1;
        private TextBox tbFileFormat;
        private TextBox tbFilePath;
        private Label label2;
        private Label label1;
    }
}