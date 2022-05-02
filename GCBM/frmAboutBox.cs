using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM
{
    partial class frmAboutBox : Form
    {
        #region Properties

        Assembly assembly                        = Assembly.GetExecutingAssembly();
        DateTime CURRENT_YEAR                    = DateTime.Now;

        private const string INI_FILE            = "config.ini";
        private readonly IniFile CONFIG_INI_FILE = new IniFile(INI_FILE);
        #endregion

        #region Main Form
        public frmAboutBox()
        {
            InitializeComponent();

            var _version = assembly.GetName().Version;

            this.Text = String.Format(GCBM.Properties.Resources.AboutBox_String1, AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format(GCBM.Properties.Resources.AboutBox_String2, AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
            this.lblAboutVersion.Text = GCBM.Properties.Resources.AboutVersion + _version.ToString() + " (x64)";

            lbl_DataAtualizacao.Text = String.Format("Version: {0} " + " | " + " Last Update: {1}", 
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToShortDateString());

            AboutTranslator();
        }
        #endregion

        #region About Translator
        private void AboutTranslator()
        {
            if (File.Exists("config.ini"))
            {
                this.lblAboutCurrentLanguage.Text = GCBM.Properties.Resources.AboutCurrentLanguage + CONFIG_INI_FILE.IniReadString("GCBM", "Language", "");
                this.lblAboutTranslator.Text = GCBM.Properties.Resources.AboutTranslator + CONFIG_INI_FILE.IniReadString("GCBM", "TranslatedBy", "");
            }
            else
            {
                this.lblAboutCurrentLanguage.Text = "Idioma Atual: Português [Brasil]";
                this.lblAboutTranslator.Text = "Tradutor: Laete Meireles";
            }
        }
        #endregion

        #region Acessório de Atributos do Assembly
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                //object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                //if (attributes.Length == 0)
                //{
                //    return "";
                //}
                //return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
                return "Axion Drak © 2019 - " + CURRENT_YEAR.Year.ToString();
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        #region External Site
        /// <summary>
        /// Function to load websites in the default browser.
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
                if (noBrowser.ErrorCode == -2147467259)
                {
                    MessageBox.Show("Erro ao acessar site.");
                }
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
            pbGameTDB.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void pbDonations_MouseEnter(object sender, EventArgs e)
        {
            pbDonations.Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }
}
