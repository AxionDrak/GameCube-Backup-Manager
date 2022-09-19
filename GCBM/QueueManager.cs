using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCBM.Properties;
using GCBM.tools;
using Microsoft.VisualBasic.Logging;
using sio = System.IO;
namespace GCBM
{
    /// <summary>
    /// Class to facilitate working with the Queue
    /// </summary>
    public class QueueManager
    {
        public static QueueManager qmInstance = new()
        {
            
        };
        #region Variables

        public Dictionary<int, Game> InstallQueue = new Dictionary<int, Game>();
        public static Dictionary<int, Game> SourceGames = new Dictionary<int, Game>();
        public static Dictionary<int, Game> DestinationGames = new Dictionary<int, Game>();
        public static Game[] GameList;
        public static int intQueuePos = 0;
        public static int intQueueCount = 0;
        public static bool blnQueuePaused = false;
        public static bool blnQueueFinished = false;
        public static bool blnQueueError = false;
        public static bool blnQueueErrorHandledByUser = false;
        public static bool blnQueueErrorHandledByProgram = false;
        public static bool blnQueueRunning = false;
        public static bool blnAbort = false;
        private static readonly string GAMES_DIR = "games";
        public static DataGridView dgvSelected = new();

        private static string FLUSH_SD;
        private static string SCRUB_ALIGN;
        public GroupBox grpStatus = frmMain.StatusGroupBox;
        private Label lblAbort,lblInstallStatusGameTitle,lblInstallStatusGameIndex, lblInstallStatusText,lblInstallStatusPercent = new Label();//, lblInstallStatusTime, lblInstallStatusETA, lblInstallStatusSpeed;
        private Button btnAbort = new();
        private ProgressBar pbInstallStatus = new();
        public Stopwatch sw = new();
        public frmMain frm = frmMain.ActiveForm as frmMain;

        //IMPORT USED TO HIDE GCIT's windows when launched. I know, ProccesWindows.Style Hidden .. Didn't like when i changed the way it was launched
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static string[] GetSelectedGamePaths(DataGridView dgv)
        {
            var result = dgv.Rows.Cast<DataGridViewRow>().Where(x => (bool)x.Cells[0].Value)
                .Select(x => (string)x.Cells[6].Value).ToArray();
            return result;
        }

        public void AssignControls()
        {
            #region Labels
            lblAbort =qmInstance.frm.Controls["lblAbort"] as Label;
           qmInstance.lblInstallStatusGameTitle =qmInstance.frm.Controls["lblInstallStatusGameTitle"] as Label;
            lblInstallStatusGameIndex =qmInstance.frm.Controls["lblInstallStatusGameIndex"] as Label;
            qmInstance.lblInstallStatusText =qmInstance.frm.Controls["qmInstance.lblInstallStatusText"] as Label;
           qmInstance.lblInstallStatusPercent =qmInstance.frm.Controls["lblInstallStatusPercent"] as Label;
            //lblInstallStatusTime =qmInstance.frm.Controls["lblInstallStatusTime"] as Label;
            //lblInstallStatusETA =qmInstance.frm.Controls["lblInstallStatusETA"] as Label;
            //lblInstallStatusSpeed =qmInstance.frm.Controls["lblInstallStatusSpeed"] as Label;
            #endregion

            #region Buttons

            btnAbort =qmInstance.frm.Controls["btnAbort"] as Button;
            #endregion

            #region ProgressBars
           qmInstance.pbInstallStatus =qmInstance.frm.Controls["pbInstallStatus"] as ProgressBar;
            #endregion
        }

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

        #endregion

        #region Constructors


        #endregion

        #region Build Install Queue




        public static string strDestinationDrive;

        /// <summary>
        ///     Get selected games and add them to a queue.
        /// </summary>
        public void BuildInstallQueue(DataGridView dgv)
        {
            qmInstance.AssignControls();
            strDestinationDrive = frmMain.SelectedDrive;
            //Get # selected games - Done
            //Set QueueLength - Done
            //Reset QueuePos - Done

            //Start First Disc - done
            //On completion
            //Working = false - done
            //Q++ - done
            //Next Disc - done
            //Check if we're done
            intQueuePos = 0;
            InstallQueue.Clear();
            var num = 0;

            
            foreach (var path in GetSelectedGamePaths(dgv))
            {
                var g = SourceGames.AsParallel().First(x => x.Value.Path == path);
                InstallQueue.Add(num, g.Value);
                num++;
            }

            
        }
        public void BuildInstallQueue(string[] pathStrings)
        {
            strDestinationDrive = frmMain.SelectedDrive;
            //Get # selected games - Done
            //Set QueueLength - Done
            //Reset QueuePos - Done

            //Start First Disc - done
            //On completion
            //Working = false - done
            //Q++ - done
            //Next Disc - done
            //Check if we're done
            intQueuePos = 0;
            InstallQueue.Clear();
            var num = 0;

            
            foreach (var path in pathStrings)
            {
                var g = SourceGames.AsParallel().First(x => x.Value.Path == path);
                InstallQueue.Add(num, g.Value);
                num++;
            }

            
        }

