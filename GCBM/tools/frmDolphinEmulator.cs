using System;
using System.Windows.Forms;

namespace GCBM.tools
{
    public partial class frmDolphinEmulator : Form
    {
        public frmDolphinEmulator()
        {
            InitializeComponent();
        }

        public frmDolphinEmulator(string gameName, string pathGame)
        {
            InitializeComponent();

            lblGame.Text = gameName;
        }

        private string GAME_NAME { get; set; }
        private string GAME_PATH { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (ofdDolphin.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                tbPathDolphinEmulator.Text = ofdDolphin.FileName;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
        }
    }
}