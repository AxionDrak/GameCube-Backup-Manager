using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCBM.Properties;
using sio = System.IO;
namespace GCBM
{
    /// <summary>
    /// Class to facilitate working with the Queue
    /// </summary>
    internal class QueueManager
    {

        #region Variables

        public static Dictionary<int, Game> InstallQueue = new Dictionary<int, Game>();
        public static int intQueuePos = 0;
        public static int intQueueCount = 0;
        public static bool blnQueuePaused = false;
        public static bool blnQueueFinished = false;
        public static bool blnQueueError = false;
        public static bool blnQueueErrorHandledByUser = false;
        public static bool blnQueueErrorHandledByProgram = false;
        public static bool blnQueueRunning = false;
        public static bool blnAbort = false;
        public static readonly Dictionary<int, Game> dSourceGames = new();
        public static readonly Dictionary<int, Game> dDestGames = new();
        public static DataGridView dgvSelected = new();

        private static string FLUSH_SD;
        private static string SCRUB_ALIGN;
        public GroupBox grpStatus = frmMain.StatusGroupBox;
        private static Label lblAbort, lblInstallStatusGameTitle, lblInstallStatusGameIndex, lblInstallStatusText, lblInstallStatusPercent;//, lblInstallStatusTime, lblInstallStatusETA, lblInstallStatusSpeed;
        private static Button btnAbort;
        private static ProgressBar pbInstallStatus;

