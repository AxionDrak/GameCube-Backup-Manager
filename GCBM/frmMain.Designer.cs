
namespace GCBM
{
    partial class frmMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pbGameCover3D = new System.Windows.Forms.PictureBox();
            this.pbGameDisc = new System.Windows.Forms.PictureBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabMainFile = new System.Windows.Forms.TabPage();
            this.lblInstallGame = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblCopy = new System.Windows.Forms.Label();
            this.pbCopy = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.grpDetails = new System.Windows.Forms.GroupBox();
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
            this.dgvGameList = new System.Windows.Forms.DataGridView();
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
            this.lblSpaceAvailabeOnDevice = new System.Windows.Forms.Label();
            this.lblSpaceTotalOnDevice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbWebGameDiscID = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbIDGameDisc = new System.Windows.Forms.TextBox();
            this.tbIDRegionDisc = new System.Windows.Forms.TextBox();
            this.tbIDNameDisc = new System.Windows.Forms.TextBox();
            this.dgvGameListDisc = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameCover3D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameDisc)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabMainFile.SuspendLayout();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebGameID)).BeginInit();
            this.grpOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGameList)).BeginInit();
            this.cmsMain.SuspendLayout();
            this.mstripFile.SuspendLayout();
            this.tabMainDisc.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebGameDiscID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGameListDisc)).BeginInit();
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
            this.spcMain.Panel1.Controls.Add(this.groupBox1);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.tabControlMain);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.tbSearch);
            this.groupBox1.Controls.Add(this.pbGameCover3D);
            this.groupBox1.Controls.Add(this.pbGameDisc);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
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
            // tbSearch
            // 
            resources.ApplyResources(this.tbSearch, "tbSearch");
            this.tbSearch.Name = "tbSearch";
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
            this.tabMainFile.Controls.Add(this.lblInstallGame);
            this.tabMainFile.Controls.Add(this.lblPercent);
            this.tabMainFile.Controls.Add(this.lblCopy);
            this.tabMainFile.Controls.Add(this.pbCopy);
            this.tabMainFile.Controls.Add(this.label1);
            this.tabMainFile.Controls.Add(this.btnSelectFolder);
            this.tabMainFile.Controls.Add(this.grpDetails);
            this.tabMainFile.Controls.Add(this.dgvGameList);
            this.tabMainFile.Controls.Add(this.mstripFile);
            resources.ApplyResources(this.tabMainFile, "tabMainFile");
            this.tabMainFile.Name = "tabMainFile";
            this.tabMainFile.UseVisualStyleBackColor = true;
            // 
            // lblInstallGame
            // 
            resources.ApplyResources(this.lblInstallGame, "lblInstallGame");
            this.lblInstallGame.Name = "lblInstallGame";
            // 
            // lblPercent
            // 
            resources.ApplyResources(this.lblPercent, "lblPercent");
            this.lblPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblPercent.Name = "lblPercent";
            // 
            // lblCopy
            // 
            resources.ApplyResources(this.lblCopy, "lblCopy");
            this.lblCopy.Name = "lblCopy";
            // 
            // pbCopy
            // 
            resources.ApplyResources(this.pbCopy, "pbCopy");
            this.pbCopy.Name = "pbCopy";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnSelectFolder
            // 
            resources.ApplyResources(this.btnSelectFolder, "btnSelectFolder");
            this.btnSelectFolder.Image = global::GCBM.Properties.Resources.open_folder_64;
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // grpDetails
            // 
            resources.ApplyResources(this.grpDetails, "grpDetails");
            this.grpDetails.Controls.Add(this.lblTypeDisc);
            this.grpDetails.Controls.Add(this.label34);
            this.grpDetails.Controls.Add(this.tbIDMakerCode);
            this.grpDetails.Controls.Add(this.tbIDDiscID);
            this.grpDetails.Controls.Add(this.label29);
            this.grpDetails.Controls.Add(this.pbWebGameID);
            this.grpDetails.Controls.Add(this.grpOperations);
            this.grpDetails.Controls.Add(this.labelGameID);
            this.grpDetails.Controls.Add(this.labelFile);
            this.grpDetails.Controls.Add(this.labelTitle);
            this.grpDetails.Controls.Add(this.tbIDGame);
            this.grpDetails.Controls.Add(this.tbIDRegion);
            this.grpDetails.Controls.Add(this.tbIDName);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.TabStop = false;
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
            this.pbWebGameID.Image = global::GCBM.Properties.Resources.globe_earth_grayscale_64;
            this.pbWebGameID.Name = "pbWebGameID";
            this.pbWebGameID.TabStop = false;
            this.pbWebGameID.Click += new System.EventHandler(this.pbWebGameID_Click);
            // 
            // grpOperations
            // 
            this.grpOperations.Controls.Add(this.btnGameInstallScrub);
            this.grpOperations.Controls.Add(this.btnGameInstallExactCopy);
            resources.ApplyResources(this.grpOperations, "grpOperations");
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
            // dgvGameList
            // 
            this.dgvGameList.AllowUserToAddRows = false;
            this.dgvGameList.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvGameList, "dgvGameList");
            this.dgvGameList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGameList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvGameList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvGameList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGameList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmChk,
            this.clmTitle,
            this.clmRegion,
            this.clmID,
            this.clmExtension,
            this.clmSize,
            this.clmPath});
            this.dgvGameList.ContextMenuStrip = this.cmsMain;
            this.dgvGameList.Name = "dgvGameList";
            this.dgvGameList.ReadOnly = true;
            this.dgvGameList.RowHeadersVisible = false;
            this.dgvGameList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGameList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGameList_CellContentClick);
            this.dgvGameList.Click += new System.EventHandler(this.dgvGameList_Click);
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
            // mstripFile
            // 
            this.mstripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReloadGameList,
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
            // tsmiSelectGameList
            // 
            this.tsmiSelectGameList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameListSelectAll,
            this.tsmiGameListSelectNone});
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
            this.tabMainDisc.Controls.Add(this.lblSpaceAvailabeOnDevice);
            this.tabMainDisc.Controls.Add(this.lblSpaceTotalOnDevice);
            this.tabMainDisc.Controls.Add(this.label3);
            this.tabMainDisc.Controls.Add(this.label2);
            this.tabMainDisc.Controls.Add(this.groupBox2);
            this.tabMainDisc.Controls.Add(this.dgvGameListDisc);
            this.tabMainDisc.Controls.Add(this.mstripDisc);
            resources.ApplyResources(this.tabMainDisc, "tabMainDisc");
            this.tabMainDisc.Name = "tabMainDisc";
            this.tabMainDisc.UseVisualStyleBackColor = true;
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
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.pbWebGameDiscID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbIDGameDisc);
            this.groupBox2.Controls.Add(this.tbIDRegionDisc);
            this.groupBox2.Controls.Add(this.tbIDNameDisc);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
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
            // dgvGameListDisc
            // 
            this.dgvGameListDisc.AllowUserToAddRows = false;
            this.dgvGameListDisc.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvGameListDisc, "dgvGameListDisc");
            this.dgvGameListDisc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGameListDisc.BackgroundColor = System.Drawing.Color.White;
            this.dgvGameListDisc.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvGameListDisc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGameListDisc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvMainDiscCheck,
            this.clmDiscTitle,
            this.clmDiscID,
            this.clmDiscRegion,
            this.clmDiscExtension,
            this.clmDiscSize,
            this.clmDiscPath});
            this.dgvGameListDisc.MultiSelect = false;
            this.dgvGameListDisc.Name = "dgvGameListDisc";
            this.dgvGameListDisc.ReadOnly = true;
            this.dgvGameListDisc.RowHeadersVisible = false;
            this.dgvGameListDisc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGameList_CellContentClick);
            this.dgvGameListDisc.Click += new System.EventHandler(this.dgvGameListDisc_Click);
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
            // tsmiSelectGameDisc
            // 
            this.tsmiSelectGameDisc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGameDiscSelectAll,
            this.tsmiGameDiscSelectNone});
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
            // sstripMain
            // 
            this.sstripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCurrentYear});
            resources.ApplyResources(this.sstripMain, "sstripMain");
            this.sstripMain.Name = "sstripMain";
            this.sstripMain.SizingGrip = false;
            // 
            // tsslCurrentYear
            // 
            this.tsslCurrentYear.Name = "tsslCurrentYear";
            resources.ApplyResources(this.tsslCurrentYear, "tsslCurrentYear");
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
            this.tsmiGameInfo.Image = global::GCBM.Properties.Resources.additional_information_16;
            this.tsmiGameInfo.Name = "tsmiGameInfo";
            resources.ApplyResources(this.tsmiGameInfo, "tsmiGameInfo");
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
            this.tsmiMainPlugins});
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
            // 
            // gameBindingSource
            // 
            this.gameBindingSource.DataSource = typeof(GCBM.Game);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameCover3D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameDisc)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabMainFile.ResumeLayout(false);
            this.tabMainFile.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebGameID)).EndInit();
            this.grpOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGameList)).EndInit();
            this.cmsMain.ResumeLayout(false);
            this.mstripFile.ResumeLayout(false);
            this.mstripFile.PerformLayout();
            this.tabMainDisc.ResumeLayout(false);
            this.tabMainDisc.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebGameDiscID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGameListDisc)).EndInit();
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

        private System.Windows.Forms.StatusStrip sstripMain;
        private System.Windows.Forms.MenuStrip mstripMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiCovers;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisplay;
        private System.Windows.Forms.ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiDownloadCoversSelectedGame;
        private System.Windows.Forms.ToolStripMenuItem tsmiSyncDownloadDiscOnly3DCovers;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameInfo;
        private System.Windows.Forms.ToolStripMenuItem boxArtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfigurationMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenuAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiEnableCoverPanel;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisableCoverPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbGameCover3D;
        private System.Windows.Forms.PictureBox pbGameDisc;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentYear;
        private System.Windows.Forms.FolderBrowserDialog fbd1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tsmiSyncDownloadAllDiscOnly3DCovers;
        private System.Windows.Forms.ToolStripMenuItem tsmiSyncDownloadAllCovers;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransferDeviceCovers;
        private System.Windows.Forms.FolderBrowserDialog fbd2;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem tsmiWebsiteFacebook;
        private System.Windows.Forms.Label lblNetStatus;
        private System.Windows.Forms.PictureBox pbNetStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenameISO;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cmsNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem tsmiNotifyExit;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiInfoGame;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerifyUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainPlugins;
        private System.Windows.Forms.ToolStripMenuItem tsmiMetaXml;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageApp;
        private System.Windows.Forms.ToolStripMenuItem tsmiElfDol;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreatePackage;
        private System.Windows.Forms.ToolStripMenuItem tsmiBurnMedia;
        private System.Windows.Forms.ToolStripMenuItem tsmiOfficialGitHub;
        private System.Windows.Forms.ToolStripMenuItem tsmiOfficialGBATemp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearchOnGoogle;
        private System.Windows.Forms.ToolStripMenuItem SearchOnWikipedia;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearchOnYoutube;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearchOnGameSpot;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearchOnVGChartz;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearchOnGameTDB;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem tsmiDolphinEmulator;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabMainFile;
        private System.Windows.Forms.Label lblInstallGame;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblCopy;
        private System.Windows.Forms.ProgressBar pbCopy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblTypeDisc;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox tbIDMakerCode;
        private System.Windows.Forms.TextBox tbIDDiscID;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.PictureBox pbWebGameID;
        private System.Windows.Forms.GroupBox grpOperations;
        private System.Windows.Forms.Button btnGameInstallScrub;
        private System.Windows.Forms.Button btnGameInstallExactCopy;
        private System.Windows.Forms.Label labelGameID;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox tbIDGame;
        private System.Windows.Forms.TextBox tbIDRegion;
        private System.Windows.Forms.TextBox tbIDName;
        private System.Windows.Forms.DataGridView dgvGameList;
        private System.Windows.Forms.MenuStrip mstripFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiReloadGameList;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectGameList;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameListSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameListSelectNone;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveGameList;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameListDeleteAllFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameListDeleteSelectedFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiToolsGameList;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameListSignatureSHA1;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameListHashSHA1;
        private System.Windows.Forms.ToolStripMenuItem exportarListaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportTXT;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportHTML;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportCSV;
        private System.Windows.Forms.TabPage tabMainDisc;
        private System.Windows.Forms.Label lblSpaceAvailabeOnDevice;
        private System.Windows.Forms.Label lblSpaceTotalOnDevice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbWebGameDiscID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbIDGameDisc;
        private System.Windows.Forms.TextBox tbIDRegionDisc;
        private System.Windows.Forms.TextBox tbIDNameDisc;
        private System.Windows.Forms.DataGridView dgvGameListDisc;
        private System.Windows.Forms.MenuStrip mstripDisc;
        private System.Windows.Forms.ToolStripComboBox tscbDiscDrive;
        private System.Windows.Forms.ToolStripMenuItem tsmiReloadDeviceDrive;
        private System.Windows.Forms.ToolStripMenuItem tsmiReloadGameListDisc;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectGameDisc;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscSelectNone;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveGameDisc;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscDeleteAllFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscDeleteSelectedFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiToolsGameDisc;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscExportList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscSignatureSHA1;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscAllHashSHA1;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscHashSHA1;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscSignatureMD5;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscAllHashMD5;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscHashMD5;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscRecalculateAllMD5;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameDiscRecalculateSelectedGameMD5;
        private System.Windows.Forms.TabPage tabMainDatabase;
        private System.Windows.Forms.Label lblDatabaseTotal;
        private System.Windows.Forms.ComboBox cbFilterDatabase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lvDatabase;
        private System.Windows.Forms.MenuStrip mstripDatabase;
        private System.Windows.Forms.ToolStripMenuItem tsmiToolDatabase;
        private System.Windows.Forms.ToolStripMenuItem tsmiDatabaseUpdateGameTDB;
        private System.Windows.Forms.TabPage tabMainLog;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.MenuStrip mstripLog;
        private System.Windows.Forms.ToolStripMenuItem tsmiToolLog;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearLog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportLog;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenameFolders;
        private System.Windows.Forms.BindingSource gameBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmExtension;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPath;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvMainDiscCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiscTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiscID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiscRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiscExtension;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiscSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiscPath;
    }
}

