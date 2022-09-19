using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace GCBM;

public partial class frmSplashScreen : Form
{
    #region Main Form

    public frmSplashScreen()
    {
        var configIniFile = Program.ConfigFile;
        Program.AdjustLanguage(Thread.CurrentThread);

        InitializeComponent();

        CurrentYear();

        Thread t = new Thread(() => Application.Run(new frmMain(new Action<string, int>((s, i) =>
        {
            pbSplashScreen.Invoke(new Action(() => pbSplashScreen.Value = i));
            lblStartSplashScreen.Invoke(new Action(() => lblStartSplashScreen.Text = s));
        }))));
        t.SetApartmentState(ApartmentState.STA);
        Program.AdjustLanguage(t);
        t.Start();
    }

    #endregion

    #region Adjust Language



    #endregion

    #region Current Year

    private void CurrentYear()
    {
        var _currentYear = DateTime.Now;
        tsslCurrentYear.Text = "Copyright © 2019 - " + _currentYear.Year + " Laete Meireles";
    }

    #endregion
    #region Update Progress Internal

    #endregion

    #region Update Progress

    public void UpdateProgress(int progress)
    {
        try
        {
            _ = Invoke(del, progress);
        }
        catch (Exception ex)
        {
            //not implemented!
            _ = MessageBox.Show(ex.Message);
        }
    }

    #endregion

    private void frmSplashScreen_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (Process.GetCurrentProcess().GetChildProcesses() != null &&
            Process.GetCurrentProcess().GetChildProcesses().Count != 0)
            foreach (var process in Process.GetCurrentProcess().GetChildProcesses())
                //Kill GCIT and others
                process.Kill();
        //Garbage collector
        GC.Collect();
        //Cleanup any Threads left lying around
    }

    #region Properties

    private const string INI_FILE = "config.ini";
    private readonly IniFile CONFIG_INI_FILE = new(INI_FILE);

    private delegate void ProgressDelegate(int progress);

    private readonly ProgressDelegate del;

    #endregion

    private void frmSplashScreen_Load(object sender, EventArgs e)
    {
    }
}