        public static string[] GetSelectedGamePaths(DataGridView dgv)
        {
            var result = dgv.Rows.Cast<DataGridViewRow>().Where(x => (bool)x.Cells[0].Value)
                .Select(x => (string)x.Cells[6].Value).ToArray();
            return result;
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



        #region Build Install Queue




        public static string strDestinationDrive;

        /// <summary>
        ///     Get selected games and add them to a queue.
        /// </summary>
        public static void BuildInstallQueue(DataGridView dgv)
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

            foreach (var path in GetSelectedGamePaths(dgv))
            {
                var g = dSourceGames.AsParallel().First(x => x.Value.Path == path)
                    .Value; //Ensure we are talking about the same file not just the same game

                InstallQueue.Add(num, g);
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

                        BuildInstallQueue(dgv);
                        //Light the fire
                    }
                    catch
                    {

                    }
                else // Install Scrub
                {
                    StartScrub(dgv,installType,controlsBox);
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
            DisableOptionsGame(dgvDestination);
            btnblnAbort.Visible = true;
            lblblnAbort.Visible = true;
            intQueuePos = 0;
            DisableOptionsGame(dgvSource);
            QueueManager.BuildInstallQueue(dgvSource);
            foreach (var game in QueueManager.InstallQueue.Values)
                if (!blnAbort)
                    await InstallGameScrub(QueueManager.InstallQueue[intQueuePos]).ConfigureAwait(false);

            var d2counter = 0;
            foreach (var game in _listSecondDiscs)
            {
                d2counter++;
                lblInstallStatusText.Text = Resources.InstallGameScrub_TransferDisc2;
                lblInstallStatusGameTitle.Text = game.Title;
                lblInstallStatusGameIndex.Text = d2counter.ToString();
                await RenameDisc2(game).ConfigureAwait(false);
            }

            Notifications.GlobalNotifications("Successfully installed " + QueueManager.InstallQueue.Count + " games.", ToolTipIcon.Info);
            pbInstallStatus.BeginInvoke(() =>
            {
                pbInstallStatus.Hide();
                lblInstallStatusPercent.Hide();
                lblInstallStatusText.Hide();
                lblInstallStatusGameTitle.Hide();
            });

        }


        #region Install Game Scrub

        private readonly Stopwatch scrubStopwatch = new();

        /// <summary>
        ///     Function to install an copy of the file in Scrub mode.
        /// </summary>
        private async Task InstallGameScrub(Game game, GroupBox controlsBox)
        {




            scrubStopwatch.Stop();
            scrubStopwatch.Reset();
            QueueManager.InstallType = "SCRUB";
            pbInstallStatus.Style = ProgressBarStyle.Continuous;
            if (blnblnAbort)
                return; //I know we already checked, but just in case.. one more time just to be extra careful. We are writing data after all.
            const string quote = "\"";
            var _source = game.Path;

            // GCIT

            //setup vars


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
                    pbInstallStatus.Visible = true;
                    lblInstallStatusPercent.Text = "100%";
                    pbInstallStatus.Value = 100;
                    lblInstallStatusText.Text = Resources.InstallGameScrub_DoneScrubbing;
                    var game = QueueManager.InstallQueue[intQueuePos];
                    CheckDisc1Or2Scrub(game).ConfigureAwait(false);

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
            while (!myProcess.HasExited && !blnAbort)
            {
                UpdateProgressScrub(scrubStopwatch.ElapsedMilliseconds);
                Application.DoEvents();
            }
        }

        #endregion
        private async Task CheckDisc1Or2Scrub(Game game)
        {
            #region Disc 1

            if (game.DiscID == "0x00")
                if (useXmlTitle)
                {
                    var myOrigem = SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                   game.InternalName +
                                   " [" + game.ID + "]" +
                                   sio.Path.DirectorySeparatorChar + "game.iso";

                    var _SwapCharacter = game.Title.Replace(":", " - ").Replace(";", " - ").Replace(",", " - ")
                        .Replace(" -  ", " - ").Replace("/", "&");

                    var myDestiny = SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
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
                    var Source = new sio.DirectoryInfo(SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                       game.InternalName + " [" + game.ID + "]");
                    var Destination = new sio.DirectoryInfo(SelectedDrive + GAMES_DIR +
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
                            Notifications.GlobalNotifications(ex.Message, ToolTipIcon.Error);
                        }
                    }).ContinueWith(task =>
                    {
                        Notifications.GlobalNotifications(Resources.InstallGameScrub_GameInstalled, ToolTipIcon.Info);

                        //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabMainFile.BeginInvoke(() =>
                        {
                            lblInstallStatusGameTitle.Visible = false;
                            lblInstallStatusGameIndex.Visible = false;
                            lblInstallStatusText.Visible = false;
                            lblInstallStatusPercent.Visible = false;
                            pbInstallStatus.Visible = false;
                        });
                        //GC.Collect();
                        //Delete folder at   SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
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
                var myOrigem = SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                               game.InternalName +
                               " [" + game.ID + "]" +
                               sio.Path.DirectorySeparatorChar + "game.iso";

                var _SwapCharacter = game.Title.Replace(":", " - ").Replace(";", " - ").Replace(",", " - ")
                    .Replace(" -  ", " - ").Replace("/", "&");

                var myDestiny = SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
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
                var Source = new sio.DirectoryInfo(SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                   game.InternalName + " (2) [" + game.ID + "2]");
                var Destination = new sio.DirectoryInfo(SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
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
                            Notifications.GlobalNotifications(ex.Message, ToolTipIcon.Error);
                        }

                    else
                        Source.MoveTo(Destination.FullName);
                }).ContinueWith(task =>
                {
                    Notifications.GlobalNotifications(Resources.InstallGameScrub_GameInstalled, ToolTipIcon.Info);

                    //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabMainFile.BeginInvoke(() =>
                    {
                        lblInstallStatusGameTitle.Visible = false;
                        lblInstallStatusGameIndex.Visible = false;
                        lblInstallStatusText.Visible = false;
                        lblInstallStatusPercent.Visible = false;
                        pbInstallStatus.Visible = false;
                    });

                    //GC.Collect();
                    //Delete folder at   SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
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
                var Source = new sio.DirectoryInfo(SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
                                                   game.InternalName + " (2) [" + game.ID + "2]");
                var Destination = new sio.DirectoryInfo(SelectedDrive + GAMES_DIR + sio.Path.DirectorySeparatorChar +
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
                            Notifications.GlobalNotifications(ex.Message, ToolTipIcon.Error);
                        }
                    else
                        Source.MoveTo(Destination.FullName);
                }).ContinueWith(task =>
                {
                    Notifications.GlobalNotifications(Resources.InstallGameScrub_GameInstalled, ToolTipIcon.Info);

                    //MessageBox.Show(GCBM.Properties.Resources.InstallGameScrub_String6, GCBM.Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabMainFile.BeginInvoke(() =>
                    {
                        lblInstallStatusGameTitle.Visible = false;
                        lblInstallStatusGameIndex.Visible = false;
                        lblInstallStatusText.Visible = false;
                        lblInstallStatusPercent.Visible = false;
                        pbInstallStatus.Visible = false;
                    });
                }).ConfigureAwait(false);
            }
        }

        private readonly List<Game> _listSecondDiscs = new();

        private void UpdateProgressScrub(long i)
        {
            tabMainFile.BeginInvoke(() =>
            {
                //Make sure pbInstallStatus is Continuous
                lblInstallStatusGameTitle.Visible = true;
                lblInstallStatusText.Visible = true;
                lblInstallStatusPercent.Visible = true;
                lblInstallStatusGameTitle.Text = QueueManager.InstallQueue[intQueuePos].Title;
                lblInstallStatusGameIndex.Text = intQueuePos + "  /  " + QueueManager.InstallQueue.Count;
                pbInstallStatus.Visible = true;
                DisableOptionsGame(dgvSource);
                var incrementValue = Convert.ToInt32(i / 333);
                if (incrementValue >= 100)
                {
                    pbInstallStatus.Style = ProgressBarStyle.Marquee;
                    lblInstallStatusPercent.Hide();
                    lblInstallStatusText.Text = Resources.InstallGameScrub_Scrubbing +
                                                " -- This is taking a while, but we are still responding.";
                    pbInstallStatus.Value = pbInstallStatus.Maximum;
                }
                else
                {
                    pbInstallStatus.Style = ProgressBarStyle.Continuous;
                    lblInstallStatusPercent.Show();
                    lblInstallStatusPercent.Text = incrementValue + "%"; //i++.ToString() + "%";
                    lblInstallStatusText.Show();
                    lblInstallStatusText.Text = Resources.InstallGameScrub_Scrubbing;
                    pbInstallStatus.Value = incrementValue;
                }
            });
        }

        private void UpdateProgressScrubDisc2(string title, int i)
        {
            tabMainFile.BeginInvoke(() =>
            {
                //Make sure pbInstallStatus is Continuous
                lblInstallStatusGameIndex.Visible = true;
                lblInstallStatusGameTitle.Visible = true;
                lblInstallStatusText.Visible = true;
                lblInstallStatusPercent.Visible = true;
                lblInstallStatusGameTitle.Text = title;
                pbInstallStatus.Visible = true;
                DisableOptionsGame(dgvSource);
                if (i >= 100)
                {
                    pbInstallStatus.Style = ProgressBarStyle.Marquee;
                    lblInstallStatusPercent.Hide();
                    lblInstallStatusText.Text = string.Format(Resources.InstallGameScrub_TransferDisc2, title) +
                                                " -- This is taking a while, but we are still responding.";
                    pbInstallStatus.Value = pbInstallStatus.Maximum;
                }
                else
                {
                    pbInstallStatus.Style = ProgressBarStyle.Continuous;
                    lblInstallStatusPercent.Show();
                    lblInstallStatusPercent.Text = i + "%"; //i++.ToString() + "%";
                    lblInstallStatusText.Show();
                    lblInstallStatusText.Text = string.Format(Resources.InstallGameScrub_TransferDisc2, title);
                    pbInstallStatus.Value = i;
                }
            });
        }

        #endregion



    }
}