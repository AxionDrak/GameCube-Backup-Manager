
namespace GameCube_Backup_Manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.tsmiMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainUpdateGameList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainExportGameList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMainExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainCovers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainBoxArt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainBoxArtEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainBoxArtDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.grpBoxArt = new System.Windows.Forms.GroupBox();
            this.pictureBoxGameDisc = new System.Windows.Forms.PictureBox();
            this.pictureBoxGameCover3D = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMainFile = new System.Windows.Forms.TabPage();
            this.labelPasta = new System.Windows.Forms.Label();
            this.labelOpenFolder = new System.Windows.Forms.Label();
            this.grpStatistics = new System.Windows.Forms.GroupBox();
            this.lblSizeTotal = new System.Windows.Forms.Label();
            this.lblSizeApps = new System.Windows.Forms.Label();
            this.lblSizeISO = new System.Windows.Forms.Label();
            this.lblQuantTotal = new System.Windows.Forms.Label();
            this.lblQuantApps = new System.Windows.Forms.Label();
            this.lblQuantISO = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelAPPs = new System.Windows.Forms.Label();
            this.labelGC_ISO = new System.Windows.Forms.Label();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtBoxMainCountryCode = new System.Windows.Forms.TextBox();
            this.txtBoxMainDiscID = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.pictureBoxGameID = new System.Windows.Forms.PictureBox();
            this.grpOperations = new System.Windows.Forms.GroupBox();
            this.btnGameInstallScrub = new System.Windows.Forms.Button();
            this.btnGameInstallExactCopy = new System.Windows.Forms.Button();
            this.btnCheatEditor = new System.Windows.Forms.Button();
            this.btnManagerART = new System.Windows.Forms.Button();
            this.btnEditGameCFG = new System.Windows.Forms.Button();
            this.btnHashGame = new System.Windows.Forms.Button();
            this.btnRenameGameISO = new System.Windows.Forms.Button();
            this.btnDeleteGame = new System.Windows.Forms.Button();
            this.labelGameID = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.txtBoxMainGameID = new System.Windows.Forms.TextBox();
            this.txtBoxMainGameFileName = new System.Windows.Forms.TextBox();
            this.txtBoxMainGameName = new System.Windows.Forms.TextBox();
            this.dgvMainGame = new System.Windows.Forms.DataGridView();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.tabMainDisc = new System.Windows.Forms.TabPage();
            this.BtnListAllFiles = new System.Windows.Forms.Button();
            this.BtnReloadedDevices = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnRenameGameID = new System.Windows.Forms.Button();
            this.BtnDeleteAllGameDisc = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.BtnDeleteGameDisc = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.BtnRenameDirectory = new System.Windows.Forms.Button();
            this.dataGridViewFiles = new System.Windows.Forms.DataGridView();
            this.menuStripMainDisc = new System.Windows.Forms.MenuStrip();
            this.tscbDeviceDriveUSB = new System.Windows.Forms.ToolStripComboBox();
            this.tsmiMainDiscSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainDiscSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainDiscTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainDiscRemoveGameSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainDiscRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMainDiscRenameGameDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMainDiscDownloadAllCovers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMainDiscCalculateHash = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainDiscExportGameList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainDiscExportGameListCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainDiscExportGameListTXT = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMainDatabase = new System.Windows.Forms.TabPage();
            this.toolStripMainDatabase = new System.Windows.Forms.ToolStrip();
            this.tsddbMainDatabaseTools = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsddbMainDatabaseUpdateGameTDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddbMainDatabaseExportGameList = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMainDatabase = new System.Windows.Forms.DataGridView();
            this.tabMainLog = new System.Windows.Forms.TabPage();
            this.toolStripMainLog = new System.Windows.Forms.ToolStrip();
            this.tsddbMainLogTools = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsddbMainLogClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddbMainLogExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbMainLogDebug = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsddbMainLogDebugErrorsOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbMainLogDebugNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbMainLogDebugComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDebugLog = new System.Windows.Forms.TextBox();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.grpBoxArt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameDisc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameCover3D)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabMainFile.SuspendLayout();
            this.grpStatistics.SuspendLayout();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameID)).BeginInit();
            this.grpOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainGame)).BeginInit();
            this.tabMainDisc.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).BeginInit();
            this.menuStripMainDisc.SuspendLayout();
            this.tabMainDatabase.SuspendLayout();
            this.toolStripMainDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainDatabase)).BeginInit();
            this.tabMainLog.SuspendLayout();
            this.toolStripMainLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainFile,
            this.tsmiMainCovers,
            this.tsmiMainView,
            this.tsmiMainOptions,
            this.tsmiMainTools,
            this.tsmiMainHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1504, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // tsmiMainFile
            // 
            this.tsmiMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainUpdateGameList,
            this.tsmiMainExportGameList,
            this.toolStripMenuItem1,
            this.tsmiMainExit});
            this.tsmiMainFile.Name = "tsmiMainFile";
            this.tsmiMainFile.Size = new System.Drawing.Size(61, 20);
            this.tsmiMainFile.Text = "Arquivo";
            // 
            // tsmiMainUpdateGameList
            // 
            this.tsmiMainUpdateGameList.Name = "tsmiMainUpdateGameList";
            this.tsmiMainUpdateGameList.Size = new System.Drawing.Size(192, 22);
            this.tsmiMainUpdateGameList.Text = "Atualizar lista de jogos";
            // 
            // tsmiMainExportGameList
            // 
            this.tsmiMainExportGameList.Name = "tsmiMainExportGameList";
            this.tsmiMainExportGameList.Size = new System.Drawing.Size(192, 22);
            this.tsmiMainExportGameList.Text = "Exportar lista de jogos";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(189, 6);
            // 
            // tsmiMainExit
            // 
            this.tsmiMainExit.Name = "tsmiMainExit";
            this.tsmiMainExit.Size = new System.Drawing.Size(192, 22);
            this.tsmiMainExit.Text = "Sair";
            // 
            // tsmiMainCovers
            // 
            this.tsmiMainCovers.Name = "tsmiMainCovers";
            this.tsmiMainCovers.Size = new System.Drawing.Size(51, 20);
            this.tsmiMainCovers.Text = "Capas";
            // 
            // tsmiMainView
            // 
            this.tsmiMainView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainBoxArt});
            this.tsmiMainView.Name = "tsmiMainView";
            this.tsmiMainView.Size = new System.Drawing.Size(48, 20);
            this.tsmiMainView.Text = "Exibir";
            // 
            // tsmiMainBoxArt
            // 
            this.tsmiMainBoxArt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainBoxArtEnable,
            this.tsmiMainBoxArtDisable});
            this.tsmiMainBoxArt.Name = "tsmiMainBoxArt";
            this.tsmiMainBoxArt.Size = new System.Drawing.Size(110, 22);
            this.tsmiMainBoxArt.Text = "BoxArt";
            // 
            // tsmiMainBoxArtEnable
            // 
            this.tsmiMainBoxArtEnable.Checked = true;
            this.tsmiMainBoxArtEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiMainBoxArtEnable.Name = "tsmiMainBoxArtEnable";
            this.tsmiMainBoxArtEnable.Size = new System.Drawing.Size(129, 22);
            this.tsmiMainBoxArtEnable.Text = "Habilitar";
            // 
            // tsmiMainBoxArtDisable
            // 
            this.tsmiMainBoxArtDisable.Name = "tsmiMainBoxArtDisable";
            this.tsmiMainBoxArtDisable.Size = new System.Drawing.Size(129, 22);
            this.tsmiMainBoxArtDisable.Text = "Desabilitar";
            // 
            // tsmiMainOptions
            // 
            this.tsmiMainOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainSettings});
            this.tsmiMainOptions.Name = "tsmiMainOptions";
            this.tsmiMainOptions.Size = new System.Drawing.Size(59, 20);
            this.tsmiMainOptions.Text = "Opções";
            // 
            // tsmiMainSettings
            // 
            this.tsmiMainSettings.Name = "tsmiMainSettings";
            this.tsmiMainSettings.Size = new System.Drawing.Size(160, 22);
            this.tsmiMainSettings.Text = "Configurações...";
            // 
            // tsmiMainTools
            // 
            this.tsmiMainTools.Name = "tsmiMainTools";
            this.tsmiMainTools.Size = new System.Drawing.Size(84, 20);
            this.tsmiMainTools.Text = "Ferramentas";
            // 
            // tsmiMainHelp
            // 
            this.tsmiMainHelp.Name = "tsmiMainHelp";
            this.tsmiMainHelp.Size = new System.Drawing.Size(50, 20);
            this.tsmiMainHelp.Text = "Ajuda";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Location = new System.Drawing.Point(0, 799);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1504, 22);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.splitContainerMain.Panel1.Controls.Add(this.grpBoxArt);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.splitContainerMain.Panel2.Controls.Add(this.tabControl1);
            this.splitContainerMain.Size = new System.Drawing.Size(1504, 775);
            this.splitContainerMain.SplitterDistance = 290;
            this.splitContainerMain.SplitterWidth = 1;
            this.splitContainerMain.TabIndex = 2;
            // 
            // grpBoxArt
            // 
            this.grpBoxArt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpBoxArt.AutoSize = true;
            this.grpBoxArt.Controls.Add(this.pictureBoxGameDisc);
            this.grpBoxArt.Controls.Add(this.pictureBoxGameCover3D);
            this.grpBoxArt.Location = new System.Drawing.Point(11, 32);
            this.grpBoxArt.Name = "grpBoxArt";
            this.grpBoxArt.Size = new System.Drawing.Size(269, 710);
            this.grpBoxArt.TabIndex = 2;
            this.grpBoxArt.TabStop = false;
            this.grpBoxArt.Text = "BoxArt";
            // 
            // pictureBoxGameDisc
            // 
            this.pictureBoxGameDisc.Location = new System.Drawing.Point(7, 43);
            this.pictureBoxGameDisc.Name = "pictureBoxGameDisc";
            this.pictureBoxGameDisc.Size = new System.Drawing.Size(250, 258);
            this.pictureBoxGameDisc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGameDisc.TabIndex = 8;
            this.pictureBoxGameDisc.TabStop = false;
            // 
            // pictureBoxGameCover3D
            // 
            this.pictureBoxGameCover3D.Location = new System.Drawing.Point(7, 322);
            this.pictureBoxGameCover3D.Name = "pictureBoxGameCover3D";
            this.pictureBoxGameCover3D.Size = new System.Drawing.Size(250, 369);
            this.pictureBoxGameCover3D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGameCover3D.TabIndex = 31;
            this.pictureBoxGameCover3D.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabMainFile);
            this.tabControl1.Controls.Add(this.tabMainDisc);
            this.tabControl1.Controls.Add(this.tabMainDatabase);
            this.tabControl1.Controls.Add(this.tabMainLog);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1181, 721);
            this.tabControl1.TabIndex = 12;
            // 
            // tabMainFile
            // 
            this.tabMainFile.Controls.Add(this.labelPasta);
            this.tabMainFile.Controls.Add(this.labelOpenFolder);
            this.tabMainFile.Controls.Add(this.grpStatistics);
            this.tabMainFile.Controls.Add(this.grpDetails);
            this.tabMainFile.Controls.Add(this.dgvMainGame);
            this.tabMainFile.Controls.Add(this.btnSelectFolder);
            this.tabMainFile.Location = new System.Drawing.Point(4, 22);
            this.tabMainFile.Name = "tabMainFile";
            this.tabMainFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainFile.Size = new System.Drawing.Size(1173, 695);
            this.tabMainFile.TabIndex = 0;
            this.tabMainFile.Text = "Arquivos";
            this.tabMainFile.UseVisualStyleBackColor = true;
            // 
            // labelPasta
            // 
            this.labelPasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPasta.AutoSize = true;
            this.labelPasta.Location = new System.Drawing.Point(739, 515);
            this.labelPasta.Name = "labelPasta";
            this.labelPasta.Size = new System.Drawing.Size(16, 13);
            this.labelPasta.TabIndex = 7;
            this.labelPasta.Text = "...";
            // 
            // labelOpenFolder
            // 
            this.labelOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOpenFolder.AutoSize = true;
            this.labelOpenFolder.Location = new System.Drawing.Point(739, 629);
            this.labelOpenFolder.Name = "labelOpenFolder";
            this.labelOpenFolder.Size = new System.Drawing.Size(16, 13);
            this.labelOpenFolder.TabIndex = 6;
            this.labelOpenFolder.Text = "...";
            // 
            // grpStatistics
            // 
            this.grpStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStatistics.Controls.Add(this.lblSizeTotal);
            this.grpStatistics.Controls.Add(this.lblSizeApps);
            this.grpStatistics.Controls.Add(this.lblSizeISO);
            this.grpStatistics.Controls.Add(this.lblQuantTotal);
            this.grpStatistics.Controls.Add(this.lblQuantApps);
            this.grpStatistics.Controls.Add(this.lblQuantISO);
            this.grpStatistics.Controls.Add(this.labelSize);
            this.grpStatistics.Controls.Add(this.labelAmount);
            this.grpStatistics.Controls.Add(this.labelTotal);
            this.grpStatistics.Controls.Add(this.labelAPPs);
            this.grpStatistics.Controls.Add(this.labelGC_ISO);
            this.grpStatistics.Location = new System.Drawing.Point(740, 391);
            this.grpStatistics.Name = "grpStatistics";
            this.grpStatistics.Size = new System.Drawing.Size(377, 121);
            this.grpStatistics.TabIndex = 5;
            this.grpStatistics.TabStop = false;
            this.grpStatistics.Text = "Estatísticas";
            // 
            // lblSizeTotal
            // 
            this.lblSizeTotal.AutoSize = true;
            this.lblSizeTotal.Location = new System.Drawing.Point(254, 97);
            this.lblSizeTotal.Name = "lblSizeTotal";
            this.lblSizeTotal.Size = new System.Drawing.Size(13, 13);
            this.lblSizeTotal.TabIndex = 10;
            this.lblSizeTotal.Text = "0";
            // 
            // lblSizeApps
            // 
            this.lblSizeApps.AutoSize = true;
            this.lblSizeApps.Location = new System.Drawing.Point(254, 70);
            this.lblSizeApps.Name = "lblSizeApps";
            this.lblSizeApps.Size = new System.Drawing.Size(13, 13);
            this.lblSizeApps.TabIndex = 9;
            this.lblSizeApps.Text = "0";
            // 
            // lblSizeISO
            // 
            this.lblSizeISO.AutoSize = true;
            this.lblSizeISO.Location = new System.Drawing.Point(254, 43);
            this.lblSizeISO.Name = "lblSizeISO";
            this.lblSizeISO.Size = new System.Drawing.Size(13, 13);
            this.lblSizeISO.TabIndex = 8;
            this.lblSizeISO.Text = "0";
            // 
            // lblQuantTotal
            // 
            this.lblQuantTotal.AutoSize = true;
            this.lblQuantTotal.Location = new System.Drawing.Point(155, 97);
            this.lblQuantTotal.Name = "lblQuantTotal";
            this.lblQuantTotal.Size = new System.Drawing.Size(13, 13);
            this.lblQuantTotal.TabIndex = 7;
            this.lblQuantTotal.Text = "0";
            // 
            // lblQuantApps
            // 
            this.lblQuantApps.AutoSize = true;
            this.lblQuantApps.Location = new System.Drawing.Point(155, 70);
            this.lblQuantApps.Name = "lblQuantApps";
            this.lblQuantApps.Size = new System.Drawing.Size(13, 13);
            this.lblQuantApps.TabIndex = 6;
            this.lblQuantApps.Text = "0";
            // 
            // lblQuantISO
            // 
            this.lblQuantISO.AutoSize = true;
            this.lblQuantISO.Location = new System.Drawing.Point(155, 43);
            this.lblQuantISO.Name = "lblQuantISO";
            this.lblQuantISO.Size = new System.Drawing.Size(13, 13);
            this.lblQuantISO.TabIndex = 5;
            this.lblQuantISO.Text = "0";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(242, 18);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(52, 13);
            this.labelSize.TabIndex = 4;
            this.labelSize.Text = "Tamanho";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(131, 18);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(62, 13);
            this.labelAmount.TabIndex = 3;
            this.labelAmount.Text = "Quantidade";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(44, 97);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(34, 13);
            this.labelTotal.TabIndex = 2;
            this.labelTotal.Text = "Total:";
            // 
            // labelAPPs
            // 
            this.labelAPPs.AutoSize = true;
            this.labelAPPs.Location = new System.Drawing.Point(39, 70);
            this.labelAPPs.Name = "labelAPPs";
            this.labelAPPs.Size = new System.Drawing.Size(38, 13);
            this.labelAPPs.TabIndex = 1;
            this.labelAPPs.Text = "APP\'s:";
            // 
            // labelGC_ISO
            // 
            this.labelGC_ISO.AutoSize = true;
            this.labelGC_ISO.Location = new System.Drawing.Point(19, 43);
            this.labelGC_ISO.Name = "labelGC_ISO";
            this.labelGC_ISO.Size = new System.Drawing.Size(57, 13);
            this.labelGC_ISO.TabIndex = 0;
            this.labelGC_ISO.Text = "ISO/GCM:";
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Controls.Add(this.label34);
            this.grpDetails.Controls.Add(this.txtBoxMainCountryCode);
            this.grpDetails.Controls.Add(this.txtBoxMainDiscID);
            this.grpDetails.Controls.Add(this.label29);
            this.grpDetails.Controls.Add(this.pictureBoxGameID);
            this.grpDetails.Controls.Add(this.grpOperations);
            this.grpDetails.Controls.Add(this.labelGameID);
            this.grpDetails.Controls.Add(this.labelFile);
            this.grpDetails.Controls.Add(this.labelTitle);
            this.grpDetails.Controls.Add(this.txtBoxMainGameID);
            this.grpDetails.Controls.Add(this.txtBoxMainGameFileName);
            this.grpDetails.Controls.Add(this.txtBoxMainGameName);
            this.grpDetails.Location = new System.Drawing.Point(740, 7);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(377, 378);
            this.grpDetails.TabIndex = 4;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Detalhes";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(273, 85);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(65, 13);
            this.label34.TabIndex = 12;
            this.label34.Text = "MakerCode:";
            // 
            // txtBoxMainCountryCode
            // 
            this.txtBoxMainCountryCode.Location = new System.Drawing.Point(344, 81);
            this.txtBoxMainCountryCode.Name = "txtBoxMainCountryCode";
            this.txtBoxMainCountryCode.ReadOnly = true;
            this.txtBoxMainCountryCode.Size = new System.Drawing.Size(26, 20);
            this.txtBoxMainCountryCode.TabIndex = 11;
            // 
            // txtBoxMainDiscID
            // 
            this.txtBoxMainDiscID.Location = new System.Drawing.Point(231, 82);
            this.txtBoxMainDiscID.Name = "txtBoxMainDiscID";
            this.txtBoxMainDiscID.ReadOnly = true;
            this.txtBoxMainDiscID.Size = new System.Drawing.Size(30, 20);
            this.txtBoxMainDiscID.TabIndex = 10;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(180, 85);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(45, 13);
            this.label29.TabIndex = 9;
            this.label29.Text = "Disc ID:";
            // 
            // pictureBoxGameID
            // 
            this.pictureBoxGameID.Enabled = false;
            this.pictureBoxGameID.InitialImage = null;
            this.pictureBoxGameID.Location = new System.Drawing.Point(146, 79);
            this.pictureBoxGameID.Name = "pictureBoxGameID";
            this.pictureBoxGameID.Size = new System.Drawing.Size(27, 27);
            this.pictureBoxGameID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGameID.TabIndex = 8;
            this.pictureBoxGameID.TabStop = false;
            // 
            // grpOperations
            // 
            this.grpOperations.Controls.Add(this.btnGameInstallScrub);
            this.grpOperations.Controls.Add(this.btnGameInstallExactCopy);
            this.grpOperations.Controls.Add(this.btnCheatEditor);
            this.grpOperations.Controls.Add(this.btnManagerART);
            this.grpOperations.Controls.Add(this.btnEditGameCFG);
            this.grpOperations.Controls.Add(this.btnHashGame);
            this.grpOperations.Controls.Add(this.btnRenameGameISO);
            this.grpOperations.Controls.Add(this.btnDeleteGame);
            this.grpOperations.Location = new System.Drawing.Point(7, 112);
            this.grpOperations.Name = "grpOperations";
            this.grpOperations.Size = new System.Drawing.Size(363, 260);
            this.grpOperations.TabIndex = 6;
            this.grpOperations.TabStop = false;
            this.grpOperations.Text = "Operações";
            // 
            // btnGameInstallScrub
            // 
            this.btnGameInstallScrub.Enabled = false;
            this.btnGameInstallScrub.Image = global::GameCube_Backup_Manager.Properties.Resources.compact_file_32;
            this.btnGameInstallScrub.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGameInstallScrub.Location = new System.Drawing.Point(185, 94);
            this.btnGameInstallScrub.Name = "btnGameInstallScrub";
            this.btnGameInstallScrub.Size = new System.Drawing.Size(140, 40);
            this.btnGameInstallScrub.TabIndex = 7;
            this.btnGameInstallScrub.Text = "Instalar Jogo (Scrub)";
            this.btnGameInstallScrub.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGameInstallScrub.UseVisualStyleBackColor = true;
            // 
            // btnGameInstallExactCopy
            // 
            this.btnGameInstallExactCopy.Enabled = false;
            this.btnGameInstallExactCopy.Image = global::GameCube_Backup_Manager.Properties.Resources.install_iso_32;
            this.btnGameInstallExactCopy.Location = new System.Drawing.Point(185, 48);
            this.btnGameInstallExactCopy.Name = "btnGameInstallExactCopy";
            this.btnGameInstallExactCopy.Size = new System.Drawing.Size(140, 40);
            this.btnGameInstallExactCopy.TabIndex = 6;
            this.btnGameInstallExactCopy.Text = "Instalar Jogo (1:1)";
            this.btnGameInstallExactCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGameInstallExactCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGameInstallExactCopy.UseVisualStyleBackColor = true;
            // 
            // btnCheatEditor
            // 
            this.btnCheatEditor.Enabled = false;
            this.btnCheatEditor.Image = global::GameCube_Backup_Manager.Properties.Resources.game_cheat_32;
            this.btnCheatEditor.Location = new System.Drawing.Point(185, 185);
            this.btnCheatEditor.Name = "btnCheatEditor";
            this.btnCheatEditor.Size = new System.Drawing.Size(140, 40);
            this.btnCheatEditor.TabIndex = 5;
            this.btnCheatEditor.Text = "Editor de Cheat\'s";
            this.btnCheatEditor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheatEditor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheatEditor.UseVisualStyleBackColor = true;
            this.btnCheatEditor.Visible = false;
            // 
            // btnManagerART
            // 
            this.btnManagerART.Enabled = false;
            this.btnManagerART.Image = global::GameCube_Backup_Manager.Properties.Resources.art_32;
            this.btnManagerART.Location = new System.Drawing.Point(38, 140);
            this.btnManagerART.Name = "btnManagerART";
            this.btnManagerART.Size = new System.Drawing.Size(140, 40);
            this.btnManagerART.TabIndex = 4;
            this.btnManagerART.Text = "Gerenciar ART\'s";
            this.btnManagerART.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManagerART.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManagerART.UseVisualStyleBackColor = true;
            this.btnManagerART.Visible = false;
            // 
            // btnEditGameCFG
            // 
            this.btnEditGameCFG.Enabled = false;
            this.btnEditGameCFG.Image = global::GameCube_Backup_Manager.Properties.Resources.config_32;
            this.btnEditGameCFG.Location = new System.Drawing.Point(38, 185);
            this.btnEditGameCFG.Name = "btnEditGameCFG";
            this.btnEditGameCFG.Size = new System.Drawing.Size(140, 40);
            this.btnEditGameCFG.TabIndex = 3;
            this.btnEditGameCFG.Text = "Editar CFG";
            this.btnEditGameCFG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditGameCFG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditGameCFG.UseVisualStyleBackColor = true;
            this.btnEditGameCFG.Visible = false;
            // 
            // btnHashGame
            // 
            this.btnHashGame.Enabled = false;
            this.btnHashGame.Image = global::GameCube_Backup_Manager.Properties.Resources.hash_key_32;
            this.btnHashGame.Location = new System.Drawing.Point(185, 140);
            this.btnHashGame.Name = "btnHashGame";
            this.btnHashGame.Size = new System.Drawing.Size(140, 40);
            this.btnHashGame.TabIndex = 2;
            this.btnHashGame.Text = "Calcular Hash";
            this.btnHashGame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHashGame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHashGame.UseVisualStyleBackColor = true;
            // 
            // btnRenameGameISO
            // 
            this.btnRenameGameISO.Enabled = false;
            this.btnRenameGameISO.Image = global::GameCube_Backup_Manager.Properties.Resources.rename_32;
            this.btnRenameGameISO.Location = new System.Drawing.Point(38, 94);
            this.btnRenameGameISO.Name = "btnRenameGameISO";
            this.btnRenameGameISO.Size = new System.Drawing.Size(140, 40);
            this.btnRenameGameISO.TabIndex = 1;
            this.btnRenameGameISO.Text = "Renomear ISO";
            this.btnRenameGameISO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRenameGameISO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRenameGameISO.UseVisualStyleBackColor = true;
            // 
            // btnDeleteGame
            // 
            this.btnDeleteGame.Enabled = false;
            this.btnDeleteGame.Image = global::GameCube_Backup_Manager.Properties.Resources.eraser_32;
            this.btnDeleteGame.Location = new System.Drawing.Point(38, 48);
            this.btnDeleteGame.Name = "btnDeleteGame";
            this.btnDeleteGame.Size = new System.Drawing.Size(140, 40);
            this.btnDeleteGame.TabIndex = 0;
            this.btnDeleteGame.Text = "Apagar Jogo";
            this.btnDeleteGame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteGame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteGame.UseVisualStyleBackColor = true;
            // 
            // labelGameID
            // 
            this.labelGameID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGameID.AutoSize = true;
            this.labelGameID.Location = new System.Drawing.Point(4, 85);
            this.labelGameID.Name = "labelGameID";
            this.labelGameID.Size = new System.Drawing.Size(52, 13);
            this.labelGameID.TabIndex = 5;
            this.labelGameID.Text = "Game ID:";
            // 
            // labelFile
            // 
            this.labelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(7, 55);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(46, 13);
            this.labelFile.TabIndex = 4;
            this.labelFile.Text = "Arquivo:";
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(16, 25);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(38, 13);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Título:";
            // 
            // txtBoxMainGameID
            // 
            this.txtBoxMainGameID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMainGameID.Location = new System.Drawing.Point(68, 82);
            this.txtBoxMainGameID.Name = "txtBoxMainGameID";
            this.txtBoxMainGameID.ReadOnly = true;
            this.txtBoxMainGameID.Size = new System.Drawing.Size(72, 20);
            this.txtBoxMainGameID.TabIndex = 2;
            // 
            // txtBoxMainGameFileName
            // 
            this.txtBoxMainGameFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMainGameFileName.Location = new System.Drawing.Point(68, 52);
            this.txtBoxMainGameFileName.Name = "txtBoxMainGameFileName";
            this.txtBoxMainGameFileName.ReadOnly = true;
            this.txtBoxMainGameFileName.Size = new System.Drawing.Size(301, 20);
            this.txtBoxMainGameFileName.TabIndex = 1;
            // 
            // txtBoxMainGameName
            // 
            this.txtBoxMainGameName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMainGameName.Location = new System.Drawing.Point(68, 22);
            this.txtBoxMainGameName.Name = "txtBoxMainGameName";
            this.txtBoxMainGameName.ReadOnly = true;
            this.txtBoxMainGameName.Size = new System.Drawing.Size(301, 20);
            this.txtBoxMainGameName.TabIndex = 0;
            // 
            // dgvMainGame
            // 
            this.dgvMainGame.AllowUserToAddRows = false;
            this.dgvMainGame.AllowUserToDeleteRows = false;
            this.dgvMainGame.AllowUserToResizeColumns = false;
            this.dgvMainGame.AllowUserToResizeRows = false;
            this.dgvMainGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMainGame.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMainGame.BackgroundColor = System.Drawing.Color.White;
            this.dgvMainGame.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainGame.Location = new System.Drawing.Point(7, 7);
            this.dgvMainGame.MultiSelect = false;
            this.dgvMainGame.Name = "dgvMainGame";
            this.dgvMainGame.ReadOnly = true;
            this.dgvMainGame.Size = new System.Drawing.Size(726, 682);
            this.dgvMainGame.TabIndex = 2;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectFolder.Location = new System.Drawing.Point(930, 629);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(180, 60);
            this.btnSelectFolder.TabIndex = 3;
            this.btnSelectFolder.Text = "Procurar...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            // 
            // tabMainDisc
            // 
            this.tabMainDisc.Controls.Add(this.BtnListAllFiles);
            this.tabMainDisc.Controls.Add(this.BtnReloadedDevices);
            this.tabMainDisc.Controls.Add(this.groupBox3);
            this.tabMainDisc.Controls.Add(this.dataGridViewFiles);
            this.tabMainDisc.Controls.Add(this.menuStripMainDisc);
            this.tabMainDisc.Location = new System.Drawing.Point(4, 22);
            this.tabMainDisc.Name = "tabMainDisc";
            this.tabMainDisc.Size = new System.Drawing.Size(1173, 695);
            this.tabMainDisc.TabIndex = 6;
            this.tabMainDisc.Text = "Disco";
            this.tabMainDisc.UseVisualStyleBackColor = true;
            // 
            // BtnListAllFiles
            // 
            this.BtnListAllFiles.Location = new System.Drawing.Point(553, 3);
            this.BtnListAllFiles.Name = "BtnListAllFiles";
            this.BtnListAllFiles.Size = new System.Drawing.Size(150, 23);
            this.BtnListAllFiles.TabIndex = 4;
            this.BtnListAllFiles.Text = "Listar Arquivos";
            this.BtnListAllFiles.UseVisualStyleBackColor = true;
            // 
            // BtnReloadedDevices
            // 
            this.BtnReloadedDevices.Location = new System.Drawing.Point(383, 3);
            this.BtnReloadedDevices.Name = "BtnReloadedDevices";
            this.BtnReloadedDevices.Size = new System.Drawing.Size(150, 23);
            this.BtnReloadedDevices.TabIndex = 3;
            this.BtnReloadedDevices.Text = "Recarregar Dispositivos";
            this.BtnReloadedDevices.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.BtnRenameGameID);
            this.groupBox3.Controls.Add(this.BtnDeleteAllGameDisc);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.BtnDeleteGameDisc);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.BtnRenameDirectory);
            this.groupBox3.Location = new System.Drawing.Point(902, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 662);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operações";
            // 
            // BtnRenameGameID
            // 
            this.BtnRenameGameID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRenameGameID.Location = new System.Drawing.Point(41, 188);
            this.BtnRenameGameID.Name = "BtnRenameGameID";
            this.BtnRenameGameID.Size = new System.Drawing.Size(140, 40);
            this.BtnRenameGameID.TabIndex = 10;
            this.BtnRenameGameID.Text = "Alterar Dados do Jogo";
            this.BtnRenameGameID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRenameGameID.UseVisualStyleBackColor = true;
            // 
            // BtnDeleteAllGameDisc
            // 
            this.BtnDeleteAllGameDisc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDeleteAllGameDisc.Location = new System.Drawing.Point(41, 96);
            this.BtnDeleteAllGameDisc.Name = "BtnDeleteAllGameDisc";
            this.BtnDeleteAllGameDisc.Size = new System.Drawing.Size(140, 40);
            this.BtnDeleteAllGameDisc.TabIndex = 9;
            this.BtnDeleteAllGameDisc.Text = "Apagar Todos os Jogos";
            this.BtnDeleteAllGameDisc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDeleteAllGameDisc.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.Location = new System.Drawing.Point(41, 234);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 40);
            this.button3.TabIndex = 8;
            this.button3.Text = "Baixar Todas as Capas";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // BtnDeleteGameDisc
            // 
            this.BtnDeleteGameDisc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDeleteGameDisc.Location = new System.Drawing.Point(41, 50);
            this.BtnDeleteGameDisc.Name = "BtnDeleteGameDisc";
            this.BtnDeleteGameDisc.Size = new System.Drawing.Size(140, 40);
            this.BtnDeleteGameDisc.TabIndex = 5;
            this.BtnDeleteGameDisc.Text = "Apagar Jogo Selecionado";
            this.BtnDeleteGameDisc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDeleteGameDisc.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(41, 280);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 40);
            this.button6.TabIndex = 7;
            this.button6.Text = "Calcular Hash";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // BtnRenameDirectory
            // 
            this.BtnRenameDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRenameDirectory.Location = new System.Drawing.Point(41, 142);
            this.BtnRenameDirectory.Name = "BtnRenameDirectory";
            this.BtnRenameDirectory.Size = new System.Drawing.Size(140, 40);
            this.BtnRenameDirectory.TabIndex = 6;
            this.BtnRenameDirectory.Text = "Renomear Diretório do Jogo";
            this.BtnRenameDirectory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRenameDirectory.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFiles
            // 
            this.dataGridViewFiles.AllowUserToAddRows = false;
            this.dataGridViewFiles.AllowUserToDeleteRows = false;
            this.dataGridViewFiles.AllowUserToResizeRows = false;
            this.dataGridViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFiles.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiles.Location = new System.Drawing.Point(3, 30);
            this.dataGridViewFiles.MultiSelect = false;
            this.dataGridViewFiles.Name = "dataGridViewFiles";
            this.dataGridViewFiles.ReadOnly = true;
            this.dataGridViewFiles.Size = new System.Drawing.Size(891, 662);
            this.dataGridViewFiles.TabIndex = 1;
            // 
            // menuStripMainDisc
            // 
            this.menuStripMainDisc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbDeviceDriveUSB,
            this.tsmiMainDiscSelect,
            this.tsmiMainDiscTools});
            this.menuStripMainDisc.Location = new System.Drawing.Point(0, 0);
            this.menuStripMainDisc.Name = "menuStripMainDisc";
            this.menuStripMainDisc.Size = new System.Drawing.Size(1173, 27);
            this.menuStripMainDisc.TabIndex = 0;
            this.menuStripMainDisc.Text = "menuStrip2";
            // 
            // tscbDeviceDriveUSB
            // 
            this.tscbDeviceDriveUSB.Name = "tscbDeviceDriveUSB";
            this.tscbDeviceDriveUSB.Size = new System.Drawing.Size(121, 23);
            // 
            // tsmiMainDiscSelect
            // 
            this.tsmiMainDiscSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainDiscSelectNone});
            this.tsmiMainDiscSelect.Name = "tsmiMainDiscSelect";
            this.tsmiMainDiscSelect.Size = new System.Drawing.Size(73, 23);
            this.tsmiMainDiscSelect.Text = "Selecionar";
            // 
            // tsmiMainDiscSelectNone
            // 
            this.tsmiMainDiscSelectNone.Name = "tsmiMainDiscSelectNone";
            this.tsmiMainDiscSelectNone.Size = new System.Drawing.Size(121, 22);
            this.tsmiMainDiscSelectNone.Text = "Nenhum";
            // 
            // tsmiMainDiscTools
            // 
            this.tsmiMainDiscTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainDiscRemoveGameSelected,
            this.tsmiMainDiscRemoveAll,
            this.toolStripMenuItem15,
            this.tsmiMainDiscRenameGameDirectory,
            this.toolStripMenuItem16,
            this.tsmiMainDiscDownloadAllCovers,
            this.toolStripMenuItem17,
            this.tsmiMainDiscCalculateHash,
            this.tsmiMainDiscExportGameList});
            this.tsmiMainDiscTools.Name = "tsmiMainDiscTools";
            this.tsmiMainDiscTools.Size = new System.Drawing.Size(84, 23);
            this.tsmiMainDiscTools.Text = "Ferramentas";
            // 
            // tsmiMainDiscRemoveGameSelected
            // 
            this.tsmiMainDiscRemoveGameSelected.Name = "tsmiMainDiscRemoveGameSelected";
            this.tsmiMainDiscRemoveGameSelected.Size = new System.Drawing.Size(222, 22);
            this.tsmiMainDiscRemoveGameSelected.Text = "Apagar Jogo Selecionado";
            // 
            // tsmiMainDiscRemoveAll
            // 
            this.tsmiMainDiscRemoveAll.Name = "tsmiMainDiscRemoveAll";
            this.tsmiMainDiscRemoveAll.Size = new System.Drawing.Size(222, 22);
            this.tsmiMainDiscRemoveAll.Text = "Apagar Todos os Jogos";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(219, 6);
            // 
            // tsmiMainDiscRenameGameDirectory
            // 
            this.tsmiMainDiscRenameGameDirectory.Name = "tsmiMainDiscRenameGameDirectory";
            this.tsmiMainDiscRenameGameDirectory.Size = new System.Drawing.Size(222, 22);
            this.tsmiMainDiscRenameGameDirectory.Text = "Renomear Diretório do Jogo";
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(219, 6);
            // 
            // tsmiMainDiscDownloadAllCovers
            // 
            this.tsmiMainDiscDownloadAllCovers.Name = "tsmiMainDiscDownloadAllCovers";
            this.tsmiMainDiscDownloadAllCovers.Size = new System.Drawing.Size(222, 22);
            this.tsmiMainDiscDownloadAllCovers.Text = "Baixar Todas as Capas";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(219, 6);
            // 
            // tsmiMainDiscCalculateHash
            // 
            this.tsmiMainDiscCalculateHash.Name = "tsmiMainDiscCalculateHash";
            this.tsmiMainDiscCalculateHash.Size = new System.Drawing.Size(222, 22);
            this.tsmiMainDiscCalculateHash.Text = "Calcular Hash";
            // 
            // tsmiMainDiscExportGameList
            // 
            this.tsmiMainDiscExportGameList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainDiscExportGameListCSV,
            this.tsmiMainDiscExportGameListTXT});
            this.tsmiMainDiscExportGameList.Enabled = false;
            this.tsmiMainDiscExportGameList.Name = "tsmiMainDiscExportGameList";
            this.tsmiMainDiscExportGameList.Size = new System.Drawing.Size(222, 22);
            this.tsmiMainDiscExportGameList.Text = "Exportar lista de jogos";
            // 
            // tsmiMainDiscExportGameListCSV
            // 
            this.tsmiMainDiscExportGameListCSV.Name = "tsmiMainDiscExportGameListCSV";
            this.tsmiMainDiscExportGameListCSV.Size = new System.Drawing.Size(168, 22);
            this.tsmiMainDiscExportGameListCSV.Text = "Exportar para CSV";
            // 
            // tsmiMainDiscExportGameListTXT
            // 
            this.tsmiMainDiscExportGameListTXT.Name = "tsmiMainDiscExportGameListTXT";
            this.tsmiMainDiscExportGameListTXT.Size = new System.Drawing.Size(168, 22);
            this.tsmiMainDiscExportGameListTXT.Text = "Exportar para TXT";
            // 
            // tabMainDatabase
            // 
            this.tabMainDatabase.Controls.Add(this.toolStripMainDatabase);
            this.tabMainDatabase.Controls.Add(this.dgvMainDatabase);
            this.tabMainDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabMainDatabase.Name = "tabMainDatabase";
            this.tabMainDatabase.Size = new System.Drawing.Size(1173, 695);
            this.tabMainDatabase.TabIndex = 5;
            this.tabMainDatabase.Text = "Base de Dados";
            this.tabMainDatabase.UseVisualStyleBackColor = true;
            // 
            // toolStripMainDatabase
            // 
            this.toolStripMainDatabase.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMainDatabase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbMainDatabaseTools});
            this.toolStripMainDatabase.Location = new System.Drawing.Point(0, 0);
            this.toolStripMainDatabase.Name = "toolStripMainDatabase";
            this.toolStripMainDatabase.Size = new System.Drawing.Size(1173, 25);
            this.toolStripMainDatabase.TabIndex = 1;
            this.toolStripMainDatabase.Text = "Database";
            // 
            // tsddbMainDatabaseTools
            // 
            this.tsddbMainDatabaseTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbMainDatabaseUpdateGameTDB,
            this.toolStripSeparator1,
            this.tsddbMainDatabaseExportGameList});
            this.tsddbMainDatabaseTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbMainDatabaseTools.Name = "tsddbMainDatabaseTools";
            this.tsddbMainDatabaseTools.Size = new System.Drawing.Size(85, 22);
            this.tsddbMainDatabaseTools.Text = "Ferramentas";
            // 
            // tsddbMainDatabaseUpdateGameTDB
            // 
            this.tsddbMainDatabaseUpdateGameTDB.Enabled = false;
            this.tsddbMainDatabaseUpdateGameTDB.Name = "tsddbMainDatabaseUpdateGameTDB";
            this.tsddbMainDatabaseUpdateGameTDB.Size = new System.Drawing.Size(207, 22);
            this.tsddbMainDatabaseUpdateGameTDB.Text = "Atualização do GameTDB";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            // 
            // tsddbMainDatabaseExportGameList
            // 
            this.tsddbMainDatabaseExportGameList.Enabled = false;
            this.tsddbMainDatabaseExportGameList.Name = "tsddbMainDatabaseExportGameList";
            this.tsddbMainDatabaseExportGameList.Size = new System.Drawing.Size(207, 22);
            this.tsddbMainDatabaseExportGameList.Text = "Exportar lista de jogos";
            // 
            // dgvMainDatabase
            // 
            this.dgvMainDatabase.AllowUserToAddRows = false;
            this.dgvMainDatabase.AllowUserToDeleteRows = false;
            this.dgvMainDatabase.AllowUserToOrderColumns = true;
            this.dgvMainDatabase.AllowUserToResizeColumns = false;
            this.dgvMainDatabase.AllowUserToResizeRows = false;
            this.dgvMainDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMainDatabase.BackgroundColor = System.Drawing.Color.White;
            this.dgvMainDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainDatabase.Location = new System.Drawing.Point(3, 28);
            this.dgvMainDatabase.MultiSelect = false;
            this.dgvMainDatabase.Name = "dgvMainDatabase";
            this.dgvMainDatabase.ReadOnly = true;
            this.dgvMainDatabase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMainDatabase.Size = new System.Drawing.Size(1028, 664);
            this.dgvMainDatabase.TabIndex = 0;
            // 
            // tabMainLog
            // 
            this.tabMainLog.Controls.Add(this.toolStripMainLog);
            this.tabMainLog.Controls.Add(this.txtDebugLog);
            this.tabMainLog.Location = new System.Drawing.Point(4, 22);
            this.tabMainLog.Name = "tabMainLog";
            this.tabMainLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainLog.Size = new System.Drawing.Size(1173, 695);
            this.tabMainLog.TabIndex = 2;
            this.tabMainLog.Text = "Log";
            this.tabMainLog.UseVisualStyleBackColor = true;
            // 
            // toolStripMainLog
            // 
            this.toolStripMainLog.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMainLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbMainLogTools,
            this.tsddbMainLogDebug});
            this.toolStripMainLog.Location = new System.Drawing.Point(3, 3);
            this.toolStripMainLog.Name = "toolStripMainLog";
            this.toolStripMainLog.ShowItemToolTips = false;
            this.toolStripMainLog.Size = new System.Drawing.Size(1167, 25);
            this.toolStripMainLog.TabIndex = 2;
            this.toolStripMainLog.Text = "Log";
            // 
            // tsddbMainLogTools
            // 
            this.tsddbMainLogTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbMainLogClear,
            this.toolStripSeparator2,
            this.tsddbMainLogExport});
            this.tsddbMainLogTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbMainLogTools.Name = "tsddbMainLogTools";
            this.tsddbMainLogTools.Size = new System.Drawing.Size(85, 22);
            this.tsddbMainLogTools.Text = "Ferramentas";
            // 
            // tsddbMainLogClear
            // 
            this.tsddbMainLogClear.Name = "tsddbMainLogClear";
            this.tsddbMainLogClear.Size = new System.Drawing.Size(150, 22);
            this.tsddbMainLogClear.Text = "Limpar Log...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // tsddbMainLogExport
            // 
            this.tsddbMainLogExport.Name = "tsddbMainLogExport";
            this.tsddbMainLogExport.Size = new System.Drawing.Size(150, 22);
            this.tsddbMainLogExport.Text = "Exportar Log...";
            // 
            // tsddbMainLogDebug
            // 
            this.tsddbMainLogDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbMainLogDebugErrorsOnly,
            this.tsddbMainLogDebugNormal,
            this.tsddbMainLogDebugComplete});
            this.tsddbMainLogDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbMainLogDebug.Name = "tsddbMainLogDebug";
            this.tsddbMainLogDebug.Size = new System.Drawing.Size(101, 22);
            this.tsddbMainLogDebug.Text = "Nível de Debug";
            // 
            // tsddbMainLogDebugErrorsOnly
            // 
            this.tsddbMainLogDebugErrorsOnly.Name = "tsddbMainLogDebugErrorsOnly";
            this.tsddbMainLogDebugErrorsOnly.Size = new System.Drawing.Size(163, 22);
            this.tsddbMainLogDebugErrorsOnly.Text = "Somente erros";
            // 
            // tsddbMainLogDebugNormal
            // 
            this.tsddbMainLogDebugNormal.Checked = true;
            this.tsddbMainLogDebugNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsddbMainLogDebugNormal.Name = "tsddbMainLogDebugNormal";
            this.tsddbMainLogDebugNormal.Size = new System.Drawing.Size(163, 22);
            this.tsddbMainLogDebugNormal.Text = "Normal";
            // 
            // tsddbMainLogDebugComplete
            // 
            this.tsddbMainLogDebugComplete.Name = "tsddbMainLogDebugComplete";
            this.tsddbMainLogDebugComplete.Size = new System.Drawing.Size(163, 22);
            this.tsddbMainLogDebugComplete.Text = "Debug completo";
            // 
            // txtDebugLog
            // 
            this.txtDebugLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugLog.BackColor = System.Drawing.Color.White;
            this.txtDebugLog.Location = new System.Drawing.Point(7, 31);
            this.txtDebugLog.Multiline = true;
            this.txtDebugLog.Name = "txtDebugLog";
            this.txtDebugLog.ReadOnly = true;
            this.txtDebugLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDebugLog.Size = new System.Drawing.Size(991, 658);
            this.txtDebugLog.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 821);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameCube Backup Manager - Alpha 0.0.0-2022";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.grpBoxArt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameDisc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameCover3D)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabMainFile.ResumeLayout(false);
            this.tabMainFile.PerformLayout();
            this.grpStatistics.ResumeLayout(false);
            this.grpStatistics.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameID)).EndInit();
            this.grpOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainGame)).EndInit();
            this.tabMainDisc.ResumeLayout(false);
            this.tabMainDisc.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).EndInit();
            this.menuStripMainDisc.ResumeLayout(false);
            this.menuStripMainDisc.PerformLayout();
            this.tabMainDatabase.ResumeLayout(false);
            this.tabMainDatabase.PerformLayout();
            this.toolStripMainDatabase.ResumeLayout(false);
            this.toolStripMainDatabase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainDatabase)).EndInit();
            this.tabMainLog.ResumeLayout(false);
            this.tabMainLog.PerformLayout();
            this.toolStripMainLog.ResumeLayout(false);
            this.toolStripMainLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainUpdateGameList;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainExportGameList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainCovers;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainView;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainBoxArt;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainBoxArtEnable;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainBoxArtDisable;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainSettings;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox grpBoxArt;
        private System.Windows.Forms.PictureBox pictureBoxGameDisc;
        private System.Windows.Forms.PictureBox pictureBoxGameCover3D;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMainFile;
        private System.Windows.Forms.Label labelPasta;
        private System.Windows.Forms.Label labelOpenFolder;
        private System.Windows.Forms.GroupBox grpStatistics;
        private System.Windows.Forms.Label lblSizeTotal;
        private System.Windows.Forms.Label lblSizeApps;
        private System.Windows.Forms.Label lblSizeISO;
        private System.Windows.Forms.Label lblQuantTotal;
        private System.Windows.Forms.Label lblQuantApps;
        private System.Windows.Forms.Label lblQuantISO;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelAPPs;
        private System.Windows.Forms.Label labelGC_ISO;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtBoxMainCountryCode;
        private System.Windows.Forms.TextBox txtBoxMainDiscID;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.PictureBox pictureBoxGameID;
        private System.Windows.Forms.GroupBox grpOperations;
        private System.Windows.Forms.Button btnGameInstallScrub;
        private System.Windows.Forms.Button btnGameInstallExactCopy;
        private System.Windows.Forms.Button btnCheatEditor;
        private System.Windows.Forms.Button btnManagerART;
        private System.Windows.Forms.Button btnEditGameCFG;
        private System.Windows.Forms.Button btnHashGame;
        private System.Windows.Forms.Button btnRenameGameISO;
        private System.Windows.Forms.Button btnDeleteGame;
        private System.Windows.Forms.Label labelGameID;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox txtBoxMainGameID;
        private System.Windows.Forms.TextBox txtBoxMainGameFileName;
        private System.Windows.Forms.TextBox txtBoxMainGameName;
        private System.Windows.Forms.DataGridView dgvMainGame;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TabPage tabMainDisc;
        private System.Windows.Forms.Button BtnListAllFiles;
        private System.Windows.Forms.Button BtnReloadedDevices;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnRenameGameID;
        private System.Windows.Forms.Button BtnDeleteAllGameDisc;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button BtnDeleteGameDisc;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button BtnRenameDirectory;
        private System.Windows.Forms.DataGridView dataGridViewFiles;
        private System.Windows.Forms.MenuStrip menuStripMainDisc;
        private System.Windows.Forms.ToolStripComboBox tscbDeviceDriveUSB;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainDiscSelect;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainDiscSelectNone;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainDiscTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainDiscRemoveGameSelected;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainDiscRemoveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainDiscRenameGameDirectory;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainDiscDownloadAllCovers;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainDiscCalculateHash;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainDiscExportGameList;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainDiscExportGameListCSV;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainDiscExportGameListTXT;
        private System.Windows.Forms.TabPage tabMainDatabase;
        private System.Windows.Forms.ToolStrip toolStripMainDatabase;
        private System.Windows.Forms.ToolStripDropDownButton tsddbMainDatabaseTools;
        private System.Windows.Forms.ToolStripMenuItem tsddbMainDatabaseUpdateGameTDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsddbMainDatabaseExportGameList;
        private System.Windows.Forms.DataGridView dgvMainDatabase;
        private System.Windows.Forms.TabPage tabMainLog;
        private System.Windows.Forms.ToolStrip toolStripMainLog;
        private System.Windows.Forms.ToolStripDropDownButton tsddbMainLogTools;
        private System.Windows.Forms.ToolStripMenuItem tsddbMainLogClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsddbMainLogExport;
        private System.Windows.Forms.ToolStripDropDownButton tsddbMainLogDebug;
        private System.Windows.Forms.ToolStripMenuItem tsddbMainLogDebugErrorsOnly;
        private System.Windows.Forms.ToolStripMenuItem tsddbMainLogDebugNormal;
        private System.Windows.Forms.ToolStripMenuItem tsddbMainLogDebugComplete;
        private System.Windows.Forms.TextBox txtDebugLog;
    }
}

