using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM.tools
{
    public partial class frmConvertELFtoDOL : Form
    {
        // ProcessStartInfo
        #region Properties
        private static string GET_CURRENT_PATH = Directory.GetCurrentDirectory();
        readonly ProcessStartInfo startInfo = new ProcessStartInfo();
        #endregion

        #region Main form
        public frmConvertELFtoDOL()
        {
            InitializeComponent();
        }
        #endregion

        #region Buttons
        private void btnSearchELF_Click(object sender, EventArgs e)
        {
            if (ofdELF.ShowDialog() == DialogResult.OK)
            {
                textBoxELF.Text = ofdELF.FileName;
                //textBoxDOL.Text = openFileDialogELF.FileName.ToString().Replace(textBoxELF.Text, textBoxELF.Text + "boot.dol");
                textBoxDOL.Text = ofdELF.FileName.ToString().Replace(".elf", ".dol");
            }

            if (string.IsNullOrEmpty(textBoxELF.Text))
            {
                btnConvertELF.Enabled = false;
            }
            else
            {
                btnConvertELF.Enabled = true;
            }
        }

        private void btnConvertELF_Click(object sender, EventArgs e)
        {
            //var _source = new FileInfo(openFileDialogELF.FileName);

            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = true;
            // Elf2Dol
            startInfo.FileName = GET_CURRENT_PATH + @"\bin\elf2dol.exe ";
            // Argumentos
            startInfo.Arguments = " -O binary " + textBoxELF.Text + " " + textBoxDOL.Text;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //MessageBox.Show(startInfo.FileName.ToString() + startInfo.Arguments.ToString());

            using (Process myProcess = Process.Start(startInfo))
            {
                do
                {
                    if (!myProcess.HasExited)
                    {
                        // Refresh the current process property values.
                        myProcess.Refresh();
                        // Display current process statistics.
                        textBoxLogELFtoDOL.AppendText("ELF->DOL");
                        textBoxLogELFtoDOL.AppendText(Environment.NewLine + "---------------" + Environment.NewLine + Environment.NewLine);

                        if (myProcess.Responding)
                        {
                            textBoxLogELFtoDOL.AppendText(GCBM.Properties.Resources.ConvertElfDol_String1 + Environment.NewLine);
                        }
                        else
                        {
                            textBoxLogELFtoDOL.AppendText(GCBM.Properties.Resources.ConvertElfDol_String2 + Environment.NewLine);
                        }
                    }
                }
                while (!myProcess.WaitForExit(1000));

                var _StatusExit = myProcess.ExitCode;
                if (_StatusExit == 0)
                {
                    textBoxLogELFtoDOL.AppendText(GCBM.Properties.Resources.ConvertElfDol_String3 + Environment.NewLine);
                }
                if (_StatusExit == 1)
                {
                    textBoxLogELFtoDOL.AppendText(GCBM.Properties.Resources.ConvertElfDol_String4 + Environment.NewLine);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion
    }
}
