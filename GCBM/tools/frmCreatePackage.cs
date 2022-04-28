using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM.tools
{
    public partial class frmCreatePackage : Form
    {
        #region Properties
        public string dgvFile { get; private set; }
        public string dgvDirectory { get; private set; }
        public string fbdDirectory { get; private set; }
        public string packType { get; private set; }
        public string newFile { get; private set; }
        #endregion

        #region Main Form
        public frmCreatePackage()
        {
            InitializeComponent();
        }

        public frmCreatePackage(string dgvSourceFile, string dgvSourceDirectory, string fbdSourceDirectory)
        {
            InitializeComponent();

            dgvFile = dgvSourceFile;
            dgvDirectory = dgvSourceDirectory;
            fbdDirectory = fbdSourceDirectory;
        }
        #endregion

        #region Compress Functions
        /// <summary>
        /// Compactar pastas, subpastas e todos os arquivos dentro das pastas.
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="dest"></param>
        //private void CompressFolder(string dgvFile, string dgvDirectory)
        private void CompressFolder(string dgvFile)
        {
            try
            {
                //Tipo de pacote.
                if (rbFileZip.Checked)
                {
                    packType = ".zip";
                    newFile = dgvFile + packType;

                    if (File.Exists(newFile))
                    {
                        File.Delete(newFile);
                        CompressType();
                    }
                    else
                    {
                        CompressType();
                    }
                }
                else
                {
                    packType = ".nwb";
                    newFile = dgvFile + packType;

                    if (File.Exists(newFile))
                    {
                        File.Delete(newFile);
                        CompressType();
                    }
                    else
                    {
                        CompressType();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionErrorList(ex);
            }
        }

        private void CompressType()
        {
            try
            {
                if (rbNoCompression.Checked)
                {
                    ZipFile.CreateFromDirectory(Path.GetDirectoryName(dgvDirectory), fbdDirectory + @"\" + newFile, CompressionLevel.NoCompression, true);
                    SuccessCompressingFile();
                }
                else if (rbFastCompression.Checked)
                {
                    ZipFile.CreateFromDirectory(Path.GetDirectoryName(dgvDirectory), fbdDirectory + @"\" + newFile, CompressionLevel.Fastest, true);
                    SuccessCompressingFile();
                }
                else
                {
                    ZipFile.CreateFromDirectory(Path.GetDirectoryName(dgvDirectory), fbdDirectory + @"\" + newFile, CompressionLevel.Optimal, true);
                    SuccessCompressingFile();
                }
            }
            catch (Exception ex)
            {
                ExceptionErrorList(ex);
            }
        }
        #endregion

        #region Notifications
        private void ExceptionErrorList(Exception error)
        {
            notifyIcon.ShowBalloonTip(10, "GameCube Backup Manager", error.Message, ToolTipIcon.Info);
        }

        private void SuccessCompressingFile()
        {
            notifyIcon.ShowBalloonTip(10, "GameCube Backup Manager", "Arquivo compactado criado com sucesso!", ToolTipIcon.Info);
        }
        #endregion

        #region Buttons
        private void btnCompress_Click(object sender, EventArgs e)
        {
            //CompressFolder(dgvFile, dgvDirectory);
            CompressFolder(dgvFile);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion
    }
}
