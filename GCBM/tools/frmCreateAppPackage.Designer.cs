
namespace GCBM.tools
{
    partial class frmCreateAppPackage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateAppPackage));
            this.btnClear = new System.Windows.Forms.Button();
            this.grbExtra = new System.Windows.Forms.GroupBox();
            this.rbCreateNwb = new System.Windows.Forms.RadioButton();
            this.rbCreateZip = new System.Windows.Forms.RadioButton();
            this.chkIncludeExtra = new System.Windows.Forms.CheckBox();
            this.btnSearchExtras = new System.Windows.Forms.Button();
            this.lblMainExtra = new System.Windows.Forms.Label();
            this.tbExtra = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreatePackage = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.lblMainPackage = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.fbdCreatePackage = new System.Windows.Forms.FolderBrowserDialog();
            this.grbExtra.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Image = global::GCBM.Properties.Resources.eraser_16;
            this.btnClear.Location = new System.Drawing.Point(353, 91);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 51;
            this.btnClear.Text = "Limpar";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grbExtra
            // 
            this.grbExtra.Controls.Add(this.rbCreateNwb);
            this.grbExtra.Controls.Add(this.rbCreateZip);
            this.grbExtra.Controls.Add(this.chkIncludeExtra);
            this.grbExtra.Location = new System.Drawing.Point(12, 87);
            this.grbExtra.Name = "grbExtra";
            this.grbExtra.Size = new System.Drawing.Size(335, 106);
            this.grbExtra.TabIndex = 50;
            this.grbExtra.TabStop = false;
            this.grbExtra.Text = "Ajustes";
            // 
            // rbCreateNwb
            // 
            this.rbCreateNwb.AutoSize = true;
            this.rbCreateNwb.Location = new System.Drawing.Point(17, 70);
            this.rbCreateNwb.Name = "rbCreateNwb";
            this.rbCreateNwb.Size = new System.Drawing.Size(111, 17);
            this.rbCreateNwb.TabIndex = 41;
            this.rbCreateNwb.Text = "Criar pacote NWB";
            this.rbCreateNwb.UseVisualStyleBackColor = true;
            // 
            // rbCreateZip
            // 
            this.rbCreateZip.AutoSize = true;
            this.rbCreateZip.Checked = true;
            this.rbCreateZip.Location = new System.Drawing.Point(17, 52);
            this.rbCreateZip.Name = "rbCreateZip";
            this.rbCreateZip.Size = new System.Drawing.Size(102, 17);
            this.rbCreateZip.TabIndex = 40;
            this.rbCreateZip.TabStop = true;
            this.rbCreateZip.Text = "Criar pacote ZIP";
            this.rbCreateZip.UseVisualStyleBackColor = true;
            // 
            // chkIncludeExtra
            // 
            this.chkIncludeExtra.AutoSize = true;
            this.chkIncludeExtra.Location = new System.Drawing.Point(17, 29);
            this.chkIncludeExtra.Name = "chkIncludeExtra";
            this.chkIncludeExtra.Size = new System.Drawing.Size(171, 17);
            this.chkIncludeExtra.TabIndex = 39;
            this.chkIncludeExtra.Text = "Incluir pastas e arquivos extras";
            this.chkIncludeExtra.UseVisualStyleBackColor = true;
            this.chkIncludeExtra.CheckedChanged += new System.EventHandler(this.chkIncludeExtra_CheckedChanged);
            // 
            // btnSearchExtras
            // 
            this.btnSearchExtras.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchExtras.Image")));
            this.btnSearchExtras.Location = new System.Drawing.Point(353, 55);
            this.btnSearchExtras.Name = "btnSearchExtras";
            this.btnSearchExtras.Size = new System.Drawing.Size(100, 30);
            this.btnSearchExtras.TabIndex = 49;
            this.btnSearchExtras.Text = "Procurar...";
            this.btnSearchExtras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchExtras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchExtras.UseVisualStyleBackColor = true;
            this.btnSearchExtras.Click += new System.EventHandler(this.btnSearchExtras_Click);
            // 
            // lblMainExtra
            // 
            this.lblMainExtra.AutoSize = true;
            this.lblMainExtra.Location = new System.Drawing.Point(12, 45);
            this.lblMainExtra.Name = "lblMainExtra";
            this.lblMainExtra.Size = new System.Drawing.Size(125, 13);
            this.lblMainExtra.TabIndex = 48;
            this.lblMainExtra.Text = "Pastas e arquivos extras:";
            // 
            // tbExtra
            // 
            this.tbExtra.BackColor = System.Drawing.Color.White;
            this.tbExtra.Location = new System.Drawing.Point(12, 61);
            this.tbExtra.Name = "tbExtra";
            this.tbExtra.ReadOnly = true;
            this.tbExtra.Size = new System.Drawing.Size(335, 20);
            this.tbExtra.TabIndex = 47;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::GCBM.Properties.Resources.cancel_16;
            this.btnClose.Location = new System.Drawing.Point(353, 163);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Fechar";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreatePackage
            // 
            this.btnCreatePackage.Image = global::GCBM.Properties.Resources.box_16;
            this.btnCreatePackage.Location = new System.Drawing.Point(353, 127);
            this.btnCreatePackage.Name = "btnCreatePackage";
            this.btnCreatePackage.Size = new System.Drawing.Size(100, 30);
            this.btnCreatePackage.TabIndex = 45;
            this.btnCreatePackage.Text = "Criar Pacote";
            this.btnCreatePackage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreatePackage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreatePackage.UseVisualStyleBackColor = true;
            this.btnCreatePackage.Click += new System.EventHandler(this.btnCreatePackage_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(353, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 44;
            this.btnSearch.Text = "Procurar...";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbDirectory
            // 
            this.tbDirectory.BackColor = System.Drawing.Color.White;
            this.tbDirectory.Location = new System.Drawing.Point(12, 25);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.ReadOnly = true;
            this.tbDirectory.Size = new System.Drawing.Size(335, 20);
            this.tbDirectory.TabIndex = 43;
            this.tbDirectory.TextChanged += new System.EventHandler(this.tbDirectory_TextChanged);
            // 
            // lblMainPackage
            // 
            this.lblMainPackage.AutoSize = true;
            this.lblMainPackage.Location = new System.Drawing.Point(12, 9);
            this.lblMainPackage.Name = "lblMainPackage";
            this.lblMainPackage.Size = new System.Drawing.Size(118, 13);
            this.lblMainPackage.TabIndex = 42;
            this.lblMainPackage.Text = "Pasta principal do APP:";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Visible = true;
            // 
            // fbdCreatePackage
            // 
            this.fbdCreatePackage.Description = "Selecione a pasta que contém o app:";
            this.fbdCreatePackage.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdCreatePackage.ShowNewFolderButton = false;
            // 
            // frmCreateAppPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 201);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grbExtra);
            this.Controls.Add(this.btnSearchExtras);
            this.Controls.Add(this.lblMainExtra);
            this.Controls.Add(this.tbExtra);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreatePackage);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbDirectory);
            this.Controls.Add(this.lblMainPackage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateAppPackage";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Criar Pacote APP";
            this.grbExtra.ResumeLayout(false);
            this.grbExtra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grbExtra;
        private System.Windows.Forms.RadioButton rbCreateNwb;
        private System.Windows.Forms.RadioButton rbCreateZip;
        private System.Windows.Forms.CheckBox chkIncludeExtra;
        private System.Windows.Forms.Button btnSearchExtras;
        private System.Windows.Forms.Label lblMainExtra;
        private System.Windows.Forms.TextBox tbExtra;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreatePackage;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Label lblMainPackage;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.FolderBrowserDialog fbdCreatePackage;
    }
}