        #endregion



        public static string InstallType = "";

        #region Start

        /// <summary>
        /// Variables have been set-up, fire up the engine
        /// </summary>
        public static void StartQueue(DataGridView dgv, int installType, GroupBox controlsBox)
        {

            //Set the Queue to Running
            blnQueueRunning = true;
            //Set the Queue to Not Paused
            blnQueuePaused = false;
            //Set the Queue to Not Finished
            blnQueueFinished = false;
            //Set the Queue to Not Error
            blnQueueError = false;
            //Set the Queue to Not Error Handled
            blnQueueErrorHandledByUser = false;
            //Set the Queue to Not Error Handled By Program
            blnQueueErrorHandledByProgram = false;
            //Set the Queue Position to 0
            intQueuePos = 0;
            //Set the Queue Count to the number of rows selected in the DataGridView
            intQueueCount = GetSelectedGamePaths(dgv).Length;
            var selectedRowCount = dgv.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (GetSelectedGamePaths(dgv).Length == 0)
            {
                QueueManager.SelectGameFromList();
                return;
            }

            if (frmMain.SelectedDrive == "Inactive")
            {
                SelectTargetDrive();
            }
            else
            {
                if (!isGCITRunning())
                    try
                    {
                        if (installType == 0) // Install Exact Copy
                        {
                            //Set the Install type, and prepare the interface
                            InstallType = "COPY";
                            foreach (Control c in controlsBox.Controls)
                            {

                                c.Visible = true;
                            }
                        }

                        qmInstance.BuildInstallQueue(dgv);
                        //Start the first game in the queue
                        InstallGameExactCopy(qmInstance.InstallQueue[intQueuePos].Path);
                    }
                    catch (Exception ex)
                    {
                        if (ex.GetBaseException() is sio.FileNotFoundException)
                        {
                            ExceptionHelper helper = new ExceptionHelper();
                            helper.NewFileNotFoundException(ex,intQueuePos);
                        }

                    }
                else // Install Scrub
                {
                    StartScrub(dgv, installType, controlsBox);
                }
            }
            //Lets Build the Install Queue

            //else ; possibilities..... Nkit?

        }

