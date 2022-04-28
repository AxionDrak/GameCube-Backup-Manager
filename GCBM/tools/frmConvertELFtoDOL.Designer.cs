
namespace GCBM.tools
{
    partial class frmConvertELFtoDOL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvertELFtoDOL));
            this.labelLogELFtoDOL = new System.Windows.Forms.Label();
            this.textBoxLogELFtoDOL = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConvertELF = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchELF = new System.Windows.Forms.Button();
            this.textBoxDOL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxELF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdELF = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // labelLogELFtoDOL
            // 
            resources.ApplyResources(this.labelLogELFtoDOL, "labelLogELFtoDOL");
            this.labelLogELFtoDOL.Name = "labelLogELFtoDOL";
            // 
            // textBoxLogELFtoDOL
            // 
            resources.ApplyResources(this.textBoxLogELFtoDOL, "textBoxLogELFtoDOL");
            this.textBoxLogELFtoDOL.Name = "textBoxLogELFtoDOL";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GCBM.Properties.Resources.cancel_32;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConvertELF
            // 
            resources.ApplyResources(this.btnConvertELF, "btnConvertELF");
            this.btnConvertELF.Image = global::GCBM.Properties.Resources.convert_32;
            this.btnConvertELF.Name = "btnConvertELF";
            this.btnConvertELF.UseVisualStyleBackColor = true;
            this.btnConvertELF.Click += new System.EventHandler(this.btnConvertELF_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btnSearchELF
            // 
            resources.ApplyResources(this.btnSearchELF, "btnSearchELF");
            this.btnSearchELF.Name = "btnSearchELF";
            this.btnSearchELF.UseVisualStyleBackColor = true;
            this.btnSearchELF.Click += new System.EventHandler(this.btnSearchELF_Click);
            // 
            // textBoxDOL
            // 
            this.textBoxDOL.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textBoxDOL, "textBoxDOL");
            this.textBoxDOL.Name = "textBoxDOL";
            this.textBoxDOL.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textBoxELF
            // 
            this.textBoxELF.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.textBoxELF, "textBoxELF");
            this.textBoxELF.Name = "textBoxELF";
            this.textBoxELF.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ofdELF
            // 
            resources.ApplyResources(this.ofdELF, "ofdELF");
            // 
            // frmConvertELFtoDOL
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelLogELFtoDOL);
            this.Controls.Add(this.textBoxLogELFtoDOL);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConvertELF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearchELF);
            this.Controls.Add(this.textBoxDOL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxELF);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConvertELFtoDOL";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogELFtoDOL;
        private System.Windows.Forms.TextBox textBoxLogELFtoDOL;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConvertELF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchELF;
        private System.Windows.Forms.TextBox textBoxDOL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxELF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdELF;
    }
}