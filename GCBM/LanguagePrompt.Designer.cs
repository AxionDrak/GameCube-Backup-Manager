namespace GCBM
{
    partial class frmLanguagePrompt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLanguagePrompt));
            this.lblLanguagePrompt = new System.Windows.Forms.Label();
            this.cbSupportedCultures = new System.Windows.Forms.ComboBox();
            this.btnSetLanguage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLanguagePrompt
            // 
            this.lblLanguagePrompt.AutoSize = true;
            this.lblLanguagePrompt.Location = new System.Drawing.Point(12, 12);
            this.lblLanguagePrompt.Name = "lblLanguagePrompt";
            this.lblLanguagePrompt.Size = new System.Drawing.Size(195, 13);
            this.lblLanguagePrompt.TabIndex = 0;
            this.lblLanguagePrompt.Text = "Please choose your preferred language:";
            // 
            // cbSupportedCultures
            // 
            this.cbSupportedCultures.FormattingEnabled = true;
            this.cbSupportedCultures.Location = new System.Drawing.Point(213, 9);
            this.cbSupportedCultures.Name = "cbSupportedCultures";
            this.cbSupportedCultures.Size = new System.Drawing.Size(182, 21);
            this.cbSupportedCultures.TabIndex = 1;
            this.cbSupportedCultures.SelectedIndexChanged += new System.EventHandler(this.cbSupportedCultures_SelectedIndexChanged);
            // 
            // btnSetLanguage
            // 
            this.btnSetLanguage.Location = new System.Drawing.Point(401, 7);
            this.btnSetLanguage.Name = "btnSetLanguage";
            this.btnSetLanguage.Size = new System.Drawing.Size(46, 23);
            this.btnSetLanguage.TabIndex = 2;
            this.btnSetLanguage.Text = "Set";
            this.btnSetLanguage.UseVisualStyleBackColor = true;
            this.btnSetLanguage.Click += new System.EventHandler(this.btnSetLanguage_Click);
            // 
            // frmLanguagePrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 39);
            this.Controls.Add(this.btnSetLanguage);
            this.Controls.Add(this.cbSupportedCultures);
            this.Controls.Add(this.lblLanguagePrompt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLanguagePrompt";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "GCBM - Language Prompt";
            this.Load += new System.EventHandler(this.LanguagePrompt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLanguagePrompt;
        private System.Windows.Forms.ComboBox cbSupportedCultures;
        private System.Windows.Forms.Button btnSetLanguage;
    }
}