        /// <summary>
        ///     Informs if it is necessary to select a game from the list.
        /// </summary>
        public static void SelectGameFromList()
        {
            _ = MessageBox.Show(Resources.SelectGameFromList, Resources.Information, MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// </summary>
        public static void SelectTargetDrive()
        {
            _ = MessageBox.Show(Resources.SelectTargetDrive, Resources.Information, MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        #endregion







        #region Pause

        #endregion



        #region Resume

        #endregion

        #region Stop - Finished

        #endregion










        #region Scrub



        private async static void StartScrub(DataGridView dgv, int installType, GroupBox controlsBox)
        {
            qmInstance.frm.DisableOptionsGame((DataGridView)qmInstance.frm.Controls["dgvDestination"]);
           qmInstance.btnAbort.Visible = true;
           qmInstance.lblAbort.Visible = true;
            intQueuePos = 0;

            qmInstance.BuildInstallQueue((DataGridView)frmMain.ActiveForm.Controls["dgvSource"]);
            foreach (var game in qmInstance.InstallQueue.Values)
                if (!blnAbort)
                    await InstallGameScrub(qmInstance.InstallQueue[intQueuePos], frmMain.StatusGroupBox, qmInstance.sw).ConfigureAwait(false);

            var d2counter = 0;
            foreach (var game in _listSecondDiscs)
            {
                d2counter++;
                qmInstance.lblInstallStatusText.Text = Resources.InstallGameScrub_TransferDisc2;
                qmInstance.lblInstallStatusGameTitle.Text = game.Title;
                qmInstance.lblInstallStatusGameIndex.Text = d2counter.ToString();
                await RenameDisc2(game).ConfigureAwait(false);
            }

            Notifications.GlobalNotifications("Successfully installed " + qmInstance.InstallQueue.Count + " games.", ToolTipIcon.Info);
            qmInstance.pbInstallStatus.BeginInvoke(() =>
            {
                qmInstance.pbInstallStatus.Hide();
                qmInstance.lblInstallStatusPercent.Hide();
                qmInstance.lblInstallStatusText.Hide();
                qmInstance.lblInstallStatusGameTitle.Hide();
            });

        }


        #region Install Game Scrub

        private readonly Stopwatch scrubStopwatch = new();

        /// <summary>
        ///     Function to install an copy of the file in Scrub mode.
        /// </summary>
        private static async Task InstallGameScrub(Game game, GroupBox controlsBox, Stopwatch scrubStopwatch)
        {




            scrubStopwatch.Stop();
            scrubStopwatch.Reset();
            QueueManager.InstallType = "SCRUB";
            qmInstance.pbInstallStatus.Style = ProgressBarStyle.Continuous;
            if (blnAbort)
                return; //I know we already checked, but just in case.. one more time just to be extra careful. We are writing data after all.
            const string quote = "\"";
            var _source = game.Path;

        // GCIT

        //setup vars


        GetTransferVars();

            //START_INFO
            var myProcess = new Process();
            myProcess.StartInfo.Arguments = quote + _source + quote + " -aq " + SCRUB_ALIGN + FLUSH_SD + " -f " +
                                            Program.ConfigFile.IniReadString("TRANSFERSYSTEM", "ScrubFormat", "") + " -d " +
                                            frmMain.SelectedDrive + GAMES_DIR;
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.SynchronizingObject = frmMain.ActiveForm;
            myProcess.EnableRaisingEvents = true;
            myProcess.StartInfo.UseShellExecute = true;
            //myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.FileName = frmMain.GET_CURRENT_PATH + sio.Path.DirectorySeparatorChar
                                                            + "bin" + sio.Path.DirectorySeparatorChar + "gcit.exe ";
            /*gcit.exe proccesses/trims excess data (padding) from a file*/
            myProcess.Exited += (s, evt) =>
            {
                var _StatusExit = myProcess.ExitCode;
                if (_StatusExit == 0) //exit success
                {
                    qmInstance.lblInstallStatusText.Visible = true;
                    qmInstance.lblInstallStatusPercent.Visible = true;
                    qmInstance.pbInstallStatus.Visible = true;
                    qmInstance.lblInstallStatusPercent.Text = "100%";
                    qmInstance.pbInstallStatus.Value = 100;
                    qmInstance.lblInstallStatusText.Text = Resources.InstallGameScrub_DoneScrubbing;
                    var game = qmInstance.InstallQueue[intQueuePos];
                    CheckDisc1Or2Scrub(game).ConfigureAwait(false);

                }

                if (_StatusExit == 3)
                {
                    //whItespace in filename.
                    //lblInstallStatusGameTitle.Text = "Status: ERRO! -> " + "{" + _StatusExit.ToString() + "}"
                    //               + " Por favor, verifique se exitem espaços no nome do arquivo!";
                }

                intQueuePos++;
                if (intQueuePos >= intQueueCount) return;
                scrubStopwatch.Stop();
                myProcess?.Dispose();
            };

            myProcess.Start();
            Thread.Sleep(1000);
            ShowWindow(myProcess.MainWindowHandle, 0);

            scrubStopwatch.Start();
            while (!myProcess.HasExited && !blnAbort)
            {
                UpdateProgressScrub(scrubStopwatch.ElapsedMilliseconds);
                Application.DoEvents();
            }
        }

        public static void GetTransferVars()
        {
            var boolCaseSwitch = Program.ConfigFile.IniReadBool("TRANSFERSYSTEM", "ScrubFlushSD");
            var intCaseSwitch = Program.ConfigFile.IniReadInt("TRANSFERSYSTEM", "ScrubAlign");
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
        }

        #endregion
        private static async Task CheckDisc1Or2Scrub(Game game)
        {
            #region Disc 1

            if (game.DiscID == "0x00")
                if (frmMain.useXmlTitle)
                {
                    var myOrigem = frmMain.SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                   game.InternalName +
                                   " [" + game.ID + "]" +
                                   sio.Path.DirectorySeparatorChar + "game.iso";

                    var _SwapCharacter = game.Title.Replace(":", " - ").Replace(";", " - ").Replace(",", " - ")
                        .Replace(" -  ", " - ").Replace("/", "&");

                    var myDestiny = frmMain.SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
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
                    var Source = new sio.DirectoryInfo(frmMain.SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                       game.InternalName + " [" + game.ID + "]");
                    var Destination = new sio.DirectoryInfo(frmMain.SelectedDrive + GAMES_DIR +
                                                            sio.Path.DirectorySeparatorChar +
                                                            _SwapCharacter + " [" + game.ID + "]");

                    await Task.Run(() =>
                    {
                        if (Destination.Exists) Destination.Delete();

                        try
                        {
                            Source.MoveTo(Destination.FullName);
                        }
                        catch (Exception ex)
                        {
                            Notifications.GlobalNotifications(ex.Message, ToolTipIcon.Error);
                        }
                    }).ContinueWith(task =>
                    {
                        Notifications.GlobalNotifications(Resources.InstallGameScrub_GameInstalled, ToolTipIcon.Info);

                        //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmMain.ActiveForm.Controls["tabMainFile"].BeginInvoke(() =>
                        {
                            qmInstance.lblInstallStatusGameTitle.Visible = false;
                            qmInstance.lblInstallStatusGameIndex.Visible = false;
                            qmInstance.lblInstallStatusText.Visible = false;
                            qmInstance.lblInstallStatusPercent.Visible = false;
                            qmInstance.pbInstallStatus.Visible = false;
                        });
                        //GC.Collect();
                        //Delete folder at   frmMain.SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                        //                   game.Title +
                        //                   " [" + game.ID + "2]" +
                    }).ConfigureAwait(false);
                }

            #endregion

            #region Disc 2

            if (game.DiscID == "0x01") _listSecondDiscs.Add(game);

            #endregion
        }

        private static async Task RenameDisc2(Game game)
        {
            // Usar nome intermo

            if (frmMain.useXmlTitle)
            {
                var myOrigem = frmMain.SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                               game.InternalName +
                               " [" + game.ID + "]" +
                               sio.Path.DirectorySeparatorChar + "game.iso";

                var _SwapCharacter = game.Title.Replace(":", " - ").Replace(";", " - ").Replace(",", " - ")
                    .Replace(" -  ", " - ").Replace("/", "&");

                var myDestiny = frmMain.SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
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
                var Source = new sio.DirectoryInfo(frmMain.SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                   game.InternalName + " (2) [" + game.ID + "2]");
                var Destination = new sio.DirectoryInfo(frmMain.SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                        _SwapCharacter + " [" + game.ID + "]");


                await Task.Run(() =>
                {
                    if (Destination.Exists)
                        try
                        {
                            var file = Source.EnumerateFiles("*.iso").First();
                            file.CopyTo(new sio.FileInfo(sio.Path.Combine(Destination.FullName, "disc2.iso")),
                                qmInstance.frm.UpdateTransfer);
                            file.Directory.Delete(true);
                        }
                        catch (Exception ex)
                        {
                            Notifications.GlobalNotifications(ex.Message, ToolTipIcon.Error);
                        }

                    else
                        Source.MoveTo(Destination.FullName);
                }).ContinueWith(task =>
                {
                    Notifications.GlobalNotifications(Resources.InstallGameScrub_GameInstalled, ToolTipIcon.Info);

                    //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMain.ActiveForm.Controls["tabMainFile"].BeginInvoke(() =>
                    {
                        qmInstance.lblInstallStatusGameTitle.Visible = false;
                        qmInstance.lblInstallStatusGameIndex.Visible = false;
                        qmInstance.lblInstallStatusText.Visible = false;
                        qmInstance.lblInstallStatusPercent.Visible = false;
                        qmInstance.pbInstallStatus.Visible = false;
                    });

                    //GC.Collect();
                    //Delete folder at   frmMain.SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
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
                var Source = new sio.DirectoryInfo(frmMain.SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                   game.InternalName + " (2) [" + game.ID + "2]");
                var Destination = new sio.DirectoryInfo(frmMain.SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                        game.InternalName + " [" + game.ID + "]");
                await Task.Run(() =>
                {
                    if (Destination.Exists)
                        try
                        {
                            var file = Source.EnumerateFiles("*.iso").First();
                            file.CopyTo(new sio.FileInfo(sio.Path.Combine(Destination.FullName, "disc2.iso")),
                                qmInstance.frm.UpdateTransfer);
                            file.Directory.Delete(true);
                        }
                        catch (Exception ex)
                        {
                            Notifications.GlobalNotifications(ex.Message, ToolTipIcon.Error);
                        }
                    else
                        Source.MoveTo(Destination.FullName);
                }).ContinueWith(task =>
                {
                    Notifications.GlobalNotifications(Resources.InstallGameScrub_GameInstalled, ToolTipIcon.Info);

                    //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMain.ActiveForm.Controls["tabMainFile"].BeginInvoke(() =>
                    {
                        qmInstance.lblInstallStatusGameTitle.Visible = false;
                        qmInstance.lblInstallStatusGameIndex.Visible = false;
                        qmInstance.lblInstallStatusText.Visible = false;
                        qmInstance.lblInstallStatusPercent.Visible = false;
                        qmInstance.pbInstallStatus.Visible = false;
                    });
                }).ConfigureAwait(false);
            }
        }

        private static readonly List<Game> _listSecondDiscs = new();

        private static void UpdateProgressScrub(long i)
        {
            frmMain.ActiveForm.Controls["tabMainFile"].BeginInvoke(() =>
            {
                //Make sureqmInstance.pbInstallStatus. is Continuous
                qmInstance.lblInstallStatusGameTitle.Visible = true;
                qmInstance.lblInstallStatusText.Visible = true;
                qmInstance.lblInstallStatusPercent.Visible = true;
                qmInstance.lblInstallStatusGameTitle.Text = qmInstance.InstallQueue[intQueuePos].Title;
                qmInstance.lblInstallStatusGameIndex.Text = intQueuePos + "  /  " + qmInstance.InstallQueue.Count;
                qmInstance.pbInstallStatus.Visible = true;
                qmInstance.frm.DisableOptionsGame((DataGridView)frmMain.ActiveForm.Controls["dgvSource"]);
                var incrementValue = Convert.ToInt32(i / 333);
                if (incrementValue >= 100)
                {
                    qmInstance.pbInstallStatus.Style = ProgressBarStyle.Marquee;
                    qmInstance.lblInstallStatusPercent.Hide();
                    qmInstance.lblInstallStatusText.Text = Resources.InstallGameScrub_Scrubbing +
                                                           " -- This is taking a while, but we are still responding.";
                    qmInstance.pbInstallStatus.Value = qmInstance.pbInstallStatus.Maximum;
                }
                else
                {
                    qmInstance.pbInstallStatus.Style = ProgressBarStyle.Continuous;
                   qmInstance.lblInstallStatusPercent.Show();
                   qmInstance.lblInstallStatusPercent.Text = incrementValue + "%"; //i++.ToString() + "%";
                    qmInstance.lblInstallStatusText.Show();
                    qmInstance.lblInstallStatusText.Text = Resources.InstallGameScrub_Scrubbing;
                    qmInstance.pbInstallStatus.Value = incrementValue;
                }
            });
        }

        private void UpdateProgressScrubDisc2(string title, int i)
        {
            frmMain.ActiveForm.Controls["tabMainFile"].BeginInvoke(() =>
            {
                //Make sureqmInstance.pbInstallStatus. is Continuous
               qmInstance.lblInstallStatusGameIndex.Visible = true;
               qmInstance.lblInstallStatusGameTitle.Visible = true;
                qmInstance.lblInstallStatusText.Visible = true;
               qmInstance.lblInstallStatusPercent.Visible = true;
               qmInstance.lblInstallStatusGameTitle.Text = title;
               qmInstance.pbInstallStatus.Visible = true;
               qmInstance.frm.DisableOptionsGame((DataGridView)frmMain.ActiveForm.Controls["dgvSource"]);
                if (i >= 100)
                {
                   qmInstance.pbInstallStatus.Style = ProgressBarStyle.Marquee;
                   qmInstance.lblInstallStatusPercent.Hide();
                    qmInstance.lblInstallStatusText.Text = string.Format(Resources.InstallGameScrub_TransferDisc2, title) +
                                                " -- This is taking a while, but we are still responding.";
                   qmInstance.pbInstallStatus.Value =qmInstance.pbInstallStatus.Maximum;
                }
                else
                {
                   qmInstance.pbInstallStatus.Style = ProgressBarStyle.Continuous;
                   qmInstance.lblInstallStatusPercent.Show();
                   qmInstance.lblInstallStatusPercent.Text = i + "%"; //i++.ToString() + "%";
                    qmInstance.lblInstallStatusText.Show();
                    qmInstance.lblInstallStatusText.Text = string.Format(Resources.InstallGameScrub_TransferDisc2, title);
                   qmInstance.pbInstallStatus.Value = i;
                }
            });
        }

        #endregion


        #region Exact Copy


        #region This part writes the file

        //InstallGameExactCopy(row);
        private static void InstallGameExactCopy(string path)
        {
            //Make sure pbCopy is Continuous
            qmInstance.pbInstallStatus.Style = ProgressBarStyle.Continuous;
            qmInstance.btnAbort.Visible = true;
            qmInstance.lblAbort.Visible = true;
            if (intQueuePos <= qmInstance.InstallQueue.Count - 1 && !blnAbort)
            {
                var _file = new sio.FileInfo(path);
                int? selectedRowCount = Convert.ToInt32(((DataGridView)frmMain.ActiveForm.Controls["dgvSource"]).Rows.GetRowCount(DataGridViewElementStates.Selected));

                if (((DataGridView)frmMain.ActiveForm.Controls["dgvSource"]).RowCount == 0)
                    Notifications.EmptyGamesList();
                else if (selectedRowCount > 0)
                    try
                    {
                        blnQueueRunning = true;

                        // Removes blank spaces
                        //string ret = Regex.Replace(txtGameTitle.Text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ\s]+?", string.Empty);
                        // Removes whitespace
                        //string ret = Regex.Replace(txtGameTitle.Text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+?", string.Empty);
                        // Replaces
                        //string _SwapCharacter = tbIDName.Text.Replace(" disc1", "").Replace(" disc2", "").Replace(" 1", "").Replace(" 2", "")
                        //.Replace(" (2)", "").Replace(":", " - ").Replace(";", " - ").Replace(",", " - ")
                        //.Replace(" -  ", " - ").Replace(" FOR NINTENDO GAMECUBE", "").Replace(" GameCube", "");
                        // Nome do jogo
                        var _SwapCharacter = qmInstance.InstallQueue[intQueuePos].Title.Replace(":", " - ").Replace(";", " - ")
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
                            new sio.FileInfo(sio.Path.Combine(qmInstance.frm.fbdSourceFolderDialog.SelectedPath, qmInstance.InstallQueue[intQueuePos].Path));

                        // Disc 1 (0 -> 0) - Title [ID Game]
                        if (qmInstance.InstallQueue[intQueuePos].DiscID == "0x00" && Program.ConfigFile.IniReadInt("SEVERAL", "AppointmentStyle") == 0)
                        {
                            if (!sio.Directory.Exists(frmMain.SelectedDrive + GAMES_DIR +
                                                      sio.Path.DirectorySeparatorChar +
                                                      _SwapCharacter + " [" + qmInstance.InstallQueue[intQueuePos].ID + "]"))
                                sio.Directory.CreateDirectory(frmMain.SelectedDrive + GAMES_DIR +
                                                              sio.Path.DirectorySeparatorChar +
                                                              _SwapCharacter + " [" + qmInstance.InstallQueue[intQueuePos].ID + "]");
                            var _destination = new sio.FileInfo(frmMain.SelectedDrive + GAMES_DIR +
                                                                sio.Path.DirectorySeparatorChar +
                                                                _SwapCharacter + " [" + qmInstance.InstallQueue[intQueuePos].ID +
                                                                "]" + sio.Path.DirectorySeparatorChar + "game.iso");
                            oldCopyTask(_source, _destination);
                        } // Disc 2 (1 -> 0) - Title [ID Game]
                        else if (qmInstance.InstallQueue[intQueuePos].DiscID == "0x01" &&
                                 Program.ConfigFile.IniReadInt("SEVERAL", "AppointmentStyle") == 0)
                        {
                            if (!sio.Directory.Exists(frmMain.SelectedDrive + GAMES_DIR +
                                                      sio.Path.DirectorySeparatorChar +
                                                      _SwapCharacter + " [" + qmInstance.InstallQueue[intQueuePos].ID + "]"))
                                sio.Directory.CreateDirectory(frmMain.SelectedDrive + GAMES_DIR +
                                                              sio.Path.DirectorySeparatorChar +
                                                              _SwapCharacter + " [" + qmInstance.InstallQueue[intQueuePos].ID + "]");
                            var _destination = new sio.FileInfo(frmMain.SelectedDrive + GAMES_DIR +
                                                                sio.Path.DirectorySeparatorChar +
                                                                _SwapCharacter + " [" + qmInstance.InstallQueue[intQueuePos].ID +
                                                                "]" + sio.Path.DirectorySeparatorChar + "disc2.iso");
                            oldCopyTask(_source, _destination);
                        } // Disc 1 (0 -> 1) - [ID Game]
                        else if (qmInstance.InstallQueue[intQueuePos].DiscID == "0x00" &&
                                 Program.ConfigFile.IniReadInt("SEVERAL", "AppointmentStyle") == 1)
                        {
                            if (!sio.Directory.Exists(frmMain.SelectedDrive + GAMES_DIR +
                                                      sio.Path.DirectorySeparatorChar + "[" +
                                                      qmInstance.InstallQueue[intQueuePos].ID + "]"))
                                sio.Directory.CreateDirectory(frmMain.SelectedDrive + GAMES_DIR +
                                                              sio.Path.DirectorySeparatorChar + "[" +
                                                              qmInstance.InstallQueue[intQueuePos].ID + "]");
                            var _destination = new sio.FileInfo(frmMain.SelectedDrive + GAMES_DIR +
                                                                sio.Path.DirectorySeparatorChar + "[" +
                                                                qmInstance.InstallQueue[intQueuePos].ID + "]" +
                                                                sio.Path.DirectorySeparatorChar + "game.iso");
                            oldCopyTask(_source, _destination);
                        } // Disc 2 (1 -> 1) - [ID Game]
                        else if (qmInstance.InstallQueue[intQueuePos].DiscID == "0x01" &&
                                 Program.ConfigFile.IniReadInt("SEVERAL", "AppointmentStyle") == 1)
                        {
                            if (!sio.Directory.Exists(frmMain.SelectedDrive + GAMES_DIR +
                                                      sio.Path.DirectorySeparatorChar + "[" +
                                                      qmInstance.InstallQueue[intQueuePos].ID + "]"))
                                sio.Directory.CreateDirectory(frmMain.SelectedDrive + GAMES_DIR +
                                                              sio.Path.DirectorySeparatorChar + "[" +
                                                              qmInstance.InstallQueue[intQueuePos].ID + "]");
                            var _destination = new sio.FileInfo(frmMain.SelectedDrive + GAMES_DIR +
                                                                sio.Path.DirectorySeparatorChar + "[" +
                                                                qmInstance.InstallQueue[intQueuePos].ID + "]" +
                                                                sio.Path.DirectorySeparatorChar +
                                                                "disc2.iso");
                            oldCopyTask(_source, _destination);
                        }
                        // Título [Código do Jogo] -> 0
                        // [Código do Jogo]        -> 1
                    }
                    catch (Exception ex)
                    {
                        ((TextBox)qmInstance.frm.Controls["tbLog"]).AppendText("[" + qmInstance.frm.DateString() + "]" + Resources.Error + ex.Message + Environment.NewLine);
                        ((TextBox)qmInstance.frm.Controls["tbLog"]).AppendText(ex.StackTrace);
                        Notifications.GlobalNotifications(ex.Message, ToolTipIcon.Error);
                    }
            }
            else
            {
                qmInstance.frm.FinishedInstalling();
            }
        }

        #endregion

        #region Copy Task

        /// <summary>
        ///     Function for the copy job.
        /// </summary>
        /// <param name="_source"></param>
        /// <param name="_destination"></param>
        private static void oldCopyTask(sio.FileInfo _source, sio.FileInfo _destination)
        {
            //Make sure pbCopy is Continuous
            qmInstance.pbInstallStatus.Style = ProgressBarStyle.Continuous;
            // Disc 1
            //if (textBoxDiscID.Text == "00" && comboBoxSettingsNomenclatureAppointmentStyle.SelectedIndex  == 0)
            if (qmInstance.InstallQueue[intQueuePos].DiscID == "0x00")
            {
                if (_destination.Exists) _destination.Delete();
                //Create a tast to run copy file
                Task.Run(() =>
                {
                    //_source.CopyTo(_destination, true);
                    _source.CopyTo(_destination, x => qmInstance.pbInstallStatus.BeginInvoke(new Action(() =>
                    {
                        //DisableOptionsGame((DataGridView)frmMain.ActiveForm.Controls["dgvSource"]);
                        qmInstance.frm.Controls["dgvSource"].Enabled = false;
                        qmInstance.pbInstallStatus.Visible = true;
                        qmInstance.lblInstallStatusGameTitle.Visible = true;
                        qmInstance.lblInstallStatusPercent.Visible = true;
                        qmInstance.lblInstallStatusText.Visible = true;
                        if (x < qmInstance.pbInstallStatus.Value)
                            qmInstance.pbInstallStatus.Value = x;
                       qmInstance.lblInstallStatusGameTitle.Text = qmInstance.InstallQueue[intQueuePos].Title;
                        qmInstance.lblInstallStatusText.Text = Resources.CopyTask_String1;
                       qmInstance.lblInstallStatusPercent.Text = x + "%";
                    })));
                }).GetAwaiter().OnCompleted(() =>qmInstance.pbInstallStatus.BeginInvoke(new Action(() =>
                {
                   qmInstance.pbInstallStatus.Maximum = 100;
                   qmInstance.pbInstallStatus.Value = 100;
                   qmInstance.lblInstallStatusGameTitle.Text = Resources.CopyTask_String3;
                    qmInstance.lblInstallStatusText.Text = Resources.CopyTask_String4;
                   qmInstance.lblInstallStatusPercent.Text = Resources.CopyTask_String5;
                    Notifications.GlobalNotifications(Resources.InstallGameScrub_Complete, ToolTipIcon.Info);

                   qmInstance.pbInstallStatus.Visible = false;
                   qmInstance.lblInstallStatusGameTitle.Visible = false;
                   qmInstance.lblInstallStatusPercent.Visible = false;
                    qmInstance.lblInstallStatusText.Visible = false;
                    intQueuePos++;
                    blnQueueRunning = false;
                   qmInstance.frm.EnableOptionsGameList();

                    if (intQueuePos <= qmInstance.InstallQueue.Count - 1)
                    {
                        try
                        {
                            InstallGameExactCopy(qmInstance.InstallQueue[intQueuePos].Path);
                        }
                        catch (Exception ex)
                        {
                            ((TextBox)qmInstance.frm.Controls["tbLog"]).AppendText("[" + DateTime.Now + "] Error Installing: " + Environment.NewLine +
                                             ex.Message + Environment.NewLine);
                            ((TextBox)qmInstance.frm.Controls["tbLog"]).AppendText(ex.StackTrace);
                        }
                    }
                    else
                    {
                       qmInstance.frm.EnableOptionsGameList();
                       qmInstance.frm.Controls["dgvSource"].Enabled = true;
                    }
                })));
            }
            // Disc 2
            else if (qmInstance.InstallQueue[intQueuePos].DiscID == "0x01")
            {
                if (_destination.Exists) _destination.Delete();
                //Create a tast to run copy file
                Task.Run(() =>
                {
                    _source.CopyTo(_destination, x =>qmInstance.pbInstallStatus.BeginInvoke(new Action(() =>
                    {
                        //DisableOptionsGame((DataGridView)frmMain.ActiveForm.Controls["dgvSource"]);
                       qmInstance.pbInstallStatus.Visible = true;
                       qmInstance.lblInstallStatusGameTitle.Visible = true;
                       qmInstance.lblInstallStatusPercent.Visible = true;
                        qmInstance.lblInstallStatusText.Visible = true;
                       qmInstance.pbInstallStatus.Value = x;
                       qmInstance.lblInstallStatusGameTitle.Text = qmInstance.InstallQueue[intQueuePos].Title;
                        qmInstance.lblInstallStatusText.Text = Resources.CopyTask_String2;
                       qmInstance.lblInstallStatusPercent.Text = x + "%";
                    })));
                }).GetAwaiter().OnCompleted(() =>qmInstance.pbInstallStatus.BeginInvoke(new Action(() =>
                {
                   qmInstance.pbInstallStatus.Value = 100;
                    qmInstance.lblInstallStatusText.Text = Resources.CopyTask_String4;
                   qmInstance.lblInstallStatusPercent.Text = Resources.CopyTask_String5;
                    Notifications.GlobalNotifications(Resources.InstallGameScrub_TrasnferredDisc2, ToolTipIcon.Info);
                   qmInstance.pbInstallStatus.Visible = false;
                   qmInstance.lblInstallStatusGameTitle.Visible = false;
                   qmInstance.lblInstallStatusPercent.Visible = false;
                    qmInstance.lblInstallStatusText.Visible = false;
                    intQueuePos++;
                    blnQueueRunning = false;
                    if (intQueuePos <= qmInstance.InstallQueue.Count)
                    {
                        try
                        {
                            InstallGameExactCopy(qmInstance.InstallQueue[intQueuePos].Path);
                        }
                        catch (Exception ex)
                        {
                            ((TextBox)qmInstance.frm.Controls["tbLog"]).AppendText("[" + DateTime.Now + "] Error Installing: " + Environment.NewLine +
                                             ex.Message + Environment.NewLine);
                        }
                    }
                    else
                    {
                       qmInstance.frm.EnableOptionsGameList();
                        ((DataGridView)qmInstance.frm.Controls["dgvSource"]).Enabled = true;
                    }
                })));
            }

           qmInstance.frm.EnableOptionsGameList();
        }

        #endregion




        #endregion
    }
}