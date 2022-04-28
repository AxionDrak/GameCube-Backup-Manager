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
        private delegate void ProgressDelegate(int progress);
        private ProgressDelegate del;
        // IniFile 
        private readonly IniFile configIniFile = new IniFile("config.ini");

        public frmSplashScreen()
        {
            InitializeComponent();

            AdjustLanguage();
            CurrentYear();
            this.pbSplashScreen.Maximum = 100;
            del = this.UpdateProgressInternal;
        }

        private void AdjustLanguage()
        {
            switch (configIniFile.IniReadInt("LANGUAGE", "ConfigLanguage"))
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
            }
        }

        private void CurrentYear()
        {
            DateTime _currentYear = DateTime.Now;
            tsslCurrentYear.Text = "Copyright © 2019 - " + _currentYear.Year.ToString() + " Laete Meireles";
        }

        private void UpdateProgressInternal(int progress)
        {
            if (this.Handle == null)
            {
                return;
            }
            this.pbSplashScreen.Value = progress;
        }
        public void UpdateProgress(int progress)
        {
            this.Invoke(del, progress);
        }

    }
}
