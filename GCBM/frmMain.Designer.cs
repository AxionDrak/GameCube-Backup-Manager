
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabMainFile = new System.Windows.Forms.TabPage();
            this.btnSearch = new System.Windows.Forms.Button();
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
            this.tbSearch = new System.Windows.Forms.TextBox();
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
            this.btnGameInstallScrub = new System.Windows.Forms.Button();
            this.btnGameInstallExactCopy = new System.Windows.Forms.Button();
            this.grpDetailsSource = new System.Windows.Forms.GroupBox();
            this.lblTypeDisc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbGameDisc = new System.Windows.Forms.PictureBox();
            this.pbGameCover3D = new System.Windows.Forms.PictureBox();
            this.tbIDName = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tbIDRegion = new System.Windows.Forms.TextBox();
            this.tbIDGame = new System.Windows.Forms.TextBox();
            this.tbIDMakerCode = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelGameID = new System.Windows.Forms.Label();
            this.tbIDDiscID = new System.Windows.Forms.TextBox();
            this.pbWebGameID = new System.Windows.Forms.PictureBox();
            this.label29 = new System.Windows.Forms.Label();
            this.grpOperations = new System.Windows.Forms.GroupBox();
            this.lblInstallStatusPercent = new System.Windows.Forms.Label();
            this.lblCurrentGameIndex = new System.Windows.Forms.Label();
            this.lblBrowse = new System.Windows.Forms.Label();
            this.lblSourceCount = new System.Windows.Forms.Label();
            this.pbSource = new System.Windows.Forms.ProgressBar();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lblSourceGameCount = new System.Windows.Forms.Label();
            this.btnAbort = new System.Windows.Forms.Button();
            this.pbCopy = new System.Windows.Forms.ProgressBar();
            this.lblInstallStatusText = new System.Windows.Forms.Label();
            this.lblCurrentGameTitle = new System.Windows.Forms.Label();
            this.cbNotificationToggle = new System.Windows.Forms.CheckBox();
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
            this.process1 = new System.Diagnostics.Process();
            this.gameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabMainFile.SuspendLayout();
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
            this.grpDetailsSource.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameDisc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameCover3D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebGameID)).BeginInit();
            this.grpOperations.SuspendLayout();
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
            this.spcMain.Panel1.Controls.Add(this.tabControlMain);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.btnGameInstallScrub);
            this.spcMain.Panel2.Controls.Add(this.btnGameInstallExactCopy);
            this.spcMain.Panel2.Controls.Add(this.grpDetailsSource);
            this.spcMain.Panel2.Controls.Add(this.grpOperations);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabMainFile);
            this.tabControlMain.Controls.Add(this.tabMainDisc);
            this.tabControlMain.Controls.Add(this.tabMainDatabase);
            this.tabControlMain.Controls.Add(this.tabMainLog);
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabMainFile
            // 
            this.tabMainFile.Controls.Add(this.btnSearch);
            this.tabMainFile.Controls.Add(this.dgvSource);
            this.tabMainFile.Controls.Add(this.tbSearch);
            this.tabMainFile.Controls.Add(this.mstripFile);
            resources.ApplyResources(this.tabMainFile, "tabMainFile");
            this.tabMainFile.Name = "tabMainFile";
            this.tabMainFile.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::GCBM.Properties.Resources.search_16;
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.Search_Click);
            this.btnSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnSearch_KeyPress);
            // 
            // dgvSource
            // 
            this.dgvSource.AllowUserToAddRows = false;
            this.dgvSource.AllowUserToDeleteRows = false;
            this.dgvSource.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgvSource, "dgvSource");
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
            resources.ApplyResources(this.cmsMain, "cmsMain");
            // 
            // tsmiInfoGame
            // 
            this.tsmiInfoGame.Name = "tsmiInfoGame";
            resources.ApplyResources(this.tsmiInfoGame, "tsmiInfoGame");
            this.tsmiInfoGame.Click += new System.EventHandler(this.tsmiInfoGame_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
            // 
            // tsmiDolphinEmulator
            // 
            this.tsmiDolphinEmulator.Name = "tsmiDolphinEmulator";
            resources.ApplyResources(this.tsmiDolphinEmulator, "tsmiDolphinEmulator");
            this.tsmiDolphinEmulator.Click += new System.EventHandler(this.tsmiDolphinEmulator_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            // 
            // tsmiSearchOnGameTDB
            // 
            this.tsmiSearchOnGameTDB.Name = "tsmiSearchOnGameTDB";
            resources.ApplyResources(this.tsmiSearchOnGameTDB, "tsmiSearchOnGameTDB");
            this.tsmiSearchOnGameTDB.Click += new System.EventHandler(this.tsmiSearchOnGameTDB_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
            // 
            // tsmiSearchOnGoogle
            // 
            this.tsmiSearchOnGoogle.Name = "tsmiSearchOnGoogle";
            resources.ApplyResources(this.tsmiSearchOnGoogle, "tsmiSearchOnGoogle");
            this.tsmiSearchOnGoogle.Click += new System.EventHandler(this.tsmiSearchOnGoogle_Click);
            // 
            // SearchOnWikipedia
            // 
            this.SearchOnWikipedia.Name = "SearchOnWikipedia";
            resources.ApplyResources(this.SearchOnWikipedia, "SearchOnWikipedia");
            this.SearchOnWikipedia.Click += new System.EventHandler(this.SearchOnWikipedia_Click);
            // 
            // tsmiSearchOnYoutube
            // 
            this.tsmiSearchOnYoutube.Name = "tsmiSearchOnYoutube";
            resources.ApplyResources(this.tsmiSearchOnYoutube, "tsmiSearchOnYoutube");
            this.tsmiSearchOnYoutube.Click += new System.EventHandler(this.tsmiSearchOnYoutube_Click);
            // 
            // tsmiSearchOnGameSpot
            // 
            this.tsmiSearchOnGameSpot.Name = "tsmiSearchOnGameSpot";
            resources.ApplyResources(this.tsmiSearchOnGameSpot, "tsmiSearchOnGameSpot");
            this.tsmiSearchOnGameSpot.Click += new System.EventHandler(this.tsmiSearchOnGameSpot_Click);
            // 
            // tsmiSearchOnVGChartz
            // 
            this.tsmiSearchOnVGChartz.Name = "tsmiSearchOnVGChartz";
            resources.ApplyResources(this.tsmiSearchOnVGChartz, "tsmiSearchOnVGChartz");
            this.tsmiSearchOnVGChartz.Click += new System.EventHandler(this.tsmiSearchOnVGChartz_Click);
            // 
            // tbSearch
            // 
            resources.ApplyResources(this.tbSearch, "tbSearch");
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.TextChanged += new System.EventHandler(this.Search_Click);
            // 
            // mstripFile
            // 
            this.mstripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReloadGameList,
            this.tsmiClearListSource,
            this.tsmiSelectGameList,
            this.tsmiRemoveGameList,
            this.tsmiToolsGameList});
            resources.ApplyResources(this.mstripFile, "mstripFile");
            this.mstripFile.Name = "mstripFile";
            // 
            // tsmiReloadGameList
            // 
            this.tsmiReloadGameList.Image = global::GCBM.Properties.Resources.refresh_32;
            this.tsmiReloadGameList.Name = "tsmiReloadGameList";
            resources.ApplyResources(this.tsmiReloadGameList, "tsmiReloadGameList");
            this.tsmiReloadGameList.Click += new System.EventHandler(this.tsmiReloadGameList_Click);
            // 
            // tsmiClearListSource
            // 
            this.tsmiClearListSource.Image = global::GCBM.Properties.Resources.Clear_icon;
            this.tsmiClearListSource.Name = "tsmiClearListSource";
            resources.ApplyResources(this.tsmiClearListSource, "tsmiClearListSource");
            this.tsmiClearListSource.Click += new System.EventHandler(this.tsmiClearListSource_Click);
            // 
            // tsmiSelectGameList
            // 
            this.tsmiSelectGameList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameListSelectAll,
            this.tsmiGameListSelectNone});
            this.tsmiSelectGameList.Image = global::GCBM.Properties.Resources.Cursor_Select_icon;
            this.tsmiSelectGameList.Name = "tsmiSelectGameList";
            resources.ApplyResources(this.tsmiSelectGameList, "tsmiSelectGameList");
            // 
            // tsmiGameListSelectAll
            // 
            this.tsmiGameListSelectAll.Name = "tsmiGameListSelectAll";
            resources.ApplyResources(this.tsmiGameListSelectAll, "tsmiGameListSelectAll");
            this.tsmiGameListSelectAll.Click += new System.EventHandler(this.tsmiGameSelectAll_Click);
            // 
            // tsmiGameListSelectNone
            // 
            this.tsmiGameListSelectNone.Name = "tsmiGameListSelectNone";
            resources.ApplyResources(this.tsmiGameListSelectNone, "tsmiGameListSelectNone");
            this.tsmiGameListSelectNone.Click += new System.EventHandler(this.tsmiGameSelectNone_Click);
            // 
            // tsmiRemoveGameList
            // 
            this.tsmiRemoveGameList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameListDeleteAllFiles,
            this.tsmiGameListDeleteSelectedFile});
            this.tsmiRemoveGameList.Image = global::GCBM.Properties.Resources.delete_16;
            this.tsmiRemoveGameList.Name = "tsmiRemoveGameList";
            resources.ApplyResources(this.tsmiRemoveGameList, "tsmiRemoveGameList");
            // 
            // tsmiGameListDeleteAllFiles
            // 
            this.tsmiGameListDeleteAllFiles.Name = "tsmiGameListDeleteAllFiles";
            resources.ApplyResources(this.tsmiGameListDeleteAllFiles, "tsmiGameListDeleteAllFiles");
            this.tsmiGameListDeleteAllFiles.Click += new System.EventHandler(this.tsmiGameListDeleteAllFiles_Click);
            // 
            // tsmiGameListDeleteSelectedFile
            // 
            this.tsmiGameListDeleteSelectedFile.Name = "tsmiGameListDeleteSelectedFile";
            resources.ApplyResources(this.tsmiGameListDeleteSelectedFile, "tsmiGameListDeleteSelectedFile");
            this.tsmiGameListDeleteSelectedFile.Click += new System.EventHandler(this.tsmiDeleteSelectedFile_Click);
            // 
            // tsmiToolsGameList
            // 
            this.tsmiToolsGameList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameListSignatureSHA1,
            this.exportarListaToolStripMenuItem});
            this.tsmiToolsGameList.Image = global::GCBM.Properties.Resources.Utilities_icon;
            this.tsmiToolsGameList.Name = "tsmiToolsGameList";
            resources.ApplyResources(this.tsmiToolsGameList, "tsmiToolsGameList");
            // 
            // tsmiGameListSignatureSHA1
            // 
            this.tsmiGameListSignatureSHA1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameListHashSHA1});
            this.tsmiGameListSignatureSHA1.Name = "tsmiGameListSignatureSHA1";
            resources.ApplyResources(this.tsmiGameListSignatureSHA1, "tsmiGameListSignatureSHA1");
            // 
            // tsmiGameListHashSHA1
            // 
            this.tsmiGameListHashSHA1.Image = global::GCBM.Properties.Resources.search_16;
            this.tsmiGameListHashSHA1.Name = "tsmiGameListHashSHA1";
            resources.ApplyResources(this.tsmiGameListHashSHA1, "tsmiGameListHashSHA1");
            this.tsmiGameListHashSHA1.Click += new System.EventHandler(this.tsmiGameHashSHA1_Click);
            // 
            // exportarListaToolStripMenuItem
            // 
            this.exportarListaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportTXT,
            this.tsmiExportHTML,
            this.tsmiExportCSV});
            this.exportarListaToolStripMenuItem.Name = "exportarListaToolStripMenuItem";
            resources.ApplyResources(this.exportarListaToolStripMenuItem, "exportarListaToolStripMenuItem");
            // 
            // tsmiExportTXT
            // 
            this.tsmiExportTXT.Image = global::GCBM.Properties.Resources.txt_16;
            this.tsmiExportTXT.Name = "tsmiExportTXT";
            resources.ApplyResources(this.tsmiExportTXT, "tsmiExportTXT");
            this.tsmiExportTXT.Click += new System.EventHandler(this.tsmiExportTXT_Click);
            // 
            // tsmiExportHTML
            // 
            this.tsmiExportHTML.Image = global::GCBM.Properties.Resources.html_16;
            this.tsmiExportHTML.Name = "tsmiExportHTML";
            resources.ApplyResources(this.tsmiExportHTML, "tsmiExportHTML");
            this.tsmiExportHTML.Click += new System.EventHandler(this.tsmiExportHTML_Click);
            // 
            // tsmiExportCSV
            // 
            this.tsmiExportCSV.Image = global::GCBM.Properties.Resources.csv_16;
            this.tsmiExportCSV.Name = "tsmiExportCSV";
            resources.ApplyResources(this.tsmiExportCSV, "tsmiExportCSV");
            this.tsmiExportCSV.Click += new System.EventHandler(this.tsmiExportCSV_Click);
            // 
            // tabMainDisc
            // 
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
            resources.ApplyResources(this.tabMainDisc, "tabMainDisc");
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
            this.btnAbortDestination.Image = global::GCBM.Properties.Resources.cancel_32;
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
            this.pbWebGameDiscID.Image = global::GCBM.Properties.Resources.globe_earth_grayscale_64;
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
            this.dgvDestination.AllowUserToAddRows = false;
            this.dgvDestination.AllowUserToDeleteRows = false;
            this.dgvDestination.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgvDestination, "dgvDestination");
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
            this.mstripDisc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbDiscDrive,
            this.tsmiReloadDeviceDrive,
            this.tsmiReloadGameListDisc,
            this.tsmiClearListDestination,
            this.tsmiSelectGameDisc,
            this.tsmiRemoveGameDisc,
            this.tsmiToolsGameDisc});
            resources.ApplyResources(this.mstripDisc, "mstripDisc");
            this.mstripDisc.Name = "mstripDisc";
            // 
            // tscbDiscDrive
            // 
            this.tscbDiscDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.tscbDiscDrive, "tscbDiscDrive");
            this.tscbDiscDrive.Items.AddRange(new object[] {
            resources.GetString("tscbDiscDrive.Items")});
            this.tscbDiscDrive.Name = "tscbDiscDrive";
            this.tscbDiscDrive.SelectedIndexChanged += new System.EventHandler(this.tscbDiscDrive_SelectedIndexChanged);
            // 
            // tsmiReloadDeviceDrive
            // 
            this.tsmiReloadDeviceDrive.Image = global::GCBM.Properties.Resources.refresh_32;
            this.tsmiReloadDeviceDrive.Name = "tsmiReloadDeviceDrive";
            resources.ApplyResources(this.tsmiReloadDeviceDrive, "tsmiReloadDeviceDrive");
            this.tsmiReloadDeviceDrive.Click += new System.EventHandler(this.tsmiReloadDeviceDrive_Click);
            // 
            // tsmiReloadGameListDisc
            // 
            this.tsmiReloadGameListDisc.Image = global::GCBM.Properties.Resources.refresh_32;
            this.tsmiReloadGameListDisc.Name = "tsmiReloadGameListDisc";
            resources.ApplyResources(this.tsmiReloadGameListDisc, "tsmiReloadGameListDisc");
            this.tsmiReloadGameListDisc.Click += new System.EventHandler(this.tsmiReloadGameListDisc_Click);
            // 
            // tsmiClearListDestination
            // 
            this.tsmiClearListDestination.Image = global::GCBM.Properties.Resources.Clear_icon;
            this.tsmiClearListDestination.Name = "tsmiClearListDestination";
            resources.ApplyResources(this.tsmiClearListDestination, "tsmiClearListDestination");
            this.tsmiClearListDestination.Click += new System.EventHandler(this.tsmiClearListDestination_Click);
            // 
            // tsmiSelectGameDisc
            // 
            this.tsmiSelectGameDisc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameDiscSelectAll,
            this.tsmiGameDiscSelectNone});
            this.tsmiSelectGameDisc.Image = global::GCBM.Properties.Resources.Cursor_Select_icon;
            this.tsmiSelectGameDisc.Name = "tsmiSelectGameDisc";
            resources.ApplyResources(this.tsmiSelectGameDisc, "tsmiSelectGameDisc");
            // 
            // tsmiGameDiscSelectAll
            // 
            this.tsmiGameDiscSelectAll.Name = "tsmiGameDiscSelectAll";
            resources.ApplyResources(this.tsmiGameDiscSelectAll, "tsmiGameDiscSelectAll");
            this.tsmiGameDiscSelectAll.Click += new System.EventHandler(this.tsmiGameSelectAll_Click);
            // 
            // tsmiGameDiscSelectNone
            // 
            this.tsmiGameDiscSelectNone.Name = "tsmiGameDiscSelectNone";
            resources.ApplyResources(this.tsmiGameDiscSelectNone, "tsmiGameDiscSelectNone");
            this.tsmiGameDiscSelectNone.Click += new System.EventHandler(this.tsmiGameSelectNone_Click);
            // 
            // tsmiRemoveGameDisc
            // 
            this.tsmiRemoveGameDisc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameDiscDeleteAllFiles,
            this.tsmiGameDiscDeleteSelectedFile});
            this.tsmiRemoveGameDisc.Image = global::GCBM.Properties.Resources.delete_16;
            this.tsmiRemoveGameDisc.Name = "tsmiRemoveGameDisc";
            resources.ApplyResources(this.tsmiRemoveGameDisc, "tsmiRemoveGameDisc");
            // 
            // tsmiGameDiscDeleteAllFiles
            // 
            this.tsmiGameDiscDeleteAllFiles.Name = "tsmiGameDiscDeleteAllFiles";
            resources.ApplyResources(this.tsmiGameDiscDeleteAllFiles, "tsmiGameDiscDeleteAllFiles");
            this.tsmiGameDiscDeleteAllFiles.Click += new System.EventHandler(this.tsmiGameDiscDeleteAllFiles_Click);
            // 
            // tsmiGameDiscDeleteSelectedFile
            // 
            this.tsmiGameDiscDeleteSelectedFile.Name = "tsmiGameDiscDeleteSelectedFile";
            resources.ApplyResources(this.tsmiGameDiscDeleteSelectedFile, "tsmiGameDiscDeleteSelectedFile");
            this.tsmiGameDiscDeleteSelectedFile.Click += new System.EventHandler(this.tsmiDeleteSelectedFileDisc_Click);
            // 
            // tsmiToolsGameDisc
            // 
            this.tsmiToolsGameDisc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameDiscExportList,
            this.toolStripMenuItem3,
            this.tsmiGameDiscSignatureSHA1,
            this.tsmiGameDiscSignatureMD5});
            this.tsmiToolsGameDisc.Image = global::GCBM.Properties.Resources.Utilities_icon;
            this.tsmiToolsGameDisc.Name = "tsmiToolsGameDisc";
            resources.ApplyResources(this.tsmiToolsGameDisc, "tsmiToolsGameDisc");
            // 
            // tsmiGameDiscExportList
            // 
            resources.ApplyResources(this.tsmiGameDiscExportList, "tsmiGameDiscExportList");
            this.tsmiGameDiscExportList.Name = "tsmiGameDiscExportList";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // tsmiGameDiscSignatureSHA1
            // 
            this.tsmiGameDiscSignatureSHA1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameDiscAllHashSHA1,
            this.tsmiGameDiscHashSHA1});
            this.tsmiGameDiscSignatureSHA1.Name = "tsmiGameDiscSignatureSHA1";
            resources.ApplyResources(this.tsmiGameDiscSignatureSHA1, "tsmiGameDiscSignatureSHA1");
            // 
            // tsmiGameDiscAllHashSHA1
            // 
            this.tsmiGameDiscAllHashSHA1.Image = global::GCBM.Properties.Resources.search_16;
            this.tsmiGameDiscAllHashSHA1.Name = "tsmiGameDiscAllHashSHA1";
            resources.ApplyResources(this.tsmiGameDiscAllHashSHA1, "tsmiGameDiscAllHashSHA1");
            // 
            // tsmiGameDiscHashSHA1
            // 
            this.tsmiGameDiscHashSHA1.Image = global::GCBM.Properties.Resources.search_16;
            this.tsmiGameDiscHashSHA1.Name = "tsmiGameDiscHashSHA1";
            resources.ApplyResources(this.tsmiGameDiscHashSHA1, "tsmiGameDiscHashSHA1");
            this.tsmiGameDiscHashSHA1.Click += new System.EventHandler(this.tsmiGameDiscHashSHA1_Click);
            // 
            // tsmiGameDiscSignatureMD5
            // 
            this.tsmiGameDiscSignatureMD5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameDiscAllHashMD5,
            this.tsmiGameDiscHashMD5,
            this.toolStripMenuItem4,
            this.tsmiGameDiscRecalculateAllMD5,
            this.tsmiGameDiscRecalculateSelectedGameMD5});
            this.tsmiGameDiscSignatureMD5.Name = "tsmiGameDiscSignatureMD5";
            resources.ApplyResources(this.tsmiGameDiscSignatureMD5, "tsmiGameDiscSignatureMD5");
            // 
            // tsmiGameDiscAllHashMD5
            // 
            this.tsmiGameDiscAllHashMD5.Image = global::GCBM.Properties.Resources.search_16;
            this.tsmiGameDiscAllHashMD5.Name = "tsmiGameDiscAllHashMD5";
            resources.ApplyResources(this.tsmiGameDiscAllHashMD5, "tsmiGameDiscAllHashMD5");
            // 
            // tsmiGameDiscHashMD5
            // 
            this.tsmiGameDiscHashMD5.Image = global::GCBM.Properties.Resources.search_16;
            this.tsmiGameDiscHashMD5.Name = "tsmiGameDiscHashMD5";
            resources.ApplyResources(this.tsmiGameDiscHashMD5, "tsmiGameDiscHashMD5");
            this.tsmiGameDiscHashMD5.Click += new System.EventHandler(this.tsmiGameDiscHashMD5_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // tsmiGameDiscRecalculateAllMD5
            // 
            this.tsmiGameDiscRecalculateAllMD5.Image = global::GCBM.Properties.Resources.hash_16;
            this.tsmiGameDiscRecalculateAllMD5.Name = "tsmiGameDiscRecalculateAllMD5";
            resources.ApplyResources(this.tsmiGameDiscRecalculateAllMD5, "tsmiGameDiscRecalculateAllMD5");
            // 
            // tsmiGameDiscRecalculateSelectedGameMD5
            // 
            this.tsmiGameDiscRecalculateSelectedGameMD5.Image = global::GCBM.Properties.Resources.hash_16;
            this.tsmiGameDiscRecalculateSelectedGameMD5.Name = "tsmiGameDiscRecalculateSelectedGameMD5";
            resources.ApplyResources(this.tsmiGameDiscRecalculateSelectedGameMD5, "tsmiGameDiscRecalculateSelectedGameMD5");
            // 
            // tabMainDatabase
            // 
            this.tabMainDatabase.Controls.Add(this.lblDatabaseTotal);
            this.tabMainDatabase.Controls.Add(this.cbFilterDatabase);
            this.tabMainDatabase.Controls.Add(this.label7);
            this.tabMainDatabase.Controls.Add(this.lvDatabase);
            this.tabMainDatabase.Controls.Add(this.mstripDatabase);
            resources.ApplyResources(this.tabMainDatabase, "tabMainDatabase");
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
            this.mstripDatabase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiToolDatabase});
            resources.ApplyResources(this.mstripDatabase, "mstripDatabase");
            this.mstripDatabase.Name = "mstripDatabase";
            // 
            // tsmiToolDatabase
            // 
            this.tsmiToolDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDatabaseUpdateGameTDB});
            this.tsmiToolDatabase.Name = "tsmiToolDatabase";
            resources.ApplyResources(this.tsmiToolDatabase, "tsmiToolDatabase");
            // 
            // tsmiDatabaseUpdateGameTDB
            // 
            this.tsmiDatabaseUpdateGameTDB.Image = global::GCBM.Properties.Resources.Misc_Download_Database_icon;
            this.tsmiDatabaseUpdateGameTDB.Name = "tsmiDatabaseUpdateGameTDB";
            resources.ApplyResources(this.tsmiDatabaseUpdateGameTDB, "tsmiDatabaseUpdateGameTDB");
            this.tsmiDatabaseUpdateGameTDB.Click += new System.EventHandler(this.tsmiDatabaseUpdateGameTDB_Click);
            // 
            // tabMainLog
            // 
            this.tabMainLog.Controls.Add(this.tbLog);
            this.tabMainLog.Controls.Add(this.mstripLog);
            resources.ApplyResources(this.tabMainLog, "tabMainLog");
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
            this.mstripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiToolLog});
            resources.ApplyResources(this.mstripLog, "mstripLog");
            this.mstripLog.Name = "mstripLog";
            // 
            // tsmiToolLog
            // 
            this.tsmiToolLog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClearLog,
            this.toolStripMenuItem2,
            this.tsmiExportLog});
            this.tsmiToolLog.Name = "tsmiToolLog";
            resources.ApplyResources(this.tsmiToolLog, "tsmiToolLog");
            // 
            // tsmiClearLog
            // 
            this.tsmiClearLog.Name = "tsmiClearLog";
            resources.ApplyResources(this.tsmiClearLog, "tsmiClearLog");
            this.tsmiClearLog.Click += new System.EventHandler(this.tsmiClearLog_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // tsmiExportLog
            // 
            this.tsmiExportLog.Name = "tsmiExportLog";
            resources.ApplyResources(this.tsmiExportLog, "tsmiExportLog");
            this.tsmiExportLog.Click += new System.EventHandler(this.tsmiExportLog_Click);
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
            // grpDetailsSource
            // 
            resources.ApplyResources(this.grpDetailsSource, "grpDetailsSource");
            this.grpDetailsSource.Controls.Add(this.lblTypeDisc);
            this.grpDetailsSource.Controls.Add(this.groupBox1);
            this.grpDetailsSource.Controls.Add(this.tbIDName);
            this.grpDetailsSource.Controls.Add(this.label34);
            this.grpDetailsSource.Controls.Add(this.tbIDRegion);
            this.grpDetailsSource.Controls.Add(this.tbIDGame);
            this.grpDetailsSource.Controls.Add(this.tbIDMakerCode);
            this.grpDetailsSource.Controls.Add(this.labelTitle);
            this.grpDetailsSource.Controls.Add(this.labelFile);
            this.grpDetailsSource.Controls.Add(this.labelGameID);
            this.grpDetailsSource.Controls.Add(this.tbIDDiscID);
            this.grpDetailsSource.Controls.Add(this.pbWebGameID);
            this.grpDetailsSource.Controls.Add(this.label29);
            this.grpDetailsSource.Name = "grpDetailsSource";
            this.grpDetailsSource.TabStop = false;
            // 
            // lblTypeDisc
            // 
            resources.ApplyResources(this.lblTypeDisc, "lblTypeDisc");
            this.lblTypeDisc.Name = "lblTypeDisc";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.pbGameDisc);
            this.groupBox1.Controls.Add(this.pbGameCover3D);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // pbGameDisc
            // 
            resources.ApplyResources(this.pbGameDisc, "pbGameDisc");
            this.pbGameDisc.BackColor = System.Drawing.Color.Transparent;
            this.pbGameDisc.Name = "pbGameDisc";
            this.pbGameDisc.TabStop = false;
            // 
            // pbGameCover3D
            // 
            resources.ApplyResources(this.pbGameCover3D, "pbGameCover3D");
            this.pbGameCover3D.Name = "pbGameCover3D";
            this.pbGameCover3D.TabStop = false;
            // 
            // tbIDName
            // 
            resources.ApplyResources(this.tbIDName, "tbIDName");
            this.tbIDName.Name = "tbIDName";
            this.tbIDName.ReadOnly = true;
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // tbIDRegion
            // 
            resources.ApplyResources(this.tbIDRegion, "tbIDRegion");
            this.tbIDRegion.Name = "tbIDRegion";
            this.tbIDRegion.ReadOnly = true;
            // 
            // tbIDGame
            // 
            resources.ApplyResources(this.tbIDGame, "tbIDGame");
            this.tbIDGame.Name = "tbIDGame";
            this.tbIDGame.ReadOnly = true;
            // 
            // tbIDMakerCode
            // 
            resources.ApplyResources(this.tbIDMakerCode, "tbIDMakerCode");
            this.tbIDMakerCode.Name = "tbIDMakerCode";
            this.tbIDMakerCode.ReadOnly = true;
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // labelFile
            // 
            resources.ApplyResources(this.labelFile, "labelFile");
            this.labelFile.Name = "labelFile";
            // 
            // labelGameID
            // 
            resources.ApplyResources(this.labelGameID, "labelGameID");
            this.labelGameID.Name = "labelGameID";
            // 
            // tbIDDiscID
            // 
            resources.ApplyResources(this.tbIDDiscID, "tbIDDiscID");
            this.tbIDDiscID.Name = "tbIDDiscID";
            this.tbIDDiscID.ReadOnly = true;
            // 
            // pbWebGameID
            // 
            resources.ApplyResources(this.pbWebGameID, "pbWebGameID");
            this.pbWebGameID.Image = global::GCBM.Properties.Resources.globe_earth_grayscale_64;
            this.pbWebGameID.Name = "pbWebGameID";
            this.pbWebGameID.TabStop = false;
            this.pbWebGameID.Click += new System.EventHandler(this.pbWebGameID_Click);
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // grpOperations
            // 
            resources.ApplyResources(this.grpOperations, "grpOperations");
            this.grpOperations.Controls.Add(this.lblInstallStatusPercent);
            this.grpOperations.Controls.Add(this.lblCurrentGameIndex);
            this.grpOperations.Controls.Add(this.lblBrowse);
            this.grpOperations.Controls.Add(this.lblSourceCount);
            this.grpOperations.Controls.Add(this.pbSource);
            this.grpOperations.Controls.Add(this.btnSelectFolder);
            this.grpOperations.Controls.Add(this.lblSourceGameCount);
            this.grpOperations.Controls.Add(this.btnAbort);
            this.grpOperations.Controls.Add(this.pbCopy);
            this.grpOperations.Controls.Add(this.lblInstallStatusText);
            this.grpOperations.Controls.Add(this.lblCurrentGameTitle);
            this.grpOperations.Name = "grpOperations";
            this.grpOperations.TabStop = false;
            // 
            // lblInstallStatusPercent
            // 
            resources.ApplyResources(this.lblInstallStatusPercent, "lblInstallStatusPercent");
            this.lblInstallStatusPercent.Name = "lblInstallStatusPercent";
            // 
            // lblCurrentGameIndex
            // 
            resources.ApplyResources(this.lblCurrentGameIndex, "lblCurrentGameIndex");
            this.lblCurrentGameIndex.Name = "lblCurrentGameIndex";
            // 
            // lblBrowse
            // 
            resources.ApplyResources(this.lblBrowse, "lblBrowse");
            this.lblBrowse.Name = "lblBrowse";
            // 
            // lblSourceCount
            // 
            resources.ApplyResources(this.lblSourceCount, "lblSourceCount");
            this.lblSourceCount.Name = "lblSourceCount";
            // 
            // pbSource
            // 
            resources.ApplyResources(this.pbSource, "pbSource");
            this.pbSource.Name = "pbSource";
            // 
            // btnSelectFolder
            // 
            resources.ApplyResources(this.btnSelectFolder, "btnSelectFolder");
            this.btnSelectFolder.Image = global::GCBM.Properties.Resources.open_folder_64;
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblSourceGameCount
            // 
            resources.ApplyResources(this.lblSourceGameCount, "lblSourceGameCount");
            this.lblSourceGameCount.Name = "lblSourceGameCount";
            // 
            // btnAbort
            // 
            resources.ApplyResources(this.btnAbort, "btnAbort");
            this.btnAbort.FlatAppearance.BorderSize = 0;
            this.btnAbort.Image = global::GCBM.Properties.Resources.cancel_32;
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // pbCopy
            // 
            resources.ApplyResources(this.pbCopy, "pbCopy");
            this.pbCopy.Name = "pbCopy";
            // 
            // lblInstallStatusText
            // 
            resources.ApplyResources(this.lblInstallStatusText, "lblInstallStatusText");
            this.lblInstallStatusText.Name = "lblInstallStatusText";
            // 
            // lblCurrentGameTitle
            // 
            resources.ApplyResources(this.lblCurrentGameTitle, "lblCurrentGameTitle");
            this.lblCurrentGameTitle.Name = "lblCurrentGameTitle";
            // 
            // cbNotificationToggle
            // 
            resources.ApplyResources(this.cbNotificationToggle, "cbNotificationToggle");
            this.cbNotificationToggle.BackColor = System.Drawing.Color.Transparent;
            this.cbNotificationToggle.Image = global::GCBM.Properties.Resources.bell_24;
            this.cbNotificationToggle.Name = "cbNotificationToggle";
            this.cbNotificationToggle.UseVisualStyleBackColor = false;
            this.cbNotificationToggle.CheckedChanged += new System.EventHandler(this.cbNotificationToggle_click);
            this.cbNotificationToggle.Click += new System.EventHandler(this.cbNotificationToggle_click);
            // 
            // sstripMain
            // 
            this.sstripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCurrentYear,
            this.lblScan});
            resources.ApplyResources(this.sstripMain, "sstripMain");
            this.sstripMain.Name = "sstripMain";
            this.sstripMain.SizingGrip = false;
            // 
            // tsslCurrentYear
            // 
            this.tsslCurrentYear.Name = "tsslCurrentYear";
            resources.ApplyResources(this.tsslCurrentYear, "tsslCurrentYear");
            // 
            // lblScan
            // 
            this.lblScan.Name = "lblScan";
            resources.ApplyResources(this.lblScan, "lblScan");
            // 
            // mstripMain
            // 
            this.mstripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiCovers,
            this.tsmiDisplay,
            this.tsmiOptions,
            this.tsmiTools,
            this.tsmiHelp});
            resources.ApplyResources(this.mstripMain, "mstripMain");
            this.mstripMain.Name = "mstripMain";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            resources.ApplyResources(this.tsmiFile, "tsmiFile");
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = global::GCBM.Properties.Resources.exit;
            this.tsmiExit.Name = "tsmiExit";
            resources.ApplyResources(this.tsmiExit, "tsmiExit");
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiCovers
            // 
            this.tsmiCovers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDownloadCoversSelectedGame,
            this.tsmiSyncDownloadDiscOnly3DCovers,
            this.toolStripMenuItem5,
            this.tsmiSyncDownloadAllDiscOnly3DCovers,
            this.tsmiSyncDownloadAllCovers,
            this.toolStripMenuItem6,
            this.tsmiTransferDeviceCovers});
            this.tsmiCovers.Name = "tsmiCovers";
            resources.ApplyResources(this.tsmiCovers, "tsmiCovers");
            // 
            // tsmiDownloadCoversSelectedGame
            // 
            this.tsmiDownloadCoversSelectedGame.Image = global::GCBM.Properties.Resources.sync_16;
            this.tsmiDownloadCoversSelectedGame.Name = "tsmiDownloadCoversSelectedGame";
            resources.ApplyResources(this.tsmiDownloadCoversSelectedGame, "tsmiDownloadCoversSelectedGame");
            this.tsmiDownloadCoversSelectedGame.Click += new System.EventHandler(this.tsmiDownloadCoversSelectedGame_Click);
            // 
            // tsmiSyncDownloadDiscOnly3DCovers
            // 
            this.tsmiSyncDownloadDiscOnly3DCovers.Image = global::GCBM.Properties.Resources.sync_16;
            this.tsmiSyncDownloadDiscOnly3DCovers.Name = "tsmiSyncDownloadDiscOnly3DCovers";
            resources.ApplyResources(this.tsmiSyncDownloadDiscOnly3DCovers, "tsmiSyncDownloadDiscOnly3DCovers");
            this.tsmiSyncDownloadDiscOnly3DCovers.Click += new System.EventHandler(this.tsmiSyncDownloadDiscOnly3DCovers_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // tsmiSyncDownloadAllDiscOnly3DCovers
            // 
            resources.ApplyResources(this.tsmiSyncDownloadAllDiscOnly3DCovers, "tsmiSyncDownloadAllDiscOnly3DCovers");
            this.tsmiSyncDownloadAllDiscOnly3DCovers.Image = global::GCBM.Properties.Resources.sync_16;
            this.tsmiSyncDownloadAllDiscOnly3DCovers.Name = "tsmiSyncDownloadAllDiscOnly3DCovers";
            // 
            // tsmiSyncDownloadAllCovers
            // 
            resources.ApplyResources(this.tsmiSyncDownloadAllCovers, "tsmiSyncDownloadAllCovers");
            this.tsmiSyncDownloadAllCovers.Image = global::GCBM.Properties.Resources.sync_16;
            this.tsmiSyncDownloadAllCovers.Name = "tsmiSyncDownloadAllCovers";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            // 
            // tsmiTransferDeviceCovers
            // 
            this.tsmiTransferDeviceCovers.Image = global::GCBM.Properties.Resources.transfer_0002;
            this.tsmiTransferDeviceCovers.Name = "tsmiTransferDeviceCovers";
            resources.ApplyResources(this.tsmiTransferDeviceCovers, "tsmiTransferDeviceCovers");
            this.tsmiTransferDeviceCovers.Click += new System.EventHandler(this.tsmiTransferDeviceCovers_Click);
            // 
            // tsmiDisplay
            // 
            this.tsmiDisplay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameInfo,
            this.boxArtToolStripMenuItem});
            this.tsmiDisplay.Name = "tsmiDisplay";
            resources.ApplyResources(this.tsmiDisplay, "tsmiDisplay");
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
            this.boxArtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEnableCoverPanel,
            this.tsmiDisableCoverPanel});
            this.boxArtToolStripMenuItem.Name = "boxArtToolStripMenuItem";
            resources.ApplyResources(this.boxArtToolStripMenuItem, "boxArtToolStripMenuItem");
            // 
            // tsmiEnableCoverPanel
            // 
            this.tsmiEnableCoverPanel.Checked = true;
            this.tsmiEnableCoverPanel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiEnableCoverPanel.Name = "tsmiEnableCoverPanel";
            resources.ApplyResources(this.tsmiEnableCoverPanel, "tsmiEnableCoverPanel");
            this.tsmiEnableCoverPanel.Click += new System.EventHandler(this.tsmiEnableCoverPanel_Click);
            // 
            // tsmiDisableCoverPanel
            // 
            this.tsmiDisableCoverPanel.Name = "tsmiDisableCoverPanel";
            resources.ApplyResources(this.tsmiDisableCoverPanel, "tsmiDisableCoverPanel");
            this.tsmiDisableCoverPanel.Click += new System.EventHandler(this.tsmiDisableCoverPanel_Click);
            // 
            // tsmiOptions
            // 
            this.tsmiOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConfigurationMain});
            this.tsmiOptions.Name = "tsmiOptions";
            resources.ApplyResources(this.tsmiOptions, "tsmiOptions");
            // 
            // tsmiConfigurationMain
            // 
            this.tsmiConfigurationMain.Image = global::GCBM.Properties.Resources.config;
            this.tsmiConfigurationMain.Name = "tsmiConfigurationMain";
            resources.ApplyResources(this.tsmiConfigurationMain, "tsmiConfigurationMain");
            this.tsmiConfigurationMain.Click += new System.EventHandler(this.tsmiConfigurationMain_Click);
            // 
            // tsmiTools
            // 
            this.tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRenameFolders,
            this.tsmiRenameISO,
            this.tsmiMainPlugins,
            this.toolStripMenuItem11});
            this.tsmiTools.Name = "tsmiTools";
            resources.ApplyResources(this.tsmiTools, "tsmiTools");
            // 
            // tsmiRenameFolders
            // 
            this.tsmiRenameFolders.Image = global::GCBM.Properties.Resources.rename_folder_16;
            this.tsmiRenameFolders.Name = "tsmiRenameFolders";
            resources.ApplyResources(this.tsmiRenameFolders, "tsmiRenameFolders");
            // 
            // tsmiRenameISO
            // 
            this.tsmiRenameISO.Image = global::GCBM.Properties.Resources.rename_16;
            this.tsmiRenameISO.Name = "tsmiRenameISO";
            resources.ApplyResources(this.tsmiRenameISO, "tsmiRenameISO");
            this.tsmiRenameISO.Click += new System.EventHandler(this.tsmiRenameISO_Click);
            // 
            // tsmiMainPlugins
            // 
            this.tsmiMainPlugins.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMetaXml,
            this.tsmiManageApp,
            this.tsmiElfDol,
            this.tsmiCreatePackage,
            this.tsmiBurnMedia});
            this.tsmiMainPlugins.Image = global::GCBM.Properties.Resources.plugin_16;
            this.tsmiMainPlugins.Name = "tsmiMainPlugins";
            resources.ApplyResources(this.tsmiMainPlugins, "tsmiMainPlugins");
            // 
            // tsmiMetaXml
            // 
            this.tsmiMetaXml.Image = global::GCBM.Properties.Resources.xml_16;
            this.tsmiMetaXml.Name = "tsmiMetaXml";
            resources.ApplyResources(this.tsmiMetaXml, "tsmiMetaXml");
            this.tsmiMetaXml.Click += new System.EventHandler(this.tsmiMetaXml_Click);
            // 
            // tsmiManageApp
            // 
            this.tsmiManageApp.Image = global::GCBM.Properties.Resources.manager_apps_16;
            this.tsmiManageApp.Name = "tsmiManageApp";
            resources.ApplyResources(this.tsmiManageApp, "tsmiManageApp");
            this.tsmiManageApp.Click += new System.EventHandler(this.tsmiManageApp_Click);
            // 
            // tsmiElfDol
            // 
            this.tsmiElfDol.Image = global::GCBM.Properties.Resources.convert_16;
            this.tsmiElfDol.Name = "tsmiElfDol";
            resources.ApplyResources(this.tsmiElfDol, "tsmiElfDol");
            this.tsmiElfDol.Click += new System.EventHandler(this.tsmiElfDol_Click);
            // 
            // tsmiCreatePackage
            // 
            this.tsmiCreatePackage.Image = global::GCBM.Properties.Resources.box_16;
            this.tsmiCreatePackage.Name = "tsmiCreatePackage";
            resources.ApplyResources(this.tsmiCreatePackage, "tsmiCreatePackage");
            this.tsmiCreatePackage.Click += new System.EventHandler(this.tsmiCreatePackage_Click);
            // 
            // tsmiBurnMedia
            // 
            this.tsmiBurnMedia.Image = global::GCBM.Properties.Resources.burn_cd_16;
            this.tsmiBurnMedia.Name = "tsmiBurnMedia";
            resources.ApplyResources(this.tsmiBurnMedia, "tsmiBurnMedia");
            this.tsmiBurnMedia.Click += new System.EventHandler(this.tsmiBurnMedia_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Image = global::GCBM.Properties.Resources.Misc_Download_Database_icon;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
            this.toolStripMenuItem11.Click += new System.EventHandler(this.tsmiDatabaseUpdateGameTDB_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiWebsiteFacebook,
            this.tsmiOfficialGitHub,
            this.tsmiOfficialGBATemp,
            this.toolStripMenuItem7,
            this.tsmiVerifyUpdate,
            this.toolStripMenuItem1,
            this.tsmiMenuAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            resources.ApplyResources(this.tsmiHelp, "tsmiHelp");
            // 
            // tsmiWebsiteFacebook
            // 
            this.tsmiWebsiteFacebook.Image = global::GCBM.Properties.Resources.facebook_16;
            this.tsmiWebsiteFacebook.Name = "tsmiWebsiteFacebook";
            resources.ApplyResources(this.tsmiWebsiteFacebook, "tsmiWebsiteFacebook");
            this.tsmiWebsiteFacebook.Click += new System.EventHandler(this.tsmiWebsiteFacebook_Click);
            // 
            // tsmiOfficialGitHub
            // 
            this.tsmiOfficialGitHub.Image = global::GCBM.Properties.Resources.github_16;
            this.tsmiOfficialGitHub.Name = "tsmiOfficialGitHub";
            resources.ApplyResources(this.tsmiOfficialGitHub, "tsmiOfficialGitHub");
            this.tsmiOfficialGitHub.Click += new System.EventHandler(this.tsmiOfficialGitHub_Click);
            // 
            // tsmiOfficialGBATemp
            // 
            this.tsmiOfficialGBATemp.Image = global::GCBM.Properties.Resources.gbatemp_16;
            this.tsmiOfficialGBATemp.Name = "tsmiOfficialGBATemp";
            resources.ApplyResources(this.tsmiOfficialGBATemp, "tsmiOfficialGBATemp");
            this.tsmiOfficialGBATemp.Click += new System.EventHandler(this.tsmiOfficialGBATemp_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            // 
            // tsmiVerifyUpdate
            // 
            this.tsmiVerifyUpdate.Image = global::GCBM.Properties.Resources.update_16;
            this.tsmiVerifyUpdate.Name = "tsmiVerifyUpdate";
            resources.ApplyResources(this.tsmiVerifyUpdate, "tsmiVerifyUpdate");
            this.tsmiVerifyUpdate.Click += new System.EventHandler(this.tsmiVerifyUpdate_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // tsmiMenuAbout
            // 
            this.tsmiMenuAbout.Image = global::GCBM.Properties.Resources.info_16;
            this.tsmiMenuAbout.Name = "tsmiMenuAbout";
            resources.ApplyResources(this.tsmiMenuAbout, "tsmiMenuAbout");
            this.tsmiMenuAbout.Click += new System.EventHandler(this.tsmiMenuAbout_Click);
            // 
            // fbd1
            // 
            this.fbd1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // fbd2
            // 
            this.fbd2.RootFolder = System.Environment.SpecialFolder.MyComputer;
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
            this.notifyIcon.ContextMenuStrip = this.cmsNotifyIcon;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            // 
            // cmsNotifyIcon
            // 
            this.cmsNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNotifyExit});
            this.cmsNotifyIcon.Name = "cmsNotifyIcon";
            resources.ApplyResources(this.cmsNotifyIcon, "cmsNotifyIcon");
            // 
            // tsmiNotifyExit
            // 
            this.tsmiNotifyExit.Image = global::GCBM.Properties.Resources.exit;
            this.tsmiNotifyExit.Name = "tsmiNotifyExit";
            resources.ApplyResources(this.tsmiNotifyExit, "tsmiNotifyExit");
            this.tsmiNotifyExit.Click += new System.EventHandler(this.tsmiNotifyExit_Click);
            // 
            // pbNetStatus
            // 
            resources.ApplyResources(this.pbNetStatus, "pbNetStatus");
            this.pbNetStatus.Image = global::GCBM.Properties.Resources.not_conected_16;
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
            this.Controls.Add(this.cbNotificationToggle);
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
            this.tabControlMain.ResumeLayout(false);
            this.tabMainFile.ResumeLayout(false);
            this.tabMainFile.PerformLayout();
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
            this.grpDetailsSource.ResumeLayout(false);
            this.grpDetailsSource.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameDisc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameCover3D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebGameID)).EndInit();
            this.grpOperations.ResumeLayout(false);
            this.grpOperations.PerformLayout();
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
        private Label lblCurrentGameTitle;
        private ProgressBar pbCopy;
        private Label lblBrowse;
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
        private Process process1;
        private Button btnAbort;
        private Label lblSourceCount;
        private Label lblSourceGameCount;
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
        private CheckBox cbNotificationToggle;
        private Button btnGameInstallExactCopy;
        private Label lblCurrentGameIndex;
        private Label lblInstallStatusPercent;
    }
}

