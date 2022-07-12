
using System.ComponentModel;
using System.Windows.Forms;

namespace GCBM.tools
{
    partial class frmManageApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageApp));
            this.btnListApp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPackageApp = new System.Windows.Forms.Button();
            this.btnInstallApp = new System.Windows.Forms.Button();
            this.btnRemoveApp = new System.Windows.Forms.Button();
            this.dgvAppList = new System.Windows.Forms.DataGridView();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListApp
            // 
            this.btnListApp.Image = global::GCBM.Properties.Resources.open_folder_32;
            this.btnListApp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListApp.Location = new System.Drawing.Point(12, 241);
            this.btnListApp.Name = "btnListApp";
            this.btnListApp.Size = new System.Drawing.Size(120, 45);
            this.btnListApp.TabIndex = 19;
            this.btnListApp.Text = "Listar APP\'s";
            this.btnListApp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListApp.UseVisualStyleBackColor = true;
            this.btnListApp.Click += new System.EventHandler(this.btnListApp_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::GCBM.Properties.Resources.cancel_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(516, 241);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 45);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Fechar";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPackageApp
            // 
            this.btnPackageApp.Image = global::GCBM.Properties.Resources.compact_file_32;
            this.btnPackageApp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPackageApp.Location = new System.Drawing.Point(390, 241);
            this.btnPackageApp.Name = "btnPackageApp";
            this.btnPackageApp.Size = new System.Drawing.Size(120, 45);
            this.btnPackageApp.TabIndex = 17;
            this.btnPackageApp.Text = "Empacotar APP";
            this.btnPackageApp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPackageApp.UseVisualStyleBackColor = true;
            this.btnPackageApp.Click += new System.EventHandler(this.btnPackageApp_Click);
            // 
            // btnInstallApp
            // 
            this.btnInstallApp.Enabled = false;
            this.btnInstallApp.Image = global::GCBM.Properties.Resources.install_software_32;
            this.btnInstallApp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInstallApp.Location = new System.Drawing.Point(138, 241);
            this.btnInstallApp.Name = "btnInstallApp";
            this.btnInstallApp.Size = new System.Drawing.Size(120, 45);
            this.btnInstallApp.TabIndex = 16;
            this.btnInstallApp.Text = "Instalar APP";
            this.btnInstallApp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInstallApp.UseVisualStyleBackColor = true;
            this.btnInstallApp.Click += new System.EventHandler(this.btnInstallApp_Click);
            // 
            // btnRemoveApp
            // 
            this.btnRemoveApp.Image = global::GCBM.Properties.Resources.eraser_32;
            this.btnRemoveApp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveApp.Location = new System.Drawing.Point(264, 241);
            this.btnRemoveApp.Name = "btnRemoveApp";
            this.btnRemoveApp.Size = new System.Drawing.Size(120, 45);
            this.btnRemoveApp.TabIndex = 15;
            this.btnRemoveApp.Text = "Apagar APP";
            this.btnRemoveApp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveApp.UseVisualStyleBackColor = true;
            this.btnRemoveApp.Click += new System.EventHandler(this.btnRemoveApp_Click);
            // 
            // dgvAppList
            // 
            this.dgvAppList.AllowUserToAddRows = false;
            this.dgvAppList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppList.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppList.Location = new System.Drawing.Point(12, 12);
            this.dgvAppList.MultiSelect = false;
            this.dgvAppList.Name = "dgvAppList";
            this.dgvAppList.ReadOnly = true;
            this.dgvAppList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvAppList.Size = new System.Drawing.Size(624, 223);
            this.dgvAppList.TabIndex = 14;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            // 
            // fbd
            // 
            this.fbd.Description = "Selecione a pasta com os app\'s:";
            this.fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbd.ShowNewFolderButton = false;
            // 
            // frmManageApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 292);
            this.Controls.Add(this.btnListApp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPackageApp);
            this.Controls.Add(this.btnInstallApp);
            this.Controls.Add(this.btnRemoveApp);
            this.Controls.Add(this.dgvAppList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageApp";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gerenciar APP\'s";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnListApp;
        private Button btnClose;
        private Button btnPackageApp;
        private Button btnInstallApp;
        private Button btnRemoveApp;
        private DataGridView dgvAppList;
        private NotifyIcon notifyIcon;
        private FolderBrowserDialog fbd;
    }
}