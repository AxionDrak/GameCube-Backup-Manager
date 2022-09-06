using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;
using System.Xml.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCBM.Properties;
using sio = System.IO;
using ste = System.Text.Encoding;

namespace GCBM
{
    public class Game
    {
        private static readonly string RES_PATH;
        private static string IMAGE_PATH;
        private static string INI_FILE = "config.ini";
        private const string WIITDB_FILE = "wiitdb.xml";
        private bool ROOT_OPENED = true;
        private readonly bool FILENAME_SORT = true;

        private readonly bool RETRIEVE_FILES_INFO = true;
        private char REGION;
        #region Properties        
        public string Title { get; set; }
        public string InternalName { get; set; }
        public string ID { get; set; }
        public string Region { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public string Path { get; set; }
        public string IDMakerCode { get; set; }
        public string IDGameCode { get; set; }
        public string IDRegionCode { get; set; }
        public string DiscID { get; set; }
        public string Date { get; set; }
        #endregion

        #region fromInfo.cs

        public byte b;
        public byte[] bb;

        public sio.BinaryReader br;
        //sio.MemoryStream bnr = null;
        //sio.BinaryReader bnrr = null;

        public sio.FileStream fs;
        public string loadPath;

        public string _IDMakerCode { get; private set; }
        public string _IDRegionCode { get; private set; }
        public string _oldNameInternal { get; private set; }

        public string _IDRegionName { get; private set; }

        public async void LoadInfo(string path,bool useXmlTitle)
        {
            GetGameInfo(path,useXmlTitle);
        }

        public async void LoadInfo(bool image)
        {

        }
        #endregion

        #region Constructors
        public Game()
        {

        }
        public Task<Game> GetGameInfo(string path,bool useXmlTitle)
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

            if (!useXmlTitle)
            {
                game.Title = game.InternalName;
            }

            if (useXmlTitle)
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
            return Task.FromResult(game);
        }

