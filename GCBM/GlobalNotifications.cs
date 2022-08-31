using GCBM.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using sio = System.IO;

namespace GCBM
{
    internal class GlobalNotifications
    {
        #region Constants
        private const string WIITDB_FILE = "wiitdb.xml";
        private const string WIITDB_DOWNLOAD_SITE = "https://www.gametdb.com/";
        private const string en_US = "en-US";
        private const string INI_FILE = "config.ini";


        private readonly IniFile CONFIG_INI_FILE = new IniFile(INI_FILE);

        #endregion

        #region Statics

        #region Imports
        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        #endregion

        #endregion

        #region Fields
        private NotifyIcon icon;
        #endregion

        #region Properties
        public bool WiiTDBDownloadSuccessfull { get; set; }

        public NotifyIcon nIcon
        {

            get
            {
                //Convert BMP to ICO because.. I'm probably stupid, and VS isn't playing fair
                IntPtr i = Resources.gcbm.GetHicon();
                icon.Icon = Icon.FromHandle(i);
                return icon;
            }
            set { icon = value; }
        }

        #endregion


        #region Methods


        /// <summary>
        ///     Global Notifications
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        public void Tell(string message, ToolTipIcon icon)
        {

            nIcon.ShowBalloonTip(5, "GameCube Backup Manager", message, icon);
        }
        #region Notifications



        /// <summary>
        /// Check for WiiTDB.xml.
        ///     if not found:   
        ///         Inform the user, and ask them if they want to download the file.
        /// </summary>
        public async void CheckAndDownloadWiiTdbXml()
        {

            if (sio.File.Exists(WIITDB_FILE))
            {
                return;
            }

            if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "NetVerify"))
            {

                //frmDownloadGameTDB.GameTDBAsynchronous();
                //await ProcessTaskDelay();
                //Monitor.Exit(lvDatabase);

                //Ask the user via Dialog if they want to download, if Yes, run a new frmDownloadGameTDB in a task, and wait for it to finish
                DialogResult result = MessageBox.Show(Resources.AskDownloadWiiTDB, Resources.ProcessTaskDelay_String1, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await Task.Run(() => Application.Run(new frmDownloadGameTDB()));
                }
                if (sio.File.Exists(WIITDB_FILE))
                {
                    WiiTDBDownloadSuccessfull = true;
                }
            }

            CheckWiiTdbXml();
        }

        /// <summary>
        /// </summary>
        public async void CheckWiiTdbXml()
        {
            await Task.Delay(5000);
            _ = MessageBox.Show(Resources.ProcessTaskDelay_String1 + Environment.NewLine +
                            Resources.ProcessTaskDelay_String2 +
                            Environment.NewLine + Environment.NewLine +
                            Resources.ProcessTaskDelay_String3 +
                            Environment.NewLine + Environment.NewLine +
                            Resources.ProcessTaskDelay_String4,
                Resources.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        #endregion
        #endregion

    }
}
