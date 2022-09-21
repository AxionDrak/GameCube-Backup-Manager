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

        Thread t = new Thread(() => Application.Run(frmMain.MainFormInstance(pbSplashScreen, lblStartSplashScreen)));
        t.SetApartmentState(ApartmentState.STA);
        Program.AdjustLanguage(t);
        t.Start();
    }

    public frmMain GetMainForm()
    {
        frmMain mainForm;
        var configIniFile = Program.ConfigFile;
        Program.AdjustLanguage(Thread.CurrentThread);

        InitializeComponent();
        mainForm = frmMain.MainFormInstance(pbSplashScreen, lblStartSplashScreen);
        CurrentYear();
        Thread t = new Thread(() => Application.Run(mainForm));
        t.SetApartmentState(ApartmentState.STA);
        Program.AdjustLanguage(t);
        t.Start();
        return mainForm;
    }
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

    public delegate void ProgressDelegate(int progress);

    public readonly ProgressDelegate del;

    #endregion

    private void frmSplashScreen_Load(object sender, EventArgs e)
    {
    }
}