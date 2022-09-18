using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCBM.Properties;

namespace GCBM
{
    public partial class frmLanguagePrompt : Form
    {
        public IniFile ini = Program.ConfigFile;
        public frmLanguagePrompt()
        {
            InitializeComponent();
        }

        private void LanguagePrompt_Load(object sender, EventArgs e)
        {
            this.Text = Resources.LanguagePromptTitle;
            string sysLang = Program.DetectOSLanguage();
            
            foreach (var c in Program.cultureInfos)
            {
                cbSupportedCultures.Items.Add(c.NativeName + " [" + c.Name + "]");
            }
        }

        private void btnSetLanguage_Click(object sender, EventArgs e)
        {
            Program.ConfigFile.IniWriteString("LANGUAGE", "ConfigLanguage", Program.cultureInfos[cbSupportedCultures.SelectedIndex].Name);
            this.Dispose();
        }

        private void cbSupportedCultures_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Refresh the interface to give the user a preview of the selected language via updating the label text
            CultureInfo.CurrentUICulture = new CultureInfo(Program.cultureInfos[cbSupportedCultures.SelectedIndex].Name);
            MessageBox.Show(Resources.LanguagePromptConfirm, Resources.LanguagePromptConfirmTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Refresh();
        }
    }
}
