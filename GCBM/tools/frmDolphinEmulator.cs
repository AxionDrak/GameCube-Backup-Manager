using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM.tools
{
    public partial class frmDolphinEmulator : Form
    {
        private string GAME_NAME { get; set; }
        private string GAME_PATH { get; set; }

        public frmDolphinEmulator()
        {
            InitializeComponent();
        }

        public frmDolphinEmulator(string gameName, string pathGame)
        {
            InitializeComponent();

            lblGame.Text = gameName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
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
