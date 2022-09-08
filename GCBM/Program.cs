using GCBM.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace GCBM;

internal static class Program
{
    public static Form SplashScreen;
    private static Form MainForm;
    private static readonly string GET_CURRENT_PATH = Directory.GetCurrentDirectory();
    
    private static readonly string GAMES_DIR = "games";
    private static readonly string TEMP_DIR = System.IO.Path.DirectorySeparatorChar + "temp";

    private static readonly string COVERS_DIR =
        System.IO.Path.DirectorySeparatorChar + "covers" + System.IO.Path.DirectorySeparatorChar + "cache";

    private static readonly string MEDIA_DIR =
        System.IO.Path.DirectorySeparatorChar + "media" + System.IO.Path.DirectorySeparatorChar + "covers";

    private const string INI_FILE = "config.ini";
    private static readonly string PROG_UPDATE = "10/07/2022";
    public enum Language
    {
        Portuguese, English, Spanish, Korean, French, German, Japanese
    }
    public static Dictionary<string, int> Translations = new()
        {
            {"pt-BR" ,0},//Portuguese
            {"en-US" ,1},//English
            {"es"    ,2},//Spanish
            {"ko"    ,3},//Korean
            {"fr"    ,4},//French
            {"de"    ,5},//German
            {"ja"    ,6}//Japanese
        };

