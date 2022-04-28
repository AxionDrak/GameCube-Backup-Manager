using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM
{
    public partial class frmRenameISO : Form
    {
        #region Properties
        public string _newName { get; private set; }
        public string _oldName { get; private set; }
        public int _returnConfirm { get; set; }
        // IniFile 
        private readonly IniFile configIniFile = new IniFile("config.ini");
        #endregion

        #region Main Form
        public frmRenameISO()
        {
            InitializeComponent();
        }

        public frmRenameISO(string fbd, string pathImage)
        {
            InitializeComponent();

            _newName = pathImage;
            _oldName = fbd;
            tbRenameISO.Text = Path.GetFileName(_newName);
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

        #region Rename ISO
        private void RenameISO()
        {
            string _directoryName = Path.GetDirectoryName(_newName);
            string _fileName = Path.GetFileName(_newName);
            string ret = Regex.Replace(_fileName, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ[\]\-().]+?", string.Empty);

            if (chkRenameISO.Checked)
            {
                if (File.Exists(_newName))
                {
                    string newFilename = ret;
                    
                    if (!string.IsNullOrEmpty(newFilename))
                    {
                        //File.Move(_oldName + @"\" + _newName, _oldName + @"\" + newFilename);
                        File.Move(_newName, _directoryName + @"\" + newFilename);
                        if (File.Exists(_directoryName + @"\" + newFilename))
                        {
                            ConfirmRename(newFilename);

                            this.DialogResult = DialogResult.OK;
                            this._returnConfirm = 1;
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                if (File.Exists(_newName))
                {
                    string newFilename = tbRenameISO.Text;
                    if (!string.IsNullOrEmpty(newFilename))
                    {
                        File.Move(_newName, _directoryName + @"\" + newFilename);
                        if (File.Exists(_directoryName + @"\" + newFilename))
                        {
                            ConfirmRename(newFilename);

                            this.DialogResult = DialogResult.OK;
                            this._returnConfirm = 1;
                            this.Close();
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
            {
                tbRenameISO.Enabled = false;
            }
            else
            {
                tbRenameISO.Enabled = true;
            }
        }
        #endregion

        #region Buttons
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            RenameISO();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion
    }
}
