using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GCBM
{
    public partial class frmRenameISO : Form
    {
        #region Rename ISO

        private void RenameISO()
        {
            var _directoryName = Path.GetDirectoryName(NEW_NAME);
            var _fileName = Path.GetFileName(NEW_NAME);
            var ret = Regex.Replace(_fileName,
                @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ[\]\-().]+?", string.Empty);

            if (chkRenameISO.Checked)
            {
                if (File.Exists(NEW_NAME))
                {
                    var newFilename = ret;

                    if (!string.IsNullOrEmpty(newFilename))
                    {
                        //File.Move(_oldName + @"\" + _newName, _oldName + @"\" + newFilename);
                        File.Move(NEW_NAME, _directoryName + @"\" + newFilename);
                        if (File.Exists(_directoryName + @"\" + newFilename))
                        {
                            ConfirmRename(newFilename);

                            DialogResult = DialogResult.OK;
                            RETURN_CONFIRM = 1;
                            Close();
                        }
                    }
                }
            }
            else
            {
                if (File.Exists(NEW_NAME))
                {
                    var newFilename = tbRenameISO.Text;
                    if (!string.IsNullOrEmpty(newFilename))
                    {
                        File.Move(NEW_NAME, _directoryName + @"\" + newFilename);
                        if (File.Exists(_directoryName + @"\" + newFilename))
                        {
                            ConfirmRename(newFilename);

                            DialogResult = DialogResult.OK;
                            RETURN_CONFIRM = 1;
                            Close();
                        }
                    }
                    else
                    {
                        NameNeeded();
                    }
                }
            }
        }

        #endregion

        #region chkRenameISO_CheckedChanged

        private void chkRenameISO_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRenameISO.Checked)
                tbRenameISO.Enabled = false;
            else
                tbRenameISO.Enabled = true;
        }

        #endregion

        #region Properties

        public string NEW_NAME { get; }
        public string OLD_NAME { get; }
        public int RETURN_CONFIRM { get; set; }

        #endregion

        #region Main Form

        public frmRenameISO()
        {
            InitializeComponent();
        }

        public frmRenameISO(string fbd, string pathImage)
        {
            InitializeComponent();

            NEW_NAME = pathImage;
            OLD_NAME = fbd;
            tbRenameISO.Text = Path.GetFileName(NEW_NAME);
        }

        #endregion

        #region Notifications

        private void ConfirmRename(string newFilename)
        {
            MessageBox.Show("Arquivo renomeado para: " +
                            Environment.NewLine + Environment.NewLine +
                            newFilename, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NameNeeded()
        {
            MessageBox.Show("Por favor, digite um nome para o arquivo!",
                "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Buttons

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            RenameISO();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        #endregion
    }
}