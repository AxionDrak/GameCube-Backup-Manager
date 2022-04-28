#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace GCBM
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmTransferCover : Form
    {
        #region Properties
        /// <summary>
        /// Exposes static methods for creating, moving, and enumerating through directories and subdirectories.
        /// Gets the current working directory of the application.
        /// </summary>
        private static string getCurrentPath = Directory.GetCurrentDirectory();

        /// <summary>
        /// IniFile
        /// </summary>
        readonly IniFile configIniFile = new IniFile("config.ini");

        string _region = "";
        #endregion

        #region Main Constructor
        /// <summary>
        /// 
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
            if (chkTransferAllRegions.Checked == true)
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
        async Task ProcessTaskDelay()
        {
            await Task.Delay(4000);
        }
        #endregion

        private void CopyAllCovers()
        {
            // USB Loader GX - Diretórios de destino das capas
            string _targetDisc = configIniFile.IniReadString("COVERS", "GXCoverDirectoryDisc", "");
            string _target2D = configIniFile.IniReadString("COVERS", "GXCoverDirectory2D", "");
            string _target3D = configIniFile.IniReadString("COVERS", "GXCoverDirectory3D", "");
            string _targetFull = configIniFile.IniReadString("COVERS", "GXCoverDirectoryFull", "");
            // WiiFlow - Diretórios de destino das capas
            string _target3DCovers = configIniFile.IniReadString("COVERS", "WiiFlowCoverDirectory3D", "");
            string _targetBoxCovers = configIniFile.IniReadString("COVERS", "WiiFlowCoverDirectoryFull", "");

            if (rbUsa.Checked == true)
            {
                _region = "US";
            }
            else if (rbEurope.Checked == true)
            {
                _region = "EN";
            }
            else if (rbJapan.Checked == true)
            {
                _region = "JA";
            }

            //USB Loader GX
            if (configIniFile.IniReadBool("COVERS", "GXCoverUSBLoader") == true)
            {
                // Disc covers
                try
                {
                    var _filesDisc = Directory.GetFiles(configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") + @"\" + _region + @"\disc");
                    var _files2D = Directory.GetFiles(configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") + @"\" + _region + @"\2d");
                    var _files3D = Directory.GetFiles(configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") + @"\" + _region + @"\3d");
                    var _filesFull = Directory.GetFiles(configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") + @"\" + _region + @"\full");

                    var _destFiles = "";
                    // Disc
                    foreach (var source in _filesDisc)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _targetDisc + @"\" + _destFiles, true);
                    }

                    // 2D
                    foreach (var source in _files2D)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _target2D + @"\" + _destFiles, true);
                    }

                    // 3D
                    foreach (var source in _files3D)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _target3D + @"\" + _destFiles, true);
                    }

                    // Full
                    foreach (var source in _filesFull)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _targetFull + @"\" + _destFiles, true);
                    }

                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }
            }// WiiFlow
            else if (configIniFile.IniReadBool("COVERS", "WiiFlowCoverUSBLoader") == true)
            {
                // 3D covers
                try
                {
                    var _files = Directory.GetFiles(configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") + @"\" + _region + @"\3d");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _target3DCovers + @"\" + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }

                // Full covers
                try
                {
                    var _files = Directory.GetFiles(configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") + @"\" + _region + @"\full");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _targetBoxCovers + @"\" + _destFiles, true);
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
            string _targetDisc = configIniFile.IniReadString("COVERS", "GXCoverDirectoryDisc", "");
            string _target2D = configIniFile.IniReadString("COVERS", "GXCoverDirectory2D", "");
            string _target3D = configIniFile.IniReadString("COVERS", "GXCoverDirectory3D", "");
            string _targetFull = configIniFile.IniReadString("COVERS", "GXCoverDirectoryFull", "");
            // WiiFlow - Diretórios de destino das capas
            string _target3DCovers = configIniFile.IniReadString("COVERS", "WiiFlowCoverDirectory3D", "");
            string _targetBoxCovers = configIniFile.IniReadString("COVERS", "WiiFlowCoverDirectoryFull", "");

            if (rbUsa.Checked == true)
            {
                _region = "US";
            }
            else if (rbEurope.Checked == true)
            {
                _region = "EN";
            }
            else if (rbJapan.Checked == true)
            {
                _region = "JA";
            }

            //USB Loader GX
            if (configIniFile.IniReadBool("COVERS", "GXCoverUSBLoader") == true)
            {
                // Disc covers
                try
                {
                    var _files = Directory.GetFiles(configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") + @"\" + _region + @"\disc");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _targetDisc + @"\" + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }

                // 2D covers
                try
                {
                    var _files = Directory.GetFiles(configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") + @"\" + _region + @"\2d");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _target2D + @"\" + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }

                // 3D covers
                try
                {
                    var _files = Directory.GetFiles(configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") + @"\" + _region + @"\3d");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _target3D + @"\" + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }

                // Full Boxcovers
                try
                {
                    var _files = Directory.GetFiles(configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") + @"\" + _region + @"\full");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _targetFull + @"\" + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }
            }// WiiFlow
            else if (configIniFile.IniReadBool("COVERS", "WiiFlowCoverUSBLoader") == true)
            {
                // 3D covers
                try
                {
                    var _files = Directory.GetFiles(configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") + @"\" + _region + @"\3d");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _target3DCovers + @"\" + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }

                // Full covers
                try
                {
                    var _files = Directory.GetFiles(configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") + @"\" + _region + @"\full");
                    var _destFiles = "";

                    foreach (var source in _files)
                    {
                        _destFiles = Path.GetFileName(source);
                        File.Copy(source, _targetBoxCovers + @"\" + _destFiles, true);
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications("Falha: " + ex.Message);
                }

            }
        }
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
            this.Close();
            this.notifyIcon.Dispose();
            this.Dispose();
        }

        private void btnTaskIndeterminate_Click(object sender, EventArgs e)
        {
            if(rbUsa.Checked == true)
            {
                lblTransferStatus.Text = string.Empty;
                lblTransferStatus.Text = "";
            }
            else if (rbEurope.Checked == true)
            {
                lblTransferStatus.Text = string.Empty;
                lblTransferStatus.Text = "";
            }
            else if (rbJapan.Checked == true)
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
            if (bgWorkerIndeterminate.IsBusy != true)
            {
                bgWorkerIndeterminate.RunWorkerAsync();
            }

            //define a progressBar para Marquee
            pbCoverCopy.Style = ProgressBarStyle.Marquee;
            pbCoverCopy.MarqueeAnimationSpeed = 5;

            //informa que a tarefa esta sendo executada.
            lblTransferStatus.Text = "Processando...";
        }
        #endregion

        #region Backgroundworker Indeterminate DoWork
        private void bgWorkerIndeterminate_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            //Verifica se houve uma requisição para cancelar a operação.
            if (worker.CancellationPending == true)
            {
                //se sim, define a propriedade Cancel para true
                //para que o evento WorkerCompleted saiba que a tarefa foi cancelada.
                e.Cancel = true;
                return;
            }
            else
            {
                CopyCovers();
            }
        }
        #endregion

        #region Backgroundworker Indeterminate RunWorker Completed
        private async void bgWorkerIndeterminate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
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

            await ProcessTaskDelay();
            //habilita os botões.
            btnTaskIndeterminate.Enabled = true;
            btnClose.Enabled = true;
            rbUsa.Enabled = true;
            rbEurope.Enabled = true;
            rbJapan.Enabled = true;
        }
        #endregion

    }
}
