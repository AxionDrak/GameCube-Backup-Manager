
using System.ComponentModel;
using System.Windows.Forms;

namespace GCBM
{
    partial class frmDownloadGameTDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadGameTDB));
            this.lblDownload = new System.Windows.Forms.Label();
            this.lblExtracting = new System.Windows.Forms.Label();
            this.lblConverting = new System.Windows.Forms.Label();
            this.pbGameTDB = new System.Windows.Forms.ProgressBar();
            this.btnCancelWork = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDownload
            // 
            resources.ApplyResources(this.lblDownload, "lblDownload");
            this.lblDownload.Name = "lblDownload";
            // 
            // lblExtracting
            // 
            resources.ApplyResources(this.lblExtracting, "lblExtracting");
            this.lblExtracting.Name = "lblExtracting";
            // 
            // lblConverting
            // 
            resources.ApplyResources(this.lblConverting, "lblConverting");
            this.lblConverting.Name = "lblConverting";
            // 
            // pbGameTDB
            // 
            resources.ApplyResources(this.pbGameTDB, "pbGameTDB");
            this.pbGameTDB.Name = "pbGameTDB";
            // 
            // btnCancelWork
            // 
            resources.ApplyResources(this.btnCancelWork, "btnCancelWork");
            this.btnCancelWork.Name = "btnCancelWork";
            this.btnCancelWork.UseVisualStyleBackColor = true;
            this.btnCancelWork.Click += new System.EventHandler(this.btnCancelWork_Click);
            // 
            // frmDownloadGameTDB
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelWork);
            this.Controls.Add(this.pbGameTDB);
            this.Controls.Add(this.lblConverting);
            this.Controls.Add(this.lblExtracting);
            this.Controls.Add(this.lblDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownloadGameTDB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.frmDownloadGameTDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblDownload;
        private Label lblExtracting;
        private Label lblConverting;
        private ProgressBar pbGameTDB;
        private Button btnCancelWork;
    }
}