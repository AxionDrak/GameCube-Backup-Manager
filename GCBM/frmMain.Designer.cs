
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GCBM.Properties;

namespace GCBM
{
    partial class frmMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbGameCover3D = new System.Windows.Forms.PictureBox();
            this.pbGameDisc = new System.Windows.Forms.PictureBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabMainFile = new System.Windows.Forms.TabPage();
            this.lblInstallStatusGameIndex = new System.Windows.Forms.Label();
            this.pbSource = new System.Windows.Forms.ProgressBar();
            this.lblSourceCount = new System.Windows.Forms.Label();
            this.lblGamesVerifiedText = new System.Windows.Forms.Label();
            this.lblAbort = new System.Windows.Forms.Label();
            this.pbCopy = new System.Windows.Forms.ProgressBar();
            this.lblInstallStatusGameTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAbort = new System.Windows.Forms.Button();
            this.lblInstallStatusPercent = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lblInstallStatusText = new System.Windows.Forms.Label();
            this.grpDetailsSource = new System.Windows.Forms.GroupBox();
            this.lblTypeDisc = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tbIDMakerCode = new System.Windows.Forms.TextBox();
            this.tbIDDiscID = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.pbWebGameID = new System.Windows.Forms.PictureBox();
            this.grpOperations = new System.Windows.Forms.GroupBox();
            this.btnGameInstallScrub = new System.Windows.Forms.Button();
            this.btnGameInstallExactCopy = new System.Windows.Forms.Button();
            this.labelGameID = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.tbIDGame = new System.Windows.Forms.TextBox();
            this.tbIDRegion = new System.Windows.Forms.TextBox();
            this.tbIDName = new System.Windows.Forms.TextBox();
            this.dgvSource = new System.Windows.Forms.DataGridView();
            this.clmChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiInfoGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDolphinEmulator = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSearchOnGameTDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSearchOnGoogle = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchOnWikipedia = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSearchOnYoutube = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSearchOnGameSpot = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSearchOnVGChartz = new System.Windows.Forms.ToolStripMenuItem();
            this.mstripFile = new System.Windows.Forms.MenuStrip();
            this.tsmiReloadGameList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearListSource = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectGameList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameListSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameListSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveGameList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameListDeleteAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameListDeleteSelectedFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiToolsGameList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameListSignatureSHA1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameListHashSHA1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportTXT = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMainDisc = new System.Windows.Forms.TabPage();
            this.lblAbortDestination = new System.Windows.Forms.Label();
            this.pbDestination = new System.Windows.Forms.ProgressBar();
            this.btnAbortDestination = new System.Windows.Forms.Button();
            this.lblDestinationCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSpaceAvailabeOnDevice = new System.Windows.Forms.Label();
            this.lblSpaceTotalOnDevice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpDetailsDestiny = new System.Windows.Forms.GroupBox();
            this.pbWebGameDiscID = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbIDGameDisc = new System.Windows.Forms.TextBox();
            this.tbIDRegionDisc = new System.Windows.Forms.TextBox();
            this.tbIDNameDisc = new System.Windows.Forms.TextBox();
            this.dgvDestination = new System.Windows.Forms.DataGridView();
            this.dgvMainDiscCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmDiscTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiscID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiscRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiscExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiscSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiscPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mstripDisc = new System.Windows.Forms.MenuStrip();
            this.tscbDiscDrive = new System.Windows.Forms.ToolStripComboBox();
            this.tsmiReloadDeviceDrive = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReloadGameListDisc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearListDestination = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectGameDisc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameDiscSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameDiscSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveGameDisc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameDiscDeleteAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameDiscDeleteSelectedFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiToolsGameDisc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameDiscExportList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiGameDiscSignatureSHA1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameDiscAllHashSHA1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameDiscHashSHA1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameDiscSignatureMD5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameDiscAllHashMD5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameDiscHashMD5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiGameDiscRecalculateAllMD5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameDiscRecalculateSelectedGameMD5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMainDatabase = new System.Windows.Forms.TabPage();
            this.lblDatabaseTotal = new System.Windows.Forms.Label();
            this.cbFilterDatabase = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lvDatabase = new System.Windows.Forms.ListView();
            this.mstripDatabase = new System.Windows.Forms.MenuStrip();
            this.tsmiToolDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDatabaseUpdateGameTDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMainLog = new System.Windows.Forms.TabPage();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.mstripLog = new System.Windows.Forms.MenuStrip();
            this.tsmiToolLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExportLog = new System.Windows.Forms.ToolStripMenuItem();
            this.sstripMain = new System.Windows.Forms.StatusStrip();
            this.tsslCurrentYear = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblScan = new System.Windows.Forms.ToolStripStatusLabel();
            this.mstripMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCovers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDownloadCoversSelectedGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSyncDownloadDiscOnly3DCovers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSyncDownloadAllDiscOnly3DCovers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSyncDownloadAllCovers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTransferDeviceCovers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.boxArtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEnableCoverPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisableCoverPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConfigurationMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenameFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenameISO = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainPlugins = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMetaXml = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageApp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiElfDol = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreatePackage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBurnMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWebsiteFacebook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOfficialGitHub = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOfficialGBATemp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiVerifyUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fbd2 = new System.Windows.Forms.FolderBrowserDialog();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.lblNetStatus = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNotifyExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pbNetStatus = new System.Windows.Forms.PictureBox();
            this.gameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.process1 = new System.Diagnostics.Process();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameCover3D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameDisc)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabMainFile.SuspendLayout();
            this.grpDetailsSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebGameID)).BeginInit();
            this.grpOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).BeginInit();
            this.cmsMain.SuspendLayout();
            this.mstripFile.SuspendLayout();
            this.tabMainDisc.SuspendLayout();
            this.grpDetailsDestiny.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebGameDiscID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestination)).BeginInit();
            this.mstripDisc.SuspendLayout();
            this.tabMainDatabase.SuspendLayout();
            this.mstripDatabase.SuspendLayout();
            this.tabMainLog.SuspendLayout();
            this.mstripLog.SuspendLayout();
            this.sstripMain.SuspendLayout();
            this.mstripMain.SuspendLayout();
            this.cmsNotifyIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNetStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            resources.ApplyResources(this.spcMain, "spcMain");
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            resources.ApplyResources(this.spcMain.Panel1, "spcMain.Panel1");
            this.spcMain.Panel1.Controls.Add(this.grpSearch);
            this.spcMain.Panel1.Controls.Add(this.groupBox1);
            // 
            // spcMain.Panel2
            // 
            resources.ApplyResources(this.spcMain.Panel2, "spcMain.Panel2");
            this.spcMain.Panel2.Controls.Add(this.tabControlMain);
            // 
            // grpSearch
            // 
            resources.ApplyResources(this.grpSearch, "grpSearch");
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.tbSearch);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.TabStop = false;
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.Search_Click);
            this.btnSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnSearch_KeyPress);
            // 
            // tbSearch
            // 
            resources.ApplyResources(this.tbSearch, "tbSearch");
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.TextChanged += new System.EventHandler(this.Search_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.pbGameCover3D);
            this.groupBox1.Controls.Add(this.pbGameDisc);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // pbGameCover3D
            // 
            resources.ApplyResources(this.pbGameCover3D, "pbGameCover3D");
            this.pbGameCover3D.Name = "pbGameCover3D";
            this.pbGameCover3D.TabStop = false;
            // 
            // pbGameDisc
            // 
            resources.ApplyResources(this.pbGameDisc, "pbGameDisc");
            this.pbGameDisc.Name = "pbGameDisc";
            this.pbGameDisc.TabStop = false;
            // 
            // tabControlMain
            // 
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.Controls.Add(this.tabMainFile);
            this.tabControlMain.Controls.Add(this.tabMainDisc);
            this.tabControlMain.Controls.Add(this.tabMainDatabase);
            this.tabControlMain.Controls.Add(this.tabMainLog);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabMainFile
            // 
            resources.ApplyResources(this.tabMainFile, "tabMainFile");
            this.tabMainFile.Controls.Add(this.lblInstallStatusGameIndex);
            this.tabMainFile.Controls.Add(this.pbSource);
            this.tabMainFile.Controls.Add(this.lblSourceCount);
            this.tabMainFile.Controls.Add(this.lblGamesVerifiedText);
            this.tabMainFile.Controls.Add(this.lblAbort);
            this.tabMainFile.Controls.Add(this.pbCopy);
            this.tabMainFile.Controls.Add(this.lblInstallStatusGameTitle);
            this.tabMainFile.Controls.Add(this.label1);
            this.tabMainFile.Controls.Add(this.btnAbort);
            this.tabMainFile.Controls.Add(this.lblInstallStatusPercent);
            this.tabMainFile.Controls.Add(this.btnSelectFolder);
            this.tabMainFile.Controls.Add(this.lblInstallStatusText);
            this.tabMainFile.Controls.Add(this.grpDetailsSource);
            this.tabMainFile.Controls.Add(this.dgvSource);
            this.tabMainFile.Controls.Add(this.mstripFile);
            this.tabMainFile.Name = "tabMainFile";
            this.tabMainFile.UseVisualStyleBackColor = true;
            // 
            // lblInstallStatusGameIndex
            // 
            resources.ApplyResources(this.lblInstallStatusGameIndex, "lblInstallStatusGameIndex");
            this.lblInstallStatusGameIndex.Name = "lblInstallStatusGameIndex";
            // 
            // pbSource
            // 
            resources.ApplyResources(this.pbSource, "pbSource");
            this.pbSource.Name = "pbSource";
            // 
            // lblSourceCount
            // 
            resources.ApplyResources(this.lblSourceCount, "lblSourceCount");
            this.lblSourceCount.Name = "lblSourceCount";
            // 
            // lblGamesVerifiedText
            // 
            resources.ApplyResources(this.lblGamesVerifiedText, "lblGamesVerifiedText");
            this.lblGamesVerifiedText.Name = "lblGamesVerifiedText";
            // 
            // lblAbort
            // 
            resources.ApplyResources(this.lblAbort, "lblAbort");
            this.lblAbort.Name = "lblAbort";
            // 
            // pbCopy
            // 
            resources.ApplyResources(this.pbCopy, "pbCopy");
            this.pbCopy.Name = "pbCopy";
            // 
            // lblInstallStatusGameTitle
            // 
            resources.ApplyResources(this.lblInstallStatusGameTitle, "lblInstallStatusGameTitle");
            this.lblInstallStatusGameTitle.Name = "lblInstallStatusGameTitle";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnAbort
            // 
            resources.ApplyResources(this.btnAbort, "btnAbort");
            this.btnAbort.FlatAppearance.BorderSize = 0;
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // lblInstallStatusPercent
            // 
            resources.ApplyResources(this.lblInstallStatusPercent, "lblInstallStatusPercent");
            this.lblInstallStatusPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblInstallStatusPercent.Name = "lblInstallStatusPercent";
            // 
            // btnSelectFolder
            // 
            resources.ApplyResources(this.btnSelectFolder, "btnSelectFolder");
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblInstallStatusText
            // 
            resources.ApplyResources(this.lblInstallStatusText, "lblInstallStatusText");
            this.lblInstallStatusText.Name = "lblInstallStatusText";
            // 
            // grpDetailsSource
            // 
            resources.ApplyResources(this.grpDetailsSource, "grpDetailsSource");
            this.grpDetailsSource.Controls.Add(this.lblTypeDisc);
            this.grpDetailsSource.Controls.Add(this.label34);
            this.grpDetailsSource.Controls.Add(this.tbIDMakerCode);
            this.grpDetailsSource.Controls.Add(this.tbIDDiscID);
            this.grpDetailsSource.Controls.Add(this.label29);
            this.grpDetailsSource.Controls.Add(this.pbWebGameID);
            this.grpDetailsSource.Controls.Add(this.grpOperations);
            this.grpDetailsSource.Controls.Add(this.labelGameID);
            this.grpDetailsSource.Controls.Add(this.labelFile);
            this.grpDetailsSource.Controls.Add(this.labelTitle);
            this.grpDetailsSource.Controls.Add(this.tbIDGame);
            this.grpDetailsSource.Controls.Add(this.tbIDRegion);
            this.grpDetailsSource.Controls.Add(this.tbIDName);
            this.grpDetailsSource.Name = "grpDetailsSource";
            this.grpDetailsSource.TabStop = false;
            // 
            // lblTypeDisc
            // 
            resources.ApplyResources(this.lblTypeDisc, "lblTypeDisc");
            this.lblTypeDisc.Name = "lblTypeDisc";
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // tbIDMakerCode
            // 
            resources.ApplyResources(this.tbIDMakerCode, "tbIDMakerCode");
            this.tbIDMakerCode.Name = "tbIDMakerCode";
            this.tbIDMakerCode.ReadOnly = true;
            // 
            // tbIDDiscID
            // 
            resources.ApplyResources(this.tbIDDiscID, "tbIDDiscID");
            this.tbIDDiscID.Name = "tbIDDiscID";
            this.tbIDDiscID.ReadOnly = true;
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // pbWebGameID
            // 
            resources.ApplyResources(this.pbWebGameID, "pbWebGameID");
            this.pbWebGameID.Name = "pbWebGameID";
            this.pbWebGameID.TabStop = false;
            this.pbWebGameID.Click += new System.EventHandler(this.pbWebGameID_Click);
            // 
            // grpOperations
            // 
            resources.ApplyResources(this.grpOperations, "grpOperations");
            this.grpOperations.Controls.Add(this.btnGameInstallScrub);
            this.grpOperations.Controls.Add(this.btnGameInstallExactCopy);
            this.grpOperations.Name = "grpOperations";
            this.grpOperations.TabStop = false;
            // 
            // btnGameInstallScrub
            // 
            resources.ApplyResources(this.btnGameInstallScrub, "btnGameInstallScrub");
            this.btnGameInstallScrub.Name = "btnGameInstallScrub";
            this.btnGameInstallScrub.UseVisualStyleBackColor = true;
            this.btnGameInstallScrub.Click += new System.EventHandler(this.btnGameInstallScrub_Click);
            // 
            // btnGameInstallExactCopy
            // 
            resources.ApplyResources(this.btnGameInstallExactCopy, "btnGameInstallExactCopy");
            this.btnGameInstallExactCopy.Name = "btnGameInstallExactCopy";
            this.btnGameInstallExactCopy.UseVisualStyleBackColor = true;
            this.btnGameInstallExactCopy.Click += new System.EventHandler(this.btnGameInstallExactCopy_Click);
            // 
            // labelGameID
            // 
            resources.ApplyResources(this.labelGameID, "labelGameID");
            this.labelGameID.Name = "labelGameID";
            // 
            // labelFile
            // 
            resources.ApplyResources(this.labelFile, "labelFile");
            this.labelFile.Name = "labelFile";
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // tbIDGame
            // 
            resources.ApplyResources(this.tbIDGame, "tbIDGame");
            this.tbIDGame.Name = "tbIDGame";
            this.tbIDGame.ReadOnly = true;
            // 
            // tbIDRegion
            // 
            resources.ApplyResources(this.tbIDRegion, "tbIDRegion");
            this.tbIDRegion.Name = "tbIDRegion";
            this.tbIDRegion.ReadOnly = true;
            // 
            // tbIDName
            // 
            resources.ApplyResources(this.tbIDName, "tbIDName");
            this.tbIDName.Name = "tbIDName";
            this.tbIDName.ReadOnly = true;
            // 
            // dgvSource
            // 
            resources.ApplyResources(this.dgvSource, "dgvSource");
            this.dgvSource.AllowUserToAddRows = false;
            this.dgvSource.AllowUserToDeleteRows = false;
            this.dgvSource.AllowUserToResizeRows = false;
            this.dgvSource.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSource.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSource.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmChk,
            this.clmTitle,
            this.clmRegion,
            this.clmID,
            this.clmExtension,
            this.clmSize,
            this.clmPath});
            this.dgvSource.ContextMenuStrip = this.cmsMain;
            this.dgvSource.Name = "dgvSource";
            this.dgvSource.ReadOnly = true;
            this.dgvSource.RowHeadersVisible = false;
            this.dgvSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSource.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSource_CellContentClick);
            this.dgvSource.CurrentCellChanged += new System.EventHandler(this.dgvSource_CurrentCellChanged);
            // 
            // clmChk
            // 
            this.clmChk.FillWeight = 0.6474377F;
            resources.ApplyResources(this.clmChk, "clmChk");
            this.clmChk.Name = "clmChk";
            this.clmChk.ReadOnly = true;
            // 
            // clmTitle
            // 
            this.clmTitle.FillWeight = 186.4554F;
            resources.ApplyResources(this.clmTitle, "clmTitle");
            this.clmTitle.Name = "clmTitle";
            this.clmTitle.ReadOnly = true;
            // 
            // clmRegion
            // 
            this.clmRegion.FillWeight = 96.77139F;
            resources.ApplyResources(this.clmRegion, "clmRegion");
            this.clmRegion.Name = "clmRegion";
            this.clmRegion.ReadOnly = true;
            // 
            // clmID
            // 
            this.clmID.FillWeight = 72.39307F;
            resources.ApplyResources(this.clmID, "clmID");
            this.clmID.Name = "clmID";
            this.clmID.ReadOnly = true;
            // 
            // clmExtension
            // 
            resources.ApplyResources(this.clmExtension, "clmExtension");
            this.clmExtension.Name = "clmExtension";
            this.clmExtension.ReadOnly = true;
            // 
            // clmSize
            // 
            this.clmSize.FillWeight = 129.4417F;
            resources.ApplyResources(this.clmSize, "clmSize");
            this.clmSize.Name = "clmSize";
            this.clmSize.ReadOnly = true;
            // 
            // clmPath
            // 
            this.clmPath.FillWeight = 24.29118F;
            resources.ApplyResources(this.clmPath, "clmPath");
            this.clmPath.Name = "clmPath";
            this.clmPath.ReadOnly = true;
            // 
            // cmsMain
            // 
            resources.ApplyResources(this.cmsMain, "cmsMain");
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInfoGame,
            this.toolStripMenuItem10,
            this.tsmiDolphinEmulator,
            this.toolStripMenuItem9,
            this.tsmiSearchOnGameTDB,
            this.toolStripMenuItem8,
            this.tsmiSearchOnGoogle,
            this.SearchOnWikipedia,
            this.tsmiSearchOnYoutube,
            this.tsmiSearchOnGameSpot,
            this.tsmiSearchOnVGChartz});
            this.cmsMain.Name = "cmsMain";
            // 
            // tsmiInfoGame
            // 
            resources.ApplyResources(this.tsmiInfoGame, "tsmiInfoGame");
            this.tsmiInfoGame.Name = "tsmiInfoGame";
            this.tsmiInfoGame.Click += new System.EventHandler(this.tsmiInfoGame_Click);
            // 
            // toolStripMenuItem10
            // 
            resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            // 
            // tsmiDolphinEmulator
            // 
            resources.ApplyResources(this.tsmiDolphinEmulator, "tsmiDolphinEmulator");
            this.tsmiDolphinEmulator.Name = "tsmiDolphinEmulator";
            this.tsmiDolphinEmulator.Click += new System.EventHandler(this.tsmiDolphinEmulator_Click);
            // 
            // toolStripMenuItem9
            // 
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            // 
            // tsmiSearchOnGameTDB
            // 
            resources.ApplyResources(this.tsmiSearchOnGameTDB, "tsmiSearchOnGameTDB");
            this.tsmiSearchOnGameTDB.Name = "tsmiSearchOnGameTDB";
            this.tsmiSearchOnGameTDB.Click += new System.EventHandler(this.tsmiSearchOnGameTDB_Click);
            // 
            // toolStripMenuItem8
            // 
            resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            // 
            // tsmiSearchOnGoogle
            // 
            resources.ApplyResources(this.tsmiSearchOnGoogle, "tsmiSearchOnGoogle");
            this.tsmiSearchOnGoogle.Name = "tsmiSearchOnGoogle";
            this.tsmiSearchOnGoogle.Click += new System.EventHandler(this.tsmiSearchOnGoogle_Click);
            // 
            // SearchOnWikipedia
            // 
            resources.ApplyResources(this.SearchOnWikipedia, "SearchOnWikipedia");
            this.SearchOnWikipedia.Name = "SearchOnWikipedia";
            this.SearchOnWikipedia.Click += new System.EventHandler(this.SearchOnWikipedia_Click);
            // 
            // tsmiSearchOnYoutube
            // 
            resources.ApplyResources(this.tsmiSearchOnYoutube, "tsmiSearchOnYoutube");
            this.tsmiSearchOnYoutube.Name = "tsmiSearchOnYoutube";
            this.tsmiSearchOnYoutube.Click += new System.EventHandler(this.tsmiSearchOnYoutube_Click);
            // 
            // tsmiSearchOnGameSpot
            // 
            resources.ApplyResources(this.tsmiSearchOnGameSpot, "tsmiSearchOnGameSpot");
            this.tsmiSearchOnGameSpot.Name = "tsmiSearchOnGameSpot";
            this.tsmiSearchOnGameSpot.Click += new System.EventHandler(this.tsmiSearchOnGameSpot_Click);
            // 
            // tsmiSearchOnVGChartz
            // 
            resources.ApplyResources(this.tsmiSearchOnVGChartz, "tsmiSearchOnVGChartz");
            this.tsmiSearchOnVGChartz.Name = "tsmiSearchOnVGChartz";
            this.tsmiSearchOnVGChartz.Click += new System.EventHandler(this.tsmiSearchOnVGChartz_Click);
            // 
            // mstripFile
            // 
            resources.ApplyResources(this.mstripFile, "mstripFile");
            this.mstripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReloadGameList,
            this.tsmiClearListSource,
            this.tsmiSelectGameList,
            this.tsmiRemoveGameList,
            this.tsmiToolsGameList});
            this.mstripFile.Name = "mstripFile";
            // 
            // tsmiReloadGameList
            // 
            resources.ApplyResources(this.tsmiReloadGameList, "tsmiReloadGameList");
            this.tsmiReloadGameList.Name = "tsmiReloadGameList";
            this.tsmiReloadGameList.Click += new System.EventHandler(this.tsmiReloadGameList_Click);
            // 
            // tsmiClearListSource
            // 
            resources.ApplyResources(this.tsmiClearListSource, "tsmiClearListSource");
            this.tsmiClearListSource.Name = "tsmiClearListSource";
            this.tsmiClearListSource.Click += new System.EventHandler(this.tsmiClearListSource_Click);
            // 
            // tsmiSelectGameList
            // 
            resources.ApplyResources(this.tsmiSelectGameList, "tsmiSelectGameList");
            this.tsmiSelectGameList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameListSelectAll,
            this.tsmiGameListSelectNone});
            this.tsmiSelectGameList.Name = "tsmiSelectGameList";
            // 
            // tsmiGameListSelectAll
            // 
            resources.ApplyResources(this.tsmiGameListSelectAll, "tsmiGameListSelectAll");
            this.tsmiGameListSelectAll.Name = "tsmiGameListSelectAll";
            this.tsmiGameListSelectAll.Click += new System.EventHandler(this.tsmiGameSelectAll_Click);
            // 
            // tsmiGameListSelectNone
            // 
            resources.ApplyResources(this.tsmiGameListSelectNone, "tsmiGameListSelectNone");
            this.tsmiGameListSelectNone.Name = "tsmiGameListSelectNone";
            this.tsmiGameListSelectNone.Click += new System.EventHandler(this.tsmiGameSelectNone_Click);
            // 
            // tsmiRemoveGameList
            // 
            resources.ApplyResources(this.tsmiRemoveGameList, "tsmiRemoveGameList");
            this.tsmiRemoveGameList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameListDeleteAllFiles,
            this.tsmiGameListDeleteSelectedFile});
            this.tsmiRemoveGameList.Name = "tsmiRemoveGameList";
            // 
            // tsmiGameListDeleteAllFiles
            // 
            resources.ApplyResources(this.tsmiGameListDeleteAllFiles, "tsmiGameListDeleteAllFiles");
            this.tsmiGameListDeleteAllFiles.Name = "tsmiGameListDeleteAllFiles";
            this.tsmiGameListDeleteAllFiles.Click += new System.EventHandler(this.tsmiGameListDeleteAllFiles_Click);
            // 
            // tsmiGameListDeleteSelectedFile
            // 
            resources.ApplyResources(this.tsmiGameListDeleteSelectedFile, "tsmiGameListDeleteSelectedFile");
            this.tsmiGameListDeleteSelectedFile.Name = "tsmiGameListDeleteSelectedFile";
            this.tsmiGameListDeleteSelectedFile.Click += new System.EventHandler(this.tsmiDeleteSelectedFile_Click);
            // 
            // tsmiToolsGameList
            // 
            resources.ApplyResources(this.tsmiToolsGameList, "tsmiToolsGameList");
            this.tsmiToolsGameList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameListSignatureSHA1,
            this.exportarListaToolStripMenuItem});
            this.tsmiToolsGameList.Name = "tsmiToolsGameList";
            // 
            // tsmiGameListSignatureSHA1
            // 
            resources.ApplyResources(this.tsmiGameListSignatureSHA1, "tsmiGameListSignatureSHA1");
            this.tsmiGameListSignatureSHA1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameListHashSHA1});
            this.tsmiGameListSignatureSHA1.Name = "tsmiGameListSignatureSHA1";
            // 
            // tsmiGameListHashSHA1
            // 
            resources.ApplyResources(this.tsmiGameListHashSHA1, "tsmiGameListHashSHA1");
            this.tsmiGameListHashSHA1.Name = "tsmiGameListHashSHA1";
            this.tsmiGameListHashSHA1.Click += new System.EventHandler(this.tsmiGameHashSHA1_Click);
            // 
            // exportarListaToolStripMenuItem
            // 
            resources.ApplyResources(this.exportarListaToolStripMenuItem, "exportarListaToolStripMenuItem");
            this.exportarListaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportTXT,
            this.tsmiExportHTML,
            this.tsmiExportCSV});
            this.exportarListaToolStripMenuItem.Name = "exportarListaToolStripMenuItem";
            // 
            // tsmiExportTXT
            // 
            resources.ApplyResources(this.tsmiExportTXT, "tsmiExportTXT");
            this.tsmiExportTXT.Name = "tsmiExportTXT";
            this.tsmiExportTXT.Click += new System.EventHandler(this.tsmiExportTXT_Click);
            // 
            // tsmiExportHTML
            // 
            resources.ApplyResources(this.tsmiExportHTML, "tsmiExportHTML");
            this.tsmiExportHTML.Name = "tsmiExportHTML";
            this.tsmiExportHTML.Click += new System.EventHandler(this.tsmiExportHTML_Click);
            // 
            // tsmiExportCSV
            // 
            resources.ApplyResources(this.tsmiExportCSV, "tsmiExportCSV");
            this.tsmiExportCSV.Name = "tsmiExportCSV";
            this.tsmiExportCSV.Click += new System.EventHandler(this.tsmiExportCSV_Click);
            // 
            // tabMainDisc
            // 
            resources.ApplyResources(this.tabMainDisc, "tabMainDisc");
            this.tabMainDisc.Controls.Add(this.lblAbortDestination);
            this.tabMainDisc.Controls.Add(this.pbDestination);
            this.tabMainDisc.Controls.Add(this.btnAbortDestination);
            this.tabMainDisc.Controls.Add(this.lblDestinationCount);
            this.tabMainDisc.Controls.Add(this.label8);
            this.tabMainDisc.Controls.Add(this.lblSpaceAvailabeOnDevice);
            this.tabMainDisc.Controls.Add(this.lblSpaceTotalOnDevice);
            this.tabMainDisc.Controls.Add(this.label3);
            this.tabMainDisc.Controls.Add(this.label2);
            this.tabMainDisc.Controls.Add(this.grpDetailsDestiny);
            this.tabMainDisc.Controls.Add(this.dgvDestination);
            this.tabMainDisc.Controls.Add(this.mstripDisc);
            this.tabMainDisc.Name = "tabMainDisc";
            this.tabMainDisc.UseVisualStyleBackColor = true;
            // 
            // lblAbortDestination
            // 
            resources.ApplyResources(this.lblAbortDestination, "lblAbortDestination");
            this.lblAbortDestination.Name = "lblAbortDestination";
            // 
            // pbDestination
            // 
            resources.ApplyResources(this.pbDestination, "pbDestination");
            this.pbDestination.Name = "pbDestination";
            // 
            // btnAbortDestination
            // 
            resources.ApplyResources(this.btnAbortDestination, "btnAbortDestination");
            this.btnAbortDestination.FlatAppearance.BorderSize = 0;
            this.btnAbortDestination.Name = "btnAbortDestination";
            this.btnAbortDestination.UseVisualStyleBackColor = true;
            this.btnAbortDestination.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // lblDestinationCount
            // 
            resources.ApplyResources(this.lblDestinationCount, "lblDestinationCount");
            this.lblDestinationCount.Name = "lblDestinationCount";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // lblSpaceAvailabeOnDevice
            // 
            resources.ApplyResources(this.lblSpaceAvailabeOnDevice, "lblSpaceAvailabeOnDevice");
            this.lblSpaceAvailabeOnDevice.Name = "lblSpaceAvailabeOnDevice";
            // 
            // lblSpaceTotalOnDevice
            // 
            resources.ApplyResources(this.lblSpaceTotalOnDevice, "lblSpaceTotalOnDevice");
            this.lblSpaceTotalOnDevice.Name = "lblSpaceTotalOnDevice";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // grpDetailsDestiny
            // 
            resources.ApplyResources(this.grpDetailsDestiny, "grpDetailsDestiny");
            this.grpDetailsDestiny.Controls.Add(this.pbWebGameDiscID);
            this.grpDetailsDestiny.Controls.Add(this.label4);
            this.grpDetailsDestiny.Controls.Add(this.label5);
            this.grpDetailsDestiny.Controls.Add(this.label6);
            this.grpDetailsDestiny.Controls.Add(this.tbIDGameDisc);
            this.grpDetailsDestiny.Controls.Add(this.tbIDRegionDisc);
            this.grpDetailsDestiny.Controls.Add(this.tbIDNameDisc);
            this.grpDetailsDestiny.Name = "grpDetailsDestiny";
            this.grpDetailsDestiny.TabStop = false;
            // 
            // pbWebGameDiscID
            // 
            resources.ApplyResources(this.pbWebGameDiscID, "pbWebGameDiscID");
            this.pbWebGameDiscID.Name = "pbWebGameDiscID";
            this.pbWebGameDiscID.TabStop = false;
            this.pbWebGameDiscID.Click += new System.EventHandler(this.pbWebGameDiscID_Click);
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
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tbIDGameDisc
            // 
            resources.ApplyResources(this.tbIDGameDisc, "tbIDGameDisc");
            this.tbIDGameDisc.Name = "tbIDGameDisc";
            this.tbIDGameDisc.ReadOnly = true;
            // 
            // tbIDRegionDisc
            // 
            resources.ApplyResources(this.tbIDRegionDisc, "tbIDRegionDisc");
            this.tbIDRegionDisc.Name = "tbIDRegionDisc";
            this.tbIDRegionDisc.ReadOnly = true;
            // 
            // tbIDNameDisc
            // 
            resources.ApplyResources(this.tbIDNameDisc, "tbIDNameDisc");
            this.tbIDNameDisc.Name = "tbIDNameDisc";
            this.tbIDNameDisc.ReadOnly = true;
            // 
            // dgvDestination
            // 
            resources.ApplyResources(this.dgvDestination, "dgvDestination");
            this.dgvDestination.AllowUserToAddRows = false;
            this.dgvDestination.AllowUserToDeleteRows = false;
            this.dgvDestination.AllowUserToResizeRows = false;
            this.dgvDestination.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDestination.BackgroundColor = System.Drawing.Color.White;
            this.dgvDestination.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvDestination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDestination.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvMainDiscCheck,
            this.clmDiscTitle,
            this.clmDiscID,
            this.clmDiscRegion,
            this.clmDiscExtension,
            this.clmDiscSize,
            this.clmDiscPath});
            this.dgvDestination.MultiSelect = false;
            this.dgvDestination.Name = "dgvDestination";
            this.dgvDestination.ReadOnly = true;
            this.dgvDestination.RowHeadersVisible = false;
            this.dgvDestination.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDestination.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSource_CellContentClick);
            this.dgvDestination.CurrentCellChanged += new System.EventHandler(this.dgvDestination_CurrentCellChanged);
            // 
            // dgvMainDiscCheck
            // 
            this.dgvMainDiscCheck.FillWeight = 0.96F;
            resources.ApplyResources(this.dgvMainDiscCheck, "dgvMainDiscCheck");
            this.dgvMainDiscCheck.Name = "dgvMainDiscCheck";
            this.dgvMainDiscCheck.ReadOnly = true;
            this.dgvMainDiscCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clmDiscTitle
            // 
            this.clmDiscTitle.FillWeight = 186F;
            resources.ApplyResources(this.clmDiscTitle, "clmDiscTitle");
            this.clmDiscTitle.Name = "clmDiscTitle";
            this.clmDiscTitle.ReadOnly = true;
            // 
            // clmDiscID
            // 
            this.clmDiscID.FillWeight = 96F;
            resources.ApplyResources(this.clmDiscID, "clmDiscID");
            this.clmDiscID.Name = "clmDiscID";
            this.clmDiscID.ReadOnly = true;
            // 
            // clmDiscRegion
            // 
            this.clmDiscRegion.FillWeight = 72F;
            resources.ApplyResources(this.clmDiscRegion, "clmDiscRegion");
            this.clmDiscRegion.Name = "clmDiscRegion";
            this.clmDiscRegion.ReadOnly = true;
            // 
            // clmDiscExtension
            // 
            resources.ApplyResources(this.clmDiscExtension, "clmDiscExtension");
            this.clmDiscExtension.Name = "clmDiscExtension";
            this.clmDiscExtension.ReadOnly = true;
            // 
            // clmDiscSize
            // 
            this.clmDiscSize.FillWeight = 130F;
            resources.ApplyResources(this.clmDiscSize, "clmDiscSize");
            this.clmDiscSize.Name = "clmDiscSize";
            this.clmDiscSize.ReadOnly = true;
            // 
            // clmDiscPath
            // 
            this.clmDiscPath.FillWeight = 24F;
            resources.ApplyResources(this.clmDiscPath, "clmDiscPath");
            this.clmDiscPath.Name = "clmDiscPath";
            this.clmDiscPath.ReadOnly = true;
            // 
            // mstripDisc
            // 
            resources.ApplyResources(this.mstripDisc, "mstripDisc");
            this.mstripDisc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbDiscDrive,
            this.tsmiReloadDeviceDrive,
            this.tsmiReloadGameListDisc,
            this.tsmiClearListDestination,
            this.tsmiSelectGameDisc,
            this.tsmiRemoveGameDisc,
            this.tsmiToolsGameDisc});
            this.mstripDisc.Name = "mstripDisc";
            // 
            // tscbDiscDrive
            // 
            resources.ApplyResources(this.tscbDiscDrive, "tscbDiscDrive");
            this.tscbDiscDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbDiscDrive.Items.AddRange(new object[] {
            resources.GetString("tscbDiscDrive.Items")});
            this.tscbDiscDrive.Name = "tscbDiscDrive";
            this.tscbDiscDrive.SelectedIndexChanged += new System.EventHandler(this.tscbDiscDrive_SelectedIndexChanged);
            // 
            // tsmiReloadDeviceDrive
            // 
            resources.ApplyResources(this.tsmiReloadDeviceDrive, "tsmiReloadDeviceDrive");
            this.tsmiReloadDeviceDrive.Name = "tsmiReloadDeviceDrive";
            this.tsmiReloadDeviceDrive.Click += new System.EventHandler(this.tsmiReloadDeviceDrive_Click);
            // 
            // tsmiReloadGameListDisc
            // 
            resources.ApplyResources(this.tsmiReloadGameListDisc, "tsmiReloadGameListDisc");
            this.tsmiReloadGameListDisc.Name = "tsmiReloadGameListDisc";
            this.tsmiReloadGameListDisc.Click += new System.EventHandler(this.tsmiReloadGameListDisc_Click);
            // 
            // tsmiClearListDestination
            // 
            resources.ApplyResources(this.tsmiClearListDestination, "tsmiClearListDestination");
            this.tsmiClearListDestination.Name = "tsmiClearListDestination";
            this.tsmiClearListDestination.Click += new System.EventHandler(this.tsmiClearListDestination_Click);
            // 
            // tsmiSelectGameDisc
            // 
            resources.ApplyResources(this.tsmiSelectGameDisc, "tsmiSelectGameDisc");
            this.tsmiSelectGameDisc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameDiscSelectAll,
            this.tsmiGameDiscSelectNone});
            this.tsmiSelectGameDisc.Name = "tsmiSelectGameDisc";
            // 
            // tsmiGameDiscSelectAll
            // 
            resources.ApplyResources(this.tsmiGameDiscSelectAll, "tsmiGameDiscSelectAll");
            this.tsmiGameDiscSelectAll.Name = "tsmiGameDiscSelectAll";
            this.tsmiGameDiscSelectAll.Click += new System.EventHandler(this.tsmiGameSelectAll_Click);
            // 
            // tsmiGameDiscSelectNone
            // 
            resources.ApplyResources(this.tsmiGameDiscSelectNone, "tsmiGameDiscSelectNone");
            this.tsmiGameDiscSelectNone.Name = "tsmiGameDiscSelectNone";
            this.tsmiGameDiscSelectNone.Click += new System.EventHandler(this.tsmiGameSelectNone_Click);
            // 
            // tsmiRemoveGameDisc
            // 
            resources.ApplyResources(this.tsmiRemoveGameDisc, "tsmiRemoveGameDisc");
            this.tsmiRemoveGameDisc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameDiscDeleteAllFiles,
            this.tsmiGameDiscDeleteSelectedFile});
            this.tsmiRemoveGameDisc.Name = "tsmiRemoveGameDisc";
            // 
            // tsmiGameDiscDeleteAllFiles
            // 
            resources.ApplyResources(this.tsmiGameDiscDeleteAllFiles, "tsmiGameDiscDeleteAllFiles");
            this.tsmiGameDiscDeleteAllFiles.Name = "tsmiGameDiscDeleteAllFiles";
            this.tsmiGameDiscDeleteAllFiles.Click += new System.EventHandler(this.tsmiGameDiscDeleteAllFiles_Click);
            // 
            // tsmiGameDiscDeleteSelectedFile
            // 
            resources.ApplyResources(this.tsmiGameDiscDeleteSelectedFile, "tsmiGameDiscDeleteSelectedFile");
            this.tsmiGameDiscDeleteSelectedFile.Name = "tsmiGameDiscDeleteSelectedFile";
            this.tsmiGameDiscDeleteSelectedFile.Click += new System.EventHandler(this.tsmiDeleteSelectedFileDisc_Click);
            // 
            // tsmiToolsGameDisc
            // 
            resources.ApplyResources(this.tsmiToolsGameDisc, "tsmiToolsGameDisc");
            this.tsmiToolsGameDisc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameDiscExportList,
            this.toolStripMenuItem3,
            this.tsmiGameDiscSignatureSHA1,
            this.tsmiGameDiscSignatureMD5});
            this.tsmiToolsGameDisc.Name = "tsmiToolsGameDisc";
            // 
            // tsmiGameDiscExportList
            // 
            resources.ApplyResources(this.tsmiGameDiscExportList, "tsmiGameDiscExportList");
            this.tsmiGameDiscExportList.Name = "tsmiGameDiscExportList";
            // 
            // toolStripMenuItem3
            // 
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            // 
            // tsmiGameDiscSignatureSHA1
            // 
            resources.ApplyResources(this.tsmiGameDiscSignatureSHA1, "tsmiGameDiscSignatureSHA1");
            this.tsmiGameDiscSignatureSHA1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameDiscAllHashSHA1,
            this.tsmiGameDiscHashSHA1});
            this.tsmiGameDiscSignatureSHA1.Name = "tsmiGameDiscSignatureSHA1";
            // 
            // tsmiGameDiscAllHashSHA1
            // 
            resources.ApplyResources(this.tsmiGameDiscAllHashSHA1, "tsmiGameDiscAllHashSHA1");
            this.tsmiGameDiscAllHashSHA1.Name = "tsmiGameDiscAllHashSHA1";
            // 
            // tsmiGameDiscHashSHA1
            // 
            resources.ApplyResources(this.tsmiGameDiscHashSHA1, "tsmiGameDiscHashSHA1");
            this.tsmiGameDiscHashSHA1.Name = "tsmiGameDiscHashSHA1";
            this.tsmiGameDiscHashSHA1.Click += new System.EventHandler(this.tsmiGameDiscHashSHA1_Click);
            // 
            // tsmiGameDiscSignatureMD5
            // 
            resources.ApplyResources(this.tsmiGameDiscSignatureMD5, "tsmiGameDiscSignatureMD5");
            this.tsmiGameDiscSignatureMD5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameDiscAllHashMD5,
            this.tsmiGameDiscHashMD5,
            this.toolStripMenuItem4,
            this.tsmiGameDiscRecalculateAllMD5,
            this.tsmiGameDiscRecalculateSelectedGameMD5});
            this.tsmiGameDiscSignatureMD5.Name = "tsmiGameDiscSignatureMD5";
            // 
            // tsmiGameDiscAllHashMD5
            // 
            resources.ApplyResources(this.tsmiGameDiscAllHashMD5, "tsmiGameDiscAllHashMD5");
            this.tsmiGameDiscAllHashMD5.Name = "tsmiGameDiscAllHashMD5";
            // 
            // tsmiGameDiscHashMD5
            // 
            resources.ApplyResources(this.tsmiGameDiscHashMD5, "tsmiGameDiscHashMD5");
            this.tsmiGameDiscHashMD5.Name = "tsmiGameDiscHashMD5";
            this.tsmiGameDiscHashMD5.Click += new System.EventHandler(this.tsmiGameDiscHashMD5_Click);
            // 
            // toolStripMenuItem4
            // 
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            // 
            // tsmiGameDiscRecalculateAllMD5
            // 
            resources.ApplyResources(this.tsmiGameDiscRecalculateAllMD5, "tsmiGameDiscRecalculateAllMD5");
            this.tsmiGameDiscRecalculateAllMD5.Name = "tsmiGameDiscRecalculateAllMD5";
            // 
            // tsmiGameDiscRecalculateSelectedGameMD5
            // 
            resources.ApplyResources(this.tsmiGameDiscRecalculateSelectedGameMD5, "tsmiGameDiscRecalculateSelectedGameMD5");
            this.tsmiGameDiscRecalculateSelectedGameMD5.Name = "tsmiGameDiscRecalculateSelectedGameMD5";
            // 
            // tabMainDatabase
            // 
            resources.ApplyResources(this.tabMainDatabase, "tabMainDatabase");
            this.tabMainDatabase.Controls.Add(this.lblDatabaseTotal);
            this.tabMainDatabase.Controls.Add(this.cbFilterDatabase);
            this.tabMainDatabase.Controls.Add(this.label7);
            this.tabMainDatabase.Controls.Add(this.lvDatabase);
            this.tabMainDatabase.Controls.Add(this.mstripDatabase);
            this.tabMainDatabase.Name = "tabMainDatabase";
            this.tabMainDatabase.UseVisualStyleBackColor = true;
            // 
            // lblDatabaseTotal
            // 
            resources.ApplyResources(this.lblDatabaseTotal, "lblDatabaseTotal");
            this.lblDatabaseTotal.Name = "lblDatabaseTotal";
            // 
            // cbFilterDatabase
            // 
            resources.ApplyResources(this.cbFilterDatabase, "cbFilterDatabase");
            this.cbFilterDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterDatabase.FormattingEnabled = true;
            this.cbFilterDatabase.Items.AddRange(new object[] {
            resources.GetString("cbFilterDatabase.Items"),
            resources.GetString("cbFilterDatabase.Items1"),
            resources.GetString("cbFilterDatabase.Items2"),
            resources.GetString("cbFilterDatabase.Items3"),
            resources.GetString("cbFilterDatabase.Items4"),
            resources.GetString("cbFilterDatabase.Items5"),
            resources.GetString("cbFilterDatabase.Items6"),
            resources.GetString("cbFilterDatabase.Items7"),
            resources.GetString("cbFilterDatabase.Items8"),
            resources.GetString("cbFilterDatabase.Items9"),
            resources.GetString("cbFilterDatabase.Items10"),
            resources.GetString("cbFilterDatabase.Items11"),
            resources.GetString("cbFilterDatabase.Items12"),
            resources.GetString("cbFilterDatabase.Items13"),
            resources.GetString("cbFilterDatabase.Items14")});
            this.cbFilterDatabase.Name = "cbFilterDatabase";
            this.cbFilterDatabase.SelectedIndexChanged += new System.EventHandler(this.cbFilterDatabase_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lvDatabase
            // 
            resources.ApplyResources(this.lvDatabase, "lvDatabase");
            this.lvDatabase.ForeColor = System.Drawing.Color.Blue;
            this.lvDatabase.HideSelection = false;
            this.lvDatabase.Name = "lvDatabase";
            this.lvDatabase.UseCompatibleStateImageBehavior = false;
            this.lvDatabase.Click += new System.EventHandler(this.lvDatabase_Click);
            // 
            // mstripDatabase
            // 
            resources.ApplyResources(this.mstripDatabase, "mstripDatabase");
            this.mstripDatabase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiToolDatabase});
            this.mstripDatabase.Name = "mstripDatabase";
            // 
            // tsmiToolDatabase
            // 
            resources.ApplyResources(this.tsmiToolDatabase, "tsmiToolDatabase");
            this.tsmiToolDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDatabaseUpdateGameTDB});
            this.tsmiToolDatabase.Name = "tsmiToolDatabase";
            // 
            // tsmiDatabaseUpdateGameTDB
            // 
            resources.ApplyResources(this.tsmiDatabaseUpdateGameTDB, "tsmiDatabaseUpdateGameTDB");
            this.tsmiDatabaseUpdateGameTDB.Name = "tsmiDatabaseUpdateGameTDB";
            this.tsmiDatabaseUpdateGameTDB.Click += new System.EventHandler(this.tsmiDatabaseUpdateGameTDB_Click);
            // 
            // tabMainLog
            // 
            resources.ApplyResources(this.tabMainLog, "tabMainLog");
            this.tabMainLog.Controls.Add(this.tbLog);
            this.tabMainLog.Controls.Add(this.mstripLog);
            this.tabMainLog.Name = "tabMainLog";
            this.tabMainLog.UseVisualStyleBackColor = true;
            // 
            // tbLog
            // 
            resources.ApplyResources(this.tbLog, "tbLog");
            this.tbLog.BackColor = System.Drawing.Color.White;
            this.tbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLog.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // mstripLog
            // 
            resources.ApplyResources(this.mstripLog, "mstripLog");
            this.mstripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiToolLog});
            this.mstripLog.Name = "mstripLog";
            // 
            // tsmiToolLog
            // 
            resources.ApplyResources(this.tsmiToolLog, "tsmiToolLog");
            this.tsmiToolLog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClearLog,
            this.toolStripMenuItem2,
            this.tsmiExportLog});
            this.tsmiToolLog.Name = "tsmiToolLog";
            // 
            // tsmiClearLog
            // 
            resources.ApplyResources(this.tsmiClearLog, "tsmiClearLog");
            this.tsmiClearLog.Name = "tsmiClearLog";
            this.tsmiClearLog.Click += new System.EventHandler(this.tsmiClearLog_Click);
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // tsmiExportLog
            // 
            resources.ApplyResources(this.tsmiExportLog, "tsmiExportLog");
            this.tsmiExportLog.Name = "tsmiExportLog";
            this.tsmiExportLog.Click += new System.EventHandler(this.tsmiExportLog_Click);
            // 
            // sstripMain
            // 
            resources.ApplyResources(this.sstripMain, "sstripMain");
            this.sstripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCurrentYear,
            this.lblScan});
            this.sstripMain.Name = "sstripMain";
            this.sstripMain.SizingGrip = false;
            // 
            // tsslCurrentYear
            // 
            resources.ApplyResources(this.tsslCurrentYear, "tsslCurrentYear");
            this.tsslCurrentYear.Name = "tsslCurrentYear";
            // 
            // lblScan
            // 
            resources.ApplyResources(this.lblScan, "lblScan");
            this.lblScan.Name = "lblScan";
            // 
            // mstripMain
            // 
            resources.ApplyResources(this.mstripMain, "mstripMain");
            this.mstripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiCovers,
            this.tsmiDisplay,
            this.tsmiOptions,
            this.tsmiTools,
            this.tsmiHelp});
            this.mstripMain.Name = "mstripMain";
            // 
            // tsmiFile
            // 
            resources.ApplyResources(this.tsmiFile, "tsmiFile");
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            // 
            // tsmiExit
            // 
            resources.ApplyResources(this.tsmiExit, "tsmiExit");
            this.tsmiExit.Image = global::GCBM.Properties.Resources.exit;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiCovers
            // 
            resources.ApplyResources(this.tsmiCovers, "tsmiCovers");
            this.tsmiCovers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDownloadCoversSelectedGame,
            this.tsmiSyncDownloadDiscOnly3DCovers,
            this.toolStripMenuItem5,
            this.tsmiSyncDownloadAllDiscOnly3DCovers,
            this.tsmiSyncDownloadAllCovers,
            this.toolStripMenuItem6,
            this.tsmiTransferDeviceCovers});
            this.tsmiCovers.Name = "tsmiCovers";
            // 
            // tsmiDownloadCoversSelectedGame
            // 
            resources.ApplyResources(this.tsmiDownloadCoversSelectedGame, "tsmiDownloadCoversSelectedGame");
            this.tsmiDownloadCoversSelectedGame.Image = global::GCBM.Properties.Resources.sync_16;
            this.tsmiDownloadCoversSelectedGame.Name = "tsmiDownloadCoversSelectedGame";
            this.tsmiDownloadCoversSelectedGame.Click += new System.EventHandler(this.tsmiDownloadCoversSelectedGame_Click);
            // 
            // tsmiSyncDownloadDiscOnly3DCovers
            // 
            resources.ApplyResources(this.tsmiSyncDownloadDiscOnly3DCovers, "tsmiSyncDownloadDiscOnly3DCovers");
            this.tsmiSyncDownloadDiscOnly3DCovers.Image = global::GCBM.Properties.Resources.sync_16;
            this.tsmiSyncDownloadDiscOnly3DCovers.Name = "tsmiSyncDownloadDiscOnly3DCovers";
            this.tsmiSyncDownloadDiscOnly3DCovers.Click += new System.EventHandler(this.tsmiSyncDownloadDiscOnly3DCovers_Click);
            // 
            // toolStripMenuItem5
            // 
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            // 
            // tsmiSyncDownloadAllDiscOnly3DCovers
            // 
            resources.ApplyResources(this.tsmiSyncDownloadAllDiscOnly3DCovers, "tsmiSyncDownloadAllDiscOnly3DCovers");
            this.tsmiSyncDownloadAllDiscOnly3DCovers.Name = "tsmiSyncDownloadAllDiscOnly3DCovers";
            // 
            // tsmiSyncDownloadAllCovers
            // 
            resources.ApplyResources(this.tsmiSyncDownloadAllCovers, "tsmiSyncDownloadAllCovers");
            this.tsmiSyncDownloadAllCovers.Name = "tsmiSyncDownloadAllCovers";
            // 
            // toolStripMenuItem6
            // 
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            // 
            // tsmiTransferDeviceCovers
            // 
            resources.ApplyResources(this.tsmiTransferDeviceCovers, "tsmiTransferDeviceCovers");
            this.tsmiTransferDeviceCovers.Image = global::GCBM.Properties.Resources.transfer_0002;
            this.tsmiTransferDeviceCovers.Name = "tsmiTransferDeviceCovers";
            this.tsmiTransferDeviceCovers.Click += new System.EventHandler(this.tsmiTransferDeviceCovers_Click);
            // 
            // tsmiDisplay
            // 
            resources.ApplyResources(this.tsmiDisplay, "tsmiDisplay");
            this.tsmiDisplay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameInfo,
            this.boxArtToolStripMenuItem});
            this.tsmiDisplay.Name = "tsmiDisplay";
            // 
            // tsmiGameInfo
            // 
            resources.ApplyResources(this.tsmiGameInfo, "tsmiGameInfo");
            this.tsmiGameInfo.Image = global::GCBM.Properties.Resources.additional_information_16;
            this.tsmiGameInfo.Name = "tsmiGameInfo";
            this.tsmiGameInfo.Click += new System.EventHandler(this.tsmiGameInfo_Click);
            // 
            // boxArtToolStripMenuItem
            // 
            resources.ApplyResources(this.boxArtToolStripMenuItem, "boxArtToolStripMenuItem");
            this.boxArtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEnableCoverPanel,
            this.tsmiDisableCoverPanel});
            this.boxArtToolStripMenuItem.Name = "boxArtToolStripMenuItem";
            // 
            // tsmiEnableCoverPanel
            // 
            resources.ApplyResources(this.tsmiEnableCoverPanel, "tsmiEnableCoverPanel");
            this.tsmiEnableCoverPanel.Checked = true;
            this.tsmiEnableCoverPanel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiEnableCoverPanel.Name = "tsmiEnableCoverPanel";
            this.tsmiEnableCoverPanel.Click += new System.EventHandler(this.tsmiEnableCoverPanel_Click);
            // 
            // tsmiDisableCoverPanel
            // 
            resources.ApplyResources(this.tsmiDisableCoverPanel, "tsmiDisableCoverPanel");
            this.tsmiDisableCoverPanel.Name = "tsmiDisableCoverPanel";
            this.tsmiDisableCoverPanel.Click += new System.EventHandler(this.tsmiDisableCoverPanel_Click);
            // 
            // tsmiOptions
            // 
            resources.ApplyResources(this.tsmiOptions, "tsmiOptions");
            this.tsmiOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConfigurationMain});
            this.tsmiOptions.Name = "tsmiOptions";
            // 
            // tsmiConfigurationMain
            // 
            resources.ApplyResources(this.tsmiConfigurationMain, "tsmiConfigurationMain");
            this.tsmiConfigurationMain.Name = "tsmiConfigurationMain";
            this.tsmiConfigurationMain.Click += new System.EventHandler(this.tsmiConfigurationMain_Click);
            // 
            // tsmiTools
            // 
            resources.ApplyResources(this.tsmiTools, "tsmiTools");
            this.tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRenameFolders,
            this.tsmiRenameISO,
            this.tsmiMainPlugins,
            this.toolStripMenuItem11});
            this.tsmiTools.Name = "tsmiTools";
            // 
            // tsmiRenameFolders
            // 
            resources.ApplyResources(this.tsmiRenameFolders, "tsmiRenameFolders");
            this.tsmiRenameFolders.Name = "tsmiRenameFolders";
            // 
            // tsmiRenameISO
            // 
            resources.ApplyResources(this.tsmiRenameISO, "tsmiRenameISO");
            this.tsmiRenameISO.Name = "tsmiRenameISO";
            this.tsmiRenameISO.Click += new System.EventHandler(this.tsmiRenameISO_Click);
            // 
            // tsmiMainPlugins
            // 
            resources.ApplyResources(this.tsmiMainPlugins, "tsmiMainPlugins");
            this.tsmiMainPlugins.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMetaXml,
            this.tsmiManageApp,
            this.tsmiElfDol,
            this.tsmiCreatePackage,
            this.tsmiBurnMedia});
            this.tsmiMainPlugins.Name = "tsmiMainPlugins";
            // 
            // tsmiMetaXml
            // 
            resources.ApplyResources(this.tsmiMetaXml, "tsmiMetaXml");
            this.tsmiMetaXml.Name = "tsmiMetaXml";
            this.tsmiMetaXml.Click += new System.EventHandler(this.tsmiMetaXml_Click);
            // 
            // tsmiManageApp
            // 
            resources.ApplyResources(this.tsmiManageApp, "tsmiManageApp");
            this.tsmiManageApp.Name = "tsmiManageApp";
            this.tsmiManageApp.Click += new System.EventHandler(this.tsmiManageApp_Click);
            // 
            // tsmiElfDol
            // 
            resources.ApplyResources(this.tsmiElfDol, "tsmiElfDol");
            this.tsmiElfDol.Image = global::GCBM.Properties.Resources.convert_16;
            this.tsmiElfDol.Name = "tsmiElfDol";
            this.tsmiElfDol.Click += new System.EventHandler(this.tsmiElfDol_Click);
            // 
            // tsmiCreatePackage
            // 
            resources.ApplyResources(this.tsmiCreatePackage, "tsmiCreatePackage");
            this.tsmiCreatePackage.Image = global::GCBM.Properties.Resources.box_16;
            this.tsmiCreatePackage.Name = "tsmiCreatePackage";
            this.tsmiCreatePackage.Click += new System.EventHandler(this.tsmiCreatePackage_Click);
            // 
            // tsmiBurnMedia
            // 
            resources.ApplyResources(this.tsmiBurnMedia, "tsmiBurnMedia");
            this.tsmiBurnMedia.Image = global::GCBM.Properties.Resources.burn_cd_16;
            this.tsmiBurnMedia.Name = "tsmiBurnMedia";
            this.tsmiBurnMedia.Click += new System.EventHandler(this.tsmiBurnMedia_Click);
            // 
            // toolStripMenuItem11
            // 
            resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.tsmiDatabaseUpdateGameTDB_Click);
            // 
            // tsmiHelp
            // 
            resources.ApplyResources(this.tsmiHelp, "tsmiHelp");
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiWebsiteFacebook,
            this.tsmiOfficialGitHub,
            this.tsmiOfficialGBATemp,
            this.toolStripMenuItem7,
            this.tsmiVerifyUpdate,
            this.toolStripMenuItem1,
            this.tsmiMenuAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            // 
            // tsmiWebsiteFacebook
            // 
            resources.ApplyResources(this.tsmiWebsiteFacebook, "tsmiWebsiteFacebook");
            this.tsmiWebsiteFacebook.Name = "tsmiWebsiteFacebook";
            this.tsmiWebsiteFacebook.Click += new System.EventHandler(this.tsmiWebsiteFacebook_Click);
            // 
            // tsmiOfficialGitHub
            // 
            resources.ApplyResources(this.tsmiOfficialGitHub, "tsmiOfficialGitHub");
            this.tsmiOfficialGitHub.Name = "tsmiOfficialGitHub";
            this.tsmiOfficialGitHub.Click += new System.EventHandler(this.tsmiOfficialGitHub_Click);
            // 
            // tsmiOfficialGBATemp
            // 
            resources.ApplyResources(this.tsmiOfficialGBATemp, "tsmiOfficialGBATemp");
            this.tsmiOfficialGBATemp.Name = "tsmiOfficialGBATemp";
            this.tsmiOfficialGBATemp.Click += new System.EventHandler(this.tsmiOfficialGBATemp_Click);
            // 
            // toolStripMenuItem7
            // 
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            // 
            // tsmiVerifyUpdate
            // 
            resources.ApplyResources(this.tsmiVerifyUpdate, "tsmiVerifyUpdate");
            this.tsmiVerifyUpdate.Image = global::GCBM.Properties.Resources.update_16;
            this.tsmiVerifyUpdate.Name = "tsmiVerifyUpdate";
            this.tsmiVerifyUpdate.Click += new System.EventHandler(this.tsmiVerifyUpdate_Click);
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // tsmiMenuAbout
            // 
            resources.ApplyResources(this.tsmiMenuAbout, "tsmiMenuAbout");
            this.tsmiMenuAbout.Image = global::GCBM.Properties.Resources.info_16;
            this.tsmiMenuAbout.Name = "tsmiMenuAbout";
            this.tsmiMenuAbout.Click += new System.EventHandler(this.tsmiMenuAbout_Click);
            // 
            // fbd1
            // 
            resources.ApplyResources(this.fbd1, "fbd1");
            this.fbd1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // fbd2
            // 
            resources.ApplyResources(this.fbd2, "fbd2");
            this.fbd2.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ofd1
            // 
            resources.ApplyResources(this.ofd1, "ofd1");
            // 
            // lblNetStatus
            // 
            resources.ApplyResources(this.lblNetStatus, "lblNetStatus");
            this.lblNetStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNetStatus.Name = "lblNetStatus";
            this.lblNetStatus.Click += new System.EventHandler(this.lblNetStatus_Click);
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.ContextMenuStrip = this.cmsNotifyIcon;
            // 
            // cmsNotifyIcon
            // 
            resources.ApplyResources(this.cmsNotifyIcon, "cmsNotifyIcon");
            this.cmsNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNotifyExit});
            this.cmsNotifyIcon.Name = "cmsNotifyIcon";
            // 
            // tsmiNotifyExit
            // 
            resources.ApplyResources(this.tsmiNotifyExit, "tsmiNotifyExit");
            this.tsmiNotifyExit.Name = "tsmiNotifyExit";
            this.tsmiNotifyExit.Click += new System.EventHandler(this.tsmiNotifyExit_Click);
            // 
            // pbNetStatus
            // 
            resources.ApplyResources(this.pbNetStatus, "pbNetStatus");
            this.pbNetStatus.Name = "pbNetStatus";
            this.pbNetStatus.TabStop = false;
            this.pbNetStatus.Click += new System.EventHandler(this.lblNetStatus_Click);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbNetStatus);
            this.Controls.Add(this.lblNetStatus);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.sstripMain);
            this.Controls.Add(this.mstripMain);
            this.MainMenuStrip = this.mstripMain;
            this.Name = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameCover3D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameDisc)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabMainFile.ResumeLayout(false);
            this.tabMainFile.PerformLayout();
            this.grpDetailsSource.ResumeLayout(false);
            this.grpDetailsSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebGameID)).EndInit();
            this.grpOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).EndInit();
            this.cmsMain.ResumeLayout(false);
            this.mstripFile.ResumeLayout(false);
            this.mstripFile.PerformLayout();
            this.tabMainDisc.ResumeLayout(false);
            this.tabMainDisc.PerformLayout();
            this.grpDetailsDestiny.ResumeLayout(false);
            this.grpDetailsDestiny.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebGameDiscID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestination)).EndInit();
            this.mstripDisc.ResumeLayout(false);
            this.mstripDisc.PerformLayout();
            this.tabMainDatabase.ResumeLayout(false);
            this.tabMainDatabase.PerformLayout();
            this.mstripDatabase.ResumeLayout(false);
            this.mstripDatabase.PerformLayout();
            this.tabMainLog.ResumeLayout(false);
            this.tabMainLog.PerformLayout();
            this.mstripLog.ResumeLayout(false);
            this.mstripLog.PerformLayout();
            this.sstripMain.ResumeLayout(false);
            this.sstripMain.PerformLayout();
            this.mstripMain.ResumeLayout(false);
            this.mstripMain.PerformLayout();
            this.cmsNotifyIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNetStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip sstripMain;
        private MenuStrip mstripMain;
        private ToolStripMenuItem tsmiFile;
        private ToolStripMenuItem tsmiExit;
        private SplitContainer spcMain;
        private ToolStripMenuItem tsmiCovers;
        private ToolStripMenuItem tsmiDisplay;
        private ToolStripMenuItem tsmiOptions;
        private ToolStripMenuItem tsmiTools;
        private ToolStripMenuItem tsmiHelp;
        private ToolStripMenuItem tsmiDownloadCoversSelectedGame;
        private ToolStripMenuItem tsmiSyncDownloadDiscOnly3DCovers;
        private ToolStripMenuItem tsmiGameInfo;
        private ToolStripMenuItem boxArtToolStripMenuItem;
        private ToolStripMenuItem tsmiConfigurationMain;
        private ToolStripMenuItem tsmiMenuAbout;
        private ToolStripMenuItem tsmiEnableCoverPanel;
        private ToolStripMenuItem tsmiDisableCoverPanel;
        private GroupBox groupBox1;
        private PictureBox pbGameCover3D;
        private PictureBox pbGameDisc;
        private ToolStripStatusLabel tsslCurrentYear;
        private FolderBrowserDialog fbd1;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem tsmiSyncDownloadAllDiscOnly3DCovers;
        private ToolStripMenuItem tsmiSyncDownloadAllCovers;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem tsmiTransferDeviceCovers;
        private FolderBrowserDialog fbd2;
        private OpenFileDialog ofd1;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripMenuItem tsmiWebsiteFacebook;
        private Label lblNetStatus;
        private PictureBox pbNetStatus;
        private ToolStripMenuItem tsmiRenameISO;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip cmsNotifyIcon;
        private ToolStripMenuItem tsmiNotifyExit;
        private ContextMenuStrip cmsMain;
        private ToolStripMenuItem tsmiInfoGame;
        private ToolStripMenuItem tsmiVerifyUpdate;
        private ToolStripMenuItem tsmiMainPlugins;
        private ToolStripMenuItem tsmiMetaXml;
        private ToolStripMenuItem tsmiManageApp;
        private ToolStripMenuItem tsmiElfDol;
        private ToolStripMenuItem tsmiCreatePackage;
        private ToolStripMenuItem tsmiBurnMedia;
        private ToolStripMenuItem tsmiOfficialGitHub;
        private ToolStripMenuItem tsmiOfficialGBATemp;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripMenuItem tsmiSearchOnGoogle;
        private ToolStripMenuItem SearchOnWikipedia;
        private ToolStripMenuItem tsmiSearchOnYoutube;
        private ToolStripMenuItem tsmiSearchOnGameSpot;
        private ToolStripMenuItem tsmiSearchOnVGChartz;
        private ToolStripSeparator toolStripMenuItem9;
        private ToolStripMenuItem tsmiSearchOnGameTDB;
        private ToolStripSeparator toolStripMenuItem10;
        private ToolStripMenuItem tsmiDolphinEmulator;
        private TabControl tabControlMain;
        private TabPage tabMainFile;
        private Label lblInstallStatusText;
        private Label lblInstallStatusPercent;
        private Label lblInstallStatusGameTitle;
        private ProgressBar pbCopy;
        private Label label1;
        private Button btnSelectFolder;
        private GroupBox grpDetailsSource;
        private Label lblTypeDisc;
        private Label label34;
        private TextBox tbIDMakerCode;
        private TextBox tbIDDiscID;
        private Label label29;
        private PictureBox pbWebGameID;
        private GroupBox grpOperations;
        private Button btnGameInstallScrub;
        private Button btnGameInstallExactCopy;
        private Label labelGameID;
        private Label labelFile;
        private Label labelTitle;
        private TextBox tbIDGame;
        private TextBox tbIDRegion;
        private TextBox tbIDName;
        private DataGridView dgvSource;
        private MenuStrip mstripFile;
        private ToolStripMenuItem tsmiReloadGameList;
        private ToolStripMenuItem tsmiSelectGameList;
        private ToolStripMenuItem tsmiGameListSelectAll;
        private ToolStripMenuItem tsmiGameListSelectNone;
        private ToolStripMenuItem tsmiRemoveGameList;
        private ToolStripMenuItem tsmiGameListDeleteAllFiles;
        private ToolStripMenuItem tsmiGameListDeleteSelectedFile;
        private ToolStripMenuItem tsmiToolsGameList;
        private ToolStripMenuItem tsmiGameListSignatureSHA1;
        private ToolStripMenuItem tsmiGameListHashSHA1;
        private ToolStripMenuItem exportarListaToolStripMenuItem;
        private ToolStripMenuItem tsmiExportTXT;
        private ToolStripMenuItem tsmiExportHTML;
        private ToolStripMenuItem tsmiExportCSV;
        private TabPage tabMainDisc;
        private Label lblSpaceAvailabeOnDevice;
        private Label lblSpaceTotalOnDevice;
        private Label label3;
        private Label label2;
        private GroupBox grpDetailsDestiny;
        private PictureBox pbWebGameDiscID;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tbIDGameDisc;
        private TextBox tbIDRegionDisc;
        private TextBox tbIDNameDisc;
        private DataGridView dgvDestination;
        private MenuStrip mstripDisc;
        private ToolStripComboBox tscbDiscDrive;
        private ToolStripMenuItem tsmiReloadDeviceDrive;
        private ToolStripMenuItem tsmiReloadGameListDisc;
        private ToolStripMenuItem tsmiSelectGameDisc;
        private ToolStripMenuItem tsmiGameDiscSelectAll;
        private ToolStripMenuItem tsmiGameDiscSelectNone;
        private ToolStripMenuItem tsmiRemoveGameDisc;
        private ToolStripMenuItem tsmiGameDiscDeleteAllFiles;
        private ToolStripMenuItem tsmiGameDiscDeleteSelectedFile;
        private ToolStripMenuItem tsmiToolsGameDisc;
        private ToolStripMenuItem tsmiGameDiscExportList;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem tsmiGameDiscSignatureSHA1;
        private ToolStripMenuItem tsmiGameDiscAllHashSHA1;
        private ToolStripMenuItem tsmiGameDiscHashSHA1;
        private ToolStripMenuItem tsmiGameDiscSignatureMD5;
        private ToolStripMenuItem tsmiGameDiscAllHashMD5;
        private ToolStripMenuItem tsmiGameDiscHashMD5;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem tsmiGameDiscRecalculateAllMD5;
        private ToolStripMenuItem tsmiGameDiscRecalculateSelectedGameMD5;
        private TabPage tabMainDatabase;
        private Label lblDatabaseTotal;
        private ComboBox cbFilterDatabase;
        private Label label7;
        private ListView lvDatabase;
        private MenuStrip mstripDatabase;
        private ToolStripMenuItem tsmiToolDatabase;
        private ToolStripMenuItem tsmiDatabaseUpdateGameTDB;
        private TabPage tabMainLog;
        private TextBox tbLog;
        private MenuStrip mstripLog;
        private ToolStripMenuItem tsmiToolLog;
        private ToolStripMenuItem tsmiClearLog;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem tsmiExportLog;
        private ToolStripMenuItem tsmiRenameFolders;
        private BindingSource gameBindingSource;
        private DataGridViewCheckBoxColumn clmChk;
        private DataGridViewTextBoxColumn clmTitle;
        private DataGridViewTextBoxColumn clmRegion;
        private DataGridViewTextBoxColumn clmID;
        private DataGridViewTextBoxColumn clmExtension;
        private DataGridViewTextBoxColumn clmSize;
        private DataGridViewTextBoxColumn clmPath;
        private TextBox tbSearch;
        private Button btnSearch;
        private DataGridViewCheckBoxColumn dgvMainDiscCheck;
        private DataGridViewTextBoxColumn clmDiscTitle;
        private DataGridViewTextBoxColumn clmDiscID;
        private DataGridViewTextBoxColumn clmDiscRegion;
        private DataGridViewTextBoxColumn clmDiscExtension;
        private DataGridViewTextBoxColumn clmDiscSize;
        private DataGridViewTextBoxColumn clmDiscPath;
        private GroupBox grpSearch;
        private Process process1;
        private Button btnAbort;
        private Label lblAbort;
        private Label lblSourceCount;
        private Label lblGamesVerifiedText;
        private ToolStripStatusLabel lblScan;
        private Label lblDestinationCount;
        private Label label8;
        private Label lblAbortDestination;
        private ProgressBar pbDestination;
        private Button btnAbortDestination;
        private ToolStripMenuItem tsmiClearListSource;
        private ToolStripMenuItem tsmiClearListDestination;
        private ToolStripMenuItem toolStripMenuItem11;
        private ProgressBar pbSource;
        private Label lblInstallStatusGameIndex;
    }
}

