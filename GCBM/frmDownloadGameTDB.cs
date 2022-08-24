using GCBM.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM
{
    public partial class frmDownloadGameTDB : Form
    {
        private const string WIITDB_FILE = "wiitdb.xml";
        private const string WIITDB_ZIP_FILE = "wiitdb.zip";

        private const int MF_BYPOSITION = 0x400;
        private static readonly string GET_CURRENT_PATH = Directory.GetCurrentDirectory();
        private static readonly string DOWNLOAD_FILE = Resources.DownloadingWiiTDB_String1;
        private static readonly string EXTRACT_FILE = Resources.DownloadingWiiTDB_String2;
        private static readonly string PROCESS_COMPLETED = Resources.DownloadingWiiTDB_String3;

        public frmDownloadGameTDB()
        {
            InitializeComponent();

            btnCancelWork.Enabled = false;
            GameTDB();
        }

        public int RETURN_CONFIRM { get; set; }

        private void GameTDB()
        {
            try
            {
                var webClient = new WebClient();
                webClient.DownloadFileCompleted += Completed;
                webClient.DownloadProgressChanged += ProgressChanged;
                webClient.DownloadFileAsync(new Uri("https://www.gametdb.com/wiitdb.zip"), WIITDB_ZIP_FILE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GameTDBSynchronous()
        {
            try
            {
                var webClient = new WebClient();
                webClient.DownloadFile(new Uri("https://www.gametdb.com/wiitdb.zip"), WIITDB_ZIP_FILE);

                try
                {
                    ZipFile.ExtractToDirectory(GET_CURRENT_PATH + @"\" + WIITDB_ZIP_FILE, GET_CURRENT_PATH);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                finally
                {
                    File.Delete(GET_CURRENT_PATH + @"\" + WIITDB_ZIP_FILE);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            lblDownload.Font = new Font(lblDownload.Font, FontStyle.Bold);
            lblDownload.Text = DOWNLOAD_FILE + e.ProgressPercentage + "%";
            pbGameTDB.Value = e.ProgressPercentage;
        }

        private async void Completed(object sender, AsyncCompletedEventArgs e)
        {
            lblExtracting.Font = new Font(lblExtracting.Font, FontStyle.Bold);
            lblExtracting.Text = EXTRACT_FILE;

            try
            {
                ZipFile.ExtractToDirectory(GET_CURRENT_PATH + Path.DirectorySeparatorChar + WIITDB_ZIP_FILE, GET_CURRENT_PATH);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                File.Delete(GET_CURRENT_PATH + Path.DirectorySeparatorChar + WIITDB_ZIP_FILE);

                await ProcessTaskDelay().ConfigureAwait(false);
                var fileinfo = new FileInfo(GET_CURRENT_PATH + Path.DirectorySeparatorChar + WIITDB_FILE);
                if (fileinfo.Length >= 31035000) //31035596
                {
                    lblConverting.Font = new Font(lblConverting.Font, FontStyle.Bold);
                    lblConverting.Text = PROCESS_COMPLETED;
                    btnCancelWork.Enabled = true;
                }
            }
        }

        private async Task ProcessTaskDelay()
        {
            await Task.Delay(5000).ConfigureAwait(false);
        }

        private void btnCancelWork_Click(object sender, EventArgs e)
        {
            //SaveConfigFile();

            //MessageBox.Show("Deseja mesmo sair?", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            RETURN_CONFIRM = 1;
            Close();
            Dispose();
        }

        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);

        private void frmDownloadGameTDB_Load(object sender, EventArgs e)
        {
            var hMenu = GetSystemMenu(Handle, false);
            var MenuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);
        }
    }
}