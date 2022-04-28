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
            loadPath = (image) ? imgPath : toc.fils[2].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);

            bb = br.ReadBytes(4); // 4
            //tbIDGameCode.Text = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            string IDGameCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Game Code - String

            _IDRegionCode = Convert.ToString(ste.Default.GetChars(new byte[] { bb[3] })[0]).ToLower();

            switch (Convert.ToString(ste.Default.GetChars(new byte[] { bb[3] })[0]).ToLower())
            {
                case "e":
                    tbIDRegion.Text = "USA/NTSC-U";
                    region = 'u';
                    break;
                case "j":
                    tbIDRegion.Text = "JAP/NTSC-J";
                    region = 'j';
                    break;
                case "p":
                    tbIDRegion.Text = "EUR/PAL";
                    region = 'e';
                    break;
                default:
                    tbIDRegion.Text = "UNK";
                    region = 'n';
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

            if (configIniFile.IniReadBool("TITLES", "GameInternalName") == true)
            {
                tbIDName.Text = br.ReadStringNT();
                _oldNameInternal = br.ReadStringNT();   
            }

            if (configIniFile.IniReadBool("TITLES", "GameXmlName") == true)
            {
                _oldNameInternal = br.ReadStringNT();
            }

            br.Close();
            fs.Close();

            loadPath = (image) ? imgPath : toc.fils[3].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);
            if (image) fs.Position = toc.fils[3].pos;

            //tbIDDate.Text = br.ReadStringNT();
            tbIDGame.Text = IDGameCode + IDMakerCode; // GameID (IDGameCode + IDMakerCode)
            //_tbIDGameOld = IDGameCode + IDMakerCode; // GameID (IDGameCode + IDMakerCode)
            _IDMakerCode = IDGameCode + IDMakerCode;

            br.Close();
            fs.Close();

        }

        private void LoadISOInfoDisc(bool image)
        {
            loadPath = (image) ? imgPath : toc.fils[2].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);

            bb = br.ReadBytes(4); // 4
            //tbIDGameCode.Text = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            string IDGameCodeDisc = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Game Code - String

            _IDRegionCode = Convert.ToString(ste.Default.GetChars(new byte[] { bb[3] })[0]).ToLower();

            switch (Convert.ToString(ste.Default.GetChars(new byte[] { bb[3] })[0]).ToLower())
            {
                case "e":
                    tbIDRegionDisc.Text = "USA/NTSC-U";
                    region = 'u';
                    break;
                case "j":
                    tbIDRegionDisc.Text = "JAP/NTSC-J";
                    region = 'j';
                    break;
                case "p":
                    tbIDRegionDisc.Text = "EUR/PAL";
                    region = 'e';
                    break;
                default:
                    tbIDRegionDisc.Text = "UNK";
                    region = 'n';
                    break;
            }
            bb = br.ReadBytes(2); // 2
            string IDMakerCodeDisc = SIOExtensions.ToStringC(ste.Default.GetChars(bb)); // ID Maker Code - String
            //tbIDMakerCode.Text = IDMakerCode;
            b = br.ReadByte();
            //tbIDDiscID.Text = string.Format("0x{0:x2}", b);
            fs.Position += 0x19;

            if (configIniFile.IniReadBool("TITLES", "GameInternalName") == true)
            {
                tbIDNameDisc.Text = br.ReadStringNT();
                _oldNameInternal = br.ReadStringNT();
            }

            if (configIniFile.IniReadBool("TITLES", "GameXmlName") == true)
            {
                _oldNameInternal = br.ReadStringNT();
            }

            br.Close();
            fs.Close();

            loadPath = (image) ? imgPath : toc.fils[3].path;

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

    }
}
