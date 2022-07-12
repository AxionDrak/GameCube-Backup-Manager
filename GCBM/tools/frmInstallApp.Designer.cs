
using System.ComponentModel;
using System.Windows.Forms;

namespace GCBM.tools
{
    partial class frmInstallApp
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
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.cbDestiny = new System.Windows.Forms.ComboBox();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.cbDevice = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Banner:";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::GCBM.Properties.Resources.cancel_16;
            this.btnClose.Location = new System.Drawing.Point(376, 94);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "Fechar";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnInstall
            // 
            this.btnInstall.Image = global::GCBM.Properties.Resources.install_16;
            this.btnInstall.Location = new System.Drawing.Point(285, 94);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(85, 30);
            this.btnInstall.TabIndex = 35;
            this.btnInstall.Text = "Instalar";
            this.btnInstall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInstall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInstall.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::GCBM.Properties.Resources.open_folder_16;
            this.btnSearch.Location = new System.Drawing.Point(194, 94);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 30);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "Procurar...";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // pbBanner
            // 
            this.pbBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBanner.ErrorImage = global::GCBM.Properties.Resources.image_not_found_2;
            this.pbBanner.Image = global::GCBM.Properties.Resources.image_not_found_1;
            this.pbBanner.InitialImage = null;
            this.pbBanner.Location = new System.Drawing.Point(12, 68);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(128, 48);
            this.pbBanner.TabIndex = 33;
            this.pbBanner.TabStop = false;
            // 
            // tbVersion
            // 
            this.tbVersion.BackColor = System.Drawing.Color.White;
            this.tbVersion.Location = new System.Drawing.Point(194, 68);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.ReadOnly = true;
            this.tbVersion.Size = new System.Drawing.Size(267, 20);
            this.tbVersion.TabIndex = 32;
            // 
            // cbDestiny
            // 
            this.cbDestiny.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestiny.FormattingEnabled = true;
            this.cbDestiny.Items.AddRange(new object[] {
            "\\",
            "\\apps"});
            this.cbDestiny.Location = new System.Drawing.Point(103, 29);
            this.cbDestiny.Name = "cbDestiny";
            this.cbDestiny.Size = new System.Drawing.Size(85, 21);
            this.cbDestiny.TabIndex = 31;
            // 
            // tbDirectory
            // 
            this.tbDirectory.BackColor = System.Drawing.Color.White;
            this.tbDirectory.Location = new System.Drawing.Point(194, 29);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.ReadOnly = true;
            this.tbDirectory.Size = new System.Drawing.Size(267, 20);
            this.tbDirectory.TabIndex = 30;
            // 
            // cbDevice
            // 
            this.cbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(12, 29);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(85, 21);
            this.cbDevice.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Versão:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Diretório/Nome do APP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Destino:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Dispositivo:";
            // 
            // frmInstallApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 135);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pbBanner);
            this.Controls.Add(this.tbVersion);
            this.Controls.Add(this.cbDestiny);
            this.Controls.Add(this.tbDirectory);
            this.Controls.Add(this.cbDevice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInstallApp";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Instalar APP";
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label5;
        private Button btnClose;
        private Button btnInstall;
        private Button btnSearch;
        private PictureBox pbBanner;
        private TextBox tbVersion;
        private ComboBox cbDestiny;
        private TextBox tbDirectory;
        private ComboBox cbDevice;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}