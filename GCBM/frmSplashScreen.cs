using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GCBM;

public partial class frmSplashScreen : Form
{
    #region Main Form

    public frmSplashScreen()
    {
        var configIniFile = new IniFile("config.ini");
        AdjustLanguage();

        InitializeComponent();

        CurrentYear();
        
        Thread t = new Thread(() => Application.Run(new frmMain(new Action<string,int>((s, i) =>
        {
            pbSplashScreen.Invoke(new Action(() => pbSplashScreen.Value=i));
            lblStartSplashScreen.Invoke(new Action(() => lblStartSplashScreen.Text = s));
        }))));
        t.SetApartmentState(ApartmentState.STA);
        t.Start();
    }

    #endregion

    #region Adjust Language

    private void AdjustLanguage()
    {
        //Get current system Locale -- Thread.CurrentThread.CurrentUICulture.Name
        if (CONFIG_INI_FILE.IniReadBool("SEVERAL", "LaunchedOnce"))
        {
            switch (CONFIG_INI_FILE.IniReadInt("LANGUAGE", "ConfigLanguage"))
            {
                case 0:
                    CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
                    break;
                case 1:
                    CultureInfo.CurrentUICulture = new CultureInfo("en-US");
                    break;
                case 2:
                    CultureInfo.CurrentUICulture = new CultureInfo("es");
                    break;
                case 3:
                    CultureInfo.CurrentUICulture = new CultureInfo("ko");
                    break;
            }
        }
        else
        {
            #region Adjust Language

            var sysLocale = CultureInfo.CurrentCulture;

            string[] aryLocales = { "pt-BR", "en-US", "es", "ko" };

            //  See if we have that translation
            var isTranslated = aryLocales.Contains(sysLocale.ToString());
            if (isTranslated)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(sysLocale.ToString());
                CultureInfo.CurrentUICulture = new CultureInfo(sysLocale.ToString());
            }

            #endregion
        }
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

    private void UpdateProgressInternal(int progress)
    {
        if (Handle == null) return;

        pbSplashScreen.Value = progress;
    }

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