    /// <summary>
    ///     Ponto de entrada principal para o aplicativo.
    /// </summary>
    [STAThread]
    private static void Main()
    {

        var configIniFile = new IniFile("config.ini");

        //Pega o nome do processo deste programa
        var nomeProcesso = Process.GetCurrentProcess().ProcessName;
        //Busca os processos com este nome que estão em execução
        var processos = Process.GetProcessesByName(nomeProcesso);

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
            DefaultConfigSave();
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

    public static void DefaultConfigSave()
    {
        if (System.IO.File.Exists(GET_CURRENT_PATH + System.IO.Path.DirectorySeparatorChar + INI_FILE))
        {
            var CONFIG_INI_FILE = new IniFile("config.ini");
            // GCBM
            CONFIG_INI_FILE.IniWriteString("GCBM", "ProgUpdated", PROG_UPDATE);
            //CONFIG_INI_FILE.IniWriteString("GCBM", "ProgVersion", VERSION());
            CONFIG_INI_FILE.IniWriteString("GCBM", "ConfigUpdated", DateTime.Now.ToString("dd/MM/yyyy"));
            CONFIG_INI_FILE.IniWriteString("GCBM", "Language", Resources.GCBM_Language);
            CONFIG_INI_FILE.IniWriteString("GCBM", "TranslatedBy", Resources.GCBM_TranslatedBy);
            // General
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "DiscClean", true);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "DiscDelete", false);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractZip", false);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "Extract7z", false);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractRar", false);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractBZip2", false);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractSplitFile", false);
            CONFIG_INI_FILE.IniWriteBool("GENERAL", "ExtractNwb", false);
            CONFIG_INI_FILE.IniWriteInt("GENERAL", "FileSize", 0);
            CONFIG_INI_FILE.IniWriteString("GENERAL", "TemporaryFolder", GET_CURRENT_PATH + TEMP_DIR);
            // Several
            CONFIG_INI_FILE.IniWriteInt("SEVERAL", "AppointmentStyle", 0);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "CheckMD5", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "CheckSHA1", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "CheckNotify", true);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "NetVerify", true);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "RecursiveMode", true);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "TemporaryBuffer", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "WindowMaximized", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "DisableSplash", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "Screensaver", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "LoadDatabase", true);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "MultipleInstances", false);
            CONFIG_INI_FILE.IniWriteBool("SEVERAL", "LaunchedOnce", true);
            // TransferSystem
            CONFIG_INI_FILE.IniWriteBool("TRANSFERSYSTEM", "FST", false);
            CONFIG_INI_FILE.IniWriteBool("TRANSFERSYSTEM", "ScrubFlushSD", false);
            CONFIG_INI_FILE.IniWriteInt("TRANSFERSYSTEM", "ScrubAlign", 0);
            CONFIG_INI_FILE.IniWriteString("TRANSFERSYSTEM", "ScrubFormat", "DiscEx");
            CONFIG_INI_FILE.IniWriteInt("TRANSFERSYSTEM", "ScrubFormatIndex", 1);
            CONFIG_INI_FILE.IniWriteBool("TRANSFERSYSTEM", "Wipe", false);
            CONFIG_INI_FILE.IniWriteBool("TRANSFERSYSTEM", "XCopy", true);
            // Covers
            CONFIG_INI_FILE.IniWriteBool("COVERS", "DeleteCovers", false);
            CONFIG_INI_FILE.IniWriteBool("COVERS", "CoverRecursiveSearch", false);
            CONFIG_INI_FILE.IniWriteBool("COVERS", "TransferCovers", false);
            CONFIG_INI_FILE.IniWriteBool("COVERS", "WiiFlowCoverUSBLoader", false);
            CONFIG_INI_FILE.IniWriteBool("COVERS", "GXCoverUSBLoader", true);
            CONFIG_INI_FILE.IniWriteString("COVERS", "CoverDirectoryCache", GET_CURRENT_PATH + COVERS_DIR);
            CONFIG_INI_FILE.IniWriteString("COVERS", "WiiFlowCoverDirectoryDisc", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "WiiFlowCoverDirectory2D", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "WiiFlowCoverDirectory3D", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "WiiFlowCoverDirectoryFull", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "GXCoverDirectoryDisc", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "GXCoverDirectory2D", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "GXCoverDirectory3D", "");
            CONFIG_INI_FILE.IniWriteString("COVERS", "GXCoverDirectoryFull", "");
            // Titles
            CONFIG_INI_FILE.IniWriteBool("TITLES", "GameCustomTitles", false);
            CONFIG_INI_FILE.IniWriteBool("TITLES", "GameTdbTitles", false);
            CONFIG_INI_FILE.IniWriteBool("TITLES", "GameInternalName", true);
            CONFIG_INI_FILE.IniWriteBool("TITLES", "GameXmlName", false);
            CONFIG_INI_FILE.IniWriteString("TITLES", "LocationTitles",
                "%APP%" + System.IO.Path.DirectorySeparatorChar + "titles.txt");
            CONFIG_INI_FILE.IniWriteString("TITLES", "LocationCustomTitles",
                "%APP%" + System.IO.Path.DirectorySeparatorChar + "custom-titles.txt");
            CONFIG_INI_FILE.IniWriteInt("TITLES", "TitleLanguage", 0);
            // Dolphin Emulator
            CONFIG_INI_FILE.IniWriteString("DOLPHIN", "DolphinFolder", "");
            CONFIG_INI_FILE.IniWriteBool("DOLPHIN", "DolphinDX11", true);
            CONFIG_INI_FILE.IniWriteBool("DOLPHIN", "DolphinDX12", false);
            CONFIG_INI_FILE.IniWriteBool("DOLPHIN", "DolphinVKGL", false);
            CONFIG_INI_FILE.IniWriteBool("DOLPHIN", "DolphinLLE", false);
            CONFIG_INI_FILE.IniWriteBool("DOLPHIN", "DolphinHLE", true);
            // Updates
            CONFIG_INI_FILE.IniWriteBool("UPDATES", "UpdateVerifyStart", false);
            CONFIG_INI_FILE.IniWriteBool("UPDATES", "UpdateBetaChannel", false);
            CONFIG_INI_FILE.IniWriteBool("UPDATES", "UpdateFileLog", false);
            CONFIG_INI_FILE.IniWriteBool("UPDATES", "UpdateServerProxy", false);
            CONFIG_INI_FILE.IniWriteString("UPDATES", "ServerProxy", "");
            CONFIG_INI_FILE.IniWriteString("UPDATES", "UserProxy", "");
            CONFIG_INI_FILE.IniWriteString("UPDATES", "PassProxy", "");
            CONFIG_INI_FILE.IniWriteInt("UPDATES", "VerificationInterval", 0);
            // Manager Log
            CONFIG_INI_FILE.IniWriteInt("MANAGERLOG", "LogLevel", 0);
            CONFIG_INI_FILE.IniWriteBool("MANAGERLOG", "LogSystemConsole", false);
            CONFIG_INI_FILE.IniWriteBool("MANAGERLOG", "LogDebugConsole", false);
            CONFIG_INI_FILE.IniWriteBool("MANAGERLOG", "LogWindow", false);
            CONFIG_INI_FILE.IniWriteBool("MANAGERLOG", "LogFile", true);
            // Language
            CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 1);
        }
    }

    #region Detect OS Language

    /// <summary>
    ///     Automatic detection of operating system default language
    /// </summary>
    public static void DetectOSLanguage()
    {
        var configIniFile = new IniFile("config.ini");

        var sysLocale = Thread.CurrentThread.CurrentCulture;

        //  See if we have that translation
        var isTranslated = Translations.ContainsKey(sysLocale.ToString());

        //  Write the corresponding number to INI
        if (isTranslated)
            configIniFile.IniWriteInt("LANGUAGE", "ConfigLanguage",
                Translations[sysLocale.ToString()]);
        else //Default to english
            configIniFile.IniWriteInt("LANGUAGE", "ConfigLanguage", 1); //en-US
    }

    public static void AdjustLanguage(Thread t)
    {
        while (true)
        {
            var configIniFile = new IniFile("config.ini");
            //Get current system Locale -- Thread.CurrentThread.CurrentUICulture.Name
            if (configIniFile.IniReadBool("SEVERAL", "LaunchedOnce"))
            {
                switch (configIniFile.IniReadInt("LANGUAGE", "ConfigLanguage"))
                {
                    case 0:
                        t.CurrentUICulture = new CultureInfo("pt-BR");
                        break;
                    case 1:
                        t.CurrentUICulture = new CultureInfo("en-US");
                        break;
                    case 2:
                        t.CurrentUICulture = new CultureInfo("es");
                        break;
                    case 3:
                        t.CurrentUICulture = new CultureInfo("ko");
                        break;
                    case 4:
                        t.CurrentUICulture = new CultureInfo("fr");
                        break;
                    case 5:
                        t.CurrentUICulture = new CultureInfo("de");
                        break;
                    case 6:
                        t.CurrentUICulture = new CultureInfo("ja");
                        break;
                    default:
                        t.CurrentUICulture = new CultureInfo("en-US");
                        break;
                }
            }
            else
            {
                DetectOSLanguage();
            }

            break;
        }
    }

    #endregion
    private static void Start()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //Show Splash Form
        SplashScreen = new frmSplashScreen();

        var splashThread = new Thread(() => Application.Run(SplashScreen));
        splashThread.CurrentUICulture = CultureInfo.CurrentCulture;
        splashThread.SetApartmentState(ApartmentState.STA);
        splashThread.Start();

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