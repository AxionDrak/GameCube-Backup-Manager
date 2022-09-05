using GCBM.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using sio = System.IO;
using ste = System.Text.Encoding;

namespace GCBM
{
    public partial class frmMain : Form
    {
        private byte b;
        private byte[] bb;

        private sio.BinaryReader br;
        //sio.MemoryStream bnr = null;
        //sio.BinaryReader bnrr = null;

        private sio.FileStream fs;
        private string loadPath;

        public string _IDMakerCode { get; private set; }
        public string _IDRegionCode { get; private set; }
        public string _oldNameInternal { get; private set; }

        public string _IDRegionName { get; private set; }

        private async void LoadInfo(string path)
        {
            IMAGE_PATH = path;
            LoadISOInfo(true);
        }
        private async void LoadInfo(bool image)
        {
            LoadISOInfo(image);
        }

        private async void LoadInfoDisc(bool image)
        {
            LoadISOInfoDisc(image);
        }

        private async void LoadISOInfo(bool image)
        {
            loadPath = image ? IMAGE_PATH : toc.fils[2].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);

            bb = br.ReadBytes(4); // 4
            //tbIDGameCode.Text = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            string IDGameCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Game Code - String

            _IDRegionCode = Convert.ToString(ste.Default.GetChars(new[] { bb[3] })[0]).ToLower();

            switch (Convert.ToString(ste.Default.GetChars(new[] { bb[3] })[0]).ToLower())
            {
                case "e":
                    tbIDRegion.Text = "USA/NTSC-U";
                    REGION = 'u';
                    break;
                case "j":
                    tbIDRegion.Text = "JAP/NTSC-J";
                    REGION = 'j';
                    break;
                case "p":
                    tbIDRegion.Text = "EUR/PAL";
                    REGION = 'e';
                    break;
                default:
                    tbIDRegion.Text = "UNK";
                    REGION = 'n';
                    break;
            }

            //Catch GAMEREGION
            bb = br.ReadBytes(2); // 2
            string IDMakerCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Maker Code - String
            tbIDMakerCode.Text = IDMakerCode;

            b = br.ReadByte();
            tbIDDiscID.Text = string.Format("0x{0:x2}", b);
            fs.Position += 0x19;

            if (string.Format("0x{0:x2}", b) == "0x00")
            {
                lblTypeDisc.Visible = true;
                lblTypeDisc.Text = Resources.LoadISOInfo_String1;
            }
            else
            {
                lblTypeDisc.Visible = true;
                lblTypeDisc.Text = Resources.LoadISOInfo_String2;
            }


            //Catch GAMETITLE
            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameInternalName"))
            {
                tbIDName.Text = br.ReadStringNT();
                _oldNameInternal = br.ReadStringNT();
            }

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName"))
            {
                _oldNameInternal = br.ReadStringNT();
            }

            br.Close();
            fs.Close();

            loadPath = image ? IMAGE_PATH : toc.fils[3].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);
            if (image)
            {
                fs.Position = toc.fils[3].pos;
            }

            //tbIDDate.Text = br.ReadStringNT();
            tbIDGame.Text = IDGameCode + IDMakerCode; // GameID (IDGameCode + IDMakerCode)
            //Catch GAMEID here

            //_tbIDGameOld = IDGameCode + IDMakerCode; // GameID (IDGameCode + IDMakerCode)
            _IDMakerCode = IDGameCode + IDMakerCode;

