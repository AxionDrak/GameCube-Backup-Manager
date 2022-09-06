﻿using GCBM;
using GCBM.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GCBM
{

    internal static class Program
    {
        public static Form SplashScreen;
        static Form MainForm;
        /// <summary>
        ///     Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            #region Adjust Language
            CultureInfo sysLocale = Thread.CurrentThread.CurrentCulture;

            string[] aryLocales = { "pt-BR", "en-US", "es", "ko" };

            //  See if we have that translation
            bool isTranslated = aryLocales.Contains(sysLocale.ToString());
            if (isTranslated)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(sysLocale.ToString()); 
                CultureInfo.CurrentUICulture = new CultureInfo(sysLocale.ToString());

            }
            #endregion
            IniFile configIniFile = new IniFile("config.ini");

            //Pega o nome do processo deste programa
            string nomeProcesso = Process.GetCurrentProcess().ProcessName;
            //Busca os processos com este nome que estão em execução
            Process[] processos = Process.GetProcessesByName(nomeProcesso);

            if (File.Exists("config.ini"))
            {
                if (configIniFile.IniReadBool("SEVERAL", "MultipleInstances") == false)
                {
                    //Pega o nome do processo deste programa
                    //string nomeProcesso = Process.GetCurrentProcess().ProcessName;
                    //Busca os processos com este nome que estão em execução
                    //Process[] processos = Process.GetProcessesByName(nomeProcesso);
                    //Se já houver um aberto
                    if (processos.Length > 1)
                    {
                        _ = MessageBox.Show(Resources.CannotOpenTwoInstances, "GameCube Backup Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Application.Exit();
                    }
                    else
                    {
                        Start();
                    }
                }
                else
                {
                    Start();
                }
            }
            else
            {
                if (processos.Length > 1)
                {
                    _ = MessageBox.Show(Resources.CannotOpenTwoInstances, "GameCube Backup Manager", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
                else
                {
                    Start();
                }
            }
        }

        private static void Start()
        {
            #region Adjust Language
            CultureInfo sysLocale = CultureInfo.CurrentCulture;

            string[] aryLocales = { "pt-BR", "en-US", "es", "ko" };

            //  See if we have that translation
            bool isTranslated = aryLocales.Contains(sysLocale.ToString());
            if (isTranslated)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(sysLocale.ToString()); 
                CultureInfo.CurrentUICulture = new CultureInfo(sysLocale.ToString());

            }
            #endregion
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Show Splash Form
            SplashScreen = new frmSplashScreen();
            var splashThread = new Thread(new ThreadStart(
                () => Application.Run(SplashScreen)));
            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.CurrentUICulture = new CultureInfo(sysLocale.ToString());
            splashThread.Start();

            //Create and Show Main Form
            MainForm = new frmMain();
            MainForm.Load += MainForm_LoadCompleted;
            Application.Run(new frmMain());
        }
        private static void MainForm_LoadCompleted(object sender, EventArgs e)
        {
            if (SplashScreen != null && !SplashScreen.Disposing && !SplashScreen.IsDisposed)
                SplashScreen.Invoke(new Action(() => SplashScreen.Close()));
            //MainForm.TopMost = true;
            MainForm.Show();
            MainForm.Activate();
            //MainForm.TopMost = false;
        }
    }


    //Create and Show Main Form



}