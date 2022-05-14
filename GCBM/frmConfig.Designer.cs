
namespace GCBM
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabSettingsGeneral = new System.Windows.Forms.TabPage();
            this.grbGeneralTemporaryFolder = new System.Windows.Forms.GroupBox();
            this.btnTemporaryFolder = new System.Windows.Forms.Button();
            this.tbGeneralTempPath = new System.Windows.Forms.TextBox();
            this.grbGeneralFiles = new System.Windows.Forms.GroupBox();
            this.chkGeneralExtractNwb = new System.Windows.Forms.CheckBox();
            this.chkGeneralExtractSplitFile = new System.Windows.Forms.CheckBox();
            this.chkGeneralExtractBZip2 = new System.Windows.Forms.CheckBox();
            this.chkGeneralExtractRar = new System.Windows.Forms.CheckBox();
            this.chkGeneralExtract7z = new System.Windows.Forms.CheckBox();
            this.chkGeneralExtractZip = new System.Windows.Forms.CheckBox();
            this.lblGeneralExtract = new System.Windows.Forms.Label();
            this.grbGeneralFileSize = new System.Windows.Forms.GroupBox();
            this.cbGeneralFileSize = new System.Windows.Forms.ComboBox();
            this.grbGeneralPartitions = new System.Windows.Forms.GroupBox();
            this.rbGeneralDiscDelete = new System.Windows.Forms.RadioButton();
            this.rbGeneralDiscClean = new System.Windows.Forms.RadioButton();
            this.tabSettingsNomenclature = new System.Windows.Forms.TabPage();
            this.lblCommentsScrubCopy = new System.Windows.Forms.Label();
            this.lblCommentsExactCopy = new System.Windows.Forms.Label();
            this.lblComments = new System.Windows.Forms.Label();
            this.grpNomenclatureFolderFormat = new System.Windows.Forms.GroupBox();
            this.cbAdjustNamingStyle = new System.Windows.Forms.ComboBox();
            this.lblNomenclature = new System.Windows.Forms.Label();
            this.tabSettingsSeveral = new System.Windows.Forms.TabPage();
            this.grbGeneralDiverse = new System.Windows.Forms.GroupBox();
            this.chkMultipleInstances = new System.Windows.Forms.CheckBox();
            this.chkLoadDatabase = new System.Windows.Forms.CheckBox();
            this.chkNotify = new System.Windows.Forms.CheckBox();
            this.chkScreensaver = new System.Windows.Forms.CheckBox();
            this.chkWelcome = new System.Windows.Forms.CheckBox();
            this.chkNetVerify = new System.Windows.Forms.CheckBox();
            this.chkStartWindowMaximized = new System.Windows.Forms.CheckBox();
            this.chkGeneralSHA1 = new System.Windows.Forms.CheckBox();
            this.chkGeneralRecursiva = new System.Windows.Forms.CheckBox();
            this.chkGeneralTemporaryBuffer = new System.Windows.Forms.CheckBox();
            this.chkGeneralMD5 = new System.Windows.Forms.CheckBox();
            this.tabSettingsTransfer = new System.Windows.Forms.TabPage();
            this.grbGeneralScrub = new System.Windows.Forms.GroupBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.lblAlignment = new System.Windows.Forms.Label();
            this.cbScrubFormat = new System.Windows.Forms.ComboBox();
            this.cbScrubAlign = new System.Windows.Forms.ComboBox();
            this.chkGeneralScrubFlushSD = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblScrub = new System.Windows.Forms.Label();
            this.lblWipe = new System.Windows.Forms.Label();
            this.lblFST = new System.Windows.Forms.Label();
            this.lblXCopy = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.grbTransferSystem = new System.Windows.Forms.GroupBox();
            this.rbTransferSystemFST = new System.Windows.Forms.RadioButton();
            this.rbTransferSystemWipe = new System.Windows.Forms.RadioButton();
            this.rbTransferSystemXCopy = new System.Windows.Forms.RadioButton();
            this.tabSettingsCovers = new System.Windows.Forms.TabPage();
            this.grpTitlesCoverFolder = new System.Windows.Forms.GroupBox();
            this.btnCoverDirectory = new System.Windows.Forms.Button();
            this.tbDirectoryCoverCache = new System.Windows.Forms.TextBox();
            this.grbCoverTransfer = new System.Windows.Forms.GroupBox();
            this.rbCoverUSBLoaderGX = new System.Windows.Forms.RadioButton();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabCoverDisc = new System.Windows.Forms.TabPage();
            this.btnDirectoryCoverDisc = new System.Windows.Forms.Button();
            this.tbDirectoryCoverDisc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabCoverFront = new System.Windows.Forms.TabPage();
            this.btnDirectoryCover2D = new System.Windows.Forms.Button();
            this.tbDirectoryCover2D = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabCover3D = new System.Windows.Forms.TabPage();
            this.btnDirectoryCover3D = new System.Windows.Forms.Button();
            this.tbDirectoryCover3D = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabCoverFull = new System.Windows.Forms.TabPage();
            this.btnDirectoryCoverFull = new System.Windows.Forms.Button();
            this.tbDirectoryCoverFull = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.rbCoverWiiFlow = new System.Windows.Forms.RadioButton();
            this.grpCoversSynchronize = new System.Windows.Forms.GroupBox();
            this.chkCoverRecursiveSearch = new System.Windows.Forms.CheckBox();
            this.chkCoverEnableTransfer = new System.Windows.Forms.CheckBox();
            this.chkCoverSynchronizeDelete = new System.Windows.Forms.CheckBox();
            this.tabSettingsTitle = new System.Windows.Forms.TabPage();
            this.grbTitleLanguage = new System.Windows.Forms.GroupBox();
            this.btnTitleDownload = new System.Windows.Forms.Button();
            this.cbTitleLanguage = new System.Windows.Forms.ComboBox();
            this.grbTitleFileLocation = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTitleCustom = new System.Windows.Forms.Button();
            this.btnTitle = new System.Windows.Forms.Button();
            this.tbTitleCustom = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.grbTitleDiverse = new System.Windows.Forms.GroupBox();
            this.rbGameXmlName = new System.Windows.Forms.RadioButton();
            this.rbGameInternalName = new System.Windows.Forms.RadioButton();
            this.chkGameTitleCustom = new System.Windows.Forms.CheckBox();
            this.chkGameTitle = new System.Windows.Forms.CheckBox();
            this.tabSettingsUpdates = new System.Windows.Forms.TabPage();
            this.lblTimeInterval = new System.Windows.Forms.Label();
            this.grbUpdate = new System.Windows.Forms.GroupBox();
            this.cbVerificationInterval = new System.Windows.Forms.ComboBox();
            this.lblUpdateInterval = new System.Windows.Forms.Label();
            this.tbPassProxy = new System.Windows.Forms.TextBox();
            this.tbUserProxy = new System.Windows.Forms.TextBox();
            this.tbServerProxy = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblServerProxy = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkUpdateServerProxy = new System.Windows.Forms.CheckBox();
            this.chkUpdateFileLog = new System.Windows.Forms.CheckBox();
            this.chkUpdateBetaChannel = new System.Windows.Forms.CheckBox();
            this.chkUpdateVerifyStart = new System.Windows.Forms.CheckBox();
            this.tabSettingsLanguage = new System.Windows.Forms.TabPage();
            this.lblLanguageComments = new System.Windows.Forms.Label();
            this.grbLanguage = new System.Windows.Forms.GroupBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.tabSettingsLog = new System.Windows.Forms.TabPage();
            this.grbLog = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblLOG = new System.Windows.Forms.Label();
            this.chkManagerLogFile = new System.Windows.Forms.CheckBox();
            this.chkManagerLogWindow = new System.Windows.Forms.CheckBox();
            this.chkManagerLogDebugConsole = new System.Windows.Forms.CheckBox();
            this.chkManagerLogSystemConsole = new System.Windows.Forms.CheckBox();
            this.cbLevelLog = new System.Windows.Forms.ComboBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.btnApply = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabSettingsDolphin = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.tbPathDolphinEmulator = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbHLE = new System.Windows.Forms.RadioButton();
            this.rbLLE = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbOpenGL = new System.Windows.Forms.RadioButton();
            this.rbD3D12 = new System.Windows.Forms.RadioButton();
            this.rbD3D11 = new System.Windows.Forms.RadioButton();
            this.ofdDolphin = new System.Windows.Forms.OpenFileDialog();
            this.tabSettings.SuspendLayout();
            this.tabSettingsGeneral.SuspendLayout();
            this.grbGeneralTemporaryFolder.SuspendLayout();
            this.grbGeneralFiles.SuspendLayout();
            this.grbGeneralFileSize.SuspendLayout();
            this.grbGeneralPartitions.SuspendLayout();
            this.tabSettingsNomenclature.SuspendLayout();
            this.grpNomenclatureFolderFormat.SuspendLayout();
            this.tabSettingsSeveral.SuspendLayout();
            this.grbGeneralDiverse.SuspendLayout();
            this.tabSettingsTransfer.SuspendLayout();
            this.grbGeneralScrub.SuspendLayout();
            this.grbTransferSystem.SuspendLayout();
            this.tabSettingsCovers.SuspendLayout();
            this.grpTitlesCoverFolder.SuspendLayout();
            this.grbCoverTransfer.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabCoverDisc.SuspendLayout();
            this.tabCoverFront.SuspendLayout();
            this.tabCover3D.SuspendLayout();
            this.tabCoverFull.SuspendLayout();
            this.grpCoversSynchronize.SuspendLayout();
            this.tabSettingsTitle.SuspendLayout();
            this.grbTitleLanguage.SuspendLayout();
            this.grbTitleFileLocation.SuspendLayout();
            this.grbTitleDiverse.SuspendLayout();
            this.tabSettingsUpdates.SuspendLayout();
            this.grbUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabSettingsLanguage.SuspendLayout();
            this.grbLanguage.SuspendLayout();
            this.tabSettingsLog.SuspendLayout();
            this.grbLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabSettingsDolphin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabSettingsGeneral);
            this.tabSettings.Controls.Add(this.tabSettingsNomenclature);
            this.tabSettings.Controls.Add(this.tabSettingsSeveral);
            this.tabSettings.Controls.Add(this.tabSettingsTransfer);
            this.tabSettings.Controls.Add(this.tabSettingsCovers);
            this.tabSettings.Controls.Add(this.tabSettingsTitle);
            this.tabSettings.Controls.Add(this.tabSettingsDolphin);
            this.tabSettings.Controls.Add(this.tabSettingsUpdates);
            this.tabSettings.Controls.Add(this.tabSettingsLanguage);
            this.tabSettings.Controls.Add(this.tabSettingsLog);
            resources.ApplyResources(this.tabSettings, "tabSettings");
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            // 
            // tabSettingsGeneral
            // 
            this.tabSettingsGeneral.Controls.Add(this.grbGeneralTemporaryFolder);
            this.tabSettingsGeneral.Controls.Add(this.grbGeneralFiles);
            this.tabSettingsGeneral.Controls.Add(this.grbGeneralFileSize);
            this.tabSettingsGeneral.Controls.Add(this.grbGeneralPartitions);
            resources.ApplyResources(this.tabSettingsGeneral, "tabSettingsGeneral");
            this.tabSettingsGeneral.Name = "tabSettingsGeneral";
            this.tabSettingsGeneral.UseVisualStyleBackColor = true;
            // 
            // grbGeneralTemporaryFolder
            // 
            this.grbGeneralTemporaryFolder.Controls.Add(this.btnTemporaryFolder);
            this.grbGeneralTemporaryFolder.Controls.Add(this.tbGeneralTempPath);
            resources.ApplyResources(this.grbGeneralTemporaryFolder, "grbGeneralTemporaryFolder");
            this.grbGeneralTemporaryFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grbGeneralTemporaryFolder.Name = "grbGeneralTemporaryFolder";
            this.grbGeneralTemporaryFolder.TabStop = false;
            // 
            // btnTemporaryFolder
            // 
            resources.ApplyResources(this.btnTemporaryFolder, "btnTemporaryFolder");
            this.btnTemporaryFolder.Name = "btnTemporaryFolder";
            this.btnTemporaryFolder.UseVisualStyleBackColor = true;
            this.btnTemporaryFolder.Click += new System.EventHandler(this.btnTemporaryFolder_Click);
            // 
            // tbGeneralTempPath
            // 
            resources.ApplyResources(this.tbGeneralTempPath, "tbGeneralTempPath");
            this.tbGeneralTempPath.Name = "tbGeneralTempPath";
            this.tbGeneralTempPath.ReadOnly = true;
            // 
            // grbGeneralFiles
            // 
            this.grbGeneralFiles.Controls.Add(this.chkGeneralExtractNwb);
            this.grbGeneralFiles.Controls.Add(this.chkGeneralExtractSplitFile);
            this.grbGeneralFiles.Controls.Add(this.chkGeneralExtractBZip2);
            this.grbGeneralFiles.Controls.Add(this.chkGeneralExtractRar);
            this.grbGeneralFiles.Controls.Add(this.chkGeneralExtract7z);
            this.grbGeneralFiles.Controls.Add(this.chkGeneralExtractZip);
            this.grbGeneralFiles.Controls.Add(this.lblGeneralExtract);
            resources.ApplyResources(this.grbGeneralFiles, "grbGeneralFiles");
            this.grbGeneralFiles.Name = "grbGeneralFiles";
            this.grbGeneralFiles.TabStop = false;
            // 
            // chkGeneralExtractNwb
            // 
            resources.ApplyResources(this.chkGeneralExtractNwb, "chkGeneralExtractNwb");
            this.chkGeneralExtractNwb.Name = "chkGeneralExtractNwb";
            this.chkGeneralExtractNwb.UseVisualStyleBackColor = true;
            // 
            // chkGeneralExtractSplitFile
            // 
            resources.ApplyResources(this.chkGeneralExtractSplitFile, "chkGeneralExtractSplitFile");
            this.chkGeneralExtractSplitFile.Name = "chkGeneralExtractSplitFile";
            this.chkGeneralExtractSplitFile.UseVisualStyleBackColor = true;
            // 
            // chkGeneralExtractBZip2
            // 
            resources.ApplyResources(this.chkGeneralExtractBZip2, "chkGeneralExtractBZip2");
            this.chkGeneralExtractBZip2.Name = "chkGeneralExtractBZip2";
            this.chkGeneralExtractBZip2.UseVisualStyleBackColor = true;
            // 
            // chkGeneralExtractRar
            // 
            resources.ApplyResources(this.chkGeneralExtractRar, "chkGeneralExtractRar");
            this.chkGeneralExtractRar.Name = "chkGeneralExtractRar";
            this.chkGeneralExtractRar.UseVisualStyleBackColor = true;
            // 
            // chkGeneralExtract7z
            // 
            resources.ApplyResources(this.chkGeneralExtract7z, "chkGeneralExtract7z");
            this.chkGeneralExtract7z.Name = "chkGeneralExtract7z";
            this.chkGeneralExtract7z.UseVisualStyleBackColor = true;
            // 
            // chkGeneralExtractZip
            // 
            resources.ApplyResources(this.chkGeneralExtractZip, "chkGeneralExtractZip");
            this.chkGeneralExtractZip.Name = "chkGeneralExtractZip";
            this.chkGeneralExtractZip.UseVisualStyleBackColor = true;
            // 
            // lblGeneralExtract
            // 
            resources.ApplyResources(this.lblGeneralExtract, "lblGeneralExtract");
            this.lblGeneralExtract.Name = "lblGeneralExtract";
            // 
            // grbGeneralFileSize
            // 
            this.grbGeneralFileSize.Controls.Add(this.cbGeneralFileSize);
            resources.ApplyResources(this.grbGeneralFileSize, "grbGeneralFileSize");
            this.grbGeneralFileSize.Name = "grbGeneralFileSize";
            this.grbGeneralFileSize.TabStop = false;
            // 
            // cbGeneralFileSize
            // 
            this.cbGeneralFileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGeneralFileSize.FormattingEnabled = true;
            this.cbGeneralFileSize.Items.AddRange(new object[] {
            resources.GetString("cbGeneralFileSize.Items"),
            resources.GetString("cbGeneralFileSize.Items1"),
            resources.GetString("cbGeneralFileSize.Items2"),
            resources.GetString("cbGeneralFileSize.Items3"),
            resources.GetString("cbGeneralFileSize.Items4")});
            resources.ApplyResources(this.cbGeneralFileSize, "cbGeneralFileSize");
            this.cbGeneralFileSize.Name = "cbGeneralFileSize";
            // 
            // grbGeneralPartitions
            // 
            this.grbGeneralPartitions.Controls.Add(this.rbGeneralDiscDelete);
            this.grbGeneralPartitions.Controls.Add(this.rbGeneralDiscClean);
            resources.ApplyResources(this.grbGeneralPartitions, "grbGeneralPartitions");
            this.grbGeneralPartitions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grbGeneralPartitions.Name = "grbGeneralPartitions";
            this.grbGeneralPartitions.TabStop = false;
            // 
            // rbGeneralDiscDelete
            // 
            resources.ApplyResources(this.rbGeneralDiscDelete, "rbGeneralDiscDelete");
            this.rbGeneralDiscDelete.ForeColor = System.Drawing.Color.Red;
            this.rbGeneralDiscDelete.Name = "rbGeneralDiscDelete";
            this.rbGeneralDiscDelete.UseVisualStyleBackColor = true;
            // 
            // rbGeneralDiscClean
            // 
            resources.ApplyResources(this.rbGeneralDiscClean, "rbGeneralDiscClean");
            this.rbGeneralDiscClean.Checked = true;
            this.rbGeneralDiscClean.Name = "rbGeneralDiscClean";
            this.rbGeneralDiscClean.TabStop = true;
            this.rbGeneralDiscClean.UseVisualStyleBackColor = true;
            // 
            // tabSettingsNomenclature
            // 
            this.tabSettingsNomenclature.Controls.Add(this.lblCommentsScrubCopy);
            this.tabSettingsNomenclature.Controls.Add(this.lblCommentsExactCopy);
            this.tabSettingsNomenclature.Controls.Add(this.lblComments);
            this.tabSettingsNomenclature.Controls.Add(this.grpNomenclatureFolderFormat);
            resources.ApplyResources(this.tabSettingsNomenclature, "tabSettingsNomenclature");
            this.tabSettingsNomenclature.Name = "tabSettingsNomenclature";
            this.tabSettingsNomenclature.UseVisualStyleBackColor = true;
            // 
            // lblCommentsScrubCopy
            // 
            resources.ApplyResources(this.lblCommentsScrubCopy, "lblCommentsScrubCopy");
            this.lblCommentsScrubCopy.Name = "lblCommentsScrubCopy";
            // 
            // lblCommentsExactCopy
            // 
            resources.ApplyResources(this.lblCommentsExactCopy, "lblCommentsExactCopy");
            this.lblCommentsExactCopy.Name = "lblCommentsExactCopy";
            // 
            // lblComments
            // 
            resources.ApplyResources(this.lblComments, "lblComments");
            this.lblComments.Name = "lblComments";
            // 
            // grpNomenclatureFolderFormat
            // 
            this.grpNomenclatureFolderFormat.Controls.Add(this.cbAdjustNamingStyle);
            this.grpNomenclatureFolderFormat.Controls.Add(this.lblNomenclature);
            resources.ApplyResources(this.grpNomenclatureFolderFormat, "grpNomenclatureFolderFormat");
            this.grpNomenclatureFolderFormat.Name = "grpNomenclatureFolderFormat";
            this.grpNomenclatureFolderFormat.TabStop = false;
            // 
            // cbAdjustNamingStyle
            // 
            this.cbAdjustNamingStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdjustNamingStyle.FormattingEnabled = true;
            this.cbAdjustNamingStyle.Items.AddRange(new object[] {
            resources.GetString("cbAdjustNamingStyle.Items"),
            resources.GetString("cbAdjustNamingStyle.Items1")});
            resources.ApplyResources(this.cbAdjustNamingStyle, "cbAdjustNamingStyle");
            this.cbAdjustNamingStyle.Name = "cbAdjustNamingStyle";
            // 
            // lblNomenclature
            // 
            resources.ApplyResources(this.lblNomenclature, "lblNomenclature");
            this.lblNomenclature.Name = "lblNomenclature";
            // 
            // tabSettingsSeveral
            // 
            this.tabSettingsSeveral.Controls.Add(this.grbGeneralDiverse);
            resources.ApplyResources(this.tabSettingsSeveral, "tabSettingsSeveral");
            this.tabSettingsSeveral.Name = "tabSettingsSeveral";
            this.tabSettingsSeveral.UseVisualStyleBackColor = true;
            // 
            // grbGeneralDiverse
            // 
            this.grbGeneralDiverse.Controls.Add(this.chkMultipleInstances);
            this.grbGeneralDiverse.Controls.Add(this.chkLoadDatabase);
            this.grbGeneralDiverse.Controls.Add(this.chkNotify);
            this.grbGeneralDiverse.Controls.Add(this.chkScreensaver);
            this.grbGeneralDiverse.Controls.Add(this.chkWelcome);
            this.grbGeneralDiverse.Controls.Add(this.chkNetVerify);
            this.grbGeneralDiverse.Controls.Add(this.chkStartWindowMaximized);
            this.grbGeneralDiverse.Controls.Add(this.chkGeneralSHA1);
            this.grbGeneralDiverse.Controls.Add(this.chkGeneralRecursiva);
            this.grbGeneralDiverse.Controls.Add(this.chkGeneralTemporaryBuffer);
            this.grbGeneralDiverse.Controls.Add(this.chkGeneralMD5);
            resources.ApplyResources(this.grbGeneralDiverse, "grbGeneralDiverse");
            this.grbGeneralDiverse.Name = "grbGeneralDiverse";
            this.grbGeneralDiverse.TabStop = false;
            // 
            // chkMultipleInstances
            // 
            resources.ApplyResources(this.chkMultipleInstances, "chkMultipleInstances");
            this.chkMultipleInstances.Name = "chkMultipleInstances";
            this.chkMultipleInstances.UseVisualStyleBackColor = true;
            // 
            // chkLoadDatabase
            // 
            resources.ApplyResources(this.chkLoadDatabase, "chkLoadDatabase");
            this.chkLoadDatabase.Checked = true;
            this.chkLoadDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLoadDatabase.Name = "chkLoadDatabase";
            this.chkLoadDatabase.UseVisualStyleBackColor = true;
            // 
            // chkNotify
            // 
            resources.ApplyResources(this.chkNotify, "chkNotify");
            this.chkNotify.Checked = true;
            this.chkNotify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotify.Name = "chkNotify";
            this.chkNotify.UseVisualStyleBackColor = true;
            this.chkNotify.Click += new System.EventHandler(this.chkNotify_Click);
            // 
            // chkScreensaver
            // 
            resources.ApplyResources(this.chkScreensaver, "chkScreensaver");
            this.chkScreensaver.Name = "chkScreensaver";
            this.chkScreensaver.UseVisualStyleBackColor = true;
            // 
            // chkWelcome
            // 
            resources.ApplyResources(this.chkWelcome, "chkWelcome");
            this.chkWelcome.Name = "chkWelcome";
            this.chkWelcome.UseVisualStyleBackColor = true;
            // 
            // chkNetVerify
            // 
            resources.ApplyResources(this.chkNetVerify, "chkNetVerify");
            this.chkNetVerify.Name = "chkNetVerify";
            this.chkNetVerify.UseVisualStyleBackColor = true;
            // 
            // chkStartWindowMaximized
            // 
            resources.ApplyResources(this.chkStartWindowMaximized, "chkStartWindowMaximized");
            this.chkStartWindowMaximized.Name = "chkStartWindowMaximized";
            this.chkStartWindowMaximized.UseVisualStyleBackColor = true;
            // 
            // chkGeneralSHA1
            // 
            resources.ApplyResources(this.chkGeneralSHA1, "chkGeneralSHA1");
            this.chkGeneralSHA1.Name = "chkGeneralSHA1";
            this.chkGeneralSHA1.UseVisualStyleBackColor = true;
            // 
            // chkGeneralRecursiva
            // 
            resources.ApplyResources(this.chkGeneralRecursiva, "chkGeneralRecursiva");
            this.chkGeneralRecursiva.Checked = true;
            this.chkGeneralRecursiva.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGeneralRecursiva.Name = "chkGeneralRecursiva";
            this.chkGeneralRecursiva.UseVisualStyleBackColor = true;
            // 
            // chkGeneralTemporaryBuffer
            // 
            resources.ApplyResources(this.chkGeneralTemporaryBuffer, "chkGeneralTemporaryBuffer");
            this.chkGeneralTemporaryBuffer.Name = "chkGeneralTemporaryBuffer";
            this.chkGeneralTemporaryBuffer.UseVisualStyleBackColor = true;
            // 
            // chkGeneralMD5
            // 
            resources.ApplyResources(this.chkGeneralMD5, "chkGeneralMD5");
            this.chkGeneralMD5.Name = "chkGeneralMD5";
            this.chkGeneralMD5.UseVisualStyleBackColor = true;
            // 
            // tabSettingsTransfer
            // 
            this.tabSettingsTransfer.Controls.Add(this.grbGeneralScrub);
            this.tabSettingsTransfer.Controls.Add(this.label28);
            this.tabSettingsTransfer.Controls.Add(this.label31);
            this.tabSettingsTransfer.Controls.Add(this.label20);
            this.tabSettingsTransfer.Controls.Add(this.lblScrub);
            this.tabSettingsTransfer.Controls.Add(this.lblWipe);
            this.tabSettingsTransfer.Controls.Add(this.lblFST);
            this.tabSettingsTransfer.Controls.Add(this.lblXCopy);
            this.tabSettingsTransfer.Controls.Add(this.label17);
            this.tabSettingsTransfer.Controls.Add(this.grbTransferSystem);
            resources.ApplyResources(this.tabSettingsTransfer, "tabSettingsTransfer");
            this.tabSettingsTransfer.Name = "tabSettingsTransfer";
            this.tabSettingsTransfer.UseVisualStyleBackColor = true;
            // 
            // grbGeneralScrub
            // 
            this.grbGeneralScrub.Controls.Add(this.lblFormat);
            this.grbGeneralScrub.Controls.Add(this.lblAlignment);
            this.grbGeneralScrub.Controls.Add(this.cbScrubFormat);
            this.grbGeneralScrub.Controls.Add(this.cbScrubAlign);
            this.grbGeneralScrub.Controls.Add(this.chkGeneralScrubFlushSD);
            resources.ApplyResources(this.grbGeneralScrub, "grbGeneralScrub");
            this.grbGeneralScrub.Name = "grbGeneralScrub";
            this.grbGeneralScrub.TabStop = false;
            // 
            // lblFormat
            // 
            resources.ApplyResources(this.lblFormat, "lblFormat");
            this.lblFormat.Name = "lblFormat";
            // 
            // lblAlignment
            // 
            resources.ApplyResources(this.lblAlignment, "lblAlignment");
            this.lblAlignment.Name = "lblAlignment";
            // 
            // cbScrubFormat
            // 
            this.cbScrubFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScrubFormat.FormattingEnabled = true;
            this.cbScrubFormat.Items.AddRange(new object[] {
            resources.GetString("cbScrubFormat.Items"),
            resources.GetString("cbScrubFormat.Items1")});
            resources.ApplyResources(this.cbScrubFormat, "cbScrubFormat");
            this.cbScrubFormat.Name = "cbScrubFormat";
            // 
            // cbScrubAlign
            // 
            this.cbScrubAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScrubAlign.FormattingEnabled = true;
            this.cbScrubAlign.Items.AddRange(new object[] {
            resources.GetString("cbScrubAlign.Items"),
            resources.GetString("cbScrubAlign.Items1"),
            resources.GetString("cbScrubAlign.Items2"),
            resources.GetString("cbScrubAlign.Items3")});
            resources.ApplyResources(this.cbScrubAlign, "cbScrubAlign");
            this.cbScrubAlign.Name = "cbScrubAlign";
            // 
            // chkGeneralScrubFlushSD
            // 
            resources.ApplyResources(this.chkGeneralScrubFlushSD, "chkGeneralScrubFlushSD");
            this.chkGeneralScrubFlushSD.Name = "chkGeneralScrubFlushSD";
            this.chkGeneralScrubFlushSD.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // lblScrub
            // 
            resources.ApplyResources(this.lblScrub, "lblScrub");
            this.lblScrub.Name = "lblScrub";
            // 
            // lblWipe
            // 
            resources.ApplyResources(this.lblWipe, "lblWipe");
            this.lblWipe.Name = "lblWipe";
            // 
            // lblFST
            // 
            resources.ApplyResources(this.lblFST, "lblFST");
            this.lblFST.Name = "lblFST";
            // 
            // lblXCopy
            // 
            resources.ApplyResources(this.lblXCopy, "lblXCopy");
            this.lblXCopy.Name = "lblXCopy";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // grbTransferSystem
            // 
            this.grbTransferSystem.Controls.Add(this.rbTransferSystemFST);
            this.grbTransferSystem.Controls.Add(this.rbTransferSystemWipe);
            this.grbTransferSystem.Controls.Add(this.rbTransferSystemXCopy);
            resources.ApplyResources(this.grbTransferSystem, "grbTransferSystem");
            this.grbTransferSystem.Name = "grbTransferSystem";
            this.grbTransferSystem.TabStop = false;
            // 
            // rbTransferSystemFST
            // 
            resources.ApplyResources(this.rbTransferSystemFST, "rbTransferSystemFST");
            this.rbTransferSystemFST.Name = "rbTransferSystemFST";
            this.rbTransferSystemFST.UseVisualStyleBackColor = true;
            // 
            // rbTransferSystemWipe
            // 
            resources.ApplyResources(this.rbTransferSystemWipe, "rbTransferSystemWipe");
            this.rbTransferSystemWipe.Name = "rbTransferSystemWipe";
            this.rbTransferSystemWipe.UseVisualStyleBackColor = true;
            // 
            // rbTransferSystemXCopy
            // 
            resources.ApplyResources(this.rbTransferSystemXCopy, "rbTransferSystemXCopy");
            this.rbTransferSystemXCopy.Checked = true;
            this.rbTransferSystemXCopy.Name = "rbTransferSystemXCopy";
            this.rbTransferSystemXCopy.TabStop = true;
            this.rbTransferSystemXCopy.UseVisualStyleBackColor = true;
            // 
            // tabSettingsCovers
            // 
            resources.ApplyResources(this.tabSettingsCovers, "tabSettingsCovers");
            this.tabSettingsCovers.Controls.Add(this.grpTitlesCoverFolder);
            this.tabSettingsCovers.Controls.Add(this.grbCoverTransfer);
            this.tabSettingsCovers.Controls.Add(this.grpCoversSynchronize);
            this.tabSettingsCovers.Name = "tabSettingsCovers";
            this.tabSettingsCovers.UseVisualStyleBackColor = true;
            // 
            // grpTitlesCoverFolder
            // 
            this.grpTitlesCoverFolder.Controls.Add(this.btnCoverDirectory);
            this.grpTitlesCoverFolder.Controls.Add(this.tbDirectoryCoverCache);
            resources.ApplyResources(this.grpTitlesCoverFolder, "grpTitlesCoverFolder");
            this.grpTitlesCoverFolder.Name = "grpTitlesCoverFolder";
            this.grpTitlesCoverFolder.TabStop = false;
            // 
            // btnCoverDirectory
            // 
            resources.ApplyResources(this.btnCoverDirectory, "btnCoverDirectory");
            this.btnCoverDirectory.Name = "btnCoverDirectory";
            this.btnCoverDirectory.UseVisualStyleBackColor = true;
            this.btnCoverDirectory.Click += new System.EventHandler(this.btnCoverDirectory_Click);
            // 
            // tbDirectoryCoverCache
            // 
            resources.ApplyResources(this.tbDirectoryCoverCache, "tbDirectoryCoverCache");
            this.tbDirectoryCoverCache.Name = "tbDirectoryCoverCache";
            this.tbDirectoryCoverCache.ReadOnly = true;
            // 
            // grbCoverTransfer
            // 
            this.grbCoverTransfer.Controls.Add(this.rbCoverUSBLoaderGX);
            this.grbCoverTransfer.Controls.Add(this.tabControl2);
            this.grbCoverTransfer.Controls.Add(this.rbCoverWiiFlow);
            resources.ApplyResources(this.grbCoverTransfer, "grbCoverTransfer");
            this.grbCoverTransfer.Name = "grbCoverTransfer";
            this.grbCoverTransfer.TabStop = false;
            // 
            // rbCoverUSBLoaderGX
            // 
            resources.ApplyResources(this.rbCoverUSBLoaderGX, "rbCoverUSBLoaderGX");
            this.rbCoverUSBLoaderGX.Checked = true;
            this.rbCoverUSBLoaderGX.Name = "rbCoverUSBLoaderGX";
            this.rbCoverUSBLoaderGX.TabStop = true;
            this.rbCoverUSBLoaderGX.UseVisualStyleBackColor = true;
            this.rbCoverUSBLoaderGX.CheckedChanged += new System.EventHandler(this.rbCoverUSBLoaderGX_CheckedChanged);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabCoverDisc);
            this.tabControl2.Controls.Add(this.tabCoverFront);
            this.tabControl2.Controls.Add(this.tabCover3D);
            this.tabControl2.Controls.Add(this.tabCoverFull);
            resources.ApplyResources(this.tabControl2, "tabControl2");
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            // 
            // tabCoverDisc
            // 
            this.tabCoverDisc.Controls.Add(this.btnDirectoryCoverDisc);
            this.tabCoverDisc.Controls.Add(this.tbDirectoryCoverDisc);
            this.tabCoverDisc.Controls.Add(this.label8);
            resources.ApplyResources(this.tabCoverDisc, "tabCoverDisc");
            this.tabCoverDisc.Name = "tabCoverDisc";
            this.tabCoverDisc.UseVisualStyleBackColor = true;
            // 
            // btnDirectoryCoverDisc
            // 
            resources.ApplyResources(this.btnDirectoryCoverDisc, "btnDirectoryCoverDisc");
            this.btnDirectoryCoverDisc.Name = "btnDirectoryCoverDisc";
            this.btnDirectoryCoverDisc.UseVisualStyleBackColor = true;
            this.btnDirectoryCoverDisc.Click += new System.EventHandler(this.btnDirectoryCoverDisc_Click);
            // 
            // tbDirectoryCoverDisc
            // 
            resources.ApplyResources(this.tbDirectoryCoverDisc, "tbDirectoryCoverDisc");
            this.tbDirectoryCoverDisc.Name = "tbDirectoryCoverDisc";
            this.tbDirectoryCoverDisc.ReadOnly = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // tabCoverFront
            // 
            this.tabCoverFront.Controls.Add(this.btnDirectoryCover2D);
            this.tabCoverFront.Controls.Add(this.tbDirectoryCover2D);
            this.tabCoverFront.Controls.Add(this.label6);
            resources.ApplyResources(this.tabCoverFront, "tabCoverFront");
            this.tabCoverFront.Name = "tabCoverFront";
            this.tabCoverFront.UseVisualStyleBackColor = true;
            // 
            // btnDirectoryCover2D
            // 
            resources.ApplyResources(this.btnDirectoryCover2D, "btnDirectoryCover2D");
            this.btnDirectoryCover2D.Name = "btnDirectoryCover2D";
            this.btnDirectoryCover2D.UseVisualStyleBackColor = true;
            this.btnDirectoryCover2D.Click += new System.EventHandler(this.btnDirectoryCover2D_Click);
            // 
            // tbDirectoryCover2D
            // 
            resources.ApplyResources(this.tbDirectoryCover2D, "tbDirectoryCover2D");
            this.tbDirectoryCover2D.Name = "tbDirectoryCover2D";
            this.tbDirectoryCover2D.ReadOnly = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tabCover3D
            // 
            this.tabCover3D.Controls.Add(this.btnDirectoryCover3D);
            this.tabCover3D.Controls.Add(this.tbDirectoryCover3D);
            this.tabCover3D.Controls.Add(this.label9);
            resources.ApplyResources(this.tabCover3D, "tabCover3D");
            this.tabCover3D.Name = "tabCover3D";
            this.tabCover3D.UseVisualStyleBackColor = true;
            // 
            // btnDirectoryCover3D
            // 
            resources.ApplyResources(this.btnDirectoryCover3D, "btnDirectoryCover3D");
            this.btnDirectoryCover3D.Name = "btnDirectoryCover3D";
            this.btnDirectoryCover3D.UseVisualStyleBackColor = true;
            this.btnDirectoryCover3D.Click += new System.EventHandler(this.btnDirectoryCover3D_Click);
            // 
            // tbDirectoryCover3D
            // 
            resources.ApplyResources(this.tbDirectoryCover3D, "tbDirectoryCover3D");
            this.tbDirectoryCover3D.Name = "tbDirectoryCover3D";
            this.tbDirectoryCover3D.ReadOnly = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // tabCoverFull
            // 
            this.tabCoverFull.Controls.Add(this.btnDirectoryCoverFull);
            this.tabCoverFull.Controls.Add(this.tbDirectoryCoverFull);
            this.tabCoverFull.Controls.Add(this.label35);
            resources.ApplyResources(this.tabCoverFull, "tabCoverFull");
            this.tabCoverFull.Name = "tabCoverFull";
            this.tabCoverFull.UseVisualStyleBackColor = true;
            // 
            // btnDirectoryCoverFull
            // 
            resources.ApplyResources(this.btnDirectoryCoverFull, "btnDirectoryCoverFull");
            this.btnDirectoryCoverFull.Name = "btnDirectoryCoverFull";
            this.btnDirectoryCoverFull.UseVisualStyleBackColor = true;
            this.btnDirectoryCoverFull.Click += new System.EventHandler(this.btnDirectoryCoverFull_Click);
            // 
            // tbDirectoryCoverFull
            // 
            resources.ApplyResources(this.tbDirectoryCoverFull, "tbDirectoryCoverFull");
            this.tbDirectoryCoverFull.Name = "tbDirectoryCoverFull";
            this.tbDirectoryCoverFull.ReadOnly = true;
            // 
            // label35
            // 
            resources.ApplyResources(this.label35, "label35");
            this.label35.Name = "label35";
            // 
            // rbCoverWiiFlow
            // 
            resources.ApplyResources(this.rbCoverWiiFlow, "rbCoverWiiFlow");
            this.rbCoverWiiFlow.Name = "rbCoverWiiFlow";
            this.rbCoverWiiFlow.UseVisualStyleBackColor = true;
            this.rbCoverWiiFlow.CheckedChanged += new System.EventHandler(this.rbCoverWiiFlow_CheckedChanged);
            // 
            // grpCoversSynchronize
            // 
            this.grpCoversSynchronize.Controls.Add(this.chkCoverRecursiveSearch);
            this.grpCoversSynchronize.Controls.Add(this.chkCoverEnableTransfer);
            this.grpCoversSynchronize.Controls.Add(this.chkCoverSynchronizeDelete);
            resources.ApplyResources(this.grpCoversSynchronize, "grpCoversSynchronize");
            this.grpCoversSynchronize.Name = "grpCoversSynchronize";
            this.grpCoversSynchronize.TabStop = false;
            // 
            // chkCoverRecursiveSearch
            // 
            resources.ApplyResources(this.chkCoverRecursiveSearch, "chkCoverRecursiveSearch");
            this.chkCoverRecursiveSearch.Name = "chkCoverRecursiveSearch";
            this.chkCoverRecursiveSearch.UseVisualStyleBackColor = true;
            // 
            // chkCoverEnableTransfer
            // 
            resources.ApplyResources(this.chkCoverEnableTransfer, "chkCoverEnableTransfer");
            this.chkCoverEnableTransfer.Name = "chkCoverEnableTransfer";
            this.chkCoverEnableTransfer.UseVisualStyleBackColor = true;
            this.chkCoverEnableTransfer.CheckedChanged += new System.EventHandler(this.chkCoverEnableTransfer_CheckedChanged);
            // 
            // chkCoverSynchronizeDelete
            // 
            resources.ApplyResources(this.chkCoverSynchronizeDelete, "chkCoverSynchronizeDelete");
            this.chkCoverSynchronizeDelete.Name = "chkCoverSynchronizeDelete";
            this.chkCoverSynchronizeDelete.UseVisualStyleBackColor = true;
            // 
            // tabSettingsTitle
            // 
            this.tabSettingsTitle.Controls.Add(this.grbTitleLanguage);
            this.tabSettingsTitle.Controls.Add(this.grbTitleFileLocation);
            this.tabSettingsTitle.Controls.Add(this.grbTitleDiverse);
            resources.ApplyResources(this.tabSettingsTitle, "tabSettingsTitle");
            this.tabSettingsTitle.Name = "tabSettingsTitle";
            this.tabSettingsTitle.UseVisualStyleBackColor = true;
            // 
            // grbTitleLanguage
            // 
            this.grbTitleLanguage.Controls.Add(this.btnTitleDownload);
            this.grbTitleLanguage.Controls.Add(this.cbTitleLanguage);
            resources.ApplyResources(this.grbTitleLanguage, "grbTitleLanguage");
            this.grbTitleLanguage.Name = "grbTitleLanguage";
            this.grbTitleLanguage.TabStop = false;
            // 
            // btnTitleDownload
            // 
            resources.ApplyResources(this.btnTitleDownload, "btnTitleDownload");
            this.btnTitleDownload.Name = "btnTitleDownload";
            this.btnTitleDownload.UseVisualStyleBackColor = true;
            // 
            // cbTitleLanguage
            // 
            this.cbTitleLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTitleLanguage.FormattingEnabled = true;
            this.cbTitleLanguage.Items.AddRange(new object[] {
            resources.GetString("cbTitleLanguage.Items"),
            resources.GetString("cbTitleLanguage.Items1"),
            resources.GetString("cbTitleLanguage.Items2"),
            resources.GetString("cbTitleLanguage.Items3"),
            resources.GetString("cbTitleLanguage.Items4"),
            resources.GetString("cbTitleLanguage.Items5"),
            resources.GetString("cbTitleLanguage.Items6"),
            resources.GetString("cbTitleLanguage.Items7"),
            resources.GetString("cbTitleLanguage.Items8"),
            resources.GetString("cbTitleLanguage.Items9"),
            resources.GetString("cbTitleLanguage.Items10"),
            resources.GetString("cbTitleLanguage.Items11")});
            resources.ApplyResources(this.cbTitleLanguage, "cbTitleLanguage");
            this.cbTitleLanguage.Name = "cbTitleLanguage";
            // 
            // grbTitleFileLocation
            // 
            this.grbTitleFileLocation.Controls.Add(this.label5);
            this.grbTitleFileLocation.Controls.Add(this.label4);
            this.grbTitleFileLocation.Controls.Add(this.btnTitleCustom);
            this.grbTitleFileLocation.Controls.Add(this.btnTitle);
            this.grbTitleFileLocation.Controls.Add(this.tbTitleCustom);
            this.grbTitleFileLocation.Controls.Add(this.tbTitle);
            resources.ApplyResources(this.grbTitleFileLocation, "grbTitleFileLocation");
            this.grbTitleFileLocation.Name = "grbTitleFileLocation";
            this.grbTitleFileLocation.TabStop = false;
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
            // btnTitleCustom
            // 
            resources.ApplyResources(this.btnTitleCustom, "btnTitleCustom");
            this.btnTitleCustom.Name = "btnTitleCustom";
            this.btnTitleCustom.UseVisualStyleBackColor = true;
            // 
            // btnTitle
            // 
            resources.ApplyResources(this.btnTitle, "btnTitle");
            this.btnTitle.Name = "btnTitle";
            this.btnTitle.UseVisualStyleBackColor = true;
            // 
            // tbTitleCustom
            // 
            resources.ApplyResources(this.tbTitleCustom, "tbTitleCustom");
            this.tbTitleCustom.Name = "tbTitleCustom";
            // 
            // tbTitle
            // 
            resources.ApplyResources(this.tbTitle, "tbTitle");
            this.tbTitle.Name = "tbTitle";
            // 
            // grbTitleDiverse
            // 
            this.grbTitleDiverse.Controls.Add(this.rbGameXmlName);
            this.grbTitleDiverse.Controls.Add(this.rbGameInternalName);
            this.grbTitleDiverse.Controls.Add(this.chkGameTitleCustom);
            this.grbTitleDiverse.Controls.Add(this.chkGameTitle);
            resources.ApplyResources(this.grbTitleDiverse, "grbTitleDiverse");
            this.grbTitleDiverse.Name = "grbTitleDiverse";
            this.grbTitleDiverse.TabStop = false;
            // 
            // rbGameXmlName
            // 
            resources.ApplyResources(this.rbGameXmlName, "rbGameXmlName");
            this.rbGameXmlName.Name = "rbGameXmlName";
            this.rbGameXmlName.UseVisualStyleBackColor = true;
            // 
            // rbGameInternalName
            // 
            resources.ApplyResources(this.rbGameInternalName, "rbGameInternalName");
            this.rbGameInternalName.Checked = true;
            this.rbGameInternalName.Name = "rbGameInternalName";
            this.rbGameInternalName.TabStop = true;
            this.rbGameInternalName.UseVisualStyleBackColor = true;
            // 
            // chkGameTitleCustom
            // 
            resources.ApplyResources(this.chkGameTitleCustom, "chkGameTitleCustom");
            this.chkGameTitleCustom.Name = "chkGameTitleCustom";
            this.chkGameTitleCustom.UseVisualStyleBackColor = true;
            // 
            // chkGameTitle
            // 
            resources.ApplyResources(this.chkGameTitle, "chkGameTitle");
            this.chkGameTitle.Name = "chkGameTitle";
            this.chkGameTitle.UseVisualStyleBackColor = true;
            this.chkGameTitle.CheckedChanged += new System.EventHandler(this.chkGameTitle_CheckedChanged);
            // 
            // tabSettingsUpdates
            // 
            this.tabSettingsUpdates.Controls.Add(this.lblTimeInterval);
            this.tabSettingsUpdates.Controls.Add(this.grbUpdate);
            resources.ApplyResources(this.tabSettingsUpdates, "tabSettingsUpdates");
            this.tabSettingsUpdates.Name = "tabSettingsUpdates";
            this.tabSettingsUpdates.UseVisualStyleBackColor = true;
            // 
            // lblTimeInterval
            // 
            resources.ApplyResources(this.lblTimeInterval, "lblTimeInterval");
            this.lblTimeInterval.Name = "lblTimeInterval";
            // 
            // grbUpdate
            // 
            this.grbUpdate.Controls.Add(this.cbVerificationInterval);
            this.grbUpdate.Controls.Add(this.lblUpdateInterval);
            this.grbUpdate.Controls.Add(this.tbPassProxy);
            this.grbUpdate.Controls.Add(this.tbUserProxy);
            this.grbUpdate.Controls.Add(this.tbServerProxy);
            this.grbUpdate.Controls.Add(this.lblPass);
            this.grbUpdate.Controls.Add(this.lblUser);
            this.grbUpdate.Controls.Add(this.lblServerProxy);
            this.grbUpdate.Controls.Add(this.pictureBox1);
            this.grbUpdate.Controls.Add(this.chkUpdateServerProxy);
            this.grbUpdate.Controls.Add(this.chkUpdateFileLog);
            this.grbUpdate.Controls.Add(this.chkUpdateBetaChannel);
            this.grbUpdate.Controls.Add(this.chkUpdateVerifyStart);
            resources.ApplyResources(this.grbUpdate, "grbUpdate");
            this.grbUpdate.Name = "grbUpdate";
            this.grbUpdate.TabStop = false;
            // 
            // cbVerificationInterval
            // 
            this.cbVerificationInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbVerificationInterval, "cbVerificationInterval");
            this.cbVerificationInterval.FormattingEnabled = true;
            this.cbVerificationInterval.Items.AddRange(new object[] {
            resources.GetString("cbVerificationInterval.Items"),
            resources.GetString("cbVerificationInterval.Items1"),
            resources.GetString("cbVerificationInterval.Items2"),
            resources.GetString("cbVerificationInterval.Items3"),
            resources.GetString("cbVerificationInterval.Items4"),
            resources.GetString("cbVerificationInterval.Items5"),
            resources.GetString("cbVerificationInterval.Items6"),
            resources.GetString("cbVerificationInterval.Items7")});
            this.cbVerificationInterval.Name = "cbVerificationInterval";
            // 
            // lblUpdateInterval
            // 
            resources.ApplyResources(this.lblUpdateInterval, "lblUpdateInterval");
            this.lblUpdateInterval.Name = "lblUpdateInterval";
            // 
            // tbPassProxy
            // 
            resources.ApplyResources(this.tbPassProxy, "tbPassProxy");
            this.tbPassProxy.Name = "tbPassProxy";
            // 
            // tbUserProxy
            // 
            resources.ApplyResources(this.tbUserProxy, "tbUserProxy");
            this.tbUserProxy.Name = "tbUserProxy";
            // 
            // tbServerProxy
            // 
            resources.ApplyResources(this.tbServerProxy, "tbServerProxy");
            this.tbServerProxy.Name = "tbServerProxy";
            // 
            // lblPass
            // 
            resources.ApplyResources(this.lblPass, "lblPass");
            this.lblPass.Name = "lblPass";
            // 
            // lblUser
            // 
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.Name = "lblUser";
            // 
            // lblServerProxy
            // 
            resources.ApplyResources(this.lblServerProxy, "lblServerProxy");
            this.lblServerProxy.Name = "lblServerProxy";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GCBM.Properties.Resources.update_64;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // chkUpdateServerProxy
            // 
            resources.ApplyResources(this.chkUpdateServerProxy, "chkUpdateServerProxy");
            this.chkUpdateServerProxy.Name = "chkUpdateServerProxy";
            this.chkUpdateServerProxy.UseVisualStyleBackColor = true;
            this.chkUpdateServerProxy.CheckedChanged += new System.EventHandler(this.cbUpdateServerProxy_CheckedChanged);
            // 
            // chkUpdateFileLog
            // 
            resources.ApplyResources(this.chkUpdateFileLog, "chkUpdateFileLog");
            this.chkUpdateFileLog.Name = "chkUpdateFileLog";
            this.chkUpdateFileLog.UseVisualStyleBackColor = true;
            // 
            // chkUpdateBetaChannel
            // 
            resources.ApplyResources(this.chkUpdateBetaChannel, "chkUpdateBetaChannel");
            this.chkUpdateBetaChannel.Name = "chkUpdateBetaChannel";
            this.chkUpdateBetaChannel.UseVisualStyleBackColor = true;
            // 
            // chkUpdateVerifyStart
            // 
            resources.ApplyResources(this.chkUpdateVerifyStart, "chkUpdateVerifyStart");
            this.chkUpdateVerifyStart.Name = "chkUpdateVerifyStart";
            this.chkUpdateVerifyStart.UseVisualStyleBackColor = true;
            this.chkUpdateVerifyStart.CheckedChanged += new System.EventHandler(this.chkUpdateVerifyStart_CheckedChanged);
            // 
            // tabSettingsLanguage
            // 
            this.tabSettingsLanguage.Controls.Add(this.lblLanguageComments);
            this.tabSettingsLanguage.Controls.Add(this.grbLanguage);
            resources.ApplyResources(this.tabSettingsLanguage, "tabSettingsLanguage");
            this.tabSettingsLanguage.Name = "tabSettingsLanguage";
            this.tabSettingsLanguage.UseVisualStyleBackColor = true;
            // 
            // lblLanguageComments
            // 
            resources.ApplyResources(this.lblLanguageComments, "lblLanguageComments");
            this.lblLanguageComments.Name = "lblLanguageComments";
            // 
            // grbLanguage
            // 
            this.grbLanguage.Controls.Add(this.lblLanguage);
            this.grbLanguage.Controls.Add(this.cbLanguage);
            resources.ApplyResources(this.grbLanguage, "grbLanguage");
            this.grbLanguage.Name = "grbLanguage";
            this.grbLanguage.TabStop = false;
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] {
            resources.GetString("cbLanguage.Items"),
            resources.GetString("cbLanguage.Items1"),
            resources.GetString("cbLanguage.Items2"),
            resources.GetString("cbLanguage.Items3")});
            resources.ApplyResources(this.cbLanguage, "cbLanguage");
            this.cbLanguage.Name = "cbLanguage";
            // 
            // tabSettingsLog
            // 
            this.tabSettingsLog.Controls.Add(this.grbLog);
            resources.ApplyResources(this.tabSettingsLog, "tabSettingsLog");
            this.tabSettingsLog.Name = "tabSettingsLog";
            this.tabSettingsLog.UseVisualStyleBackColor = true;
            // 
            // grbLog
            // 
            this.grbLog.Controls.Add(this.pictureBox2);
            this.grbLog.Controls.Add(this.lblLOG);
            this.grbLog.Controls.Add(this.chkManagerLogFile);
            this.grbLog.Controls.Add(this.chkManagerLogWindow);
            this.grbLog.Controls.Add(this.chkManagerLogDebugConsole);
            this.grbLog.Controls.Add(this.chkManagerLogSystemConsole);
            this.grbLog.Controls.Add(this.cbLevelLog);
            resources.ApplyResources(this.grbLog, "grbLog");
            this.grbLog.Name = "grbLog";
            this.grbLog.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GCBM.Properties.Resources.log_64;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // lblLOG
            // 
            resources.ApplyResources(this.lblLOG, "lblLOG");
            this.lblLOG.Name = "lblLOG";
            // 
            // chkManagerLogFile
            // 
            resources.ApplyResources(this.chkManagerLogFile, "chkManagerLogFile");
            this.chkManagerLogFile.Checked = true;
            this.chkManagerLogFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManagerLogFile.Name = "chkManagerLogFile";
            this.chkManagerLogFile.UseVisualStyleBackColor = true;
            // 
            // chkManagerLogWindow
            // 
            resources.ApplyResources(this.chkManagerLogWindow, "chkManagerLogWindow");
            this.chkManagerLogWindow.Name = "chkManagerLogWindow";
            this.chkManagerLogWindow.UseVisualStyleBackColor = true;
            // 
            // chkManagerLogDebugConsole
            // 
            resources.ApplyResources(this.chkManagerLogDebugConsole, "chkManagerLogDebugConsole");
            this.chkManagerLogDebugConsole.Name = "chkManagerLogDebugConsole";
            this.chkManagerLogDebugConsole.UseVisualStyleBackColor = true;
            // 
            // chkManagerLogSystemConsole
            // 
            resources.ApplyResources(this.chkManagerLogSystemConsole, "chkManagerLogSystemConsole");
            this.chkManagerLogSystemConsole.Name = "chkManagerLogSystemConsole";
            this.chkManagerLogSystemConsole.UseVisualStyleBackColor = true;
            // 
            // cbLevelLog
            // 
            this.cbLevelLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLevelLog.FormattingEnabled = true;
            this.cbLevelLog.Items.AddRange(new object[] {
            resources.GetString("cbLevelLog.Items"),
            resources.GetString("cbLevelLog.Items1"),
            resources.GetString("cbLevelLog.Items2")});
            resources.ApplyResources(this.cbLevelLog, "cbLevelLog");
            this.cbLevelLog.Name = "cbLevelLog";
            // 
            // btnRestore
            // 
            resources.ApplyResources(this.btnRestore, "btnRestore");
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fbd
            // 
            resources.ApplyResources(this.fbd, "fbd");
            this.fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            // 
            // tabSettingsDolphin
            // 
            this.tabSettingsDolphin.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabSettingsDolphin, "tabSettingsDolphin");
            this.tabSettingsDolphin.Name = "tabSettingsDolphin";
            this.tabSettingsDolphin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSelectFile);
            this.groupBox5.Controls.Add(this.tbPathDolphinEmulator);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // btnSelectFile
            // 
            resources.ApplyResources(this.btnSelectFile, "btnSelectFile");
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // tbPathDolphinEmulator
            // 
            this.tbPathDolphinEmulator.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbPathDolphinEmulator, "tbPathDolphinEmulator");
            this.tbPathDolphinEmulator.Name = "tbPathDolphinEmulator";
            this.tbPathDolphinEmulator.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbHLE);
            this.groupBox3.Controls.Add(this.rbLLE);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // rbHLE
            // 
            resources.ApplyResources(this.rbHLE, "rbHLE");
            this.rbHLE.Name = "rbHLE";
            this.rbHLE.UseVisualStyleBackColor = true;
            // 
            // rbLLE
            // 
            resources.ApplyResources(this.rbLLE, "rbLLE");
            this.rbLLE.Checked = true;
            this.rbLLE.Name = "rbLLE";
            this.rbLLE.TabStop = true;
            this.rbLLE.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbOpenGL);
            this.groupBox2.Controls.Add(this.rbD3D12);
            this.groupBox2.Controls.Add(this.rbD3D11);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // rbOpenGL
            // 
            resources.ApplyResources(this.rbOpenGL, "rbOpenGL");
            this.rbOpenGL.Name = "rbOpenGL";
            this.rbOpenGL.UseVisualStyleBackColor = true;
            // 
            // rbD3D12
            // 
            resources.ApplyResources(this.rbD3D12, "rbD3D12");
            this.rbD3D12.Name = "rbD3D12";
            this.rbD3D12.UseVisualStyleBackColor = true;
            // 
            // rbD3D11
            // 
            resources.ApplyResources(this.rbD3D11, "rbD3D11");
            this.rbD3D11.Checked = true;
            this.rbD3D11.Name = "rbD3D11";
            this.rbD3D11.TabStop = true;
            this.rbD3D11.UseVisualStyleBackColor = true;
            // 
            // ofdDolphin
            // 
            resources.ApplyResources(this.ofdDolphin, "ofdDolphin");
            // 
            // frmConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.tabSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.tabSettings.ResumeLayout(false);
            this.tabSettingsGeneral.ResumeLayout(false);
            this.grbGeneralTemporaryFolder.ResumeLayout(false);
            this.grbGeneralTemporaryFolder.PerformLayout();
            this.grbGeneralFiles.ResumeLayout(false);
            this.grbGeneralFiles.PerformLayout();
            this.grbGeneralFileSize.ResumeLayout(false);
            this.grbGeneralPartitions.ResumeLayout(false);
            this.grbGeneralPartitions.PerformLayout();
            this.tabSettingsNomenclature.ResumeLayout(false);
            this.tabSettingsNomenclature.PerformLayout();
            this.grpNomenclatureFolderFormat.ResumeLayout(false);
            this.grpNomenclatureFolderFormat.PerformLayout();
            this.tabSettingsSeveral.ResumeLayout(false);
            this.grbGeneralDiverse.ResumeLayout(false);
            this.grbGeneralDiverse.PerformLayout();
            this.tabSettingsTransfer.ResumeLayout(false);
            this.tabSettingsTransfer.PerformLayout();
            this.grbGeneralScrub.ResumeLayout(false);
            this.grbGeneralScrub.PerformLayout();
            this.grbTransferSystem.ResumeLayout(false);
            this.grbTransferSystem.PerformLayout();
            this.tabSettingsCovers.ResumeLayout(false);
            this.grpTitlesCoverFolder.ResumeLayout(false);
            this.grpTitlesCoverFolder.PerformLayout();
            this.grbCoverTransfer.ResumeLayout(false);
            this.grbCoverTransfer.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabCoverDisc.ResumeLayout(false);
            this.tabCoverDisc.PerformLayout();
            this.tabCoverFront.ResumeLayout(false);
            this.tabCoverFront.PerformLayout();
            this.tabCover3D.ResumeLayout(false);
            this.tabCover3D.PerformLayout();
            this.tabCoverFull.ResumeLayout(false);
            this.tabCoverFull.PerformLayout();
            this.grpCoversSynchronize.ResumeLayout(false);
            this.grpCoversSynchronize.PerformLayout();
            this.tabSettingsTitle.ResumeLayout(false);
            this.grbTitleLanguage.ResumeLayout(false);
            this.grbTitleFileLocation.ResumeLayout(false);
            this.grbTitleFileLocation.PerformLayout();
            this.grbTitleDiverse.ResumeLayout(false);
            this.grbTitleDiverse.PerformLayout();
            this.tabSettingsUpdates.ResumeLayout(false);
            this.tabSettingsUpdates.PerformLayout();
            this.grbUpdate.ResumeLayout(false);
            this.grbUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabSettingsLanguage.ResumeLayout(false);
            this.tabSettingsLanguage.PerformLayout();
            this.grbLanguage.ResumeLayout(false);
            this.grbLanguage.PerformLayout();
            this.tabSettingsLog.ResumeLayout(false);
            this.grbLog.ResumeLayout(false);
            this.grbLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabSettingsDolphin.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabSettingsGeneral;
        private System.Windows.Forms.GroupBox grbGeneralTemporaryFolder;
        private System.Windows.Forms.Button btnTemporaryFolder;
        private System.Windows.Forms.TextBox tbGeneralTempPath;
        private System.Windows.Forms.GroupBox grbGeneralFiles;
        private System.Windows.Forms.CheckBox chkGeneralExtractSplitFile;
        private System.Windows.Forms.CheckBox chkGeneralExtractBZip2;
        private System.Windows.Forms.CheckBox chkGeneralExtractRar;
        private System.Windows.Forms.CheckBox chkGeneralExtract7z;
        private System.Windows.Forms.CheckBox chkGeneralExtractZip;
        private System.Windows.Forms.Label lblGeneralExtract;
        private System.Windows.Forms.GroupBox grbGeneralFileSize;
        private System.Windows.Forms.ComboBox cbGeneralFileSize;
        private System.Windows.Forms.GroupBox grbGeneralPartitions;
        private System.Windows.Forms.RadioButton rbGeneralDiscDelete;
        private System.Windows.Forms.RadioButton rbGeneralDiscClean;
        private System.Windows.Forms.TabPage tabSettingsSeveral;
        private System.Windows.Forms.TabPage tabSettingsTitle;
        private System.Windows.Forms.GroupBox grbTitleFileLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTitleCustom;
        private System.Windows.Forms.Button btnTitle;
        private System.Windows.Forms.TextBox tbTitleCustom;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.GroupBox grbTitleDiverse;
        private System.Windows.Forms.CheckBox chkGameTitleCustom;
        private System.Windows.Forms.CheckBox chkGameTitle;
        private System.Windows.Forms.TabPage tabSettingsCovers;
        private System.Windows.Forms.GroupBox grpTitlesCoverFolder;
        private System.Windows.Forms.Button btnCoverDirectory;
        private System.Windows.Forms.TextBox tbDirectoryCoverCache;
        private System.Windows.Forms.GroupBox grbCoverTransfer;
        private System.Windows.Forms.RadioButton rbCoverUSBLoaderGX;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabCoverDisc;
        private System.Windows.Forms.Button btnDirectoryCoverDisc;
        private System.Windows.Forms.TextBox tbDirectoryCoverDisc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabCoverFront;
        private System.Windows.Forms.Button btnDirectoryCover2D;
        private System.Windows.Forms.TextBox tbDirectoryCover2D;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabCover3D;
        private System.Windows.Forms.Button btnDirectoryCover3D;
        private System.Windows.Forms.TextBox tbDirectoryCover3D;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabCoverFull;
        private System.Windows.Forms.Button btnDirectoryCoverFull;
        private System.Windows.Forms.TextBox tbDirectoryCoverFull;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.RadioButton rbCoverWiiFlow;
        private System.Windows.Forms.GroupBox grpCoversSynchronize;
        private System.Windows.Forms.CheckBox chkCoverEnableTransfer;
        private System.Windows.Forms.CheckBox chkCoverSynchronizeDelete;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage tabSettingsUpdates;
        private System.Windows.Forms.GroupBox grbUpdate;
        private System.Windows.Forms.TextBox tbPassProxy;
        private System.Windows.Forms.TextBox tbUserProxy;
        private System.Windows.Forms.TextBox tbServerProxy;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblServerProxy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkUpdateServerProxy;
        private System.Windows.Forms.CheckBox chkUpdateFileLog;
        private System.Windows.Forms.CheckBox chkUpdateBetaChannel;
        private System.Windows.Forms.CheckBox chkUpdateVerifyStart;
        private System.Windows.Forms.CheckBox chkGeneralExtractNwb;
        private System.Windows.Forms.TabPage tabSettingsTransfer;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.TabPage tabSettingsLog;
        private System.Windows.Forms.GroupBox grbLog;
        private System.Windows.Forms.Label lblLOG;
        private System.Windows.Forms.CheckBox chkManagerLogFile;
        private System.Windows.Forms.CheckBox chkManagerLogWindow;
        private System.Windows.Forms.CheckBox chkManagerLogDebugConsole;
        private System.Windows.Forms.CheckBox chkManagerLogSystemConsole;
        private System.Windows.Forms.ComboBox cbLevelLog;
        private System.Windows.Forms.GroupBox grbTitleLanguage;
        private System.Windows.Forms.Button btnTitleDownload;
        private System.Windows.Forms.ComboBox cbTitleLanguage;
        private System.Windows.Forms.GroupBox grbTransferSystem;
        private System.Windows.Forms.RadioButton rbTransferSystemFST;
        private System.Windows.Forms.RadioButton rbTransferSystemWipe;
        private System.Windows.Forms.RadioButton rbTransferSystemXCopy;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblXCopy;
        private System.Windows.Forms.Label lblScrub;
        private System.Windows.Forms.Label lblWipe;
        private System.Windows.Forms.Label lblFST;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox grbGeneralDiverse;
        private System.Windows.Forms.CheckBox chkGeneralSHA1;
        private System.Windows.Forms.CheckBox chkGeneralRecursiva;
        private System.Windows.Forms.CheckBox chkGeneralTemporaryBuffer;
        private System.Windows.Forms.CheckBox chkGeneralMD5;
        private System.Windows.Forms.CheckBox chkStartWindowMaximized;
        private System.Windows.Forms.GroupBox grbGeneralScrub;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Label lblAlignment;
        private System.Windows.Forms.ComboBox cbScrubFormat;
        private System.Windows.Forms.ComboBox cbScrubAlign;
        private System.Windows.Forms.CheckBox chkGeneralScrubFlushSD;
        private System.Windows.Forms.CheckBox chkNetVerify;
        private System.Windows.Forms.CheckBox chkWelcome;
        private System.Windows.Forms.CheckBox chkScreensaver;
        private System.Windows.Forms.RadioButton rbGameXmlName;
        private System.Windows.Forms.RadioButton rbGameInternalName;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox chkNotify;
        private System.Windows.Forms.TabPage tabSettingsNomenclature;
        private System.Windows.Forms.GroupBox grpNomenclatureFolderFormat;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.ComboBox cbAdjustNamingStyle;
        private System.Windows.Forms.Label lblNomenclature;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox chkLoadDatabase;
        private System.Windows.Forms.ComboBox cbVerificationInterval;
        private System.Windows.Forms.Label lblUpdateInterval;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox chkMultipleInstances;
        private System.Windows.Forms.TabPage tabSettingsLanguage;
        private System.Windows.Forms.GroupBox grbLanguage;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Label lblLanguageComments;
        private System.Windows.Forms.CheckBox chkCoverRecursiveSearch;
        private System.Windows.Forms.Label lblCommentsScrubCopy;
        private System.Windows.Forms.Label lblCommentsExactCopy;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblTimeInterval;
        private System.Windows.Forms.TabPage tabSettingsDolphin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox tbPathDolphinEmulator;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbHLE;
        private System.Windows.Forms.RadioButton rbLLE;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbOpenGL;
        private System.Windows.Forms.RadioButton rbD3D12;
        private System.Windows.Forms.RadioButton rbD3D11;
        private System.Windows.Forms.OpenFileDialog ofdDolphin;
    }
}