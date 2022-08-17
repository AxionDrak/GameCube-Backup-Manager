#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using AutoUpdaterDotNET;
using GCBM.Properties;
using GCBM.tools;
using static System.Threading.Tasks.Task;
using sio = System.IO;
using ste = System.Text.Encoding;
using Timer = System.Timers.Timer;

#endregion

namespace GCBM
{
    public partial class frmMain : Form
    {
        #region Assembly Product

        /// <summary>
        ///     Gets the attributes of the Assembly.
        /// </summary>
        private static string AssemblyProduct
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0) return string.Empty;
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        #endregion


        #region Main Form Closing

        /// <summary>
        ///     Main Form Closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notifyIcon != null)
            {
                notifyIcon.Visible = false;
                notifyIcon.Icon = null;
                notifyIcon.Dispose();
            }

            ClearTemp();
            ExportLOG(1);
            if (Process.GetCurrentProcess().GetChildProcesses() != null &&
                Process.GetCurrentProcess().GetChildProcesses().Count != 0)
                foreach (var process in Process.GetCurrentProcess().GetChildProcesses())
                    //Kill GCIT and others
                    process.Kill();
        }

        #endregion

        #region Program Version

        /// <summary>
        ///     Get the program version directly from the Assembly.
        /// </summary>
        /// <returns></returns>
        private string VERSION()
        {
            var PROG_VERSION = assembly.GetName().Version.ToString();
            return PROG_VERSION;
        }

        #endregion

        #region About Translator

        /// <summary>
        ///     About Translator
        /// </summary>
        private void AboutTranslator()
        {
            if (sio.File.Exists("config.ini"))
            {
                if (CONFIG_INI_FILE.IniReadString("GCBM", "ProgVersion", "") != VERSION())
                    CONFIG_INI_FILE.IniWriteString("GCBM", "ProgVersion", VERSION());

                if (CONFIG_INI_FILE.IniReadString("GCBM", "Language", "") != Resources.GCBM_Language)
                    CONFIG_INI_FILE.IniWriteString("GCBM", "Language", Resources.GCBM_Language);

                if (CONFIG_INI_FILE.IniReadString("GCBM", "TranslatedBy", "") != Resources.GCBM_TranslatedBy)
                    CONFIG_INI_FILE.IniWriteString("GCBM", "TranslatedBy", Resources.GCBM_TranslatedBy);
            }
        }

        #endregion

        #region Adjust Language

        /// <summary>
        ///     Set the selected language
        /// </summary>
        private void AdjustLanguage()
        {
            switch (CONFIG_INI_FILE.IniReadInt("LANGUAGE", "ConfigLanguage"))
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    Controls.Clear();
                    InitializeComponent();
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    Controls.Clear();
                    InitializeComponent();
                    break;
                case 2:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
                    Controls.Clear();
                    InitializeComponent();
                    break;
                case 3:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ko");
                    Controls.Clear();
                    InitializeComponent();
                    break;
            }
        }

        #endregion

        #region Detect OS Language

        /// <summary>
        ///     Automatic detection of operating system default language
        /// </summary>
        private void DetectOSLanguage()
        {
            var sysLocale = Thread.CurrentThread.CurrentCulture;
            string[] aryLocales = { "pt-BR", "en-US", "es", "ko" };

            //  See if we have that translation
            var isTranslated = aryLocales.Contains(sysLocale.ToString());

            //  Write the corresponding number to INI
            if (isTranslated)
                CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage",
                    Array.FindIndex(aryLocales, l => l == sysLocale.Name));
            else //Default to english
                CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 1); //en-US
        }

        #endregion

        #region Update Program

        /// <summary>
        ///     Adjust program update system
        /// </summary>
        private void UpdateProgram()
        {
            if (CONFIG_INI_FILE.IniReadBool("UPDATES", "UpdateServerProxy"))
                if (CONFIG_INI_FILE.IniReadString("UPDATES", "ServerProxy", "") != string.Empty &&
                    CONFIG_INI_FILE.IniReadString("UPDATES", "UserProxy", "") != string.Empty &&
                    CONFIG_INI_FILE.IniReadString("UPDATES", "PassProxy", "") != string.Empty)
                {
                    var proxy = new WebProxy(CONFIG_INI_FILE.IniReadString("UPDATES", "ServerProxy", ""), true)
                    {
                        Credentials = new NetworkCredential(CONFIG_INI_FILE.IniReadString("UPDATES", "UserProxy", ""),
                            CONFIG_INI_FILE.IniReadString("UPDATES", "PassProxy", ""))
                    };
                    AutoUpdater.Proxy = proxy;
                }

            // Enable support for updates.
            if (CONFIG_INI_FILE.IniReadBool("UPDATES", "UpdateVerifyStart"))
            {
                var timeInterval = 0;

                if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 0)
                    timeInterval = 10; // 5 minutes
                else if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 1)
                    timeInterval = 20; // 10 minutes
                else if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 2)
                    timeInterval = 30; // 15 minutes
                else if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 3)
                    timeInterval = 60; // 30 minutes
                else if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 4)
                    timeInterval = 120; // 1 hour
                else if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 5)
                    timeInterval = 240; // 2 hours
                else if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 6)
                    timeInterval = 360; // 3 hours
                else
                    timeInterval = 480; // 4 hours

                // Support Beta channel updates.
                if (CONFIG_INI_FILE.IniReadBool("UPDATES", "UpdateBetaChannel"))
                {
                    var timer = new Timer
                    {
                        Interval = 2 * 15000 * timeInterval,
                        SynchronizingObject = this
                    };

                    timer.Elapsed += delegate
                    {
                        AutoUpdater.Start(
                            "https://raw.githubusercontent.com/AxionDrak/GameCube-Backup-Manager/main/BetaChannel/AutoUpdaterBeta.xml");
                        AutoUpdater.ShowRemindLaterButton = false;
                        AutoUpdater.RunUpdateAsAdmin = false;
                        AutoUpdater.ReportErrors = true;
                        //AutoUpdater.UpdateFormSize = new Size(500, 400);
                    };
                    timer.Start();
                }
                else
                {
                    // Support for Release (Default) channel updates.
                    var timer = new Timer
                    {
                        Interval = 2 * 15000 * timeInterval,
                        SynchronizingObject = this
                    };

                    timer.Elapsed += delegate
                    {
                        AutoUpdater.Start(
                            "https://raw.githubusercontent.com/AxionDrak/GameCube-Backup-Manager/main/AutoUpdaterRelease.xml");
                        AutoUpdater.ShowRemindLaterButton = false;
                        AutoUpdater.RunUpdateAsAdmin = false;
                        AutoUpdater.ReportErrors = true;
                        //AutoUpdater.UpdateFormSize = new Size(500, 400);
                    };
                    timer.Start();
                }
            }
        }

        #endregion

        #region Current Year and Date

        // Get the date and time
        private string DateString()
        {
            var dt = DateTime.Now;
            //int dts = dt.Millisecond;
            //string dtnew = dt.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "." + dts.ToString();
            tsslCurrentYear.Text = "Copyright © 2019 - " + dt.Year + " Laete Meireles";
            var dtnew = dt.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
            return dtnew;
        }

        #endregion

        #region Disable Screensaver

        // Disable screen saver
        private void DisabeScreensaver()
        {
            if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "Screensaver"))
                // Disable the screensaver.
                SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
            else
                // Activate the screensaver.
                SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }

        #endregion

        //Rewrite this function (Network Check) and create a connection verification system for
        //every attempt to download or perform any other action over the Internet
        //or local area network.

        #region Network Check

        /// <summary>
        ///     Checks for the existence of a network connection.
        /// </summary>
        private void NetworkCheck()
        {
            if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "NetVerify"))
            {
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    pbNetStatus.Image = Resources.not_conected_16;
                    lblNetStatus.ForeColor = Color.Red;
                    lblNetStatus.Text = Resources.NetworkCheck_NetStatus_Offline;
                    GlobalNotifications(Resources.NetworkCheck_NetStatus_Offline, ToolTipIcon.Info);
                }
                else
                {
                    pbNetStatus.Image = Resources.conected_16;
                    lblNetStatus.ForeColor = Color.Black;
                    lblNetStatus.Text = Resources.NetworkCheck_NetStatus_Online;
                    //GlobalNotifications(Resources.NetworkCheck_NetStatus_Online, ToolTipIcon.Info);
                }

                return;
            }

            pbNetStatus.Image = Resources.not_conected_16;
            lblNetStatus.ForeColor = Color.Red;
            lblNetStatus.Text = Resources.NetworkCheck_NetStatus_Offline;
            GlobalNotifications(Resources.NetworkCheck_NetStatus_Offline, ToolTipIcon.Info);
        }

        #endregion

        #region Register Log

        /// <summary>
        ///     Log record.
        /// </summary>
        private void RegisterHeaderLog()
        {
            // Assembly
            var _version = assembly.GetName();
            // Log
            tbLog.AppendText(
                "[" + DateString() + "]" + Resources.RegisterHeaderLog_GcbmLogCreated + Environment.NewLine);
            // Version number of the OS
            tbLog.AppendText("[" + DateString() + "]" + Resources.RegisterHeaderLog_OSVersion + Environment.OSVersion +
                             Environment.NewLine);
            // Major, minor, build, and revision numbers of the CLR
            tbLog.AppendText("[" + DateString() + "]" + Resources.RegisterHeaderLog_CLRVersion + Environment.Version +
                             Environment.NewLine);
            // Amount of physical memory mapped to the process context
            tbLog.AppendText("[" + DateString() + "]" + Resources.RegisterHeaderLog_WorkingSet +
                             Environment.WorkingSet + Environment.NewLine);
            // Array of string containing the names of the logical drives
            tbLog.AppendText("[" + DateString() + "]" + Resources.RegisterHeaderLog_LogicalUnits +
                             string.Join(", ", Environment.GetLogicalDrives()) + Environment.NewLine);
            // Gets the name of the program.
            tbLog.AppendText("[" + DateString() + "]" + Resources.RegisterHeaderLog_ProgramName + AssemblyProduct +
                             Environment.NewLine);
            // Gets the program version.
            tbLog.AppendText("[" + DateString() + "]" + Resources.RegisterHeaderLog_ApplicationVersion + _version +
                             Environment.NewLine);
            // Gets the current program directory.
            tbLog.AppendText("[" + DateString() + "]" + Resources.RegisterHeaderLog_CurrentProgramDirectory +
                             GET_CURRENT_PATH + Environment.NewLine);
        }

        #endregion

        #region Disable Options

        /// <summary>
        ///     Disables options on the game selection screen
        /// </summary>
        /// <param name="dgv"></param>
        private void DisableOptionsGame(DataGridView dgv)
        {
            if (dgv == dgvSource)
            {
                // Main Menu Game
                btnGameInstallExactCopy.Enabled = false;
                btnGameInstallScrub.Enabled = false;
                tsmiReloadGameList.Enabled = false;
                tsmiSelectGameList.Enabled = false;
                //tsmiGameListSelectAll.Enabled = false;
                //tsmiGameListSelectNone.Enabled = false;
                tsmiGameListDeleteAllFiles.Enabled = false;
                tsmiGameListDeleteSelectedFile.Enabled = false;
                tsmiGameListHashSHA1.Enabled = false;
                tsmiDownloadCoversSelectedGame.Enabled = false;
                tsmiSyncDownloadAllDiscOnly3DCovers.Enabled = false;
                //tsmiLanguage.Enabled = false;
                tsmiDownloadCoversSelectedGame.Enabled = false;
                tsmiSyncDownloadDiscOnly3DCovers.Enabled = false;
                tsmiGameInfo.Enabled = false;
                tsmiTransferDeviceCovers.Enabled = false;
            }
            else
            {
                // Main Menu Game Disc
                //tsmiReloadGameListDisc.Enabled = false;
                tsmiSelectGameDisc.Enabled = false;
                tsmiGameDiscDeleteAllFiles.Enabled = false;
                tsmiGameDiscDeleteSelectedFile.Enabled = false;
                tsmiGameDiscExportList.Enabled = false;
                tsmiGameDiscAllHashSHA1.Enabled = false;
                tsmiGameDiscHashSHA1.Enabled = false;
                tsmiGameDiscAllHashMD5.Enabled = false;
                tsmiGameDiscHashMD5.Enabled = false;
                tsmiGameDiscRecalculateAllMD5.Enabled = false;
                tsmiGameDiscRecalculateSelectedGameMD5.Enabled = false;
            }
        }

        #endregion

        #region Enable Options

        /// <summary>
        ///     Enable options on the games tab.
        /// </summary>
        private void EnableOptionsGameList()
        {
            // Main Menu Game
            btnGameInstallExactCopy.Enabled = true;
            btnGameInstallScrub.Enabled = true;
            tsmiReloadGameList.Enabled = true;
            tsmiSelectGameList.Enabled = true;
            tsmiGameListDeleteAllFiles.Enabled = true;
            tsmiGameListDeleteSelectedFile.Enabled = true;
            tsmiGameListHashSHA1.Enabled = true;
            tsmiSyncDownloadAllDiscOnly3DCovers.Enabled = true;
            tsmiSyncDownloadAllCovers.Enabled = true;
            //tsmiLanguage.Enabled = true;
            tsmiDownloadCoversSelectedGame.Enabled = true;
            tsmiSyncDownloadDiscOnly3DCovers.Enabled = true;
            tsmiGameInfo.Enabled = true;
            tsmiTransferDeviceCovers.Enabled = true;
            dgvSource.Enabled = true;
        }

        #endregion

        #region Reset Options

        /// <summary>
        ///     Reset options game list.
        /// </summary>
        private void ResetOptions()
        {
            // Main Menu Game
            tbIDName.Clear();
            tbIDRegion.Clear();
            tbIDGame.Clear();
            tbIDDiscID.Clear();
            tbIDMakerCode.Clear();
            pbGameDisc.LoadAsync(GET_CURRENT_PATH + MEDIA_DIR + sio.Path.DirectorySeparatorChar + "disc.png");
            pbGameCover3D.LoadAsync(GET_CURRENT_PATH + MEDIA_DIR + sio.Path.DirectorySeparatorChar + "3d.png");
            pbWebGameID.Enabled = false;
            pbWebGameID.Image = Resources.globe_earth_grayscale_64;
            dgvSource.DataSource = null;
            dgvSource.Columns.Clear();
            dgvSource.Rows.Clear();
            dgvSource.Refresh();
            PopDestination();
            PopSource();
        }

        #endregion

        #region Process Task Delay

        /// <summary>
        ///     Process Task Delay
        /// </summary>
        /// <returns></returns>
        private async Task ProcessTaskDelay()
        {
            await Delay(5000).ConfigureAwait(false);
        }

        #endregion

        #region List ISO/GCM Files

        /// <summary>
        ///     List existing ISO and GCM files in the directory and subdirectories.
        /// </summary>
        private void ListIsoFile()
        {
            tbLog.AppendText("[" + DateString() + "]" + Resources.FoundIsoGcmFiles + Environment.NewLine);

            foreach (DataGridViewRow dgvResultRow in dgvSource.Rows)
                tbLog.AppendText("[" + DateString() + "]" + Resources.Info +
                                 dgvSource.Rows[dgvResultRow.Index].Cells[1].Value + Environment.NewLine);
        }

        #endregion

        #region Load Database XML

        /// <summary>
        ///     Load Database XML
        /// </summary>
        private void LoadDatabaseXML()
        {
            if (!Monitor.TryEnter(lvDatabase))
            {
                return;
            }

            if (sio.File.Exists(WIITDB_FILE))
                if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "LoadDatabase"))
                    // PERFECT - DO NOT CHANGE!!!
                    try
                    {
                        lvDatabase.View = View.Details;
                        lvDatabase.GridLines = true;
                        lvDatabase.FullRowSelect = true;
                        lvDatabase.Columns.Add(Resources.LoadDatabase_IDGameCode, 70);
                        lvDatabase.Columns.Add(Resources.LoadDatabase_GameTitle, 210);
                        lvDatabase.Columns.Add(Resources.LoadDatabase_Region, 70);
                        lvDatabase.Columns.Add(Resources.LoadDatabase_Type, 80);
                        lvDatabase.Columns.Add(Resources.LoadDatabase_Developer, 200);
                        lvDatabase.Columns.Add(Resources.LoadDatabase_Editor, 200);

                        using (var ds = new DataSet())
                        {
                            ListViewItem itemXml;
                            ds.ReadXml(WIITDB_FILE);

                            foreach (DataRow dr in ds.Tables["game"].Rows)
                            {
                                itemXml = new ListViewItem(new[]
                                {
                                    dr["id"].ToString(),
                                    dr["name"].ToString(),
                                    dr["region"].ToString(),
                                    dr["type"].ToString(),
                                    dr["developer"].ToString(),
                                    dr["publisher"].ToString()
                                });

                                lvDatabase.Items.Add(itemXml);
                            }

                            foreach (DataRow dr in ds.Tables["WiiTDB"].Rows)
                                lblDatabaseTotal.Text = dr["games"] + " Total";

                            ds.Dispose();
                            ds.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        //CheckWiiTdbXml();
                        GlobalNotifications(ex.Message, ToolTipIcon.Error);
                    }

            Monitor.Exit(lvDatabase);
        }

        #endregion

        #region Load Config File

        /// <summary>
        ///     Reads and loads the contents of the INI file.
        /// </summary>
        private void LoadConfigFile()
        {
            if (sio.File.Exists(GET_CURRENT_PATH + sio.Path.DirectorySeparatorChar + INI_FILE))
                if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "WindowMaximized"))
                    WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region Default Config Save

        /// <summary>
        ///     Default Config Save
        /// </summary>
        private void DefaultConfigSave()
        {
            // GCBM
            CONFIG_INI_FILE.IniWriteString("GCBM", "ProgUpdated", PROG_UPDATE);
            CONFIG_INI_FILE.IniWriteString("GCBM", "ProgVersion", VERSION());
            CONFIG_INI_FILE.IniWriteString("GCBM", "ConfigUpdated", DateTime.Now.ToString("dd/MM/yyyy"));
            CONFIG_INI_FILE.IniWriteString("GCBM", "Language", Resources.GCBM_Language);
            CONFIG_INI_FILE.IniWriteString("GCBM", "TranslatedBy", Resources.GCBM_TranslatedBy);
            // General
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "DiscClean", true);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "DiscDelete", false);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractZip", false);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "Extract7z", false);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractRar", false);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractBZip2", false);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractSplitFile", false);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractNwb", false);
            CONFIG_INI_FILE.IniWriteInt("GENERAL", "FileSize", 0);
            CONFIG_INI_FILE.IniWriteString("GENERAL", "TemporaryFolder", GET_CURRENT_PATH + TEMP_DIR);
            // Several
            CONFIG_INI_FILE.IniWriteInt("SEVERAL", "AppointmentStyle", 0);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "CheckMD5", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "CheckSHA1", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "CheckNotify", true);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "NetVerify", true);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "RecursiveMode", true);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "TemporaryBuffer", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "WindowMaximized", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "DisableSplash", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "Screensaver", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "LoadDatabase", true);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "MultipleInstances", false);
            // TransferSystem
            CONFIG_INI_FILE.IniWriteBool("TRANSFERSYSTEM", "FST", false);
            CONFIG_INI_FILE.IniWriteBool("TRANSFERSYSTEM", "ScrubFlushSD", false);
            CONFIG_INI_FILE.IniWriteInt("TRANSFERSYSTEM", "ScrubAlign", 0);
            CONFIG_INI_FILE.IniWriteString("TRANSFERSYSTEM", "ScrubFormat", "DiscEx");
            CONFIG_INI_FILE.IniWriteInt("TRANSFERSYSTEM", "ScrubFormatIndex", 1);
            CONFIG_INI_FILE.IniWriteBool("TRANSFERSYSTEM", "Wipe", false);
            CONFIG_INI_FILE.IniWriteBool("TRANSFERSYSTEM", "XCopy", true);
            // Covers
            CONFIG_INI_FILE.IniWriteBool("COVERS", "DeleteCovers", false);
            CONFIG_INI_FILE.IniWriteBool("COVERS", "CoverRecursiveSearch", false);
            CONFIG_INI_FILE.IniWriteBool("COVERS", "TransferCovers", false);
            CONFIG_INI_FILE.IniWriteBool("COVERS", "WiiFlowCoverUSBLoader", false);
            CONFIG_INI_FILE.IniWriteBool("COVERS", "GXCoverUSBLoader", true);
            CONFIG_INI_FILE.IniWriteString("COVERS", "CoverDirectoryCache", GET_CURRENT_PATH + COVERS_DIR);
            CONFIG_INI_FILE.IniWriteString("COVERS", "WiiFlowCoverDirectoryDisc", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "WiiFlowCoverDirectory2D", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "WiiFlowCoverDirectory3D", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "WiiFlowCoverDirectoryFull", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "GXCoverDirectoryDisc", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "GXCoverDirectory2D", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "GXCoverDirectory3D", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "GXCoverDirectoryFull", "");
            // Titles
            CONFIG_INI_FILE.IniWriteBool("TITLES", "GameCustomTitles", false);
            CONFIG_INI_FILE.IniWriteBool("TITLES", "GameTdbTitles", false);
            CONFIG_INI_FILE.IniWriteBool("TITLES", "GameInternalName", true);
            CONFIG_INI_FILE.IniWriteBool("TITLES", "GameXmlName", false);
            CONFIG_INI_FILE.IniWriteString("TITLES", "LocationTitles", "%APP%" + Path.DirectorySeparatorChar + "titles.txt");
            CONFIG_INI_FILE.IniWriteString("TITLES", "LocationCustomTitles", "%APP%" + Path.DirectorySeparatorChar + "custom-titles.txt");
            CONFIG_INI_FILE.IniWriteInt("TITLES", "TitleLanguage", 0);
            // Dolphin Emulator
            CONFIG_INI_FILE.IniWriteString("DOLPHIN", "DolphinFolder", "");
            CONFIG_INI_FILE.IniWriteBool("DOLPHIN", "DolphinDX11", true);
            CONFIG_INI_FILE.IniWriteBool("DOLPHIN", "DolphinDX12", false);
            CONFIG_INI_FILE.IniWriteBool("DOLPHIN", "DolphinVKGL", false);
            CONFIG_INI_FILE.IniWriteBool("DOLPHIN", "DolphinLLE", false);
            CONFIG_INI_FILE.IniWriteBool("DOLPHIN", "DolphinHLE", true);
            // Updates
            CONFIG_INI_FILE.IniWriteBool("UPDATES", "UpdateVerifyStart", false);
            CONFIG_INI_FILE.IniWriteBool("UPDATES", "UpdateBetaChannel", false);
            CONFIG_INI_FILE.IniWriteBool("UPDATES", "UpdateFileLog", false);
            CONFIG_INI_FILE.IniWriteBool("UPDATES", "UpdateServerProxy", false);
            CONFIG_INI_FILE.IniWriteString("UPDATES", "ServerProxy", "");
            CONFIG_INI_FILE.IniWriteString("UPDATES", "UserProxy", "");
            CONFIG_INI_FILE.IniWriteString("UPDATES", "PassProxy", "");
            CONFIG_INI_FILE.IniWriteInt("UPDATES", "VerificationInterval", 0);
            // Manager Log
            CONFIG_INI_FILE.IniWriteInt("MANAGERLOG", "LogLevel", 0);
            CONFIG_INI_FILE.IniWriteBool("MANAGERLOG", "LogSystemConsole", false);
            CONFIG_INI_FILE.IniWriteBool("MANAGERLOG", "LogDebugConsole", false);
            CONFIG_INI_FILE.IniWriteBool("MANAGERLOG", "LogWindow", false);
            CONFIG_INI_FILE.IniWriteBool("MANAGERLOG", "LogFile", true);
            // Language
            CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 1);
        }

        #endregion

        // REWRITE FUNCTION - Reload DataGridView List
        // REFACTORED INTO ONE METHOD LINE 1090

        #region Reload DataGridView List

        /// <summary>
        ///     Reloads the contents of the DataGridView Games List.
        /// </summary>
        private void ReloadDataGridViewGameList(DataGridView dgv)
        {
            if (dgv.RowCount != 0)
                try
                {
                    if (dgv.CurrentRow != null)
                    {
                        VerifyGame(dgv.CurrentRow.Cells["Path"].Value.ToString());

                        if (ERROR == false) LoadCover(tbIDGame.Text);
                        // pictureBox GameID
                        if (pbWebGameID.Enabled == false)
                        {
                            pbWebGameID.Enabled = true;
                            pbWebGameID.Image = Resources.globe_earth_color_64;
                        }

                        if (dgv == dgvDestination)
                        {
                            //title,region,id
                            lblDestinationCount.Text = dgv.Rows.Count.ToString();
                            tbIDNameDisc.Text = dgv.CurrentRow.Cells["Title"].Value.ToString();
                            tbIDRegionDisc.Text = dgv.CurrentRow.Cells["Region"].Value.ToString();
                            tbIDGameDisc.Text = dgv.CurrentRow.Cells["ID"].Value.ToString();
                        }

                        if (dgv == dgvSource)
                        {
                            lblSourceCount.Text = dgv.Rows.Count.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    tbLog.AppendText("[" + DateString() + "]" + Resources.Info + ex.Message);
                    tbLog.AppendText(ex.Message + Environment.NewLine + ex.StackTrace);
                    GlobalNotifications(ex.Message, ToolTipIcon.Error);
                }
        }

        #endregion

        #region Display Files Selected

        /// <summary>
        ///     Display Files Selected
        ///     --sjohnson1021-bookmark
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="dgv"></param>
        private async void DisplayFilesSelected(string sourceFolder, DataGridView dgv)
        {
            ABORT = false;
            var filters = new[] { "iso", "gcm" };
            bool isRecursive;

            if (dgv == dgvSource)
                if (dgv.RowCount == 0)
                {
                    btnGameInstallExactCopy.Enabled = true;
                    btnGameInstallScrub.Enabled = true;
                    tsmiReloadGameList.Enabled = true;
                    tsmiGameListSelectAll.Enabled = true;
                    tsmiGameListSelectNone.Enabled = true;
                    tsmiGameListDeleteAllFiles.Enabled = true;
                    tsmiGameListDeleteSelectedFile.Enabled = true;
                    //tsmiGameListAllHashSHA1.Enabled = true;
                    tsmiGameListHashSHA1.Enabled = true;
                    tsmiDownloadCoversSelectedGame.Enabled = true;
                    tsmiSyncDownloadDiscOnly3DCovers.Enabled = true;
                    tsmiGameInfo.Enabled = true;
                    tsmiTransferDeviceCovers.Enabled = true;
                }

            if (dgv == dgvDestination)
                isRecursive = true;
            else
                isRecursive = false;

            var files = await GetFilesFolder(sourceFolder, filters, isRecursive).ConfigureAwait(false);

            if (dgv == dgvDestination)
                //tsmiReloadGameListDisc.Enabled = true;
                try
                {
                    if (dgv.RowCount == 0) tsmiReloadGameListDisc.Enabled = true;
                }
                catch (Exception ex)
                {
                    tbLog.AppendText(ex.Message + Environment.NewLine + ex.StackTrace);
                }

            tsmiSelectGameList.Enabled = true;
            // Groups files in the folder by extension.
            var filesGroupedByExtension = files
                .Select(arq => sio.Path.GetExtension(arq).TrimStart('.').ToLower(MY_CULTURE)).GroupBy(x => x,
                    (ext, extCnt) =>
                        new { _fileExtension = ext, Counter = extCnt.Count() });

            // Scroll through the result and display the values.
            foreach (var _files in filesGroupedByExtension)
            {
                tbLog.AppendText("[" + DateString() + "]" + Resources.DisplayFilesSelected_Found_String1 +
                                 _files.Counter +
                                 Resources.DisplayFilesSelected_Found_String2
                                 + _files._fileExtension.ToUpper(MY_CULTURE) + Environment.NewLine);

                GlobalNotifications(Resources.DisplayFilesSelected_Found_String3 + _files.Counter +
                                    Resources.DisplayFilesSelected_Found_String2 +
                                    _files._fileExtension.ToUpper(MY_CULTURE), ToolTipIcon.Info);
            }
            //txtLog.AppendText(Environment.NewLine + Environment.NewLine);

            // Creates a DataTable with file data.
            //DataTable _table = new DataTable();

            sio.FileInfo _file = null;
            dgv.Rows.Clear();
            //dgvSource.DataSource = GameDataTable();

            foreach (var game in GameList(sourceFolder).Result)
            {
                if (dgvSelected == dgvSource) lstSourceGames.Add(game);
                _file = new sio.FileInfo(game.Path);

                var _getSize = DisplayFormatFileSize(_file.Length, CONFIG_INI_FILE.IniReadInt("GENERAL", "FileSize"));

                // 5th column
                dgv.Rows.Add(false,
                    game.Title,
                    game.ID,
                    game.Region,
                    game.Extension.Substring(1, 3).Trim().ToUpper(MY_CULTURE),
                    _getSize,
                    game.Path);
            }


            //for (int i = 0; i < files.Length; i++)
            //{
            //    //FileInfo _file = new FileInfo(files[i]);
            //    _file = new FileInfo(files[i]);
            //    string _getSize = DisplayFormatFileSize(_file.Length, CONFIG_INI_FILE.IniReadInt("GENERAL", "FileSize"));
            //    //string _getSize = BytesToGB(_file.Length);                
            //    // 4° coluna
            //    _table.Rows.Add(_file.Name, _file.Extension.Substring(1, 3).Trim().ToUpper(MY_CULTURE), _getSize, _file.FullName);
            //    //_table.Rows.Add(_file.Name, _file.Extension.Substring(1, 3).Trim().ToUpper(myCulture), _getSize);
            //}

            //if(dgvSource.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect){
            //    MessageBox.Show("O modo de seleção é RowHeaderSelect");
            //}
            //else
            //{
            //    MessageBox.Show("O modo de seleção NÃO é RowHeaderSelect");
            //}

            EnableOptionsGameList();

            ReloadDataGridViewGameList(dgv);
        }

        #endregion

        #region Get Files Folder

        /// <summary>
        ///     Get files from folder origem.
        /// </summary>
        /// <param name="rootFolder"></param>
        /// <param name="filters"></param>
        /// <param name="isRecursive"></param>
        /// <returns></returns>
        private async Task<string[]> GetFilesFolder(string rootFolder, string[] filters, bool isRecursive)
        {
            var filesFound = new List<string>();
            // Sets options for displaying root folder images.

            if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "RecursiveMode"))
                isRecursive = true;
            else
                isRecursive = false;

            var optionSearch = isRecursive ? sio.SearchOption.AllDirectories : sio.SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
                try
                {
                    filesFound.AddRange(
                        sio.Directory.GetFiles(rootFolder, string.Format("*.{0}", filter), optionSearch));
                }
                catch (Exception ex)
                {
                    // Not used.
                    // Just to avoid mistakes.
                    tbLog.AppendText(ex.Message + Environment.NewLine + ex.StackTrace);
                }

            return filesFound.ToArray();
        }

        #endregion

        #region Get All Drives

        /// <summary>
        ///     Gets a list of all connected drives.
        /// </summary>
        private void GetAllDrives()
        {
            var allDrives = sio.DriveInfo.GetDrives();

            tscbDiscDrive.Items.Clear();
            tscbDiscDrive.Items.Add(Resources.GetAllDrives_Inactive);
            tscbDiscDrive.SelectedIndex = 0;

            foreach (var d in allDrives)
                if (d.IsReady)
                    tscbDiscDrive.Items.Add(d.Name);
        }

        #endregion

        #region Display Format File Size

        /// <summary>
        ///     Adjusts the file size display format.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string DisplayFormatFileSize(long i, int k)
        {
            // Gets the absolute value.
            var i_absolute = i < 0 ? -i : i;
            string suffix;
            double reading;

            if (k == 0)
            {
                if (i_absolute >= 0x1000000000000000) // Exabyte
                {
                    suffix = "EB";
                    reading = i >> 50;
                }
                else if (i_absolute >= 0x4000000000000) // Petabyte
                {
                    suffix = "PB";
                    reading = i >> 40;
                }
                else if (i_absolute >= 0x10000000000) // Terabyte
                {
                    suffix = "TB";
                    reading = i >> 30;
                }
                else if (i_absolute >= 0x40000000) // Gigabyte
                {
                    suffix = "GB";
                    reading = i >> 20;
                }
                else if (i_absolute >= 0x100000) // Megabyte
                {
                    suffix = "MB";
                    reading = i >> 10;
                }
                else if (i_absolute >= 0x400) // Kilobyte
                {
                    suffix = "KB";
                    reading = i;
                }
                else
                {
                    return i.ToString("0 bytes"); // Byte
                }
            }
            else if (k == 1) // Kilobyte
            {
                suffix = "KB";
                reading = i;
            }
            else if (k == 2) // Megabyte
            {
                suffix = "MB";
                reading = i >> 10;
            }
            else if (k == 3) // Gigabyte
            {
                suffix = "GB";
                reading = i >> 20;
            }
            else if (k == 4) // Terabyte
            {
                suffix = "TB";
                reading = i >> 30;
            }
            else
            {
                return i.ToString("0 bytes"); // Byte
            }

            // Divide by 1024 to get the fractional value.
            reading = reading / 1024;
            // Returns the suffix formatted number.
            return reading.ToString("0.## ") + suffix;
        }

        #endregion

        #region Display Format File Size (Basic Version - Automatic)

        /// <summary>
        ///     Display Format File Size (Basic Version - Automatic)
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToGB(long bytes)
        {
            string result;
            double _bytes = bytes;
            var array_fs = new string[5] { "B", "KB", "MB", "GB", "TB" };
            var num2_fs = 0;

            while (_bytes >= 1024.0 && num2_fs < array_fs.Length - 1)
            {
                num2_fs++;
                _bytes /= 1024.0;
            }

            result = $"{_bytes:0.##} {array_fs[num2_fs]}";

            return result;
        }

        #endregion

        #region Build Game list as List<Game>

        /// <summary>
        ///     Build a List<Game> with file and game info for easier access programmatically.
        /// </summary>
        private async Task<List<Game>> GameList(string path)
        {
            string[] filters = { "ISO", "GCM" };
            var list = new List<Game>();
            var files = await GetFilesFolder(path, filters, false).ConfigureAwait(false);

            foreach (var file in files)
            {
                var _file = new sio.FileInfo(file);
                //Title - ID - Region - Path - Extension - Size
                loadPath = _file.FullName;
                VerifyGame(loadPath);
                var game = new Game(tbIDName.Text, tbIDGame.Text, tbIDRegion.Text, loadPath, _file.Extension,
                    (int)_file.Length);
                //game.Title = tbIDName.Text;
                IMAGE_PATH = game.Path;
                if (CheckImage() && ReadImageDiscTOC()) list.Add(game);
            }

            return list;
        }

        #endregion

        #region Build Game list as DataTable

        /// <summary>
        ///     Build a list with file and game info for easier access programmatically.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataTable GameDataTable(string path)
        {
            var _table = new DataTable();
            _table.Columns.Add("Title");
            _table.Columns.Add("Region");
            _table.Columns.Add("ID");
            _table.Columns.Add("Type");
            _table.Columns.Add("Size");
            _table.Columns.Add("Path");
            foreach (var game in GameList(path).Result)
                _table.Rows.Add(game.Title,
                    game.Region,
                    game.ID,
                    game.Extension.Substring(1, 3).Trim().ToUpper(MY_CULTURE),
                    DisplayFormatFileSize(game.Size, CONFIG_INI_FILE.IniReadInt("GENERAL", "FileSize")),
                    game.Path);
            return _table;
        }

        #endregion

        #region Check Image

        /// <summary>
        ///     Checks if it is a valid Nintendo GameCube file.
        /// </summary>
        /// <returns></returns>
        private bool CheckImage()
        {
            sio.FileStream fs = null;
            sio.BinaryReader br = null;

            try
            {
                fs = new sio.FileStream(IMAGE_PATH, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
                br = new sio.BinaryReader(fs, ste.Default);

                fs.Position = 0x1c;
                if (br.ReadInt32() != 0x3d9f33c2)
                {
                    tbLog.AppendText("[" + DateString() + "]" + Resources.NotNintendoGameCubeFile);
                    GlobalNotifications(Resources.NotNintendoGameCubeFile + Environment.NewLine +
                                        Resources.RecommendedDeleteOrMoveFile, ToolTipIcon.Info);

                    pbGameDisc.LoadAsync(GET_CURRENT_PATH + MEDIA_DIR + sio.Path.DirectorySeparatorChar + "disc.png");
                    pbGameCover3D.LoadAsync(GET_CURRENT_PATH + MEDIA_DIR + sio.Path.DirectorySeparatorChar + "3d.png");

                    ERROR = true;
                    // INVALID FILE!!!
                }
                else
                {
                    ERROR = false;
                    // VALID FILE!!!
                }
            }
            catch (Exception ex)
            {
                GlobalNotifications(ex.Message, ToolTipIcon.Error);
                ERROR = true;
            }
            finally
            {
                if (br != null) br.Close();
                if (fs != null) fs.Close();
            }

            return !ERROR;
        }

        #endregion

        private bool CheckImage(string path)
        {
            sio.FileStream fs = null;
            sio.BinaryReader br = null;

            try
            {
                fs = new sio.FileStream(path, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
                br = new sio.BinaryReader(fs, ste.Default);

                fs.Position = 0x1c;
                if (br.ReadInt32() != 0x3d9f33c2)
                {
                    tbLog.AppendText("[" + DateString() + "]" + Resources.NotNintendoGameCubeFile);
                    GlobalNotifications(Resources.NotNintendoGameCubeFile + Environment.NewLine +
                                        Resources.RecommendedDeleteOrMoveFile, ToolTipIcon.Info);

                    pbGameDisc.LoadAsync(GET_CURRENT_PATH + MEDIA_DIR + sio.Path.DirectorySeparatorChar + "disc.png");
                    pbGameCover3D.LoadAsync(GET_CURRENT_PATH + MEDIA_DIR + sio.Path.DirectorySeparatorChar + "3d.png");

                    ERROR = true;
                    // INVALID FILE!!!
                }
                else
                {
                    ERROR = false;
                    // VALID FILE!!!
                }
            }
            catch (Exception ex)
            {
                GlobalNotifications(ex.Message, ToolTipIcon.Error);
                ERROR = true;
            }
            finally
            {
                if (br != null) br.Close();
                if (fs != null) fs.Close();
            }

            return !ERROR;
        }

        #region Get Game Info

        private Game getGameInfo(string path)
        {
            VerifyGame(path);
            var f = new sio.FileInfo(path);
            var game = new Game(
                tbIDName.Text, //if not INI
                tbIDGame.Text,
                _IDRegionName,
                f.FullName,
                f.Extension,
                Convert.ToInt32(f.Length));
            //lastGameLookedUp = game;
            return game;
        }

        #endregion

        #region Load Cover

        /// <summary>
        ///     Loads the respective Disk and 2D image files into the loaded ISO/GCM file.
        /// </summary>
        //private void LoadCover()
        private void LoadCover(string _idGame)
        {
            try
            {
                switch (_IDRegionCode)
                {
                    case "e": // AMERICA - USA
                        LINK_DOMAIN = "US";
                        break;
                    case "p": // EUROPE - ALL
                    case "r": // EUROPE - RUSSIA                   
                        LINK_DOMAIN = "EN";
                        break;
                    case "j": // ASIA - JAPAN
                    case "t": // ASIA - TAIWAN
                    case "k": // ASIA - KOREA
                        LINK_DOMAIN = "JA";
                        break;
                    case "d": // EUROPE - GERMANY
                        LINK_DOMAIN = "DE";
                        break;
                    case "s": // EUROPE - SPAIN
                        LINK_DOMAIN = "ES";
                        break;
                    case "i": // EUROPE - ITALY
                        LINK_DOMAIN = "IT";
                        break;
                    case "u": // AUSTRALIA
                        LINK_DOMAIN = "AU";
                        break;
                    case "y": // EUROPE - Netherlands ???
                        LINK_DOMAIN = "NL";
                        break;
                    case "f": // EUROPE - FRANCE
                        LINK_DOMAIN = "FR";
                        break;
                    default:
                        LINK_DOMAIN = "US";
                        //GlobalNotifications(GCBM.Properties.Resources.UnknownRegion, ToolTipIcon.Info);
                        break;
                }
            }
            catch (Exception ex)
            {
                tbLog.AppendText(ex.Message + Environment.NewLine + ex.StackTrace);
            }

            if (sio.File.Exists(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar + _idGame + ".png"))
                pbGameDisc.LoadAsync(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar + _idGame + ".png");
            else
                pbGameDisc.LoadAsync(GET_CURRENT_PATH + MEDIA_DIR + sio.Path.DirectorySeparatorChar + "disc.png");

            if (sio.File.Exists(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar + _idGame + ".png"))
                pbGameCover3D.LoadAsync(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar + _idGame +
                                        ".png");
            else
                pbGameCover3D.LoadAsync(GET_CURRENT_PATH + MEDIA_DIR + sio.Path.DirectorySeparatorChar + "3d.png");
        }

        #endregion

        // REWRITE FUNCTION - Download Only Disc & 3D Cover

        #region Download Only Disc & 3D Cover

        /// <summary>
        ///     Only downloads Disc and 3D files from listed ISO/GCM files.
        /// </summary>
        private void DownloadOnlyDisc3DCover(DataGridView dgv)
        {
            foreach (DataGridViewRow dgvResultRow in dgv.Rows)
            {
                var _IDGameCode = dgv.Rows[dgvResultRow.Index].Cells[6].Value.ToString();
                VerifyGame(_IDGameCode);

                //tbLog.AppendText(_IDRegionCode + Environment.NewLine);

                switch (_IDRegionCode)
                {
                    case "e": // AMERICA - USA
                        LINK_DOMAIN = "US";
                        break;
                    case "p": // EUROPE - ALL
                    case "r": // EUROPE - RUSSIA                   
                        LINK_DOMAIN = "EN";
                        break;
                    case "j": // ASIA - JAPAN
                    case "t": // ASIA - TAIWAN
                    case "k": // ASIA - KOREA
                        LINK_DOMAIN = "JA";
                        break;
                    case "d": // EUROPE - GERMANY
                        LINK_DOMAIN = "DE";
                        break;
                    case "s": // EUROPE - SPAIN
                        LINK_DOMAIN = "ES";
                        break;
                    case "i": // EUROPE - ITALY
                        LINK_DOMAIN = "IT";
                        break;
                    case "u": // AUSTRALIA
                        LINK_DOMAIN = "AU";
                        break;
                    case "y": // EUROPE - Netherlands ???
                        LINK_DOMAIN = "NL";
                        break;
                    case "f": // EUROPE - FRANCE
                        LINK_DOMAIN = "FR";
                        break;
                    default:
                        LINK_DOMAIN = "US";
                        //GlobalNotifications(GCBM.Properties.Resources.UnknownRegion, ToolTipIcon.Info);
                        break;
                }

                try
                {
                    // Download Disc cover
                    var myLinkCoverDisc = new Uri(@"https://art.gametdb.com/wii/disc/" + LINK_DOMAIN + "/" +
                                                  _IDMakerCode + ".png");
                    var request = (HttpWebRequest)WebRequest.Create(myLinkCoverDisc);
                    request.Method = "HEAD";
                    NET_RESPONSE = (HttpWebResponse)request.GetResponse();

                    if (NET_RESPONSE.StatusCode == HttpStatusCode.OK)
                    {
                        tbLog.AppendText("[" + DateString() + "]" + Resources.DownloadDiscCover + _IDMakerCode +
                                         ".png" + Environment.NewLine);
                        NET_CLIENT.DownloadFileAsync(myLinkCoverDisc,
                            GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar + _IDMakerCode + ".png");
                        while (NET_CLIENT.IsBusy) Application.DoEvents();
                    }
                }
                catch (WebException ex)
                {
                    tbLog.AppendText("[" + DateString() + "]" + Resources.DownloadDiscCoverError + Environment.NewLine +
                                     Resources.Error + ex.Message + Environment.NewLine);
                    tbLog.AppendText(ex.StackTrace);
                }
                finally
                {
                    if (NET_RESPONSE != null) NET_RESPONSE.Close();
                }

                //try
                //{
                //    // Download Disc cover
                //    Uri myLinkCoverDisc = new Uri(@"https://art.gametdb.com/wii/disc/" + LINK_DOMAIN + "/" + _IDMakerCode + ".png");
                //    var request = (HttpWebRequest)WebRequest.Create(myLinkCoverDisc);
                //    request.Method = "HEAD";
                //    NET_RESPONSE = (HttpWebResponse)request.GetResponse();

                //    if (NET_RESPONSE.StatusCode == HttpStatusCode.OK)
                //    {
                //        tbLog.AppendText("[" + DateString() + "]" + GCBM.Properties.Resources.DownloadDiscCover + _IDMakerCode + ".png" + Environment.NewLine);
                //        NET_CLIENT.DownloadFileAsync(myLinkCoverDisc, GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar + _IDMakerCode + ".png");
                //        while (NET_CLIENT.IsBusy) { Application.DoEvents(); }
                //    }
                //}
                //catch (WebException ex)
                //{
                //    tbLog.AppendText("[" + DateString() + "]" + GCBM.Properties.Resources.DownloadDiscCoverError + Environment.NewLine +
                //        GCBM.Properties.Resources.Error + ex.Message + Environment.NewLine);
                //    tbLob.AppendText(ex.StackTrace);
                //}
                //finally
                //{
                //    if (NET_RESPONSE != null)
                //    {
                //        NET_RESPONSE.Close();
                //    }
                //}

                try
                {
                    // Download 3D cover
                    var myLinkCover3D = new Uri(@"https://art.gametdb.com/wii/cover3D/" + LINK_DOMAIN + "/" +
                                                _IDMakerCode + ".png");
                    var request3D = (HttpWebRequest)WebRequest.Create(myLinkCover3D);
                    request3D.Method = "HEAD";
                    NET_RESPONSE = (HttpWebResponse)request3D.GetResponse();

                    if (NET_RESPONSE.StatusCode == HttpStatusCode.OK)
                    {
                        tbLog.AppendText("[" + DateString() + "]" + Resources.Download3DCover + _IDMakerCode + ".png" +
                                         Environment.NewLine);
                        NET_CLIENT.DownloadFileAsync(myLinkCover3D,
                            GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar+ "3d" + sio.Path.DirectorySeparatorChar + _IDMakerCode + ".png");
                        while (NET_CLIENT.IsBusy) Application.DoEvents();
                    }
                }
                catch (WebException ex)
                {
                    tbLog.AppendText("[" + DateString() + "]" + Resources.Download3DCoverError + Environment.NewLine +
                                     Resources.Error + ex.Message + Environment.NewLine);
                    tbLog.AppendText(ex.StackTrace);
                }
                finally
                {
                    if (NET_RESPONSE != null) NET_RESPONSE.Close();
                }
            }
        }

        #endregion

        // REWRITE FUNCTION - Download Only Disc & 3D Cover Selected Game

        #region Download Only Disc & 3D Cover Selected Game

        /// <summary>
        ///     Downloads Disc and 3D files from the selected ISO/GCM file only.
        /// </summary>
        private void DownloadOnlyDisc3DCoverSelectedGame(DataGridView dgv)
        {
            var _selectedGameRowCount = dgv.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (_selectedGameRowCount == 0)
            {
                SelectGameFromList();
            }
            else
            {
                switch (_IDRegionCode)
                {
                    case "e": // AMERICA - USA
                        LINK_DOMAIN = "US";
                        break;
                    case "p": // EUROPE - ALL
                    case "r": // EUROPE - RUSSIA                   
                        LINK_DOMAIN = "EN";
                        break;
                    case "j": // ASIA - JAPAN
                    case "t": // ASIA - TAIWAN
                    case "k": // ASIA - KOREA
                        LINK_DOMAIN = "JA";
                        break;
                    case "d": // EUROPE - GERMANY
                        LINK_DOMAIN = "DE";
                        break;
                    case "s": // EUROPE - SPAIN
                        LINK_DOMAIN = "ES";
                        break;
                    case "i": // EUROPE - ITALY
                        LINK_DOMAIN = "IT";
                        break;
                    case "u": // AUSTRALIA
                        LINK_DOMAIN = "AU";
                        break;
                    case "y": // EUROPE - Netherlands ???
                        LINK_DOMAIN = "NL";
                        break;
                    case "f": // EUROPE - FRANCE
                        LINK_DOMAIN = "FR";
                        break;
                    default:
                        LINK_DOMAIN = "US";
                        //GlobalNotifications(GCBM.Properties.Resources.UnknownRegion, ToolTipIcon.Info);
                        break;
                }

                try
                {
                    // Download Disc cover
                    var myLinkCoverDisc = new Uri(@"https://art.gametdb.com/wii/disc/" + LINK_DOMAIN + "/" +
                                                  _IDMakerCode + ".png");
                    var request = (HttpWebRequest)WebRequest.Create(myLinkCoverDisc);
                    request.Method = "HEAD";
                    NET_RESPONSE = (HttpWebResponse)request.GetResponse();

                    if (NET_RESPONSE.StatusCode == HttpStatusCode.OK)
                    {
                        tbLog.AppendText("[" + DateString() + "]" + Resources.DownloadDiscCover + _IDMakerCode +
                                         ".png" + Environment.NewLine);
                        NET_CLIENT.DownloadFileAsync(myLinkCoverDisc,
                            GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar + _IDMakerCode + ".png");
                        while (NET_CLIENT.IsBusy) Application.DoEvents();
                    }
                }
                catch (WebException ex)
                {
                    //MessageBox.Show("ARQUIVO: " + _netResponse.ToString() + " not found!");
                    tbLog.AppendText("[" + DateString() + "]" + Resources.DownloadDiscCoverError + Environment.NewLine +
                                     "[" + DateString() + "]" + Resources.Error + ex.Message + Environment.NewLine);
                    tbLog.AppendText(ex.StackTrace);
                }
                finally
                {
                    if (NET_RESPONSE != null) NET_RESPONSE.Close();
                }

                try
                {
                    // Download 3D cover
                    var myLinkCover3D = new Uri(@"https://art.gametdb.com/wii/cover3D/" + LINK_DOMAIN + "/" +
                                                _IDMakerCode + ".png");
                    var request3D = (HttpWebRequest)WebRequest.Create(myLinkCover3D);
                    request3D.Method = "HEAD";
                    NET_RESPONSE = (HttpWebResponse)request3D.GetResponse();

                    if (NET_RESPONSE.StatusCode == HttpStatusCode.OK)
                    {
                        tbLog.AppendText("[" + DateString() + "]" + Resources.Download3DCover + _IDMakerCode + ".png" +
                                         Environment.NewLine);
                        NET_CLIENT.DownloadFileAsync(myLinkCover3D,
                            GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar + _IDMakerCode + ".png");
                        while (NET_CLIENT.IsBusy) Application.DoEvents();
                    }
                }
                catch (WebException ex)
                {
                    //MessageBox.Show("ARQUIVO: " + _netResponse.ToString() + " not found!");
                    tbLog.AppendText("[" + DateString() + "]" + Resources.Download3DCoverError + Environment.NewLine +
                                     "[" + DateString() + "]" + Resources.Error + ex.Message + Environment.NewLine);
                    tbLog.AppendText(ex.StackTrace);
                }
                finally
                {
                    if (NET_RESPONSE != null) NET_RESPONSE.Close();
                }
            }
        }

        #endregion

        // REWRITE FUNCTION - Clear temporary folder

        #region Clear Temp

        /// <summary>
        ///     Clean up the temporary directory.
        /// </summary>
        private void ClearTemp()
        {
            try
            {
                if (sio.Directory.Exists(CONFIG_INI_FILE.IniReadString("GENERAL", "TemporaryFolder", "")))
                {
                    var dir = new sio.DirectoryInfo(CONFIG_INI_FILE.IniReadString("GENERAL", "TemporaryFolder", ""));
                    foreach (var fi in dir.GetFiles("*.*", sio.SearchOption.AllDirectories))
                    {
                        fi.Delete();
                        sio.Directory.Delete(dir.ToString(), true);
                    }
                }
                else
                {
                    var dir = new sio.DirectoryInfo(GET_CURRENT_PATH + TEMP_DIR);
                    foreach (var fi in dir.GetFiles("*.*", sio.SearchOption.AllDirectories))
                    {
                        fi.Delete();
                        sio.Directory.Delete(dir.ToString(), true);
                    }
                }
            }
            catch (Exception ex)
            {
                tbLog.AppendText("[" + DateString() + "]" + Resources.ClearTemp_String1 + Environment.NewLine);
                tbLog.AppendText(ex.StackTrace);
            }
        }

        #endregion

        #region Required Directories

        /// <summary>
        ///     Directories required for the correct functioning of the program.
        /// </summary>
        private void RequiredDirectories()
        {
            // Temporary directory default
            if (!sio.Directory.Exists(CONFIG_INI_FILE.IniReadString("GENERAL", "TemporaryFolder", "")))
            {
                sio.Directory.CreateDirectory(CONFIG_INI_FILE.IniReadString("GENERAL", "TemporaryFolder", ""));
                tbLog.AppendText("[" + DateString() + "]" + Resources.RequiredDirectories_String1 +
                                 Environment.NewLine);
            }
            else
            {
                tbLog.AppendText("[" + DateString() + "]" + Resources.RequiredDirectories_String2 +
                                 Environment.NewLine);
            }

            // Cover Directory
            if (!sio.Directory.Exists(GET_CURRENT_PATH + COVERS_DIR))
            {
                // US - Covers Directory
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "US" + sio.Path.DirectorySeparatorChar + "2d" + sio.Path.DirectorySeparatorChar); // 2D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "US" + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar); // 3D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "US" + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar); // Disc
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "US" + sio.Path.DirectorySeparatorChar + "full" + sio.Path.DirectorySeparatorChar); // Full
                // JA - Covers Directory
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "JA" + sio.Path.DirectorySeparatorChar + "2d" + sio.Path.DirectorySeparatorChar); // 2D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "JA" + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar); // 3D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "JA" + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar); // Disc
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "JA" + sio.Path.DirectorySeparatorChar + "full" + sio.Path.DirectorySeparatorChar); // Full
                // EN - Covers Directory
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "EN" + sio.Path.DirectorySeparatorChar + "2d" + sio.Path.DirectorySeparatorChar); // 2D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "EN" + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar); // 3D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "EN" + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar); // Disc
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "EN" + sio.Path.DirectorySeparatorChar + "full" + sio.Path.DirectorySeparatorChar); // Full
                // DE - Covers Directory
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "DE" + sio.Path.DirectorySeparatorChar + "2d" + sio.Path.DirectorySeparatorChar); // 2D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "DE" + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar); // 3D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "DE" + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar); // Disc
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "DE" + sio.Path.DirectorySeparatorChar + "full" + sio.Path.DirectorySeparatorChar); // Full
                // ES - Covers Directory
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "ES" + sio.Path.DirectorySeparatorChar + "2d" + sio.Path.DirectorySeparatorChar); // 2D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "ES" + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar); // 3D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "ES" + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar); // Disc
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "ES" + sio.Path.DirectorySeparatorChar + "full" + sio.Path.DirectorySeparatorChar); // Full
                // IT - Covers Directory
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "IT" + sio.Path.DirectorySeparatorChar + "2d" + sio.Path.DirectorySeparatorChar); // 2D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "IT" + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar); // 3D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "IT" + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar); // Disc
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "IT" + sio.Path.DirectorySeparatorChar + "full" + sio.Path.DirectorySeparatorChar); // Full
                // AU - Covers Directory
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "AU" + sio.Path.DirectorySeparatorChar + "2d" + sio.Path.DirectorySeparatorChar); // 2D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "AU" + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar); // 3D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "AU" + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar); // Disc
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "AU" + sio.Path.DirectorySeparatorChar + "full" + sio.Path.DirectorySeparatorChar); // Full
                // NL - Covers Directory
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "NL" + sio.Path.DirectorySeparatorChar + "2d" + sio.Path.DirectorySeparatorChar); // 2D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "NL" + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar); // 3D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "NL" + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar); // Disc
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "NL" + sio.Path.DirectorySeparatorChar + "full" + sio.Path.DirectorySeparatorChar); // Full
                // FR - Covers Directory
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "FR" + sio.Path.DirectorySeparatorChar + "2d" + sio.Path.DirectorySeparatorChar); // 2D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "FR" + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar); // 3D
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "FR" + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar); // Disc
                sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + "FR" + sio.Path.DirectorySeparatorChar + "full" + sio.Path.DirectorySeparatorChar); // Full

                tbLog.AppendText("[" + DateString() + "]" + Resources.RequiredDirectories_String4 +
                                 Environment.NewLine);
            }
            else
            {
                tbLog.AppendText("[" + DateString() + "]" + Resources.RequiredDirectories_String5 +
                                 Environment.NewLine);
            }
        }

        #endregion

        #region External Site

        /// <summary>
        ///     Function to load websites in the default browser.
        /// </summary>
        /// <param name="targetLink"></param>
        /// <param name="targetID"></param>
        private void ExternalSite(string targetLink, string targetID)
        {
            try
            {
                Process.Start(targetLink + targetID);
            }
            catch (Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    GlobalNotifications(noBrowser.Message, ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                tbLog.AppendText("[" + DateString() + "]" + Resources.Error + ex.Message + Environment.NewLine);
                tbLog.AppendText(ex.StackTrace);
                GlobalNotifications(ex.Message, ToolTipIcon.Error);
            }
        }

        #endregion

        #region Get Hash

        /// <summary>
        ///     Get the Hash of the ISO/GCM file.
        /// </summary>
        /// <param name="hashAlgorithm"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            var data = hashAlgorithm.ComputeHash(ste.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (var i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        #endregion

        #region Verify Hash

        /// <summary>
        ///     Check the Hash of the ISO/GCM file.
        /// </summary>
        /// <param name="hashAlgorithm"></param>
        /// <param name="input"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);
            // Create a StringComparer an compare the hashes.
            var comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }

        #endregion

        #region Global Delete Selected Game

        /// <summary>
        ///     Global Delete Selected Game
        /// </summary>
        /// <param name="dgv"></param>
        private void GlobalDeleteSelectedGame(DataGridView dgv)
        {
            var _selectedRowCount = dgv.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (dgv.RowCount == 0)
            {
                EmptyGamesList();
            }
            else
            {
                if (_selectedRowCount == 0)
                    SelectGameFromList();
                else
                    try
                    {
                        if (DialogResultDeleteGame() == DialogResult.Yes)
                        {
                            if (_IDRegionCode.Equals("e"))
                                LINK_DOMAIN = "US";
                            else if (_IDRegionCode.Equals("p"))
                                LINK_DOMAIN = "EN";
                            else if (_IDRegionCode.Equals("j"))
                                LINK_DOMAIN = "JA";
                            else
                                LINK_DOMAIN = "EN";
                            //GlobalNotifications(GCBM.Properties.Resources.UnknownRegion, ToolTipIcon.Info);

                            var cover2D = GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar
                                + "2d" + sio.Path.DirectorySeparatorChar + tbIDGame.Text + ".png";
                            var cover3D = GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar
                                + "3d" + sio.Path.DirectorySeparatorChar + tbIDGame.Text + ".png";
                            var coverDisc = GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar
                                + "disc" + sio.Path.DirectorySeparatorChar + tbIDGame.Text + ".png";
                            var coverFull = GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar
                                + "full" + sio.Path.DirectorySeparatorChar + tbIDGame.Text + ".png";

                            // DELETAR JOGO E CAPA DO DISPOSITIVO DE ORIGEM
                            if (dgv == dgvSource)
                            {
                                sio.File.Delete(dgv.CurrentRow.Cells["Path"].Value.ToString());

                                // 2D
                                if (sio.File.Exists(cover2D)) sio.File.Delete(cover2D);
                                // 3D
                                if (sio.File.Exists(cover3D)) sio.File.Delete(cover3D);
                                // Disc
                                if (sio.File.Exists(coverDisc)) sio.File.Delete(coverDisc);
                                // Full
                                if (sio.File.Exists(coverFull)) sio.File.Delete(coverFull);

                                DisplayFilesSelected(fbd1.SelectedPath, dgvSource);
                            } // DELETE GAME FROM TARGET DEVICE.
                            else
                            {
                                var pasta = sio.Path.GetDirectoryName(dgv.CurrentRow.Cells["Path"].Value.ToString());
                                sio.Directory.Delete(pasta, true);
                                DisplayFilesSelected(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar, dgvDestination);
                            }
                        }

                        if (dgv.RowCount == 0)
                        {
                            DisableOptionsGame(dgvSource);
                            ResetOptions();
                        }
                    }
                    catch (Exception ex)
                    {
                        tbLog.AppendText("[" + DateString() + "]" + Resources.Error + ex.Message + Environment.NewLine);
                        tbLog.AppendText(ex.StackTrace);
                        GlobalNotifications(ex.Message, ToolTipIcon.Error);
                    }
            }
        }

        #endregion

        #region Global Delete All Games

        /// <summary>
        ///     Global Delete All Games
        /// </summary>
        /// <param name="dgv"></param>
        private async Task GlobalDeleteAllGames(DataGridView dgv)
        {
            var filters = new[] { "iso", "gcm" };

            if (dgv.RowCount == 0)
                EmptyGamesList();
            else
                try
                {
                    if (DialogResultDeleteGame() == DialogResult.Yes)
                    {
                        // HERE START DELETING FILES.

                        if (dgv == dgvSource)
                        {
                            if (_IDRegionCode.Equals("e"))
                                LINK_DOMAIN = "US";
                            else if (_IDRegionCode.Equals("p"))
                                LINK_DOMAIN = "EN";
                            else if (_IDRegionCode.Equals("j"))
                                LINK_DOMAIN = "JA";
                            else
                                LINK_DOMAIN = "EN";
                            //GlobalNotifications(GCBM.Properties.Resources.UnknownRegion, ToolTipIcon.Info);

                            var di2D = new sio.DirectoryInfo(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                                                             sio.Path.DirectorySeparatorChar + "2d" + sio.Path.DirectorySeparatorChar);
                            var di3D = new sio.DirectoryInfo(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                                                             sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar);
                            var diDisc =
                                new sio.DirectoryInfo(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar);
                            var diFull =
                                new sio.DirectoryInfo(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN + sio.Path.DirectorySeparatorChar + "full" + sio.Path.DirectorySeparatorChar);

                            var files = await GetFilesFolder(fbd1.SelectedPath, filters, false).ConfigureAwait(false);

                            // Goes through the entire file list and removes all found ISO and GCM files.
                            for (var i = 0; i < files.Length; i++)
                            {
                                //File.Delete(fbd1.SelectedPath + sio.Path.DirectorySeparatorChar + dgvSource.CurrentRow.Cells["Title"].Value.ToString());
                                sio.File.Delete(dgv.CurrentRow.Cells["Path"].Value.ToString());

                                DisplayFilesSelected(fbd1.SelectedPath, dgv);
                            }

                            // Delete cover 2D files
                            foreach (var file in di2D.GetFiles()) file.Delete();
                            // Delete cover 3D files
                            foreach (var file in di3D.GetFiles()) file.Delete();
                            // Delete cover Disc files
                            foreach (var file in diDisc.GetFiles()) file.Delete();
                            // Delete cover Full files
                            foreach (var file in diFull.GetFiles()) file.Delete();

                            //if (dgv.RowCount == 0)
                            //{
                            //    DisableOptionsGame(dgvSource);
                            //    ResetOptions();
                            //    MessageBox.Show("Todos os arquivos foram excluídos com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                        } // DELETAR JOGO DO DISPOSITIVO DE DESTINO
                        else if (dgv == dgvSource)
                        {
                            var files = await GetFilesFolder(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar, filters,
                                false).ConfigureAwait(false);

                            // Goes through the entire file list and removes all found ISO and GCM files.
                            //string folder = Path.GetDirectoryName(dgv.CurrentRow.Cells["Path"].Value.ToString());
                            for (var i = 0; i < files.Length; i++)
                            {
                                var folder = sio.Path.GetDirectoryName(dgv.CurrentRow.Cells["Path"].Value.ToString());
                                //File.Delete(tscbDiscDrive.SelectedItem + "games" + sio.Path.DirectorySeparatorChar + dgv.CurrentRow.Cells[0].Value.ToString());                               
                                sio.Directory.Delete(folder, true);
                                //MessageBox.Show(pasta);

                                DisplayFilesSelected(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar, dgv);
                            }

                            //dgvSource.DataSource = null;
                            dgv.DataSource = null;

                            // Delete cover 2D files
                            //foreach (FileInfo file in di2D.GetFiles())
                            //{
                            //    file.Delete();
                            //}
                            //// Delete cover 3D files
                            //foreach (FileInfo file in di3D.GetFiles())
                            //{
                            //    file.Delete();
                            //}
                            //// Delete cover Disc files
                            //foreach (FileInfo file in diDisc.GetFiles())
                            //{
                            //    file.Delete();
                            //}
                            //// Delete cover Full files
                            //foreach (FileInfo file in diFull.GetFiles())
                            //{
                            //    file.Delete();
                            //}

                            //if (dgvSource.RowCount == 0)
                            //{
                            //    DisableOptionsGame(dgvSource);
                            //    ResetOptions();
                            //    MessageBox.Show("Todos os arquivos foram excluídos com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                        }
                    }

                    if (dgv.RowCount == 0)
                    {
                        DisableOptionsGame(dgv);
                        if (dgv == dgvSource) ResetOptions();

                        MessageBox.Show(Resources.AllFilesSuccessfullyDeleted, Resources.Notice,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    tbLog.AppendText("[" + DateString() + "]" + Resources.Error + ex.Message + Environment.NewLine);
                    tbLog.AppendText(ex.StackTrace);
                    GlobalNotifications(ex.Message, ToolTipIcon.Error);
                }
        }

        #endregion

        #region Global Install

        /// <summary>
        ///     Global Install
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="typeInstall"></param>
        private void GlobalInstall(DataGridView dgv, int typeInstall)
        {
            var selectedRowCount = dgv.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 0)
            {
                SelectGameFromList();
            }
            else
            {
                if (tscbDiscDrive.SelectedIndex == 0)
                {
                    SelectTargetDrive();
                }
                else
                {
                    if (!isGCITRunning())
                        try
                        {
                            if (typeInstall == 0) // Install Exact Copy
                            {
                                BuildInstallQueue();
                                DisableOptionsGame(dgvSource);
                                INSTALLING = true;
                                btnAbort.Visible = true;
                                lblAbort.Visible = true;
                                InstallGameExactCopy(InstallQueue[intQueuePos].Path);
                            }
                            else // Install Scrub
                            {
                                btnAbort.Visible = true;
                                lblAbort.Visible = true;
                                BuildInstallQueue();
                                if (lstInstallQueue.Count == 0 || lstInstallQueue == null)
                                    //probably unreachable
                                    MessageBox.Show("Select a game");
                                if (lstInstallQueue.Count == 1)
                                {
                                    INSTALLING = true;
                                    InstallGameScrub(intQueuePos);
                                }
                                else
                                {
                                    if (intQueuePos <= intQueueLength)
                                    {
                                        INSTALLING = true;
                                        InstallGameScrub(intQueuePos);
                                    }
                                    //MessageBox.Show("Currently we only support 1 game to scrub at a time.");
                                }
                            }
                        }
                        catch
                        {
                        }
                }
            }
        }

        #endregion

        #region Global Check Hashs

        /// <summary>
        ///     Global Check Hashs
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="algorithm"></param>
        private void GlobalCheckHash(DataGridView dgv, string algorithm)
        {
            var selectedRowCount = dgv.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount == 0)
                SelectGameFromList();
            else
                try
                {
                    var source = dgv.CurrentRow.Cells["Path"].Value.ToString();

                    //SHA-1
                    if (algorithm == "SHA-1")
                        using (var sha1Hash = SHA1.Create())
                        {
                            var hash = GetHash(sha1Hash, source);

                            if (VerifyHash(sha1Hash, source, hash))
                                ListHash("SHA-1", hash);
                            else
                                tbLog.AppendText("[" + DateString() + "]" + Resources.HashesAreNotSame +
                                                 Environment.NewLine);
                        }
                    else if (algorithm == "MD5")
                        //MD5
                        using (var md5Hash = MD5.Create())
                        {
                            var hash = GetHash(md5Hash, source);

                            if (VerifyHash(md5Hash, source, hash))
                                ListHash("MD5", hash);
                            else
                                tbLog.AppendText("[" + DateString() + "]" + Resources.HashesAreNotSame +
                                                 Environment.NewLine);
                        }
                }
                catch (Exception ex)
                {
                    tbLog.AppendText("[" + DateString() + "]" + Resources.Error + ex.Message + Environment.NewLine);
                    tbLog.AppendText(ex.StackTrace);
                    GlobalNotifications(ex.Message, ToolTipIcon.Error);
                }
        }

        #endregion

        // REWRITE FUNCTION - Check Cover Transfer

        #region Check Cover Transfer

        /// <summary>
        ///     Function to check if the USB Loader GX or WiiFlow directories are configured.
        /// </summary>
        private void CheckCoverTransfer()
        {
            //USB Loader GX
            if (CONFIG_INI_FILE.IniReadBool("COVERS", "GXCoverUSBLoader"))
            {
                if (CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectoryDisc", "") == string.Empty ||
                    CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectory2D", "") == string.Empty
                    || CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectory3D", "") == string.Empty ||
                    CONFIG_INI_FILE.IniReadString("COVERS", "GXCoverDirectoryFull", "") == string.Empty)
                {
                    CheckUSBGXFlow();
                }
                else
                {
                    var _frmTransfer = new frmTransferCover();
                    _frmTransfer.ShowDialog();
                    _frmTransfer.Dispose();
                }
            } // WiiFlow
            else if (CONFIG_INI_FILE.IniReadBool("COVERS", "WiiFlowCoverUSBLoader"))
            {
                if (CONFIG_INI_FILE.IniReadString("COVERS", "WiiFlowCoverDirectory2D", "") == string.Empty ||
                    CONFIG_INI_FILE.IniReadString("COVERS", "WiiFlowCoverDirectoryFull", "") == string.Empty)
                {
                    CheckUSBGXFlow();
                }
                else
                {
                    var _frmTransfer = new frmTransferCover();
                    _frmTransfer.ShowDialog();
                    _frmTransfer.Dispose();
                }
            }
        }

        #endregion

        #region Additional Information

        /// <summary>
        ///     Additional Information.
        /// </summary>
        private void AdditionalInformation()
        {
            var _selectedGameRowCount = dgvSource.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (_selectedGameRowCount == 0)
            {
                SelectGameFromList();
            }
            else
            {
                if (sio.File.Exists(WIITDB_FILE))
                {
                    var _frmInfo = new frmInfoAdditional(tbIDGame.Text);
                    _frmInfo.ShowDialog();
                    _frmInfo.Dispose();
                }
                else
                {
                    CheckWiiTdbXml();
                }
            }
        }

        #endregion

        #region Export TXT

        /// <summary>
        ///     Export game list to TXT.
        /// </summary>
        /// <param name="dgv"></param>
        private void ExportTXT(DataGridView dgv)
        {
            if (dgvSource.RowCount == 0)
                GlobalNotifications(Resources.RecordExportedFailed, ToolTipIcon.Error);
            else
                try
                {
                    sio.TextWriter writer = new sio.StreamWriter(GET_CURRENT_PATH + sio.Path.DirectorySeparatorChar + "gamelist.txt");
                    for (var i = 0; i < dgv.Rows.Count - 1; i++)
                    {
                        for (var j = 1; j < dgv.Columns.Count; j++)
                            writer.Write("\t" + dgv.Rows[i].Cells[j].Value + "\t" + "|");
                        writer.WriteLine("");
                        writer.WriteLine(
                            "--------------------------------------------------------------------------------" +
                            "------------------------------------------------------------------------------------------");
                    }

                    writer.Close();
                    GlobalNotifications(Resources.GameListExportedTXT, ToolTipIcon.Info);
                }
                catch (Exception ex)
                {
                    GlobalNotifications(ex.Message, ToolTipIcon.Error);
                }
        }

        #endregion

        #region Export LOG

        /// <summary>
        ///     Export LOG
        /// </summary>
        /// <param name="value"></param>
        private void ExportLOG(int value)
        {
            if (value == 0)
            {
                if (tbLog.Text != string.Empty)
                {
                    sio.File.WriteAllText(GET_CURRENT_PATH + sio.Path.DirectorySeparatorChar + "gcbm.log", tbLog.Text);
                    GlobalNotifications(Resources.RecordExportedSuccessfully, ToolTipIcon.Info);
                }
                else
                {
                    GlobalNotifications(Resources.RecordExportedFailed, ToolTipIcon.Error);
                }
            }
            else
            {
                if (tbLog.Text != string.Empty) sio.File.WriteAllText(GET_CURRENT_PATH + sio.Path.DirectorySeparatorChar + "gcbm.log", tbLog.Text);
            }
        }

        #endregion

        #region Searh On Web

        private void SearchOnWeb(string link)
        {
            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName"))
            {
                if (sio.File.Exists(WIITDB_FILE))
                {
                    var root = XElement.Load(WIITDB_FILE);
                    var tests = from el in root.Elements("game")
                        where (string)el.Element("id") == tbIDGame.Text
                        select el;
                    foreach (var el in tests) ExternalSite(link, (string)el.Element("locale").Element("title"));
                }
                else
                {
                    CheckWiiTdbXml();
                }
            }
        }

        #endregion

        // Extras Functions

        #region dgvSource Click

        /// <summary>
        ///     Performs an action when clicking on the DataGridView Game List.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSource_Click(object sender, EventArgs e)
        {
            ReloadDataGridViewGameList(dgvSource);
        }

        #endregion

        #region Disc Drive Selected Index Changed

        /// <summary>
        ///     Selects the index of the changed disk drive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscbDiscDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbDiscDrive.SelectedIndex != 0)
            {
                tsmiGameDiscSelectAll.Enabled = true;
                tsmiGameDiscSelectNone.Enabled = true;
                tsmiGameDiscDeleteAllFiles.Enabled = true;
                tsmiGameDiscDeleteSelectedFile.Enabled = true;
                //tsmiGameDiscExportList.Enabled = true;
                //tsmiGameDiscAllHashSHA1.Enabled = true;
                tsmiGameDiscHashSHA1.Enabled = true;
                //tsmiGameDiscAllHashMD5.Enabled = true;
                tsmiGameDiscHashMD5.Enabled = true;
            }
            else
            {
                DisableOptionsGame(dgvDestination);
            }

            tabMainDisc.Text = Resources.FilesDestinationUnit + tscbDiscDrive.SelectedItem + ")";

            try
            {
                var allDrives = sio.DriveInfo.GetDrives();

                foreach (var d in allDrives)
                {
                    //if (d.DriveType == DriveType.Removable && d.Name == tscbDiscDrive.SelectedItem.ToString())
                    if (d.DriveType == sio.DriveType.Fixed && d.Name == tscbDiscDrive.SelectedItem.ToString())
                    {
                        //tscbDiscDrive.Items.Add(d.Name);
                        lblSpaceAvailabeOnDevice.Text =
                            Resources.DestinyDrive_AvailableSpace + BytesToGB(d.TotalFreeSpace);
                        lblSpaceTotalOnDevice.Text = Resources.DestinyDrive_TotalSpace + BytesToGB(d.TotalSize);
                    }
                    else if (tscbDiscDrive.SelectedIndex == 0)
                    {
                        lblSpaceAvailabeOnDevice.Text = Resources.DestinyDrive_AvailableSpace;
                        lblSpaceTotalOnDevice.Text = Resources.DestinyDrive_TotalSpace;
                    }

                    if (d.IsReady)
                    {
                        if (tscbDiscDrive.Text == d.Name)
                        {
                            if (d.DriveFormat == NTFS) // NTFS
                            {
                                InvalidDrive(d.DriveFormat);

                                if (!sio.Directory.Exists(tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR))
                                {
                                    var result = MessageBox.Show(Resources.CreateGamesFolder,
                                        Resources.Attention, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                    if (result == DialogResult.Yes)
                                        sio.Directory.CreateDirectory(tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR);
                                }
                                else
                                {
                                    // If the GAMES directory already exists, load the content recursively.
                                    DisplayFilesSelected(tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR, dgvDestination);
                                }
                            }
                            else if (d.DriveFormat == EXFAT_FAT64) // EXFAT (FAT64)
                            {
                                InvalidDrive(d.DriveFormat);

                                if (!sio.Directory.Exists(tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR))
                                {
                                    var result = MessageBox.Show(Resources.CreateGamesFolder,
                                        Resources.Attention, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                    if (result == DialogResult.Yes)
                                        sio.Directory.CreateDirectory(tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR);
                                }
                                else
                                {
                                    // If the GAMES directory already exists, load the content recursively.
                                    DisplayFilesSelected(tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR, dgvDestination);
                                }
                            }
                            else // FAT32 
                            {
                                if (!sio.Directory.Exists(tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR))
                                {
                                    var result = MessageBox.Show(Resources.CreateGamesFolderNow,
                                        Resources.Attention, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                    if (result == DialogResult.Yes)
                                        sio.Directory.CreateDirectory(tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR);
                                }
                                else
                                {
                                    // If the GAMES directory already exists, load the content recursively.
                                    DisplayFilesSelected(tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR, dgvDestination);
                                }
                            }
                            //label6.Text = "Total Size: " + d.TotalSize / (1024 * 1024) + " MB\nDrive Format: " + d.DriveFormat + " \nAvailable: " + d.AvailableFreeSpace / (1024 * 1024) + " MB\n" + d.DriveType;
                        }

                        dgvGameListDiscPath = d.RootDirectory.FullName;
                    }
                }
            }
            catch (Exception ex)
            {
                tbLog.AppendText("[" + DateString() + "]" + Resources.Error + ex.Message + Environment.NewLine);
                tbLog.AppendText(ex.StackTrace);
                GlobalNotifications(ex.Message, ToolTipIcon.Error);
            }
        }

        #endregion

        #region txtLog Text Changed

        /// <summary>
        ///     Just insert an asterisk (*) in the Log tab text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            if (tbLog.Lines.Length > 14)
            {
                tabMainLog.Text = "Log *";
                tbLog.SelectionStart = tbLog.TextLength;
                tbLog.ScrollToCaret();
            }

            if (tbLog.Visible)
            {
                tbLog.SelectionStart = tbLog.TextLength;
                tbLog.ScrollToCaret();
            }
        }

        #endregion

        #region dgvGameListDisc_Click

        private void dgvGameListDisc_Click(object sender, EventArgs e)
        {
            ReloadDataGridViewGameList(dgvDestination);
        }

        #endregion

        #region ComboBox Database Filter

        /// <summary>
        ///     ComboBox Database Filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFilterDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterDatabase.SelectedIndex != 0)
            {
                if (lvDatabase.Items.Count == 0)
                    MessageBox.Show(Resources.FilterDatabase_String1 + Environment.NewLine + Environment.NewLine +
                                    Resources.FilterDatabase_String2, Resources.Notice, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                    foreach (ListViewItem item in lvDatabase.Items)
                        if (cbFilterDatabase.Text.ToLower() == item.SubItems[3].Text.ToLower())
                        {
                            lvDatabase.Refresh();
                            lvDatabase.Focus();
                            lvDatabase.HideSelection = false;
                            item.Selected = true;
                            lvDatabase.TopItem = item;
                            break;
                        }
            }
        }

        #endregion

        // VERIFICAR, REWRITE AND ORGANIZE!!!

        #region lvDatabase_Click

        private void lvDatabase_Click(object sender, EventArgs e)
        {
            if (lvDatabase.SelectedItems[0].Text != string.Empty)
                try
                {
                    string _region;

                    if (lvDatabase.SelectedItems[0].SubItems[2].Text == "NTSC-U")
                        _region = "US";
                    else if (lvDatabase.SelectedItems[0].SubItems[2].Text == "NTSC-J")
                        _region = "JA";
                    else if (lvDatabase.SelectedItems[0].SubItems[2].Text == "NTSC-K")
                        _region = "JA";
                    else //if (lvDatabase.SelectedItems[2].Text.ToString() == "PAL")
                        _region = "EN";

                    // Take the Disc covers from the device
                    if (sio.File.Exists(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + _region + sio.Path.DirectorySeparatorChar
                        + "disc" + sio.Path.DirectorySeparatorChar + lvDatabase.SelectedItems[0].Text + ".png"))
                    {
                        pbGameDisc.LoadAsync(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + _region + sio.Path.DirectorySeparatorChar
                            + "disc" + sio.Path.DirectorySeparatorChar + lvDatabase.SelectedItems[0].Text + ".png");
                    }
                    else
                    {
                        // Get Disc Covers from the Internet
                        //HttpWebResponse response = null;
                        var request = (HttpWebRequest)WebRequest.Create(@"https://art.gametdb.com/wii/disc/" + _region +
                                                                        "/" + lvDatabase.SelectedItems[0].Text +
                                                                        ".png");
                        request.Method = "HEAD";
                        NET_RESPONSE = (HttpWebResponse)request.GetResponse();

                        try
                        {
                            if (NET_RESPONSE.StatusCode == HttpStatusCode.OK)
                                pbGameDisc.LoadAsync(@"https://art.gametdb.com/wii/disc/" + _region + "/" +
                                                     lvDatabase.SelectedItems[0].Text + ".png");
                        }
                        catch (WebException ex)
                        {
                            GlobalNotifications(Resources.ServerReportedDiscCoverNotFound + " " + ex.Message, ToolTipIcon.Error);
                        }
                        finally
                        {
                            if (NET_RESPONSE != null) NET_RESPONSE.Close();
                        }
                    }

                    //Grab the device's 3D covers
                    if (sio.File.Exists(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + _region + sio.Path.DirectorySeparatorChar
                        + "3d" + sio.Path.DirectorySeparatorChar + lvDatabase.SelectedItems[0].Text + ".png"))
                    {
                        pbGameCover3D.LoadAsync(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + _region
                            + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar + lvDatabase.SelectedItems[0].Text + ".png");
                    }
                    else
                    {
                        // Get 3D covers from the internet
                        //HttpWebResponse response = null;
                        var request3D = (HttpWebRequest)WebRequest.Create(@"https://art.gametdb.com/wii/cover3D/" +
                                                                          _region + "/" +
                                                                          lvDatabase.SelectedItems[0].Text + ".png");
                        request3D.Method = "HEAD";
                        NET_RESPONSE = (HttpWebResponse)request3D.GetResponse();

                        try
                        {
                            if (NET_RESPONSE.StatusCode == HttpStatusCode.OK)
                                pbGameCover3D.LoadAsync(@"https://art.gametdb.com/wii/cover3D/" + _region + "/" +
                                                        lvDatabase.SelectedItems[0].Text + ".png");
                        }
                        catch (WebException ex)
                        {
                            GlobalNotifications(Resources.ServerReported3DCoverNotFound + " " + ex.Message, ToolTipIcon.Error);
                        }
                        finally
                        {
                            if (NET_RESPONSE != null) NET_RESPONSE.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    GlobalNotifications(Resources.ServerReportedOneCoverOrBothNotFound, ToolTipIcon.Error);
                }
        }

        #endregion


        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabMainFile)
                dgvSelected = dgvSource;
            else if (tabControlMain.SelectedTab == tabMainDisc) dgvSelected = dgvDestination;
        }

        // Buttons

        #region Button - Install Exact Copy Game

        /// <summary>
        ///     Button to install exact copy (1:1) of the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGameInstallExactCopy_Click(object sender, EventArgs e)
        {
            GlobalInstall(dgvSource, 0);
        }

        #endregion

        #region Button - Install Scrub Game

        /// <summary>
        ///     Button to install scrub copy of the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGameInstallScrub_Click(object sender, EventArgs e)
        {
            StartScrub();
        }

        #endregion

        #region Button - Select Folder with ISO/GCM Game Files

        /// <summary>
        ///     Button to select the directory that contains the ISO/GCM files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                fbd1.Description = Resources.SelectFolderContainingIsoGcmFiles;
                fbd1.ShowNewFolderButton = false;
                if (fbd1.ShowDialog() == DialogResult.OK)
                {
                    dgvGameListPath = fbd1.SelectedPath;
                    DisplayFilesSelected(fbd1.SelectedPath, dgvSource);
                    ListIsoFile();
                }
            }
            catch (Exception ex)
            {
                tbLog.AppendText("[" + DateString() + "]" + Resources.Error + ex.Message + Environment.NewLine);
                tbLog.AppendText(ex.StackTrace);
                GlobalNotifications(ex.Message, ToolTipIcon.Error);
            }
        }

        #endregion

        //private void dgvGameList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 0)
        //    {
        //        /*
        //         * e.ColumnIndex = 0 
        //         * e.RowIndex
        //         */
        //        if (dgvSelected != dgvSource && dgvSelected != dgvDestination)
        //            dgvSelected = dgvSource; //We haven't chosen one.. but.. clicked. Set selected dgv to source
        //        //There's a way to do this in a single line.. but
        //        if (dgvSelected != null && dgvSelected.Rows[e.RowIndex].Cells[0].Value.ToString() == "False")
        //        {
        //            if (dgvSelected != null) dgvSelected.Rows[e.RowIndex].Cells[0].Value = true;
        //        }
        //        else
        //        {
        //            if (dgvSelected != null) dgvSelected.Rows[e.RowIndex].Cells[0].Value = false;
        //        }
        //    }
        //}

        private void Search_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabMainFile)
                dgvSelected = dgvSource;
            else if (tabControlMain.SelectedTab == tabMainDisc) dgvSelected = dgvDestination;
            foreach (DataGridViewRow row in dgvSelected.Rows) row.Visible = true;
            foreach (DataGridViewRow row in dgvSelected.Rows)
                if (tbSearch.Text != null || tbSearch.Text != string.Empty)
                    if (
                        !row.Cells["Title"].Value.ToString().ToLower().Contains(tbSearch.Text.ToLower()) &&
                        !row.Cells["ID"].Value.ToString().ToLower().Contains(tbSearch.Text.ToLower()) &&
                        !row.Cells["Region"].Value.ToString().ToLower().Contains(tbSearch.Text.ToLower()) &&
                        !row.Cells["Type"].Value.ToString().ToLower().Contains(tbSearch.Text.ToLower()) &&
                        !row.Cells["Size"].Value.ToString().ToLower().Contains(tbSearch.Text.ToLower()) &&
                        !row.Cells["Path"].Value.ToString().ToLower().Contains(tbSearch.Text.ToLower()))
                        row.Visible = false;
        }

        private void btnSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnSearch.PerformClick();
        }

        //Restarts the application (closes and reopens)
        //Application.Restart();
        private void tsmiGameListDeleteAllFiles_ClickAsync(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            ABORT = true;
            ResetOptions();
            lblInstallGame.Show();
        }

        #region Flag Attributes Screensaver

        /// <summary>
        ///     Flag Attributes Screensaver
        /// </summary>
        [FlagsAttribute]
        private enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
        }

        #endregion

        #region Main Form
        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                btnSearch.PerformClick();
            }
        }
        /// <summary>
        ///     Main constructor method of the class.
        ///     No argument parameters.
        /// </summary>
        private bool ABORT;

        public frmMain()
        {
            InitializeComponent();
            InstallQueue = new Dictionary<int, Game>();
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
            Text = "GameCube Backup Manager 2022 - " + VERSION() + " - 64-bit";

            // Splash Screen
            if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "DisableSplash") == false)
            {
                // Splash Screen
                Load += HandleFormLoad;
                SPLASH_SCREEN = new frmSplashScreen();
            }
            else
            {
                NetworkCheck();
            }

            if (!sio.File.Exists(INI_FILE))
            {
                DefaultConfigSave();
                DetectOSLanguage();

                AdjustLanguage();
                Controls.Clear();
                InitializeComponent();
            }

            LoadConfigFile();
            AboutTranslator();
            GetAllDrives();
            //DetectOSLanguage();
            //AdjustLanguage();
            UpdateProgram();
            LoadDatabaseXML();
            DisabeScreensaver();
            RegisterHeaderLog();
            RequiredDirectories();
            DisableOptionsGame(dgvSource);
            tscbDiscDrive.SelectedIndex = 0;
            cbFilterDatabase.SelectedIndex = 0;

            if (!sio.File.Exists(WIITDB_FILE)) CheckAndDownloadWiiTdbXml();

            // DISABLED
            tsmiExportCSV.Enabled = false;
            tsmiExportHTML.Enabled = false;
            //tsmiElfDol.Enabled = false;
            //tsmiDolphinEmulator.Enabled = false;
            tsmiBurnMedia.Enabled = false;
            tsmiManageApp.Enabled = false;
            tsmiCreatePackage.Enabled = false;
            // HIDE
            tsmiExportCSV.Visible = false;
            tsmiExportHTML.Visible = false;
            //tsmiElfDol.Visible = false;
            //tsmiDolphinEmulator.Visible = false;
            tsmiBurnMedia.Visible = false;
            tsmiManageApp.Visible = false;
            tsmiCreatePackage.Visible = false;

            //All done, Clean up / Refresh to ensure language and settings are updated.

            //Localization.. but not working @Laetemn

            #region dgvDestination Setup

            PopDestination();
            PopSource();

            #endregion

            Thread.CurrentThread.CurrentUICulture.ClearCachedData();
            Thread.CurrentThread.CurrentCulture.ClearCachedData();

            //foreach in this.Controls.Results 
            mstripMain.Refresh();
            Focus();
        }

        private void PopDestination()
        {
            var cb = new DataGridViewCheckBoxColumn();
            dgvDestination.Columns.Clear();
            dgvDestination.Columns.Add(cb);
            dgvDestination.Columns.Add("Title", Resources.LoadDatabase_GameTitle);
            dgvDestination.Columns.Add("ID", Resources.LoadDatabase_IDGameCode);
            dgvDestination.Columns.Add("Region", Resources.LoadDatabase_Region);
            dgvDestination.Columns.Add("Type", Resources.LoadDatabase_Type);
            dgvDestination.Columns.Add("Size", Resources.DisplayFilesSelected_Size);
            dgvDestination.Columns.Add("Path", Resources.DisplayFilesSelected_FilePath);
            dgvDestination.Refresh();
        }

        private void PopSource()
        {
            var cb = new DataGridViewCheckBoxColumn();
            dgvSource.Columns.Clear();
            dgvSource.Columns.Add(cb);
            dgvSource.Columns.Add("Title", Resources.LoadDatabase_GameTitle);
            dgvSource.Columns.Add("ID", Resources.LoadDatabase_IDGameCode);
            dgvSource.Columns.Add("Region", Resources.LoadDatabase_Region);
            dgvSource.Columns.Add("Type", Resources.LoadDatabase_Type);
            dgvSource.Columns.Add("Size", Resources.DisplayFilesSelected_Size);
            dgvSource.Columns.Add("Path", Resources.DisplayFilesSelected_FilePath);
            dgvSource.Refresh();
        }

        #endregion

        #region Properties

        private static readonly string GET_CURRENT_PATH = sio.Directory.GetCurrentDirectory();
        private static readonly string GAMES_DIR = "games";
        private static readonly string TEMP_DIR = sio.Path.DirectorySeparatorChar + "temp";
        private static readonly string COVERS_DIR = sio.Path.DirectorySeparatorChar + "covers" + sio.Path.DirectorySeparatorChar + "cache";
        private static readonly string MEDIA_DIR = sio.Path.DirectorySeparatorChar + "media" + sio.Path.DirectorySeparatorChar + "covers";
        private static readonly string CULTURE_CURRENT = "pt-BR";
        private static readonly string PROG_UPDATE = "10/07/2022";
        private static readonly string FAT32 = "FAT32";
        private static readonly string NTFS = "NTFS";
        private static readonly string EXFAT_FAT64 = "EXFAT";

        private bool INSTALLING;

        //private static string EXT2                   = "EXT2";
        //private static string EXT3                   = "EXT3";
        //private static string EXT4                   = "EXT4";
        //private static string CURRENT_DIRECTORY;
        //private static string STANDARD_DIRECTORY;
        //private static string FILE_TDBXML;
        //private static string LOG_LEVEL;
        //private static string CULTURE_LANG;
        //private static string TRANSLATOR;
        private static string RES_PATH;
        private static string IMAGE_PATH;
        private static string LINK_DOMAIN;
        private static string FLUSH_SD;
        private static string SCRUB_ALIGN;

        private static char REGION = 'n';

        //private const string MIN_DB_VERSION          = "1.2.0.0";
        private const string INI_FILE = "config.ini";

        //private const string GLOBAL_INI_FILE         = "gc_global.ini";
        //private const string LOG_FILE                = "gcbm.log";
        //private const string CACHE_DIR               = "cache";
        //private const string LOCAL_FILES_DB          = "gcbm_Local.xml";
        private const string WIITDB_FILE = "wiitdb.xml";
        private const string WIITDB_DOWNLOAD_SITE = "https://www.gametdb.com/";
        private const string en_US = "en-US";

        //private const string TITLES_FILE             = "titles.txt";
        //private bool ENABLE_INTERNET                 = true;
        //private bool ENABLE_UPDATE_PROGRAM           = true;
        //private bool UPDATE_LOG                      = true;
        private bool ERROR;

        //private bool NETWORK_CHECK                   = true;
        //private bool EXPORT_LOG_CHECK                = true;
        //private bool CLEAR_TEMP_CHECK                = true;
        //private bool WIITDBXML_CHECK                 = true;
        private bool SPLASH_SCREEN_DONE;
        private bool ROOT_OPENED = true;
        private readonly bool FILENAME_SORT = true;

        private readonly bool RETRIEVE_FILES_INFO = true;

        //private int Reserved;
        private readonly Assembly assembly = Assembly.GetExecutingAssembly();
        private readonly IniFile CONFIG_INI_FILE = new IniFile(INI_FILE);
        private readonly CultureInfo MY_CULTURE = new CultureInfo(CULTURE_CURRENT, false);
        private readonly ProcessStartInfo START_INFO = new ProcessStartInfo();
        private readonly WebClient NET_CLIENT = new WebClient();
        private HttpWebResponse NET_RESPONSE;
        private readonly frmSplashScreen SPLASH_SCREEN;
        private string WINTHEME;

        private bool WORKING;
        private string dgvGameListPath;
        private string dgvGameListDiscPath;
        private int intQueueLength;
        private int intQueuePos;
        private readonly List<Game> lstInstallQueue = new List<Game>();
        private readonly List<Game> lstSourceGames = new List<Game>();
        private Game lastGameLookedUp;
        private DataGridView dgvSelected = new DataGridView();
        private readonly Dictionary<int, Game> InstallQueue;

        #region Global access for Image.cs and Info.cs

        //public string _IDMakerCode;
        //public string utility_GAME_REGION;
        //public string utility_GAME_TITLE;
        //private string utility_GAME_EXTENSION;
        //private int utility_GAME_SIZE;
        //private string utility_GAME_PATH;

        #endregion

        [DllImport("kernel32.dll")]
        private static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        #endregion

        #region Splash Ssreen

        /// <summary>
        ///     Load the Splash Screen form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleFormLoad(object sender, EventArgs e)
        {
            try
            {
                Hide();
                var thread = new Thread(ShowSplashScreen);
                thread.Start();
                var worker = new Hardworker();
                worker.ProgressChanged += (o, ex) => { SPLASH_SCREEN.UpdateProgress(ex.Progress); };
                worker.HardWorkDone += (o, ex) =>
                {
                    SPLASH_SCREEN_DONE = true;
                    //this.Show();
                    if (SPLASH_SCREEN_DONE)
                    {
                        Show();
                        NetworkCheck();

                        #region dgvSource Setup

                        dgvSource.Columns[1].HeaderText = Resources.LoadDatabase_GameTitle;
                        dgvSource.Columns[2].HeaderText = Resources.LoadDatabase_IDGameCode;
                        dgvSource.Columns[3].HeaderText = Resources.LoadDatabase_Region;
                        dgvSource.Columns[4].HeaderText = Resources.LoadDatabase_Type;
                        dgvSource.Columns[5].HeaderText = Resources.DisplayFilesSelected_Size;
                        dgvSource.Columns[6].HeaderText = Resources.DisplayFilesSelected_FilePath;
                        dgvSource.Refresh();

                        #endregion

                        #region dgvSource Setup

                        dgvDestination.Columns[1].HeaderText = Resources.LoadDatabase_GameTitle;
                        dgvDestination.Columns[2].HeaderText = Resources.LoadDatabase_IDGameCode;
                        dgvDestination.Columns[3].HeaderText = Resources.LoadDatabase_Region;
                        dgvDestination.Columns[4].HeaderText = Resources.LoadDatabase_Type;
                        dgvDestination.Columns[5].HeaderText = Resources.DisplayFilesSelected_Size;
                        dgvDestination.Columns[6].HeaderText = Resources.DisplayFilesSelected_FilePath;
                        dgvDestination.Refresh();

                        #endregion
                    }
                };
                worker.DoHardWork();
            }
            catch (Exception ex)
            {
                // Not used.
                // Just to avoid mistakes.
                tbLog.AppendText(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        /// <summary>
        ///     Display and close the Splash Screen form.
        /// </summary>
        private void ShowSplashScreen()
        {
            try
            {
                SPLASH_SCREEN.Show();
                while (!SPLASH_SCREEN_DONE) Application.DoEvents();
                SPLASH_SCREEN.Close();
                SPLASH_SCREEN.Dispose();
            }
            catch (Exception ex)
            {
                tbLog.AppendText(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        #endregion

        // REWRITE FUNCTION- Directory Open

        #region Directory Open

        /// <summary>
        ///     Checks the consistency of the listed ISO and GCM files.
        /// </summary>
        /// <param name="path"></param>
        private void VerifyGame(string path)
        {
            //OpenFileDialog ofd;

            //if (path.Length == 0)
            //{
            //    ofd = new OpenFileDialog() { Filter = "GameCube ISO (*.iso)|*.iso|GameCube Image File (*.gcm)|*.gcm|All files (*.*)|*.*", Title = "Open image" };
            //    if (imgPath != "")
            //        ofd.FileName = imgPath;
            //    if (ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        imgPath = ofd.FileName;
            //        path = imgPath;
            //    }
            //}

            if (path.Length == 0)
                return;

            IMAGE_PATH = path;

            if (CheckImage())
                if (ReadImageTOC())
                {
                    if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName"))
                    {
                        if (sio.File.Exists(WIITDB_FILE))
                        {
                            var root = XElement.Load(WIITDB_FILE);
                            var tests = from el in root.Elements("game")
                                where (string)el.Element("id") == tbIDGame.Text
                                select el;
                            foreach (var el in tests) tbIDName.Text = (string)el.Element("locale").Element("title");
                        }
                        else
                        {
                            CheckWiiTdbXml();
                        }
                    }

                    ROOT_OPENED = false;
                }
        }

        /// <summary>
        /// </summary>
        /// <param name="path"></param>
        private void DirectoryOpenDiscList(string path)
        {
            if (path.Length == 0)
                return;

            IMAGE_PATH = path;

            if (CheckImage())
                if (ReadImageDiscTOC())
                {
                    if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName"))
                    {
                        if (sio.File.Exists(WIITDB_FILE))
                        {
                            var root = XElement.Load(WIITDB_FILE);
                            var tests = from el in root.Elements("game")
                                where (string)el.Element("id") == tbIDGameDisc.Text
                                select el;
                            foreach (var el in tests) tbIDNameDisc.Text = (string)el.Element("locale").Element("title");
                        }
                        else
                        {
                            CheckWiiTdbXml();
                        }
                    }

                    //miImageOpen.ToolTipText = imgPath;
                    ROOT_OPENED = false;
                }

            tbIDRegionDisc.Text = dgvSelected.CurrentRow.Cells["ID"].Value.ToString();
        }

        #endregion

        #region OLD TRANSFER SYSTEM

        #region Install Game Scrub

        /// <summary>
        ///     Function to install an copy of the file in Scrub mode.
        /// </summary>
        private void InstallGameScrub()
        {
            const string quote = "\"";
            var _source = InstallQueue[intQueuePos].Path;

            START_INFO.CreateNoWindow = true;
            START_INFO.UseShellExecute = true;
            // GCIT
            START_INFO.FileName = GET_CURRENT_PATH + sio.Path.DirectorySeparatorChar + "bin" + sio.Path.DirectorySeparatorChar + "gcit.exe ";


            var boolCaseSwitch = CONFIG_INI_FILE.IniReadBool("TRANSFERSYSTEM", "ScrubFlushSD");
            var intCaseSwitch = CONFIG_INI_FILE.IniReadInt("TRANSFERSYSTEM", "ScrubAlign");

            switch (boolCaseSwitch)
            {
                case true:
                    FLUSH_SD = " - flush";
                    break;
                case false:
                    FLUSH_SD = "";
                    break;
            }

            switch (intCaseSwitch)
            {
                case 0:
                    SCRUB_ALIGN = "";
                    break;
                case 1:
                    SCRUB_ALIGN = " -a 4";
                    break;
                case 2:
                    SCRUB_ALIGN = " -a 32";
                    break;
                default:
                    SCRUB_ALIGN = " -a 32K";
                    break;
            }

            //if (CONFIG_INI_FILE.IniReadBool("TRANSFERSYSTEM", "ScrubFlushSD") == true)
            //{
            //    FLUSH_SD = " - flush";
            //}
            //else
            //{
            //    FLUSH_SD = "";
            //}

            //if (CONFIG_INI_FILE.IniReadInt("TRANSFERSYSTEM", "ScrubAlign") == 0)
            //{
            //    SCRUB_ALIGN = "";
            //}
            //else if (CONFIG_INI_FILE.IniReadInt("TRANSFERSYSTEM", "ScrubAlign") == 1)
            //{
            //    SCRUB_ALIGN = " -a 4";
            //}
            //else if (CONFIG_INI_FILE.IniReadInt("TRANSFERSYSTEM", "ScrubAlign") == 2)
            //{
            //    SCRUB_ALIGN = " -a 32";
            //}
            //else
            //{
            //    SCRUB_ALIGN = " -a 32K";
            //}

            START_INFO.Arguments = quote + _source + quote + " -aq " + SCRUB_ALIGN + FLUSH_SD + " -f " +
                                   CONFIG_INI_FILE.IniReadString("TRANSFERSYSTEM", "ScrubFormat", "") + " -d " +
                                   tscbDiscDrive.SelectedItem + GAMES_DIR;
            START_INFO.WindowStyle = ProcessWindowStyle.Hidden;

            using (var myProcess = Process.Start(START_INFO))
            {
                var i = 0;
                // Display the process statistics until
                // the user closes the program.
                do
                {
                    if (!myProcess.HasExited)
                    {
                        // Refresh the current process property values.
                        myProcess.Refresh();
                        // Display current process statistics.
                        tbLog.AppendText($"{myProcess} -");
                        //toolStripStatusLabel3.Text = $"{myProcess} -";
                        tbLog.AppendText(Environment.NewLine + "-------------------------------------" +
                                         Environment.NewLine + Environment.NewLine);

                        if (myProcess.Responding)
                        {
                            lblCopy.Visible = true;
                            lblInstallGame.Visible = true;
                            lblPercent.Visible = true;
                            pbCopy.Visible = true;

                            DisableOptionsGame(dgvSource);

                            lblCopy.Text = Resources.InstallGameScrub_String1;
                            lblInstallGame.Text = Resources.InstallGameScrub_String2 + i++;
                            pbCopy.PerformStep();
                            var incrementValue = i++ / 2;
                            pbCopy.Value = incrementValue;
                            lblPercent.Text = incrementValue + "%"; //i++.ToString() + "%";
                            //progressBarGameCopy.Maximum = i++ * 5;
                        }
                        else
                        {
                            lblInstallGame.Visible = true;
                            lblInstallGame.Text = Resources.InstallGameScrub_String3;
                        }
                    }
                    //progressBar1.Value += 5;
                } while (!myProcess.WaitForExit(1000));

                //textLog.AppendText($">> Código de saída do processo : {myProcess.ExitCode}");

                var _StatusExit = myProcess.ExitCode;
                if (_StatusExit == 0)
                {
                    lblInstallGame.Visible = true;
                    lblPercent.Visible = true;
                    pbCopy.Visible = true;

                    EnableOptionsGameList();

                    lblPercent.Text = "100%";
                    pbCopy.Value = 100;
                    lblInstallGame.Text = Resources.InstallGameScrub_String4;

                    if (tbIDDiscID.Text == "0x00")
                    {
                        //GlobalNotifications(Resources.InstallGameScrub_String5, ToolTipIcon.Info);
                        //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String5, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lblCopy.Visible = false;
                        lblInstallGame.Visible = false;
                        lblPercent.Visible = false;
                        pbCopy.Visible = false;
                    }

                    if (tbIDDiscID.Text == "0x01")
                    {
                        // Usar nome intermo
                        if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameInternalName"))
                        {
                            // Renomear game.iso -> disc2.iso
                            var myOrigem = tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + tbIDName.Text + " [" +
                                           tbIDGame.Text + "2]" + sio.Path.DirectorySeparatorChar + "game.iso";
                            var myDestiny = tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                            tbIDName.Text.Replace("disc2 ", "") + " [" + tbIDGame.Text + "2]" +
                                            sio.Path.DirectorySeparatorChar + "disc2.iso";

                            //MessageBox.Show("MYORIGEM: " + Environment.NewLine
                            //    + myOrigem +
                            //    "\n\nMYDESTINY: " + Environment.NewLine
                            //    + myDestiny, "DISC2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /*
                            * MYORIGEM:     c:\games\resident evil 4 disc2 (2) [G4BE082]\game.iso
                            * MYDESTINY:    c:\games\resident evil 4 disc2 (2) [G4BE082]\disc2.iso
                            * MYNEWDESTINY: c:\games\resident evil 4 [G4BE08]\
                            */

                            sio.File.Move(myOrigem, myDestiny);

                            //GlobalNotifications(Resources.InstallGameScrub_String6, ToolTipIcon.Info);
                            //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lblCopy.Visible = false;
                            lblInstallGame.Visible = false;
                            lblPercent.Visible = false;
                            pbCopy.Visible = false;
                            //GC.Collect();
                        } // Usar WiiTDB.xml
                        else
                        {
                            // Renomear game.iso -> disc2.iso
                            var myOrigem = tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + tbIDName.Text + " [" +
                                           _IDMakerCode + "2]" + sio.Path.DirectorySeparatorChar + "game.iso";
                            var myDestiny = tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                            tbIDName.Text.Replace("disc2 ", "") + " [" + _IDMakerCode + "2]" +
                                            sio.Path.DirectorySeparatorChar + "disc2.iso";

                            //MessageBox.Show("MYORIGEM: " + Environment.NewLine
                            //    + myOrigem +
                            //    "\n\nMYDESTINY: " + Environment.NewLine
                            //    + myDestiny, "DISC2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /*
                            * MYORIGEM:     c:\games\resident evil 4 disc2 (2) [G4BE082]\game.iso
                            * MYDESTINY:    c:\games\resident evil 4 disc2 (2) [G4BE082]\disc2.iso
                            * MYNEWDESTINY: c:\games\resident evil 4 [G4BE08]\
                            */

                            sio.File.Move(myOrigem, myDestiny);

                            //GlobalNotifications(Resources.InstallGameScrub_String6, ToolTipIcon.Info);
                            //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lblCopy.Visible = false;
                            lblInstallGame.Visible = false;
                            lblPercent.Visible = false;
                            pbCopy.Visible = false;
                            //GC.Collect();
                        }
                    }
                }
                //if (_StatusExit == 3)
                //{
                //    //tsslStatusInformation.Text = "Status: ERRO! -> " + "{" + _StatusExit.ToString() + "}" + " Por favor, verifique se exitem espaços no nome do arquivo!";
                //}
            }
        }

        #endregion

        #region Install Game Scrub

        /// <summary>
        ///     Function to install an copy of the file in Scrub mode.
        /// </summary>
        private void InstallGameScrub(int x)
        {
            //if (ABORT) return;
            while (true && !ABORT)
            {
                const string quote = "\"";
                var _source = InstallQueue[x].Path;

                START_INFO.CreateNoWindow = true;
                START_INFO.UseShellExecute = true;
                // GCIT
                START_INFO.FileName = GET_CURRENT_PATH + sio.Path.DirectorySeparatorChar + "bin" + sio.Path.DirectorySeparatorChar + "gcit.exe ";


                var boolCaseSwitch = CONFIG_INI_FILE.IniReadBool("TRANSFERSYSTEM", "ScrubFlushSD");
                var intCaseSwitch = CONFIG_INI_FILE.IniReadInt("TRANSFERSYSTEM", "ScrubAlign");

                switch (boolCaseSwitch)
                {
                    case true:
                        FLUSH_SD = " - flush";
                        break;
                    case false:
                        FLUSH_SD = "";
                        break;
                }

                switch (intCaseSwitch)
                {
                    case 0:
                        SCRUB_ALIGN = "";
                        break;
                    case 1:
                        SCRUB_ALIGN = " -a 4";
                        break;
                    case 2:
                        SCRUB_ALIGN = " -a 32";
                        break;
                    default:
                        SCRUB_ALIGN = " -a 32K";
                        break;
                }

                //if (CONFIG_INI_FILE.IniReadBool("TRANSFERSYSTEM", "ScrubFlushSD") == true)
                //{
                //    FLUSH_SD = " - flush";
                //}
                //else
                //{
                //    FLUSH_SD = "";
                //}

                //if (CONFIG_INI_FILE.IniReadInt("TRANSFERSYSTEM", "ScrubAlign") == 0)
                //{
                //    SCRUB_ALIGN = "";
                //}
                //else if (CONFIG_INI_FILE.IniReadInt("TRANSFERSYSTEM", "ScrubAlign") == 1)
                //{
                //    SCRUB_ALIGN = " -a 4";
                //}
                //else if (CONFIG_INI_FILE.IniReadInt("TRANSFERSYSTEM", "ScrubAlign") == 2)
                //{
                //    SCRUB_ALIGN = " -a 32";
                //}
                //else
                //{
                //    SCRUB_ALIGN = " -a 32K";
                //}

                START_INFO.Arguments = quote + _source + quote + " -aq " + SCRUB_ALIGN + FLUSH_SD + " -f " +
                                       CONFIG_INI_FILE.IniReadString("TRANSFERSYSTEM", "ScrubFormat", "") + " -d " +
                                       tscbDiscDrive.SelectedItem + GAMES_DIR;
                START_INFO.WindowStyle = ProcessWindowStyle.Hidden;

                using (var myProcess = Process.Start(START_INFO))
                {
                    var i = 0;
                    // Display the process statistics until
                    // the user closes the program.
                    do
                    {
                        if (!myProcess.HasExited)
                        {
                            // Refresh the current process property values.
                            myProcess.Refresh();
                            // Display current process statistics.
                            tbLog.AppendText($"{myProcess} -");
                            //toolStripStatusLabel3.Text = $"{myProcess} -";
                            tbLog.AppendText(Environment.NewLine + "-------------------------------------" +
                                             Environment.NewLine + Environment.NewLine);

                            if (myProcess.Responding)
                            {
                                i = UpdateProgressScrub(i);

                                //progressBarGameCopy.Maximum = i++ * 5;
                            }
                            else
                            {
                                lblInstallGame.Visible = true;
                                lblInstallGame.Text = Resources.InstallGameScrub_String3;
                            }
                        }
                        //progressBar1.Value += 5;
                    } while (!myProcess.WaitForExit(1000) && !ABORT);

                    //textLog.AppendText($">> Código de saída do processo : {myProcess.ExitCode}");

                    var _StatusExit = myProcess.ExitCode;
                    if (_StatusExit == 0)
                    {
                        lblInstallGame.Visible = true;
                        lblPercent.Visible = true;
                        pbCopy.Visible = true;

                        //EnableOptionsGameList();

                        lblPercent.Text = "100%";
                        pbCopy.Value = 100;
                        lblInstallGame.Text = Resources.InstallGameScrub_String4;

                        if (tbIDDiscID.Text == "0x00")
                        {
                            //GlobalNotifications(Resources.InstallGameScrub_String5, ToolTipIcon.Info);
                            //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String5, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lblCopy.Visible = false;
                            lblInstallGame.Visible = false;
                            lblPercent.Visible = false;
                            pbCopy.Visible = false;
                        }

                        if (tbIDDiscID.Text == "0x01")
                        {
                            // Usar nome intermo
                            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameInternalName"))
                            {
                                // Renomear game.iso -> disc2.iso
                                var myOrigem = tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + tbIDName.Text + " [" +
                                               tbIDGame.Text + "2]" + sio.Path.DirectorySeparatorChar + "game.iso";
                                var myDestiny = tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                tbIDName.Text.Replace("disc2 ", "") + " [" + tbIDGame.Text + "2]" +
                                                sio.Path.DirectorySeparatorChar + "disc2.iso";

                                //MessageBox.Show("MYORIGEM: " + Environment.NewLine
                                //    + myOrigem +
                                //    "\n\nMYDESTINY: " + Environment.NewLine
                                //    + myDestiny, "DISC2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                /*
                            * MYORIGEM:     c:\games\resident evil 4 disc2 (2) [G4BE082]\game.iso
                            * MYDESTINY:    c:\games\resident evil 4 disc2 (2) [G4BE082]\disc2.iso
                            * MYNEWDESTINY: c:\games\resident evil 4 [G4BE08]\
                            */

                                sio.File.Move(myOrigem, myDestiny);

                                //GlobalNotifications(Resources.InstallGameScrub_String6, ToolTipIcon.Info);
                                //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                lblCopy.Visible = false;
                                lblInstallGame.Visible = false;
                                lblPercent.Visible = false;
                                pbCopy.Visible = false;
                                //GC.Collect();
                            } // Usar WiiTDB.xml
                            else
                            {
                                // Renomear game.iso -> disc2.iso
                                var myOrigem = tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                               InstallQueue[intQueuePos].Title + " [" + InstallQueue[intQueuePos].ID +
                                               "2]" + sio.Path.DirectorySeparatorChar + "game.iso";
                                var myDestiny = tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                InstallQueue[intQueuePos].Title.Replace("disc2 ", "") + " [" +
                                                InstallQueue[intQueuePos].ID + "2]" + sio.Path.DirectorySeparatorChar + "disc2.iso";

                                //MessageBox.Show("MYORIGEM: " + Environment.NewLine
                                //    + myOrigem +
                                //    "\n\nMYDESTINY: " + Environment.NewLine
                                //    + myDestiny, "DISC2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                /*
                            * MYORIGEM:     c:\games\resident evil 4 disc2 (2) [G4BE082]\game.iso
                            * MYDESTINY:    c:\games\resident evil 4 disc2 (2) [G4BE082]\disc2.iso
                            * MYNEWDESTINY: c:\games\resident evil 4 [G4BE08]\
                            */
                                sio.File.Move(myOrigem, myDestiny);

                                //GlobalNotifications(Resources.InstallGameScrub_String6, ToolTipIcon.Info);
                                //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                lblCopy.Visible = false;
                                lblInstallGame.Visible = false;
                                lblPercent.Visible = false;
                                pbCopy.Visible = false;
                                //GC.Collect();
                            }
                        }
                    }
                    //if (_StatusExit == 3)
                    //{
                    //    //tsslStatusInformation.Text = "Status: ERRO! -> " + "{" + _StatusExit.ToString() + "}" + " Por favor, verifique se exitem espaços no nome do arquivo!";
                    //}
                }

                intQueuePos++;
                if (intQueuePos >= intQueueLength) break;
            }
        }

        private int UpdateProgressScrub(int i)
        {
            lblCopy.Visible = true;
            lblInstallGame.Visible = true;
            lblPercent.Visible = true;
            pbCopy.Visible = true;

            DisableOptionsGame(dgvSource);

            lblCopy.Text = Resources.InstallGameScrub_String1;
            lblInstallGame.Text = Resources.InstallGameScrub_String2 + i++;
            pbCopy.PerformStep();
            var incrementValue = i++ / 2;
            if (incrementValue >= 100)
            {
                pbCopy.Hide();
                lblPercent.Text = "This is taking a while, but we are still responding.";
            }
            else
            {
                lblPercent.Text = incrementValue + "%"; //i++.ToString() + "%";
                pbCopy.Value = incrementValue;
            }

            return i;
        }

        #endregion

        #region Copy Task

        /// <summary>
        ///     Function for the copy job.
        /// </summary>
        /// <param name="_source"></param>
        /// <param name="_destination"></param>
        private async void CopyTask(sio.FileInfo _source, sio.FileInfo _destination)
        {
            // Disc 1
            //if (textBoxDiscID.Text == "00" && comboBoxSettingsNomenclatureAppointmentStyle.SelectedIndex  == 0)
            if (tbIDDiscID.Text == "0x00")
            {
                if (_destination.Exists) _destination.Delete();
                //Create a tast to run copy file
                Run(() =>
                {
                    //_source.CopyTo(_destination, true);
                    _source.CopyTo(_destination, x => pbCopy.BeginInvoke(new Action(() =>
                    {
                        //DisableOptionsGame(dgvSource);
                        UpdateProgressExact(x);
                    })));
                }).GetAwaiter().OnCompleted(() => pbCopy.BeginInvoke(new Action(() =>
                {
                    FinishedInstalling();
                    if (intQueuePos <= intQueueLength)
                        try
                        {
                            CheckAndCallCopyTask(InstallQueue[intQueuePos].Path);
                        }
                        catch (Exception ex)
                        {
                            tbLog.AppendText("[" + DateTime.Now + "] Error Installing: " + Environment.NewLine + ex.Message + Environment.NewLine);
                            tbLog.AppendText(ex.StackTrace);
                        }
                })));
            }
            // Disc 2
            else if (tbIDDiscID.Text == "0x01")
            {
                if (_destination.Exists) _destination.Delete();
                //Create a tast to run copy file
                Run(() =>
                {
                    _source.CopyTo(_destination, x => pbCopy.BeginInvoke(new Action(() =>
                    {
                        //DisableOptionsGame(dgvSource);
                        UpdateProgressExact(x);
                    })));
                }).GetAwaiter().OnCompleted(() => pbCopy.BeginInvoke(new Action(() =>
                {
                    FinishedInstalling();
                    CheckAndCallCopyTask(InstallQueue[intQueuePos].Path);
                })));
            }
        }

        private void UpdateProgressExact(int x)
        {
            dgvSource.Enabled = false;
            pbCopy.Visible = true;
            lblCopy.Visible = true;
            lblPercent.Visible = true;
            lblInstallGame.Visible = true;
            pbCopy.Value = x;
            lblCopy.Text = Resources.CopyTask_String1;
            lblInstallGame.Text = Resources.CopyTask_String2 + tbIDName.Text;
            lblPercent.Text = x + "%";
        }

        private void FinishedInstalling()
        {
            pbCopy.Value = 100;
            lblCopy.Text = Resources.CopyTask_String3;
            lblInstallGame.Text = Resources.CopyTask_String4;
            lblPercent.Text = Resources.CopyTask_String5;
            //GlobalNotifications(Resources.InstallGameScrub_String5, ToolTipIcon.Info);
            EnableOptionsGameList();
            dgvSource.Enabled = true;
            pbCopy.Visible = false;
            lblCopy.Visible = false;
            lblPercent.Visible = false;
            lblInstallGame.Visible = false;
            intQueuePos++;
            WORKING = false;
        }

        #endregion

        #endregion

        #region Notifications

        /// <summary>
        ///     Global Notifications
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        private void GlobalNotifications(string message, ToolTipIcon icon)
        {
            if (intQueuePos + 1 == InstallQueue.Count && WORKING == false) EnableOptionsGameList();
            notifyIcon.ShowBalloonTip(5, "GameCube Backup Manager", message, icon);
        }

        /// <summary>
        ///     Informs if the file list is empty.
        /// </summary>
        private static void EmptyGamesList()
        {
            MessageBox.Show(Resources.EmptyGamesList, Resources.Information, MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        /// <summary>
        ///     Informs if it is necessary to select a game from the list.
        /// </summary>
        private static void SelectGameFromList()
        {
            MessageBox.Show(Resources.SelectGameFromList, Resources.Information, MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// </summary>
        private void SelectTargetDrive()
        {
            MessageBox.Show(Resources.SelectTargetDrive, Resources.Information, MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        /// <summary>
        ///     Informs about deleting files.
        ///     This procedure is irreversible.
        /// </summary>
        /// <returns></returns>
        private static DialogResult DialogResultDeleteGame()
        {
            var dr = MessageBox.Show(Resources.DialogResultDeleteGame_ReallyDeleteFile_String1 + Environment.NewLine +
                                     Environment.NewLine + Resources.DialogResultDeleteGame_ReallyDeleteFile_String2,
                Resources.Notice, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return dr;
        }

        /// <summary>
        ///     It informs you about the need to configure the USB Loader GX and WiiFlow cover transfer system.
        /// </summary>
        private static void CheckUSBGXFlow()
        {
            MessageBox.Show(Resources.CheckUSBGXFlow_String1 +
                            Environment.NewLine + Environment.NewLine +
                            Resources.CheckUSBGXFlow_String2 +
                            Environment.NewLine + Environment.NewLine +
                            Resources.CheckUSBGXFlow_String3,
                Resources.Notice, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// </summary>
        private async void CheckAndDownloadWiiTdbXml()
        {
            await ProcessTaskDelay().ConfigureAwait(false);
            if (sio.File.Exists(WIITDB_FILE))
            {
                return;
            }

            if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "NetVerify"))
            {
                if (!Monitor.TryEnter(lvDatabase))
                {
                    return;
                }

                frmDownloadGameTDB.GameTDBSynchronous();

                Monitor.Exit(lvDatabase);

                if (sio.File.Exists(WIITDB_FILE))
                {
                    LoadDatabaseXML();
                    return;
                }
            }

            CheckWiiTdbXml();
        }

        /// <summary>
        /// </summary>
        private async void CheckWiiTdbXml()
        {
            await ProcessTaskDelay().ConfigureAwait(false);
            MessageBox.Show(Resources.ProcessTaskDelay_String1 + Environment.NewLine +
                            Resources.ProcessTaskDelay_String2 +
                            Environment.NewLine + Environment.NewLine +
                            Resources.ProcessTaskDelay_String3 +
                            Environment.NewLine + Environment.NewLine +
                            Resources.ProcessTaskDelay_String4,
                Resources.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// </summary>
        /// <param name="typeDrive"></param>
        private void InvalidDrive(string typeDrive)
        {
            MessageBox.Show(Resources.InvalidDrive_String1 + Environment.NewLine +
                            Resources.InvalidDrive_String2 + typeDrive +
                            Environment.NewLine + Environment.NewLine +
                            Resources.InvalidDrive_String3 +
                            Environment.NewLine + Environment.NewLine +
                            Resources.InvalidDrive_String4 +
                            Environment.NewLine + Environment.NewLine +
                            Resources.InvalidDrive_String5 + typeDrive +
                            Resources.InvalidDrive_String6,
                Resources.Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// </summary>
        /// <param name="typehash"></param>
        /// <param name="listhash"></param>
        private void ListHash(string typehash, string listhash)
        {
            MessageBox.Show(Resources.ListHash_String1 + typehash + Resources.ListHash_String2 + Environment.NewLine +
                            Environment.NewLine
                            + listhash, Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Export HTML

        /// <summary>
        ///     Export game list to HTML.
        /// </summary>
        /// <param name="dgv"></param>
        protected string DataTableToHTML(DataTable dt)
        {
            var strHTMLBuilder = new StringBuilder();
            //strHTMLBuilder.Append("<html >");
            //strHTMLBuilder.Append("<!doctype html>");
            //strHTMLBuilder.Append("<html class=\"no-js\" lang=\"en\" dir=\"ltr\">");
            //strHTMLBuilder.Append("<head>");
            //strHTMLBuilder.Append("<meta charset=\"utf-8\">");
            //strHTMLBuilder.Append("<meta http-equiv=\"x-ua-compatible\" content=\"ie=edge\">");
            //strHTMLBuilder.Append("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            //strHTMLBuilder.Append("<title>GameCube Backups</title>");
            //strHTMLBuilder.Append("<link rel=\"stylesheet\" href=\"css/foundation.css\">");
            //strHTMLBuilder.Append("<link rel=\"stylesheet\" href=\"css/app.css\">");
            //strHTMLBuilder.Append("<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">");
            //strHTMLBuilder.Append("<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">");
            //strHTMLBuilder.Append("<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>");
            //strHTMLBuilder.Append("<link href=\"https://fonts.googleapis.com/css2?family=Raleway:wght@100&display=swap\" rel=\"stylesheet\">");
            //strHTMLBuilder.Append("<link href=\"https://fonts.googleapis.com/css2?family=Open+Sans:wght@300&display=swap\" rel=\"stylesheet\">");
            //strHTMLBuilder.Append("<style>");
            //strHTMLBuilder.Append("@font-face {");
            //strHTMLBuilder.Append("font-family: \"OpenSans\";");
            //strHTMLBuilder.Append("src: url(\"./resources/OpenSans-Light.ttf\");");
            //strHTMLBuilder.Append("}");
            //strHTMLBuilder.Append("@font-face {");
            //strHTMLBuilder.Append("font-family: \"Raleway\";");
            //strHTMLBuilder.Append("src: url(\"./resources/Raleway-Thin.ttf\");");
            //strHTMLBuilder.Append("}");
            //strHTMLBuilder.Append("</style>");
            //strHTMLBuilder.Append("<script src=\"js/sorttable.js\"></script>");
            //strHTMLBuilder.Append("</head>");
            //strHTMLBuilder.Append("<body>");
            //strHTMLBuilder.Append("<header class=\"grid-container\">");
            //strHTMLBuilder.Append("<div class=\"grid-x grid-padding-x\">");
            //strHTMLBuilder.Append("<div class=\"large-12 cell\">");
            //strHTMLBuilder.Append("<h1>GameCube Backups</h1>");
            //strHTMLBuilder.Append("</div>");
            //strHTMLBuilder.Append("</div>");
            //strHTMLBuilder.Append("</header>");
            //strHTMLBuilder.Append("<div class=\"container\">");

            strHTMLBuilder.Append(
                "<!doctype html> <html lang=\"en\" class=\"h-100\"> <head> <meta charset=\"utf-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"> <meta name=\"description\" content=\"\"> <meta name=\"author\" content=\"Mark Otto, Jacob Thornton, and Bootstrap contributors\"> <meta name=\"generator\" content=\"Hugo 0.98.0\"> <link rel=\"stylesheet\" href=\"./css/gcbm.css\" /><link rel=\"icon\" href=\"favicon.ico\" type=\"image/x-icon\" /> <title>GameCube Backups</title> <script src=\"./js/jquery.js\"></script><script src=\"./js/jquery.dataTables.min.js\"></script><script src=\"./js/bootstrap-tables.js\"></script><script>$(document).ready(function () {$('.table').DataTable();});</script> <svg xmlns =\"http://www.w3.org/2000/svg\" style=\"display: none;\"> <title>Bootstrap</title> <path fill-rule=\"evenodd\" clip-rule=\"evenodd\" d=\"M24.509 0c-6.733 0-11.715 5.893-11.492 12.284.214 6.14-.064 14.092-2.066 20.577C8.943 39.365 5.547 43.485 0 44.014v5.972c5.547.529 8.943 4.649 10.951 11.153 2.002 6.485 2.28 14.437 2.066 20.577C12.794 88.106 17.776 94 24.51 94H93.5c6.733 0 11.714-5.893 11.491-12.284-.214-6.14.064-14.092 2.066-20.577 2.009-6.504 5.396-10.624 10.943-11.153v-5.972c-5.547-.529-8.934-4.649-10.943-11.153-2.002-6.484-2.28-14.437-2.066-20.577C105.214 5.894 100.233 0 93.5 0H24.508zM80 57.863C80 66.663 73.436 72 62.543 72H44a2 2 0 01-2-2V24a2 2 0 012-2h18.437c9.083 0 15.044 4.92 15.044 12.474 0 5.302-4.01 10.049-9.119 10.88v.277C75.317 46.394 80 51.21 80 57.863zM60.521 28.34H49.948v14.934h8.905c6.884 0 10.68-2.772 10.68-7.727 0-4.643-3.264-7.207-9.012-7.207zM49.948 49.2v16.458H60.91c7.167 0 10.964-2.876 10.964-8.281 0-5.406-3.903-8.178-11.425-8.178H49.948z\"></path> </symbol> <symbol id=\"facebook\" viewBox=\"0 0 16 16\"> <path d=\"M16 8.049c0-4.446-3.582-8.05-8-8.05C3.58 0-.002 3.603-.002 8.05c0 4.017 2.926 7.347 6.75 7.951v-5.625h-2.03V8.05H6.75V6.275c0-2.017 1.195-3.131 3.022-3.131.876 0 1.791.157 1.791.157v1.98h-1.009c-.993 0-1.303.621-1.303 1.258v1.51h2.218l-.354 2.326H9.25V16c3.824-.604 6.75-3.934 6.75-7.951z\"></path> </symbol></svg><link href =\"./css/bootstrap.min.css\" rel=\"stylesheet\"><style> .bd-placeholder-img { font-size: 1.125rem; text-anchor: middle; -webkit-user-select: none; -moz-user-select: none; user-select: none; } @media(min-width: 768px) { .bd-placeholder-img-lg { font-size: 3.5rem; } } .b-example-divider { height: 3rem; background-color: rgba(0, 0, 0, .1); border: solid rgba(0, 0, 0, .15); border-width: 1px 0; box-shadow: inset 0 .5em 1.5em rgba(0, 0, 0, .1), inset 0 .125em .5em rgba(0, 0, 0, .15); } .b-example-vr { flex-shrink: 0; width: 1.5rem; height: 100vh; } .bi { vertical-align: -.125em; fill: currentColor; } .nav-scroller { position: relative; z-index: 2; height: 2.75rem; overflow-y: hidden; } .nav-scroller.nav { display: flex; flex-wrap: nowrap; padding-bottom: 1rem; margin-top: -1px; overflow-x: auto; text-align: center; white-space: nowrap; -webkit-overflow-scrolling: touch; } .bd-placeholder-img { font-size: 1.125rem; text-anchor: middle; -webkit-user-select: none; -moz-user-select: none; user-select: none; }            @media(min-width: 768px) { .bd-placeholder-img-lg { font-size: 3.5rem; } } .b-example-divider { height: 3rem; background-color: rgba(0, 0, 0, .1); border: solid rgba(0, 0, 0, .15); border-width: 1px 0; box-shadow: inset 0 .5em 1.5em rgba(0, 0, 0, .1), inset 0 .125em .5em rgba(0, 0, 0, .15); } .odd{background:#e2e3e5;} .b-example-vr { flex-shrink: 0; width: 1.5rem; height: 100vh; } .bi { vertical-align: -.125em; fill: currentColor; } .nav-scroller { position: relative; z-index: 2; height: 2.75rem; overflow-y: hidden; } .nav-scroller.nav { display: flex; flex-wrap: nowrap; padding-bottom: 1rem; margin-top: -1px; overflow-x: auto; text-align: center; white-space: nowrap; -webkit-overflow-scrolling: touch; }  .bg-dark {background-color: #4d6082 !important; } .copy { color: white!important; }# gh { margin-top: -3px; } footer { padding-left: 2em; padding-right: 2em; } </style > <link href =\"sticky-footer-navbar.css\" rel=\"stylesheet\"> </head> <body class=\"d-flex flex-column h-100\"> <header> <!-- Fixed navbar --> <nav class=\"navbar navbar-expand-md navbar-dark fixed-top bg-dark\"> <div class=\"container-fluid\"> <img src=\"./img/GC-Logo.png\" alt=\"\" style=\"height: 42px; width: 42px; padding: .25em;\"> <a class=\"navbar-brand\" href=\"https://axiondrak.github.io/gcbm.html\">GameCube Backup Manager</a> <button class=\"navbar-toggler\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#navbarCollapse\" aria-controls=\"navbarCollapse\" aria-expanded=\"false\" aria-label=\"Toggle navigation\"> <span class=\"navbar-toggler-icon\"></span> </button> <div class=\"collapse navbar-collapse\" id=\"navbarCollapse\"> <ul class=\"navbar-nav me-auto mb-2 mb-md-0\"> <li class=\"nav-item\"> <a class=\"nav-link active\" aria-current=\"page\" href=\"#\">Home</a> </li> <li class=\"nav-item\"> <a class=\"nav-link\" href=\"#\">Stats</a> </li> <li class=\"nav-item\"> <a class=\"nav-link\">Help</a> </li> </ul> </div> </div> </nav> </header> <!-- Begin page content --> <main class=\"flex-shrink-0\"> <div class=\"container\"> <h1 class=\"mt-5\">GameCube Backups</h1> <p class=\"lead\">My collection of games.</p> </div> </main> ");
            strHTMLBuilder.Append("<div class=\"container-fluid\"><table class=\"table\">");
            strHTMLBuilder.Append("<thead >");

            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<th scope=\"col\">");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</th>");
            }

            strHTMLBuilder.Append("</thead>");

            var i = 0;
            foreach (DataRow myRow in dt.Rows)
            {
                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName]);
                    strHTMLBuilder.Append("</td>");
                }

                strHTMLBuilder.Append("</tr>");
                i++;
            }
            //Close tags.

            strHTMLBuilder.Append(
                " </tbody></table></div><footer class=\"bg-dark d-flex flex-wrap justify-content-between align-items-center py-3 my-4 border-top\"> <div class=\"col-md-4 d-flex align-items-center\"> <a href=\"https://axiondrak.github.io/\" class=\"mb-3 me-2 mb-md-0 text-muted text-decoration-none lh-1\"> <img src=\"./img/Brazil.png\" style=\"opacity:55%;\"> </a> <span class=\"copy mb-3 mb-md-0 text-muted\">Copyright © 2019-2022 Laete Meireles</span> </div> <ul class=\"nav col-md-4 justify-content-end list-unstyled d-flex\"> <li class=\"ms-3\"> <a class=\"text-muted\" href=\"https://gbatemp.net/threads/gamecube-backup-manager-official-post.611247/\"> <svg xmlns=\"http://www.w3.org/2000/svg\" height=\"24px\" width=\"24px\" viewBox=\"0 0 118.06 113.06\"> <style> .st1 { fill: #ff9600 } .st2 { fill: #fff } </style> <g id=\"tempy_x5F_by_x5F_shaunj66\"> <path d=\"M98.19 6c.57 0 13.87.03 13.87 2.42l-3.08 2.85-3.07 2.83a81.372 81.372 0 00-15.5 21.7c9.34-3.12 14.76-4.62 16.54-4.62.03 8.91-5.11 16.7-7.3 20.02-.61.92-1.04 1.58-.98 1.69l4.18-.23 3.86-.23c.03 2.52-2.68 8.8-5.77 13.46 1.17 2.3 1.79 5.02 1.79 7.83 0 7.83-4.8 14.2-10.71 14.2-.76 0-1.52-.11-2.26-.32C83.7 99.41 70 107.05 54.9 107.05c-15.28 0-29.04-7.76-35.05-19.78-.99.44-2.06.65-3.15.65-5.89 0-10.7-6.37-10.7-14.19 0-4.71 1.75-9.1 4.69-11.75C7.25 52.93 6 42.01 6 36.88l3.19 2.1 6.29 4.25c-.04-10.4 4.26-25.79 12.23-33.77l.52 1.9c.72 6.33 1.84 12.38 3.34 18.01C50.03 14.51 78.2 7.51 96.7 6.03c.23-.02.76-.03 1.49-.03m0-6c-1.32 0-1.8.04-1.96.05-16.97 1.36-41.76 7.2-60.77 19.21-.51-2.78-.93-5.64-1.26-8.57a5.7 5.7 0 00-.17-.9l-.52-1.9a6 6 0 00-5.79-4.42c-1.57 0-3.11.62-4.25 1.76-6.72 6.73-11.09 17.5-12.95 27.44l-1.21-.8a5.986 5.986 0 00-6.14-.27A5.966 5.966 0 000 36.88C0 41.17.85 51.1 3.9 60.7 1.42 64.3 0 68.92 0 73.73c0 11.14 7.5 20.2 16.71 20.2h.09c7.84 11.75 22.3 19.13 38.12 19.13 15.8 0 30.31-7.41 38.12-19.17 8.75-.63 15.71-9.43 15.71-20.16 0-2.51-.38-4.97-1.1-7.26 2.47-4.32 5.12-10.23 5.08-14.09a6.009 6.009 0 00-3.64-5.45c2.06-4.28 3.9-9.72 3.88-15.76a5.994 5.994 0 00-6-5.98c-.7 0-1.63.08-3.15.39 1.93-2.5 4.02-4.89 6.27-7.15l2.98-2.75 3.08-2.86a6.025 6.025 0 001.92-4.4c0-1.63-.64-5.59-6.52-7.18-1.47-.4-3.32-.69-5.66-.9-3.65-.33-7.3-.34-7.7-.34z\" fill=\"#f2f2f2\" id=\"head_1_\" /> <g id=\"buttons\"><path class=\"st1\" d=\"M73.01 87.68c-2.81 0-5.1-2.28-5.1-5.09s2.29-5.09 5.1-5.09 5.1 2.29 5.1 5.09-2.28 5.09-5.1 5.09zm7.67-7.66c-2.81 0-5.1-2.29-5.1-5.09 0-2.81 2.29-5.09 5.1-5.09 2.81 0 5.1 2.29 5.1 5.09 0 2.81-2.29 5.09-5.1 5.09zm-15.33 0c-2.81 0-5.1-2.29-5.1-5.09 0-2.81 2.29-5.09 5.1-5.09s5.1 2.29 5.1 5.09c0 2.81-2.29 5.09-5.1 5.09zm7.77-7.76c-2.81 0-5.1-2.29-5.1-5.09 0-2.81 2.29-5.09 5.1-5.09s5.1 2.29 5.1 5.09c0 2.81-2.29 5.09-5.1 5.09z\" /><path class=\"st2\" d=\"M73.12 63.57a3.596 3.596 0 110 7.19 3.596 3.596 0 110-7.19m7.56 7.76a3.596 3.596 0 110 7.19 3.596 3.596 0 110-7.19m-15.33 0a3.596 3.596 0 110 7.19 3.596 3.596 0 110-7.19m7.66 7.66a3.59 3.59 0 110 7.18c-1.99 0-3.6-1.61-3.6-3.59 0-1.98 1.62-3.59 3.6-3.59m.11-18.42c-3.64 0-6.6 2.96-6.6 6.59 0 .44.04.88.13 1.3-.42-.08-.86-.13-1.3-.13-3.64 0-6.6 2.96-6.6 6.59 0 3.64 2.96 6.6 6.6 6.6.4 0 .79-.04 1.17-.1-.07.38-.1.77-.1 1.17 0 3.64 2.96 6.59 6.6 6.59 3.64 0 6.6-2.96 6.6-6.59 0-.4-.04-.79-.1-1.17.38.07.77.1 1.17.1 3.64 0 6.6-2.96 6.6-6.6 0-3.64-2.96-6.59-6.6-6.59-.37 0-.73.03-1.09.09.08-.41.12-.83.12-1.26 0-3.63-2.96-6.59-6.6-6.59zM71.84 76.1c.07-.38.1-.77.1-1.17 0-.44-.04-.88-.13-1.29.42.08.86.13 1.3.13.37 0 .73-.03 1.08-.09-.08.41-.12.83-.12 1.25 0 .4.04.79.1 1.17-.38-.07-.77-.1-1.17-.1-.39-.01-.78.03-1.16.1z\" /></g> <g id=\"dpad\"><path class=\"st1\" d=\"M36.83 87.69c-1.79 0-3.25-1.59-3.25-3.55v-4.07H29.3c-1.96 0-3.55-1.46-3.55-3.25v-3.33c0-1.79 1.59-3.25 3.55-3.25h4.28v-4.27c0-1.96 1.46-3.55 3.25-3.55h3.33c1.79 0 3.25 1.59 3.25 3.55v4.27h4.08c1.96 0 3.56 1.46 3.56 3.25v3.33c0 1.79-1.6 3.25-3.56 3.25h-4.08v4.07c0 1.96-1.46 3.55-3.25 3.55h-3.33z\" /><path class=\"st2\" d=\"M40.16 63.92c.97 0 1.75.92 1.75 2.05v5.77h5.58c1.14 0 2.06.79 2.06 1.75v3.33c0 .97-.92 1.75-2.06 1.75h-5.58v5.57c0 1.13-.78 2.05-1.75 2.05h-3.33c-.97 0-1.75-.92-1.75-2.05v-5.57H29.3c-1.13 0-2.05-.78-2.05-1.75v-3.33c0-.96.92-1.75 2.05-1.75h5.78v-5.77c0-1.13.78-2.05 1.75-2.05h3.33m0-3h-3.33c-2.62 0-4.75 2.27-4.75 5.05v2.77H29.3c-2.78 0-5.05 2.13-5.05 4.75v3.33c0 2.62 2.27 4.75 5.05 4.75h2.78v2.57c0 2.78 2.13 5.05 4.75 5.05h3.33c2.62 0 4.75-2.27 4.75-5.05v-2.57h2.58c2.79 0 5.06-2.13 5.06-4.75v-3.33c0-2.62-2.27-4.75-5.06-4.75h-2.58v-2.77c0-2.79-2.13-5.05-4.75-5.05z\" /></g> </g> </svg> </a> </li> <li class=\"ms-3\"> <a class=\"text-muted\" href=\"https://github.com/AxionDrak\"> <svg id=\"gh\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 256 250\" version=\"1.1\" preserveAspectRatio=\"xMidYMid\"> <g id=\"github\"> <path d=\"M128.00106,0 C57.3172926,0 0,57.3066942 0,128.00106 C0,184.555281 36.6761997,232.535542 87.534937,249.460899 C93.9320223,250.645779 96.280588,246.684165 96.280588,243.303333 C96.280588,240.251045 96.1618878,230.167899 96.106777,219.472176 C60.4967585,227.215235 52.9826207,204.369712 52.9826207,204.369712 C47.1599584,189.574598 38.770408,185.640538 38.770408,185.640538 C27.1568785,177.696113 39.6458206,177.859325 39.6458206,177.859325 C52.4993419,178.762293 59.267365,191.04987 59.267365,191.04987 C70.6837675,210.618423 89.2115753,204.961093 96.5158685,201.690482 C97.6647155,193.417512 100.981959,187.77078 104.642583,184.574357 C76.211799,181.33766 46.324819,170.362144 46.324819,121.315702 C46.324819,107.340889 51.3250588,95.9223682 59.5132437,86.9583937 C58.1842268,83.7344152 53.8029229,70.715562 60.7532354,53.0843636 C60.7532354,53.0843636 71.5019501,49.6441813 95.9626412,66.2049595 C106.172967,63.368876 117.123047,61.9465949 128.00106,61.8978432 C138.879073,61.9465949 149.837632,63.368876 160.067033,66.2049595 C184.49805,49.6441813 195.231926,53.0843636 195.231926,53.0843636 C202.199197,70.715562 197.815773,83.7344152 196.486756,86.9583937 C204.694018,95.9223682 209.660343,107.340889 209.660343,121.315702 C209.660343,170.478725 179.716133,181.303747 151.213281,184.472614 C155.80443,188.444828 159.895342,196.234518 159.895342,208.176593 C159.895342,225.303317 159.746968,239.087361 159.746968,243.303333 C159.746968,246.709601 162.05102,250.70089 168.53925,249.443941 C219.370432,232.499507 256,184.536204 256,128.00106 C256,57.3066942 198.691187,0 128.00106,0 Z M47.9405593,182.340212 C47.6586465,182.976105 46.6581745,183.166873 45.7467277,182.730227 C44.8183235,182.312656 44.2968914,181.445722 44.5978808,180.80771 C44.8734344,180.152739 45.876026,179.97045 46.8023103,180.409216 C47.7328342,180.826786 48.2627451,181.702199 47.9405593,182.340212 Z M54.2367892,187.958254 C53.6263318,188.524199 52.4329723,188.261363 51.6232682,187.366874 C50.7860088,186.474504 50.6291553,185.281144 51.2480912,184.70672 C51.8776254,184.140775 53.0349512,184.405731 53.8743302,185.298101 C54.7115892,186.201069 54.8748019,187.38595 54.2367892,187.958254 Z M58.5562413,195.146347 C57.7719732,195.691096 56.4895886,195.180261 55.6968417,194.042013 C54.9125733,192.903764 54.9125733,191.538713 55.713799,190.991845 C56.5086651,190.444977 57.7719732,190.936735 58.5753181,192.066505 C59.3574669,193.22383 59.3574669,194.58888 58.5562413,195.146347 Z M65.8613592,203.471174 C65.1597571,204.244846 63.6654083,204.03712 62.5716717,202.981538 C61.4524999,201.94927 61.1409122,200.484596 61.8446341,199.710926 C62.5547146,198.935137 64.0575422,199.15346 65.1597571,200.200564 C66.2704506,201.230712 66.6095936,202.705984 65.8613592,203.471174 Z M75.3025151,206.281542 C74.9930474,207.284134 73.553809,207.739857 72.1039724,207.313809 C70.6562556,206.875043 69.7087748,205.700761 70.0012857,204.687571 C70.302275,203.678621 71.7478721,203.20382 73.2083069,203.659543 C74.6539041,204.09619 75.6035048,205.261994 75.3025151,206.281542 Z M86.046947,207.473627 C86.0829806,208.529209 84.8535871,209.404622 83.3316829,209.4237 C81.8013,209.457614 80.563428,208.603398 80.5464708,207.564772 C80.5464708,206.498591 81.7483088,205.631657 83.2786917,205.606221 C84.8005962,205.576546 86.046947,206.424403 86.046947,207.473627 Z M96.6021471,207.069023 C96.7844366,208.099171 95.7267341,209.156872 94.215428,209.438785 C92.7295577,209.710099 91.3539086,209.074206 91.1652603,208.052538 C90.9808515,206.996955 92.0576306,205.939253 93.5413813,205.66582 C95.054807,205.402984 96.4092596,206.021919 96.6021471,207.069023 Z\" fill=\"#fff\" /> </g> </svg> </a> </li> <li class=\"ms-3\"> <a class=\"text-muted\" href=\"https://www.facebook.com/groups/nintendowiibrasil/\"> <svg width=\"24\" height=\"24\"> <style> #facebook { fill: #fff; } </style> <use xlink:href=\"#facebook\"></use> </svg> </a> </li></ul> </footer> <script src=\"./js/bootstrap.bundle.min.js\"></script> </body> </html> ");
            //strHTMLBuilder.Append("</table>");
            //strHTMLBuilder.Append("<script src=\"js/vendor/jquery.js\"></script>");
            //strHTMLBuilder.Append("<script src=\"js/vendor/what - input.js\"></script>");
            //strHTMLBuilder.Append("<script src=\"js/vendor/foundation.js\"></script>");
            //strHTMLBuilder.Append("<script src=\"js/app.js\"></script>");
            //strHTMLBuilder.Append("</body>");
            //strHTMLBuilder.Append("</body><footer><span>&copy;2022 Sean Johnson</span></footer>");
            //strHTMLBuilder.Append("</html>");
            var Htmltext = strHTMLBuilder.ToString();
            return Htmltext;
        }

        public void ExportHTML(DataTable dt)
        {
            try
            {
                var ThisFolder = new sio.FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
                var caminho = sio.Path.Combine(ThisFolder, "media\\Web\\index.html");
                var r = new sio.StreamWriter(caminho, false);
                r.Write(DataTableToHTML(dt));
                r.Close();
                tbLog.Text += "\n HTML exported sucessfully at: \n" + caminho + "\n";
                MessageBox.Show("File has been saved at: " + caminho, "Sucess!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR! Please post report this to Github or GBATemp.\n" + ex.Message, "ERROR!");
                tbLog.AppendText("[" + DateTime.Now.ToString("hh:mm:ss tt") + "] HTML Export error" + Environment.NewLine + ex.Message + Environment.NewLine);
                tbLog.AppendText(ex.StackTrace);
            }
        }

        //Font fonte = dgv.ColumnHeadersDefaultCellStyle.Font;
        //int tabSize = 0;
        //foreach (DataGridViewColumn col in dgv.Columns)
        //    if (col.Visible) tabSize += col.Width;

        ////string[] conteudo = new string[dgv.Columns.Count];

        //r.WriteLine("<html><head>");
        //r.WriteLine("<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />");
        //r.WriteLine("<title>" + dgv.Name + "</title>");
        //r.WriteLine("</head><body>");
        //r.WriteLine("<div style='position:static'>");
        //r.WriteLine("<table style='border-collapse: collapse; width:" + tabSize.ToString() + "px'>");
        //r.WriteLine("<tr>");

        //foreach (DataGridViewColumn coluna in dgv.Columns)
        //{
        //    if (coluna.Visible)
        //    {
        //        r.WriteLine("<td style='padding: 2px 2px 2px 2px; font-weight:bold; font-size:"
        //            + Convert.ToInt32(fonte.Size + 3).ToString()
        //            + "px; border-collapse: collapse; ' align='"
        //            + coluna.InheritedStyle.Alignment.ToString().Substring(6,
        //                coluna.InheritedStyle.Alignment.ToString().Length - 6)
        //            + "' width='" + coluna.Width + "'>");
        //        r.WriteLine("<font face='" + fonte.Name + "'>");
        //        r.WriteLine(coluna.HeaderText.ToString());
        //        r.WriteLine("</font>");
        //        r.WriteLine("</td>");
        //    }
        //}
        //r.WriteLine("</tr>");
        //if (dgv.Rows.Count > 0)
        //{
        //    foreach (DataGridViewRow linha in dgv.Rows)
        //    {
        //        r.WriteLine("<tr>");
        //        foreach (DataGridViewCell celula in linha.Cells)
        //        {
        //            if (celula.Visible)
        //            {
        //                r.WriteLine("<td style='padding: 2px 2px 2px 2px; font-size:"
        //                    + Convert.ToInt32(fonte.Size + 3).ToString()
        //                    + "; border-collapse: collapse; ' align='"
        //                    + celula.InheritedStyle.Alignment.ToString().Substring(6,
        //                        celula.InheritedStyle.Alignment.ToString().Length - 6)
        //                    + "' width='" + celula.Size.Width + "'>");
        //                r.Write("<font face='" + fonte.Name + "'>"
        //                    + celula.FormattedValue.ToString() + "</font>");
        //                r.WriteLine("</td>");
        //            }
        //        }
        //        r.WriteLine("</tr>");
        //    }
        //}
        //r.WriteLine("</table></div></body></html>");
        //r.Close();

        //    //Process p = new Process();
        //    //p.StartInfo = new ProcessStartInfo(caminho);
        //    //p.StartInfo.UseShellExecute = true;
        //    //p.Start();
        //}

        #endregion

        #region Export CSV

        /// <summary>
        ///     Export game list to CSV.
        /// </summary>
        //private void ExportCSV(DataGridView dgv)
        //{
        //    if (dgvSource.Rows.Count > 0)
        //    {
        //        SaveFileDialog sfd = new SaveFileDialog();
        //        sfd.Filter = "CSV (*.csv)|*.csv";
        //        sfd.FileName = "gamelist.csv";
        //        bool fileError = false;
        //        if (sfd.ShowDialog() == DialogResult.OK)
        //        {
        //            if (File.Exists(sfd.FileName))
        //            {
        //                try
        //                {
        //                    File.Delete(sfd.FileName);
        //                }
        //                catch (IOException ex)
        //                {
        //                    fileError = true;
        //                    GlobalNotifications(GCBM.Properties.Resources.UnableWriteDataDisk + " " + ex.Message, ToolTipIcon.Error);
        //                }
        //            }
        //            if (!fileError)
        //            {
        //                try
        //                {
        //                    int columnCount = dgv.Columns.Count;
        //                    string columnNames = "";
        //                    string[] outputCsv = new string[dgv.Rows.Count + 1];
        //                    for (int i = 0; i < columnCount; i++)
        //                    {
        //                        columnNames += dgv.Columns[i].HeaderText.ToString() + ",";
        //                    }
        //                    outputCsv[0] += columnNames;

        //                    for (int i = 1; (i - 1) < dgv.Rows.Count; i++)
        //                    {
        //                        for (int j = 1; j < columnCount; j++)
        //                        {
        //                            outputCsv[i] += dgv.Rows[i - 1].Cells[j].Value.ToString() + ",";
        //                        }
        //                    }

        //                    File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
        //                    GlobalNotifications(GCBM.Properties.Resources.GameListExportedCSV, ToolTipIcon.Info);

        //                }
        //                catch (Exception ex)
        //                {
        //                    tbLog.AppendText("[" + DateString() + "]" + GCBM.Properties.Resources.Error + ex.Message + Environment.NewLine);
        //                    tbLog.AppendText(ex.StackTrace);
        //                    GlobalNotifications(ex.Message, ToolTipIcon.Error);
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        GlobalNotifications(GCBM.Properties.Resources.RecordExportedFailed, ToolTipIcon.Error);
        //    }
        //}

        #endregion

        // Tool Strip Menu Item

        #region TSMI

        #region tsmiDeleteSelectedFile_Click

        private void tsmiDeleteSelectedFile_Click(object sender, EventArgs e)
        {
            //DeleteSelectedGame(0);
            GlobalDeleteSelectedGame(dgvSource);
        }

        #endregion

        #region tsmiGameListDeleteAllFiles_Click

        private async Task TsmiGameListDeleteAllFiles_ClickAsync(object sender, EventArgs e)
        {
            //DeleteAllGames(0);
            await GlobalDeleteAllGames(dgvSource).ConfigureAwait(false);
        }

        #endregion

        #region tsmiReloadGameList_Click

        private void tsmiReloadGameList_Click(object sender, EventArgs e)
        {
            //UpdateGameList(fbd1.SelectedPath, dgvSource);
            DisplayFilesSelected(fbd1.SelectedPath, dgvSource);
        }

        #endregion

        #region tsmiEnableCoverPanel_Click

        private void tsmiEnableCoverPanel_Click(object sender, EventArgs e)
        {
            if (!tsmiEnableCoverPanel.Checked)
            {
                tsmiEnableCoverPanel.Checked = true;
                tsmiDisableCoverPanel.Checked = false;
                spcMain.Panel1Collapsed = false;
            }
        }

        #endregion

        #region tsmiDisableCoverPanel_Click

        private void tsmiDisableCoverPanel_Click(object sender, EventArgs e)
        {
            if (!tsmiDisableCoverPanel.Checked)
            {
                tsmiEnableCoverPanel.Checked = false;
                tsmiDisableCoverPanel.Checked = true;
                spcMain.Panel1Collapsed = true;
            }
        }

        #endregion

        #region tsmiExportLog_Click

        private void tsmiExportLog_Click(object sender, EventArgs e)
        {
            ExportLOG(0);
        }

        #endregion

        #region tsmiDownloadCoversSelectedGame_Click

        private void tsmiDownloadCoversSelectedGame_Click(object sender, EventArgs e)
        {
            if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "NetVerify"))
                DownloadOnlyDisc3DCoverSelectedGame(dgvSource);
            else
                GlobalNotifications(Resources.NoInternetConnectionFound_String1 + Environment.NewLine +
                                    Resources.NoInternetConnectionFound_String2, ToolTipIcon.Info);
        }

        #endregion

        #region tsmiSyncDownloadDiscOnly3DCovers_Click

        private void tsmiSyncDownloadDiscOnly3DCovers_Click(object sender, EventArgs e)
        {
            if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "NetVerify"))
                DownloadOnlyDisc3DCover(dgvSource);
            else
                GlobalNotifications(Resources.NoInternetConnectionFound_String1 + Environment.NewLine +
                                    Resources.NoInternetConnectionFound_String2, ToolTipIcon.Info);
        }

        #endregion

        #region tsmiExit_Click

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            if (notifyIcon != null)
            {
                notifyIcon.Visible = false;
                notifyIcon.Icon = null;
                notifyIcon.Dispose();
            }

            ClearTemp();
            Application.Exit();
        }

        #endregion

        #region tsmiDeleteSelectedFileDisc_Click

        private void tsmiDeleteSelectedFileDisc_Click(object sender, EventArgs e)
        {
            //DeleteSelectedGame(1);
            GlobalDeleteSelectedGame(dgvDestination);
        }

        #endregion

        #region tsmiDatabaseUpdateGameTDB_Click

        private void tsmiDatabaseUpdateGameTDB_Click(object sender, EventArgs e)
        {
            if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "NetVerify"))
            {
                if (!Monitor.TryEnter(lvDatabase))
                {
                    return;
                }

                using (var form = new frmDownloadGameTDB())
                {
                    var _returnRename = form.ShowDialog();
                    Monitor.Exit(lvDatabase);
                    if (_returnRename == DialogResult.OK)
                    {
                        var _code = form.RETURN_CONFIRM;
                        if (_code == 1)
                            if (sio.File.Exists(WIITDB_FILE))
                                LoadDatabaseXML();
                    }
                }
            }
            else
                GlobalNotifications(Resources.NoInternetConnectionFound_String1 + Environment.NewLine +
                                    Resources.NoInternetConnectionFound_String2, ToolTipIcon.Info);
        }

        #endregion

        #region tsmiClearLog_Click

        private void tsmiClearLog_Click(object sender, EventArgs e)
        {
            if (tbLog.Text != string.Empty)
            {
                var dr = MessageBox.Show(Resources.ClearLog, Resources.Notice,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dr == DialogResult.Yes)
                {
                    tbLog.Clear();
                    tabMainLog.Text = "Log";
                }
            }
            else
            {
                MessageBox.Show(Resources.ClearLogNotFound, Resources.Notice,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region tsmiMenuAbout_Click

        private void tsmiMenuAbout_Click(object sender, EventArgs e)
        {
            var _frmAbout = new frmAboutBox();
            _frmAbout.ShowDialog();
            _frmAbout.Dispose();
        }

        #endregion

        #region tsmiGameInfo_Click

        private void tsmiGameInfo_Click(object sender, EventArgs e)
        {
            AdditionalInformation();
        }

        #endregion

        #region tsmiConfigurationMain_Click

        private void tsmiConfigurationMain_Click(object sender, EventArgs e)
        {
            using (var form = new frmConfig())
            {
                var _returnRename = form.ShowDialog();
                if (_returnRename == DialogResult.OK)
                {
                    var _code = form.RETURN_CONFIRM;
                    if (_code == 1) NetworkCheck();
                }
            }
        }

        #endregion

        #region tsmiTransferDeviceCovers_Click

        private void tsmiTransferDeviceCovers_Click(object sender, EventArgs e)
        {
            CheckCoverTransfer();
        }

        #endregion

        #region tsmiReloadDeviceDrive_Click

        /// <summary>
        ///     Reloads devices connected to the computer and clears the DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiReloadDeviceDrive_Click(object sender, EventArgs e)
        {
            GetAllDrives();
            dgvDestination.DataSource = null;
        }

        #endregion

        #region tsmiReloadGameListDisc_Click

        private void tsmiReloadGameListDisc_Click(object sender, EventArgs e)
        {
            DisplayFilesSelected(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar, dgvDestination);
        }

        #endregion

        #region tsmiRenameISO_Click

        private void tsmiRenameISO_Click(object sender, EventArgs e)
        {
            var _selectedGameRowCount = dgvSource.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (dgvSource.RowCount == 0)
            {
                EmptyGamesList();
            }
            else
            {
                if (_selectedGameRowCount == 0)
                {
                    SelectGameFromList();
                }
                else
                {
                    var pathImage = dgvSource.CurrentRow.Cells["Path"].Value.ToString();

                    using (var form = new frmRenameISO(fbd1.SelectedPath, pathImage))
                    {
                        var _returnRename = form.ShowDialog();
                        if (_returnRename == DialogResult.OK)
                        {
                            var _code = form.RETURN_CONFIRM;
                            if (_code == 1) DisplayFilesSelected(fbd1.SelectedPath, dgvSource);
                        }
                    }
                }
            }
        }

        #endregion

        #region tsmiNotifyExit_Click

        private void tsmiNotifyExit_Click(object sender, EventArgs e)
        {
            ClearTemp();
            Application.Exit();
        }

        #endregion

        #region tsmiGameDiscDeleteAllFiles_Click

        private void tsmiGameDiscDeleteAllFiles_Click(object sender, EventArgs e)
        {
            GlobalDeleteAllGames(dgvDestination);
        }

        #endregion

        #region tsmiExportTXT_Click

        private void tsmiExportTXT_Click(object sender, EventArgs e)
        {
            ExportTXT(dgvSource);
        }

        #endregion

        #region tsmiExportHTML_Click

        private void tsmiExportHTML_Click(object sender, EventArgs e)
        {
            ExportHTML(GameDataTable(dgvGameListPath));
        }

        #endregion

        #region tsmiExportCSV_Click

        private void tsmiExportCSV_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                //setup here

                if (dialog.ShowDialog() ==
                    DialogResult.OK) //check for OK...they might press cancel, so don't do anything if they did.
                {
                    var path = dialog.SelectedPath + sio.Path.DirectorySeparatorChar + "games.csv";
                    GameDataTable(dgvGameListPath).ToCSV(path);
                }
            }
        }

        #endregion

        #region tsmiGameSelectAll_Click

        /// <summary>
        ///     Selects all files listed in the DataGridView Game List.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiGameSelectAll_Click(object sender, EventArgs e)
        {
            dgvSource.EndEdit();

            foreach (DataGridViewRow dtr in dgvSelected.Rows) ((DataGridViewCheckBoxCell)dtr.Cells[0]).Value = true;
        }

        #endregion

        #region tsmiGameSelectNone_Click

        /// <summary>
        ///     Deselects all files listed in the DataGridView Game List.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiGameSelectNone_Click(object sender, EventArgs e)
        {
            dgvSource.EndEdit();

            foreach (DataGridViewRow dtr in dgvSelected.Rows) ((DataGridViewCheckBoxCell)dtr.Cells[0]).Value = false;
        }

        #endregion

        #region tsmiGameHashSHA1_Click

        /// <summary>
        ///     Checks the SHA-1 Hash of the selected file in the DataGridView Game List.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiGameHashSHA1_Click(object sender, EventArgs e)
        {
            GlobalCheckHash(dgvSource, "SHA-1");
        }

        #endregion

        #region tsmiGameDiscHashSHA1_Click

        /// <summary>
        ///     Checks the SHA-1 Hash of the selected file in the DataGridView Disc List.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiGameDiscHashSHA1_Click(object sender, EventArgs e)
        {
            GlobalCheckHash(dgvDestination, "SHA-1");
        }

        #endregion

        #region tsmiGameDiscHashMD5_Click

        /// <summary>
        ///     Checks the MD5 Hash of the selected file in the DataGridView Disc List.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiGameDiscHashMD5_Click(object sender, EventArgs e)
        {
            GlobalCheckHash(dgvDestination, "MD5");
        }

        #endregion

        #region tsmiInfoGame_Click

        private void tsmiInfoGame_Click(object sender, EventArgs e)
        {
            var _selecteGameRowCount = dgvSource.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (dgvSource.RowCount == 0)
            {
                EmptyGamesList();
            }
            else
            {
                if (_selecteGameRowCount == 0)
                {
                    SelectGameFromList();
                }
                else
                {
                    // Nome do Arquivo, Formato (Tipo), Tamanho, Local do Arquivo, ID do Jogo
                    var _frmInfo = new frmInformation(dgvSource.CurrentRow.Cells["Title"].Value.ToString(),
                        dgvSource.CurrentRow.Cells["Type"].Value.ToString(),
                        dgvSource.CurrentRow.Cells["Size"].Value.ToString(),
                        dgvSource.CurrentRow.Cells["Path"].Value.ToString(),
                        dgvSource.CurrentRow.Cells["ID"].Value.ToString());
                    _frmInfo.ShowDialog();
                    _frmInfo.Dispose();
                }
            }
        }

        #endregion

        #region tsmiMetaXml_Click

        private void tsmiMetaXml_Click(object sender, EventArgs e)
        {
            var metaXml = new frmMetaXml();
            metaXml.ShowDialog();
            metaXml.Dispose();
        }

        #endregion

        #region tsmiManageApp_Click

        private void tsmiManageApp_Click(object sender, EventArgs e)
        {
            var manageApp = new frmManageApp();
            manageApp.ShowDialog();
            manageApp.Dispose();
        }

        #endregion

        #region tsmiElfDol_Click

        private void tsmiElfDol_Click(object sender, EventArgs e)
        {
            var elfDol = new frmConvertELFtoDOL();
            elfDol.ShowDialog();
            elfDol.Dispose();
        }

        #endregion

        #region tsmiDolphinEmulator_Click

        private void tsmiDolphinEmulator_Click(object sender, EventArgs e)
        {
            int? selectedRowCount = Convert.ToInt32(dgvSource.Rows.GetRowCount(DataGridViewElementStates.Selected));

            if (dgvSource.RowCount == 0)
            {
                EmptyGamesList();
            }
            else if (selectedRowCount > 0)
            {
                if (CONFIG_INI_FILE.IniReadString("DOLPHIN", "DolphinFolder", "") == string.Empty)
                    MessageBox.Show(Resources.DolphinEmulator_Not_Found_String_1 + Environment.NewLine +
                                    Environment.NewLine +
                                    Resources.DolphinEmulator_Not_Found_String_2, Resources.MetaXml_String_ERRO,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    try
                    {
                        var VideoDX = "";
                        var AudioDSP = "";
                        var _sourceGame = dgvSource.CurrentRow.Cells["Path"].Value.ToString();

                        START_INFO.CreateNoWindow = true;
                        START_INFO.UseShellExecute = true;
                        // DOLPHIN
                        START_INFO.FileName = CONFIG_INI_FILE.IniReadString("DOLPHIN", "DolphinFolder", "");

                        if (CONFIG_INI_FILE.IniReadBool("DOLPHIN", "DolphinDX11"))
                            VideoDX = " --video_backend=D3D";
                        else if (CONFIG_INI_FILE.IniReadBool("DOLPHIN", "DolphinDX12"))
                            VideoDX = " --video_backend=D3D";
                        else
                            VideoDX = " --video_backend=OGL";

                        if (CONFIG_INI_FILE.IniReadBool("DOLPHIN", "DolphinLLE"))
                            AudioDSP = " --audio_emulation=LLE";
                        else
                            AudioDSP = " --audio_emulation=HLE";

                        START_INFO.Arguments = " --exec=" + sio.Path.DirectorySeparatorChar + _sourceGame + sio.Path.DirectorySeparatorChar + " /b " + VideoDX + AudioDSP;
                        //START_INFO.WindowStyle = ProcessWindowStyle.Hidden;
                        Process.Start(START_INFO);
                    }
                    catch (Exception ex)
                    {
                        GlobalNotifications(ex.Message, ToolTipIcon.Error);
                    }
            }
        }

        #endregion

        #region tsmiCreatePackage_Click

        private void tsmiCreatePackage_Click(object sender, EventArgs e)
        {
            var createPackage = new frmCreateAppPackage();
            createPackage.ShowDialog();
            createPackage.Dispose();
        }

        #endregion

        #region tsmiBurnMedia_Click

        private void tsmiBurnMedia_Click(object sender, EventArgs e)
        {
            var burnMedia = new frmBurnMedia();
            burnMedia.ShowDialog();
            burnMedia.Dispose();
        }

        #endregion

        #region tsmiWebsiteFacebook_Click

        private void tsmiWebsiteFacebook_Click(object sender, EventArgs e)
        {
            ExternalSite("https://www.facebook.com/groups/nintendowiibrasil/", "");
        }

        #endregion

        #region tsmiOfficialGitHub_Click

        private void tsmiOfficialGitHub_Click(object sender, EventArgs e)
        {
            ExternalSite("https://axiondrak.github.io/gcbm.html", "");
        }

        #endregion

        #region tsmiOfficialGBATemp_Click

        private void tsmiOfficialGBATemp_Click(object sender, EventArgs e)
        {
            ExternalSite("https://gbatemp.net/threads/gamecube-backup-manager-official-post.611247/", "");
        }

        #endregion

        #region tsmiVerifyUpdate_Click

        private void tsmiVerifyUpdate_Click(object sender, EventArgs e)
        {
            if (sio.File.Exists("config.ini"))
            {
                // Suporte as atualizações do canal Beta
                if (CONFIG_INI_FILE.IniReadBool("UPDATES", "UpdateBetaChannel"))
                {
                    AutoUpdater.Start(
                        "https://raw.githubusercontent.com/AxionDrak/GameCube-Backup-Manager/main/BetaChannel/AutoUpdaterBeta.xml");
                    AutoUpdater.ShowRemindLaterButton = false;
                    AutoUpdater.RunUpdateAsAdmin = false;
                    AutoUpdater.ReportErrors = true;
                    //AutoUpdater.UpdateFormSize = new Size(500, 400);
                }
                else
                {
                    AutoUpdater.Start(
                        "https://raw.githubusercontent.com/AxionDrak/GameCube-Backup-Manager/main/AutoUpdaterRelease.xml");
                    AutoUpdater.ShowRemindLaterButton = false;
                    AutoUpdater.RunUpdateAsAdmin = false;
                    AutoUpdater.ReportErrors = true;
                    //AutoUpdater.UpdateFormSize = new Size(500, 400);
                }
            }
            else
            {
                AutoUpdater.Start(
                    "https://raw.githubusercontent.com/AxionDrak/GameCube-Backup-Manager/main/AutoUpdaterRelease.xml");
                AutoUpdater.ShowRemindLaterButton = false;
                AutoUpdater.RunUpdateAsAdmin = false;
                AutoUpdater.ReportErrors = true;
                //AutoUpdater.UpdateFormSize = new Size(500, 400);
            }
        }

        #endregion

        #endregion

        #region Search Extras On Web

        private void tsmiSearchOnGoogle_Click(object sender, EventArgs e)
        {
            SearchOnWeb("https://www.google.com/search?q=");
        }

        private void SearchOnWikipedia_Click(object sender, EventArgs e)
        {
            SearchOnWeb("https://en.wikipedia.org/w/index.php?search=");
        }

        private void tsmiSearchOnYoutube_Click(object sender, EventArgs e)
        {
            SearchOnWeb("https://www.youtube.com/results?search_query=");
        }

        private void tsmiSearchOnVGChartz_Click(object sender, EventArgs e)
        {
            SearchOnWeb("https://www.vgchartz.com/gamedb/games.php?name=");
        }

        private void tsmiSearchOnGameSpot_Click(object sender, EventArgs e)
        {
            SearchOnWeb("https://www.gamespot.com/search/?header=1&i=site&q=");
        }

        private void tsmiSearchOnGameTDB_Click(object sender, EventArgs e)
        {
            ExternalSite("https://www.gametdb.com/Wii/", tbIDGame.Text);
        }

        #endregion

        #region pictureBox Game ID Click

        /// <summary>
        ///     Function to load websites in the default browser when clicking on a link image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbWebGameID_Click(object sender, EventArgs e)
        {
            ExternalSite("https://www.gametdb.com/Wii/", tbIDGame.Text);
        }

        private void pbWebGameDiscID_Click(object sender, EventArgs e)
        {
            ExternalSite("https://www.gametdb.com/Wii/", tbIDGameDisc.Text);
        }

        #endregion

        ///Testing stuff. The night is dark and full of terrors.

        #region SJohnson1021's Playground

        private void StartScrub()
        {
            btnAbort.Visible = true;
            lblAbort.Visible = true;
            DisableOptionsGame(dgvSource);
            BuildInstallQueue();
            foreach (var game in InstallQueue) InstallGameScrub(intQueuePos);
            GlobalNotifications("Successfully installed " + InstallQueue.Count + " games.", ToolTipIcon.Info);
            pbCopy.Hide();
            lblPercent.Hide();
            lblInstallGame.Hide();
            lblCopy.Hide();
            EnableOptionsGameList();
        }

        private void StartExact()
        {
            btnAbort.Visible = true;
            lblAbort.Visible = true;
            DisableOptionsGame(dgvSource);
            BuildInstallQueue();
            foreach (var game in InstallQueue) CheckAndCallCopyTask(InstallQueue[intQueuePos].Path);
            GlobalNotifications("Successfully installed " + InstallQueue.Count + " games.", ToolTipIcon.Info);
            pbCopy.Hide();
            lblPercent.Hide();
            lblInstallGame.Hide();
            lblCopy.Hide();
            btnAbort.Visible = false;
            EnableOptionsGameList();
        }

        #region Install Queue System

        #region Variables

        #endregion

        #region Build Install Queue

        /// <summary>
        ///     Get selected games and add them to a queue.
        /// </summary>
        private void BuildInstallQueue()
        {
            //Get # selected games - Done
            //Set QueueLength - Done
            //Reset QueuePos - Done

            //Start First Disc - done
            //On completion
            //Working = false - done
            //Q++ - done
            //Next Disc - done
            //Check if we're done
            intQueueLength = 0;
            intQueuePos = 0;
            InstallQueue.Clear();
            var num = 0;
            foreach (DataGridViewRow row in dgvSource.Rows)
            {
                if (row.Cells[0].Value.ToString() != "True") continue;
                InstallQueue.Add(num, getGameInfo(row.Cells["Path"].Value.ToString()));
                num++;
            }

            intQueueLength = lstInstallQueue.Count;
        }

        #endregion

        #region Check Install Queue and Tell CopyTask to begin

        private void CheckAndCallCopyTask(string path)
        {
            if (intQueuePos <= InstallQueue.Count - 1) //starts with 0
            {
                var _file = new sio.FileInfo(path);
                loadPath = _file.FullName;
                VerifyGame(loadPath);
                int? selectedRowCount = Convert.ToInt32(dgvSource.Rows.GetRowCount(DataGridViewElementStates.Selected));

                if (dgvSource.RowCount == 0)
                    EmptyGamesList();
                else if (selectedRowCount > 0)
                    try
                    {
                        // Removes blank spaces
                        //string ret = Regex.Replace(txtGameTitle.Text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ\s]+?", string.Empty);
                        // Removes whitespace
                        //string ret = Regex.Replace(txtGameTitle.Text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+?", string.Empty);

                        // Replaces
                        //string _SwapCharacter = tbIDName.Text.Replace(" disc1", "").Replace(" disc2", "").Replace(" 1", "").Replace(" 2", "")
                        //.Replace(" (2)", "").Replace(":", " - ").Replace(";", " - ").Replace(",", " - ")
                        //.Replace(" -  ", " - ").Replace(" FOR NINTENDO GAMECUBE", "").Replace(" GameCube", "");

                        // Nome do jogo
                        var _SwapCharacter = tbIDName.Text.Replace(":", " - ").Replace(";", " - ").Replace(",", " - ")
                            .Replace(" -  ", " - ").Replace("/", "&");

                        var _source =
                            new sio.FileInfo(sio.Path.Combine(fbd1.SelectedPath, InstallQueue[intQueuePos].Path));

                        // Disc 1 (0 -> 0) - Title [ID Game]
                        if (tbIDDiscID.Text == "0x00" && CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 0)
                        {
                            sio.Directory.CreateDirectory(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                          _SwapCharacter + " [" + _IDMakerCode + "]");
                            var _destination = new sio.FileInfo(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                                _SwapCharacter + " [" + InstallQueue[intQueuePos].ID +
                                                                "]" + sio.Path.DirectorySeparatorChar + "game.iso");
                            CopyTask(_source, _destination);
                        } // Disc 2 (1 -> 0) - Title [ID Game]
                        else if (tbIDDiscID.Text == "0x01" &&
                                 CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 0)
                        {
                            sio.Directory.CreateDirectory(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                          _SwapCharacter + " [" + InstallQueue[intQueuePos].ID + "]");
                            var _destination = new sio.FileInfo(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                                _SwapCharacter + " [" + InstallQueue[intQueuePos].ID +
                                                                "]" + sio.Path.DirectorySeparatorChar + "disc2.iso");
                            CopyTask(_source, _destination);
                        } // Disc 1 (0 -> 1) - [ID Game]
                        else if (tbIDDiscID.Text == "0x00" &&
                                 CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 1)
                        {
                            sio.Directory.CreateDirectory(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + "[" +
                                                          InstallQueue[intQueuePos].ID + "]");
                            var _destination = new sio.FileInfo(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + "[" +
                                                                InstallQueue[intQueuePos].ID + "]" + sio.Path.DirectorySeparatorChar + "game.iso");
                            CopyTask(_source, _destination);
                        } // Disc 2 (1 -> 1) - [ID Game]
                        else if (tbIDDiscID.Text == "0x01" &&
                                 CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 1)
                        {
                            sio.Directory.CreateDirectory(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + "[" +
                                                          InstallQueue[intQueuePos].ID + "]");
                            var _destination = new sio.FileInfo(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + "[" +
                                                                InstallQueue[intQueuePos].ID + "]" + sio.Path.DirectorySeparatorChar +
                                                                "disc2.iso");
                            CopyTask(_source, _destination);
                        }

                        // Título [Código do Jogo] -> 0
                        // [Código do Jogo]        -> 1
                    }
                    catch (Exception ex)
                    {
                        tbLog.AppendText("[" + DateString() + "]" + Resources.Error + ex.Message + Environment.NewLine);
                        tbLog.AppendText(ex.StackTrace);
                        GlobalNotifications(ex.Message, ToolTipIcon.Error);
                    }
            }
            else
            {
                GlobalNotifications("Successfully installed " + InstallQueue.Count + " games.", ToolTipIcon.Info);
                EnableOptionsGameList();
            }
        }

        #endregion

        #region Copy Task

        /// <summary>
        ///     Function for the copy job.
        /// </summary>
        /// <param name="_source"></param>
        /// <param name="_destination"></param>
        private void SimplifiedCopyTask(sio.FileInfo _source, sio.FileInfo _destination)
        {
            // Disc 1
            //if (textBoxDiscID.Text == "00" && comboBoxSettingsNomenclatureAppointmentStyle.SelectedIndex  == 0)

            if (tbIDDiscID.Text == "0x00")
            {
                if (_destination.Exists) _destination.Delete();
                //Create a task to run copy file
                Run(() =>
                {
                    //_source.CopyTo(_destination, true);
                    _source.CopyTo(_destination, x => pbCopy.BeginInvoke(new Action(() =>
                    {
                        //Update Progress
                    })));
                }).GetAwaiter().OnCompleted(() => pbCopy.BeginInvoke(new Action(() =>
                {
                    //Finished
                })));
            }
            // Disc 2
            else if (tbIDDiscID.Text == "0x01")
            {
                if (_destination.Exists) _destination.Delete();
                //Create a task to run copy file
                Run(() =>
                {
                    _source.CopyTo(_destination, x => pbCopy.BeginInvoke(new Action(() =>
                    {
                        //Update Progress
                    })));
                }).GetAwaiter().OnCompleted(() => pbCopy.BeginInvoke(new Action(() =>
                {
                    //Finished
                })));
            }

            if (intQueuePos + 1 == InstallQueue.Count && !WORKING)
            {
                GlobalNotifications("Finished!", ToolTipIcon.Info);
                EnableOptionsGameList();
            }
        }

        #endregion

        #region GCIT clone Scrub functionality

        #region isGCITRunning

        /// <summary />
        /// <returns></returns>
        public static bool isGCITRunning()
        {
            var procs = Process.GetCurrentProcess().GetChildProcesses();

            if (procs != null)
                if (procs.Count != 0)
                    foreach (var proc in procs)
                        if (proc.ProcessName.Contains("gcit"))
                            return true;
            return false;
        }

        #endregion

        #region Install Game Scrub

        /// <summary>
        ///     Function to install an copy of the file in Scrub mode.
        /// </summary>
        public void SimplifiedScrub(string path)
        {
            const string quote = "\"";
            START_INFO.CreateNoWindow = true;
            START_INFO.UseShellExecute = true;
            // GCIT
            START_INFO.FileName = GET_CURRENT_PATH + sio.Path.DirectorySeparatorChar + "bin" + sio.Path.DirectorySeparatorChar + "gcit.exe ";


            var boolCaseSwitch = CONFIG_INI_FILE.IniReadBool("TRANSFERSYSTEM", "ScrubFlushSD");
            var intCaseSwitch = CONFIG_INI_FILE.IniReadInt("TRANSFERSYSTEM", "ScrubAlign");

            switch (boolCaseSwitch)
            {
                case true:
                    FLUSH_SD = " - flush";
                    break;
                case false:
                    FLUSH_SD = "";
                    break;
            }

            switch (intCaseSwitch)
            {
                case 0:
                    SCRUB_ALIGN = "";
                    break;
                case 1:
                    SCRUB_ALIGN = " -a 4";
                    break;
                case 2:
                    SCRUB_ALIGN = " -a 32";
                    break;
                default:
                    SCRUB_ALIGN = " -a 32K";
                    break;
            }

            START_INFO.Arguments = quote + path + quote + " -aq " + SCRUB_ALIGN + FLUSH_SD + " -f " +
                                   CONFIG_INI_FILE.IniReadString("TRANSFERSYSTEM", "ScrubFormat", "") + " -d " +
                                   tscbDiscDrive.SelectedItem + GAMES_DIR;
            START_INFO.WindowStyle = ProcessWindowStyle.Hidden;

            using (var myProcess = Process.Start(START_INFO))
            {
                var i = 0;
                // Display the process statistics until
                // the user closes the program.
                do
                {
                    if (!myProcess.HasExited)
                    {
                        // Refresh the current process property values.
                        myProcess.Refresh();
                        // Display current process statistics.
                        tbLog.AppendText($"{myProcess} -");
                        //toolStripStatusLabel3.Text = $"{myProcess} -";
                        tbLog.AppendText(Environment.NewLine + "-------------------------------------" +
                                         Environment.NewLine + Environment.NewLine);

                        if (myProcess.Responding)
                        {
                            //HideLabels
                            //Disable Controls
                            //Update Progress
                        }
                    }
                    //progressBar1.Value += 5;
                } while (!myProcess.WaitForExit(500));


                var _StatusExit = myProcess.ExitCode;
                if (_StatusExit == 0)
                {
                    //Exit Successfully
                    //Enable Controls
                    //Tell them we're done

                    if (tbIDDiscID.Text == "0x00") //We installed disc 1
                    {
                    }

                    if (tbIDDiscID.Text == "0x01") //We installed disc 2
                    {
                        // Usar nome intermo - Use Internal Name
                        if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameInternalName"))
                        {
                            // Renomear - Rename game.iso -> disc2.iso
                            var myOrigem = tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + tbIDName.Text + " [" +
                                           tbIDGame.Text + "2]" + sio.Path.DirectorySeparatorChar + "game.iso";
                            var myDestiny = tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                            tbIDName.Text.Replace("disc2 ", "") + " [" + tbIDGame.Text + "2]" +
                                            sio.Path.DirectorySeparatorChar + "disc2.iso";


                            sio.File.Move(myOrigem, myDestiny);

                            //GlobalNotifications(Resources.InstallGameScrub_String6, ToolTipIcon.Info);
                            //We moved the file

                            //GC.Collect();
                        }
                        // Usar WiiTDB.xml
                        else
                        {
                            // Renomear game.iso -> disc2.iso
                            var myOrigem = tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + _oldNameInternal + " [" +
                                           tbIDGame.Text + "2]" + sio.Path.DirectorySeparatorChar + "game.iso";
                            var myDestiny = tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                            _oldNameInternal.Replace("disc2 ", "") + " [" + tbIDGame.Text + "2]" +
                                            sio.Path.DirectorySeparatorChar + "disc2.iso";

                            //MessageBox.Show("MYORIGEM: " + Environment.NewLine
                            //    + myOrigem +
                            //    "\n\nMYDESTINY: " + Environment.NewLine
                            //    + myDestiny, "DISC2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /*
                            * MYORIGEM:     c:\games\resident evil 4 disc2 (2) [G4BE082]\game.iso
                            * MYDESTINY:    c:\games\resident evil 4 disc2 (2) [G4BE082]\disc2.iso
                            * MYNEWDESTINY: c:\games\resident evil 4 [G4BE08]\
                            */

                            sio.File.Move(myOrigem, myDestiny);

                            //GlobalNotifications(Resources.InstallGameScrub_String6, ToolTipIcon.Info);
                            //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lblCopy.Visible = false;
                            lblInstallGame.Visible = false;
                            lblPercent.Visible = false;
                            pbCopy.Visible = false;
                            //GC.Collect();
                        }
                    }
                } //done
                //if (_StatusExit == 3)
                //{
                //    //tsslStatusInformation.Text = "Status: ERRO! -> " + "{" + _StatusExit.ToString() + "}" + " Por favor, verifique se exitem espaços no nome do arquivo!";
                //}
            }
        }

        #endregion


        #region BatchInstall1to1 from 2.5

        // REWRITE FUNCTION - Install Game Exact Copy

        #region Build Exact Copy Install Queue

        /// <summary>
        ///     Function to install an exact copy of the file (1:1).
        /// </summary>
        private void BuildCopyQueue(DataGridView dgv)
        {
            //Get # selected games - Done
            //Set QueueLength - Done
            //Reset QueuePos - Done

            //Start First Disc - done
            //On completion
            //Working = false - done
            //Q++ - done
            //Next Disc - done
            //Check if we're done
            intQueueLength = 0;
            intQueuePos = 0;
            var num = 0;
            lstInstallQueue.Clear();
            foreach (DataGridViewRow row in dgvSource.Rows)
                if (row.Cells[0].Value.ToString() == "True")
                {
                    InstallQueue.Add(num, getGameInfo(row.Cells["Path"].Value.ToString()));
                    num++;
                }

            intQueueLength = lstInstallQueue.Count;
        }

        #endregion

        #region This part writes the file

        //InstallGameExactCopy(row);
        private void InstallGameExactCopy(string path)
        {
            btnAbort.Visible = true;
            lblAbort.Visible = true;
            if (intQueuePos <= InstallQueue.Count - 1 && !ABORT)
            {
                var _file = new sio.FileInfo(path);
                loadPath = _file.FullName;
                DirectoryOpenGameList(loadPath);
                int? selectedRowCount = Convert.ToInt32(dgvSource.Rows.GetRowCount(DataGridViewElementStates.Selected));

                if (dgvSource.RowCount == 0)
                    EmptyGamesList();
                else if (selectedRowCount > 0)
                    try
                    {
                        WORKING = true;
                        // Removes blank spaces
                        //string ret = Regex.Replace(txtGameTitle.Text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ\s]+?", string.Empty);
                        // Removes whitespace
                        //string ret = Regex.Replace(txtGameTitle.Text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+?", string.Empty);

                        // Replaces
                        //string _SwapCharacter = tbIDName.Text.Replace(" disc1", "").Replace(" disc2", "").Replace(" 1", "").Replace(" 2", "")
                        //.Replace(" (2)", "").Replace(":", " - ").Replace(";", " - ").Replace(",", " - ")
                        //.Replace(" -  ", " - ").Replace(" FOR NINTENDO GAMECUBE", "").Replace(" GameCube", "");

                        // Nome do jogo
                        var _SwapCharacter = InstallQueue[intQueuePos].Title.Replace(":", " - ").Replace(";", " - ")
                            .Replace(",", " - ").Replace(" -  ", " - ").Replace("/", "&");

                        //string strResult = "";
                        //bool firstCharacter = true;

                        //if (_SwapCharacter.Length > 0)
                        //{
                        //    for (int intCont = 0; intCont <= _SwapCharacter.Length - 1; intCont++)
                        //    {
                        //        if ((firstCharacter) && (!_SwapCharacter.Substring(intCont, 1).Equals(" ")))
                        //        {
                        //            strResult += _SwapCharacter.Substring(intCont, 1).ToUpper();
                        //            firstCharacter = false;
                        //        }
                        //        else
                        //        {
                        //            strResult += _SwapCharacter.Substring(intCont, 1).ToLower();
                        //            if (_SwapCharacter.Substring(intCont, 1).Equals(" "))
                        //            {
                        //                firstCharacter = true;
                        //            }
                        //        }
                        //    }
                        //}

                        var _source =
                            new sio.FileInfo(sio.Path.Combine(fbd1.SelectedPath, InstallQueue[intQueuePos].Path));

                        // Disc 1 (0 -> 0) - Title [ID Game]
                        if (tbIDDiscID.Text == "0x00" && CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 0)
                        {
                            sio.Directory.CreateDirectory(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                          _SwapCharacter + " [" + InstallQueue[intQueuePos].ID + "]");
                            var _destination = new sio.FileInfo(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                                _SwapCharacter + " [" + InstallQueue[intQueuePos].ID +
                                                                "]" + sio.Path.DirectorySeparatorChar + "game.iso");
                            oldCopyTask(_source, _destination);
                        } // Disc 2 (1 -> 0) - Title [ID Game]
                        else if (tbIDDiscID.Text == "0x01" &&
                                 CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 0)
                        {
                            sio.Directory.CreateDirectory(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                          _SwapCharacter + " [" + InstallQueue[intQueuePos].ID + "]");
                            var _destination = new sio.FileInfo(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                                _SwapCharacter + " [" + InstallQueue[intQueuePos].ID +
                                                                "]" + sio.Path.DirectorySeparatorChar + "disc2.iso");
                            oldCopyTask(_source, _destination);
                        } // Disc 1 (0 -> 1) - [ID Game]
                        else if (tbIDDiscID.Text == "0x00" &&
                                 CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 1)
                        {
                            sio.Directory.CreateDirectory(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + "[" +
                                                          InstallQueue[intQueuePos].ID + "]");
                            var _destination = new sio.FileInfo(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + "[" +
                                                                InstallQueue[intQueuePos].ID + "]" + sio.Path.DirectorySeparatorChar + "game.iso");
                            oldCopyTask(_source, _destination);
                        } // Disc 2 (1 -> 1) - [ID Game]
                        else if (tbIDDiscID.Text == "0x01" &&
                                 CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 1)
                        {
                            sio.Directory.CreateDirectory(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + "[" +
                                                          InstallQueue[intQueuePos].ID + "]");
                            var _destination = new sio.FileInfo(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar + "[" +
                                                                InstallQueue[intQueuePos].ID + "]" + sio.Path.DirectorySeparatorChar +
                                                                "disc2.iso");
                            oldCopyTask(_source, _destination);
                        }

                        // Título [Código do Jogo] -> 0
                        // [Código do Jogo]        -> 1
                    }
                    catch (Exception ex)
                    {
                        tbLog.AppendText("[" + DateString() + "]" + Resources.Error + ex.Message + Environment.NewLine);
                        tbLog.AppendText(ex.StackTrace);
                        GlobalNotifications(ex.Message, ToolTipIcon.Error);
                    }
            }

            if (intQueuePos + 1 != InstallQueue.Count) return;
            GlobalNotifications("Successfully installed " + InstallQueue.Count + " games.", ToolTipIcon.Info);
            btnAbort.Visible = false;
            EnableOptionsGameList();
        }

        #endregion

        #region Directory Open

        /// <summary>
        ///     Checks the consistency of the listed ISO and GCM files.
        /// </summary>
        /// <param name="path"></param>
        private void DirectoryOpenGameList(string path)
        {
            //OpenFileDialog ofd;

            //if (path.Length == 0)
            //{
            //    ofd = new OpenFileDialog() { Filter = "GameCube ISO (*.iso)|*.iso|GameCube Image File (*.gcm)|*.gcm|All files (*.*)|*.*", Title = "Open image" };
            //    if (imgPath != "")
            //        ofd.FileName = imgPath;
            //    if (ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        imgPath = ofd.FileName;
            //        path = imgPath;
            //    }
            //}

            if (path.Length == 0)
                return;

            IMAGE_PATH = path;

            if (CheckImage())
                if (ReadImageTOC())
                {
                    if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName"))
                    {
                        if (sio.File.Exists(WIITDB_FILE))
                        {
                            var root = XElement.Load(WIITDB_FILE);
                            var tests = from el in root.Elements("game")
                                where (string)el.Element("id") == tbIDGame.Text
                                select el;
                            foreach (var el in tests) tbIDName.Text = (string)el.Element("locale").Element("title");
                        }
                        else
                        {
                            CheckWiiTdbXml();
                        }
                    }

                    //miImageOpen.ToolTipText = imgPath;
                    ROOT_OPENED = false;
                }
        }

        #endregion

        #region Copy Task

        /// <summary>
        ///     Function for the copy job.
        /// </summary>
        /// <param name="_source"></param>
        /// <param name="_destination"></param>
        private void oldCopyTask(sio.FileInfo _source, sio.FileInfo _destination)
        {
            // Disc 1
            //if (textBoxDiscID.Text == "00" && comboBoxSettingsNomenclatureAppointmentStyle.SelectedIndex  == 0)
            if (tbIDDiscID.Text == "0x00")
            {
                if (_destination.Exists) _destination.Delete();
                //Create a tast to run copy file
                Run(() =>
                {
                    //_source.CopyTo(_destination, true);
                    _source.CopyTo(_destination, x => pbCopy.BeginInvoke(new Action(() =>
                    {
                        //DisableOptionsGame(dgvSource);
                        dgvSource.Enabled = false;
                        pbCopy.Visible = true;
                        lblCopy.Visible = true;
                        lblPercent.Visible = true;
                        lblInstallGame.Visible = true;
                        pbCopy.Value = x;
                        lblCopy.Text = Resources.CopyTask_String1;
                        lblInstallGame.Text = Resources.CopyTask_String2 + tbIDName.Text;
                        lblPercent.Text = x + "%";
                    })));
                }).GetAwaiter().OnCompleted(() => pbCopy.BeginInvoke(new Action(() =>
                {
                    pbCopy.Value = 100;
                    lblCopy.Text = Resources.CopyTask_String3;
                    lblInstallGame.Text = Resources.CopyTask_String4;
                    lblPercent.Text = Resources.CopyTask_String5;
                    //GlobalNotifications(Resources.InstallGameScrub_String5, ToolTipIcon.Info);

                    pbCopy.Visible = false;
                    lblCopy.Visible = false;
                    lblPercent.Visible = false;
                    lblInstallGame.Visible = false;
                    intQueuePos++;
                    WORKING = false;
                    if (intQueuePos <= InstallQueue.Count)
                    {
                        try
                        {
                            InstallGameExactCopy(InstallQueue[intQueuePos].Path);
                        }
                        catch (Exception ex)
                        {
                            tbLog.AppendText("[" + DateTime.Now + "] Error Installing: " + Environment.NewLine + ex.Message + Environment.NewLine);
                            tbLog.AppendText(ex.StackTrace);
                        }
                    }
                    else
                    {
                        EnableOptionsGameList();
                        dgvSource.Enabled = true;
                    }
                })));
            }
            // Disc 2
            else if (tbIDDiscID.Text == "0x01")
            {
                if (_destination.Exists) _destination.Delete();
                //Create a tast to run copy file
                Run(() =>
                {
                    _source.CopyTo(_destination, x => pbCopy.BeginInvoke(new Action(() =>
                    {
                        //DisableOptionsGame(dgvSource);
                        pbCopy.Visible = true;
                        lblCopy.Visible = true;
                        lblPercent.Visible = true;
                        lblInstallGame.Visible = true;
                        pbCopy.Value = x;
                        lblCopy.Text = Resources.CopyTask_String1;
                        lblInstallGame.Text = Resources.CopyTask_String2 + tbIDName.Text;
                        lblPercent.Text = x + "%";
                    })));
                }).GetAwaiter().OnCompleted(() => pbCopy.BeginInvoke(new Action(() =>
                {
                    pbCopy.Value = 100;
                    lblCopy.Text = Resources.CopyTask_String6;
                    lblInstallGame.Text = Resources.CopyTask_String4;
                    lblPercent.Text = Resources.CopyTask_String5;
                    //GlobalNotifications(Resources.InstallGameScrub_String6, ToolTipIcon.Info);
                    pbCopy.Visible = false;
                    lblCopy.Visible = false;
                    lblPercent.Visible = false;
                    lblInstallGame.Visible = false;
                    intQueuePos++;
                    WORKING = false;
                    if (intQueuePos <= InstallQueue.Count)
                    {
                        try
                        {
                            InstallGameExactCopy(InstallQueue[intQueuePos].Path);
                        }
                        catch (Exception ex)
                        {
                            tbLog.AppendText("[" + DateTime.Now + "] Error Installing: " + Environment.NewLine + ex.Message + Environment.NewLine);
                        }
                    }
                    else
                    {
                        EnableOptionsGameList();
                        dgvSource.Enabled = true;
                    }
                })));
            }
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region Wait

        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled) Application.DoEvents();
        }

        private void getProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EnableOptionsGameList();
            btnGameInstallExactCopy.Enabled = true;
            btnGameInstallScrub.Enabled = true;
        }

        private void dgvSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                /*
                 * e.ColumnIndex = 0 
                 * e.RowIndex
                 */
                if (dgvSelected != dgvSource && dgvSelected != dgvDestination)
                    dgvSelected = dgvSource; //We haven't chosen one.. but.. clicked. Set selected dgv to source
                //There's a way to do this in a single line.. but
                if (dgvSelected != null && dgvSelected.Rows[e.RowIndex].Cells[0].Value.ToString() == "False")
                {
                    if (dgvSelected != null) dgvSelected.Rows[e.RowIndex].Cells[0].Value = true;
                }
                else
                {
                    if (dgvSelected != null) dgvSelected.Rows[e.RowIndex].Cells[0].Value = false;
                }
            }
        }

        private void dgvDestination_CurrentCellChanged(object sender, EventArgs e)
        {
            ReloadDataGridViewGameList(dgvDestination);
        }

        private void dgvSource_CurrentCellChanged(object sender, EventArgs e)
        {
            ReloadDataGridViewGameList(dgvSource);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            ResetOptions();
        }

        #endregion

        #endregion
    } // frmMain Form
} // namespace GCBM