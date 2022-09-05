using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GCBM
{
    public partial class frmSplashScreen : Form
    {
        #region Main Form

        public frmSplashScreen()
        {
            #region Adjust Language
            CultureInfo sysLocale = Thread.CurrentThread.CurrentCulture;
            string[] aryLocales = { "pt-BR", "en-US", "es", "ko" };

            //  See if we have that translation
            bool isTranslated = aryLocales.Contains(sysLocale.ToString());
            if (isTranslated)
            {
                CultureInfo.CurrentUICulture = new CultureInfo(sysLocale.ToString());
            }
            #endregion
            InitializeComponent();
            CurrentYear();
            pbSplashScreen.Maximum = 100;
            del = UpdateProgressInternal;
        }

        #endregion

        #region Adjust Language

        private void AdjustLanguage()
        {
            //Get current system Locale -- Thread.CurrentThread.CurrentUICulture.Name
            if (!CONFIG_INI_FILE.IniReadBool("SEVERAL", "First Run"))
            {
                switch (CONFIG_INI_FILE.IniReadInt("LANGUAGE", "ConfigLanguage"))
                {
                    case 0:
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
                        break;
                    case 1:
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture = new CultureInfo("en-US");
                        break;
                    case 2:
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture = new CultureInfo("es");
                        break;
                    case 3:
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture = new CultureInfo("ko");
                        break;
                }
            }
            else
            {
                switch (Thread.CurrentThread.CurrentUICulture.Name)
                {
                    case "pt - BR":
                        Thread.CurrentThread.CurrentUICulture= CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
                        CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 0);
                        break;
                    case "en-US":
                        Thread.CurrentThread.CurrentUICulture= CultureInfo.CurrentUICulture = new CultureInfo("en-US");
                        CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 1);
                        break;
                    case "es":
                        Thread.CurrentThread.CurrentUICulture= CultureInfo.CurrentUICulture = new CultureInfo("es");
                        CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 2);
                        break;
                    case "ko":
                        Thread.CurrentThread.CurrentUICulture= CultureInfo.CurrentUICulture = new CultureInfo("ko");
                        CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 3);
                        break;
                    default:
                        Thread.CurrentThread.CurrentUICulture= CultureInfo.CurrentUICulture = new CultureInfo("en-US");
                        CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 1);
                        break;
                }

                CONFIG_INI_FILE.IniWriteBool("SEVERAL", "FirstRun", false);
            }
        }

        #endregion

        #region Current Year

        private void CurrentYear()
        {
            DateTime _currentYear = DateTime.Now;
            tsslCurrentYear.Text = "Copyright © 2019 - " + _currentYear.Year + " Laete Meireles";
        }

        #endregion

        #region Update Progress Internal

        private void UpdateProgressInternal(int progress)
        {
            if (Handle == null)
            {
                return;
            }

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

        #region Properties

        private const string INI_FILE = "config.ini";
        private readonly IniFile CONFIG_INI_FILE = new IniFile(INI_FILE);

        private delegate void ProgressDelegate(int progress);

        private readonly ProgressDelegate del;

        #endregion

        private void frmSplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Process.GetCurrentProcess().GetChildProcesses() != null &&
               Process.GetCurrentProcess().GetChildProcesses().Count != 0)
            {
                foreach (Process process in Process.GetCurrentProcess().GetChildProcesses())
                {
                    //Kill GCIT and others
                    process.Kill();
                }
            }
            //Garbage collector
            GC.Collect();
            //Cleanup any Threads left lying around
        }
    }
}