        public Game(string Title, string ID, string Region, string Extension, int Size, string Path)
        {
            this.Title = Title;
            this.ID = ID;
            this.Region = Region;
            this.Extension = Extension;
            this.Size = Size;
            this.Path = Path;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Inform the user they should download WiiTDB.
        /// </summary>
        public void CheckWiiTdbXml()
        {
            _ = MessageBox.Show(Resources.ProcessTaskDelay_String1 + Environment.NewLine +
                            Resources.ProcessTaskDelay_String2 +
                            Environment.NewLine + Environment.NewLine +
                            Resources.ProcessTaskDelay_String3 +
                            Environment.NewLine + Environment.NewLine +
                            Resources.ProcessTaskDelay_String4,
                Resources.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public override string ToString()
        {
            return Title + " [" + ID + "]";
        }
        #endregion



        public TOCClass toc;

        public void GetFilDirInfo(sio.DirectoryInfo pDir, ref int itemNum, ref int filePos)
        {
            sio.DirectoryInfo di;
            sio.DirectoryInfo[] dirs;
            sio.FileInfo[] fils;
            TOCItemFil tif;
            int tocDirIdx = itemNum - 1;

            dirs = pDir.GetDirectories();
            for (int cnt = 0; cnt < dirs.Length; cnt++)
            {
                if (dirs[cnt].Name.ToLower() == "&&systemdata")
                {
                    di = dirs[0];
                    dirs[0] = dirs[cnt];
                    dirs[cnt] = di;
                    break;
                }
            }

            for (int cnt = 0; cnt < dirs.Length; cnt++)
            {
                tif = new TOCItemFil(itemNum, tocDirIdx, tocDirIdx, 0, true,
                    dirs[cnt].Name, dirs[cnt].FullName.Replace(RES_PATH, ""), dirs[cnt].FullName);
                toc.fils.Add(tif);
                itemNum += 1;
                toc.dirCount += 1;
                GetFilDirInfo(dirs[cnt], ref itemNum, ref filePos);
            }

            fils = pDir.GetFiles();
            for (int cnt = 0; cnt < fils.Length; cnt++)
            {
                tif = new TOCItemFil(itemNum, tocDirIdx, filePos, (int)fils[cnt].Length, false,
                    fils[cnt].Name, fils[cnt].FullName.Replace(RES_PATH, ""), fils[cnt].FullName);
                toc.fils.Add(tif);
                toc.fils[0].len = toc.fils.Count;
                filePos += 2;
                itemNum += 1;
                toc.filCount += 1;
            }

            toc.fils[tocDirIdx].len = itemNum;
        }

        public bool GenerateTreeView(bool fileNameSort)
        {
            List<TreeNode> tns = new List<TreeNode>();
            TreeNode tn, tnn;
            int idx;
            int j;

            tn = new TreeNode(toc.fils[0].name, 0, 0)
            {
                Name = toc.fils[0].TOCIdx.ToString(),
                ToolTipText = RES_PATH
            };
            toc.fils[0].node = tn;
            tns.Add(tn);

            if (fileNameSort)
            {
                for (int i = 1; i < toc.fils.Count; i++)
                {
                    if (toc.fils[i].isDir)
                    {
                        for (j = 0; j < tns.Count; j++)
                        {
                            if (tns[j].Name == toc.fils[i].dirIdx.ToString())
                            {
                                break;
                            }
                        }

                        if (j == tns.Count)
                        {
                            _ = MessageBox.Show("GenerateTreeView() error: dir2dir not found", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        tn = tns[j];
                        tnn = new TreeNode(toc.fils[i].name, 1, 2)
                        {
                            Name = toc.fils[i].TOCIdx.ToString(),
                            ToolTipText = toc.fils[i].path,
                            Tag = i
                        };
                        toc.fils[i].node = tnn;
                        tns.Add(tnn);
                        _ = tn.Nodes.Add(tnn);
                    }
                    else
                    {
                        for (j = 0; j < tns.Count; j++)
                        {
                            if (tns[j].Name == toc.fils[i].dirIdx.ToString())
                            {
                                break;
                            }
                        }

                        if (j == tns.Count)
                        {
                            _ = MessageBox.Show("GenerateTreeView() error: dir2fil not found", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        tn = tns[j];
                        tnn = new TreeNode(toc.fils[i].name, 3, 3)
                        {
                            Name = toc.fils[i].TOCIdx.ToString(),
                            ToolTipText = toc.fils[i].path,
                            Tag = i
                        };
                        toc.fils[i].node = tnn;
                        _ = tn.Nodes.Add(tnn);
                    }
                }
            }
            else
            {
                idx = 2;
                for (int i = 1; i < toc.fils.Count; i++)
                {
                    if (!toc.fils[i].isDir)
                    {
                        tnn = new TreeNode(toc.fils[idx].gamePath, 3, 3)
                        {
                            Name = toc.fils[idx].TOCIdx.ToString(),
                            ToolTipText = toc.fils[idx].path,
                            Tag = idx
                        };
                        toc.fils[idx].node = tnn;
                        _ = tn.Nodes.Add(tnn);
                        if (toc.fils[idx].name == "opening.bnr")
                        {
                        }

                        idx = toc.fils[i].nextIdx;
                    }
                }
            }

            return true;
        }

        //public delegate void ResetProgressBarCB(int min, int max, int val);
        //public delegate void UpdateProgressBarCB(int val);
        //public delegate void UpdateActionLabelCB(string text);
        public delegate void ResetControlsCB(bool error, string errorText);

        public delegate int ModCB(int val);

        #region TOC class

        public class TOCClass : IComparer<TOCItemFil>, ICloneable
        {
            public readonly List<TOCItemFil> fils;
            public int dataStart;
            public int dirCount = 1;
            public int filCount = 4;
            public int lastIdx;
            public int startIdx;
            public int totalLen;

            public TOCClass(string resPath)
            {
                fils = new List<TOCItemFil>
                {
                    new TOCItemFil(0, 0, 0, 99999, true, "root", "", resPath),
                    new TOCItemFil(1, 0, 0, 6, true, "&&SystemData", "&&systemdata" + sio.Path.DirectorySeparatorChar,
                    resPath + "&&systemdata" + sio.Path.DirectorySeparatorChar),
                    new TOCItemFil(2, 1, 0, 99999, false, "ISO.hdr", "&&SystemData" + sio.Path.DirectorySeparatorChar + "iso.hdr",
                    resPath + "&&SystemData" + sio.Path.DirectorySeparatorChar + "iso.hdr"),
                    new TOCItemFil(3, 1, 9280, 99999, false, "AppLoader.ldr", "&&SystemData" + sio.Path.DirectorySeparatorChar + "apploader.ldr",
                    resPath + "&&SystemData" + sio.Path.DirectorySeparatorChar + "apploader.ldr"),
                    new TOCItemFil(4, 1, 0, 99999, false, "Start.dol", "&&SystemData" + sio.Path.DirectorySeparatorChar + "start.dol",
                    resPath + "&&SystemData" + sio.Path.DirectorySeparatorChar + "start.dol"),
                    new TOCItemFil(5, 1, 0, 99999, false, "Game.toc", "&&SystemData" + sio.Path.DirectorySeparatorChar + "game.toc",
                    resPath + "&&SystemData" + sio.Path.DirectorySeparatorChar + "game.toc")
                };

                totalLen = 0;
                dataStart = totalLen;
                startIdx = totalLen;
            }

            #region ICloneable Members

            public object Clone()
            {
                TOCClass res;

                res = new TOCClass(fils[0].path);
                res.fils.Clear();
                res.dirCount = dirCount;
                res.filCount = filCount;
                for (int i = 0; i < fils.Count; i++)
                {
                    res.fils.Add((TOCItemFil)fils[i].Clone());
                }

                return res;
            }

            #endregion

            #region IComparer<TOCItemFil> Members

            public int Compare(TOCItemFil x, TOCItemFil y)
            {
                return x.pos > y.pos ? 1 : x.pos < y.pos ? -1 : 0;
            }

            #endregion
        }

        public class TOCItemFil : ICloneable
        {
            public readonly int dirIdx;
            public readonly string gamePath;
            public readonly bool isDir;
            public readonly string name;
            public readonly string path;
            public readonly int TOCIdx;
            public int len;
            public int nextIdx;
            public TreeNode node;
            public int pos;
            public int prevIdx;

            public TOCItemFil(int TOCIdx, int dirIdx, int pos, int len, bool isDir, string name, string gamePath,
                string path)
            {
                this.TOCIdx = TOCIdx;
                this.dirIdx = dirIdx;
                this.pos = pos;
                this.len = len;
                this.isDir = isDir;
                this.name = name;
                this.gamePath = gamePath;
                this.path = path;
            }

            #region ICloneable Members

            public object Clone()
            {
                return new TOCItemFil(TOCIdx, dirIdx, pos, len, isDir, name, gamePath, path);
            }

            #endregion
        }

        #endregion

        public bool ReadImageTOC()
        {
            TOCItemFil tif;
            sio.FileStream fsr;
            sio.BinaryReader brr;
            sio.MemoryStream msr;
            sio.BinaryReader mbr;
            long prevPos, newPos;

            int namesTableEntryCount;
            int namesTableStart;
            int itemNamePtr;
            bool itemIsDir = false;
            int itemPos;
            int itemLen;
            string itemName;
            string itemGamePath = "";
            string itemPath;

            int itemNum;
            int shift;
            int[] dirEntry = new int[512];
            int dirEntryCount = 0;
            dirEntry[1] = 99999999;

            bool error = false;
            string errorText = "";
            int i, j;

            toc = new TOCClass(RES_PATH);
            itemNum = toc.fils.Count;
            shift = toc.fils.Count - 1;

            try { fsr = new sio.FileStream(IMAGE_PATH, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read); }
            catch (sio.IOException)
            {
                error = true;
                errorText = Resources.CantOpenImage;
                return false;
            }

            brr = new sio.BinaryReader(fsr, ste.Default);

            if (fsr.Length > 0x0438)
            {
                fsr.Position = 0x0400;
                toc.fils[2].pos = 0x0;
                toc.fils[2].len = 0x2440;
                toc.fils[3].pos = 0x2440;
                toc.fils[3].len = brr.ReadInt32BE();
                fsr.Position += 0x1c;
                toc.fils[4].pos = brr.ReadInt32BE();
                toc.fils[5].pos = brr.ReadInt32BE();
                toc.fils[5].len = brr.ReadInt32BE();
                toc.fils[4].len = toc.fils[5].pos - toc.fils[4].pos;
                fsr.Position += 0x08;
                toc.dataStart = brr.ReadInt32BE();

                toc.totalLen = (int)fsr.Length;
            }
            else
            {
                errorText = Resources.ReadImage_String1 + " " + IMAGE_PATH;
                error = true;
            }

            if (fsr.Length < toc.dataStart && !IMAGE_PATH.ToLower().EndsWith(".nkit.iso"))
            {
                errorText = Resources.ReadImage_String1 + " " + IMAGE_PATH + ": expected length of " + toc.dataStart + " but got " + fsr.Length + ".";
                error = true;
            }

            if (!error)
            {
                fsr.Position = toc.fils[5].pos;
                msr = new sio.MemoryStream(brr.ReadBytes(toc.fils[5].len));
                mbr = new sio.BinaryReader(msr, ste.Default);

                i = mbr.ReadInt32();
                if (i != 1)
                {
                    error = true;
                    errorText = Resources.ReadImage_String2;
                }

                i = mbr.ReadInt32();
                if (i != 0)
                {
                    error = true;
                    errorText = Resources.ReadImage_String2;
                }

                namesTableEntryCount = mbr.ReadInt32BE() - 1;
                namesTableStart = (namesTableEntryCount * 12) + 12;

                for (int cnt = 0; cnt < namesTableEntryCount; cnt++)
                {
                    itemNamePtr = mbr.ReadInt32BE();
                    if (itemNamePtr >> 0x18 == 1)
                    {
                        itemIsDir = true;
                    }

                    itemNamePtr &= 0x00ffffff;
                    itemPos = mbr.ReadInt32BE();
                    itemLen = mbr.ReadInt32BE();
                    prevPos = msr.Position;
                    newPos = namesTableStart + itemNamePtr;
                    msr.Position = newPos;
                    itemName = mbr.ReadStringNT();
                    msr.Position = prevPos;

                    while (dirEntry[dirEntryCount + 1] <= itemNum)
                    {
                        dirEntryCount -= 2;
                    }

                    if (itemIsDir)
                    {
                        dirEntryCount += 2;
                        dirEntry[dirEntryCount] = itemPos > 0 ? itemPos + shift : itemPos;
                        itemPos += shift;
                        itemLen += shift;
                        dirEntry[dirEntryCount + 1] = itemLen;
                        toc.dirCount += 1;
                    }
                    else
                    {
                        toc.filCount += 1;
                    }

                    itemPath = itemName;
                    j = dirEntry[dirEntryCount];
                    for (i = 0; i < 256; i++)
                    {
                        if (j == 0)
                        {
                            itemGamePath = itemPath;
                            itemPath = RES_PATH + itemPath;
                            break;
                        }
                        else
                        {
                            itemPath = itemPath.Insert(0, toc.fils[j].name + sio.Path.DirectorySeparatorChar);
                            j = toc.fils[j].dirIdx;
                        }
                    }

                    if (itemIsDir)
                    {
                        itemPath += sio.Path.DirectorySeparatorChar;
                    }

                    if (RETRIEVE_FILES_INFO)
                    {
                        if (!itemIsDir)
                        {
                            if (fsr.Length < itemPos + itemLen)
                            {
                                errorText = string.Format(Resources.ReadImage_String3, itemPath);
                                error = true;
                            }
                        }

                        if (error)
                        {
                            break;
                        }
                    }

                    tif = new TOCItemFil(itemNum, dirEntry[dirEntryCount], itemPos, itemLen, itemIsDir, itemName,
                        itemGamePath, itemPath);
                    toc.fils.Add(tif);
                    toc.fils[0].len = toc.fils.Count;

                    if (itemIsDir)
                    {
                        dirEntry[dirEntryCount] = itemNum;
                        itemIsDir = false;
                    }

                    itemNum += 1;
                }

                mbr.Close();
                msr.Close();
            }

            brr.Close();
            fsr.Close();

            if (error)
            {
                _ = MessageBox.Show(errorText, Resources.ReadImage_String4, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //        private void DisplaySourceFiles(string sourceFolder)

            ROOT_OPENED = false;
            LoadInfo(!ROOT_OPENED);

            return error;
        }

        //*****************************
        public bool ReadImageDiscTOC()
        {
            TOCItemFil tif;
            sio.FileStream fsr;
            sio.BinaryReader brr;
            sio.MemoryStream msr;
            sio.BinaryReader mbr;
            long prevPos, newPos;

            int namesTableEntryCount;
            int namesTableStart;
            int itemNamePtr;
            bool itemIsDir = false;
            int itemPos;
            int itemLen;
            string itemName;
            string itemGamePath = "";
            string itemPath;

            int itemNum;
            int shift;
            int[] dirEntry = new int[512];
            int dirEntryCount = 0;
            dirEntry[1] = 99999999;

            bool error = false;
            string errorText = "";
            int i, j;

            toc = new TOCClass(RES_PATH);
            itemNum = toc.fils.Count;
            shift = toc.fils.Count - 1;

            fsr = new sio.FileStream(IMAGE_PATH, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            brr = new sio.BinaryReader(fsr, ste.Default);

            if (fsr.Length > 0x0438)
            {
                fsr.Position = 0x0400;
                toc.fils[2].pos = 0x0;
                toc.fils[2].len = 0x2440;
                toc.fils[3].pos = 0x2440;
                toc.fils[3].len = brr.ReadInt32BE();
                fsr.Position += 0x1c;
                toc.fils[4].pos = brr.ReadInt32BE();
                toc.fils[5].pos = brr.ReadInt32BE();
                toc.fils[5].len = brr.ReadInt32BE();
                toc.fils[4].len = toc.fils[5].pos - toc.fils[4].pos;
                fsr.Position += 0x08;
                toc.dataStart = brr.ReadInt32BE();

                toc.totalLen = (int)fsr.Length;
            }
            else
            {
                errorText = Resources.ReadImage_String1 + " " + IMAGE_PATH;
                error = true;
            }

            if (fsr.Length < toc.dataStart && !IMAGE_PATH.ToLower().EndsWith(".nkit.iso"))
            {
                errorText = Resources.ReadImage_String1 + " " + IMAGE_PATH + ": expected length of " + toc.dataStart + " but got " + fsr.Length + ".";
                error = true;
            }

            if (!error)
            {
                fsr.Position = toc.fils[5].pos;
                msr = new sio.MemoryStream(brr.ReadBytes(toc.fils[5].len));
                mbr = new sio.BinaryReader(msr, ste.Default);

                i = mbr.ReadInt32();
                if (i != 1)
                {
                    error = true;
                    errorText = Resources.ReadImage_String2;
                }

                i = mbr.ReadInt32();
                if (i != 0)
                {
                    error = true;
                    errorText = Resources.ReadImage_String2;
                }

                namesTableEntryCount = mbr.ReadInt32BE() - 1;
                namesTableStart = (namesTableEntryCount * 12) + 12;

                for (int cnt = 0; cnt < namesTableEntryCount; cnt++)
                {
                    itemNamePtr = mbr.ReadInt32BE();
                    if (itemNamePtr >> 0x18 == 1)
                    {
                        itemIsDir = true;
                    }

                    itemNamePtr &= 0x00ffffff;
                    itemPos = mbr.ReadInt32BE();
                    itemLen = mbr.ReadInt32BE();
                    prevPos = msr.Position;
                    newPos = namesTableStart + itemNamePtr;
                    msr.Position = newPos;
                    itemName = mbr.ReadStringNT();
                    msr.Position = prevPos;

                    while (dirEntry[dirEntryCount + 1] <= itemNum)
                    {
                        dirEntryCount -= 2;
                    }

                    if (itemIsDir)
                    {
                        dirEntryCount += 2;
                        dirEntry[dirEntryCount] = itemPos > 0 ? itemPos + shift : itemPos;
                        itemPos += shift;
                        itemLen += shift;
                        dirEntry[dirEntryCount + 1] = itemLen;
                        toc.dirCount += 1;
                    }
                    else
                    {
                        toc.filCount += 1;
                    }

                    itemPath = itemName;
                    j = dirEntry[dirEntryCount];
                    for (i = 0; i < 256; i++)
                    {
                        if (j == 0)
                        {
                            itemGamePath = itemPath;
                            itemPath = RES_PATH + itemPath;
                            break;
                        }
                        else
                        {
                            itemPath = itemPath.Insert(0, toc.fils[j].name + sio.Path.DirectorySeparatorChar);
                            j = toc.fils[j].dirIdx;
                        }
                    }

                    if (itemIsDir)
                    {
                        itemPath += sio.Path.DirectorySeparatorChar;
                    }

                    if (RETRIEVE_FILES_INFO)
                    {
                        if (!itemIsDir)
                        {
                            if (fsr.Length < itemPos + itemLen)
                            {
                                errorText = string.Format(Resources.ReadImage_String3, itemPath);
                                error = true;
                            }
                        }

                        if (error)
                        {
                            break;
                        }
                    }

                    tif = new TOCItemFil(itemNum, dirEntry[dirEntryCount], itemPos, itemLen, itemIsDir, itemName,
                        itemGamePath, itemPath);
                    toc.fils.Add(tif);
                    toc.fils[0].len = toc.fils.Count;

                    if (itemIsDir)
                    {
                        dirEntry[dirEntryCount] = itemNum;
                        itemIsDir = false;
                    }

                    itemNum += 1;
                }

                mbr.Close();
                msr.Close();
            }

            brr.Close();
            fsr.Close();

            if (error)
            {
                _ = MessageBox.Show(errorText, Resources.ReadImage_String4, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //        private void DisplaySourceFiles(string sourceFolder)

            ROOT_OPENED = false;
            LoadInfo(!ROOT_OPENED);

            return error;
        }

        public delegate string ShowMTFolderDialogCB(string path);

        public delegate bool ShowMTMBoxCB(string text, string caption, MessageBoxButtons btns, MessageBoxIcon icon,
            MessageBoxDefaultButton defBtn, DialogResult desRes);
    }
}