
namespace GCBM
{
    partial class frmTransferCover
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferCover));
            this.lblTransferStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTransferAllRegions = new System.Windows.Forms.CheckBox();
            this.rbJapan = new System.Windows.Forms.RadioButton();
            this.rbEurope = new System.Windows.Forms.RadioButton();
            this.rbUsa = new System.Windows.Forms.RadioButton();
            this.pbCoverCopy = new System.Windows.Forms.ProgressBar();
            this.bgWorkerIndeterminate = new System.ComponentModel.BackgroundWorker();
            this.btnTaskCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTaskIndeterminate = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTransferStatus
            // 
            resources.ApplyResources(this.lblTransferStatus, "lblTransferStatus");
            this.lblTransferStatus.Name = "lblTransferStatus";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.chkTransferAllRegions);
            this.groupBox1.Controls.Add(this.rbJapan);
            this.groupBox1.Controls.Add(this.rbEurope);
            this.groupBox1.Controls.Add(this.rbUsa);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkTransferAllRegions
            // 
            resources.ApplyResources(this.chkTransferAllRegions, "chkTransferAllRegions");
            this.chkTransferAllRegions.Name = "chkTransferAllRegions";
            this.chkTransferAllRegions.UseVisualStyleBackColor = true;
            this.chkTransferAllRegions.CheckedChanged += new System.EventHandler(this.chkTransferAllRegions_CheckedChanged);
            // 
            // rbJapan
            // 
            resources.ApplyResources(this.rbJapan, "rbJapan");
            this.rbJapan.Name = "rbJapan";
            this.rbJapan.UseVisualStyleBackColor = true;
            // 
            // rbEurope
            // 
            resources.ApplyResources(this.rbEurope, "rbEurope");
            this.rbEurope.Name = "rbEurope";
            this.rbEurope.UseVisualStyleBackColor = true;
            // 
            // rbUsa
            // 
            resources.ApplyResources(this.rbUsa, "rbUsa");
            this.rbUsa.Checked = true;
            this.rbUsa.Name = "rbUsa";
            this.rbUsa.TabStop = true;
            this.rbUsa.UseVisualStyleBackColor = true;
            // 
            // pbCoverCopy
            // 
            resources.ApplyResources(this.pbCoverCopy, "pbCoverCopy");
            this.pbCoverCopy.Name = "pbCoverCopy";
            // 
            // bgWorkerIndeterminate
            // 
            this.bgWorkerIndeterminate.WorkerSupportsCancellation = true;
            this.bgWorkerIndeterminate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerIndeterminate_DoWork);
            this.bgWorkerIndeterminate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerIndeterminate_RunWorkerCompleted);
            // 
            // btnTaskCancel
            // 
            resources.ApplyResources(this.btnTaskCancel, "btnTaskCancel");
            this.btnTaskCancel.Name = "btnTaskCancel";
            this.btnTaskCancel.UseVisualStyleBackColor = true;
            this.btnTaskCancel.Click += new System.EventHandler(this.btnTaskCancel_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTaskIndeterminate
            // 
            resources.ApplyResources(this.btnTaskIndeterminate, "btnTaskIndeterminate");
            this.btnTaskIndeterminate.Name = "btnTaskIndeterminate";
            this.btnTaskIndeterminate.UseVisualStyleBackColor = true;
            this.btnTaskIndeterminate.Click += new System.EventHandler(this.btnTaskIndeterminate_Click);
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            // 
            // frmTransferCover
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTaskIndeterminate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTaskCancel);
            this.Controls.Add(this.pbCoverCopy);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTransferStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransferCover";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTransferStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkTransferAllRegions;
        private System.Windows.Forms.RadioButton rbJapan;
        private System.Windows.Forms.RadioButton rbEurope;
        private System.Windows.Forms.RadioButton rbUsa;
        private System.Windows.Forms.ProgressBar pbCoverCopy;
        private System.ComponentModel.BackgroundWorker bgWorkerIndeterminate;
        private System.Windows.Forms.Button btnTaskCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTaskIndeterminate;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}