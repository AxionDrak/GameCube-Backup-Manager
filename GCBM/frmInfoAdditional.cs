﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Resources;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace GCBM
{
    public partial class frmInfoAdditional : Form
    {
        #region Properties
        private readonly string fileXML = @"wiitdb.xml";
        // IniFile 
        private readonly IniFile configIniFile = new IniFile("config.ini");
        #endregion

        #region Main Form
        public frmInfoAdditional()
        {
            InitializeComponent();
        }

        public frmInfoAdditional(string tbIDGame)
        {
            InitializeComponent();
            //tbGameInternalName.Text = tbIDName;
            //tbGameInternalName.Text = tbIDGame;
            //tbGameRegion.Text = tbIDRegion;
            //extraGameName = tbIDName;

            //ParseDatabase(tbIDGame);
            ParserXml(tbIDGame);
        }
        #endregion

        #region Notifications
        private void GlobalNotifications(string ex)
        {
            notifyIcon.ShowBalloonTip(10, "GameCube Backup Manager", ex, ToolTipIcon.Info);
        }

        #endregion

        #region ParserXml
        /// <summary>
        /// Parsers the XML.
        /// </summary>
        //private void ParserXml(string tbIDGame)
        private void ParserXml(string tbIDGame)
        {
            //string caseSwitch = tbGameRatingValue.Text;

            try
            {
                XElement root = XElement.Load(fileXML);
                IEnumerable<XElement> tests = from el in root.Elements("game") where (string)el.Element("id") == tbIDGame select el;

                foreach (XElement el in tests)
                {
                    //tbGameInternalName.Text = (string)el.Attribute("name");
                    tbGameInternalName.Text = (string)el.Element("locale").Element("title");
                    tbGameDay.Text = (string)el.Element("date").Attribute("day");
                    tbGameMonth.Text = (string)el.Element("date").Attribute("month");
                    tbGameYear.Text = (string)el.Element("date").Attribute("year");
                    tbGameRatingType.Text = (string)el.Element("rating").Attribute("type");
                    tbGameRatingValue.Text = (string)el.Element("rating").Attribute("value");
                    tbGamePlayersOnline.Text = (string)el.Element("wi-fi").Attribute("players");
                    tbGamePlayers.Text = (string)el.Element("input").Attribute("players");
                    tbGameCRC.Text = (string)el.Element("rom").Attribute("crc");
                    tbGameMD5.Text = (string)el.Element("rom").Attribute("md5");
                    tbGameSHA1.Text = (string)el.Element("rom").Attribute("sha1");
                    tbGameControl.Text = "control(s) " + (string)el.Element("input").Element("control").Attribute("type");
                    tbGameSynopsis.Text = (string)el.Element("locale").Element("synopsis");
                    tbGameDescriptor.Text = (string)el.Element("rating").Element("descriptor");
                    tbGameRegion.Text = (string)el.Element("region");
                    tbGameLanguage.Text = (string)el.Element("languages");
                    tbGameDeveloper.Text = (string)el.Element("developer");
                    tbGameGenre.Text = (string)el.Element("genre");
                    tbGamePublisher.Text = (string)el.Element("publisher");
                    //tbGameAccessories.Text = 
                    if (String.IsNullOrWhiteSpace(tbGameVersion.Text = (string)el.Element("rom").Attribute("version")))
                    {
                        tbGameVersion.Text = "??";
                    }
                    else
                    {
                        tbGameVersion.Text = (string)el.Element("rom").Attribute("version");
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalNotifications(ex.Message);
            }

            if (tbGameRatingValue.Text == "A")
            {
                pbESRB_A.Image = Properties.Resources.ESRB_Adults_Only_18_;
            }
            else if (tbGameRatingValue.Text == "C")
            {
                pbESRB_C.Image = Properties.Resources.ESRB_Early_Childhood;
            }
            else if (tbGameRatingValue.Text == "E")
            {
                pbESRB_E.Image = Properties.Resources.ESRB_Everyone;
            }
            else if (tbGameRatingValue.Text == "E10+")
            {
                pbESRB_Eplus.Image = Properties.Resources.ESRB_Everyone_10_;
            }
            else if (tbGameRatingValue.Text == "M")
            {
                pbESRB_M.Image = Properties.Resources.ESRB_Mature_17_;
            }
            else
            {
                pbESRB_T.Image = Properties.Resources.ESRB_Teen;
            }

            if (pbGameTitle.Enabled == false)
            {
                pbGameTitle.Enabled = true;
                pbGameTitle.Image = Properties.Resources.website;
            }
        }
        #endregion

        #region ExternalSite
        private void ExternalSite(string targetLink, string targetID)
        {
            try
            {
                Process.Start(targetLink + targetID);
            }
            catch (Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (Exception ex)
            {
                GlobalNotifications(ex.Message);
            }
        }
        #endregion

        #region pbGameTitle_Click
        private void pbGameTitle_Click(object sender, EventArgs e)
        {
            ExternalSite("https://en.wikipedia.org/wiki/", tbGameInternalName.Text);
        }
        #endregion

        #region Buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.notifyIcon.Dispose();
            this.Dispose();
        }
        #endregion
    }
}