            br.Close();
            fs.Close();
        }

        private void LoadISOInfoDisc(bool image)
        {
            loadPath = image ? IMAGE_PATH : toc.fils[2].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);

            bb = br.ReadBytes(4); // 4
            //tbIDGameCode.Text = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            string IDGameCodeDisc = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Game Code - String

            _IDRegionCode = Convert.ToString(ste.Default.GetChars(new[] { bb[3] })[0]).ToLower();

            switch (Convert.ToString(ste.Default.GetChars(new[] { bb[3] })[0]).ToLower())
            {
                case "e":
                    tbIDRegionDisc.Text = "USA/NTSC-U";
                    REGION = 'u';
                    break;
                case "j":
                    tbIDRegionDisc.Text = "JAP/NTSC-J";
                    REGION = 'j';
                    break;
                case "p":
                    tbIDRegionDisc.Text = "EUR/PAL";
                    REGION = 'e';
                    break;
                default:
                    tbIDRegionDisc.Text = "UNK";
                    REGION = 'n';
                    break;
            }

            bb = br.ReadBytes(2); // 2
            string IDMakerCodeDisc = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Maker Code - String
            //tbIDMakerCode.Text = IDMakerCode;
            b = br.ReadByte();
            //tbIDDiscID.Text = string.Format("0x{0:x2}", b);
            fs.Position += 0x19;

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameInternalName"))
            {
                tbIDNameDisc.Text = br.ReadStringNT();
                _oldNameInternal = br.ReadStringNT();
            }

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName"))
            {
                _oldNameInternal = br.ReadStringNT();
            }

            br.Close();
            fs.Close();

            loadPath = image ? IMAGE_PATH : toc.fils[3].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);
            if (image)
            {
                fs.Position = toc.fils[3].pos;
            }

            //tbIDDate.Text = br.ReadStringNT();
            tbIDGameDisc.Text = IDGameCodeDisc + IDMakerCodeDisc; // GameID (IDGameCode + IDMakerCode)
            //_tbIDGameOld = IDGameCode + IDMakerCode; // GameID (IDGameCode + IDMakerCode)
            _IDMakerCode = IDGameCodeDisc + IDMakerCodeDisc;

            br.Close();
            fs.Close();
        }


        private Game GetGameInfo(string path)
        {
            Game game = new Game();
            IMAGE_PATH = path;
            loadPath = true ? IMAGE_PATH : toc.fils[2].path;
            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);

            bb = br.ReadBytes(4); // 4
            //tbIDGameCode.Text = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            game.IDGameCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Game Code - String

            game.IDRegionCode = Convert.ToString(ste.Default.GetChars(new[] { bb[3] })[0]).ToLower();

            switch (Convert.ToString(ste.Default.GetChars(new[] { bb[3] })[0]).ToLower())
            {
                case "e":
                    game.Region = "USA/NTSC-U";
                    REGION = 'u';
                    break;
                case "j":
                    game.Region = "JAP/NTSC-J";
                    REGION = 'j';
                    break;
                case "p":
                    game.Region = "EUR/PAL";
                    REGION = 'e';
                    break;
                default:
                    game.Region = "UNK";
                    REGION = 'n';
                    break;
            }

            //Catch GAMEREGION
            bb = br.ReadBytes(2); // 2
            game.IDMakerCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Maker Code - String

            b = br.ReadByte();
            game.DiscID = string.Format("0x{0:x2}", b);
            fs.Position += 0x19;


            //Catch GAMETITLE

            game.InternalName = br.ReadStringNT();

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameInternalName"))
            {
                game.Title = game.InternalName;
            }

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName"))
            {
                if (sio.File.Exists(WIITDB_FILE))
                {
                    XElement root = XElement.Load(WIITDB_FILE);
                    IEnumerable<XElement> tests = from el in root.Elements("game")
                                                  where (string)el.Element("id") == game.IDGameCode + game.IDMakerCode //GameID
                                                  select el;
                    foreach (XElement el in tests)
                    {
                        game.Title = (string)el.Element("locale").Element("title");
                    }
                }
                else
                {
                    CheckWiiTdbXml();
                }
            }
            br.Close();
            fs.Close();

            loadPath = true ? IMAGE_PATH : toc.fils[3].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);
            //if (true)
            //{
            //    fs.Position = toc.fils[3].pos;
            //}

            game.Date = br.ReadStringNT();
            game.ID = game.IDGameCode + game.IDMakerCode; // GameID (IDGameCode + IDMakerCode)
                                                          //Catch GAMEID here

            br.Close();
            fs.Close();
            sio.FileInfo f = new sio.FileInfo(path);
            game.Extension = f.Extension;
            game.Size = Convert.ToInt32(f.Length);
            game.Path = path;

            br.Close();
            fs.Close();
            return game;
        }
    }
}