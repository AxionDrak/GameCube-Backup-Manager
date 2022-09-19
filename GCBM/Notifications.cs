using GCBM.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using sio = System.IO;
namespace GCBM
{
    internal class Notifications
    {
        public static NotifyIcon notifyIcon = new NotifyIcon(frmMain.mainContainer);

        #region Notifications

        /// <summary>
        ///     Global Notifications
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        public static void GlobalNotifications(string message, ToolTipIcon icon)
        {
            if (Program.ConfigFile.IniReadBool("SEVERAL", "CheckNotify"))
            {

                notifyIcon.ShowBalloonTip(5, "GameCube Backup Manager", message, icon);
            }
        }
        public const string WIITDB_FILE = "wiitdb.xml";
        /// <summary>
        ///     Informs if the file list is empty.
        /// </summary>
        public static void EmptyGamesList()
        {
            _ = MessageBox.Show(Resources.EmptyGamesList, Resources.Information, MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }


        /// <summary>
        ///     Informs about deleting files.
        ///     This procedure is irreversible.
        /// </summary>
        /// <returns></returns>
        public static DialogResult DialogResultDeleteGame()
        {
            var dr = MessageBox.Show(Resources.DialogResultDeleteGame_ReallyDeleteFile_String1 + Environment.NewLine +
                                     Environment.NewLine + Resources.DialogResultDeleteGame_ReallyDeleteFile_String2,
                Resources.Notice, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return dr;
        }

        /// <summary>
        ///     It informs you about the need to configure the USB Loader GX and WiiFlow cover transfer system.
        /// </summary>
        public static void CheckUSBGXFlow()
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

        /// <summary>
        /// </summary>
        public async static void CheckWiiTdbXml()
        {
            await Task.Delay(5000).ConfigureAwait(false);
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
        public static void InvalidDrive(string typeDrive)
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
        public static void ListHash(string typehash, string listhash)
        {
            _ = MessageBox.Show(Resources.ListHash_String1 + typehash + Resources.ListHash_String2 + Environment.NewLine +
                                Environment.NewLine
                                + listhash, Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

    }
}
