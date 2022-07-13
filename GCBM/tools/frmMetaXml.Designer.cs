
using System.ComponentModel;
using System.Windows.Forms;

namespace GCBM.tools
{
    partial class frmMetaXml
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMetaXml));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbPortUSB = new System.Windows.Forms.ComboBox();
            this.chkEnableArguments = new System.Windows.Forms.CheckBox();
            this.lblIOS = new System.Windows.Forms.Label();
            this.tbIOS = new System.Windows.Forms.TextBox();
            this.lblUsbPort = new System.Windows.Forms.Label();
            this.cbMountUSB = new System.Windows.Forms.ComboBox();
            this.cbAppAhbAccess = new System.Windows.Forms.ComboBox();
            this.lblMountUsb = new System.Windows.Forms.Label();
            this.cbAppNoReloadIOS = new System.Windows.Forms.ComboBox();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDeleteBanner = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddBanner = new System.Windows.Forms.Button();
            this.tbAppReleaseDate = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblImageNotFound = new System.Windows.Forms.Label();
            this.lblAttentionImageNotFound = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAppLongDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAppShortDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAppVersion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAppDeveloper = new System.Windows.Forms.TextBox();
            this.tbAppName = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ofdXml = new System.Windows.Forms.OpenFileDialog();
            this.ofdBanner = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tbAppReleaseDate);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.lblImageNotFound);
            this.groupBox1.Controls.Add(this.lblAttentionImageNotFound);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbAppLongDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbAppShortDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbAppVersion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbAppDeveloper);
            this.groupBox1.Controls.Add(this.tbAppName);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.cbPortUSB);
            this.groupBox2.Controls.Add(this.chkEnableArguments);
            this.groupBox2.Controls.Add(this.lblIOS);
            this.groupBox2.Controls.Add(this.tbIOS);
            this.groupBox2.Controls.Add(this.lblUsbPort);
            this.groupBox2.Controls.Add(this.cbMountUSB);
            this.groupBox2.Controls.Add(this.cbAppAhbAccess);
            this.groupBox2.Controls.Add(this.lblMountUsb);
            this.groupBox2.Controls.Add(this.cbAppNoReloadIOS);
            this.groupBox2.Controls.Add(this.pbBanner);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnDeleteBanner);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnAddBanner);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // cbPortUSB
            // 
            resources.ApplyResources(this.cbPortUSB, "cbPortUSB");
            this.cbPortUSB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPortUSB.FormattingEnabled = true;
            this.cbPortUSB.Items.AddRange(new object[] {
            resources.GetString("cbPortUSB.Items"),
            resources.GetString("cbPortUSB.Items1"),
            resources.GetString("cbPortUSB.Items2")});
            this.cbPortUSB.Name = "cbPortUSB";
            // 
            // chkEnableArguments
            // 
            resources.ApplyResources(this.chkEnableArguments, "chkEnableArguments");
            this.chkEnableArguments.Name = "chkEnableArguments";
            this.chkEnableArguments.UseVisualStyleBackColor = true;
            // 
            // lblIOS
            // 
            resources.ApplyResources(this.lblIOS, "lblIOS");
            this.lblIOS.Name = "lblIOS";
            // 
            // tbIOS
            // 
            resources.ApplyResources(this.tbIOS, "tbIOS");
            this.tbIOS.Name = "tbIOS";
            // 
            // lblUsbPort
            // 
            resources.ApplyResources(this.lblUsbPort, "lblUsbPort");
            this.lblUsbPort.Name = "lblUsbPort";
            // 
            // cbMountUSB
            // 
            resources.ApplyResources(this.cbMountUSB, "cbMountUSB");
            this.cbMountUSB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMountUSB.FormattingEnabled = true;
            this.cbMountUSB.Items.AddRange(new object[] {
            resources.GetString("cbMountUSB.Items"),
            resources.GetString("cbMountUSB.Items1"),
            resources.GetString("cbMountUSB.Items2")});
            this.cbMountUSB.Name = "cbMountUSB";
            // 
            // cbAppAhbAccess
            // 
            resources.ApplyResources(this.cbAppAhbAccess, "cbAppAhbAccess");
            this.cbAppAhbAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAppAhbAccess.FormattingEnabled = true;
            this.cbAppAhbAccess.Items.AddRange(new object[] {
            resources.GetString("cbAppAhbAccess.Items"),
            resources.GetString("cbAppAhbAccess.Items1")});
            this.cbAppAhbAccess.Name = "cbAppAhbAccess";
            // 
            // lblMountUsb
            // 
            resources.ApplyResources(this.lblMountUsb, "lblMountUsb");
            this.lblMountUsb.Name = "lblMountUsb";
            // 
            // cbAppNoReloadIOS
            // 
            resources.ApplyResources(this.cbAppNoReloadIOS, "cbAppNoReloadIOS");
            this.cbAppNoReloadIOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAppNoReloadIOS.FormattingEnabled = true;
            this.cbAppNoReloadIOS.Items.AddRange(new object[] {
            resources.GetString("cbAppNoReloadIOS.Items"),
            resources.GetString("cbAppNoReloadIOS.Items1")});
            this.cbAppNoReloadIOS.Name = "cbAppNoReloadIOS";
            // 
            // pbBanner
            // 
            resources.ApplyResources(this.pbBanner, "pbBanner");
            this.pbBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBanner.ErrorImage = global::GCBM.Properties.Resources.image_not_found_2;
            this.pbBanner.Image = global::GCBM.Properties.Resources.image_not_found_1;
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.TabStop = false;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // btnDeleteBanner
            // 
            resources.ApplyResources(this.btnDeleteBanner, "btnDeleteBanner");
            this.btnDeleteBanner.Image = global::GCBM.Properties.Resources.Remove;
            this.btnDeleteBanner.Name = "btnDeleteBanner";
            this.btnDeleteBanner.UseVisualStyleBackColor = true;
            this.btnDeleteBanner.Click += new System.EventHandler(this.btnDeleteBanner_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // btnAddBanner
            // 
            resources.ApplyResources(this.btnAddBanner, "btnAddBanner");
            this.btnAddBanner.Image = global::GCBM.Properties.Resources.add;
            this.btnAddBanner.Name = "btnAddBanner";
            this.btnAddBanner.UseVisualStyleBackColor = true;
            this.btnAddBanner.Click += new System.EventHandler(this.btnAddBanner_Click);
            // 
            // tbAppReleaseDate
            // 
            resources.ApplyResources(this.tbAppReleaseDate, "tbAppReleaseDate");
            this.tbAppReleaseDate.Name = "tbAppReleaseDate";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Image = global::GCBM.Properties.Resources.cancel_32;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblImageNotFound
            // 
            resources.ApplyResources(this.lblImageNotFound, "lblImageNotFound");
            this.lblImageNotFound.ForeColor = System.Drawing.Color.Red;
            this.lblImageNotFound.Name = "lblImageNotFound";
            // 
            // lblAttentionImageNotFound
            // 
            resources.ApplyResources(this.lblAttentionImageNotFound, "lblAttentionImageNotFound");
            this.lblAttentionImageNotFound.ForeColor = System.Drawing.Color.Red;
            this.lblAttentionImageNotFound.Name = "lblAttentionImageNotFound";
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Image = global::GCBM.Properties.Resources.eraser_32;
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Image = global::GCBM.Properties.Resources.save_32;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Image = global::GCBM.Properties.Resources.open_folder_32;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tbAppLongDescription
            // 
            resources.ApplyResources(this.tbAppLongDescription, "tbAppLongDescription");
            this.tbAppLongDescription.Name = "tbAppLongDescription";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tbAppShortDescription
            // 
            resources.ApplyResources(this.tbAppShortDescription, "tbAppShortDescription");
            this.tbAppShortDescription.Name = "tbAppShortDescription";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tbAppVersion
            // 
            resources.ApplyResources(this.tbAppVersion, "tbAppVersion");
            this.tbAppVersion.Name = "tbAppVersion";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tbAppDeveloper
            // 
            resources.ApplyResources(this.tbAppDeveloper, "tbAppDeveloper");
            this.tbAppDeveloper.Name = "tbAppDeveloper";
            // 
            // tbAppName
            // 
            resources.ApplyResources(this.tbAppName, "tbAppName");
            this.tbAppName.Name = "tbAppName";
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            // 
            // ofdXml
            // 
            resources.ApplyResources(this.ofdXml, "ofdXml");
            // 
            // ofdBanner
            // 
            resources.ApplyResources(this.ofdBanner, "ofdBanner");
            // 
            // frmMetaXml
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMetaXml";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox cbPortUSB;
        private CheckBox chkEnableArguments;
        private Label lblIOS;
        private TextBox tbIOS;
        private Label lblUsbPort;
        private ComboBox cbMountUSB;
        private ComboBox cbAppAhbAccess;
        private Label lblMountUsb;
        private ComboBox cbAppNoReloadIOS;
        private PictureBox pbBanner;
        private Label label9;
        private Label label7;
        private Button btnDeleteBanner;
        private Label label8;
        private Button btnAddBanner;
        private TextBox tbAppReleaseDate;
        private Button btnClose;
        private Label lblImageNotFound;
        private Label lblAttentionImageNotFound;
        private Button btnClear;
        private Button btnSave;
        private Button btnSearch;
        private Label label1;
        private Label label2;
        private TextBox tbAppLongDescription;
        private Label label3;
        private TextBox tbAppShortDescription;
        private Label label4;
        private Label label5;
        private TextBox tbAppVersion;
        private Label label6;
        private TextBox tbAppDeveloper;
        private TextBox tbAppName;
        private NotifyIcon notifyIcon;
        private OpenFileDialog ofdXml;
        private OpenFileDialog ofdBanner;
    }
}