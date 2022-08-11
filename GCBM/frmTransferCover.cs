#region Using

using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace GCBM
{
    /// <summary>
    /// </summary>
    public partial class frmTransferCover : Form
    {
        #region Main Constructor

        /// <summary>
        /// </summary>
        public frmTransferCover()
        {
            InitializeComponent();

            bgWorkerIndeterminate.WorkerReportsProgress = true;
            bgWorkerIndeterminate.WorkerSupportsCancellation = true;
            btnTaskCancel.Enabled = false;
            btnTaskCancel.Visible = false;
        }

        #endregion

        #region Notifications

        private void GlobalNotifications(string ex)
        {
            notifyIcon.ShowBalloonTip(10, "GameCube Backup Manager", ex, ToolTipIcon.Info);
        }

        #endregion

        #region Checkbox All Regions

        private void chkTransferAllRegions_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransferAllRegions.Checked)
            {
                rbUsa.Enabled = false;
                rbEurope.Enabled = false;
                rbJapan.Enabled = false;
            }
            else
            {
                rbUsa.Enabled = true;
                rbEurope.Enabled = true;
                rbJapan.Enabled = true;
            }
        }

        #endregion

        #region Task.Delay

        private async Task ProcessTaskDelay()
        {
            await Task.Delay(4000).ConfigureAwait(false);
        }

        #endregion

        private void CopyAllCovers()
        {
            // USB Loader GX - Diretórios de destino das capas
            var _targetDisc = CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectoryDisc", "");
            var _target2D = CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectory2D", "");
            var _target3D = CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectory3D", "");
            var _targetFull = CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectoryFull", "");
            // WiiFlow - Diretórios de destino das capas
            var _target3DCovers = CONFIG_INI_FILE.IniReadString("COVERS", "WiiFlowCoverDirectory3D", "");
            var _targetBoxCovers = CONFIG_INI_FILE.IniReadString("COVERS", "WiiFlowCoverDirectoryFull", "");

            if (rbUsa.Checked)
                REGION_GAME = "US";
            else if (rbEurope.Checked)
                REGION_GAME = "EN";
            else if (rbJapan.Checked) REGION_GAME = "JA";

            //USB Loader GX
            if (CONFIG_INI_FILE.IniReadBool("COVERS", "GXCoverUSBLoader"))
            {
                // Disc covers
                try
                {
                    var _filesDisc =
                        Directory.GetFiles(CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") + Path.DirectorySeparatorChar +
                                           REGION_GAME + Path.DirectorySeparatorChar + "disc");
                    var _files2D =
                        Directory.GetFiles(CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") + Path.DirectorySeparatorChar +
                                           REGION_GAME + Path.DirectorySeparatorChar + "2d");
                    var _files3D =
                        Directory.GetFiles(CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") + Path.DirectorySeparatorChar +
                                           REGION_GAME + Path.DirectorySeparatorChar + "3d");
                    var _filesFull =
                        Directory.GetFiles(CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") + Path.DirectorySeparatorChar +
                                           REGION_GAME + Path.DirectorySeparatorChar + "full");

                    var _destFiles = "";
                    // Disc
                    foreach (var source in _filesDisc)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _targetDisc + Path.DirectorySeparatorChar + _destFiles, true);
                    }

                    // 2D
                    foreach (var source in _files2D)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _target2D + Path.DirectorySeparatorChar + _destFiles, true);
                    }

                    // 3D
                    foreach (var source in _files3D)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _target3D + Path.DirectorySeparatorChar + _destFiles, true);
                    }

                    // Full
                    foreach (var source in _filesFull)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _targetFull + Path.DirectorySeparatorChar + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }
            } // WiiFlow
            else if (CONFIG_INI_FILE.IniReadBool("COVERS", "WiiFlowCoverUSBLoader"))
            {
                // 3D covers
                try
                {
                    var _files = Directory.GetFiles(CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") +
                                                    Path.DirectorySeparatorChar + REGION_GAME + Path.DirectorySeparatorChar + "3d");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _target3DCovers + Path.DirectorySeparatorChar + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }

                // Full covers
                try
                {
                    var _files = Directory.GetFiles(CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") +
                                                    Path.DirectorySeparatorChar + REGION_GAME + Path.DirectorySeparatorChar + "full");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _targetBoxCovers + Path.DirectorySeparatorChar + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }
            }
        }

        #region Copy Covers

        private void CopyCovers()
        {
            //if (worker.CancellationPending)
            //{
            //    e.Cancel = true;
            //}

            // USB Loader GX - Diretórios de destino das capas
            var _targetDisc = CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectoryDisc", "");
            var _target2D = CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectory2D", "");
            var _target3D = CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectory3D", "");
            var _targetFull = CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectoryFull", "");
            // WiiFlow - Diretórios de destino das capas
            var _target3DCovers = CONFIG_INI_FILE.IniReadString("COVERS", "WiiFlowCoverDirectory3D", "");
            var _targetBoxCovers = CONFIG_INI_FILE.IniReadString("COVERS", "WiiFlowCoverDirectoryFull", "");

            if (rbUsa.Checked)
                REGION_GAME = "US";
            else if (rbEurope.Checked)
                REGION_GAME = "EN";
            else if (rbJapan.Checked) REGION_GAME = "JA";

            //USB Loader GX
            if (CONFIG_INI_FILE.IniReadBool("COVERS", "GXCoverUSBLoader"))
            {
                // Disc covers
                try
                {
                    var _files = Directory.GetFiles(CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") +
                                                    Path.DirectorySeparatorChar + REGION_GAME + Path.DirectorySeparatorChar + "disc");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _targetDisc + Path.DirectorySeparatorChar + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }

                // 2D covers
                try
                {
                    var _files = Directory.GetFiles(CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") +
                                                    Path.DirectorySeparatorChar + REGION_GAME + Path.DirectorySeparatorChar + "2d");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _target2D + Path.DirectorySeparatorChar + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }

                // 3D covers
                try
                {
                    var _files = Directory.GetFiles(CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") +
                                                    Path.DirectorySeparatorChar + REGION_GAME + Path.DirectorySeparatorChar + "3d");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _target3D + Path.DirectorySeparatorChar + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }

                // Full Boxcovers
                try
                {
                    var _files = Directory.GetFiles(CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") +
                                                    Path.DirectorySeparatorChar + REGION_GAME + Path.DirectorySeparatorChar + "full");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _targetFull + Path.DirectorySeparatorChar + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }
            } // WiiFlow
            else if (CONFIG_INI_FILE.IniReadBool("COVERS", "WiiFlowCoverUSBLoader"))
            {
                // 3D covers
                try
                {
                    var _files = Directory.GetFiles(CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") +
                                                    Path.DirectorySeparatorChar + REGION_GAME + Path.DirectorySeparatorChar + "3d");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _target3DCovers + Path.DirectorySeparatorChar + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }

                // Full covers
                try
                {
                    var _files = Directory.GetFiles(CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") +
                                                    Path.DirectorySeparatorChar + REGION_GAME + Path.DirectorySeparatorChar + "full");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _targetBoxCovers + Path.DirectorySeparatorChar + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }
            }
        }

        #endregion

        #region Backgroundworker Indeterminate DoWork

        private void bgWorkerIndeterminate_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            //Verifica se houve uma requisição para cancelar a operação.
            if (worker.CancellationPending)
            {
                //se sim, define a propriedade Cancel para true
                //para que o evento WorkerCompleted saiba que a tarefa foi cancelada.
                e.Cancel = true;
                return;
            }

            CopyCovers();
        }

        #endregion

        #region Backgroundworker Indeterminate RunWorker Completed

        private async void bgWorkerIndeterminate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // reconfigura a progressbar para o padrao.
                pbCoverCopy.MarqueeAnimationSpeed = 0;
                pbCoverCopy.Style = ProgressBarStyle.Blocks;
                pbCoverCopy.Value = 0;
                lblTransferStatus.Text = "Transferência cancelada!";
                //habilita o botao cancelar
                btnTaskCancel.Enabled = false;
                btnTaskCancel.Visible = false;
                btnClose.Enabled = true;

                //limpa a label
                lblTransferStatus.Text = string.Empty;
            }
            else if (e.Error != null)
            {
                lblTransferStatus.Text = "Erro: " + e.Error.Message;
                // reconfigura a progressbar para o padrao.
                pbCoverCopy.MarqueeAnimationSpeed = 0;
                pbCoverCopy.Style = ProgressBarStyle.Blocks;
                pbCoverCopy.Value = 0;
            }
            else
            {
                //Carrega todo progressbar.
                pbCoverCopy.MarqueeAnimationSpeed = 50;
                pbCoverCopy.Style = ProgressBarStyle.Blocks;
                pbCoverCopy.Value = 100;
                //lblTransferStatus.Text = "Transferência finalizada: " + pbCoverCopy.Value.ToString() + "%";
                lblTransferStatus.Text = "Transferência finalizada!";
            }

            await ProcessTaskDelay().ConfigureAwait(false);
            //habilita os botões.
            btnTaskIndeterminate.Enabled = true;
            btnClose.Enabled = true;
            rbUsa.Enabled = true;
            rbEurope.Enabled = true;
            rbJapan.Enabled = true;
        }

        #endregion

        #region Properties

        private static string REGION_GAME = "";
        private const string INI_FILE = "config.ini";
        private readonly IniFile CONFIG_INI_FILE = new IniFile(INI_FILE);

        #endregion

        #region Buttons

        private void btnTaskCancel_Click(object sender, EventArgs e)
        {
            bgWorkerIndeterminate.CancelAsync();

            //desabilita o botão cancelar.
            btnTaskIndeterminate.Enabled = true;
            btnTaskCancel.Enabled = false;
            btnTaskCancel.Visible = false;
            btnClose.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            notifyIcon.Dispose();
            Dispose();
        }

        private void btnTaskIndeterminate_Click(object sender, EventArgs e)
        {
            if (rbUsa.Checked)
            {
                lblTransferStatus.Text = string.Empty;
                lblTransferStatus.Text = "";
            }
            else if (rbEurope.Checked)
            {
                lblTransferStatus.Text = string.Empty;
                lblTransferStatus.Text = "";
            }
            else if (rbJapan.Checked)
            {
                lblTransferStatus.Text = string.Empty;
                lblTransferStatus.Text = "";
            }

            //Desabilita os botões enquanto a tarefa é executada.
            btnTaskIndeterminate.Enabled = false;
            btnClose.Enabled = false;
            rbUsa.Enabled = false;
            rbEurope.Enabled = false;
            rbJapan.Enabled = false;

            //Habilita os botões enquanto a tarefa é executada.
            //btnTaskCancel.Enabled = true;
            //btnTaskCancel.Visible = false;

            //Tarefa sendo executada.          
            if (bgWorkerIndeterminate.IsBusy != true) bgWorkerIndeterminate.RunWorkerAsync();

            //define a progressBar para Marquee
            pbCoverCopy.Style = ProgressBarStyle.Marquee;
            pbCoverCopy.MarqueeAnimationSpeed = 5;

            //informa que a tarefa esta sendo executada.
            lblTransferStatus.Text = "Processando...";
        }

        #endregion
    }
}