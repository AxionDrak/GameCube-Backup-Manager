
namespace GCBM.tools
{
    partial class frmBurnMedia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBurnMedia));
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBurn = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.labelStatusText = new System.Windows.Forms.Label();
            this.btnBurn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelMediaType = new System.Windows.Forms.Label();
            this.btnDetectMedia = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTotalSize = new System.Windows.Forms.Label();
            this.pbCapacity = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbVerification = new System.Windows.Forms.ComboBox();
            this.labelVerification = new System.Windows.Forms.Label();
            this.chkEject = new System.Windows.Forms.CheckBox();
            this.chkCloseMedia = new System.Windows.Forms.CheckBox();
            this.tbVolumeLabel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoveFiles = new System.Windows.Forms.Button();
            this.btnAddFolders = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.tabPageFormat = new System.Windows.Forms.TabPage();
            this.chkQuickFormat = new System.Windows.Forms.CheckBox();
            this.chkEjectFormat = new System.Windows.Forms.CheckBox();
            this.pbFormat = new System.Windows.Forms.ProgressBar();
            this.labelFormatStatusText = new System.Windows.Forms.Label();
            this.btnFormat = new System.Windows.Forms.Button();
            this.supportedMediaLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.bgBurnWorker = new System.ComponentModel.BackgroundWorker();
            this.bgFormatWorker = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPageBurn.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Drive:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageBurn);
            this.tabControl1.Controls.Add(this.tabPageFormat);
            this.tabControl1.Location = new System.Drawing.Point(12, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 344);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPageBurn
            // 
            this.tabPageBurn.Controls.Add(this.groupBox3);
            this.tabPageBurn.Controls.Add(this.groupBox2);
            this.tabPageBurn.Controls.Add(this.groupBox1);
            this.tabPageBurn.Location = new System.Drawing.Point(4, 22);
            this.tabPageBurn.Name = "tabPageBurn";
            this.tabPageBurn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBurn.Size = new System.Drawing.Size(632, 318);
            this.tabPageBurn.TabIndex = 0;
            this.tabPageBurn.Text = "Gravar Disco";
            this.tabPageBurn.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbStatus);
            this.groupBox3.Controls.Add(this.labelStatusText);
            this.groupBox3.Controls.Add(this.btnBurn);
            this.groupBox3.Location = new System.Drawing.Point(377, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 169);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Progresso";
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(12, 70);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(224, 16);
            this.pbStatus.TabIndex = 8;
            // 
            // labelStatusText
            // 
            this.labelStatusText.Location = new System.Drawing.Point(9, 18);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(227, 45);
            this.labelStatusText.TabIndex = 7;
            this.labelStatusText.Text = "status";
            this.labelStatusText.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnBurn
            // 
            this.btnBurn.Image = global::GCBM.Properties.Resources.burn_cd_32;
            this.btnBurn.Location = new System.Drawing.Point(68, 92);
            this.btnBurn.Name = "btnBurn";
            this.btnBurn.Size = new System.Drawing.Size(110, 45);
            this.btnBurn.TabIndex = 6;
            this.btnBurn.Text = "Gravar";
            this.btnBurn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBurn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBurn.UseVisualStyleBackColor = true;
            this.btnBurn.Click += new System.EventHandler(this.btnBurn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelMediaType);
            this.groupBox2.Controls.Add(this.btnDetectMedia);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelTotalSize);
            this.groupBox2.Controls.Add(this.pbCapacity);
            this.groupBox2.Location = new System.Drawing.Point(377, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 132);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de mídia selecionado:";
            // 
            // labelMediaType
            // 
            this.labelMediaType.Location = new System.Drawing.Point(117, 20);
            this.labelMediaType.Name = "labelMediaType";
            this.labelMediaType.Size = new System.Drawing.Size(119, 40);
            this.labelMediaType.TabIndex = 10;
            this.labelMediaType.Text = "Pressione o botão \'Detectar Mídia\'.";
            // 
            // btnDetectMedia
            // 
            this.btnDetectMedia.Location = new System.Drawing.Point(12, 20);
            this.btnDetectMedia.Name = "btnDetectMedia";
            this.btnDetectMedia.Size = new System.Drawing.Size(98, 28);
            this.btnDetectMedia.TabIndex = 9;
            this.btnDetectMedia.Text = "Detectar Mídia";
            this.btnDetectMedia.UseVisualStyleBackColor = true;
            this.btnDetectMedia.Click += new System.EventHandler(this.btnDetectMedia_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "0";
            // 
            // labelTotalSize
            // 
            this.labelTotalSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalSize.AutoSize = true;
            this.labelTotalSize.Location = new System.Drawing.Point(193, 73);
            this.labelTotalSize.Name = "labelTotalSize";
            this.labelTotalSize.Size = new System.Drawing.Size(32, 13);
            this.labelTotalSize.TabIndex = 7;
            this.labelTotalSize.Text = "0 MB";
            // 
            // pbCapacity
            // 
            this.pbCapacity.Location = new System.Drawing.Point(6, 92);
            this.pbCapacity.Name = "pbCapacity";
            this.pbCapacity.Size = new System.Drawing.Size(230, 12);
            this.pbCapacity.Step = 1;
            this.pbCapacity.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbCapacity.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbVerification);
            this.groupBox1.Controls.Add(this.labelVerification);
            this.groupBox1.Controls.Add(this.chkEject);
            this.groupBox1.Controls.Add(this.chkCloseMedia);
            this.groupBox1.Controls.Add(this.tbVolumeLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnRemoveFiles);
            this.groupBox1.Controls.Add(this.btnAddFolders);
            this.groupBox1.Controls.Add(this.btnAddFiles);
            this.groupBox1.Controls.Add(this.lbFiles);
            this.groupBox1.Location = new System.Drawing.Point(11, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 307);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arquivos para gravar";
            // 
            // cbVerification
            // 
            this.cbVerification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVerification.FormattingEnabled = true;
            this.cbVerification.Items.AddRange(new object[] {
            "Nenhum",
            "Rapido",
            "Completo"});
            this.cbVerification.Location = new System.Drawing.Point(79, 275);
            this.cbVerification.Name = "cbVerification";
            this.cbVerification.Size = new System.Drawing.Size(121, 21);
            this.cbVerification.TabIndex = 9;
            // 
            // labelVerification
            // 
            this.labelVerification.AutoSize = true;
            this.labelVerification.Location = new System.Drawing.Point(10, 278);
            this.labelVerification.Name = "labelVerification";
            this.labelVerification.Size = new System.Drawing.Size(63, 13);
            this.labelVerification.TabIndex = 8;
            this.labelVerification.Text = "Verificação:";
            // 
            // chkEject
            // 
            this.chkEject.AutoSize = true;
            this.chkEject.Checked = true;
            this.chkEject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEject.Location = new System.Drawing.Point(185, 243);
            this.chkEject.Name = "chkEject";
            this.chkEject.Size = new System.Drawing.Size(132, 17);
            this.chkEject.TabIndex = 7;
            this.chkEject.Text = "Ejetar quando terminar";
            this.chkEject.UseVisualStyleBackColor = true;
            // 
            // chkCloseMedia
            // 
            this.chkCloseMedia.AutoSize = true;
            this.chkCloseMedia.Checked = true;
            this.chkCloseMedia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCloseMedia.Location = new System.Drawing.Point(48, 243);
            this.chkCloseMedia.Name = "chkCloseMedia";
            this.chkCloseMedia.Size = new System.Drawing.Size(88, 17);
            this.chkCloseMedia.TabIndex = 6;
            this.chkCloseMedia.Text = "Fechar mídia";
            this.chkCloseMedia.UseVisualStyleBackColor = true;
            // 
            // tbVolumeLabel
            // 
            this.tbVolumeLabel.Location = new System.Drawing.Point(109, 208);
            this.tbVolumeLabel.Name = "tbVolumeLabel";
            this.tbVolumeLabel.Size = new System.Drawing.Size(242, 20);
            this.tbVolumeLabel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rótulo do volume:";
            // 
            // btnRemoveFiles
            // 
            this.btnRemoveFiles.Image = global::GCBM.Properties.Resources.delete_file_32;
            this.btnRemoveFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveFiles.Location = new System.Drawing.Point(242, 149);
            this.btnRemoveFiles.Name = "btnRemoveFiles";
            this.btnRemoveFiles.Size = new System.Drawing.Size(110, 45);
            this.btnRemoveFiles.TabIndex = 3;
            this.btnRemoveFiles.Text = "Remover Arquivo(s)...";
            this.btnRemoveFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveFiles.UseVisualStyleBackColor = true;
            this.btnRemoveFiles.Click += new System.EventHandler(this.btnRemoveFiles_Click);
            // 
            // btnAddFolders
            // 
            this.btnAddFolders.Image = global::GCBM.Properties.Resources.add_folder_32;
            this.btnAddFolders.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddFolders.Location = new System.Drawing.Point(126, 149);
            this.btnAddFolders.Name = "btnAddFolders";
            this.btnAddFolders.Size = new System.Drawing.Size(110, 45);
            this.btnAddFolders.TabIndex = 2;
            this.btnAddFolders.Text = "Adicionar Diretórios...";
            this.btnAddFolders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFolders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddFolders.UseVisualStyleBackColor = true;
            this.btnAddFolders.Click += new System.EventHandler(this.btnAddFolders_Click);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Image = global::GCBM.Properties.Resources.add_file_32;
            this.btnAddFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddFiles.Location = new System.Drawing.Point(10, 149);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(110, 45);
            this.btnAddFiles.TabIndex = 1;
            this.btnAddFiles.Text = "Adicionar Arquivos...";
            this.btnAddFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // lbFiles
            // 
            this.lbFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.ItemHeight = 24;
            this.lbFiles.Location = new System.Drawing.Point(10, 19);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(341, 124);
            this.lbFiles.TabIndex = 0;
            // 
            // tabPageFormat
            // 
            this.tabPageFormat.Controls.Add(this.chkQuickFormat);
            this.tabPageFormat.Controls.Add(this.chkEjectFormat);
            this.tabPageFormat.Controls.Add(this.pbFormat);
            this.tabPageFormat.Controls.Add(this.labelFormatStatusText);
            this.tabPageFormat.Controls.Add(this.btnFormat);
            this.tabPageFormat.Location = new System.Drawing.Point(4, 22);
            this.tabPageFormat.Name = "tabPageFormat";
            this.tabPageFormat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFormat.Size = new System.Drawing.Size(632, 318);
            this.tabPageFormat.TabIndex = 1;
            this.tabPageFormat.Text = "Formatar Disco";
            this.tabPageFormat.UseVisualStyleBackColor = true;
            // 
            // chkQuickFormat
            // 
            this.chkQuickFormat.AutoSize = true;
            this.chkQuickFormat.Checked = true;
            this.chkQuickFormat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkQuickFormat.Location = new System.Drawing.Point(226, 52);
            this.chkQuickFormat.Name = "chkQuickFormat";
            this.chkQuickFormat.Size = new System.Drawing.Size(119, 17);
            this.chkQuickFormat.TabIndex = 14;
            this.chkQuickFormat.Text = "Formatação Rápida";
            this.chkQuickFormat.UseVisualStyleBackColor = true;
            // 
            // chkEjectFormat
            // 
            this.chkEjectFormat.AutoSize = true;
            this.chkEjectFormat.Checked = true;
            this.chkEjectFormat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEjectFormat.Location = new System.Drawing.Point(226, 28);
            this.chkEjectFormat.Name = "chkEjectFormat";
            this.chkEjectFormat.Size = new System.Drawing.Size(132, 17);
            this.chkEjectFormat.TabIndex = 12;
            this.chkEjectFormat.Text = "Ejetar quando terminar";
            this.chkEjectFormat.UseVisualStyleBackColor = true;
            // 
            // pbFormat
            // 
            this.pbFormat.Location = new System.Drawing.Point(140, 222);
            this.pbFormat.Name = "pbFormat";
            this.pbFormat.Size = new System.Drawing.Size(318, 16);
            this.pbFormat.TabIndex = 13;
            // 
            // labelFormatStatusText
            // 
            this.labelFormatStatusText.Location = new System.Drawing.Point(139, 160);
            this.labelFormatStatusText.Name = "labelFormatStatusText";
            this.labelFormatStatusText.Size = new System.Drawing.Size(321, 55);
            this.labelFormatStatusText.TabIndex = 11;
            this.labelFormatStatusText.Text = "status";
            this.labelFormatStatusText.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnFormat
            // 
            this.btnFormat.Image = global::GCBM.Properties.Resources.format_dvd_32;
            this.btnFormat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFormat.Location = new System.Drawing.Point(244, 101);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(110, 45);
            this.btnFormat.TabIndex = 10;
            this.btnFormat.Text = "&Formatar Disco";
            this.btnFormat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // supportedMediaLabel
            // 
            this.supportedMediaLabel.Location = new System.Drawing.Point(384, 9);
            this.supportedMediaLabel.Name = "supportedMediaLabel";
            this.supportedMediaLabel.Size = new System.Drawing.Size(260, 57);
            this.supportedMediaLabel.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mídia(s) Suportada(s):";
            // 
            // cbDevices
            // 
            this.cbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(65, 14);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(196, 21);
            this.cbDevices.TabIndex = 17;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            // 
            // ofd
            // 
            this.ofd.Filter = "Arquivo ISO|*.iso|Arquivos GCM|*.gcm";
            // 
            // bgBurnWorker
            // 
            this.bgBurnWorker.WorkerReportsProgress = true;
            this.bgBurnWorker.WorkerSupportsCancellation = true;
            // 
            // bgFormatWorker
            // 
            this.bgFormatWorker.WorkerReportsProgress = true;
            this.bgFormatWorker.WorkerSupportsCancellation = true;
            // 
            // frmBurnMedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 408);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.supportedMediaLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBurnMedia";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gravar Mídia CD/DVD";
            this.Load += new System.EventHandler(this.frmBurnMedia_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageBurn.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageFormat.ResumeLayout(false);
            this.tabPageFormat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBurn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar pbStatus;
        private System.Windows.Forms.Label labelStatusText;
        private System.Windows.Forms.Button btnBurn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelMediaType;
        private System.Windows.Forms.Button btnDetectMedia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTotalSize;
        private System.Windows.Forms.ProgressBar pbCapacity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbVerification;
        private System.Windows.Forms.Label labelVerification;
        private System.Windows.Forms.CheckBox chkEject;
        private System.Windows.Forms.CheckBox chkCloseMedia;
        private System.Windows.Forms.TextBox tbVolumeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemoveFiles;
        private System.Windows.Forms.Button btnAddFolders;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.TabPage tabPageFormat;
        private System.Windows.Forms.CheckBox chkQuickFormat;
        private System.Windows.Forms.CheckBox chkEjectFormat;
        private System.Windows.Forms.ProgressBar pbFormat;
        private System.Windows.Forms.Label labelFormatStatusText;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Label supportedMediaLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.ComponentModel.BackgroundWorker bgBurnWorker;
        private System.ComponentModel.BackgroundWorker bgFormatWorker;
    }
}