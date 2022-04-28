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
        /// <summary>
        /// Invoke Assembly
        /// </summary>
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Get Current Directory
        private static string getCurrentPath = Directory.GetCurrentDirectory();
        // Default folders
        private static string coverPathDefault = getCurrentPath + @"\covers\cache";
        private static string tempPathDefault = getCurrentPath + @"\temp";
        // IniFile 
        private readonly IniFile configIniFile = new IniFile("config.ini");
        public int _returnConfirm { get; set; }
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
            tbGeneralTempPath.Text = tempPathDefault;
            tbDirectoryCoverCache.Text = coverPathDefault;
        }
        #endregion

        #region Notifications
        private void UpdateProgram()
        {
            notifyIcon.ShowBalloonTip(10, "GameCube Backup Manager", "Nova atualização disponível!", ToolTipIcon.Info);
        }

        private void NetVerify()
        {
            notifyIcon.ShowBalloonTip(10, "GameCube Backup Manager", "Por favor, reinicie o programa para que a " +
                "configuração seja aplicada corretamente.", ToolTipIcon.Info);
        }

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
            configIniFile.IniWriteString("GCBM", "Language", "Portuguese");
            configIniFile.IniWriteString("GCBM", "TranslatedBy", "Laete Meireles");
            configIniFile.IniWriteString("GCBM", "TranslatorContact", "laetemn@hotmail.com");
            configIniFile.IniWriteString("GCBM", "LastUpdated", "22/04/2022");
            configIniFile.IniWriteString("GCBM", "ProgVersion", _version.ToString());

            // General          
            configIniFile.IniWriteBool("GENERAL", "DiscClean", rbGeneralDiscClean.Checked);
            configIniFile.IniWriteBool("GENERAL", "DiscDelete", rbGeneralDiscDelete.Checked);
            configIniFile.IniWriteBool("GENERAL", "ExtractZip", chkGeneralExtractZip.Checked);
            configIniFile.IniWriteBool("GENERAL", "Extract7z", chkGeneralExtract7z.Checked);
            configIniFile.IniWriteBool("GENERAL", "ExtractRar", chkGeneralExtractRar.Checked);
            configIniFile.IniWriteBool("GENERAL", "ExtractBZip2", chkGeneralExtractBZip2.Checked);
            configIniFile.IniWriteBool("GENERAL", "ExtractSplitFile", chkGeneralExtractSplitFile.Checked);
            configIniFile.IniWriteBool("GENERAL", "ExtractNwb", chkGeneralExtractNwb.Checked);
            configIniFile.IniWriteInt("GENERAL", "FileSize", cbGeneralFileSize.SelectedIndex);

            if (tbGeneralTempPath.Text == string.Empty)
            {
                tbGeneralTempPath.Text = tempPathDefault;
                configIniFile.IniWriteString("GENERAL", "TemporaryFolder", tempPathDefault);
            }
            else
            {
                configIniFile.IniWriteString("GENERAL", "TemporaryFolder", tbGeneralTempPath.Text);
            }

            // Several
            configIniFile.IniWriteInt("SEVERAL", "AppointmentStyle", cbAdjustNamingStyle.SelectedIndex);
            configIniFile.IniWriteBool("SEVERAL", "CheckMD5", chkGeneralMD5.Checked);
            configIniFile.IniWriteBool("SEVERAL", "CheckSHA1", chkGeneralSHA1.Checked);
            configIniFile.IniWriteBool("SEVERAL", "CheckNotify", chkNotify.Checked);
            configIniFile.IniWriteBool("SEVERAL", "NetVerify", chkNetVerify.Checked);
            configIniFile.IniWriteBool("SEVERAL", "RecursiveMode", chkGeneralRecursiva.Checked);
            configIniFile.IniWriteBool("SEVERAL", "SupportNkit", chkEnableSupportNkit.Checked);
            configIniFile.IniWriteBool("SEVERAL", "TemporaryBuffer", chkGeneralTemporaryBuffer.Checked);
            configIniFile.IniWriteBool("SEVERAL", "WindowMaximized", chkStartWindowMaximized.Checked);
            //configIniFile.IniWriteBool("SEVERAL", "EnableSupportNkit", chkEnableSupportNkit.Checked);
            configIniFile.IniWriteBool("SEVERAL", "Welcome", chkWelcome.Checked);
            configIniFile.IniWriteBool("SEVERAL", "Screensaver", chkScreensaver.Checked);
            configIniFile.IniWriteBool("SEVERAL", "LoadDatabase", chkLoadDatabase.Checked);
            configIniFile.IniWriteBool("SEVERAL", "MultipleInstances", chkMultipleInstances.Checked);

            // TransferSystem
            configIniFile.IniWriteBool("TRANSFERSYSTEM", "FST", rbTransferSystemFST.Checked);
            configIniFile.IniWriteBool("TRANSFERSYSTEM", "ScrubFlushSD", chkGeneralScrubFlushSD.Checked);
            configIniFile.IniWriteInt("TRANSFERSYSTEM", "ScrubAlign", cbScrubAlign.SelectedIndex);
            configIniFile.IniWriteString("TRANSFERSYSTEM", "ScrubFormat", cbScrubFormat.Text);
            configIniFile.IniWriteInt("TRANSFERSYSTEM", "ScrubFormatIndex", cbScrubFormat.SelectedIndex);
            configIniFile.IniWriteBool("TRANSFERSYSTEM", "Wipe", rbTransferSystemWipe.Checked);
            configIniFile.IniWriteBool("TRANSFERSYSTEM", "XCopy", rbTransferSystemXCopy.Checked);

            // Covers
            configIniFile.IniWriteBool("COVERS", "DeleteCovers", chkCoverSynchronizeDelete.Checked);
            configIniFile.IniWriteBool("COVERS", "CoverRecursiveSearch", chkCoverRecursiveSearch.Checked);
            configIniFile.IniWriteBool("COVERS", "TransferCovers", chkCoverEnableTransfer.Checked);
            configIniFile.IniWriteBool("COVERS", "WiiFlowCoverUSBLoader", rbCoverWiiFlow.Checked);
            configIniFile.IniWriteBool("COVERS", "GXCoverUSBLoader", rbCoverUSBLoaderGX.Checked);

            if (tbDirectoryCoverCache.Text == string.Empty)
            {
                tbDirectoryCoverCache.Text = coverPathDefault;
                configIniFile.IniWriteString("COVERS", "CoverDirectoryCache", coverPathDefault);
            }
            else
            {
                configIniFile.IniWriteString("COVERS", "CoverDirectoryCache", tbDirectoryCoverCache.Text);
            }

            if (rbCoverWiiFlow.Checked)
            {
                configIniFile.IniWriteString("COVERS", "WiiFlowCoverDirectoryDisc", tbDirectoryCoverDisc.Text);
                configIniFile.IniWriteString("COVERS", "WiiFlowCoverDirectory2D", tbDirectoryCover2D.Text);
                configIniFile.IniWriteString("COVERS", "WiiFlowCoverDirectory3D", tbDirectoryCover3D.Text);
                configIniFile.IniWriteString("COVERS", "WiiFlowCoverDirectoryFull", tbDirectoryCoverFull.Text);
            }
            else
            {
                configIniFile.IniWriteString("COVERS", "GXCoverDirectoryDisc", tbDirectoryCoverDisc.Text);
                configIniFile.IniWriteString("COVERS", "GXCoverDirectory2D", tbDirectoryCover2D.Text);
                configIniFile.IniWriteString("COVERS", "GXCoverDirectory3D", tbDirectoryCover3D.Text);
                configIniFile.IniWriteString("COVERS", "GXCoverDirectoryFull", tbDirectoryCoverFull.Text);
            }

            // Titles
            configIniFile.IniWriteBool("TITLES", "GameCustomTitles", chkGameTitleCustom.Checked);
            configIniFile.IniWriteBool("TITLES", "GameTdbTitles", chkGameTitle.Checked);
            configIniFile.IniWriteBool("TITLES", "GameInternalName", rbGameInternalName.Checked);
            configIniFile.IniWriteBool("TITLES", "GameXmlName", rbGameXmlName.Checked);
            configIniFile.IniWriteString("TITLES", "LocationTitles", tbTitle.Text);
            configIniFile.IniWriteString("TITLES", "LocationCustomTitles", tbTitleCustom.Text);
            configIniFile.IniWriteInt("TITLES", "TitleLanguage", cbTitleLanguage.SelectedIndex);

            // Downloads
            //configIniFile.IniWriteBool("DOWNLOADS", "ListTaskComplete", chkDownloadTaskComplete.Checked);
            //configIniFile.IniWriteBool("DOWNLOADS", "ListTaskFailure", chkDownloadTaskFailure.Checked);
            //configIniFile.IniWriteBool("DOWNLOADS", "ListTaskCanceled", chkDownloadTaskCanceled.Checked);
            //configIniFile.IniWriteBool("DOWNLOADS", "PreviewCovers", chkDownloadPreviewCovers.Checked);

            // Updates
            configIniFile.IniWriteBool("UPDATES", "UpdateVerifyStart", chkUpdateVerifyStart.Checked);
            configIniFile.IniWriteBool("UPDATES", "UpdateBetaChannel", chkUpdateBetaChannel.Checked);
            configIniFile.IniWriteBool("UPDATES", "UpdateFileLog", chkUpdateFileLog.Checked);
            configIniFile.IniWriteBool("UPDATES", "UpdateServerProxy", chkUpdateServerProxy.Checked);
            configIniFile.IniWriteString("UPDATES", "ServerProxy", tbServerProxy.Text);
            configIniFile.IniWriteString("UPDATES", "UserProxy", tbUserProxy.Text);
            configIniFile.IniWriteString("UPDATES", "PassProxy", tbPassProxy.Text);
            configIniFile.IniWriteInt("UPDATES", "VerificationInterval", cbVerificationInterval.SelectedIndex);

            // Manager Log
            configIniFile.IniWriteInt("MANAGERLOG", "LogLevel", cbLevelLog.SelectedIndex);
            configIniFile.IniWriteBool("MANAGERLOG", "LogSystemConsole", chkManagerLogSystemConsole.Checked);
            configIniFile.IniWriteBool("MANAGERLOG", "LogDebugConsole", chkManagerLogDebugConsole.Checked);
            configIniFile.IniWriteBool("MANAGERLOG", "LogWindow", chkManagerLogWindow.Checked);
            configIniFile.IniWriteBool("MANAGERLOG", "LogFile", chkManagerLogFile.Checked);

            // Language
            configIniFile.IniWriteInt("LANGUAGE", "ConfigLanguage", cbLanguage.SelectedIndex);
        }
        #endregion

        #region LoadConfigFile
        private void LoadConfigFile()
        {
            if (File.Exists(getCurrentPath + @"\config.ini"))
            {
                // General
                rbGeneralDiscClean.Checked = configIniFile.IniReadBool("GENERAL", "DiscClean");
                rbGeneralDiscDelete.Checked = configIniFile.IniReadBool("GENERAL", "DiscDelete");
                chkGeneralExtractZip.Checked = configIniFile.IniReadBool("GENERAL", "ExtractZip");
                chkGeneralExtract7z.Checked = configIniFile.IniReadBool("GENERAL", "Extract7z");
                chkGeneralExtractRar.Checked = configIniFile.IniReadBool("GENERAL", "ExtractRar");
                chkGeneralExtractBZip2.Checked = configIniFile.IniReadBool("GENERAL", "ExtractBZip2");
                chkGeneralExtractSplitFile.Checked = configIniFile.IniReadBool("GENERAL", "ExtractSplitFile");
                chkGeneralExtractNwb.Checked = configIniFile.IniReadBool("GENERAL", "ExtractNwb");
                cbGeneralFileSize.SelectedIndex = configIniFile.IniReadInt("GENERAL", "FileSize");

                if (configIniFile.IniReadString("GENERAL", "TemporaryFolder", "") == string.Empty)
                {
                    tbGeneralTempPath.Text = tempPathDefault;
                }
                else
                {
                    tbGeneralTempPath.Text = configIniFile.IniReadString("GENERAL", "TemporaryFolder", "");
                }

                // Several
                cbAdjustNamingStyle.SelectedIndex = configIniFile.IniReadInt("SEVERAL", "AppointmentStyle");
                chkGeneralMD5.Checked = configIniFile.IniReadBool("SEVERAL", "CheckMD5");
                chkGeneralSHA1.Checked = configIniFile.IniReadBool("SEVERAL", "CheckSHA1");
                chkNotify.Checked = configIniFile.IniReadBool("SEVERAL", "CheckNotify");
                chkNetVerify.Checked = configIniFile.IniReadBool("SEVERAL", "NetVerify");
                chkGeneralRecursiva.Checked = configIniFile.IniReadBool("SEVERAL", "RecursiveMode");
                chkEnableSupportNkit.Checked = configIniFile.IniReadBool("SEVERAL", "SupportNkit");
                chkGeneralTemporaryBuffer.Checked = configIniFile.IniReadBool("SEVERAL", "TemporaryBuffer");
                chkStartWindowMaximized.Checked = configIniFile.IniReadBool("SEVERAL", "WindowMaximized");
                //chkEnableSupportNkit.Checked = configIniFile.IniReadBool("SEVERAL", "EnableSupportNkit");
                chkWelcome.Checked = configIniFile.IniReadBool("SEVERAL", "Welcome");
                chkScreensaver.Checked = configIniFile.IniReadBool("SEVERAL", "Screensaver");
                chkLoadDatabase.Checked = configIniFile.IniReadBool("SEVERAL", "LoadDatabase");
                chkMultipleInstances.Checked = configIniFile.IniReadBool("SEVERAL", "MultipleInstances");

                // TransferSystem
                rbTransferSystemFST.Checked = configIniFile.IniReadBool("TRANSFERSYSTEM", "FST");
                chkGeneralScrubFlushSD.Checked = configIniFile.IniReadBool("TRANSFERSYSTEM", "ScrubFlushSD");
                cbScrubAlign.SelectedIndex = configIniFile.IniReadInt("TRANSFERSYSTEM", "ScrubAlign");
                //cbScrubFormat.Text = configIniFile.IniReadString("TRANSFERSYSTEM", "ScrubFormat", "");
                cbScrubFormat.SelectedIndex = configIniFile.IniReadInt("TRANSFERSYSTEM", "ScrubFormatIndex");
                rbTransferSystemWipe.Checked = configIniFile.IniReadBool("TRANSFERSYSTEM", "Wipe");
                rbTransferSystemXCopy.Checked = configIniFile.IniReadBool("TRANSFERSYSTEM", "XCopy");

                // Covers
                chkCoverSynchronizeDelete.Checked = configIniFile.IniReadBool("COVERS", "DeleteCovers");
                chkCoverRecursiveSearch.Checked = configIniFile.IniReadBool("COVERS", "CoverRecursiveSearch");
                chkCoverEnableTransfer.Checked = configIniFile.IniReadBool("COVERS", "TransferCovers");
                rbCoverWiiFlow.Checked = configIniFile.IniReadBool("COVERS", "WiiFlowCoverUSBLoader");
                rbCoverUSBLoaderGX.Checked = configIniFile.IniReadBool("COVERS", "GXCoverUSBLoader");

                if (configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "") == string.Empty)
                {
                    tbDirectoryCoverCache.Text = coverPathDefault;
                }
                else
                {
                    tbDirectoryCoverCache.Text = configIniFile.IniReadString("COVERS", "CoverDirectoryCache", "");
                }

                if (rbCoverWiiFlow.Checked)
                {
                    tbDirectoryCoverDisc.Text = configIniFile.IniReadString("COVERS", "WiiFlowCoverDirectoryDisc", "");
                    tbDirectoryCover2D.Text = configIniFile.IniReadString("COVERS", "WiiFlowCoverDirectory2D", "");
                    tbDirectoryCover3D.Text = configIniFile.IniReadString("COVERS", "WiiFlowCoverDirectory3D", "");
                    tbDirectoryCoverFull.Text = configIniFile.IniReadString("COVERS", "WiiFlowCoverDirectoryFull", "");
                }
                else
                {
                    tbDirectoryCoverDisc.Text = configIniFile.IniReadString("COVERS", "GXCoverDirectoryDisc", "");
                    tbDirectoryCover2D.Text = configIniFile.IniReadString("COVERS", "GXCoverDirectory2D", "");
                    tbDirectoryCover3D.Text = configIniFile.IniReadString("COVERS", "GXCoverDirectory3D", "");
                    tbDirectoryCoverFull.Text = configIniFile.IniReadString("COVERS", "GXCoverDirectoryFull", "");
                }

                // Titles
                chkGameTitle.Checked = configIniFile.IniReadBool("TITLES", "GameTdbTitles");
                rbGameInternalName.Checked = configIniFile.IniReadBool("TITLES", "GameInternalName");
                rbGameXmlName.Checked = configIniFile.IniReadBool("TITLES", "GameXmlName");
                chkGameTitleCustom.Checked = configIniFile.IniReadBool("TITLES", "GameCustomTitles");
                tbTitle.Text = configIniFile.IniReadString("TITLES", "LocationTitles", "");
                tbTitleCustom.Text = configIniFile.IniReadString("TITLES", "LocationCustomTitles", "");
                cbTitleLanguage.SelectedIndex = configIniFile.IniReadInt("TITLES", "TitleLanguage");

                // Downloads
                //chkDownloadTaskComplete.Checked = configIniFile.IniReadBool("DOWNLOADS", "ListTaskComplete");
                //chkDownloadTaskFailure.Checked = configIniFile.IniReadBool("DOWNLOADS", "ListTaskFailure");
                //chkDownloadTaskCanceled.Checked = configIniFile.IniReadBool("DOWNLOADS", "ListTaskCanceled");
                //chkDownloadPreviewCovers.Checked = configIniFile.IniReadBool("DOWNLOADS", "PreviewCovers");

                // Updates
                chkUpdateVerifyStart.Checked = configIniFile.IniReadBool("UPDATES", "UpdateVerifyStart");
                chkUpdateBetaChannel.Checked = configIniFile.IniReadBool("UPDATES", "UpdateBetaChannel");
                chkUpdateFileLog.Checked = configIniFile.IniReadBool("UPDATES", "UpdateFileLog");
                chkUpdateServerProxy.Checked = configIniFile.IniReadBool("UPDATES", "UpdateServerProxy");
                tbServerProxy.Text = configIniFile.IniReadString("UPDATES", "ServerProxy", "");
                tbUserProxy.Text = configIniFile.IniReadString("UPDATES", "UserProxy", "");
                tbPassProxy.Text = configIniFile.IniReadString("UPDATES", "PassProxy", "");
                cbVerificationInterval.SelectedIndex = configIniFile.IniReadInt("UPDATES", "VerificationInterval");

                // Manager Log
                cbLevelLog.SelectedIndex = configIniFile.IniReadInt("MANAGERLOG", "LogLevel");
                chkManagerLogSystemConsole.Checked = configIniFile.IniReadBool("MANAGERLOG", "LogSystemConsole");
                chkManagerLogDebugConsole.Checked = configIniFile.IniReadBool("MANAGERLOG", "LogDebugConsole");
                chkManagerLogWindow.Checked = configIniFile.IniReadBool("MANAGERLOG", "LogWindow");
                chkManagerLogFile.Checked = configIniFile.IniReadBool("MANAGERLOG", "LogFile");

                // Language
                cbLanguage.SelectedIndex = configIniFile.IniReadInt("LANGUAGE", "ConfigLanguage");
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
            this._returnConfirm = 1;
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
            tbDirectoryCover2D.Text = configIniFile.IniReadString("Covers", "WiiFlowCoverDirectory2D", "");
            //tbDirectoryCover3D.Text = configIniFile.IniReadString("Covers", "WiiFlowCoverDirectory3D", "");
            tbDirectoryCoverFull.Text = configIniFile.IniReadString("Covers", "WiiFlowCoverDirectoryFull", "");
        }
        #endregion

        #region rbCoverUSBLoaderGX_CheckedChanged
        private void rbCoverUSBLoaderGX_CheckedChanged(object sender, EventArgs e)
        {
            tbDirectoryCoverDisc.Text = configIniFile.IniReadString("Covers", "GXCoverDirectoryDisc", "");
            tbDirectoryCover2D.Text = configIniFile.IniReadString("Covers", "GXCoverDirectory2D", "");
            tbDirectoryCover3D.Text = configIniFile.IniReadString("Covers", "GXCoverDirectory3D", "");
            tbDirectoryCoverFull.Text = configIniFile.IniReadString("Covers", "GXCoverDirectoryFull", "");
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
            }
            else
            {
                //chkUpdateBetaChannel.Enabled = false;
                chkUpdateServerProxy.Enabled = false;
                //chkUpdateBetaChannel.Checked = false;
                chkUpdateServerProxy.Checked = false;
            }
        }
        #endregion

    }
}
