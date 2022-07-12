using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using PluginBurnMedia.Interop;
using PluginBurnMedia.MediaItem;

namespace GCBM.tools
{
    public partial class frmBurnMedia : Form
    {
        #region Main Form

        public frmBurnMedia()
        {
            InitializeComponent();

            cbVerification.SelectedIndex = 0;
        }

        #endregion

        #region Form Load

        /// <summary>
        ///     Initialize the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBurnMedia_Load(object sender, EventArgs e)
        {
            //
            // Determine the current recording devices
            //
            MsftDiscMaster2 discMaster = null;
            try
            {
                discMaster = new MsftDiscMaster2();

                if (!discMaster.IsSupportedEnvironment)
                    return;
                foreach (string uniqueRecorderId in discMaster)
                {
                    var discRecorder2 = new MsftDiscRecorder2();
                    discRecorder2.InitializeDiscRecorder(uniqueRecorderId);

                    cbDevices.Items.Add(discRecorder2);
                }

                if (cbDevices.Items.Count > 0) cbDevices.SelectedIndex = 0;
            }
            catch (COMException ex)
            {
                GlobalNotifications(ex.Message + " ERRO! Por favor, instale o IMAP2.");
                //MessageBox.Show(ex.Message, string.Format("Erro:{0} - Por favor, instale o IMAPI2.", ex.ErrorCode),
                //    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            finally
            {
                if (discMaster != null) Marshal.ReleaseComObject(discMaster);
            }

            //
            // Create the volume label based on the current date
            //
            var now = DateTime.Now;
            tbVolumeLabel.Text = now.Year + "_" + now.Month + "_" + now.Day;

            labelStatusText.Text = string.Empty;
            labelFormatStatusText.Text = string.Empty;

            //
            // Select no verification, by default
            //
            cbVerification.SelectedIndex = 0;

            UpdateCapacity();
        }

        #endregion

        #region Form Closing

        private void frmBurnMedia_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
            // Release the disc recorder items
            //
            foreach (MsftDiscRecorder2 discRecorder2 in cbDevices.Items)
                if (discRecorder2 != null)
                    Marshal.ReleaseComObject(discRecorder2);
            Dispose();
        }

        #endregion

        #region Notifications

        private void GlobalNotifications(string ex)
        {
            notifyIcon.ShowBalloonTip(10, "GameCube Backup Manager", ex, ToolTipIcon.Info);
        }

        #endregion

        #region TabControl

        /// <summary>
        ///     Called when user selects a new tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //
            // Prevent page from changing if we're burning or formatting.
            //
            if (_isBurning || _isFormatting) e.Cancel = true;
        }

        #endregion

        # region Verification ComboBox

        /// <summary>
        ///     Get the burn verification level when the user changes the selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbVerification_SelectedIndexChanged(object sender, EventArgs e)
        {
            _verificationLevel = (IMAPI_BURN_VERIFICATION_LEVEL)cbVerification.SelectedIndex;
        }

        #endregion

        #region Properties

        private const string ClientName = "GCBM BurnMedia";

        private long _totalDiscSize;

        private bool _isBurning;
        private bool _isFormatting;

        private IMAPI_BURN_VERIFICATION_LEVEL _verificationLevel =
            IMAPI_BURN_VERIFICATION_LEVEL.IMAPI_BURN_VERIFICATION_NONE;

        private bool _closeMedia;
        private bool _ejectMedia;

        private readonly BurnData _burnData = new BurnData();

        #endregion

        #region Device ComboBox

        /// <summary>
        ///     Selected a new device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDevices.SelectedIndex == -1) return;

            var discRecorder = (IDiscRecorder2)cbDevices.Items[cbDevices.SelectedIndex];

            supportedMediaLabel.Text = string.Empty;

