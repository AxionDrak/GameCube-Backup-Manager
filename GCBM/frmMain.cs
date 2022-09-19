#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
using Timer = System.Windows.Forms.Timer;

#endregion

namespace GCBM;

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
            return attributes.Length == 0 ? string.Empty : ((AssemblyProductAttribute)attributes[0]).Product;
        }
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


    public static frmMain frmMainInstance(ProgressBar pb, Label lbl)
    {
        return new frmMain(((s, i) =>
            {
                pb.Invoke(new Action(() => pb.Value = i));
                lbl.Invoke(new Action(() => lbl.Text = s));
            })
        );
    }

    #region Main Form Closing

    /// <summary>
    ///     Main Form Closing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
            CLOSING = true;

            ClearTemp();
            ExportLOG(1);
            if (Process.GetCurrentProcess().GetChildProcesses() != null &&
                Process.GetCurrentProcess().GetChildProcesses().Count != 0)
                foreach (var process in Process.GetCurrentProcess().GetChildProcesses())
                    //Kill GCIT and others
                    process.Kill();

            //Garbage Collector
            GC.Collect();
            //Cleanup any Threads left lying around
            Dispose();
            Process.GetCurrentProcess().Kill();
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


    //Remove the "Update Program" function if it no longer needs to exist.

    #region Update Program

    /// <summary>
    ///     Adjust program update system
    /// </summary>
    //private void UpdateProgram()
    //{
    //    if (CONFIG_INI_FILE.IniReadBool("UPDATES", "UpdateServerProxy"))
    //    {
    //        if (CONFIG_INI_FILE.IniReadString("UPDATES", "ServerProxy", "") != string.Empty &&
    //            CONFIG_INI_FILE.IniReadString("UPDATES", "UserProxy", "") != string.Empty &&
    //            CONFIG_INI_FILE.IniReadString("UPDATES", "PassProxy", "") != string.Empty)
    //        {
    //            WebProxy proxy = new WebProxy(CONFIG_INI_FILE.IniReadString("UPDATES", "ServerProxy", ""), true)
    //            {
    //                Credentials = new NetworkCredential(CONFIG_INI_FILE.IniReadString("UPDATES", "UserProxy", ""),
    //                    CONFIG_INI_FILE.IniReadString("UPDATES", "PassProxy", ""))
    //            };
    //            AutoUpdater.Proxy = proxy;
    //        }
    //    }

    //    // Enable support for updates.
    //    if (CONFIG_INI_FILE.IniReadBool("UPDATES", "UpdateVerifyStart"))
    //    {
    //        int timeInterval = 0;

    //        if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 0)
    //        {
    //            timeInterval = 10; // 5 minutes
    //        }
    //        else if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 1)
    //        {
    //            timeInterval = 20; // 10 minutes
    //        }
    //        else if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 2)
    //        {
    //            timeInterval = 30; // 15 minutes
    //        }
    //        else if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 3)
    //        {
    //            timeInterval = 60; // 30 minutes
    //        }
    //        else if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 4)
    //        {
    //            timeInterval = 120; // 1 hour
    //        }
    //        else if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 5)
    //        {
    //            timeInterval = 240; // 2 hours
    //        }
    //        else if (CONFIG_INI_FILE.IniReadInt("UPDATES", "VerificationInterval") == 6)
    //        {
    //            timeInterval = 360; // 3 hours
    //        }
    //        else
    //        {
    //            timeInterval = 480; // 4 hours
    //        }

    //        // Support Beta channel updates.
    //        if (CONFIG_INI_FILE.IniReadBool("UPDATES", "UpdateBetaChannel"))
    //        {
    //            Timer timer = new Timer
    //            {
    //                Interval = 2 * 15000 * timeInterval,
    //                SynchronizingObject = this
    //            };

    //            timer.Elapsed += delegate
    //            {
    //                AutoUpdater.Start(
    //                    "https://raw.githubusercontent.com/AxionDrak/GameCube-Backup-Manager/main/BetaChannel/AutoUpdaterBeta.xml");
    //                AutoUpdater.ShowRemindLaterButton = false;
    //                AutoUpdater.RunUpdateAsAdmin = false;
    //                AutoUpdater.ReportErrors = true;
    //                //AutoUpdater.UpdateFormSize = new Size(500, 400);
    //            };
    //            timer.Start();
    //        }
    //        else
    //        {
    //            // Support for Release (Default) channel updates.
    //            Timer timer = new Timer
    //            {
    //                Interval = 2 * 15000 * timeInterval,
    //                SynchronizingObject = this
    //            };

    //            timer.Elapsed += delegate
    //            {
    //                AutoUpdater.Start(
    //                    "https://raw.githubusercontent.com/AxionDrak/GameCube-Backup-Manager/main/AutoUpdaterRelease.xml");
    //                AutoUpdater.ShowRemindLaterButton = false;
    //                AutoUpdater.RunUpdateAsAdmin = false;
    //                AutoUpdater.ReportErrors = true;
    //                //AutoUpdater.UpdateFormSize = new Size(500, 400);
    //            };
    //            timer.Start();
    //        }
    //    }
    //}

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
            _ = SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
        else
            // Activate the screensaver.
            _ = SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
    }

    #endregion

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
    private void SetupLog()
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
            tscbDiscDrive.Enabled = false;
            tsmiReloadGameListDisc.Enabled = false;
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
        //    tabMainFile.BeginInvoke(new Action(() =>
        //    {
        // Main Menu Game
        btnGameInstallExactCopy.Invoke(() => btnGameInstallExactCopy.Enabled = true);
        btnGameInstallScrub.Invoke(() => btnGameInstallScrub.Enabled = true);
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
        dgvSource.Invoke(()=>dgvSource.Enabled = true);
        //}));
        //tabMainFile.Update();
        //tabMainDisc.Invoke(() =>
        //{
        tscbDiscDrive.Enabled = true;

        tsmiReloadDeviceDrive.Enabled = true;
        tsmiReloadGameListDisc.Enabled = true;
        //});
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
        pbCopy.Visible = false;
        pbCopy.Value = 0;
        pbSource.Visible = false;
        pbDestination.Visible = false;
        dgvSource.DataSource = null;
        dgvSource.Columns.Clear();
        dgvSource.Rows.Clear();
        dgvSource.Refresh();
        PopDgv();
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
    private async void LoadDatabaseXML()
    {
        if (!Monitor.TryEnter(lvDatabase)) return;

        if (sio.File.Exists(WIITDB_FILE))
            if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "LoadDatabase"))
                // PERFECT - DO NOT CHANGE!!!
                tabMainDatabase.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        lvDatabase.View = View.Details;
                        lvDatabase.GridLines = true;
                        lvDatabase.FullRowSelect = true;
                        _ = lvDatabase.Columns.Add(Resources.LoadDatabase_IDGameCode, 70);
                        _ = lvDatabase.Columns.Add(Resources.LoadDatabase_GameTitle, 210);
                        _ = lvDatabase.Columns.Add(Resources.LoadDatabase_Region, 70);
                        _ = lvDatabase.Columns.Add(Resources.LoadDatabase_Type, 80);
                        _ = lvDatabase.Columns.Add(Resources.LoadDatabase_Developer, 200);
                        _ = lvDatabase.Columns.Add(Resources.LoadDatabase_Editor, 200);

                        using var ds = new DataSet();
                        _ = ds.ReadXml(WIITDB_FILE);

                        foreach (DataRow dr in ds.Tables["game"].Rows)
                        {
                            var itemXml = new ListViewItem(new[]
                            {
                                dr["id"].ToString(),
                                dr["name"].ToString(),
                                dr["region"].ToString(),
                                dr["type"].ToString(),
                                dr["developer"].ToString(),
                                dr["publisher"].ToString()
                            });

                            _ = lvDatabase.Items.Add(itemXml);
                        }

                        foreach (DataRow dr in ds.Tables["WiiTDB"].Rows) lblDatabaseTotal.Text = dr["games"] + " Total";

                        ds.Dispose();
                        ds.Clear();
                    }
                    catch (Exception ex)
                    {
                        //CheckWiiTdbXml();
                        GlobalNotifications(ex.Message, ToolTipIcon.Error);
                    }
                }));

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
        {
            useXmlTitle = CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName");
            if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "WindowMaximized")) WindowState = FormWindowState.Maximized;
            CONFIG_INI_FILE.IniWriteString("GCBM", "ProgVersion", VERSION());
        }
    }

    #endregion

    #region Reload DataGridView List

    /// <summary>
    ///     Reloads the contents of the DataGridView Games List.
    /// </summary>
    private async void ReloadDataGridViewGameList(DataGridView dgv, Dictionary<int, Game> dGames)
    {
        if (SCANNING)
            return;
        if (dgv == dgvSource)
            dGames = dSourceGames;
        else
            dGames = dDestGames;
        if (dgv.RowCount == 0) return;
        try
        {
            if (dgv.CurrentRow == null) return;
            var game = new Game();
            if (dgv == dgvSource)
                game = (from g in dGames.Values
                        where dgv.CurrentRow.Cells[6].Value.ToString() == g.Path
                        select g).First();
            else
                game = (from g in dDestGames.Values
                        where g.Path == dgv.CurrentRow.Cells["Path"].Value.ToString()
                        select g).First();

            LoadCover(game.ID);
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
                tbIDNameDisc.Text = game.Title;
                tbIDGameDisc.Text = game.ID;
                tbIDRegionDisc.Text = game.Region;
                tbIDGameDisc.Text = game.DiscID;
            }

            if (dgv == dgvSource)
            {
                tbIDName.Text = game.Title;
                tbIDGame.Text = game.ID;
                tbIDRegion.Text = game.Region;
                tbIDMakerCode.Text = game.IDMakerCode;
                tbIDDiscID.Text = game.DiscID;
                lblSourceCount.Text = dgv.Rows.Count.ToString();
                if (game.DiscID == "0x00")
                {
                    lblTypeDisc.Visible = true;
                    lblTypeDisc.Text = Resources.LoadISOInfo_String1;
                }
                else
                {
                    lblTypeDisc.Visible = true;
                    lblTypeDisc.Text = Resources.LoadISOInfo_String2;
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

    #region Display Source Files List

    /// <summary>
    ///     Display Source Files
    ///     --sjohnson1021-bookmark
    /// </summary>
    /// <param name="sourceFolder"></param>
    /// <param name="dgv"></param>
    private async Task DisplaySourceFilesAsync(string sourceFolder, DataGridView dgv)
    {
        dSourceGames.Clear();
        pbSource.Value = 0;
        //Check for an empty string first, and return a completed task if it is
        if (sourceFolder != string.Empty && !string.IsNullOrEmpty(sourceFolder))
        {
            //Store the passed dgv locally to prevent errors
            var dgvSourcetemp = dgv;
            //Setup Variables
            ABORT = false;
            SCANNING = true;
            string[] filters = { "iso", "gcm" };
            var isRecursive = true;
            UseWaitCursor = true;

            //if(dgv == dgvSource)
            if (dgvSourcetemp.RowCount == 0) EnableOptionsGameList();

            //if (dgv == dgvDestination)
            //    isRecursive = true;
            //else
            //    isRecursive = false;
            var files = GetFilesFolder(sourceFolder, filters, isRecursive).Result;

            //if (dgv == dgvDestination)
            //    //tsmiReloadGameListDisc.Enabled = true;
            //    try
            //    {
            //        if (dgv.RowCount == 0) tsmiReloadGameListDisc.Enabled = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        tbLog.AppendText(ex.Message + Environment.NewLine + ex.StackTrace);
            //    }

            tsmiSelectGameList.Enabled = true;
            // Groups files in the folder by extension.
            var enumerable = files
                .Select(arq => sio.Path.GetExtension(arq).TrimStart('.').ToLower(MY_CULTURE)).GroupBy(x => x,
                    (ext, extCnt) =>
                        new { _fileExtension = ext, Counter = extCnt.Count() });

            // Scroll through the result and display the values.
            foreach (var _files in enumerable)
            {
                tbLog.AppendText("[" + DateString() + "]" + Resources.DisplayFilesSelected_Found_String1 +
                                 _files.Counter +
                                 Resources.DisplayFilesSelected_Found_String2
                                 + _files._fileExtension.ToUpper(MY_CULTURE) + Environment.NewLine);

                GlobalNotifications(Resources.DisplayFilesSelected_Found_String3 + _files.Counter +
                                    Resources.DisplayFilesSelected_Found_String2 +
                                    _files._fileExtension.ToUpper(MY_CULTURE), ToolTipIcon.Info);
            }

            //Setup Interface
            pbSource.Maximum = files.Length;
            pbSource.Visible = true;
            dgvSourcetemp.Rows.Clear();
            btnAbort.Visible = true;
            UseWaitCursor = false;

            //Loop through files
            var counter = 0;
            foreach (var file in files)
            {
                if (ABORT) break;

                var game = new Game();
                var displayTitle = "";
                game = game.GetGameInfo(file, useXmlTitle).Result;
                displayTitle = game.Title;
                if (game.DiscID == "0x01")
                    displayTitle += " (2)";
                var _f = new sio.FileInfo(file);
                var _getSize = DisplayFormatFileSize(_f.Length, CONFIG_INI_FILE.IniReadInt("GENERAL", "FileSize"));
                //Title - ID - Region - Extension - Size - Path
                _ = dgvSourcetemp.Rows.Add(false, displayTitle, game.ID, game.Region,
                    _f.Extension.Substring(1, 3).Trim().ToUpper(MY_CULTURE), _getSize, _f.FullName);
                //Update ProgressBar pbCopy, and make sure we don't go over the maximum value
                if (pbSource.Value < pbSource.Maximum)
                    pbSource.Value++;
                else
                    pbSource.Value = pbSource.Maximum;


                //Clean up Interface
                //put pbCopy back to normal
                counter++;
                lblSourceCount.Text = counter + "/" + files.Length;
                //done with loop
                tabMainFile.Update();
                dSourceGames.Add(counter, game);
                Application.DoEvents();
            }

            EnableOptionsGameList();

            ReloadDataGridViewGameList(dgvSourcetemp, dSourceGames);
        }

        SCANNING = false;
    }

    #endregion

    #region Display Destination Files List

    /// <summary>
    ///     Display Source Files
    ///     --sjohnson1021-bookmark
    /// </summary>
    /// <param name="sourceFolder"></param>
    /// <param name="dgv"></param>
    private async Task DisplayDestinationFilesAsync(string sourceFolder, DataGridView dgv)
    {
        dDestGames.Clear();
        pbDestination.Value = 0;
        //Check for an empty string first, and return if it is
        if (sourceFolder != string.Empty || sourceFolder == "" || sourceFolder == null)
        {
            //Store the passed dgv locally to prevent errors
            var dgvDestinationtemp = dgv;
            //Setup Variables
            ABORT = false;
            SCANNING = true;
            string[] filters = { "iso", "gcm" };
            var isRecursive = true;
            UseWaitCursor = true;

            var files = GetFilesFolder(sourceFolder, filters, isRecursive).Result;

            //if (dgv == dgvDestination)
            tsmiReloadGameListDisc.Enabled = true;
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
            var enumerable = files
                .Select(arq => sio.Path.GetExtension(arq).TrimStart('.').ToLower(MY_CULTURE)).GroupBy(x => x,
                    (ext, extCnt) =>
                        new { _fileExtension = ext, Counter = extCnt.Count() });

            // Scroll through the result and display the values.
            foreach (var _files in enumerable)
            {
                tbLog.AppendText("[" + DateString() + "]" + Resources.DisplayFilesSelected_Found_String1 +
                                 _files.Counter +
                                 Resources.DisplayFilesSelected_Found_String2
                                 + _files._fileExtension.ToUpper(MY_CULTURE) + Environment.NewLine);

                GlobalNotifications(Resources.DisplayFilesSelected_Found_String3 + _files.Counter +
                                    Resources.DisplayFilesSelected_Found_String2 +
                                    _files._fileExtension.ToUpper(MY_CULTURE), ToolTipIcon.Info);
            }

            //Setup Interface
            pbDestination.Maximum = files.Length;
            pbDestination.Visible = true;
            dgvDestinationtemp.Rows.Clear();
            btnAbortDestination.Visible = true;
            UseWaitCursor = false;

            //Loop through files
            var counter = 0;
            foreach (var file in files)
            {
                if (ABORT) break;

                var displayTitle = "";
                var game = new Game();
                game = game.GetGameInfo(file, useXmlTitle).Result;
                displayTitle = game.Title;
                if (game.DiscID == "0x01")
                    displayTitle += " (2)";
                var _f = new sio.FileInfo(file);
                var _getSize = DisplayFormatFileSize(_f.Length, CONFIG_INI_FILE.IniReadInt("GENERAL", "FileSize"));
                _ = dgvDestinationtemp.Rows.Add(false, displayTitle, game.ID, game.Region,
                    _f.Extension.Substring(1, 3).Trim().ToUpper(MY_CULTURE), _getSize, _f.FullName);
                dDestGames.Add(counter, game);

                //Clean up Interface
                lblDestinationCount.Text = files.Length.ToString();
                pbDestination.Value++;
                counter++;
                //done with loop
                tabMainDisc.Update(); //Force tab to redraw updated controls (progress bar, label, and grid)
                Application.DoEvents();
            }

            EnableOptionsGameList();

            ReloadDataGridViewGameList(dgvDestinationtemp, dDestGames);
        }

        SCANNING = false;
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
    private Task<string[]> GetFilesFolder(string rootFolder, string[] filters, bool isRecursive)
    {
        var filesFound = new List<string>();
        // Sets options for displaying root folder images.

        isRecursive = CONFIG_INI_FILE.IniReadBool("SEVERAL", "RecursiveMode");

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

        return FromResult(filesFound.ToArray());
    }

    #endregion

    #region Get All Drives

    /// <summary>
    ///     Gets a list of all connected drives.
    /// </summary>
    private async Task GetAllDrives(Action<string> callback)
    {
        tscbDiscDrive.Items.Clear();
        _ = tscbDiscDrive.Items.Add(Resources.GetAllDrives_Inactive);
        tscbDiscDrive.SelectedIndex = 0;
        foreach (var d in from sio.DriveInfo d in sio.DriveInfo.GetDrives() /*.AsParallel()*/
                          where d.IsReady
                          select d)
        {
            _ = tscbDiscDrive.Items.Add(d.Name);
            callback(d.Name);
        }

        callback("Finishing up");
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
        reading /= 1024;
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
        double _bytes = bytes;
        var array_fs = new string[5] { "B", "KB", "MB", "GB", "TB" };
        var num2_fs = 0;

        while (_bytes >= 1024.0 && num2_fs < array_fs.Length - 1)
        {
            num2_fs++;
            _bytes /= 1024.0;
        }

        var result = $"{_bytes:0.##} {array_fs[num2_fs]}";

        return result;
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

    #region Load Cover

    /// <summary>
    ///     Loads the respective Disk and 2D image files into the loaded ISO/GCM file.
    /// </summary>
    //private void LoadCover()
    private async void LoadCover(string _idGame)
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

        if (sio.File.Exists(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                            sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar + _idGame +
                            ".png"))
            pbGameDisc.LoadAsync(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                                 sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar + _idGame +
                                 ".png");
        else
            pbGameDisc.LoadAsync(GET_CURRENT_PATH + MEDIA_DIR + sio.Path.DirectorySeparatorChar + "disc.png");

        if (sio.File.Exists(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                            sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar + _idGame +
                            ".png"))
            pbGameCover3D.LoadAsync(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                                    sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar + _idGame +
                                    ".png");
        else
            pbGameCover3D.LoadAsync(GET_CURRENT_PATH + MEDIA_DIR + sio.Path.DirectorySeparatorChar + "3d.png");
    }

    #endregion

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
                        GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                        sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar + _IDMakerCode +
                        ".png");
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
                        GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                        sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar + _IDMakerCode +
                        ".png");
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
                        GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                        sio.Path.DirectorySeparatorChar + "disc" + sio.Path.DirectorySeparatorChar + _IDMakerCode +
                        ".png");
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
                        GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                        sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar + _IDMakerCode +
                        ".png");
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
    ///     Directories required for the correct functioning of the program. Sjohnson1021: This.. should be done with
    ///     setup.exe.
    /// </summary>
    private async Task RequiredDirectories(Action<int> callback, int progressCheckpoint)
    {
        // Temporary directory default
        if (!sio.Directory.Exists(CONFIG_INI_FILE.IniReadString("GENERAL", "TemporaryFolder", "")))
        {
            _ = sio.Directory.CreateDirectory(CONFIG_INI_FILE.IniReadString("GENERAL", "TemporaryFolder", ""));
            tbLog.AppendText("[" + DateString() + "]" + Resources.RequiredDirectories_String1 +
                             Environment.NewLine);
        }
        else
        {
            tbLog.AppendText("[" + DateString() + "]" + Resources.RequiredDirectories_String2 +
                             Environment.NewLine);
        }

        var incr = 2;
        if (progressCheckpoint > 60) incr = 1;

        // Cover Directory
        if (!sio.Directory.Exists(GET_CURRENT_PATH + COVERS_DIR))
        {
            await Run(() =>
            {
                // US - Covers Directory
                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "US" + sio.Path.DirectorySeparatorChar + "2d" +
                                                  sio.Path.DirectorySeparatorChar); // 2D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "US" + sio.Path.DirectorySeparatorChar + "3d" +
                                                  sio.Path.DirectorySeparatorChar); // 3D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "US" + sio.Path.DirectorySeparatorChar + "disc" +
                                                  sio.Path.DirectorySeparatorChar); // Disc
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "US" + sio.Path.DirectorySeparatorChar + "full" +
                                                  sio.Path.DirectorySeparatorChar); // Full
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                // JA - Covers Directory
                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "JA" + sio.Path.DirectorySeparatorChar + "2d" +
                                                  sio.Path.DirectorySeparatorChar); // 2D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "JA" + sio.Path.DirectorySeparatorChar + "3d" +
                                                  sio.Path.DirectorySeparatorChar); // 3D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "JA" + sio.Path.DirectorySeparatorChar + "disc" +
                                                  sio.Path.DirectorySeparatorChar); // Disc
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "JA" + sio.Path.DirectorySeparatorChar + "full" +
                                                  sio.Path.DirectorySeparatorChar); // Full
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                // EN - Covers Directory
                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "EN" + sio.Path.DirectorySeparatorChar + "2d" +
                                                  sio.Path.DirectorySeparatorChar); // 2D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "EN" + sio.Path.DirectorySeparatorChar + "3d" +
                                                  sio.Path.DirectorySeparatorChar); // 3D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "EN" + sio.Path.DirectorySeparatorChar + "disc" +
                                                  sio.Path.DirectorySeparatorChar); // Disc
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "EN" + sio.Path.DirectorySeparatorChar + "full" +
                                                  sio.Path.DirectorySeparatorChar); // Full
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                // DE - Covers Directory
                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "DE" + sio.Path.DirectorySeparatorChar + "2d" +
                                                  sio.Path.DirectorySeparatorChar); // 2D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "DE" + sio.Path.DirectorySeparatorChar + "3d" +
                                                  sio.Path.DirectorySeparatorChar); // 3D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "DE" + sio.Path.DirectorySeparatorChar + "disc" +
                                                  sio.Path.DirectorySeparatorChar); // Disc
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "DE" + sio.Path.DirectorySeparatorChar + "full" +
                                                  sio.Path.DirectorySeparatorChar); // Full
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                // ES - Covers Directory
                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "ES" + sio.Path.DirectorySeparatorChar + "2d" +
                                                  sio.Path.DirectorySeparatorChar); // 2D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "ES" + sio.Path.DirectorySeparatorChar + "3d" +
                                                  sio.Path.DirectorySeparatorChar); // 3D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "ES" + sio.Path.DirectorySeparatorChar + "disc" +
                                                  sio.Path.DirectorySeparatorChar); // Disc
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "ES" + sio.Path.DirectorySeparatorChar + "full" +
                                                  sio.Path.DirectorySeparatorChar); // Full
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                // IT - Covers Directory
                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "IT" + sio.Path.DirectorySeparatorChar + "2d" +
                                                  sio.Path.DirectorySeparatorChar); // 2D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "IT" + sio.Path.DirectorySeparatorChar + "3d" +
                                                  sio.Path.DirectorySeparatorChar); // 3D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "IT" + sio.Path.DirectorySeparatorChar + "disc" +
                                                  sio.Path.DirectorySeparatorChar); // Disc
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "IT" + sio.Path.DirectorySeparatorChar + "full" +
                                                  sio.Path.DirectorySeparatorChar); // Full
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                // AU - Covers Directory
                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "AU" + sio.Path.DirectorySeparatorChar + "2d" +
                                                  sio.Path.DirectorySeparatorChar); // 2D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "AU" + sio.Path.DirectorySeparatorChar + "3d" +
                                                  sio.Path.DirectorySeparatorChar); // 3D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "AU" + sio.Path.DirectorySeparatorChar + "disc" +
                                                  sio.Path.DirectorySeparatorChar); // Disc
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "AU" + sio.Path.DirectorySeparatorChar + "full" +
                                                  sio.Path.DirectorySeparatorChar); // Full
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                // NL - Covers Directory
                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "NL" + sio.Path.DirectorySeparatorChar + "2d" +
                                                  sio.Path.DirectorySeparatorChar); // 2D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "NL" + sio.Path.DirectorySeparatorChar + "3d" +
                                                  sio.Path.DirectorySeparatorChar); // 3D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "NL" + sio.Path.DirectorySeparatorChar + "disc" +
                                                  sio.Path.DirectorySeparatorChar); // Disc
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "NL" + sio.Path.DirectorySeparatorChar + "full" +
                                                  sio.Path.DirectorySeparatorChar); // Full
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                // FR - Covers Directory
                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "FR" + sio.Path.DirectorySeparatorChar + "2d" +
                                                  sio.Path.DirectorySeparatorChar); // 2D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "FR" + sio.Path.DirectorySeparatorChar + "3d" +
                                                  sio.Path.DirectorySeparatorChar); // 3D
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "FR" + sio.Path.DirectorySeparatorChar + "disc" +
                                                  sio.Path.DirectorySeparatorChar); // Disc
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));

                _ = sio.Directory.CreateDirectory(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  "FR" + sio.Path.DirectorySeparatorChar + "full" +
                                                  sio.Path.DirectorySeparatorChar); // Full
                callback(Convert.ToInt32(progressCheckpoint + incr / 2));
            }).ConfigureAwait(false);

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
            _ = Process.Start(targetLink + targetID);
        }
        catch (Win32Exception noBrowser)
        {
            if (noBrowser.ErrorCode == -2147467259) GlobalNotifications(noBrowser.Message, ToolTipIcon.Info);
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
        for (var i = 0; i < data.Length; i++) _ = sBuilder.Append(data[i].ToString("x2"));
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
    private async Task GlobalDeleteSelectedGame(DataGridView dgv)
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
                        LINK_DOMAIN = _IDRegionCode.Equals("e") ? "US" :
                            _IDRegionCode.Equals("p") ? "EN" :
                            _IDRegionCode.Equals("j") ? "JA" : "EN";

                        //GlobalNotifications(GCBM.Properties.Resources.UnknownRegion, ToolTipIcon.Info);
                        var cover2D = GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                                      sio.Path.DirectorySeparatorChar
                                      + "2d" + sio.Path.DirectorySeparatorChar + tbIDGame.Text + ".png";
                        var cover3D = GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                                      sio.Path.DirectorySeparatorChar
                                      + "3d" + sio.Path.DirectorySeparatorChar + tbIDGame.Text + ".png";
                        var coverDisc = GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                                        sio.Path.DirectorySeparatorChar
                                        + "disc" + sio.Path.DirectorySeparatorChar + tbIDGame.Text + ".png";
                        var coverFull = GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                                        sio.Path.DirectorySeparatorChar
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

                            await DisplaySourceFilesAsync(fbd1.SelectedPath, dgvSource).ConfigureAwait(false);
                        } // DELETE GAME FROM TARGET DEVICE.
                        else
                        {
                            var pasta = sio.Path.GetDirectoryName(dgv.CurrentRow.Cells["Path"].Value.ToString());
                            sio.Directory.Delete(pasta, true);
                            await DisplayDestinationFilesAsync(
                                tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar,
                                dgvDestination).ConfigureAwait(false);
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
        string[] filters = { "iso", "gcm" };

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
                        LINK_DOMAIN = _IDRegionCode.Equals("e") ? "US" :
                            _IDRegionCode.Equals("p") ? "EN" :
                            _IDRegionCode.Equals("j") ? "JA" : "EN";

                        //GlobalNotifications(GCBM.Properties.Resources.UnknownRegion, ToolTipIcon.Info);
                        var di2D = new sio.DirectoryInfo(GET_CURRENT_PATH + COVERS_DIR +
                                                         sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                                                         sio.Path.DirectorySeparatorChar + "2d" +
                                                         sio.Path.DirectorySeparatorChar);
                        var di3D = new sio.DirectoryInfo(GET_CURRENT_PATH + COVERS_DIR +
                                                         sio.Path.DirectorySeparatorChar + LINK_DOMAIN +
                                                         sio.Path.DirectorySeparatorChar + "3d" +
                                                         sio.Path.DirectorySeparatorChar);
                        var diDisc =
                            new sio.DirectoryInfo(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  LINK_DOMAIN + sio.Path.DirectorySeparatorChar + "disc" +
                                                  sio.Path.DirectorySeparatorChar);
                        var diFull =
                            new sio.DirectoryInfo(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar +
                                                  LINK_DOMAIN + sio.Path.DirectorySeparatorChar + "full" +
                                                  sio.Path.DirectorySeparatorChar);

                        var files = await GetFilesFolder(fbd1.SelectedPath, filters, false).ConfigureAwait(false);

                        // Goes through the entire file list and removes all found ISO and GCM files.
                        foreach (DataGridViewRow r in dgv.Rows) sio.File.Delete(r.Cells["Path"].Value.ToString());

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
                    //else if (dgv == dgvSource) <-- Uh.. No..?
                    else if (dgv == dgvDestination)
                    {
                        var files = await GetFilesFolder(
                            tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar, filters,
                            false).ConfigureAwait(false);

                        // Goes through the entire file list and removes all found ISO and GCM files.
                        foreach (DataGridViewRow r in dgv.Rows) sio.File.Delete(r.Cells["Path"].Value.ToString());


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

                    _ = MessageBox.Show(Resources.AllFilesSuccessfullyDeleted, Resources.Notice,
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
                {
                    using var sha1Hash = SHA1.Create();
                    var hash = GetHash(sha1Hash, source);

                    if (VerifyHash(sha1Hash, source, hash))
                        ListHash("SHA-1", hash);
                    else
                        tbLog.AppendText("[" + DateString() + "]" + Resources.HashesAreNotSame +
                                         Environment.NewLine);
                }
                else if (algorithm == "MD5")
                //MD5
                {
                    using var md5Hash = MD5.Create();
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
                _ = _frmTransfer.ShowDialog();
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
                _ = _frmTransfer.ShowDialog();
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
        var _selectedGameRowCount = dgvSelected.Rows.GetRowCount(DataGridViewElementStates.Selected);

        if (_selectedGameRowCount == 0)
        {
            SelectGameFromList();
        }
        else
        {
            if (sio.File.Exists(WIITDB_FILE))
            {
                var _frmInfo = new frmInfoAdditional(tbIDGame.Text);
                _ = _frmInfo.ShowDialog();
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
                sio.TextWriter writer =
                    new sio.StreamWriter(GET_CURRENT_PATH + sio.Path.DirectorySeparatorChar + "gamelist.txt");
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
            if (tbLog.Text != string.Empty)
                sio.File.WriteAllText(GET_CURRENT_PATH + sio.Path.DirectorySeparatorChar + "gcbm.log", tbLog.Text);
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

    #region Disc Drive Selected Index Changed

    /// <summary>
    ///     Selects the index of the changed disk drive.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void tscbDiscDrive_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedDrive = tscbDiscDrive.SelectedItem.ToString();
        if (FINISHEDLAUNCH)
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
                var d = allDrives.First(a => a.Name == tscbDiscDrive.Text);
                //foreach (DriveInfo d in allDrives)
                //{
                if (d.DriveType == sio.DriveType.Removable && d.Name == tscbDiscDrive.SelectedItem.ToString())
                {
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
                                    _ = sio.Directory.CreateDirectory(tscbDiscDrive.Text +
                                                                      sio.Path.DirectorySeparatorChar + GAMES_DIR);
                            }
                            else
                            {
                                // If the GAMES directory already exists, load the content recursively.
                                await DisplayDestinationFilesAsync(
                                        tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR,
                                        dgvDestination)
                                    .ConfigureAwait(false);
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
                                    _ = sio.Directory.CreateDirectory(tscbDiscDrive.Text +
                                                                      sio.Path.DirectorySeparatorChar + GAMES_DIR);
                            }
                            else
                            {
                                // If the GAMES directory already exists, load the content recursively.
                                await DisplayDestinationFilesAsync(
                                        tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR,
                                        dgvDestination)
                                    .ConfigureAwait(false);
                            }
                        }
                        else // FAT32 
                        {
                            if (!sio.Directory.Exists(tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR))
                            {
                                var result = MessageBox.Show(Resources.CreateGamesFolderNow,
                                    Resources.Attention, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                if (result == DialogResult.Yes)
                                    _ = sio.Directory.CreateDirectory(tscbDiscDrive.Text +
                                                                      sio.Path.DirectorySeparatorChar + GAMES_DIR);
                            }
                            else
                            {
                                // If the GAMES directory already exists, load the content recursively.
                                await DisplayDestinationFilesAsync(
                                        tscbDiscDrive.Text + sio.Path.DirectorySeparatorChar + GAMES_DIR,
                                        dgvDestination)
                                    .ConfigureAwait(false);
                            }
                        }
                        //label6.Text = "Total Size: " + d.TotalSize / (1024 * 1024) + " MB\nDrive Format: " + d.DriveFormat + " \nAvailable: " + d.AvailableFreeSpace / (1024 * 1024) + " MB\n" + d.DriveType;
                    }

                    dgvGameListDiscPath = d.RootDirectory.FullName;
                }

                wait(250);
                //}
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
                _ = MessageBox.Show(Resources.FilterDatabase_String1 + Environment.NewLine + Environment.NewLine +
                                    Resources.FilterDatabase_String2, Resources.Notice, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                foreach (ListViewItem item in lvDatabase.Items)
                    if (cbFilterDatabase.Text.ToLower() == item.SubItems[3].Text.ToLower())
                    {
                        lvDatabase.Refresh();
                        _ = lvDatabase.Focus();
                        lvDatabase.HideSelection = false;
                        item.Selected = true;
                        lvDatabase.TopItem = item;
                        break;
                    }
        }
    }

    #endregion

    // CHECK, REWRITE AND ORGANIZE!!!

    #region lvDatabase_Click

    private void lvDatabase_Click(object sender, EventArgs e)
    {
        if (lvDatabase.SelectedItems[0].Text != string.Empty)
            try
            {
                var _region = lvDatabase.SelectedItems[0].SubItems[2].Text == "NTSC-U"
                    ? "US"
                    : lvDatabase.SelectedItems[0].SubItems[2].Text == "NTSC-J"
                        ? "JA"
                        : lvDatabase.SelectedItems[0].SubItems[2].Text == "NTSC-K"
                            ? "JA"
                            : "EN";

                // Take the Disc covers from the device
                if (sio.File.Exists(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + _region +
                                    sio.Path.DirectorySeparatorChar
                                    + "disc" + sio.Path.DirectorySeparatorChar + lvDatabase.SelectedItems[0].Text +
                                    ".png"))
                {
                    pbGameDisc.LoadAsync(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + _region +
                                         sio.Path.DirectorySeparatorChar
                                         + "disc" + sio.Path.DirectorySeparatorChar + lvDatabase.SelectedItems[0].Text +
                                         ".png");
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
                        GlobalNotifications(Resources.ServerReportedDiscCoverNotFound + " " + ex.Message,
                            ToolTipIcon.Error);
                    }
                    finally
                    {
                        if (NET_RESPONSE != null) NET_RESPONSE.Close();
                    }
                }

                //Grab the device's 3D covers
                if (sio.File.Exists(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + _region +
                                    sio.Path.DirectorySeparatorChar
                                    + "3d" + sio.Path.DirectorySeparatorChar + lvDatabase.SelectedItems[0].Text +
                                    ".png"))
                {
                    pbGameCover3D.LoadAsync(GET_CURRENT_PATH + COVERS_DIR + sio.Path.DirectorySeparatorChar + _region
                                            + sio.Path.DirectorySeparatorChar + "3d" + sio.Path.DirectorySeparatorChar +
                                            lvDatabase.SelectedItems[0].Text + ".png");
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
                        GlobalNotifications(Resources.ServerReported3DCoverNotFound + " " + ex.Message,
                            ToolTipIcon.Error);
                    }
                    finally
                    {
                        if (NET_RESPONSE != null) NET_RESPONSE.Close();
                    }
                }
            }
            catch (Exception)
            {
                GlobalNotifications(Resources.ServerReportedOneCoverOrBothNotFound, ToolTipIcon.Error);
            }
    }

    #endregion

    #region tabControlMain_SelectedIndexChanged

    private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControlMain.SelectedTab == tabMainFile)
            dgvSelected = dgvSource;
        else if (tabControlMain.SelectedTab == tabMainDisc) dgvSelected = dgvDestination;
    }

    #endregion

    // Buttons

    #region Button - Install Exact Copy Game

    /// <summary>
    ///     Button to install exact copy (1:1) of the file.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnGameInstallExactCopy_Click(object sender, EventArgs e)
    {
        ABORT = false;
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
        ABORT = false;
        GlobalInstall(dgvSource, 1);
    }

    #endregion

    #region Button - Select Folder with ISO/GCM Game Files

    /// <summary>
    ///     Button to select the directory that contains the ISO/GCM files.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnSelectFolder_Click(object sender, EventArgs e)
    {
        try
        {
            fbd1.Description = Resources.SelectFolderContainingIsoGcmFiles;
            fbd1.ShowNewFolderButton = false;
            var result = fbd1.ShowDialog();
            if (result == DialogResult.OK)
            {
                dgvGameListPath = fbd1.SelectedPath;
                UseWaitCursor = true;
                await DisplaySourceFilesAsync(fbd1.SelectedPath, dgvSource).ConfigureAwait(false);
                UseWaitCursor = false;
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

    #region Button - Search grid for games matching search criteria

    /// <summary>
    ///     Button to search the grid for games matching the search criteria.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

    #endregion

    #region KeyPress - Update search criteria

    /// <summary>
    ///     Update search results live as the user types.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSearch_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter) btnSearch.PerformClick();
    }

    #endregion

    #region Button - ABORT

    /// <summary>
    ///     Button to abort the current operation, and reset the interface if Installing games..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnAbort_Click(object sender, EventArgs e)
    {
        ABORT = true;
        if (INSTALLING) ResetOptions();

        lblInstallStatusText.Text = "Stopped!";
        lblInstallStatusText.Show();
    }

    #endregion

    private void lblNetStatus_Click(object sender, EventArgs e)
    {
        NetworkCheck();
        if (sio.File.Exists(WIITDB_FILE)) return;

        var result = MessageBox.Show(Resources.ProcessTaskDelay_String1 + Environment.NewLine +
                                     Resources.ProcessTaskDelay_String2 +
                                     Environment.NewLine + Environment.NewLine +
                                     Resources.ProcessTaskDelay_String3 +
                                     Environment.NewLine + Environment.NewLine +
                                     Resources.ProcessTaskDelay_String4,
            Resources.Notice, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        if (result == DialogResult.Yes)
        {
            //download the file
            var frm = new frmDownloadGameTDB();
            frm.ShowDialog();
        }
    }

    private void tsmiClearListSource_Click(object sender, EventArgs e)
    {
        dgvSource.Rows.Clear();
    }

    private void tsmiClearListDestination_Click(object sender, EventArgs e)
    {
        dgvDestination.Rows.Clear();
    }

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

        if (path.Length == 0) return;

        IMAGE_PATH = path;

        if (CheckImage())
            if (gameUtilities.ReadImageTOC())
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

    #endregion

    private void tsmiRenameFolders_Click(object sender, EventArgs e)
    {
        //Program.AdjustLanguage(Thread.CurrentThread);
        //this.Refresh();
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

    #region Globals Properties and Variables

    public bool SCANNING;
    public bool CLOSING;
    private string _IDMakerCode;
    private string _IDRegionCode;
    public Game gameUtilities = new();
    private bool useXmlTitle;

    private static readonly string GET_CURRENT_PATH = sio.Directory.GetCurrentDirectory();
    private static readonly string GAMES_DIR = "games";
    private static readonly string TEMP_DIR = sio.Path.DirectorySeparatorChar + "temp";

    private static readonly string COVERS_DIR =
        sio.Path.DirectorySeparatorChar + "covers" + sio.Path.DirectorySeparatorChar + "cache";

    private static readonly string MEDIA_DIR =
        sio.Path.DirectorySeparatorChar + "media" + sio.Path.DirectorySeparatorChar + "covers";

    private static readonly string CULTURE_CURRENT = "pt-BR";
    private static readonly string NTFS = "NTFS";
    private static readonly string EXFAT_FAT64 = "EXFAT";

    private bool INSTALLING;
    private readonly bool FINISHEDLAUNCH;
    private static string IMAGE_PATH;
    private static string LINK_DOMAIN;
    private static string FLUSH_SD;
    private static string SCRUB_ALIGN;

    //private const string MIN_DB_VERSION          = "1.2.0.0";
    private const string INI_FILE = "config.ini";

    //private const string GLOBAL_INI_FILE         = "gc_global.ini";
    //private const string LOG_FILE                = "gcbm.log";
    //private const string CACHE_DIR               = "cache";
    //private const string LOCAL_FILES_DB          = "gcbm_Local.xml";
    private const string WIITDB_FILE = "wiitdb.xml";

    //private const string TITLES_FILE             = "titles.txt";
    //private bool ENABLE_INTERNET                 = true;
    //private bool ENABLE_UPDATE_PROGRAM           = true;
    //private bool UPDATE_LOG                      = true;
    private bool ERROR;
    private bool ROOT_OPENED = true;

    //private int Reserved;
    private readonly Assembly assembly = Assembly.GetExecutingAssembly();
    private readonly IniFile CONFIG_INI_FILE = Program.ConfigFile;
    private readonly CultureInfo MY_CULTURE = new(CULTURE_CURRENT, false);
    private readonly ProcessStartInfo START_INFO = new();
    private readonly WebClient NET_CLIENT = new();
    private HttpWebResponse NET_RESPONSE;
    private bool WORKING;
    private string dgvGameListPath;
    private string dgvGameListDiscPath;
    private int intQueueLength;
    private int intQueuePos;
    private readonly Dictionary<int, Game> dSourceGames = new();
    private readonly Dictionary<int, Game> dDestGames = new();
    private DataGridView dgvSelected = new();
    public static String SelectedDrive = ""; // Selected Drive

    [DllImport("kernel32.dll")]
    private static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

    //IMPORT USED TO HIDE GCIT's windows when launched. I know, ProccesWindows.Style Hidden .. Didn't like when i changed the way it was launched
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    #endregion

    #region Main Form

    /// <summary>
    ///     Main constructor method of the class.
    ///     No argument parameters.
    /// </summary>
    private bool ABORT;

    public frmMain(Action<string, int> callback)
    {
        Hide();

        InitializeComponent();
        //Do Work
        MainCore(callback);
        FINISHEDLAUNCH = true;
        Show();
        Activate();
    }
    // End of Main Constructor

    private void MainCore(Action<string, int> callback)
    {
        Hide();
        tbSearch.KeyPress += CheckEnterKeyPress;
        Text = "GameCube Backup Manager 2022 - " + VERSION() + " - 64-bit";

        //Splash Screen
        //if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "DisableSplash") == false)

        //    Load += HandleFormLoad;

        callback(Resources.SplashNetworkCheck, 10);
        NetworkCheck();
        if (!sio.File.Exists(INI_FILE))
        {
            Program.DefaultConfigSave();
            Program.DetectOSLanguage();

            Program.AdjustLanguage(Thread.CurrentThread);
            Controls.Clear();
            InitializeComponent();
        }

        if (!CONFIG_INI_FILE.IniReadBool("SEVERAL", "LaunchedOnce")) Program.DefaultConfigSave();

        LoadConfigFile();
        AboutTranslator();
        callback(Resources.SplashPopulatingDrives, 20);
        var progressCheckpoint = 20;
        GetAllDrives(s => callback(Resources.SplashFoundDrive + " " + s, progressCheckpoint += 5));
        //callback(Resources.SplashDirectories,progressCheckpoint);

        //DetectOSLanguage();
        //AdjustLanguage();
        //UpdateProgram();
        //LoadDatabaseXML();
        DisabeScreensaver();
        SetupLog();
        RequiredDirectories(i => callback(Resources.SplashDirectories, i),
            progressCheckpoint).ConfigureAwait(false); //Do we really need to wait on this?
        DisableOptionsGame(dgvSource);
        tscbDiscDrive.SelectedIndex = 0;
        cbFilterDatabase.SelectedIndex = 0;

        //Check for WiiTDB file and internet connection, download if not found and we're online

        callback(Resources.SplashWiiTDB, 90);
        if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "LoadDatabase"))
        {
            if (!sio.File.Exists(WIITDB_FILE) && NetworkInterface.GetIsNetworkAvailable())
            {
                //frmDownloadGameTDB frmDownload = new frmDownloadGameTDB();
                //_ = frmDownload.ShowDialog();
                Show();
                CheckAndDownloadWiiTdbXml();
            }
            else if (!sio.File.Exists(WIITDB_FILE) && !NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(Resources.NoInternetConnectionFound_String1 + Environment.NewLine +
                                Resources.NoInternetConnectionFound_String2,
                    Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LoadDatabaseXML();

        // DISABLED
        DisableOptions();

        //All done, Clean up / Refresh to ensure language and settings are updated.

        //Localization.. but not working @Laetemn

        #region dgvDestination Setup

        PopDgv();

        #endregion

        Thread.CurrentThread.CurrentUICulture.ClearCachedData();
        Thread.CurrentThread.CurrentCulture.ClearCachedData();
        callback(Resources.SplashFinishing, 95);
        //foreach in this.Controls.Results 
        mstripMain.Refresh();
        callback(Resources.SplashFinished, 100);
        var SplashScreen = Program.SplashScreen;
        if (SplashScreen != null && !SplashScreen.Disposing && !SplashScreen.IsDisposed)
            SplashScreen.Invoke(new Action(() => SplashScreen.Close()));
        wait(500);
        Show();

        Activate();
        try
        {
            LoadDatabaseXML();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Return) btnSearch.PerformClick();
    }

    private void DisableOptions()
    {
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
    }

    //Is this function not referenced?
    //How does it work? Phantom function? :P
    protected override void OnLoad(EventArgs e)
    {
        //base.OnLoad(e);
    }

    private void PopDgv()
    {
        var cb = new DataGridViewCheckBoxColumn();

        dgvSource.Columns.Clear();
        _ = dgvSource.Columns.Add(cb);
        _ = dgvSource.Columns.Add("Title", Resources.LoadDatabase_GameTitle);
        _ = dgvSource.Columns.Add("ID", Resources.LoadDatabase_IDGameCode);
        _ = dgvSource.Columns.Add("Region", Resources.LoadDatabase_Region);
        _ = dgvSource.Columns.Add("Type", Resources.LoadDatabase_Type);
        _ = dgvSource.Columns.Add("Size", Resources.DisplayFilesSelected_Size);
        _ = dgvSource.Columns.Add("Path", Resources.DisplayFilesSelected_FilePath);
        dgvSource.Refresh();

        var cbd = new DataGridViewCheckBoxColumn();
        dgvDestination.Columns.Clear();
        _ = dgvDestination.Columns.Add(cbd);
        _ = dgvDestination.Columns.Add("Title", Resources.LoadDatabase_GameTitle);
        _ = dgvDestination.Columns.Add("ID", Resources.LoadDatabase_IDGameCode);
        _ = dgvDestination.Columns.Add("Region", Resources.LoadDatabase_Region);
        _ = dgvDestination.Columns.Add("Type", Resources.LoadDatabase_Type);
        _ = dgvDestination.Columns.Add("Size", Resources.DisplayFilesSelected_Size);
        _ = dgvDestination.Columns.Add("Path", Resources.DisplayFilesSelected_FilePath);
        dgvDestination.Refresh();
    }

    #endregion

    //Remove the "Build Game list as List<Game>" function if it no longer needs to exist.

    #region Build Game list as List<Game>

    /// <summary>
    ///     Build a List<Game> with file and game info for easier access programmatically.
    /// </summary>
    //private async Task<List<Game>> GameList(string path)
    //{
    //    string[] filters = { "ISO", "GCM" };
    //    List<Game> list = new List<Game>();
    //    string[] files = await GetFilesFolder(path, filters, false).ConfigureAwait(false);

    //    foreach (string file in files)
    //    {
    //        FileInfo _file = new sio.FileInfo(file);
    //        //Title - ID - Region - Path - Extension - Size
    //        loadPath = _file.FullName;
    //        VerifyGame(loadPath);
    //        Game game = new Game(tbIDName.Text, tbIDGame.Text, tbIDRegion.Text, loadPath, _file.Extension,
    //            (int)_file.Length);
    //        //game.Title = tbIDName.Text;
    //        IMAGE_PATH = game.Path;
    //        if (CheckImage() && gameUtilities.ReadImageDiscTOC())
    //        {
    //            list.Add(game);
    //        }
    //    }

    //    return list;
    //}

    #endregion


    #endregion

    //ORGANIZE THE EXTRA FUNCTIONS SECTION
    // Extras Functions

    //Remove the "dgvSource Click" function if it no longer needs to exist.

    #region dgvSource Click

    /// <summary>
    ///     Performs an action when clicking on the DataGridView Game List.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //private void dgvSource_Click(object sender, EventArgs e)
    //{
    //    ReloadDataGridViewGameList(dgvSource);
    //}

    #endregion

    //Remove the "dgvGameListDisc_Click" function if it no longer needs to exist.

    #region dgvGameListDisc_Click

    //private void dgvGameListDisc_Click(object sender, EventArgs e)
    //{
    //    ReloadDataGridViewGameList(dgvDestination);
    //}

    #endregion

    //Remove the "Splash Ssreen" function if it no longer needs to exist.

    #region Splash Ssreen

    /// <summary>
    ///     Load the Splash Screen form.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //private void HandleFormLoad(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Hide();
    //        //Thread thread = new Thread(ShowSplashScreen);
    //        //thread.Start();
    //        //Hardworker worker = new Hardworker();
    //        //worker.ProgressChanged += (o, ex) => { SPLASH_SCREEN.UpdateProgress(ex.Progress); };
    //        //worker.HardWorkDone += (o, ex) =>
    //        //{
    //        //    SPLASH_SCREEN_DONE = true;
    //        //    Show();
    //        //    if (SPLASH_SCREEN_DONE)
    //        //    {
    //        //        Show();
    //        //        NetworkCheck();
    //        //    }
    //        //};
    //        //worker.DoHardWork(); //Is this..  ... literally just to waste time? No.
    //        //Moved to Program.cs
    //        Show();
    //    }
    //    catch (Exception ex)
    //    {
    //        // Not used.
    //        // Just to avoid mistakes.
    //        tbLog.AppendText(ex.Message + Environment.NewLine + ex.StackTrace);
    //    }

    //}

    /// <summary>
    ///     Display and close the Splash Screen form.
    /// </summary>
    //private void ShowSplashScreen()
    //{
    //    try
    //    {
    //        SPLASH_SCREEN.Show();
    //        while (!SPLASH_SCREEN_DONE)
    //        {
    //        }

    //        SPLASH_SCREEN.Close();
    //        SPLASH_SCREEN.Dispose();
    //    }
    //    catch (Exception ex)
    //    {
    //        tbLog.AppendText(ex.Message + Environment.NewLine + ex.StackTrace);
    //    }
    //}

    #endregion

    #region Transfer System


    #region Exact Copy

    #region Check Install Queue and Tell CopyTask to begin

    //private void CheckAndCallCopyTask(Game game)
    //{
    //    if (intQueuePos <= InstallQueue.Count - 1) //starts with 0
    //    {
    //        //var _file = new sio.FileInfo(game.Path);
    //        //loadPath = _file.FullName;
    //        //VerifyGame(loadPath);
    //        int? selectedRowCount = Convert.ToInt32(dgvSource.Rows.GetRowCount(DataGridViewElementStates.Selected));

    //        if (dgvSource.RowCount == 0)
    //            EmptyGamesList();
    //        else if (selectedRowCount > 0)
    //            try
    //            {
    //                // Removes blank spaces
    //                //string ret = Regex.Replace(txtGameTitle.Text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ\s]+?", string.Empty);
    //                // Removes whitespace
    //                //string ret = Regex.Replace(txtGameTitle.Text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+?", string.Empty);
    //                // Replaces
    //                //string _SwapCharacter = tbIDName.Text.Replace(" disc1", "").Replace(" disc2", "").Replace(" 1", "").Replace(" 2", "")
    //                //.Replace(" (2)", "").Replace(":", " - ").Replace(";", " - ").Replace(",", " - ")
    //                //.Replace(" -  ", " - ").Replace(" FOR NINTENDO GAMECUBE", "").Replace(" GameCube", "");
    //                // Nome do jogo
    //                var _SwapCharacter = tbIDName.Text.Replace(":", " - ").Replace(";", " - ").Replace(",", " - ")
    //                    .Replace(" -  ", " - ").Replace("/", "&");

    //                var _source =
    //                    new sio.FileInfo(sio.Path.Combine(fbd1.SelectedPath, InstallQueue[intQueuePos].Path));

    //                // Disc 1 (0 -> 0) - Title [ID Game]
    //                if (tbIDDiscID.Text == "0x00" && CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 0)
    //                {
    //                    _ = sio.Directory.CreateDirectory(strDestinationDrive + GAMES_DIR +
    //                                                      sio.Path.DirectorySeparatorChar +
    //                                                      _SwapCharacter + " [" + _IDMakerCode + "]");
    //                    var _destination = new sio.FileInfo(strDestinationDrive + GAMES_DIR +
    //                                                        sio.Path.DirectorySeparatorChar +
    //                                                        _SwapCharacter + " [" + InstallQueue[intQueuePos].ID +
    //                                                        "]" + sio.Path.DirectorySeparatorChar + "game.iso");
    //                    oldCopyTask(_source, _destination);
    //                } // Disc 2 (1 -> 0) - Title [ID Game]
    //                else if (tbIDDiscID.Text == "0x01" &&
    //                         CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 0)
    //                {
    //                    _ = sio.Directory.CreateDirectory(strDestinationDrive + GAMES_DIR +
    //                                                      sio.Path.DirectorySeparatorChar +
    //                                                      _SwapCharacter + " [" + InstallQueue[intQueuePos].ID + "]");
    //                    var _destination = new sio.FileInfo(strDestinationDrive + GAMES_DIR +
    //                                                        sio.Path.DirectorySeparatorChar +
    //                                                        _SwapCharacter + " [" + InstallQueue[intQueuePos].ID +
    //                                                        "]" + sio.Path.DirectorySeparatorChar + "disc2.iso");
    //                    oldCopyTask(_source, _destination);
    //                } // Disc 1 (0 -> 1) - [ID Game]
    //                else if (tbIDDiscID.Text == "0x00" &&
    //                         CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 1)
    //                {
    //                    _ = sio.Directory.CreateDirectory(strDestinationDrive + GAMES_DIR +
    //                                                      sio.Path.DirectorySeparatorChar + "[" +
    //                                                      InstallQueue[intQueuePos].ID + "]");
    //                    var _destination = new sio.FileInfo(strDestinationDrive + GAMES_DIR +
    //                                                        sio.Path.DirectorySeparatorChar + "[" +
    //                                                        InstallQueue[intQueuePos].ID + "]" +
    //                                                        sio.Path.DirectorySeparatorChar + "game.iso");
    //                    oldCopyTask(_source, _destination);
    //                } // Disc 2 (1 -> 1) - [ID Game]
    //                else if (tbIDDiscID.Text == "0x01" &&
    //                         CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 1)
    //                {
    //                    _ = sio.Directory.CreateDirectory(strDestinationDrive + GAMES_DIR +
    //                                                      sio.Path.DirectorySeparatorChar + "[" +
    //                                                      InstallQueue[intQueuePos].ID + "]");
    //                    var _destination = new sio.FileInfo(strDestinationDrive + GAMES_DIR +
    //                                                        sio.Path.DirectorySeparatorChar + "[" +
    //                                                        InstallQueue[intQueuePos].ID + "]" +
    //                                                        sio.Path.DirectorySeparatorChar +
    //                                                        "disc2.iso");
    //                    oldCopyTask(_source, _destination);
    //                }
    //                // Título [Código do Jogo] -> 0
    //                // [Código do Jogo]        -> 1
    //            }
    //            catch (Exception ex)
    //            {
    //                tbLog.AppendText("[" + DateString() + "]" + Resources.Error + ex.Message + Environment.NewLine);
    //                tbLog.AppendText(ex.StackTrace);
    //                GlobalNotifications(ex.Message, ToolTipIcon.Error);
    //            }
    //    }
    //    else
    //    {
    //        GlobalNotifications("Successfully installed " + InstallQueue.Count + " games.", ToolTipIcon.Info);
    //        EnableOptionsGameList();

    //    }
    //}

    #endregion

    #region This part writes the file

    //InstallGameExactCopy(row);
    private void InstallGameExactCopy(string path)
    {
        //Make sure pbCopy is Continuous
        pbCopy.Style = ProgressBarStyle.Continuous;
        btnAbort.Visible = true;
        lblAbort.Visible = true;
        if (intQueuePos <= InstallQueue.Count - 1 && !ABORT)
        {
            var _file = new sio.FileInfo(path);
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
                        if (!sio.Directory.Exists(strDestinationDrive + GAMES_DIR +
                                                  sio.Path.DirectorySeparatorChar +
                                                  _SwapCharacter + " [" + InstallQueue[intQueuePos].ID + "]"))
                            sio.Directory.CreateDirectory(strDestinationDrive + GAMES_DIR +
                                                          sio.Path.DirectorySeparatorChar +
                                                          _SwapCharacter + " [" + InstallQueue[intQueuePos].ID + "]");
                        var _destination = new sio.FileInfo(strDestinationDrive + GAMES_DIR +
                                                            sio.Path.DirectorySeparatorChar +
                                                            _SwapCharacter + " [" + InstallQueue[intQueuePos].ID +
                                                            "]" + sio.Path.DirectorySeparatorChar + "game.iso");
                        oldCopyTask(_source, _destination);
                    } // Disc 2 (1 -> 0) - Title [ID Game]
                    else if (tbIDDiscID.Text == "0x01" &&
                             CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 0)
                    {
                        if (!sio.Directory.Exists(strDestinationDrive + GAMES_DIR +
                                                  sio.Path.DirectorySeparatorChar +
                                                  _SwapCharacter + " [" + InstallQueue[intQueuePos].ID + "]"))
                            sio.Directory.CreateDirectory(strDestinationDrive + GAMES_DIR +
                                                          sio.Path.DirectorySeparatorChar +
                                                          _SwapCharacter + " [" + InstallQueue[intQueuePos].ID + "]");
                        var _destination = new sio.FileInfo(strDestinationDrive + GAMES_DIR +
                                                            sio.Path.DirectorySeparatorChar +
                                                            _SwapCharacter + " [" + InstallQueue[intQueuePos].ID +
                                                            "]" + sio.Path.DirectorySeparatorChar + "disc2.iso");
                        oldCopyTask(_source, _destination);
                    } // Disc 1 (0 -> 1) - [ID Game]
                    else if (tbIDDiscID.Text == "0x00" &&
                             CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 1)
                    {
                        if (!sio.Directory.Exists(strDestinationDrive + GAMES_DIR +
                                                  sio.Path.DirectorySeparatorChar + "[" +
                                                  InstallQueue[intQueuePos].ID + "]"))
                            sio.Directory.CreateDirectory(strDestinationDrive + GAMES_DIR +
                                                          sio.Path.DirectorySeparatorChar + "[" +
                                                          InstallQueue[intQueuePos].ID + "]");
                        var _destination = new sio.FileInfo(strDestinationDrive + GAMES_DIR +
                                                            sio.Path.DirectorySeparatorChar + "[" +
                                                            InstallQueue[intQueuePos].ID + "]" +
                                                            sio.Path.DirectorySeparatorChar + "game.iso");
                        oldCopyTask(_source, _destination);
                    } // Disc 2 (1 -> 1) - [ID Game]
                    else if (tbIDDiscID.Text == "0x01" &&
                             CONFIG_INI_FILE.IniReadInt("SEVERAL", "AppointmentStyle") == 1)
                    {
                        if (!sio.Directory.Exists(strDestinationDrive + GAMES_DIR +
                                                  sio.Path.DirectorySeparatorChar + "[" +
                                                  InstallQueue[intQueuePos].ID + "]"))
                            sio.Directory.CreateDirectory(strDestinationDrive + GAMES_DIR +
                                                          sio.Path.DirectorySeparatorChar + "[" +
                                                          InstallQueue[intQueuePos].ID + "]");
                        var _destination = new sio.FileInfo(strDestinationDrive + GAMES_DIR +
                                                            sio.Path.DirectorySeparatorChar + "[" +
                                                            InstallQueue[intQueuePos].ID + "]" +
                                                            sio.Path.DirectorySeparatorChar +
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
        else
        {
            FinishedInstalling();
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
        //Make sure pbCopy is Continuous
        pbCopy.Style = ProgressBarStyle.Continuous;
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
                    lblInstallStatusGameTitle.Visible = true;
                    lblInstallStatusPercent.Visible = true;
                    lblInstallStatusText.Visible = true;
                    if (x < pbCopy.Value)
                        pbCopy.Value = x;
                    lblInstallStatusGameTitle.Text = InstallQueue[intQueuePos].Title;
                    lblInstallStatusText.Text = Resources.CopyTask_String1;
                    lblInstallStatusPercent.Text = x + "%";
                })));
            }).GetAwaiter().OnCompleted(() => pbCopy.BeginInvoke(new Action(() =>
            {
                pbCopy.Maximum = 100;
                pbCopy.Value = 100;
                lblInstallStatusGameTitle.Text = Resources.CopyTask_String3;
                lblInstallStatusText.Text = Resources.CopyTask_String4;
                lblInstallStatusPercent.Text = Resources.CopyTask_String5;
                GlobalNotifications(Resources.InstallGameScrub_Complete, ToolTipIcon.Info);

                pbCopy.Visible = false;
                lblInstallStatusGameTitle.Visible = false;
                lblInstallStatusPercent.Visible = false;
                lblInstallStatusText.Visible = false;
                intQueuePos++;
                WORKING = false;
                EnableOptionsGameList();

                if (intQueuePos <= InstallQueue.Count - 1)
                {
                    try
                    {
                        InstallGameExactCopy(InstallQueue[intQueuePos].Path);
                    }
                    catch (Exception ex)
                    {
                        tbLog.AppendText("[" + DateTime.Now + "] Error Installing: " + Environment.NewLine +
                                         ex.Message + Environment.NewLine);
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
                    lblInstallStatusGameTitle.Visible = true;
                    lblInstallStatusPercent.Visible = true;
                    lblInstallStatusText.Visible = true;
                    pbCopy.Value = x;
                    lblInstallStatusGameTitle.Text = InstallQueue[intQueuePos].Title;
                    lblInstallStatusText.Text = Resources.CopyTask_String2;
                    lblInstallStatusPercent.Text = x + "%";
                })));
            }).GetAwaiter().OnCompleted(() => pbCopy.BeginInvoke(new Action(() =>
            {
                pbCopy.Value = 100;
                lblInstallStatusText.Text = Resources.CopyTask_String4;
                lblInstallStatusPercent.Text = Resources.CopyTask_String5;
                GlobalNotifications(Resources.InstallGameScrub_TrasnferredDisc2, ToolTipIcon.Info);
                pbCopy.Visible = false;
                lblInstallStatusGameTitle.Visible = false;
                lblInstallStatusPercent.Visible = false;
                lblInstallStatusText.Visible = false;
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
                        tbLog.AppendText("[" + DateTime.Now + "] Error Installing: " + Environment.NewLine +
                                         ex.Message + Environment.NewLine);
                    }
                }
                else
                {
                    EnableOptionsGameList();
                    dgvSource.Enabled = true;
                }
            })));
        }

        EnableOptionsGameList();
    }

    #endregion

    #endregion

    #region Scrub

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

    private async void StartScrub()
    {
        DisableOptionsGame(dgvDestination);
        btnAbort.Visible = true;
        lblAbort.Visible = true;
        intQueuePos = 0;
        DisableOptionsGame(dgvSource);
        BuildInstallQueue();
        foreach (var game in InstallQueue.Values)
            if (!ABORT)
                await InstallGameScrub(InstallQueue[intQueuePos]).ConfigureAwait(false);

        var d2counter = 0;
        foreach (var game in _listSecondDiscs)
        {
            d2counter++;
            lblInstallStatusText.Text = Resources.InstallGameScrub_TransferDisc2;
            lblInstallStatusGameTitle.Text = game.Title;
            lblInstallStatusGameIndex.Text = d2counter.ToString();
            await RenameDisc2(game).ConfigureAwait(false);
        }

        GlobalNotifications("Successfully installed " + InstallQueue.Count + " games.", ToolTipIcon.Info);
        pbCopy.BeginInvoke(() =>
        {
            pbCopy.Hide();
            lblInstallStatusPercent.Hide();
            lblInstallStatusText.Hide();
            lblInstallStatusGameTitle.Hide();
        });

        EnableOptionsGameList();
    }


    #region Install Game Scrub

    private readonly Stopwatch scrubStopwatch = new();

    /// <summary>
    ///     Function to install an copy of the file in Scrub mode.
    /// </summary>
    private async Task InstallGameScrub(Game game)
    {
        scrubStopwatch.Stop();
        scrubStopwatch.Reset();
        InstallType = "SCRUB";
        pbCopy.Style = ProgressBarStyle.Continuous;
        if (ABORT)
            return; //I know we already checked, but just in case.. one more time just to be extra careful. We are writing data after all.
        const string quote = "\"";
        var _source = game.Path;

        // GCIT

        //setup vars


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

        //START_INFO
        var myProcess = new Process();
        myProcess.StartInfo.Arguments = quote + _source + quote + " -aq " + SCRUB_ALIGN + FLUSH_SD + " -f " +
                                        CONFIG_INI_FILE.IniReadString("TRANSFERSYSTEM", "ScrubFormat", "") + " -d " +
                                        strDestinationDrive + GAMES_DIR;
        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //myProcess.StartInfo.RedirectStandardOutput = true;
        myProcess.SynchronizingObject = this;
        myProcess.EnableRaisingEvents = true;
        myProcess.StartInfo.UseShellExecute = true;
        //myProcess.StartInfo.CreateNoWindow = true;
        myProcess.StartInfo.FileName = GET_CURRENT_PATH + sio.Path.DirectorySeparatorChar
                                                        + "bin" + sio.Path.DirectorySeparatorChar + "gcit.exe ";
        /*gcit.exe proccesses/trims excess data (padding) from a file*/
        myProcess.Exited += (s, evt) =>
        {
            var _StatusExit = myProcess.ExitCode;
            if (_StatusExit == 0) //exit success
            {
                lblInstallStatusText.Visible = true;
                lblInstallStatusPercent.Visible = true;
                pbCopy.Visible = true;
                lblInstallStatusPercent.Text = "100%";
                pbCopy.Value = 100;
                lblInstallStatusText.Text = Resources.InstallGameScrub_DoneScrubbing;
                var game = InstallQueue[intQueuePos];
                CheckDisc1Or2Scrub(game).ConfigureAwait(false);

                #endregion
            }

            if (_StatusExit == 3)
            {
                //whItespace in filename.
                //lblInstallStatusGameTitle.Text = "Status: ERRO! -> " + "{" + _StatusExit.ToString() + "}"
                //               + " Por favor, verifique se exitem espaços no nome do arquivo!";
            }

            intQueuePos++;
            if (intQueuePos >= intQueueLength) return;
            scrubStopwatch.Stop();
            myProcess?.Dispose();
        };

        myProcess.Start();
        Thread.Sleep(1000);
        ShowWindow(myProcess.MainWindowHandle, 0);

        scrubStopwatch.Start();
        while (!myProcess.HasExited && !ABORT)
        {
            UpdateProgressScrub(scrubStopwatch.ElapsedMilliseconds);
            Application.DoEvents();
        }
    }


    private async Task CheckDisc1Or2Scrub(Game game)
    {
        #region Disc 1

        if (game.DiscID == "0x00")
            if (useXmlTitle)
            {
                var myOrigem = strDestinationDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                               game.InternalName +
                               " [" + game.ID + "]" +
                               sio.Path.DirectorySeparatorChar + "game.iso";

                var _SwapCharacter = game.Title.Replace(":", " - ").Replace(";", " - ").Replace(",", " - ")
                    .Replace(" -  ", " - ").Replace("/", "&");

                var myDestiny = strDestinationDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                _SwapCharacter +
                                " [" + game.ID + "]" +
                                sio.Path.DirectorySeparatorChar + "game.iso";

                //MessageBox.Show("MYORIGEM: " + Environment.NewLine
                //    + myOrigem +
                //    "\n\nMYDESTINY: " + Environment.NewLine
                //    + myDestiny, "DISC2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                /*
                        * MYORIGEM:     c:\games\resident evil 4 disc2 (2) [G4BE082]\game.iso
                        * MYDESTINY:    c:\games\resident evil 4 disc2 (2) [G4BE082]\disc2.iso
                        * MYNEWDESTINY: c:\games\resident evil 4 [G4BE08]\
                        */
                //sio.File.Move(myOrigem, myDestiny);
                var o = new sio.FileInfo(myOrigem);
                var d = new sio.FileInfo(myDestiny);
                var Source = new sio.DirectoryInfo(strDestinationDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                   game.InternalName + " [" + game.ID + "]");
                var Destination = new sio.DirectoryInfo(strDestinationDrive + GAMES_DIR +
                                                        sio.Path.DirectorySeparatorChar +
                                                        _SwapCharacter + " [" + game.ID + "]");

                await Run(() =>
                {
                    if (Destination.Exists) Destination.Delete();

                    try
                    {
                        Source.MoveTo(Destination.FullName);
                    }
                    catch (Exception ex)
                    {
                        GlobalNotifications(ex.Message, ToolTipIcon.Error);
                    }
                }).ContinueWith(task =>
                {
                    GlobalNotifications(Resources.InstallGameScrub_GameInstalled, ToolTipIcon.Info);

                    //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabMainFile.BeginInvoke(() =>
                    {
                        lblInstallStatusGameTitle.Visible = false;
                        lblInstallStatusGameIndex.Visible = false;
                        lblInstallStatusText.Visible = false;
                        lblInstallStatusPercent.Visible = false;
                        pbCopy.Visible = false;
                    });
                    //GC.Collect();
                    //Delete folder at   strDestinationDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                    //                   game.Title +
                    //                   " [" + game.ID + "2]" +
                }).ConfigureAwait(false);
            }

        #endregion

        #region Disc 2

        if (game.DiscID == "0x01") _listSecondDiscs.Add(game);

        #endregion
    }

    private async Task RenameDisc2(Game game)
    {
        // Usar nome intermo

        if (useXmlTitle)
        {
            var myOrigem = strDestinationDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                           game.InternalName +
                           " [" + game.ID + "]" +
                           sio.Path.DirectorySeparatorChar + "game.iso";

            var _SwapCharacter = game.Title.Replace(":", " - ").Replace(";", " - ").Replace(",", " - ")
                .Replace(" -  ", " - ").Replace("/", "&");

            var myDestiny = strDestinationDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                            _SwapCharacter +
                            " [" + game.ID + "]" +
                            sio.Path.DirectorySeparatorChar + "game.iso";

            //MessageBox.Show("MYORIGEM: " + Environment.NewLine
            //    + myOrigem +
            //    "\n\nMYDESTINY: " + Environment.NewLine
            //    + myDestiny, "DISC2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*
                    * MYORIGEM:     c:\games\resident evil 4 disc2 (2) [G4BE082]\game.iso
                    * MYDESTINY:    c:\games\resident evil 4 disc2 (2) [G4BE082]\disc2.iso
                    * MYNEWDESTINY: c:\games\resident evil 4 [G4BE08]\
                    */

            //sio.File.Move(myOrigem, myDestiny);
            var o = new sio.FileInfo(myOrigem);
            var d = new sio.FileInfo(myDestiny);
            var Source = new sio.DirectoryInfo(strDestinationDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                               game.InternalName + " (2) [" + game.ID + "2]");
            var Destination = new sio.DirectoryInfo(strDestinationDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                    _SwapCharacter + " [" + game.ID + "]");


            await Run(() =>
            {
                if (Destination.Exists)
                    try
                    {
                        var file = Source.EnumerateFiles("*.iso").First();
                        file.CopyTo(new sio.FileInfo(sio.Path.Combine(Destination.FullName, "disc2.iso")),
                            UpdateTransfer);
                        file.Directory.Delete(true);
                    }
                    catch (Exception ex)
                    {
                        GlobalNotifications(ex.Message, ToolTipIcon.Error);
                    }

                else
                    Source.MoveTo(Destination.FullName);
            }).ContinueWith(task =>
            {
                GlobalNotifications(Resources.InstallGameScrub_GameInstalled, ToolTipIcon.Info);

                //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabMainFile.BeginInvoke(() =>
                {
                    lblInstallStatusGameTitle.Visible = false;
                    lblInstallStatusGameIndex.Visible = false;
                    lblInstallStatusText.Visible = false;
                    lblInstallStatusPercent.Visible = false;
                    pbCopy.Visible = false;
                });

                //GC.Collect();
                //Delete folder at   strDestinationDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                //                   game.Title +
                //                   " [" + game.ID + "2]" +
            }).ConfigureAwait(false);
        }
        else
        {
            //MessageBox.Show("MYORIGEM: " + Environment.NewLine
            //    + myOrigem +
            //    "\n\nMYDESTINY: " + Environment.NewLine
            //    + myDestiny, "DISC2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*
                    * MYORIGEM:     c:\games\resident evil 4 disc2 (2) [G4BE082]\game.iso
                    * MYDESTINY:    c:\games\resident evil 4 disc2 (2) [G4BE082]\disc2.iso
                    * MYNEWDESTINY: c:\games\resident evil 4 [G4BE08]\
                    */
            var Source = new sio.DirectoryInfo(strDestinationDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                               game.InternalName + " (2) [" + game.ID + "2]");
            var Destination = new sio.DirectoryInfo(strDestinationDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                    game.InternalName + " [" + game.ID + "]");
            await Run(() =>
            {
                if (Destination.Exists)
                    try
                    {
                        var file = Source.EnumerateFiles("*.iso").First();
                        file.CopyTo(new sio.FileInfo(sio.Path.Combine(Destination.FullName, "disc2.iso")),
                            UpdateTransfer);
                        file.Directory.Delete(true);
                    }
                    catch (Exception ex)
                    {
                        GlobalNotifications(ex.Message, ToolTipIcon.Error);
                    }
                else
                    Source.MoveTo(Destination.FullName);
            }).ContinueWith(task =>
            {
                GlobalNotifications(Resources.InstallGameScrub_GameInstalled, ToolTipIcon.Info);

                //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabMainFile.BeginInvoke(() =>
                {
                    lblInstallStatusGameTitle.Visible = false;
                    lblInstallStatusGameIndex.Visible = false;
                    lblInstallStatusText.Visible = false;
                    lblInstallStatusPercent.Visible = false;
                    pbCopy.Visible = false;
                });
            }).ConfigureAwait(false);
        }
    }

    private readonly List<Game> _listSecondDiscs = new();

    private void UpdateProgressScrub(long i)
    {
        tabMainFile.BeginInvoke(() =>
        {
            //Make sure pbCopy is Continuous
            lblInstallStatusGameTitle.Visible = true;
            lblInstallStatusText.Visible = true;
            lblInstallStatusPercent.Visible = true;
            lblInstallStatusGameTitle.Text = InstallQueue[intQueuePos].Title;
            lblInstallStatusGameIndex.Text = intQueuePos + "  /  " + InstallQueue.Count;
            pbCopy.Visible = true;
            DisableOptionsGame(dgvSource);
            var incrementValue = Convert.ToInt32(i / 333);
            if (incrementValue >= 100)
            {
                pbCopy.Style = ProgressBarStyle.Marquee;
                lblInstallStatusPercent.Hide();
                lblInstallStatusText.Text = Resources.InstallGameScrub_Scrubbing +
                                            " -- This is taking a while, but we are still responding.";
                pbCopy.Value = pbCopy.Maximum;
            }
            else
            {
                pbCopy.Style = ProgressBarStyle.Continuous;
                lblInstallStatusPercent.Show();
                lblInstallStatusPercent.Text = incrementValue + "%"; //i++.ToString() + "%";
                lblInstallStatusText.Show();
                lblInstallStatusText.Text = Resources.InstallGameScrub_Scrubbing;
                pbCopy.Value = incrementValue;
            }
        });
    }

    private void UpdateProgressScrubDisc2(string title, int i)
    {
        tabMainFile.BeginInvoke(() =>
        {
            //Make sure pbCopy is Continuous
            lblInstallStatusGameIndex.Visible = true;
            lblInstallStatusGameTitle.Visible = true;
            lblInstallStatusText.Visible = true;
            lblInstallStatusPercent.Visible = true;
            lblInstallStatusGameTitle.Text = title;
            pbCopy.Visible = true;
            DisableOptionsGame(dgvSource);
            if (i >= 100)
            {
                pbCopy.Style = ProgressBarStyle.Marquee;
                lblInstallStatusPercent.Hide();
                lblInstallStatusText.Text = string.Format(Resources.InstallGameScrub_TransferDisc2, title) +
                                            " -- This is taking a while, but we are still responding.";
                pbCopy.Value = pbCopy.Maximum;
            }
            else
            {
                pbCopy.Style = ProgressBarStyle.Continuous;
                lblInstallStatusPercent.Show();
                lblInstallStatusPercent.Text = i + "%"; //i++.ToString() + "%";
                lblInstallStatusText.Show();
                lblInstallStatusText.Text = string.Format(Resources.InstallGameScrub_TransferDisc2, title);
                pbCopy.Value = i;
            }
        });
    }

    #endregion

    #endregion

    #region Copy Task

    /// <summary>
    ///     Function for the copy job.
    /// </summary>
    /// <param name="_source"></param>
    /// <param name="_destination"></param>
    //private void CopyTask(sio.FileInfo _source, sio.FileInfo _destination)
    //{
    //    // Disc 1
    //    //if (textBoxDiscID.Text == "00" && comboBoxSettingsNomenclatureAppointmentStyle.SelectedIndex  == 0)
    //    if (tbIDDiscID.Text == "0x00")
    //    {
    //        if (_destination.Exists) _destination.Delete();
    //        //Create a tast to run copy file
    //        Run(() =>
    //        {
    //            //_source.CopyTo(_destination, true);
    //            _source.CopyTo(_destination, x => pbCopy.BeginInvoke(new Action(() => UpdateProgressExact(x))));
    //        }).GetAwaiter().OnCompleted(() => pbCopy.BeginInvoke(new Action(() =>
    //        {
    //            if (intQueuePos <= intQueueLength)
    //                try
    //                {
    //                    CheckAndCallCopyTask(InstallQueue[intQueuePos]);
    //                }
    //                catch (Exception ex)
    //                {
    //                    tbLog.AppendText("[" + DateTime.Now + "] Error Installing: " + Environment.NewLine +
    //                                     ex.Message + Environment.NewLine);
    //                    tbLog.AppendText(ex.StackTrace);
    //                }
    //        })));
    //    }
    //    // Disc 2
    //    else if (tbIDDiscID.Text == "0x01")
    //    {
    //        if (_destination.Exists) _destination.Delete();
    //        //Create a tast to run copy file
    //        Run(() =>
    //        {
    //            _source.CopyTo(_destination, x => pbCopy.BeginInvoke(new Action(() => UpdateProgressExact(x))));
    //        }).GetAwaiter().OnCompleted(() => pbCopy.BeginInvoke(new Action(() =>
    //        {
    //            CheckAndCallCopyTask(InstallQueue[intQueuePos]);
    //        })));
    //    }
    //}
    private void UpdateProgressExact(int x)
    {
        tabMainFile.BeginInvoke(new Action(() =>
        {
            dgvSource.Enabled = false;
            pbCopy.Visible = true;
            lblInstallStatusGameTitle.Visible = true;
            lblInstallStatusPercent.Visible = true;
            lblInstallStatusText.Visible = true;
            pbCopy.Value = x;
            lblInstallStatusGameTitle.Text = tbIDName.Text;
            lblInstallStatusText.Text = Resources.CopyTask_String1;
            lblInstallStatusPercent.Text = x + "%";
            tabMainFile.Update();
        }));
    }

    private void UpdateTransfer(int x)
    {
        tabMainFile.BeginInvoke(new Action(() =>
        {
            dgvSource.Enabled = false;
            pbCopy.Visible = true;
            lblInstallStatusPercent.Visible = true;
            pbCopy.Value = x;
            lblInstallStatusPercent.Text = x + "%";
            lblInstallStatusText.Visible = true;
            lblInstallStatusGameIndex.Visible = true;
            tabMainFile.Update();
        }));
    }


    private void FinishedInstalling()
    {
        tabMainFile.BeginInvoke(new Action(() =>
        {
            pbCopy.Value = 100;
            lblInstallStatusGameTitle.Text = Resources.CopyTask_String3;
            lblInstallStatusText.Text = Resources.CopyTask_String4;
            lblInstallStatusPercent.Text = Resources.CopyTask_String5;
            //GlobalNotifications(Resources.InstallGameScrub_String5, ToolTipIcon.Info);
            EnableOptionsGameList();
            dgvSource.Enabled = true;
            pbCopy.Visible = false;
            lblInstallStatusGameTitle.Visible = false;
            lblInstallStatusPercent.Visible = false;
            lblInstallStatusText.Visible = false;
            intQueuePos++;
            WORKING = false;
        }));
        EnableOptionsGameList();
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

        _ = strHTMLBuilder.Append(
            "<!doctype html> <html lang=\"en\" class=\"h-100\"> <head> <meta charset=\"utf-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"> <meta name=\"description\" content=\"\"> <meta name=\"author\" content=\"Mark Otto, Jacob Thornton, and Bootstrap contributors\"> <meta name=\"generator\" content=\"Hugo 0.98.0\"> <link rel=\"stylesheet\" href=\"./css/gcbm.css\" /><link rel=\"icon\" href=\"favicon.ico\" type=\"image/x-icon\" /> <title>GameCube Backups</title> <script src=\"./js/jquery.js\"></script><script src=\"./js/jquery.dataTables.min.js\"></script><script src=\"./js/bootstrap-tables.js\"></script><script>$(document).ready(function () {$('.table').DataTable();});</script> <svg xmlns =\"http://www.w3.org/2000/svg\" style=\"display: none;\"> <title>Bootstrap</title> <path fill-rule=\"evenodd\" clip-rule=\"evenodd\" d=\"M24.509 0c-6.733 0-11.715 5.893-11.492 12.284.214 6.14-.064 14.092-2.066 20.577C8.943 39.365 5.547 43.485 0 44.014v5.972c5.547.529 8.943 4.649 10.951 11.153 2.002 6.485 2.28 14.437 2.066 20.577C12.794 88.106 17.776 94 24.51 94H93.5c6.733 0 11.714-5.893 11.491-12.284-.214-6.14.064-14.092 2.066-20.577 2.009-6.504 5.396-10.624 10.943-11.153v-5.972c-5.547-.529-8.934-4.649-10.943-11.153-2.002-6.484-2.28-14.437-2.066-20.577C105.214 5.894 100.233 0 93.5 0H24.508zM80 57.863C80 66.663 73.436 72 62.543 72H44a2 2 0 01-2-2V24a2 2 0 012-2h18.437c9.083 0 15.044 4.92 15.044 12.474 0 5.302-4.01 10.049-9.119 10.88v.277C75.317 46.394 80 51.21 80 57.863zM60.521 28.34H49.948v14.934h8.905c6.884 0 10.68-2.772 10.68-7.727 0-4.643-3.264-7.207-9.012-7.207zM49.948 49.2v16.458H60.91c7.167 0 10.964-2.876 10.964-8.281 0-5.406-3.903-8.178-11.425-8.178H49.948z\"></path> </symbol> <symbol id=\"facebook\" viewBox=\"0 0 16 16\"> <path d=\"M16 8.049c0-4.446-3.582-8.05-8-8.05C3.58 0-.002 3.603-.002 8.05c0 4.017 2.926 7.347 6.75 7.951v-5.625h-2.03V8.05H6.75V6.275c0-2.017 1.195-3.131 3.022-3.131.876 0 1.791.157 1.791.157v1.98h-1.009c-.993 0-1.303.621-1.303 1.258v1.51h2.218l-.354 2.326H9.25V16c3.824-.604 6.75-3.934 6.75-7.951z\"></path> </symbol></svg><link href =\"./css/bootstrap.min.css\" rel=\"stylesheet\"><style> .bd-placeholder-img { font-size: 1.125rem; text-anchor: middle; -webkit-user-select: none; -moz-user-select: none; user-select: none; } @media(min-width: 768px) { .bd-placeholder-img-lg { font-size: 3.5rem; } } .b-example-divider { height: 3rem; background-color: rgba(0, 0, 0, .1); border: solid rgba(0, 0, 0, .15); border-width: 1px 0; box-shadow: inset 0 .5em 1.5em rgba(0, 0, 0, .1), inset 0 .125em .5em rgba(0, 0, 0, .15); } .b-example-vr { flex-shrink: 0; width: 1.5rem; height: 100vh; } .bi { vertical-align: -.125em; fill: currentColor; } .nav-scroller { position: relative; z-index: 2; height: 2.75rem; overflow-y: hidden; } .nav-scroller.nav { display: flex; flex-wrap: nowrap; padding-bottom: 1rem; margin-top: -1px; overflow-x: auto; text-align: center; white-space: nowrap; -webkit-overflow-scrolling: touch; } .bd-placeholder-img { font-size: 1.125rem; text-anchor: middle; -webkit-user-select: none; -moz-user-select: none; user-select: none; }            @media(min-width: 768px) { .bd-placeholder-img-lg { font-size: 3.5rem; } } .b-example-divider { height: 3rem; background-color: rgba(0, 0, 0, .1); border: solid rgba(0, 0, 0, .15); border-width: 1px 0; box-shadow: inset 0 .5em 1.5em rgba(0, 0, 0, .1), inset 0 .125em .5em rgba(0, 0, 0, .15); } .odd{background:#e2e3e5;} .b-example-vr { flex-shrink: 0; width: 1.5rem; height: 100vh; } .bi { vertical-align: -.125em; fill: currentColor; } .nav-scroller { position: relative; z-index: 2; height: 2.75rem; overflow-y: hidden; } .nav-scroller.nav { display: flex; flex-wrap: nowrap; padding-bottom: 1rem; margin-top: -1px; overflow-x: auto; text-align: center; white-space: nowrap; -webkit-overflow-scrolling: touch; }  .bg-dark {background-color: #4d6082 !important; } .copy { color: white!important; }# gh { margin-top: -3px; } footer { padding-left: 2em; padding-right: 2em; } </style > <link href =\"sticky-footer-navbar.css\" rel=\"stylesheet\"> </head> <body class=\"d-flex flex-column h-100\"> <header> <!-- Fixed navbar --> <nav class=\"navbar navbar-expand-md navbar-dark fixed-top bg-dark\"> <div class=\"container-fluid\"> <img src=\"./img/GC-Logo.png\" alt=\"\" style=\"height: 42px; width: 42px; padding: .25em;\"> <a class=\"navbar-brand\" href=\"https://axiondrak.github.io/gcbm.html\">GameCube Backup Manager</a> <button class=\"navbar-toggler\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#navbarCollapse\" aria-controls=\"navbarCollapse\" aria-expanded=\"false\" aria-label=\"Toggle navigation\"> <span class=\"navbar-toggler-icon\"></span> </button> <div class=\"collapse navbar-collapse\" id=\"navbarCollapse\"> <ul class=\"navbar-nav me-auto mb-2 mb-md-0\"> <li class=\"nav-item\"> <a class=\"nav-link active\" aria-current=\"page\" href=\"#\">Home</a> </li> <li class=\"nav-item\"> <a class=\"nav-link\" href=\"#\">Stats</a> </li> <li class=\"nav-item\"> <a class=\"nav-link\">Help</a> </li> </ul> </div> </div> </nav> </header> <!-- Begin page content --> <main class=\"flex-shrink-0\"> <div class=\"container\"> <h1 class=\"mt-5\">GameCube Backups</h1> <p class=\"lead\">My collection of games.</p> </div> </main> ");
        _ = strHTMLBuilder.Append("<div class=\"container-fluid\"><table class=\"table\">");
        _ = strHTMLBuilder.Append("<thead >");

        foreach (DataColumn myColumn in dt.Columns)
        {
            _ = strHTMLBuilder.Append("<th scope=\"col\">");
            _ = strHTMLBuilder.Append(myColumn.ColumnName);
            _ = strHTMLBuilder.Append("</th>");
        }

        _ = strHTMLBuilder.Append("</thead>");

        var i = 0;
        foreach (DataRow myRow in dt.Rows)
        {
            _ = strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                _ = strHTMLBuilder.Append("<td >");
                _ = strHTMLBuilder.Append(myRow[myColumn.ColumnName]);
                _ = strHTMLBuilder.Append("</td>");
            }

            _ = strHTMLBuilder.Append("</tr>");
            i++;
        }
        //Close tags.

        _ = strHTMLBuilder.Append(
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
            _ = MessageBox.Show("File has been saved at: " + caminho, "Sucess!");
        }
        catch (Exception ex)
        {
            _ = MessageBox.Show("ERROR! Please post report this to Github or GBATemp.\n" + ex.Message, "ERROR!");
            tbLog.AppendText("[" + DateTime.Now.ToString("hh:mm:ss tt") + "] HTML Export error" + Environment.NewLine +
                             ex.Message + Environment.NewLine);
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

    //OBSOLETE?
    //Will it no longer be implemented before version 3.0?
    //Remove the "Export CSV" function if it no longer needs to exist.
    //=--sjohnson1021 : I can definitely write this. I did the HTML, and it's functional.
    //I just would need to re-bundle to files. Is that desired?

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

    private async void tsmiDeleteSelectedFile_Click(object sender, EventArgs e)
    {
        //DeleteSelectedGame(0);
        await GlobalDeleteSelectedGame(dgvSource);
    }

    #endregion

    #region tsmiGameListDeleteAllFiles_Click

    private async void tsmiGameListDeleteAllFiles_Click(object sender, EventArgs e)
    {
        //DeleteAllGame(0);
        await GlobalDeleteAllGames(dgvSource);
    }

    #endregion

    #region tsmiReloadGameList_Click

    private async void tsmiReloadGameList_Click(object sender, EventArgs e)
    {
        //UpdateGameList(fbd1.SelectedPath, dgvSource);
        await DisplaySourceFilesAsync(fbd1.SelectedPath, dgvSource).ConfigureAwait(false);
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

            ClearTemp();
        Application.Exit();
    }

    #endregion

    #region tsmiDeleteSelectedFileDisc_Click

    private async void tsmiDeleteSelectedFileDisc_Click(object sender, EventArgs e)
    {
        //DeleteSelectedGame(1);
        await GlobalDeleteSelectedGame(dgvDestination);
    }

    #endregion

    #region tsmiDatabaseUpdateGameTDB_Click

    private async void tsmiDatabaseUpdateGameTDB_Click(object sender, EventArgs e)
    {
        if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "NetVerify"))
        {
            if (!Monitor.TryEnter(lvDatabase)) return;

            using var form = new frmDownloadGameTDB();
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
        else
        {
            GlobalNotifications(Resources.NoInternetConnectionFound_String1 + Environment.NewLine +
                                Resources.NoInternetConnectionFound_String2, ToolTipIcon.Info);
        }
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
            _ = MessageBox.Show(Resources.ClearLogNotFound, Resources.Notice,
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    #endregion

    #region tsmiMenuAbout_Click

    private void tsmiMenuAbout_Click(object sender, EventArgs e)
    {
        var _frmAbout = new frmAboutBox();
        _ = _frmAbout.ShowDialog();
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
        using var form = new frmConfig();
        var _returnRename = form.ShowDialog();
        if (_returnRename == DialogResult.OK)
        {
            var _code = form.RETURN_CONFIRM;
            if (_code == 1) NetworkCheck();
            LoadConfigFile();
            Program.AdjustLanguage(Thread.CurrentThread);
            CultureInfo.CurrentUICulture = new CultureInfo(CONFIG_INI_FILE.IniReadString("LANGUAGE", "ConfigLanguage", "en-US"));
            foreach (Control c in this.Controls)
            {
                c.Text = Resources.ResourceManager.GetString(c.Name, CultureInfo.CurrentUICulture);
                c.Invalidate();
                c.Refresh();
            }

            this.Invalidate();
            this.Refresh();
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
        GetAllDrives(s => { }); //unused callback
        dgvDestination.DataSource = null;
    }

    #endregion

    #region tsmiReloadGameListDisc_Click

    private async void tsmiReloadGameListDisc_Click(object sender, EventArgs e)
    {
        await DisplayDestinationFilesAsync(tscbDiscDrive.SelectedItem + GAMES_DIR + sio.Path.DirectorySeparatorChar,
            dgvDestination);
    }

    #endregion

    #region tsmiRenameISO_Click

    private async void tsmiRenameISO_Click(object sender, EventArgs e)
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

                using var form = new frmRenameISO(fbd1.SelectedPath, pathImage);
                var _returnRename = form.ShowDialog();
                if (_returnRename == DialogResult.OK)
                {
                    var _code = form.RETURN_CONFIRM;
                    if (_code == 1)
                        await DisplaySourceFilesAsync(fbd1.SelectedPath, dgvSource).ConfigureAwait(false);
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

    private async void tsmiGameDiscDeleteAllFiles_Click(object sender, EventArgs e)
    {
        await GlobalDeleteAllGames(dgvDestination);
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
        //ExportHTML(GameDataTable(dgvGameListPath));
    }

    #endregion

    #region tsmiExportCSV_Click

    private void tsmiExportCSV_Click(object sender, EventArgs e)
    {
        //using (FolderBrowserDialog dialog = new FolderBrowserDialog())
        //{
        //    //setup here

        //    if (dialog.ShowDialog() ==
        //        DialogResult.OK) //check for OK...they might press cancel, so don't do anything if they did.
        //    {
        //        string path = dialog.SelectedPath + sio.Path.DirectorySeparatorChar + "games.csv";
        //        GameDataTable(dgvGameListPath).ToCSV(path);
        //    }
        //}
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
                _ = _frmInfo.ShowDialog();
                _frmInfo.Dispose();
            }
        }
    }

    #endregion

    #region tsmiMetaXml_Click

    private void tsmiMetaXml_Click(object sender, EventArgs e)
    {
        var metaXml = new frmMetaXml();
        _ = metaXml.ShowDialog();
        metaXml.Dispose();
    }

    #endregion

    #region tsmiManageApp_Click

    private void tsmiManageApp_Click(object sender, EventArgs e)
    {
        var manageApp = new frmManageApp();
        _ = manageApp.ShowDialog();
        manageApp.Dispose();
    }

    #endregion

    #region tsmiElfDol_Click

    private void tsmiElfDol_Click(object sender, EventArgs e)
    {
        var elfDol = new frmConvertELFtoDOL();
        _ = elfDol.ShowDialog();
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
                _ = MessageBox.Show(Resources.DolphinEmulator_Not_Found_String_1 + Environment.NewLine +
                                    Environment.NewLine +
                                    Resources.DolphinEmulator_Not_Found_String_2, Resources.MetaXml_String_ERRO,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                try
                {
                    var _sourceGame = dgvSource.CurrentRow.Cells["Path"].Value.ToString();

                    START_INFO.CreateNoWindow = true;
                    START_INFO.UseShellExecute = true;
                    // DOLPHIN
                    START_INFO.FileName = CONFIG_INI_FILE.IniReadString("DOLPHIN", "DolphinFolder", "");

                    var VideoDX = CONFIG_INI_FILE.IniReadBool("DOLPHIN", "DolphinDX11")
                        ? " --video_backend=D3D"
                        : CONFIG_INI_FILE.IniReadBool("DOLPHIN", "DolphinDX12")
                            ? " --video_backend=D3D"
                            : " --video_backend=OGL";

                    var AudioDSP = CONFIG_INI_FILE.IniReadBool("DOLPHIN", "DolphinLLE")
                        ? " --audio_emulation=LLE"
                        : " --audio_emulation=HLE";

                    START_INFO.Arguments = " --exec=" + sio.Path.DirectorySeparatorChar + _sourceGame +
                                           sio.Path.DirectorySeparatorChar + " /b " + VideoDX + AudioDSP;
                    //START_INFO.WindowStyle = ProcessWindowStyle.Hidden;
                    _ = Process.Start(START_INFO);
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
        _ = createPackage.ShowDialog();
        createPackage.Dispose();
    }

    #endregion

    #region tsmiBurnMedia_Click

    private void tsmiBurnMedia_Click(object sender, EventArgs e)
    {
        var burnMedia = new frmBurnMedia();
        _ = burnMedia.ShowDialog();
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

    #region SJohnson1021's DevGround
    /*
     *
     *
     *
                          /$$$$$$        /$$$$$           /$$                                                 /$$    /$$$$$$   /$$$$$$    /$$ /$$              
                         /$$__  $$      |__  $$          | $$                                               /$$$$   /$$$_  $$ /$$__  $$ /$$$$| $/              
                        | $$  \__/         | $$  /$$$$$$ | $$$$$$$  /$$$$$$$   /$$$$$$$  /$$$$$$  /$$$$$$$ |_  $$  | $$$$\ $$|__/  \ $$|_  $$|_/ /$$$$$$$      
                        |  $$$$$$          | $$ /$$__  $$| $$__  $$| $$__  $$ /$$_____/ /$$__  $$| $$__  $$  | $$  | $$ $$ $$  /$$$$$$/  | $$   /$$_____/      
                         \____  $$    /$$  | $$| $$  \ $$| $$  \ $$| $$  \ $$|  $$$$$$ | $$  \ $$| $$  \ $$  | $$  | $$\ $$$$ /$$____/   | $$  |  $$$$$$       
                         /$$  \ $$   | $$  | $$| $$  | $$| $$  | $$| $$  | $$ \____  $$| $$  | $$| $$  | $$  | $$  | $$ \ $$$| $$        | $$   \____  $$      
                        |  $$$$$$//$$|  $$$$$$/|  $$$$$$/| $$  | $$| $$  | $$ /$$$$$$$/|  $$$$$$/| $$  | $$ /$$$$$$|  $$$$$$/| $$$$$$$$ /$$$$$$ /$$$$$$$/      
                         \______/|__/ \______/  \______/ |__/  |__/|__/  |__/|_______/  \______/ |__/  |__/|______/ \______/ |________/|______/|_______/  

                                                                                                                                                                                                            
                                                                                       .*((((*.        .,((((*.                                                                                         
                                                               ,/(((*. .°/(((*       *(,    .,°/(/. *(/**.    ,(/        *(((/.  ,/(((*.                                                                
  ,&@@#(((((((((((((((((((((((((((((((((((((((((((((((((((((((##.    /&#.   .//      (*        ./(%%(/,        .(,     .(*    ,%%,    *#((((((((((((((((((((((((((((((((((((((((((((((((((((((((%@@(.   
    .                                                          ./(((/. .*((((,       .((,.   .,(((##/((*.   ../#,       .*(((/,  ,/(((*.                                                         .      
                                                                                         ..,..°/*.   °/*..,,.                                                                                           
    
                                             /$$$$$$$                               /$$$$$$                                                /$$
                                            | $$__  $$                             /$$__  $$                                              | $$
                                            | $$  \ $$  /$$$$$$  /$$    /$$       | $$  \__/  /$$$$$$   /$$$$$$  /$$   /$$ /$$$$$$$   /$$$$$$$
                                            | $$  | $$ /$$__  $$|  $$  /$$//$$$$$$| $$ /$$$$ /$$__  $$ /$$__  $$| $$  | $$| $$__  $$ /$$__  $$
                                            | $$  | $$| $$$$$$$$ \  $$/$$/|______/| $$|_  $$| $$  \__/| $$  \ $$| $$  | $$| $$  \ $$| $$  | $$
                                            | $$  | $$| $$_____/  \  $$$/         | $$  \ $$| $$      | $$  | $$| $$  | $$| $$  | $$| $$  | $$
                                            | $$$$$$$/|  $$$$$$$   \  $/          |  $$$$$$/| $$      |  $$$$$$/|  $$$$$$/| $$  | $$|  $$$$$$$
                                            |_______/  \_______/    \_/            \______/ |__/       \______/  \______/ |__/  |__/ \_______/

                                   ┌┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┌┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┬┐
                                   |┼/*+-------------------------------------------------------------------------+\*┼|
                                   |┼| |       |\                                           -~ /     \  /          |┼|
                                   |┼|~~__     | \                                         | \/       /\          /|┼|
                                   |┼|    --   |  \                                        | / \    /    \     /   |┼|
                                   |┼|      |~_|   \                                   \___|/    \/         /      |┼|
                                   |┼|--__  |   -- |\________________________________/~~\~~|    /  \     /     \   |┼|
                                   |┼|   |~~--__  |~_|____|____|____|____|____|____|/ /  \/|\ /      \/          \/|┼|
                                   |┼|   |      |~--_|__|____|____|____|____|____|_/ /|    |/ \    /   \       /   |┼|
                                   |┼|___|______|__|_||____|____|____|____|____|__[]/_|----|    \/       \  /      |┼|
                                   |┼|  \mmmm :   | _|___|____|____|____|____|____|___|  /\|   /  \      /  \      |┼|          
                                   |┼|      B :_--~~ |_|____|____|____|____|____|____|  |  |\/      \ /        \   |┼|    
                                   |┼|  __--P :  |  /                                /  /  | \     /  \          /\|┼|    
                                   |┼|~~  |   :  | /                                 ~~~   |  \  /      \      /   |┼|    
                                   |┼|    |      |/                        .-.             |  /\          \  /     |┼|    
                                   |┼|    |      /                        |   |            |/   \          /\      |┼|      _________________________    
                                   |┼|    |     /                        |     |            -_   \       /    \    |┼|     /~~~~~~~~~~~~~~~~~~~~~~~/||   
                                   |┼+-----------------------------------------------------------------------------+┼|    /              /######/ / ||     
                                   |┼|          |  /|  |   |  2  3  4  | /~~~~~\ |       /|    |_| ....  ......... |┼|   /              /______/ /  ||   
                                   |┼|          |  ~|~ | % |           | | ~J~ | |       ~|~ % |_| ....  ......... |┼|   ========================= /|| 
                                   |┼|   AMMO   |  HEALTH  |  5  6  7  |  \===/  |    ARMOR    |#| ....  ......... |┼|   |_______________________|/░||
                                   |┼+-----------------------------------------------------------------------------+┼|   └┐░░\**** /░░░░\__,,__/░░░░||                            
                                   └┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴╬╬╬╬╬╬╬╬╣┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┴┘   |░░░\±± /░░░░░░░░░░░░░░░░░||+++++++++++++++┐
                                            ,░_____________________________╬╬╬╬╬╬╣________________________________________|______________\====/%____||-------------/ƒ│
                                           /                     ________╠╬╬╬╬╬╬╬╬╬╣___________,                          |   ___        /▒▓▓▒\ %  / |░/          /ƒ/
                                          /                    /         \         /           |                         _|__|===|===___/░▒▓▓▒░\%_/  |/          /ƒ/
                                         /                     |--------, '-------' ,---------=|                        |    |▒▓▒|     |░░▒▓▓▒░░| | //          /ƒ/
                                        /                      |         \_________/           |                        |____\▒▓▒/______\░▒▓▓▒░/__|//          /ƒ/
                                       /                       |______________________________/                          ~~~~~~~~~~~~~~~~~~~~~~~~~~`          /ƒ/
                                      /                                      ┌┤                                                                              /ƒ/
                                     /                                       ||                                                                             /ƒ/
                                    /                _______________________╪╪_______________________,                                                     /ƒ/
                                   /                /                                       //       ()                                                   /ƒ/
                                  /                / _/_/_/_/_/ _/_/_/_/_/ _/_/_/_/ _/___/ _/_/_/_/ //««««««««═══m,                   .`/ (              /ƒ/
                                 /                /                                                //|            \\                    ) )             /ƒ/
                                /                / _/_/_/_/_/_/_/_/_/_/_/_/_/__/  _/_/_/ _/_/_/_/ //||             \\              «─░░(  (░░─»        /ƒ/
                               /                / __/_/_/_/_/_/_/_/_/_/_/_/_/  / _/_/_/ _/_/_/_/ //_|/         ,----╪╪----,        ║|░░▒▓▓▒░░╠═╗      /ƒ/
                              /                /_/__/_/_/_/_/_/_/_/_/_/_/_/___/   _/   _/_/_/_/ //            /__/__/__/ /|        ║|░░▒▓▓▒░░║ ║     /ƒ/
                             /                / __/_/_/_/_/_/_/_/_/_/_/_/__/   _/_/_/ _/_/_/ / //            /          / |        ║|░░▒▓▓▒░░╠═╝    /ƒ/
                            /                /   __/_________________/               ___/_/_/ //            /          /  )        \.░░▒▓▓▒░░/     /ƒ/
                           /                /_______________________________________________.//            /          /  /          `-------'     /ƒ/
                          /                (________________________________________________(/            (__________(__/                        /ƒ/
                         /______________________________________________________________________________________________________________________/ƒ/
                        |▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓|/
                        |▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒/
                 */
    #endregion

    #region Wait

    public void wait(int milliseconds)
    {
        var timer1 = new Timer();
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

    private void GetProcessesToolStripMenuItem_Click(object sender, EventArgs e)
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
        if (e.ColumnIndex == 0 && e.RowIndex >= 0 && !SCANNING)
        {
            /*
             * e.ColumnIndex = 0 
             * e.RowIndex
             */
            if (dgvSelected != null &&
                dgvSelected != dgvSource &&
                dgvSelected != dgvDestination)
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
        if (!SCANNING) ReloadDataGridViewGameList(dgvDestination, dDestGames);
    }

    private void dgvSource_CurrentCellChanged(object sender, EventArgs e)
    {
        if (!SCANNING) ReloadDataGridViewGameList(dgvSource, dSourceGames);
    }

    private void toolStripStatusLabel1_Click(object sender, EventArgs e)
    {
        ResetOptions();
    }

    #endregion


} // frmMain Form
  // namespace GCBM