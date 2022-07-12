using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GCBM
{
    public partial class frmInformation : Form
    {
        #region Properties

        private const string WIITDB_FILE = "wiitdb.xml";

        #endregion

        #region ParserXml

        /// <summary>
        ///     Parsers the XML.
        /// </summary>
        //private void ParserXml(string tbIDGame)
        private void ParserXml(string tbIDGame)
        {
            //string caseSwitch = tbGameRatingValue.Text;

            try
            {
                var root = XElement.Load(WIITDB_FILE);
                var tests = from el in root.Elements("game") where (string)el.Element("id") == tbIDGame select el;

                foreach (var el in tests)
                {
                    Text += (string)el.Element("locale").Element("title");

                    //tbGameInternalName.Text = (string)el.Attribute("name");
                    tbGameInternalName.Text = (string)el.Element("locale").Element("title");
                    tbLanguageBanner.Text = (string)el.Element("locale").Element("title");
                    //tbGameDay.Text = (string)el.Element("date").Attribute("day");
                    //tbGameMonth.Text = (string)el.Element("date").Attribute("month");
                    //tbGameYear.Text = (string)el.Element("date").Attribute("year");
                    //tbGameRatingType.Text = (string)el.Element("rating").Attribute("type");
                    //tbGameRatingValue.Text = (string)el.Element("rating").Attribute("value");
                    //tbGamePlayersOnline.Text = (string)el.Element("wi-fi").Attribute("players");
                    //tbGamePlayers.Text = (string)el.Element("input").Attribute("players");
                    //tbGameCRC.Text = (string)el.Element("rom").Attribute("crc");
                    //tbGameMD5.Text = (string)el.Element("rom").Attribute("md5");
                    //tbGameSHA1.Text = (string)el.Element("rom").Attribute("sha1");
                    //tbGameControl.Text = "control(s) " + (string)el.Element("input").Element("control").Attribute("type");
                    //tbGameSynopsis.Text = (string)el.Element("locale").Element("synopsis");
                    tbDescriptionBanner.Text = (string)el.Element("rating").Element("descriptor");
                    tbRegion.Text = (string)el.Element("region");
                    //tbLanguage.Text = (string)el.Element("languages");
                    tbDeveloper.Text = (string)el.Element("developer");
                    tbDeveloperBanner.Text = (string)el.Element("developer");
                    //tbGameGenre.Text = (string)el.Element("genre");
                    //tbPublisher.Text = (string)el.Element("publisher");
                    //tbGameAccessories.Text = 
                    //if (String.IsNullOrWhiteSpace(tbGameVersion.Text = (string)el.Element("rom").Attribute("version")))
                    //{
                    //    tbGameVersion.Text = "??";
                    //}
                    //else
                    //{
                    //    tbGameVersion.Text = (string)el.Element("rom").Attribute("version");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        #region Main Form

        public frmInformation()
        {
            InitializeComponent();
        }

        // Formato (Tipo), Tamanho, Local do Arquivo, ID do Jogo
        public frmInformation(string gameFile, string gameType, string gameSize, string filePath, string idGame)
        {
            InitializeComponent();

            Text = gameFile + ": " + idGame + " - ";

            tbFileFormat.Text = gameType + " (" + gameSize + ")";
            tbFilePath.Text = filePath;
            tbIDGame.Text = idGame;
            ParserXml(idGame);
        }

        #endregion
    }
}