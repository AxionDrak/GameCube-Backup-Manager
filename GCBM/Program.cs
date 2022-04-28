using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
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
                        MessageBox.Show(GCBM.Properties.Resources.CannotOpenTwoInstances, "GameCube Backup Manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show(GCBM.Properties.Resources.CannotOpenTwoInstances, "GameCube Backup Manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
