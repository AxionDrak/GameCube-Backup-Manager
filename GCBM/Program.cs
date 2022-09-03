using GCBM;
using GCBM.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics;
using System.Globalization;
using sio = System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using Timer = System.Timers.Timer;
using System.Linq;

namespace GCBM
{

    internal static class Program
    {


        public static Form SplashScreen;
        static Form MainForm;

        public static readonly string PROG_UPDATE = "10/07/2022";
        public static readonly string GET_CURRENT_PATH = System.IO.Directory.GetCurrentDirectory();
        public static readonly string COVERS_DIR = System.IO.Path.DirectorySeparatorChar + "covers" + System.IO.Path.DirectorySeparatorChar + "cache";
        public static readonly string TEMP_DIR = System.IO.Path.DirectorySeparatorChar + "temp";
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
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(sysLocale.ToString	());
            }
            #endregion

            //Pega o nome do processo deste programa
            string nomeProcesso = Process.GetCurrentProcess().ProcessName;
            //Busca os processos com este nome que estão em execução
            Process[] processos = Process.GetProcessesByName(nomeProcesso);

            if (sio.File.Exists("config.ini"))
            {
                if (new IniFile().IniReadBool("SEVERAL", "MultipleInstances") == false)
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Show Splash Form
            SplashScreen = new frmSplashScreen();
            var splashThread = new Thread(new ThreadStart(
                () => Application.Run(SplashScreen)));
            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();
            
            IniFile configIniFile = new IniFile("config.ini");
            if (!sio.File.Exists("config.ini"))
            {
                #region Default Config Save

   
                // GCBM
                Assembly assembly = Assembly.GetExecutingAssembly();
                AssemblyName _version = assembly.GetName();

                string PROG_VERSION = assembly.GetName().Version.ToString();
                configIniFile.IniWriteString("GCBM", "ProgUpdated", PROG_UPDATE);
                configIniFile.IniWriteString("GCBM", "ProgVersion", (PROG_VERSION));
                configIniFile.IniWriteString("GCBM", "ConfigUpdated", DateTime.Now.ToString("dd/MM/yyyy"));
                configIniFile.IniWriteString("GCBM", "Language", Resources.GCBM_Language);
                configIniFile.IniWriteString("GCBM", "TranslatedBy", Resources.GCBM_TranslatedBy);
                // General
                configIniFile.IniWriteBool("GENERAL", "DiscClean", true);
                configIniFile.IniWriteBool("GENERAL", "DiscDelete", false);
                configIniFile.IniWriteBool("GENERAL", "ExtractZip", false);
                configIniFile.IniWriteBool("GENERAL", "Extract7z", false);
                configIniFile.IniWriteBool("GENERAL", "ExtractRar", false);
                configIniFile.IniWriteBool("GENERAL", "ExtractBZip2", false);
                configIniFile.IniWriteBool("GENERAL", "ExtractSplitFile", false);
                configIniFile.IniWriteBool("GENERAL", "ExtractNwb", false);
                configIniFile.IniWriteInt("GENERAL", "FileSize", 0);
                configIniFile.IniWriteString("GENERAL", "TemporaryFolder", GET_CURRENT_PATH + TEMP_DIR);
                // Several
                configIniFile.IniWriteInt("SEVERAL", "AppointmentStyle", 0);
                configIniFile.IniWriteBool("SEVERAL", "CheckMD5", false);
                configIniFile.IniWriteBool("SEVERAL", "CheckSHA1", false);
                configIniFile.IniWriteBool("SEVERAL", "CheckNotify", true);
                configIniFile.IniWriteBool("SEVERAL", "NetVerify", true);
                configIniFile.IniWriteBool("SEVERAL", "RecursiveMode", true);
                configIniFile.IniWriteBool("SEVERAL", "TemporaryBuffer", false);
                configIniFile.IniWriteBool("SEVERAL", "WindowMaximized", false);
                configIniFile.IniWriteBool("SEVERAL", "DisableSplash", false);
                configIniFile.IniWriteBool("SEVERAL", "Screensaver", false);
                configIniFile.IniWriteBool("SEVERAL", "LoadDatabase", true);
                configIniFile.IniWriteBool("SEVERAL", "MultipleInstances", false);
                // TransferSystem
                configIniFile.IniWriteBool("TRANSFERSYSTEM", "FST", false);
                configIniFile.IniWriteBool("TRANSFERSYSTEM", "ScrubFlushSD", false);
                configIniFile.IniWriteInt("TRANSFERSYSTEM", "ScrubAlign", 0);
                configIniFile.IniWriteString("TRANSFERSYSTEM", "ScrubFormat", "DiscEx");
                configIniFile.IniWriteInt("TRANSFERSYSTEM", "ScrubFormatIndex", 1);
                configIniFile.IniWriteBool("TRANSFERSYSTEM", "Wipe", false);
                configIniFile.IniWriteBool("TRANSFERSYSTEM", "XCopy", true);
                // Covers
                configIniFile.IniWriteBool("COVERS", "DeleteCovers", false);
                configIniFile.IniWriteBool("COVERS", "CoverRecursiveSearch", false);
                configIniFile.IniWriteBool("COVERS", "TransferCovers", false);
                configIniFile.IniWriteBool("COVERS", "WiiFlowCoverUSBLoader", false);
                configIniFile.IniWriteBool("COVERS", "GXCoverUSBLoader", true);
                configIniFile.IniWriteString("COVERS", "CoverDirectoryCache", GET_CURRENT_PATH + COVERS_DIR);
                configIniFile.IniWriteString("COVERS", "WiiFlowCoverDirectoryDisc", "");
                configIniFile.IniWriteString("COVERS", "WiiFlowCoverDirectory2D", "");
                configIniFile.IniWriteString("COVERS", "WiiFlowCoverDirectory3D", "");
                configIniFile.IniWriteString("COVERS", "WiiFlowCoverDirectoryFull", "");
                configIniFile.IniWriteString("COVERS", "GXCoverDirectoryDisc", "");
                configIniFile.IniWriteString("COVERS", "GXCoverDirectory2D", "");
                configIniFile.IniWriteString("COVERS", "GXCoverDirectory3D", "");
                configIniFile.IniWriteString("COVERS", "GXCoverDirectoryFull", "");
                // Titles
                configIniFile.IniWriteBool("TITLES", "GameCustomTitles", false);
                configIniFile.IniWriteBool("TITLES", "GameTdbTitles", false);
                configIniFile.IniWriteBool("TITLES", "GameInternalName", true);
                configIniFile.IniWriteBool("TITLES", "GameXmlName", false);
                configIniFile.IniWriteString("TITLES", "LocationTitles", "%APP%" + sio.Path.DirectorySeparatorChar + "titles.txt");
                configIniFile.IniWriteString("TITLES", "LocationCustomTitles", "%APP%" + sio.Path.DirectorySeparatorChar + "custom-titles.txt");
                configIniFile.IniWriteInt("TITLES", "TitleLanguage", 0);
                // Dolphin Emulator
                configIniFile.IniWriteString("DOLPHIN", "DolphinFolder", "");
                configIniFile.IniWriteBool("DOLPHIN", "DolphinDX11", true);
                configIniFile.IniWriteBool("DOLPHIN", "DolphinDX12", false);
                configIniFile.IniWriteBool("DOLPHIN", "DolphinVKGL", false);
                configIniFile.IniWriteBool("DOLPHIN", "DolphinLLE", false);
                configIniFile.IniWriteBool("DOLPHIN", "DolphinHLE", true);
                // Updates
                configIniFile.IniWriteBool("UPDATES", "UpdateVerifyStart", false);
                configIniFile.IniWriteBool("UPDATES", "UpdateBetaChannel", false);
                configIniFile.IniWriteBool("UPDATES", "UpdateFileLog", false);
                configIniFile.IniWriteBool("UPDATES", "UpdateServerProxy", false);
                configIniFile.IniWriteString("UPDATES", "ServerProxy", "");
                configIniFile.IniWriteString("UPDATES", "UserProxy", "");
                configIniFile.IniWriteString("UPDATES", "PassProxy", "");
                configIniFile.IniWriteInt("UPDATES", "VerificationInterval", 0);
                // Manager Log
                configIniFile.IniWriteInt("MANAGERLOG", "LogLevel", 0);
                configIniFile.IniWriteBool("MANAGERLOG", "LogSystemConsole", false);
                configIniFile.IniWriteBool("MANAGERLOG", "LogDebugConsole", false);
                configIniFile.IniWriteBool("MANAGERLOG", "LogWindow", false);
                configIniFile.IniWriteBool("MANAGERLOG", "LogFile", true);
                // Language
                configIniFile.IniWriteInt("LANGUAGE", "ConfigLanguage", 1);

                #endregion

                #region Write Language Setting
                CultureInfo sysLocale = Thread.CurrentThread.CurrentCulture;
                string[] aryLocales = { "pt-BR", "en-US", "es", "ko" };

                bool isTranslated = aryLocales.Contains(sysLocale.ToString());
                if (isTranslated)
                {
                    configIniFile.IniWriteInt("LANGUAGE", "ConfigLanguage",
                        Array.FindIndex(aryLocales, l => l == sysLocale.Name));
                }
                else //Default to english
                {
                    configIniFile.IniWriteInt("LANGUAGE", "ConfigLanguage", 1); //en-US
                }
                #endregion

                #region Adjust Language

                switch (configIniFile.IniReadInt("LANGUAGE", "ConfigLanguage"))
                {
                    case 0:
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                        break;
                    case 1:
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                        break;
                    case 2:
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
                        break;
                    case 3:
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("ko");
                        break;
                }
                #endregion

            }
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