            //
            // Verify recorder is supported
            //
            IDiscFormat2Data discFormatData = null;
            try
            {
                discFormatData = new MsftDiscFormat2Data();
                if (!discFormatData.IsRecorderSupported(discRecorder))
                {
                    GlobalNotifications("ERRO! Gravador não suportado " + ClientName);
                    //MessageBox.Show("Gravador não suportado", ClientName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var supportedMediaTypes = new StringBuilder();
                foreach (IMAPI_PROFILE_TYPE profileType in discRecorder.SupportedProfiles)
                {
                    var profileName = GetProfileTypeString(profileType);

                    if (string.IsNullOrEmpty(profileName))
                        continue;

                    if (supportedMediaTypes.Length > 0)
                        supportedMediaTypes.Append(", ");
                    supportedMediaTypes.Append(profileName);
                }

                supportedMediaLabel.Text = supportedMediaTypes.ToString();
            }
            catch (COMException)
            {
                supportedMediaLabel.Text = "Erro ao obter os tipos suportados.";
            }
            finally
            {
                if (discFormatData != null) Marshal.ReleaseComObject(discFormatData);
            }
        }

        /// <summary>
        ///     converts an IMAPI_MEDIA_PHYSICAL_TYPE to it's string
        /// </summary>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        private static string GetMediaTypeString(IMAPI_MEDIA_PHYSICAL_TYPE mediaType)
        {
            switch (mediaType)
            {
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_UNKNOWN:
                default:
                    return "Tipo de Mídia Desconhecido";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDROM:
                    return "CD-ROM";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDR:
                    return "CD-R";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDRW:
                    return "CD-RW";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDROM:
                    return "DVD ROM";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDRAM:
                    return "DVD-RAM";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSR:
                    return "DVD+R";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSRW:
                    return "DVD+RW";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSR_DUALLAYER:
                    return "DVD+R Dual Layer";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHR:
                    return "DVD-R";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHRW:
                    return "DVD-RW";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHR_DUALLAYER:
                    return "DVD-R Dual Layer";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DISK:
                    return "random-access writes";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSRW_DUALLAYER:
                    return "DVD+RW DL";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDROM:
                    return "HD DVD-ROM";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDR:
                    return "HD DVD-R";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDRAM:
                    return "HD DVD-RAM";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDROM:
                    return "Blu-ray DVD (BD-ROM)";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDR:
                    return "Blu-ray media";

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDRE:
                    return "Blu-ray Rewritable media";
            }
        }

        /// <summary>
        ///     converts an IMAPI_PROFILE_TYPE to it's string
        /// </summary>
        /// <param name="profileType"></param>
        /// <returns></returns>
        private static string GetProfileTypeString(IMAPI_PROFILE_TYPE profileType)
        {
            switch (profileType)
            {
                default:
                    return string.Empty;

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_CD_RECORDABLE:
                    return "CD-R";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_CD_REWRITABLE:
                    return "CD-RW";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVDROM:
                    return "DVD ROM";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_DASH_RECORDABLE:
                    return "DVD-R";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_RAM:
                    return "DVD-RAM";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_PLUS_R:
                    return "DVD+R";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_PLUS_RW:
                    return "DVD+RW";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_PLUS_R_DUAL:
                    return "DVD+R Dual Layer";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_DASH_REWRITABLE:
                    return "DVD-RW";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_DASH_RW_SEQUENTIAL:
                    return "DVD-RW Sequential";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_DASH_R_DUAL_SEQUENTIAL:
                    return "DVD-R DL Sequential";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_DASH_R_DUAL_LAYER_JUMP:
                    return "DVD-R Dual Layer";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_PLUS_RW_DUAL:
                    return "DVD+RW DL";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_HD_DVD_ROM:
                    return "HD DVD-ROM";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_HD_DVD_RECORDABLE:
                    return "HD DVD-R";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_HD_DVD_RAM:
                    return "HD DVD-RAM";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_BD_ROM:
                    return "Blu-ray DVD (BD-ROM)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_BD_R_SEQUENTIAL:
                    return "Blu-ray media Sequential";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_BD_R_RANDOM_RECORDING:
                    return "Blu-ray media";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_BD_REWRITABLE:
                    return "Blu-ray Rewritable media";
            }
        }

