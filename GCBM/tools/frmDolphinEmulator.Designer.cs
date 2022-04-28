
namespace GCBM.tools
{
    partial class frmDolphinEmulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDolphinEmulator));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblGame = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.tbPathDolphinEmulator = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbHLE = new System.Windows.Forms.RadioButton();
            this.rbLLE = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbOpenGL = new System.Windows.Forms.RadioButton();
            this.rbD3D12 = new System.Windows.Forms.RadioButton();
            this.rbD3D11 = new System.Windows.Forms.RadioButton();
            this.ofdDolphin = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblGame);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(430, 55);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Jogo";
            // 
            // lblGame
            // 
            this.lblGame.AutoSize = true;
            this.lblGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGame.Location = new System.Drawing.Point(15, 23);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(19, 13);
            this.lblGame.TabIndex = 0;
            this.lblGame.Text = "...";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(359, 266);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(278, 266);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Testar";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 187);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurar Emulador";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSelectFile);
            this.groupBox5.Controls.Add(this.tbPathDolphinEmulator);
            this.groupBox5.Location = new System.Drawing.Point(7, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(415, 50);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Caminho para o emulador";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(384, 16);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(25, 25);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // tbPathDolphinEmulator
            // 
            this.tbPathDolphinEmulator.BackColor = System.Drawing.Color.White;
            this.tbPathDolphinEmulator.Location = new System.Drawing.Point(6, 19);
            this.tbPathDolphinEmulator.Name = "tbPathDolphinEmulator";
            this.tbPathDolphinEmulator.ReadOnly = true;
            this.tbPathDolphinEmulator.Size = new System.Drawing.Size(372, 20);
            this.tbPathDolphinEmulator.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbHLE);
            this.groupBox3.Controls.Add(this.rbLLE);
            this.groupBox3.Location = new System.Drawing.Point(7, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(415, 50);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Áudio";
            // 
            // rbHLE
            // 
            this.rbHLE.AutoSize = true;
            this.rbHLE.Location = new System.Drawing.Point(200, 23);
            this.rbHLE.Name = "rbHLE";
            this.rbHLE.Size = new System.Drawing.Size(113, 17);
            this.rbHLE.TabIndex = 1;
            this.rbHLE.Text = "DSP HLE (padrão)";
            this.rbHLE.UseVisualStyleBackColor = true;
            // 
            // rbLLE
            // 
            this.rbLLE.AutoSize = true;
            this.rbLLE.Checked = true;
            this.rbLLE.Location = new System.Drawing.Point(103, 23);
            this.rbLLE.Name = "rbLLE";
            this.rbLLE.Size = new System.Drawing.Size(69, 17);
            this.rbLLE.TabIndex = 0;
            this.rbLLE.TabStop = true;
            this.rbLLE.Text = "DSP LLE";
            this.rbLLE.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbOpenGL);
            this.groupBox2.Controls.Add(this.rbD3D12);
            this.groupBox2.Controls.Add(this.rbD3D11);
            this.groupBox2.Location = new System.Drawing.Point(7, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(415, 50);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vídeo";
            // 
            // rbOpenGL
            // 
            this.rbOpenGL.AutoSize = true;
            this.rbOpenGL.Location = new System.Drawing.Point(250, 22);
            this.rbOpenGL.Name = "rbOpenGL";
            this.rbOpenGL.Size = new System.Drawing.Size(103, 17);
            this.rbOpenGL.TabIndex = 2;
            this.rbOpenGL.Text = "OpenGL/Vulkan";
            this.rbOpenGL.UseVisualStyleBackColor = true;
            // 
            // rbD3D12
            // 
            this.rbD3D12.AutoSize = true;
            this.rbD3D12.Location = new System.Drawing.Point(156, 22);
            this.rbD3D12.Name = "rbD3D12";
            this.rbD3D12.Size = new System.Drawing.Size(59, 17);
            this.rbD3D12.TabIndex = 1;
            this.rbD3D12.Text = "D3D12";
            this.rbD3D12.UseVisualStyleBackColor = true;
            // 
            // rbD3D11
            // 
            this.rbD3D11.AutoSize = true;
            this.rbD3D11.Checked = true;
            this.rbD3D11.Location = new System.Drawing.Point(65, 22);
            this.rbD3D11.Name = "rbD3D11";
            this.rbD3D11.Size = new System.Drawing.Size(59, 17);
            this.rbD3D11.TabIndex = 0;
            this.rbD3D11.TabStop = true;
            this.rbD3D11.Text = "D3D11";
            this.rbD3D11.UseVisualStyleBackColor = true;
            // 
            // ofdDolphin
            // 
            this.ofdDolphin.Filter = "Dolphin emulator|dolphin.exe|Arquivo executável|*.exe";
            // 
            // frmDolphinEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 295);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDolphinEmulator";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Testar Jogo (Dolphin Emulator)";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox tbPathDolphinEmulator;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbHLE;
        private System.Windows.Forms.RadioButton rbLLE;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbOpenGL;
        private System.Windows.Forms.RadioButton rbD3D12;
        private System.Windows.Forms.RadioButton rbD3D11;
        private System.Windows.Forms.OpenFileDialog ofdDolphin;
    }
}