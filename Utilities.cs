using System;

    public class Utilities
    {
        public readonly Assembly assembly = Assembly.GetExecutingAssembly();
        public const string INI_FILE = "config.ini";
        public readonly IniFile CONFIG_INI_FILE = new IniFile(INI_FILE);
        public readonly CultureInfo MY_CULTURE = new CultureInfo(CULTURE_CURRENT, false);
        public readonly ProcessStartInfo START_INFO = new ProcessStartInfo();
        public readonly WebClient NET_CLIENT = new WebClient();
        public HttpWebResponse NET_RESPONSE;
        public frmSplashScreen SPLASH_SCREEN;
        public readonly string WINTHEME;
        public static readonly string GAMES_DIR = "games";
        public static readonly string MEDIA_DIR = System.IO.Path.DirectorySeparatorChar + "media" + System.IO.Path.DirectorySeparatorChar + "covers";
        public static readonly string CULTURE_CURRENT = "pt-BR";
        public static readonly string FAT32 = "FAT32";
        public static readonly string NTFS = "NTFS";
        public static readonly string EXFAT_FAT64 = "EXFAT";

        public static readonly string PROG_UPDATE = "10/07/2022";
        public static readonly string GET_CURRENT_PATH = System.IO.Directory.GetCurrentDirectory();
        public static readonly string COVERS_DIR = System.IO.Path.DirectorySeparatorChar + "covers" + System.IO.Path.DirectorySeparatorChar + "cache";
        public static readonly string TEMP_DIR = System.IO.Path.DirectorySeparatorChar + "temp";

        #region Assembly Product

        /// <summary>
        ///     Gets the attributes of the Assembly.
        /// </summary>
        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return attributes.Length == 0 ? string.Empty : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        #endregion

        
        #region Program Version

        /// <summary>
        ///     Get the program version directly from the Assembly.
        /// </summary>
        /// <returns></returns>
        public string VERSION()
        {
        AssemblyName _version = assembly.GetName();

        string PROG_VERSION = assembly.GetName().Version.ToString();
            return PROG_VERSION;
        }

        #endregion

        #region About Translator

        /// <summary>
        ///     About Translator
        /// </summary>
        public void AboutTranslator()
        {
            if (System.IO.File.Exists("config.ini"))
            {
                if (CONFIG_INI_FILE.IniReadString("GCBM", "ProgVersion", "") != VERSION())
                {
                    CONFIG_INI_FILE.IniWriteString("GCBM", "ProgVersion", VERSION());
                }

                if (CONFIG_INI_FILE.IniReadString("GCBM", "Language", "") != Resources.GCBM_Language)
                {
                    CONFIG_INI_FILE.IniWriteString("GCBM", "Language", Resources.GCBM_Language);
                }

                if (CONFIG_INI_FILE.IniReadString("GCBM", "TranslatedBy", "") != Resources.GCBM_TranslatedBy)
                {
                    CONFIG_INI_FILE.IniWriteString("GCBM", "TranslatedBy", Resources.GCBM_TranslatedBy);
                }
            }
        }

        #endregion
        
        #region Load Config File

        /// <summary>
        ///     Reads and loads the contents of the INI file.
        /// </summary>
        public void LoadConfigFile()
        {
            if (sio.File.Exists(GET_CURRENT_PATH + sio.Path.DirectorySeparatorChar + INI_FILE))
            {
            }
        }

        #endregion

        #region Default Config Save

        /// <summary>
        ///     Default Config Save
        /// </summary>
        public void DefaultConfigSave()
        {
            // GCBM
            CONFIG_INI_FILE.IniWriteString("GCBM", "ProgUpdated", PROG_UPDATE);
            CONFIG_INI_FILE.IniWriteString("GCBM", "ProgVersion", VERSION());
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
            CONFIG_INI_FILE.IniWriteString("TITLES", "LocationTitles", "%APP%" + sio.Path.DirectorySeparatorChar + "titles.txt");
            CONFIG_INI_FILE.IniWriteString("TITLES", "LocationCustomTitles", "%APP%" + sio.Path.DirectorySeparatorChar + "custom-titles.txt");
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

        #endregion

        #region Detect OS Language

        /// <summary>
        ///     Automatic detection of operating system default language
        /// </summary>
        public void DetectOSLanguage()
        {
            CultureInfo sysLocale = Thread.CurrentThread.CurrentCulture;
            string[] aryLocales = { "pt-BR", "en-US", "es", "ko" };

            //  See if we have that translation
            bool isTranslated = aryLocales.Contains(sysLocale.ToString());

            //  Write the corresponding number to INI
            if (isTranslated)
            {
                CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage",
                    Array.FindIndex(aryLocales, l => l == sysLocale.Name));
            }
            else //Default to english
            {
                CONFIG_INI_FILE.IniWriteInt("LANGUAGE", "ConfigLanguage", 1); //en-US
            }
        }

        #endregion

        #region Adjust Language

        /// <summary>
        ///     Set the selected language
        /// </summary>
        public void AdjustLanguage()
        {
            switch (CONFIG_INI_FILE.IniReadInt("LANGUAGE", "ConfigLanguage"))
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
        }

        #endregion


    }