        /// <summary>
        ///     Provides the display string for an IDiscRecorder2 object in the combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDevices_Format(object sender, ListControlConvertEventArgs e)
        {
            var discRecorder2 = (IDiscRecorder2)e.ListItem;
            var devicePaths = string.Empty;
            var volumePath = (string)discRecorder2.VolumePathNames.GetValue(0);
            foreach (string volPath in discRecorder2.VolumePathNames)
            {
                if (!string.IsNullOrEmpty(devicePaths)) devicePaths += ",";
                devicePaths += volumePath;
            }

            e.Value = string.Format("{0} [{1}]", devicePaths, discRecorder2.ProductId);
        }

        #endregion

        #region Media Size

        private void btnDetectMedia_Click(object sender, EventArgs e)
        {
            if (cbDevices.SelectedIndex == -1) return;

            var discRecorder = (IDiscRecorder2)cbDevices.Items[cbDevices.SelectedIndex];

            MsftFileSystemImage fileSystemImage = null;
            MsftDiscFormat2Data discFormatData = null;

            try
            {
                //
                // Create and initialize the IDiscFormat2Data
                //
                discFormatData = new MsftDiscFormat2Data();
                if (!discFormatData.IsCurrentMediaSupported(discRecorder))
                {
                    labelMediaType.Text = "Mídia não suportada!";
                    _totalDiscSize = 0;
                    return;
                }
                else
                {
                    //
                    // Get the media type in the recorder
                    //
                    discFormatData.Recorder = discRecorder;
                    var mediaType = discFormatData.CurrentPhysicalMediaType;
                    labelMediaType.Text = GetMediaTypeString(mediaType);

                    //
                    // Create a file system and select the media type
                    //
                    fileSystemImage = new MsftFileSystemImage();
                    fileSystemImage.ChooseImageDefaultsForMediaType(mediaType);

                    //
                    // See if there are other recorded sessions on the disc
                    //
                    if (!discFormatData.MediaHeuristicallyBlank)
                    {
                        fileSystemImage.MultisessionInterfaces = discFormatData.MultisessionInterfaces;
                        fileSystemImage.ImportFileSystem();
                    }

                    long freeMediaBlocks = fileSystemImage.FreeMediaBlocks;
                    _totalDiscSize = 2048 * freeMediaBlocks;
                }
            }
            catch (COMException exception)
            {
                GlobalNotifications(exception.Message + " Detectado Erro de Mídia");
                //MessageBox.Show(this, exception.Message, "Detectado Erro de Mídia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (discFormatData != null) Marshal.ReleaseComObject(discFormatData);

                if (fileSystemImage != null) Marshal.ReleaseComObject(fileSystemImage);
            }

            UpdateCapacity();
        }

        /// <summary>
        ///     Updates the capacity progressbar
        /// </summary>
        private void UpdateCapacity()
        {
            //
            // Get the text for the Max Size
            //
            if (_totalDiscSize == 0)
            {
                labelTotalSize.Text = "0MB";
                return;
            }

            labelTotalSize.Text = _totalDiscSize < 1000000000
                ? string.Format("{0}MB", _totalDiscSize / 1000000)
                : string.Format("{0:F2}GB", (float)_totalDiscSize / 1000000000.0);

            //
            // Calculate the size of the files
            //
            long totalMediaSize = 0;
            foreach (IMediaItem mediaItem in lbFiles.Items) totalMediaSize += mediaItem.SizeOnDisc;

            if (totalMediaSize == 0)
            {
                pbCapacity.Value = 0;
                pbCapacity.ForeColor = SystemColors.Highlight;
            }
            else
            {
                var percent = (int)(totalMediaSize * 100 / _totalDiscSize);
                if (percent > 100)
                {
                    pbCapacity.Value = 100;
                    pbCapacity.ForeColor = Color.Red;
                }
                else
                {
                    pbCapacity.Value = percent;
                    pbCapacity.ForeColor = SystemColors.Highlight;
                }
            }
        }

        #endregion

        #region Burn Media Process

