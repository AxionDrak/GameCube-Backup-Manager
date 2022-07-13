
using System.ComponentModel;
using System.Windows.Forms;

namespace GCBM.tools
{
    partial class frmCreatePackage
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCompress = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbFileNwb = new System.Windows.Forms.RadioButton();
            this.rbFileZip = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbOptimizedCompression = new System.Windows.Forms.RadioButton();
            this.rbFastCompression = new System.Windows.Forms.RadioButton();
            this.rbNoCompression = new System.Windows.Forms.RadioButton();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 113);
            this.label1.MaximumSize = new System.Drawing.Size(240, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "ATENÇÃO: esse método não empacota arquivos e pastas fora da pasta principal do ap" +
    "p.";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::GCBM.Properties.Resources.cancel_16;
            this.btnClose.Location = new System.Drawing.Point(353, 113);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Fechar";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCompress
            // 
            this.btnCompress.Image = global::GCBM.Properties.Resources.compact_file_16;
            this.btnCompress.Location = new System.Drawing.Point(262, 113);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(85, 30);
            this.btnCompress.TabIndex = 11;
            this.btnCompress.Text = "Comprimir";
            this.btnCompress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFileNwb);
            this.groupBox2.Controls.Add(this.rbFileZip);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 95);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Pacote";
            // 
            // rbFileNwb
            // 
            this.rbFileNwb.AutoSize = true;
            this.rbFileNwb.Location = new System.Drawing.Point(6, 57);
            this.rbFileNwb.Name = "rbFileNwb";
            this.rbFileNwb.Size = new System.Drawing.Size(122, 17);
            this.rbFileNwb.TabIndex = 1;
            this.rbFileNwb.Text = "Arquivo NWB (.nwb)";
            this.rbFileNwb.UseVisualStyleBackColor = true;
            // 
            // rbFileZip
            // 
            this.rbFileZip.AutoSize = true;
            this.rbFileZip.Checked = true;
            this.rbFileZip.Location = new System.Drawing.Point(6, 34);
            this.rbFileZip.Name = "rbFileZip";
            this.rbFileZip.Size = new System.Drawing.Size(104, 17);
            this.rbFileZip.TabIndex = 0;
            this.rbFileZip.TabStop = true;
            this.rbFileZip.Text = "Arquivo Zip (.zip)";
            this.rbFileZip.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOptimizedCompression);
            this.groupBox1.Controls.Add(this.rbFastCompression);
            this.groupBox1.Controls.Add(this.rbNoCompression);
            this.groupBox1.Location = new System.Drawing.Point(228, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 95);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Método de Compressão";
            // 
            // rbOptimizedCompression
            // 
            this.rbOptimizedCompression.AutoSize = true;
            this.rbOptimizedCompression.Location = new System.Drawing.Point(6, 69);
            this.rbOptimizedCompression.Name = "rbOptimizedCompression";
            this.rbOptimizedCompression.Size = new System.Drawing.Size(189, 17);
            this.rbOptimizedCompression.TabIndex = 2;
            this.rbOptimizedCompression.Text = "Compactar (compressão otimizada)";
            this.rbOptimizedCompression.UseVisualStyleBackColor = true;
            // 
            // rbFastCompression
            // 
            this.rbFastCompression.AutoSize = true;
            this.rbFastCompression.Checked = true;
            this.rbFastCompression.Location = new System.Drawing.Point(6, 46);
            this.rbFastCompression.Name = "rbFastCompression";
            this.rbFastCompression.Size = new System.Drawing.Size(174, 17);
            this.rbFastCompression.TabIndex = 1;
            this.rbFastCompression.TabStop = true;
            this.rbFastCompression.Text = "Compactar (compressão rápida)";
            this.rbFastCompression.UseVisualStyleBackColor = true;
            // 
            // rbNoCompression
            // 
            this.rbNoCompression.AutoSize = true;
            this.rbNoCompression.Location = new System.Drawing.Point(6, 23);
            this.rbNoCompression.Name = "rbNoCompression";
            this.rbNoCompression.Size = new System.Drawing.Size(164, 17);
            this.rbNoCompression.TabIndex = 0;
            this.rbNoCompression.Text = "Empacotar (sem compressão)";
            this.rbNoCompression.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Visible = true;
            // 
            // frmCreatePackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 149);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreatePackage";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Empacotar APP selecionado";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnClose;
        private Button btnCompress;
        private GroupBox groupBox2;
        private RadioButton rbFileNwb;
        private RadioButton rbFileZip;
        private GroupBox groupBox1;
        private RadioButton rbOptimizedCompression;
        private RadioButton rbFastCompression;
        private RadioButton rbNoCompression;
        private NotifyIcon notifyIcon;
    }
}