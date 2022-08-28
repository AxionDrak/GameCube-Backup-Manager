using System;
using System.Windows.Forms;

namespace GCBM.tools
{
    public partial class frmCreateAppPackage : Form
    {
        #region Main form

        public frmCreateAppPackage()
        {
            InitializeComponent();

            tbExtra.Enabled = false;
            btnSearchExtras.Enabled = false;
            btnCreatePackage.Enabled = false;
            btnClear.Enabled = false;
            chkIncludeExtra.Enabled = false;
            rbCreateNwb.Enabled = false;
            rbCreateZip.Enabled = false;
        }

        #endregion

        #region Notifications

        private void GlobalNotifications(string ex)
        {
            notifyIcon.ShowBalloonTip(10, "GameCube Backup Manager", ex, ToolTipIcon.Info);
        }

        #endregion

        #region CheckBox

        private void chkIncludeExtra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncludeExtra.Checked)
            {
                tbExtra.Enabled = true;
                btnSearchExtras.Enabled = true;
            }
            else
            {
                tbExtra.Enabled = false;
                btnSearchExtras.Enabled = false;
            }
        }

        #endregion

        #region TextBox

        private void tbDirectory_TextChanged(object sender, EventArgs e)
        {
            if (tbDirectory.Text != string.Empty)
            {
                chkIncludeExtra.Enabled = true;
                rbCreateZip.Enabled = true;
                rbCreateNwb.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                chkIncludeExtra.Checked = false;
                chkIncludeExtra.Enabled = false;
                rbCreateZip.Enabled = false;
                rbCreateZip.Checked = true;
                rbCreateNwb.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        #endregion

        #region Buttons

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnCreatePackage_Click(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //fbd.Description = "Selecione a pasta que contém o app:";
                //fbd.ShowNewFolderButton = false;
                if (fbdCreatePackage.ShowDialog() == DialogResult.OK)
                {
                    tbDirectory.Text = fbdCreatePackage.SelectedPath;
                }

                //DisplayFilesFolder(fbd.SelectedPath, dgvAppList);
                //RenameFiles(fbd.SelectedPath);
            }
            catch (Exception ex)
            {
                //tbLog.AppendText(">> ERRO: " + ex.Message + Environment.NewLine);
                GlobalNotifications(ex.Message);
            }
        }

        private void btnSearchExtras_Click(object sender, EventArgs e)
        {
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbDirectory.Text = string.Empty;
        }

        #endregion
    }
}