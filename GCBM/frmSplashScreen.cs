using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace GCBM
{
    public partial class frmSplashScreen : Form
    {
        #region Main Form

        public frmSplashScreen()
        {
            InitializeComponent();

            AdjustLanguage();
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
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                        Controls.Clear();
                        InitializeComponent();
                        break;
                    case 1:
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                        Controls.Clear();
                        InitializeComponent();
                        break;
                    case 2:
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
                        Controls.Clear();
                        InitializeComponent();
                        break;
                    case 3:
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("ko");
                        Controls.Clear();
                        InitializeComponent();
                        break;
                }
            }
            else
            {
                switch (Thread.CurrentThread.CurrentUICulture.Name)
                {
                    case "pt - BR":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                        Controls.Clear();
                        InitializeComponent();
                        CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 0);
                        break;
                    case "en-US":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                        Controls.Clear();
                        InitializeComponent();
                        CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 1);
                        break;
                    case "es":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
                        Controls.Clear();
                        InitializeComponent();
                        CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 2);
                        break;
                    case "ko":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("ko");
                        Controls.Clear();
                        InitializeComponent();
                        CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 3);
                        break;
                    default:
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                        Controls.Clear();
                        InitializeComponent();
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
                Invoke(del, progress);
            }
            catch (Exception ex)
            {
                //not implemented!
            }
        }

        #endregion

        #region Properties

        private const string INI_FILE = "config.ini";
        private readonly IniFile CONFIG_INI_FILE = new IniFile(INI_FILE);

        private delegate void ProgressDelegate(int progress);

        private readonly ProgressDelegate del;

        #endregion
    }
}