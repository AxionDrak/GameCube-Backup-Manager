using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace GCBM.tools
{
    public partial class frmCreatePackage : Form
    {
        #region Properties

        public string DGV_FILE { get; }
        public string DGV_DIRECTORY { get; }
        public string FBD_DIRECTORY { get; }
        public string PACK_TYPE { get; private set; }
        public string NEW_FILE { get; private set; }

        #endregion

        #region Main Form

        public frmCreatePackage()
        {
            InitializeComponent();
        }

        public frmCreatePackage(string dgvSourceFile, string dgvSourceDirectory, string fbdSourceDirectory)
        {
            InitializeComponent();

            DGV_FILE = dgvSourceFile;
            DGV_DIRECTORY = dgvSourceDirectory;
            FBD_DIRECTORY = fbdSourceDirectory;
        }

        #endregion

        #region Compress Functions

        /// <summary>
        ///     Compactar pastas, subpastas e todos os arquivos dentro das pastas.
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
                    PACK_TYPE = ".zip";
                    NEW_FILE = dgvFile + PACK_TYPE;

                    if (File.Exists(NEW_FILE))
                    {
                        File.Delete(NEW_FILE);
                        CompressType();
                    }
                    else
                    {
                        CompressType();
                    }
                }
                else
                {
                    PACK_TYPE = ".nwb";
                    NEW_FILE = dgvFile + PACK_TYPE;

                    if (File.Exists(NEW_FILE))
                    {
                        File.Delete(NEW_FILE);
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
                    ZipFile.CreateFromDirectory(Path.GetDirectoryName(DGV_DIRECTORY), FBD_DIRECTORY + Path.DirectorySeparatorChar + NEW_FILE,
                        CompressionLevel.NoCompression, true);
                    SuccessCompressingFile();
                }
                else if (rbFastCompression.Checked)
                {
                    ZipFile.CreateFromDirectory(Path.GetDirectoryName(DGV_DIRECTORY), FBD_DIRECTORY + Path.DirectorySeparatorChar + NEW_FILE,
                        CompressionLevel.Fastest, true);
                    SuccessCompressingFile();
                }
                else
                {
                    ZipFile.CreateFromDirectory(Path.GetDirectoryName(DGV_DIRECTORY), FBD_DIRECTORY + Path.DirectorySeparatorChar + NEW_FILE,
                        CompressionLevel.Optimal, true);
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
            notifyIcon.ShowBalloonTip(10, "GameCube Backup Manager", "Arquivo compactado criado com sucesso!",
                ToolTipIcon.Info);
        }

        #endregion

        #region Buttons

        private void btnCompress_Click(object sender, EventArgs e)
        {
            //CompressFolder(dgvFile, dgvDirectory);
            CompressFolder(DGV_FILE);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        #endregion
    }
}