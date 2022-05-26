using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM
{
    public partial class frmSplashScreen : Form
    {
        #region Properties
        private const string INI_FILE            = "config.ini";
        private readonly IniFile CONFIG_INI_FILE = new IniFile(INI_FILE);
        private delegate void ProgressDelegate(int progress);
        private ProgressDelegate del;
        #endregion

        #region Main Form
        public frmSplashScreen()
        {
            InitializeComponent();

            AdjustLanguage();
            CurrentYear();
            this.pbSplashScreen.Maximum = 100;
            del = this.UpdateProgressInternal;
        }
        #endregion

        #region Adjust Language
        private void AdjustLanguage()
        {
            switch (CONFIG_INI_FILE.IniReadInt("LANGUAGE", "ConfigLanguage"))
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");
                    this.Controls.Clear();
                    InitializeComponent();
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    this.Controls.Clear();
                    InitializeComponent();
                    break;
                case 2:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");
                    this.Controls.Clear();
                    InitializeComponent();
                    break;
                case 3:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ko");
                    this.Controls.Clear();
                    InitializeComponent();
                    break;
            }
        }
        #endregion

        #region Current Year
        private void CurrentYear()
        {
            DateTime _currentYear = DateTime.Now;
            tsslCurrentYear.Text = "Copyright © 2019 - " + _currentYear.Year.ToString() + " Laete Meireles";
        }
        #endregion

        #region Update Progress Internal
        private void UpdateProgressInternal(int progress)
        {
            if (this.Handle == null)
            {
                return;
            }
            this.pbSplashScreen.Value = progress;
        }
        #endregion

        #region Update Progress
        public void UpdateProgress(int progress)
        {
            try
            {
                this.Invoke(del, progress);
            }
            catch (Exception ex)
            {
                //not implemented!
            }
        }
        #endregion
    }
}
