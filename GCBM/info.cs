using System;
using System.Windows.Forms;
using GCBM.Properties;
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
            loadPath = image ? IMAGE_PATH : toc.fils[2].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);

            bb = br.ReadBytes(4); // 4
            //tbIDGameCode.Text = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            var IDGameCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Game Code - String

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
            var IDMakerCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Maker Code - String
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

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName")) _oldNameInternal = br.ReadStringNT();

            br.Close();
            fs.Close();

            loadPath = image ? IMAGE_PATH : toc.fils[3].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);
            if (image) fs.Position = toc.fils[3].pos;

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
            var IDGameCodeDisc = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Game Code - String

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
            var IDMakerCodeDisc = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Maker Code - String
            //tbIDMakerCode.Text = IDMakerCode;
            b = br.ReadByte();
            //tbIDDiscID.Text = string.Format("0x{0:x2}", b);
            fs.Position += 0x19;

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameInternalName"))
            {
                tbIDNameDisc.Text = br.ReadStringNT();
                _oldNameInternal = br.ReadStringNT();
            }

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName")) _oldNameInternal = br.ReadStringNT();

            br.Close();
            fs.Close();

            loadPath = image ? IMAGE_PATH : toc.fils[3].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);
            if (image) fs.Position = toc.fils[3].pos;

            //tbIDDate.Text = br.ReadStringNT();
            tbIDGameDisc.Text = IDGameCodeDisc + IDMakerCodeDisc; // GameID (IDGameCode + IDMakerCode)
            //_tbIDGameOld = IDGameCode + IDMakerCode; // GameID (IDGameCode + IDMakerCode)
            _IDMakerCode = IDGameCodeDisc + IDMakerCodeDisc;

            br.Close();
            fs.Close();
        }


        private Game tempLoadInfo(string path)
        {
            var game = new Game();
            fs = new sio.FileStream(path, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);

            bb = br.ReadBytes(4); // 4
            //tbIDGameCode.Text = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            var IDGameCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Game Code - String

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
            game.Region = tbIDRegion.Text;
            bb = br.ReadBytes(2); // 2
            var IDMakerCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Maker Code - String
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
            game.Title = tbIDName.Text;
            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameInternalName"))
            {
                tbIDName.Text = br.ReadStringNT();
                _oldNameInternal = br.ReadStringNT();
            }

            if (CONFIG_INI_FILE.IniReadBool("TITLES", "GameXmlName")) _oldNameInternal = br.ReadStringNT();

            br.Close();
            fs.Close();
            //DANGER!!!
            loadPath = true ? IMAGE_PATH : toc.fils[3].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);
            if (true) fs.Position = toc.fils[3].pos;

            //tbIDDate.Text = br.ReadStringNT();
            tbIDGame.Text = IDGameCode + IDMakerCode; // GameID (IDGameCode + IDMakerCode)
            //Catch GAMEID here
            game.ID = tbIDGame.Text;
            //_tbIDGameOld = IDGameCode + IDMakerCode; // GameID (IDGameCode + IDMakerCode)
            _IDMakerCode = IDGameCode + IDMakerCode;

            var f = new sio.FileInfo(path);
            game.Extension = f.Extension;
            game.Size = Convert.ToInt32(f.Length);
            game.Path = path;

            br.Close();
            fs.Close();

            return game;
        }
    }
}