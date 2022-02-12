#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace GameCube_Backup_Manager
{
    public partial class frmMain : Form
    {
        // Web Connection
        private readonly WebClient client = new WebClient();
        HttpWebResponse response = null;
        //
        private readonly string currentPath = Environment.CurrentDirectory;
        private static string getCurrentPath = Directory.GetCurrentDirectory();
        // Cover path
        private string sourcePathDisc = getCurrentPath + @"\covers\cache\disc";
        private string sourcePath2D = getCurrentPath + @"\covers\cache\2d";
        private string sourcePath3D = getCurrentPath + @"\covers\cache\3d";
        private string sourcePathFull = getCurrentPath + @"\covers\cache\full";
        // WiiTDB ZIP
        private readonly string zipWiiTDB = @"wiitdb.zip";
        // WiiTDB XML
        private readonly string ArquivoXML = @"wiitdb.xml";

        #region Form Main
        public frmMain()
        {
            InitializeComponent();

            NetworkCheck();
            RegisterHeaderLog();
        }
        #endregion


        private void NetworkCheck()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Conexão de rede não disponível." + Environment.NewLine +
                    "Algumas funções do GameCube Backup Manager estarão indisponíveis até que uma conexão de rede seja fornecida!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Environment.Exit(-1);
            }
            //else
            //{
            //    MessageBox.Show("Conexão de rede disponível!" + Environment.NewLine + 
            //        "Todas as funções do Gamecube Backup Manager estarão disponíveis!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            return;
        }

        private void RegisterHeaderLog()
        {
            txtDebugLog.AppendText("Entradas do Registro :" + Environment.NewLine);
            txtDebugLog.AppendText(Environment.NewLine + DateTime.Now.ToLongTimeString() + Environment.NewLine
                + DateTime.Now.ToLongDateString() + Environment.NewLine);
            txtDebugLog.AppendText("------------------------------------------------------------" + Environment.NewLine);
            txtDebugLog.AppendText(">> Diretório atual do programa: " + getCurrentPath + Environment.NewLine);
            //textLog.AppendText(">> Arquivo WiiTDB base: " + ArquivoXML + Environment.NewLine);
            txtDebugLog.AppendText("------------------------------------------------------------" + Environment.NewLine);
        }

        // Buttons
        private void btnDeleteGame_Click(object sender, EventArgs e)
        {

        }

        private void btnGameInstallExactCopy_Click(object sender, EventArgs e)
        {

        }

        private void btnGameInstallScrub_Click(object sender, EventArgs e)
        {

        }
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {

        }

    }
}
