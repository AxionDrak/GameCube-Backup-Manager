using GCBM.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM
{
    public class DownloadWiiTDBHeadless

    {


        #region Constants
        /// <summary>
        /// Constants
        /// </summary>
        private const string WIITDB_FILE = "wiitdb.xml";
        private const string WIITDB_ZIP_FILE = "wiitdb.zip";
        private const int MF_BYPOSITION = 0x400;
        #endregion

        #region Statics
        /// <summary>
        /// Statics
        /// </summary>
        private static readonly string GET_CURRENT_PATH = Directory.GetCurrentDirectory();
        private static readonly string DOWNLOAD_FILE = Resources.DownloadingWiiTDB_String1;
        private static readonly string EXTRACT_FILE = Resources.DownloadingWiiTDB_String2;
        private static readonly string PROCESS_COMPLETED = Resources.DownloadingWiiTDB_String3;
        #endregion


        #region Properties
        /// <summary>
        /// Properties
        /// </summary>
        public bool Success { get; set; }
        #endregion

        private BackgroundWorker worker;



        public event EventHandler TaskCompleted;

        public void Run()

        {

            this.worker = new BackgroundWorker();

            this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);

            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

            this.worker.RunWorkerAsync();

        }



        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {

            if (this.TaskCompleted != null)

                this.TaskCompleted(this, EventArgs.Empty);

        }


        /// <summary>
        /// Where the actual processing/work happens.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)

        {

            // process data

            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += Completed;
                //webClient.DownloadProgressChanged += ProgressChanged;
                webClient.DownloadFileAsync(new Uri("https://www.gametdb.com/wiitdb.zip"), WIITDB_ZIP_FILE);
                if (File.Exists(WIITDB_FILE))
                {
                    try
                    {
                        File.Delete(GET_CURRENT_PATH + @"\" + WIITDB_FILE);
                        ZipFile.ExtractToDirectory(GET_CURRENT_PATH + @"\" + WIITDB_ZIP_FILE, GET_CURRENT_PATH);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }

            Thread.Sleep(3000);

        }

        //private async void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        //{
            
        //}
        /// <summary>
        /// Event handler that fires upon webClient's completion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Completed(object sender, AsyncCompletedEventArgs e)
        {

            try
            {
                ZipFile.ExtractToDirectory(GET_CURRENT_PATH + Path.DirectorySeparatorChar + WIITDB_ZIP_FILE, GET_CURRENT_PATH);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
            finally
            {


                await Task.Delay(5000);
                File.Delete(GET_CURRENT_PATH + Path.DirectorySeparatorChar + WIITDB_ZIP_FILE);

                FileInfo fileinfo = new FileInfo(GET_CURRENT_PATH + Path.DirectorySeparatorChar + WIITDB_FILE);
                if (fileinfo.Length >= 31035000) //31035596
                {
                    Success = true;
                }
                GC.Collect();
            }

        }

        //[DllImport("User32")]
        //private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        //[DllImport("User32")]
        //private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        //[DllImport("User32")]
        //private static extern int GetMenuItemCount(IntPtr hWnd);

        //private void frmDownloadGameTDB_Load(object sender, EventArgs e)
        //{
        //    IntPtr hMenu = GetSystemMenu(Handle, false);
        //    int MenuItemCount = GetMenuItemCount(hMenu);
        //    _ = RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);
        //}


    }
}
