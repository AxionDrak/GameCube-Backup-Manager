using GCBM.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace GCBM
{
    internal static class Program
    {
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
                        MessageBox.Show(Resources.CannotOpenTwoInstances, "GameCube Backup Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Application.Exit();
                    }
                    else
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmMain());
                    }
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmMain());
                }
            }
            else
            {
                if (processos.Length > 1)
                {
                    MessageBox.Show(Resources.CannotOpenTwoInstances, "GameCube Backup Manager", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmMain());
                }
            }
        }
    }
}