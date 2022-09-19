using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCBM.Properties;

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
        public static readonly Dictionary<int, Game> dSourceGames = new();
        public static readonly Dictionary<int, Game> dDestGames = new();
        public static DataGridView dgvSelected = new();
        public string[] GetSelectedGamePaths(DataGridView dgv)
        {
            var result = dgv.Rows.Cast<DataGridViewRow>().Where(x => (bool)x.Cells[0].Value)
                .Select(x => (string)x.Cells[6].Value).ToArray();
            return result;
        }
        #endregion



        #region Build Install Queue




        private string strDestinationDrive;

        /// <summary>
        ///     Get selected games and add them to a queue.
        /// </summary>
        private void BuildInstallQueue(DataGridView dgv)
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


            #region Global Install

    private string InstallType = "";

    /// <summary>
    ///     Global Install
    /// </summary>
    /// <param name="dgv"></param>
    /// <param name="typeInstall"></param>
    private void GlobalInstall(DataGridView dgv, int typeInstall)
    {
        var selectedRowCount = dgv.Rows.GetRowCount(DataGridViewElementStates.Selected);

        if (GetSelectedGamePaths(dgv).Length == 0)
        {
            SelectGameFromList();
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
                    if (typeInstall == 0) // Install Exact Copy
                    {
                        InstallType = "COPY";
                        btnAbort.Visible = true;
                        lblAbort.Visible = true;
                        BuildInstallQueue();
                        DisableOptionsGame(dgvSource);
                        INSTALLING = true;
                        InstallGameExactCopy(InstallQueue[intQueuePos].Path);
                    }
                    else // Install Scrub
                    {
                        StartScrub();
                    }
                }
                catch
                {
                    GlobalNotifications(Resources.Error, ToolTipIcon.Error);
                    // ignored
                }
        }
    }


        #region Start
        /// <summary>
        /// Variables have been set-up, fire up the engine
        /// </summary>
        public void StartQueue(DataGridView dgv, int InstallType)
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

            //Lets Build the Install Queue
            BuildInstallQueue(dgv);

            //if InstallType = 0, we are using Exact Copy method, otherwise, we are using the Scrub method.
            if (InstallType == 0)
            {//Exact Copy
                
            }
            else if (InstallType == 1)
            {
                //Scrub/Trim

            }

            //else ; possibilities..... Nkit?

        }

        /// <summary>
        ///     Informs if it is necessary to select a game from the list.
        /// </summary>
        private static void SelectGameFromList()
        {
            _ = MessageBox.Show(Resources.SelectGameFromList, Resources.Information, MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// </summary>
        private void SelectTargetDrive()
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




    }
}