        /// <summary>
        ///     User clicked the "Burn" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBurn_Click(object sender, EventArgs e)
        {
            if (cbDevices.SelectedIndex == -1) return;

            if (_isBurning)
            {
                btnBurn.Enabled = false;
                bgBurnWorker.CancelAsync();
            }
            else
            {
                _isBurning = true;
                _closeMedia = chkCloseMedia.Checked;
                _ejectMedia = chkEject.Checked;

                EnableBurnUI(false);

                var discRecorder = (IDiscRecorder2)cbDevices.Items[cbDevices.SelectedIndex];
                _burnData.uniqueRecorderId = discRecorder.ActiveDiscRecorder;

                bgBurnWorker.RunWorkerAsync(_burnData);
            }
        }

        /// <summary>
        ///     The thread that does the burning of the media
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgBurnWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MsftDiscRecorder2 discRecorder = null;
            MsftDiscFormat2Data discFormatData = null;

            try
            {
                //
                // Create and initialize the IDiscRecorder2 object
                //
                discRecorder = new MsftDiscRecorder2();
                var burnData = (BurnData)e.Argument;
                discRecorder.InitializeDiscRecorder(burnData.uniqueRecorderId);

                //
                // Create and initialize the IDiscFormat2Data
                //
                discFormatData = new MsftDiscFormat2Data
                {
                    Recorder = discRecorder,
                    ClientName = ClientName,
                    ForceMediaToBeClosed = _closeMedia
                };

                //
                // Set the verification level
                //
                var burnVerification = (IBurnVerification)discFormatData;
                burnVerification.BurnVerificationLevel = _verificationLevel;

                //
                // Check if media is blank, (for RW media)
                //
                object[] multisessionInterfaces = null;
                if (!discFormatData.MediaHeuristicallyBlank)
                    multisessionInterfaces = discFormatData.MultisessionInterfaces;

                //
                // Create the file system
                //
                IStream fileSystem;
                if (!CreateMediaFileSystem(discRecorder, multisessionInterfaces, out fileSystem))
                {
                    e.Result = -1;
                    return;
                }

                //
                // add the Update event handler
                //
                discFormatData.Update += discFormatData_Update;

                //
                // Write the data here
                //
                try
                {
                    discFormatData.Write(fileSystem);
                    e.Result = 0;
                }
                catch (COMException ex)
                {
                    e.Result = ex.ErrorCode;
                    GlobalNotifications(ex.Message + "IDiscFormat2Data.Write falhou!");
                    //MessageBox.Show(ex.Message, "IDiscFormat2Data.Write falhou!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    if (fileSystem != null) Marshal.FinalReleaseComObject(fileSystem);
                }

                //
                // remove the Update event handler
                //
                discFormatData.Update -= discFormatData_Update;

                if (_ejectMedia) discRecorder.EjectMedia();
            }
            catch (COMException exception)
            {
                //
                // If anything happens during the format, show the message
                //
                MessageBox.Show(exception.Message);
                e.Result = exception.ErrorCode;
            }
            finally
            {
                if (discRecorder != null) Marshal.ReleaseComObject(discRecorder);

                if (discFormatData != null) Marshal.ReleaseComObject(discFormatData);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="progress"></param>
        private void discFormatData_Update([In] [MarshalAs(UnmanagedType.IDispatch)] object sender,
            [In] [MarshalAs(UnmanagedType.IDispatch)] object progress)
        {
            //
            // Check if we've cancelled
            //
            if (bgBurnWorker.CancellationPending)
            {
                var format2Data = (IDiscFormat2Data)sender;
                format2Data.CancelWrite();
                return;
            }

            var eventArgs = (IDiscFormat2DataEventArgs)progress;

            _burnData.task = BURN_MEDIA_TASK.BURN_MEDIA_TASK_WRITING;

            // IDiscFormat2DataEventArgs Interface
            _burnData.elapsedTime = eventArgs.ElapsedTime;
            _burnData.remainingTime = eventArgs.RemainingTime;
            _burnData.totalTime = eventArgs.TotalTime;

            // IWriteEngine2EventArgs Interface
            _burnData.currentAction = eventArgs.CurrentAction;
            _burnData.startLba = eventArgs.StartLba;
            _burnData.sectorCount = eventArgs.SectorCount;
            _burnData.lastReadLba = eventArgs.LastReadLba;
            _burnData.lastWrittenLba = eventArgs.LastWrittenLba;
            _burnData.totalSystemBuffer = eventArgs.TotalSystemBuffer;
            _burnData.usedSystemBuffer = eventArgs.UsedSystemBuffer;
            _burnData.freeSystemBuffer = eventArgs.FreeSystemBuffer;

            //
            // Report back to the UI
            //
            bgBurnWorker.ReportProgress(0, _burnData);
        }

        /// <summary>
        ///     Completed the "Burn" thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgBurnWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelStatusText.Text = (int)e.Result == 0 ? "Gravação do disco finalizada!" : "Erro ao gravar disco!";
            pbStatus.Value = 0;

            _isBurning = false;
            EnableBurnUI(true);
            btnBurn.Enabled = true;
        }

