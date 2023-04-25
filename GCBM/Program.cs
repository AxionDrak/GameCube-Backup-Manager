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
    private static readonly string TEMP_DIR = System.IO.Path.DirectorySeparatorChar + "temp";

    private static readonly string COVERS_DIR =
        System.IO.Path.DirectorySeparatorChar + "covers" + System.IO.Path.DirectorySeparatorChar + "cache";

    private static readonly string MEDIA_DIR =
        System.IO.Path.DirectorySeparatorChar + "media" + System.IO.Path.DirectorySeparatorChar + "covers";

    private const string INI_FILE = "config.ini";
    public static IniFile ConfigFile = new IniFile(GET_CURRENT_PATH + System.IO.Path.DirectorySeparatorChar + INI_FILE);
    private static readonly string PROG_UPDATE = "04/25/2023";


    //public enum Language
    //{
    //    ICHINESE,
    //    IENGLISH,
    //    IGERMAN,
    //    IHUNGARIAN,
    //    IINDONESIAN,
    //    IITALIAN,
    //    IJAPANESE,
    //    IKOREAN,
    //    IPORTUGUESE,
    //    IUKRAINIAN
    //};

    public static CultureInfo[] cultureInfos = new[]
    {
        new CultureInfo("en-US"), //English [US]
        new CultureInfo("pt-BR"), //Portuguese
        new CultureInfo("ko"), //Korean
        new CultureInfo("es"), //Spanish [Spain]
        new CultureInfo("es-MX"), //Spanish [Mexico]
        new CultureInfo("de"), //German [Germany]
        new CultureInfo("hu"), //Hungarian
        new CultureInfo("id"), //Indonesian
        new CultureInfo("it"), //Italian
        new CultureInfo("ja"), //Japanese
        new CultureInfo("uk"), //Ukrainian
        new CultureInfo("zh-CN"), //Chinese (Simplified)
        new CultureInfo("zh-TW"), //Chinese (Traditional)

    };


    /// <summary>
    ///     Ponto de entrada principal para o aplicativo.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        

        //Pega o nome do processo deste programa
        var nomeProcesso = Process.GetCurrentProcess().ProcessName;
        //Busca os processos com este nome que estão em execução
        var processos = Process.GetProcessesByName(nomeProcesso);

        if (File.Exists("config.ini"))
        {
            //We changed the variable that stores the selected language from an int to the culture string, this causes a crash when we try
            //to call CurrentUICulture = new CultureInfo(0)... etc. So we have to make sure that either they have a working/upated INI file.
            //Chosen to do this by presenting the user a new LanguagePrompt form, which will also appear upon first launch, If no supported language has been found.
            if (ConfigFile.IniReadBool("SEVERAL", "MultipleInstances") == false)
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
        if (!System.IO.File.Exists(GET_CURRENT_PATH + System.IO.Path.DirectorySeparatorChar + INI_FILE))
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

            if(IsTranslated(DetectOSLanguage()))
                CONFIG_INI_FILE.IniWriteString("LANGUAGE", "ConfigLanguage", DetectOSLanguage());
            else
            {
                LanguagePrompt();

            }
        }
    }

    /// <summary>
    ///     Check cultureInfos and see if the language is supported.
    /// </summary>
    public static bool IsTranslated(string language)
    {
        Application.SetCompatibleTextRenderingDefault(false);

        foreach (CultureInfo cultureInfo in cultureInfos)
        {
            if (cultureInfo.Name == language)
            {
                return true;
            }
        }
        return false;
    }

    public static void LanguagePrompt()
    {

        frmLanguagePrompt frmPrompt = new frmLanguagePrompt();
        DialogResult result = frmPrompt.DialogResult;
        frmPrompt.ShowDialog();
    }
    #region Detect OS Language

    /// <summary>
    ///     Automatic detection of operating system default language
    /// </summary>
    public static string DetectOSLanguage()
    {
        var sysLocale = Thread.CurrentThread.CurrentCulture;
        var sysLang = sysLocale.TwoLetterISOLanguageName;
        return sysLang;
    }

    /// <summary>
    ///     Check the config file to see which language is specified, or default to the OS language if supported, else default to english
    /// </summary>
    public static void AdjustLanguage(Thread t)
    {
        try
        {
            if (ConfigFile.IniReadString("LANGUAGE", "ConfigLanguage", "") == "")
            {
                var sysLocale = Thread.CurrentThread.CurrentCulture;
                var sysLang = CultureInfo.CurrentUICulture.Name;
                if (IsTranslated(sysLang))
                {
                    t.CurrentUICulture = new CultureInfo(sysLang);
                }
                else
                {
                    t.CurrentUICulture = new CultureInfo("en");
                }
            }
            else
            {
                t.CurrentUICulture = new CultureInfo(ConfigFile.IniReadString("LANGUAGE", "ConfigLanguage", ""));
            }
        }
        catch(Exception exception)
        {
            if (exception.GetBaseException() is CultureNotFoundException)
            {
             File.Delete("config.ini");
             DefaultConfigSave();
            }
        }
    }
    
    //public static void AdjustLanguage(Thread t)
    //{
    //    while (true)
    //    {
    //        var ConfigFile = new IniFile("config.ini");
    //        //Get current system Locale -- Thread.CurrentThread.CurrentUICulture.Name
    //        if (ConfigFile.IniReadBool("SEVERAL", "LaunchedOnce"))
    //        {
    //            switch (ConfigFile.IniReadString("LANGUAGE", "ConfigLanguage"))
    //            {
    //                case "pt-BR":
    //                    t.CurrentUICulture = new CultureInfo("pt-BR");
    //                    break;
    //                case "en-US":
    //                    t.CurrentUICulture = new CultureInfo("en-US");
    //                    break;
    //                case "es":
    //                    t.CurrentUICulture = new CultureInfo("es");
    //                    break;
    //                case "ko":
    //                    t.CurrentUICulture = new CultureInfo("ko");
    //                    break;
    //                case "fr":
    //                    t.CurrentUICulture = new CultureInfo("fr");
    //                    break;
    //                case "de":
    //                    t.CurrentUICulture = new CultureInfo("de");
    //                    break;
    //                case "ja":
    //                    t.CurrentUICulture = new CultureInfo("ja");
    //                    break;
    //                case "zh":
    //                    t.CurrentUICulture = new CultureInfo("zh");
    //                    break;
    //                default:
    //                    t.CurrentUICulture = new CultureInfo("en-US");
    //                    break;
    //            }
    //        }
    //        else
    //        {
    //            DetectOSLanguage();
    //        }

    //        break;
    //    }
    //}

    #endregion
    private static void Start()
    {
        Application.EnableVisualStyles();
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