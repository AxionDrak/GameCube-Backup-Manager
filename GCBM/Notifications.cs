using GCBM.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM
{
    internal class Notifications
    {
        public NotifyIcon notifyIcon = new NotifyIcon(container: frmMain.frmMainInstance);

        #region Notifications

        /// <summary>
        ///     Global Notifications
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        private void GlobalNotifications(string message, ToolTipIcon icon)
    {
        if (Program.ConfigFile.IniReadBool("SEVERAL", "CheckNotify"))
        {
            if (QueueManager.intQueuePos + 1 == QueueManager.InstallQueue.Count && QueueManager.blnQueueRunning == false) EnableOptionsGameList();

            notifyIcon.ShowBalloonTip(5, "GameCube Backup Manager", message, icon);
        }
    }

    /// <summary>
    ///     Informs if the file list is empty.
    /// </summary>
    private static void EmptyGamesList()
    {
        _ = MessageBox.Show(Resources.EmptyGamesList, Resources.Information, MessageBoxButtons.OK,
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
        _ = MessageBox.Show(Resources.CheckUSBGXFlow_String1 +
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
        if (sio.File.Exists(WIITDB_FILE)) return;

        if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "NetVerify"))
        {
            if (!Monitor.TryEnter(lvDatabase)) Process.GetCurrentProcess().Kill();

            //frmDownloadGameTDB.GameTDBAsynchronous();
            //await ProcessTaskDelay();
            //Monitor.Exit(lvDatabase);

            //Ask the user via Dialog if they want to download, if Yes, run a new frmDownloadGameTDB in a task, and wait for it to finish
            Show();
            Activate();
            var result = MessageBox.Show(Resources.AskDownloadWiiTDB, Resources.ProcessTaskDelay_String1,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var dl = new frmDownloadGameTDB();
                dl.ShowDialog();
                await Delay(5000).ConfigureAwait(false);
            }

            if (sio.File.Exists(WIITDB_FILE))
            {
                try
                {
                    LoadDatabaseXML();
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
        _ = MessageBox.Show(Resources.ProcessTaskDelay_String1 + Environment.NewLine +
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
        _ = MessageBox.Show(Resources.InvalidDrive_String1 + Environment.NewLine +
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
        _ = MessageBox.Show(Resources.ListHash_String1 + typehash + Resources.ListHash_String2 + Environment.NewLine +
                            Environment.NewLine
                            + listhash, Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    #endregion

    }
}
