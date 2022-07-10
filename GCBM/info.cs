using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using sio = System.IO;
using ste = System.Text.Encoding;

namespace GCBM
{
    public partial class frmMain : Form
    {
        //sio.MemoryStream bnr = null;
        //sio.BinaryReader bnrr = null;

        sio.FileStream fs;
        sio.BinaryReader br;
        string loadPath;
        byte b;
        byte[] bb;

        public string GAME_ID { get; private set; }
        public string GAME_REGION { get; private set; }
        public string GAME_NAME_INTERNAL { get; private set; }

        public string _IDRegionName { get; private set; }

        private void LoadInfo(bool image)
        {
            LoadISOInfo(image);
        }

        private void LoadInfoDisc(bool image)
        {
            LoadISOInfoDisc(image);
        }

        private void LoadISOInfo(bool image)
        {
            loadPath = (image) ? IMAGE_PATH : toc.fils[2].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);

            bb = br.ReadBytes(4); // 4
            //tbIDGameCode.Text = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            string IDGameCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Game Code - String

            GAME_REGION = Convert.ToString(ste.Default.GetChars(new byte[] { bb[3] })[0]).ToLower();

            //switch (Convert.ToString(ste.Default.GetChars(new byte[] { bb[3] })[0]).ToLower())
            //{
            //    case "e":
            //        tbIDRegion.Text = "USA/NTSC-U";
            //        REGION = 'u';
            //        break;
            //    case "j":
            //        tbIDRegion.Text = "JAP/NTSC-J";
            //        REGION = 'j';
            //        break;
            //    case "p":
            //        tbIDRegion.Text = "EUR/PAL";
            //        REGION = 'e';
            //        break;
            //    default:
            //        tbIDRegion.Text = "UNK (EUR/PAL ?)";
            //        REGION = 'n';
            //        break;
            //}

            switch (Convert.ToString(ste.Default.GetChars(new byte[] { bb[3] })[0]).ToLower())
            {
                case "e": // AMERICA - USA
                    tbIDRegion.Text = "USA/NTSC-U";
                    REGION = 'u';
                    break;
                case "j": // ASIA - JAPAN
                case "t": // ASIA - TAIWAN
                case "k": // ASIA - KOREA
                    tbIDRegion.Text = "JAP/NTSC-J";
                    REGION = 'j';
                    break;
                case "p": // EUROPE - ALL
                case "f": // EUROPE - FRANCE
                case "d": // EUROPE - GERMANY
                case "s": // EUROPE - SPAIN
                case "i": // EUROPE - ITALY
                case "r": // EUROPE - RUSSIA
                case "y": // EUROPE - France, Belgium, Netherlands ???
                    tbIDRegion.Text = "EUR/PAL";
                    REGION = 'e';
                    break;
                case "u": // AUSTRALIA
                    tbIDRegion.Text = "AUS/PAL";
                    REGION = 'e';
                    break;
                default:
                    tbIDRegion.Text = "UNK (EUR/PAL?)";
                    REGION = 'n';
                    break;
            }

            bb = br.ReadBytes(2); // 2
            string IDMakerCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Maker Code - String
            tbIDMakerCode.Text = IDMakerCode;
            b = br.ReadByte();
            tbIDDiscID.Text = string.Format("0x{0:x2}", b);
            fs.Position += 0x19;

            if (string.Format("0x{0:x2}", b) == "0x00")
            {
                lblTypeDisc.Visible = true;
                lblTypeDisc.Text = GCBM.Properties.Resources.LoadISOInfo_String1;
            }
            else
            {
                lblTypeDisc.Visible = true;
                lblTypeDisc.Text = GCBM.Properties.Resources.LoadISOInfo_String2;
            }

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameInternalName") == true)
            {
                tbIDName.Text = br.ReadStringNT();
                GAME_NAME_INTERNAL = br.ReadStringNT();   
            }

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName") == true)
            {
                GAME_NAME_INTERNAL = br.ReadStringNT();
            }

            br.Close();
            fs.Close();

            loadPath = (image) ? IMAGE_PATH : toc.fils[3].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);
            if (image) fs.Position = toc.fils[3].pos;

            //tbIDDate.Text = br.ReadStringNT();
            tbIDGame.Text = IDGameCode + IDMakerCode; // GameID (IDGameCode + IDMakerCode)
            //_tbIDGameOld = IDGameCode + IDMakerCode; // GameID (IDGameCode + IDMakerCode)
            GAME_ID = IDGameCode + IDMakerCode;

            br.Close();
            fs.Close();

        }

        private void LoadISOInfoDisc(bool image)
        {
            loadPath = (image) ? IMAGE_PATH : toc.fils[2].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);

            bb = br.ReadBytes(4); // 4
            //tbIDGameCode.Text = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            string IDGameCodeDisc = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Game Code - String

            GAME_REGION = Convert.ToString(ste.Default.GetChars(new byte[] { bb[3] })[0]).ToLower();

            switch (Convert.ToString(ste.Default.GetChars(new byte[] { bb[3] })[0]).ToLower())
            {
                case "e": // AMERICA - USA
                    tbIDRegion.Text = "USA/NTSC-U";
                    REGION = 'u';
                    break;
                case "j": // ASIA - JAPAN
                case "t": // ASIA - TAIWAN
                case "k": // ASIA - KOREA
                    tbIDRegion.Text = "JAP/NTSC-J";
                    REGION = 'j';
                    break;
                case "p": // EUROPE - ALL
                case "f": // EUROPE - FRANCE
                case "d": // EUROPE - GERMANY
                case "s": // EUROPE - SPAIN
                case "i": // EUROPE - ITALY
                case "r": // EUROPE - RUSSIA
                case "y": // EUROPE - France, Belgium, Netherlands ???
                    tbIDRegion.Text = "EUR/PAL";
                    REGION = 'e';
                    break;
                case "u": // AUSTRALIA
                    tbIDRegion.Text = "AUS/PAL";
                    REGION = 'e';
                    break;
                default:
                    tbIDRegion.Text = "UNK (EUR/PAL?)";
                    REGION = 'n';
                    break;
            }

            bb = br.ReadBytes(2); // 2
            string IDMakerCodeDisc = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Maker Code - String
            //tbIDMakerCode.Text = IDMakerCode;
            b = br.ReadByte();
            //tbIDDiscID.Text = string.Format("0x{0:x2}", b);
            fs.Position += 0x19;

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameInternalName") == true)
            {
                tbIDNameDisc.Text = br.ReadStringNT();
                GAME_NAME_INTERNAL = br.ReadStringNT();
            }

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName") == true)
            {
                GAME_NAME_INTERNAL = br.ReadStringNT();
            }

            br.Close();
            fs.Close();

            loadPath = (image) ? IMAGE_PATH : toc.fils[3].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);
            if (image) fs.Position = toc.fils[3].pos;

            //tbIDDate.Text = br.ReadStringNT();
            tbIDGameDisc.Text = IDGameCodeDisc + IDMakerCodeDisc; // GameID (IDGameCode + IDMakerCode)
            //_tbIDGameOld = IDGameCode + IDMakerCode; // GameID (IDGameCode + IDMakerCode)
            GAME_ID = IDGameCodeDisc + IDMakerCodeDisc;

            br.Close();
            fs.Close();
        }

    }
}
