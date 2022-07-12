
using System.ComponentModel;
using System.Windows.Forms;

namespace GCBM
{
    partial class frmSplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplashScreen));
            this.tsslCurrentYear = new System.Windows.Forms.Label();
            this.lblAllRightsReserved = new System.Windows.Forms.Label();
            this.pbSplashScreen = new System.Windows.Forms.ProgressBar();
            this.lblStartSplashScreen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tsslCurrentYear
            // 
            resources.ApplyResources(this.tsslCurrentYear, "tsslCurrentYear");
            this.tsslCurrentYear.BackColor = System.Drawing.Color.White;
            this.tsslCurrentYear.Name = "tsslCurrentYear";
            // 
            // lblAllRightsReserved
            // 
            resources.ApplyResources(this.lblAllRightsReserved, "lblAllRightsReserved");
            this.lblAllRightsReserved.BackColor = System.Drawing.Color.White;
            this.lblAllRightsReserved.Name = "lblAllRightsReserved";
            // 
            // pbSplashScreen
            // 
            resources.ApplyResources(this.pbSplashScreen, "pbSplashScreen");
            this.pbSplashScreen.Name = "pbSplashScreen";
            // 
            // lblStartSplashScreen
            // 
            resources.ApplyResources(this.lblStartSplashScreen, "lblStartSplashScreen");
            this.lblStartSplashScreen.BackColor = System.Drawing.Color.White;
            this.lblStartSplashScreen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStartSplashScreen.Name = "lblStartSplashScreen";
            // 
            // frmSplashScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStartSplashScreen);
            this.Controls.Add(this.pbSplashScreen);
            this.Controls.Add(this.lblAllRightsReserved);
            this.Controls.Add(this.tsslCurrentYear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplashScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label tsslCurrentYear;
        private Label lblAllRightsReserved;
        private ProgressBar pbSplashScreen;
        private Label lblStartSplashScreen;
    }
}