        /// <summary>
        ///     Enables/Disables the "Burn" User Interface
        /// </summary>
        /// <param name="enable"></param>
        private void EnableBurnUI(bool enable)
        {
            btnBurn.Text = enable ? "&Gravar" : "&Cancelar";
            btnDetectMedia.Enabled = enable;

            cbDevices.Enabled = enable;
            lbFiles.Enabled = enable;

            btnAddFiles.Enabled = enable;
            btnAddFolders.Enabled = enable;
            btnRemoveFiles.Enabled = enable;
            chkEject.Enabled = enable;
            chkCloseMedia.Enabled = enable;
            tbVolumeLabel.Enabled = enable;
            cbVerification.Enabled = enable;
        }

        /// <summary>
        ///     Event receives notification from the Burn thread of an event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgBurnWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //int percent = e.ProgressPercentage;
            var burnData = (BurnData)e.UserState;

            if (burnData.task == BURN_MEDIA_TASK.BURN_MEDIA_TASK_FILE_SYSTEM)
                labelStatusText.Text = burnData.statusMessage;
            else if (burnData.task == BURN_MEDIA_TASK.BURN_MEDIA_TASK_WRITING)
                switch (burnData.currentAction)
                {
                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_VALIDATING_MEDIA:
                        labelStatusText.Text = "Validando a mídia atual...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_FORMATTING_MEDIA:
                        labelStatusText.Text = "Formatando mídia...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_INITIALIZING_HARDWARE:
                        labelStatusText.Text = "Inicializando hardware...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_CALIBRATING_POWER:
                        labelStatusText.Text = "Otimizando a intensidade do laser...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_WRITING_DATA:
                        var writtenSectors = burnData.lastWrittenLba - burnData.startLba;

                        if (writtenSectors > 0 && burnData.sectorCount > 0)
                        {
                            var percent = (int)(100 * writtenSectors / burnData.sectorCount);
                            labelStatusText.Text = string.Format("Progresso: {0}%", percent);
                            pbStatus.Value = percent;
                        }
                        else
                        {
                            labelStatusText.Text = "Progresso: 0%";
                            pbStatus.Value = 0;
                        }

                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_FINALIZATION:
                        labelStatusText.Text = "Finalizando gravação...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_COMPLETED:
                        labelStatusText.Text = "Concluido!";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_VERIFYING:
                        labelStatusText.Text = "Verificando";
                        break;
                }
        }

        /// <summary>
        ///     Enable the Burn Button if items in the file listbox
        /// </summary>
        private void EnableBurnButton()
        {
            btnBurn.Enabled = lbFiles.Items.Count > 0;
        }

        #endregion

        #region File System Process

        private bool CreateMediaFileSystem(IDiscRecorder2 discRecorder, object[] multisessionInterfaces,
            out IStream dataStream)
        {
            MsftFileSystemImage fileSystemImage = null;
            try
            {
                fileSystemImage = new MsftFileSystemImage();
                fileSystemImage.ChooseImageDefaults(discRecorder);
                fileSystemImage.FileSystemsToCreate =
                    FsiFileSystems.FsiFileSystemJoliet | FsiFileSystems.FsiFileSystemISO9660;
                fileSystemImage.VolumeName = tbVolumeLabel.Text;

                fileSystemImage.Update += fileSystemImage_Update;

                //
                // If multisessions, then import previous sessions
                //
                if (multisessionInterfaces != null)
                {
                    fileSystemImage.MultisessionInterfaces = multisessionInterfaces;
                    fileSystemImage.ImportFileSystem();
                }

                //
                // Get the image root
                //
                var rootItem = fileSystemImage.Root;

                //
                // Add Files and Directories to File System Image
                //
                foreach (IMediaItem mediaItem in lbFiles.Items)
                {
                    //
                    // Check if we've cancelled
                    //
                    if (bgBurnWorker.CancellationPending) break;

                    //
                    // Add to File System
                    //
                    mediaItem.AddToFileSystem(rootItem);
                }

                fileSystemImage.Update -= fileSystemImage_Update;

                //
                // did we cancel?
                //
                if (bgBurnWorker.CancellationPending)
                {
                    dataStream = null;
                    return false;
                }

                dataStream = fileSystemImage.CreateResultImage().ImageStream;
            }
            catch (COMException exception)
            {
                GlobalNotifications(exception.Message + " Erro ao Criar sistema de Arquivos!");
                //MessageBox.Show(this, exception.Message, "Erro ao Criar Sistema de Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataStream = null;
                return false;
            }
            finally
            {
                if (fileSystemImage != null) Marshal.ReleaseComObject(fileSystemImage);
            }

            return true;
        }

        /// <summary>
        ///     Event Handler for File System Progress Updates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="currentFile"></param>
        /// <param name="copiedSectors"></param>
        /// <param name="totalSectors"></param>
        private void fileSystemImage_Update([In] [MarshalAs(UnmanagedType.IDispatch)] object sender,
            [In] [MarshalAs(UnmanagedType.BStr)] string currentFile, [In] int copiedSectors, [In] int totalSectors)
        {
            var percentProgress = 0;
            if (copiedSectors > 0 && totalSectors > 0) percentProgress = copiedSectors * 100 / totalSectors;

            if (!string.IsNullOrEmpty(currentFile))
            {
                var fileInfo = new FileInfo(currentFile);
                _burnData.statusMessage = "Adicionando \"" + fileInfo.Name + "\" à imagem...";

                //
                // report back to the ui
                //
                _burnData.task = BURN_MEDIA_TASK.BURN_MEDIA_TASK_FILE_SYSTEM;
                bgBurnWorker.ReportProgress(percentProgress, _burnData);
            }
        }

        #endregion

        #region Add/Remove File(s)/Folder(s)

        /// <summary>
        ///     Adds a file to the burn list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                var fileItem = new FileItem(ofd.FileName);
                lbFiles.Items.Add(fileItem);

                UpdateCapacity();
                EnableBurnButton();
            }
        }

        /// <summary>
        ///     Adds a folder to the burn list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFolders_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                var directoryItem = new DirectoryItem(fbd.SelectedPath);
                lbFiles.Items.Add(directoryItem);

                UpdateCapacity();
                EnableBurnButton();
            }
        }

        /// <summary>
        ///     User wants to remove a file or folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveFiles_Click(object sender, EventArgs e)
        {
            var mediaItem = (IMediaItem)lbFiles.SelectedItem;
            if (mediaItem == null)
                return;

            if (MessageBox.Show("Você tem certeza que deseja remover \"" + mediaItem + "\"?",
                    "Remover item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lbFiles.Items.Remove(mediaItem);

                EnableBurnButton();
                UpdateCapacity();
            }
        }

        #endregion

        #region File ListBox Events

        /// <summary>
        ///     The user has selected a file or folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveFiles.Enabled = lbFiles.SelectedIndex != -1;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbFiles_DrawItem(object sender, DrawItemEventArgs e)
        {
            var mediaItem = (IMediaItem)lbFiles.Items[e.Index];
            if (mediaItem == null) return;

            e.DrawBackground();

            if ((e.State & DrawItemState.Focus) != 0) e.DrawFocusRectangle();

            if (mediaItem.FileIconImage != null)
                e.Graphics.DrawImage(mediaItem.FileIconImage, new Rectangle(4, e.Bounds.Y + 4, 16, 16));

            var rectF = new RectangleF(e.Bounds.X + 24, e.Bounds.Y,
                e.Bounds.Width - 24, e.Bounds.Height);

            var font = new Font(FontFamily.GenericSansSerif, 11);

            var stringFormat = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near,
                Trimming = StringTrimming.EllipsisCharacter
            };

            e.Graphics.DrawString(mediaItem.ToString(), font, new SolidBrush(e.ForeColor),
                rectF, stringFormat);
        }

        #endregion

        #region Format/Erase the Disc

        /// <summary>
        ///     The user has clicked the "Format" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFormat_Click(object sender, EventArgs e)
        {
            if (cbDevices.SelectedIndex == -1) return;

            _isFormatting = true;
            EnableFormatUI(false);

            var discRecorder = (IDiscRecorder2)cbDevices.Items[cbDevices.SelectedIndex];
            bgFormatWorker.RunWorkerAsync(discRecorder.ActiveDiscRecorder);
        }

        /// <summary>
        ///     Enables/Disables the "Burn" User Interface
        /// </summary>
        /// <param name="enable"></param>
        private void EnableFormatUI(bool enable)
        {
            btnFormat.Enabled = enable;
            chkEjectFormat.Enabled = enable;
            chkQuickFormat.Enabled = enable;
        }

        /// <summary>
        ///     Worker thread that Formats the Disc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgFormatWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MsftDiscRecorder2 discRecorder = null;
            MsftDiscFormat2Erase discFormatErase = null;

            try
            {
                //
                // Create and initialize the IDiscRecorder2
                //
                discRecorder = new MsftDiscRecorder2();
                var activeDiscRecorder = (string)e.Argument;
                discRecorder.InitializeDiscRecorder(activeDiscRecorder);

                //
                // Create the IDiscFormat2Erase and set properties
                //
                discFormatErase = new MsftDiscFormat2Erase
                {
                    Recorder = discRecorder,
                    ClientName = ClientName,
                    FullErase = !chkQuickFormat.Checked
                };

                //
                // Setup the Update progress event handler
                //
                discFormatErase.Update += discFormatErase_Update;

                //
                // Erase the media here
                //
                try
                {
                    discFormatErase.EraseMedia();
                    e.Result = 0;
                }
                catch (COMException ex)
                {
                    e.Result = ex.ErrorCode;
                    GlobalNotifications(ex.Message + "IDiscFormat2.EreaseMedia falhou!");
                    //MessageBox.Show(ex.Message, "IDiscFormat2.EraseMedia falhou!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                //
                // Remove the Update progress event handler
                //
                discFormatErase.Update -= discFormatErase_Update;

                //
                // Eject the media 
                //
                if (chkEjectFormat.Checked) discRecorder.EjectMedia();
            }
            catch (COMException exception)
            {
                //
                // If anything happens during the format, show the message
                //
                MessageBox.Show(exception.Message);
            }
            finally
            {
                if (discRecorder != null) Marshal.ReleaseComObject(discRecorder);

                if (discFormatErase != null) Marshal.ReleaseComObject(discFormatErase);
            }
        }

        /// <summary>
        ///     Event Handler for the Erase Progress Updates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="elapsedSeconds"></param>
        /// <param name="estimatedTotalSeconds"></param>
        private void discFormatErase_Update([In] [MarshalAs(UnmanagedType.IDispatch)] object sender, int elapsedSeconds,
            int estimatedTotalSeconds)
        {
            var percent = elapsedSeconds * 100 / estimatedTotalSeconds;
            //
            // Report back to the UI
            //
            bgFormatWorker.ReportProgress(percent);
        }

        private void bgFormatWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelFormatStatusText.Text = string.Format("Formatando {0}%...", e.ProgressPercentage);
            pbFormat.Value = e.ProgressPercentage;
        }

        private void bgFormatWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelFormatStatusText.Text =
                (int)e.Result == 0 ? "Formatação do disco finalizada!" : "Erro ao formatar o disco!";

            pbFormat.Value = 0;

            _isFormatting = false;
            EnableFormatUI(true);
        }

        #endregion
    }
}