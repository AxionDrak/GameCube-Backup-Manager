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

namespace GCBM;

public partial class frmDownloadGameTDB : Form
{
    private const string WIITDB_FILE = "wiitdb.xml";
    private const string WIITDB_ZIP_FILE = "wiitdb.zip";

    private const int MF_BYPOSITION = 0x400;
    private static readonly string GET_CURRENT_PATH = Directory.GetCurrentDirectory();
    private static readonly string DOWNLOAD_FILE = Resources.DownloadingWiiTDB_String1;
    private static readonly string EXTRACT_FILE = Resources.DownloadingWiiTDB_String2;

    public frmDownloadGameTDB()
    {
        InitializeComponent();

        GameTDB();
    }

    public int RETURN_CONFIRM { get; set; }

    public async void GameTDB()
    {
        try
        {
            var webClient = new WebClient();
            webClient.DownloadFileCompleted += Completed;
            webClient.DownloadProgressChanged += ProgressChanged;
            webClient.DownloadFileAsync(new Uri("https://www.gametdb.com/wiitdb.zip"), WIITDB_ZIP_FILE);
            if (File.Exists(WIITDB_FILE))
                await Task.Run(() =>
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

                }).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _ = MessageBox.Show(ex.Message);
        }
    }

    public static async void GameTDBAsynchronous()
    {
        try
        {
            await Task.Run(() =>
            {

                var webClient = new WebClient();
                webClient.DownloadFileAsync(new Uri("https://www.gametdb.com/wiitdb.zip"), WIITDB_ZIP_FILE);

                try
                {
                    bool deleteFile = File.Exists(WIITDB_FILE);
                    try
                    {
                        if (deleteFile) File.Delete(GET_CURRENT_PATH + @"\" + WIITDB_FILE);
                        ZipFile.ExtractToDirectory(GET_CURRENT_PATH + @"\" + WIITDB_ZIP_FILE, GET_CURRENT_PATH);
                    }
                    catch (Exception ex)
                    {
                        _ = MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        File.Delete(GET_CURRENT_PATH + @"\" + WIITDB_ZIP_FILE);
                    }
                    //}
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                }
                finally
                {
                    File.Delete(GET_CURRENT_PATH + @"\" + WIITDB_ZIP_FILE);
                }

            }).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _ = ex.Message;
        }
    }

    private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        lblDownload.Font = new Font(lblDownload.Font, FontStyle.Bold);
        lblDownload.Text = DOWNLOAD_FILE + e.ProgressPercentage + "%";
        pbGameTDB.Value = e.ProgressPercentage;
        Application.DoEvents();
    }


    private async void Completed(object sender, AsyncCompletedEventArgs e)
    {
        lblExtracting.Font = new Font(lblExtracting.Font, FontStyle.Bold);
        lblExtracting.Text = EXTRACT_FILE;

        try
        {
            ZipFile.ExtractToDirectory(GET_CURRENT_PATH + Path.DirectorySeparatorChar + WIITDB_ZIP_FILE,
                GET_CURRENT_PATH);
        }
        catch (Exception ex)
        {
            _ = MessageBox.Show(ex.Message);
        }
        finally
        {
            await ProcessTaskDelay().ConfigureAwait(false);
            File.Delete(GET_CURRENT_PATH + Path.DirectorySeparatorChar + WIITDB_ZIP_FILE);

            var fileinfo = new FileInfo(GET_CURRENT_PATH + Path.DirectorySeparatorChar + WIITDB_FILE);
            if (fileinfo.Length >= 31035000) //31035596
            {
                //lblConverting.Font = new Font(lblConverting.Font, FontStyle.Bold);
                //lblConverting.Text = PROCESS_COMPLETED;
                //btnCancelWork.Enabled = true;
                DialogResult = DialogResult.OK;
                RETURN_CONFIRM = 1;
            }

            GC.Collect();
        }
    }

    private async Task ProcessTaskDelay()
    {
        await Task.Delay(2500);
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
        _ = RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);
    }
}