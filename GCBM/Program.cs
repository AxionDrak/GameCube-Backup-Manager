using GCBM.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace GCBM;

internal static class Program
{
    public static Form SplashScreen;
    private static Form MainForm;

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