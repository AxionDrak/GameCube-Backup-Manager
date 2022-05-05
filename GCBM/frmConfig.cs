using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmConfig : Form
    {
        #region Properties

        Assembly assembly = Assembly.GetExecutingAssembly();

        private static string GET_CURRENT_PATH   = Directory.GetCurrentDirectory();
        private static string COVERS_DIR         = GET_CURRENT_PATH + @"\covers\cache";
        private static string TEMP_DIR           = GET_CURRENT_PATH + @"\temp";
        private const string INI_FILE            = "config.ini";
        private readonly IniFile CONFIG_INI_FILE = new IniFile(INI_FILE);
        public int RETURN_CONFIRM { get; set; }
        #endregion

        #region Main Form
        /// <summary>
        /// 
        /// </summary>
        public frmConfig()
        {
            InitializeComponent();

            ConfigStart();
            LoadConfigFile();
        }
        #endregion

        #region ConfigStart
        private void ConfigStart()
        {
            cbLanguage.SelectedIndex = 0;
            cbAdjustNamingStyle.SelectedIndex = 0;
            cbGeneralFileSize.SelectedIndex = 0;
            cbScrubAlign.SelectedIndex = 0;
            cbScrubFormat.SelectedIndex = 1;
            cbTitleLanguage.SelectedIndex = 0;
            cbLevelLog.SelectedIndex = 0;
            cbVerificationInterval.SelectedIndex = 0;
            grbGeneralFiles.Enabled = false;
            tbGeneralTempPath.Text = TEMP_DIR;
            tbDirectoryCoverCache.Text = COVERS_DIR;
        }
        #endregion

        #region Notifications
        private void AdjustNotify(string text)
        {
            notifyIcon.ShowBalloonTip(10, "GameCube Backup Manager", "As notificações na barra de tarefas foram " + text + "!", ToolTipIcon.Info);
        }
        #endregion

        #region SaveConfigFile
        private void SaveConfigFile()
        {
            var _version = assembly.GetName().Version;

            // GCBM
            CONFIG_INI_FILE.IniWriteString("GCBM", "ProgUpdated", "30/04/2022");
            CONFIG_INI_FILE.IniWriteString("GCBM", "ProgVersion", _version.ToString());
            CONFIG_INI_FILE.IniWriteString("GCBM", "ConfigUpdated", DateTime.Now.ToString("dd/MM/yyyy"));

            if (CONFIG_INI_FILE.IniReadString("GCBM", "Language", "") != GCBM.Properties.Resources.GCBM_Language)
            {
                CONFIG_INI_FILE.IniWriteString("GCBM", "Language", GCBM.Properties.Resources.GCBM_Language);
            }

            if (CONFIG_INI_FILE.IniReadString("GCBM", "TranslatedBy", "") != GCBM.Properties.Resources.GCBM_TranslatedBy)
            {
                CONFIG_INI_FILE.IniWriteString("GCBM", "TranslatedBy", GCBM.Properties.Resources.GCBM_TranslatedBy);
            }

            //configIniFile.IniWriteString("GCBM", "Language", GCBM.Properties.Resources.GCBM_Language);
            //configIniFile.IniWriteString("GCBM", "TranslatedBy", GCBM.Properties.Resources.GCBM_TranslatedBy);

            // General          
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "DiscClean", rbGeneralDiscClean.Checked);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "DiscDelete", rbGeneralDiscDelete.Checked);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractZip", chkGeneralExtractZip.Checked);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "Extract7z", chkGeneralExtract7z.Checked);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractRar", chkGeneralExtractRar.Checked);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractBZip2", chkGeneralExtractBZip2.Checked);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractSplitFile", chkGeneralExtractSplitFile.Checked);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractNwb", chkGeneralExtractNwb.Checked);
            CONFIG_INI_FILE.IniWriteInt("GENERAL", "FileSize", cbGeneralFileSize.SelectedIndex);

            if (tbGeneralTempPath.Text == string.Empty)
            {
                tbGeneralTempPath.Text = TEMP_DIR;
                CONFIG_INI_FILE.IniWriteString("GENERAL", "TemporaryFolder", TEMP_DIR);
            }
            else
            {
                CONFIG_INI_FILE.IniWriteString("GENERAL", "TemporaryFolder", tbGeneralTempPath.Text);
            }

            // Several
            CONFIG_INI_FILE.IniWriteInt("SEVERAL", "AppointmentStyle", cbAdjustNamingStyle.SelectedIndex);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "CheckMD5", chkGeneralMD5.Checked);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "CheckSHA1", chkGeneralSHA1.Checked);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "CheckNotify", chkNotify.Checked);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "NetVerify", chkNetVerify.Checked);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "RecursiveMode", chkGeneralRecursiva.Checked);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "TemporaryBuffer", chkGeneralTemporaryBuffer.Checked);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "WindowMaximized", chkStartWindowMaximized.Checked);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "Welcome", chkWelcome.Checked);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "Screensaver", chkScreensaver.Checked);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "LoadDatabase", chkLoadDatabase.Checked);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "MultipleInstances", chkMultipleInstances.Checked);

            // TransferSystem
            CONFIG_INI_FILE.IniWriteBool("TRANSFERSYSTEM", "FST", rbTransferSystemFST.Checked);
            CONFIG_INI_FILE.IniWriteBool("TRANSFERSYSTEM", "ScrubFlushSD", chkGeneralScrubFlushSD.Checked);
            CONFIG_INI_FILE.IniWriteInt("TRANSFERSYSTEM", "ScrubAlign", cbScrubAlign.SelectedIndex);
            CONFIG_INI_FILE.IniWriteString("TRANSFERSYSTEM", "ScrubFormat", cbScrubFormat.Text);
            CONFIG_INI_FILE.IniWriteInt("TRANSFERSYSTEM", "ScrubFormatIndex", cbScrubFormat.SelectedIndex);
            CONFIG_INI_FILE.IniWriteBool("TRANSFERSYSTEM", "Wipe", rbTransferSystemWipe.Checked);
            CONFIG_INI_FILE.IniWriteBool("TRANSFERSYSTEM", "XCopy", rbTransferSystemXCopy.Checked);

            // Covers
            CONFIG_INI_FILE.IniWriteBool("COVERS", "DeleteCovers", chkCoverSynchronizeDelete.Checked);
            CONFIG_INI_FILE.IniWriteBool("COVERS", "CoverRecursiveSearch", chkCoverRecursiveSearch.Checked);
            CONFIG_INI_FILE.IniWriteBool("COVERS", "TransferCovers", chkCoverEnableTransfer.Checked);
            CONFIG_INI_FILE.IniWriteBool("COVERS", "WiiFlowCoverUSBLoader", rbCoverWiiFlow.Checked);
            CONFIG_INI_FILE.IniWriteBool("COVERS", "GXCoverUSBLoader", rbCoverUSBLoaderGX.Checked);

            if (tbDirectoryCoverCache.Text == string.Empty)
            {
                tbDirectoryCoverCache.Text = COVERS_DIR;
                CONFIG_INI_FILE.IniWriteString("COVERS", "CoverDirectoryCache", COVERS_DIR);
            }
            else
            {
                CONFIG_INI_FILE.IniWriteString("COVERS", "CoverDirectoryCache", tbDirectoryCoverCache.Text);
            }

            if (rbCoverWiiFlow.Checked)
            {
                CONFIG_INI_FILE.IniWriteString("COVERS", "WiiFlowCoverDirectoryDisc", tbDirectoryCoverDisc.Text);
                CONFIG_INI_FILE.IniWriteString("COVERS", "WiiFlowCoverDirectory2D", tbDirectoryCover2D.Text);
                CONFIG_INI_FILE.IniWriteString("COVERS", "WiiFlowCoverDirectory3D", tbDirectoryCover3D.Text);
                CONFIG_INI_FILE.IniWriteString("COVERS", "WiiFlowCoverDirectoryFull", tbDirectoryCoverFull.Text);
            }
            else
            {
                CONFIG_INI_FILE.IniWriteString("COVERS", "GXCoverDirectoryDisc", tbDirectoryCoverDisc.Text);
                CONFIG_INI_FILE.IniWriteString("COVERS", "GXCoverDirectory2D", tbDirectoryCover2D.Text);
                CONFIG_INI_FILE.IniWriteString("COVERS", "GXCoverDirectory3D", tbDirectoryCover3D.Text);
                CONFIG_INI_FILE.IniWriteString("COVERS", "GXCoverDirectoryFull", tbDirectoryCoverFull.Text);
            }

            // Titles
            CONFIG_INI_FILE.IniWriteBool("TITLES", "GameCustomTitles", chkGameTitleCustom.Checked);
            CONFIG_INI_FILE.IniWriteBool("TITLES", "GameTdbTitles", chkGameTitle.Checked);
            CONFIG_INI_FILE.IniWriteBool("TITLES", "GameInternalName", rbGameInternalName.Checked);
            CONFIG_INI_FILE.IniWriteBool("TITLES", "GameXmlName", rbGameXmlName.Checked);
            CONFIG_INI_FILE.IniWriteString("TITLES", "LocationTitles", tbTitle.Text);
            CONFIG_INI_FILE.IniWriteString("TITLES", "LocationCustomTitles", tbTitleCustom.Text);
            CONFIG_INI_FILE.IniWriteInt("TITLES", "TitleLanguage", cbTitleLanguage.SelectedIndex);

            // Downloads
            //configIniFile.IniWriteBool("DOWNLOADS", "ListTaskComplete", chkDownloadTaskComplete.Checked);
            //configIniFile.IniWriteBool("DOWNLOADS", "ListTaskFailure", chkDownloadTaskFailure.Checked);
            //configIniFile.IniWriteBool("DOWNLOADS", "ListTaskCanceled", chkDownloadTaskCanceled.Checked);
            //configIniFile.IniWriteBool("DOWNLOADS", "PreviewCovers", chkDownloadPreviewCovers.Checked);

            // Updates
            CONFIG_INI_FILE.IniWriteBool("UPDATES", "UpdateVerifyStart", chkUpdateVerifyStart.Checked);
            CONFIG_INI_FILE.IniWriteBool("UPDATES", "UpdateBetaChannel", chkUpdateBetaChannel.Checked);
            CONFIG_INI_FILE.IniWriteBool("UPDATES", "UpdateFileLog", chkUpdateFileLog.Checked);
            CONFIG_INI_FILE.IniWriteBool("UPDATES", "UpdateServerProxy", chkUpdateServerProxy.Checked);
            CONFIG_INI_FILE.IniWriteString("UPDATES", "ServerProxy", tbServerProxy.Text);
            CONFIG_INI_FILE.IniWriteString("UPDATES", "UserProxy", tbUserProxy.Text);
            CONFIG_INI_FILE.IniWriteString("UPDATES", "PassProxy", tbPassProxy.Text);
            CONFIG_INI_FILE.IniWriteInt("UPDATES", "VerificationInterval", cbVerificationInterval.SelectedIndex);

            // Manager Log
            CONFIG_INI_FILE.IniWriteInt("MANAGERLOG", "LogLevel", cbLevelLog.SelectedIndex);
            CONFIG_INI_FILE.IniWriteBool("MANAGERLOG", "LogSystemConsole", chkManagerLogSystemConsole.Checked);
            CONFIG_INI_FILE.IniWriteBool("MANAGERLOG", "LogDebugConsole", chkManagerLogDebugConsole.Checked);
            CONFIG_INI_FILE.IniWriteBool("MANAGERLOG", "LogWindow", chkManagerLogWindow.Checked);
            CONFIG_INI_FILE.IniWriteBool("MANAGERLOG", "LogFile", chkManagerLogFile.Checked);

            // Language
            CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", cbLanguage.SelectedIndex);
        }
        #endregion

        #region LoadConfigFile
        private void LoadConfigFile()
        {
            if (File.Exists(GET_CURRENT_PATH + @"\config.ini"))
            {
                // General
                rbGeneralDiscClean.Checked = CONFIG_INI_FILE.IniReadBool("GENERAL", "DiscClean");
                rbGeneralDiscDelete.Checked = CONFIG_INI_FILE.IniReadBool("GENERAL", "DiscDelete");
                chkGeneralExtractZip.Checked = CONFIG_INI_FILE.IniReadBool("GENERAL", "ExtractZip");
                chkGeneralExtract7z.Checked = CONFIG_INI_FILE.IniReadBool("GENERAL", "Extract7z");
                chkGeneralExtractRar.Checked = CONFIG_INI_FILE.IniReadBool("GENERAL", "ExtractRar");
                chkGeneralExtractBZip2.Checked = CONFIG_INI_FILE.IniReadBool("GENERAL", "ExtractBZip2");
                chkGeneralExtractSplitFile.Checked = CONFIG_INI_FILE.IniReadBool("GENERAL", "ExtractSplitFile");
                chkGeneralExtractNwb.Checked = CONFIG_INI_FILE.IniReadBool("GENERAL", "ExtractNwb");
                cbGeneralFileSize.SelectedIndex = CONFIG_INI_FILE.IniReadInt("GENERAL", "FileSize");

                if (CONFIG_INI_FILE.IniReadString("GENERAL", "TemporaryFolder", "") == string.Empty)
                {
                    tbGeneralTempPath.Text = TEMP_DIR;
                }
                else
                {
                    tbGeneralTempPath.Text = CONFIG_INI_FILE.IniReadString("GENERAL", "TemporaryFolder", "");
                }

                // Several
                cbAdjustNamingStyle.SelectedIndex = CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle");
                chkGeneralMD5.Checked = CONFIG_INI_FILE.IniReadBool("SEVERAL", "CheckMD5");
                chkGeneralSHA1.Checked = CONFIG_INI_FILE.IniReadBool("SEVERAL", "CheckSHA1");
                chkNotify.Checked = CONFIG_INI_FILE.IniReadBool("SEVERAL", "CheckNotify");
                chkNetVerify.Checked = CONFIG_INI_FILE.IniReadBool("SEVERAL", "NetVerify");
                chkGeneralRecursiva.Checked = CONFIG_INI_FILE.IniReadBool("SEVERAL", "RecursiveMode");
                chkGeneralTemporaryBuffer.Checked = CONFIG_INI_FILE.IniReadBool("SEVERAL", "TemporaryBuffer");
                chkStartWindowMaximized.Checked = CONFIG_INI_FILE.IniReadBool("SEVERAL", "WindowMaximized");
                chkWelcome.Checked = CONFIG_INI_FILE.IniReadBool("SEVERAL", "Welcome");
                chkScreensaver.Checked = CONFIG_INI_FILE.IniReadBool("SEVERAL", "Screensaver");
                chkLoadDatabase.Checked = CONFIG_INI_FILE.IniReadBool("SEVERAL", "LoadDatabase");
                chkMultipleInstances.Checked = CONFIG_INI_FILE.IniReadBool("SEVERAL", "MultipleInstances");

                // TransferSystem
                rbTransferSystemFST.Checked = CONFIG_INI_FILE.IniReadBool("TRANSFERSYSTEM", "FST");
                chkGeneralScrubFlushSD.Checked = CONFIG_INI_FILE.IniReadBool("TRANSFERSYSTEM", "ScrubFlushSD");
                cbScrubAlign.SelectedIndex = CONFIG_INI_FILE.IniReadInt("TRANSFERSYSTEM", "ScrubAlign");
                //cbScrubFormat.Text = configIniFile.IniReadString("TRANSFERSYSTEM", "ScrubFormat", "");
                cbScrubFormat.SelectedIndex = CONFIG_INI_FILE.IniReadInt("TRANSFERSYSTEM", "ScrubFormatIndex");
                rbTransferSystemWipe.Checked = CONFIG_INI_FILE.IniReadBool("TRANSFERSYSTEM", "Wipe");
                rbTransferSystemXCopy.Checked = CONFIG_INI_FILE.IniReadBool("TRANSFERSYSTEM", "XCopy");

                // Covers
                chkCoverSynchronizeDelete.Checked = CONFIG_INI_FILE.IniReadBool("COVERS", "DeleteCovers");
                chkCoverRecursiveSearch.Checked = CONFIG_INI_FILE.IniReadBool("COVERS", "CoverRecursiveSearch");
                chkCoverEnableTransfer.Checked = CONFIG_INI_FILE.IniReadBool("COVERS", "TransferCovers");
                rbCoverWiiFlow.Checked = CONFIG_INI_FILE.IniReadBool("COVERS", "WiiFlowCoverUSBLoader");
                rbCoverUSBLoaderGX.Checked = CONFIG_INI_FILE.IniReadBool("COVERS", "GXCoverUSBLoader");

                if (CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "") == string.Empty)
                {
                    tbDirectoryCoverCache.Text = COVERS_DIR;
                }
                else
                {
                    tbDirectoryCoverCache.Text = CONFIG_INI_FILE.IniReadString("COVERS", "CoverDirectoryCache", "");
                }

                if (rbCoverWiiFlow.Checked)
                {
                    tbDirectoryCoverDisc.Text = CONFIG_INI_FILE.IniReadString("COVERS", "WiiFlowCoverDirectoryDisc", "");
                    tbDirectoryCover2D.Text = CONFIG_INI_FILE.IniReadString("COVERS", "WiiFlowCoverDirectory2D", "");
                    tbDirectoryCover3D.Text = CONFIG_INI_FILE.IniReadString("COVERS", "WiiFlowCoverDirectory3D", "");
                    tbDirectoryCoverFull.Text = CONFIG_INI_FILE.IniReadString("COVERS", "WiiFlowCoverDirectoryFull", "");
                }
                else
                {
                    tbDirectoryCoverDisc.Text = CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectoryDisc", "");
                    tbDirectoryCover2D.Text = CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectory2D", "");
                    tbDirectoryCover3D.Text = CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectory3D", "");
                    tbDirectoryCoverFull.Text = CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectoryFull", "");
                }

                // Titles
                chkGameTitle.Checked = CONFIG_INI_FILE.IniReadBool("TITLES", "GameTdbTitles");
                rbGameInternalName.Checked = CONFIG_INI_FILE.IniReadBool("TITLES", "GameInternalName");
                rbGameXmlName.Checked = CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName");
                chkGameTitleCustom.Checked = CONFIG_INI_FILE.IniReadBool("TITLES", "GameCustomTitles");
                tbTitle.Text = CONFIG_INI_FILE.IniReadString("TITLES", "LocationTitles", "");
                tbTitleCustom.Text = CONFIG_INI_FILE.IniReadString("TITLES", "LocationCustomTitles", "");
                cbTitleLanguage.SelectedIndex = CONFIG_INI_FILE.IniReadInt("TITLES", "TitleLanguage");

                // Downloads
                //chkDownloadTaskComplete.Checked = configIniFile.IniReadBool("DOWNLOADS", "ListTaskComplete");
                //chkDownloadTaskFailure.Checked = configIniFile.IniReadBool("DOWNLOADS", "ListTaskFailure");
                //chkDownloadTaskCanceled.Checked = configIniFile.IniReadBool("DOWNLOADS", "ListTaskCanceled");
                //chkDownloadPreviewCovers.Checked = configIniFile.IniReadBool("DOWNLOADS", "PreviewCovers");

                // Updates
                chkUpdateVerifyStart.Checked = CONFIG_INI_FILE.IniReadBool("UPDATES", "UpdateVerifyStart");
                chkUpdateBetaChannel.Checked = CONFIG_INI_FILE.IniReadBool("UPDATES", "UpdateBetaChannel");
                chkUpdateFileLog.Checked = CONFIG_INI_FILE.IniReadBool("UPDATES", "UpdateFileLog");
                chkUpdateServerProxy.Checked = CONFIG_INI_FILE.IniReadBool("UPDATES", "UpdateServerProxy");
                tbServerProxy.Text = CONFIG_INI_FILE.IniReadString("UPDATES", "ServerProxy", "");
                tbUserProxy.Text = CONFIG_INI_FILE.IniReadString("UPDATES", "UserProxy", "");
                tbPassProxy.Text = CONFIG_INI_FILE.IniReadString("UPDATES", "PassProxy", "");
                cbVerificationInterval.SelectedIndex = CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval");

                // Manager Log
                cbLevelLog.SelectedIndex = CONFIG_INI_FILE.IniReadInt("MANAGERLOG", "LogLevel");
                chkManagerLogSystemConsole.Checked = CONFIG_INI_FILE.IniReadBool("MANAGERLOG", "LogSystemConsole");
                chkManagerLogDebugConsole.Checked = CONFIG_INI_FILE.IniReadBool("MANAGERLOG", "LogDebugConsole");
                chkManagerLogWindow.Checked = CONFIG_INI_FILE.IniReadBool("MANAGERLOG", "LogWindow");
                chkManagerLogFile.Checked = CONFIG_INI_FILE.IniReadBool("MANAGERLOG", "LogFile");

                // Language
                cbLanguage.SelectedIndex = CONFIG_INI_FILE.IniReadInt("LANGUAGE", "ConfigLanguage");
            }
        }
        #endregion

        #region Buttons
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.notifyIcon.Dispose();
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveConfigFile();

            //MessageBox.Show("Deseja mesmo sair?", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.RETURN_CONFIRM = 1;
            this.Close();
            this.notifyIcon.Dispose();
            this.Dispose();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            //RestoreDefault();
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja restaurar as configurações?"
                + Environment.NewLine + Environment.NewLine +
                "Isso irá apagar o arquivo de configuração e reinicar o programa!!", 
                "Confirmação", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                if (File.Exists("config.ini"))
                {
                    File.Delete("config.ini");
                    //Reinicia a aplicação (fecha e reabre)
                    Application.Restart();
                }
            }
        }

        private void btnTemporaryFolder_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbGeneralTempPath.Text = fbd.SelectedPath;
            }
        }

        private void btnCoverDirectory_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbDirectoryCoverCache.Text = fbd.SelectedPath;
            }
        }

        private void btnDirectoryCoverDisc_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbDirectoryCoverDisc.Text = fbd.SelectedPath;
            }
        }

        private void btnDirectoryCover2D_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbDirectoryCover2D.Text = fbd.SelectedPath;
            }
        }

        private void btnDirectoryCover3D_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbDirectoryCover3D.Text = fbd.SelectedPath;
            }
        }

        private void btnDirectoryCoverFull_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbDirectoryCoverFull.Text = fbd.SelectedPath;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveConfigFile();
        }
        #endregion

        #region cbUpdateServerProxy_CheckedChanged
        private void cbUpdateServerProxy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdateServerProxy.Checked)
            {
                tbPassProxy.Enabled = true;
                tbServerProxy.Enabled = true;
                tbUserProxy.Enabled = true;
            }
            else
            {
                tbServerProxy.Text = "";
                tbUserProxy.Text = "";
                tbPassProxy.Text = "";
                tbPassProxy.Enabled = false;
                tbServerProxy.Enabled = false;
                tbUserProxy.Enabled = false;
            }
        }
        #endregion

        #region chkCoverEnableTransfer_CheckedChanged
        private void chkCoverEnableTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCoverEnableTransfer.Checked)
            {
                //tsmiTransferDeviceCovers.Enabled = true;
                grbCoverTransfer.Enabled = true;
            }
            else
            {
                //tsmiTransferDeviceCovers.Enabled = false;
                grbCoverTransfer.Enabled = false;
            }
        }
        #endregion

        #region rbCoverWiiFlow_CheckedChanged
        private void rbCoverWiiFlow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCoverWiiFlow.Checked == true)
            {
                tbDirectoryCoverDisc.Text = string.Empty;
                tbDirectoryCover3D.Text = string.Empty;
                ((Control)tabControl2.TabPages["tabCoverDisc"]).Enabled = false;
                ((Control)tabControl2.TabPages["tabCover3D"]).Enabled = false;
            }
            else
            {
                ((Control)tabControl2.TabPages["tabCoverDisc"]).Enabled = true;
                ((Control)tabControl2.TabPages["tabCover3D"]).Enabled = true;
            }

            //tbDirectoryCoverDisc.Text = configIniFile.IniReadString("Covers", "WiiFlowCoverDirectoryDisc", "");
            tbDirectoryCover2D.Text = CONFIG_INI_FILE.IniReadString("Covers", "WiiFlowCoverDirectory2D", "");
            //tbDirectoryCover3D.Text = configIniFile.IniReadString("Covers", "WiiFlowCoverDirectory3D", "");
            tbDirectoryCoverFull.Text = CONFIG_INI_FILE.IniReadString("Covers", "WiiFlowCoverDirectoryFull", "");
        }
        #endregion

        #region rbCoverUSBLoaderGX_CheckedChanged
        private void rbCoverUSBLoaderGX_CheckedChanged(object sender, EventArgs e)
        {
            tbDirectoryCoverDisc.Text = CONFIG_INI_FILE.IniReadString("Covers", "GXCoverDirectoryDisc", "");
            tbDirectoryCover2D.Text = CONFIG_INI_FILE.IniReadString("Covers", "GXCoverDirectory2D", "");
            tbDirectoryCover3D.Text = CONFIG_INI_FILE.IniReadString("Covers", "GXCoverDirectory3D", "");
            tbDirectoryCoverFull.Text = CONFIG_INI_FILE.IniReadString("Covers", "GXCoverDirectoryFull", "");
        }
        #endregion

        #region chkGameTitle_CheckedChanged
        private void chkGameTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGameTitle.Checked == true)
            {
                grbTitleLanguage.Enabled = true;
            }
            else
            {
                grbTitleLanguage.Enabled = false;
            }
        }
        #endregion

        #region chkNotify_Click
        private void chkNotify_Click(object sender, EventArgs e)
        {
            if (chkNotify.CheckState == CheckState.Checked)
            {
                AdjustNotify("ativadas");
            }
            else
            {
                AdjustNotify("desativadas");
            }
        }
        #endregion

        #region chkUpdateVerifyStart_CheckedChanged
        private void chkUpdateVerifyStart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdateVerifyStart.Checked)
            {
                //chkUpdateBetaChannel.Enabled = true;
                chkUpdateServerProxy.Enabled = true;
                cbVerificationInterval.Enabled = true;
            }
            else
            {
                //chkUpdateBetaChannel.Enabled = false;
                chkUpdateServerProxy.Enabled = false;
                //chkUpdateBetaChannel.Checked = false;
                chkUpdateServerProxy.Checked = false;
                cbVerificationInterval.Enabled = false;
            }
        }
        #endregion
    }
}
