using GCBM.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace GCBM
{
    internal partial class frmAboutBox : Form
    {
        #region Main Form

        public frmAboutBox()
        {
            InitializeComponent();

            var _version = assembly.GetName().Version;

            Text = string.Format(Resources.AboutBox_String1, AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = string.Format(Resources.AboutBox_String2, AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            textBoxDescription.Text = AssemblyDescription;
            lblAboutVersion.Text = Resources.AboutVersion + _version + " (x64)";

            lbl_DataAtualizacao.Text = string.Format("Version: {0} " + " | " + " Last Update: {1}",
                Assembly.GetExecutingAssembly().GetName().Version,
                File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToShortDateString());

            AboutTranslator();
        }

        #endregion

        #region About Translator

        private void AboutTranslator()
        {
            if (File.Exists("config.ini"))
            {
                lblAboutCurrentLanguage.Text = Resources.AboutCurrentLanguage +
                                               CONFIG_INI_FILE.IniReadString("GCBM", "Language", "");
                lblAboutTranslator.Text =
                    Resources.AboutTranslator + CONFIG_INI_FILE.IniReadString("GCBM", "TranslatedBy", "");
            }
            else
            {
                lblAboutCurrentLanguage.Text = "Idioma Atual: Português [Brasil]";
                lblAboutTranslator.Text = "Tradutor: Laete Meireles";
            }
        }

        #endregion

        #region External Site

        /// <summary>
        ///     Function to load websites in the default browser.
        /// </summary>
        /// <param name="targetLink"></param>
        /// <param name="targetID"></param>
        private void ExternalSite(string targetLink)
        {
            try
            {
                Process.Start(targetLink);
            }
            catch (Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259) MessageBox.Show("Erro ao acessar site.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void pbDonations_Click(object sender, EventArgs e)
        {
            ExternalSite("https://www.paypal.com/donate/?hosted_button_id=MP4WGLJHAP8H2");
        }

        private void pbGameTDB_Click(object sender, EventArgs e)
        {
            ExternalSite("https://www.gametdb.com/");
        }

        private void pbGameTDB_MouseEnter(object sender, EventArgs e)
        {
            pbGameTDB.Cursor = Cursors.Hand;
        }

        private void pbDonations_MouseEnter(object sender, EventArgs e)
        {
            pbDonations.Cursor = Cursors.Hand;
        }

        #region Properties

        private readonly Assembly assembly = Assembly.GetExecutingAssembly();
        private DateTime CURRENT_YEAR = DateTime.Now;

        private const string INI_FILE = "config.ini";
        private readonly IniFile CONFIG_INI_FILE = new IniFile(INI_FILE);

        #endregion

        #region Acessório de Atributos do Assembly

        public string AssemblyTitle
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "") return titleAttribute.Title;
                }

                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string AssemblyDescription
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0) return "";
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0) return "";
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright =>
            //object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            //if (attributes.Length == 0)
            //{
            //    return "";
            //}
            //return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            "Axion Drak © 2019 - " + CURRENT_YEAR.Year;

        public string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0) return "";
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion
    }
}