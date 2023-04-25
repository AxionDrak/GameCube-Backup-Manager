using GCBM.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using sio = System.IO;
using ste = System.Text.Encoding;

namespace GCBM;

public class Game
{
    public delegate int ModCB(int val);

    //public delegate void ResetProgressBarCB(int min, int max, int val);
    //public delegate void UpdateProgressBarCB(int val);
    //public delegate void UpdateActionLabelCB(string text);
    public delegate void ResetControlsCB(bool error, string errorText);

    public delegate string ShowMTFolderDialogCB(string path);

    public delegate bool ShowMTMBoxCB(string text, string caption, MessageBoxButtons btns, MessageBoxIcon icon,
        MessageBoxDefaultButton defBtn, DialogResult desRes);

    private const string WIITDB_FILE = "wiitdb.xml";
    private static readonly string RES_PATH;
    private static string IMAGE_PATH;
    private readonly bool RETRIEVE_FILES_INFO = true;
    private char REGION;
    private bool ROOT_OPENED = true;

    #region TOC class

    public class TOCClass : IComparer<TOCItemFile>, ICloneable
    {
        public readonly List<TOCItemFile> files;
        public int dataStart;
        public int dirCount = 1;
        public int filCount = 4;
        public int lastIdx;
        public int startIdx;
        public int totalLen;

        public TOCClass(string resPath)
        {
            files = new List<TOCItemFile>
            {
                new(0, 0, 0, 99999, true, "root", "", resPath),
                new(1, 0, 0, 6, true, "&&SystemData", "&&systemdata" + sio.Path.DirectorySeparatorChar,
                    resPath + "&&systemdata" + sio.Path.DirectorySeparatorChar),
                new(2, 1, 0, 99999, false, "ISO.hdr", "&&SystemData" + sio.Path.DirectorySeparatorChar + "iso.hdr",
                    resPath + "&&SystemData" + sio.Path.DirectorySeparatorChar + "iso.hdr"),
                new(3, 1, 9280, 99999, false, "AppLoader.ldr",
                    "&&SystemData" + sio.Path.DirectorySeparatorChar + "apploader.ldr",
                    resPath + "&&SystemData" + sio.Path.DirectorySeparatorChar + "apploader.ldr"),
                new(4, 1, 0, 99999, false, "Start.dol", "&&SystemData" + sio.Path.DirectorySeparatorChar + "start.dol",
                    resPath + "&&SystemData" + sio.Path.DirectorySeparatorChar + "start.dol"),
                new(5, 1, 0, 99999, false, "Game.toc", "&&SystemData" + sio.Path.DirectorySeparatorChar + "game.toc",
                    resPath + "&&SystemData" + sio.Path.DirectorySeparatorChar + "game.toc")
            };

            totalLen = 0;
            dataStart = totalLen;
            startIdx = totalLen;
        }

        #region ICloneable Members

        public object Clone()
        {
            var res = new TOCClass(files[0].path);
            res.files.Clear();
            res.dirCount = dirCount;
            res.filCount = filCount;
            for (var i = 0; i < files.Count; i++) res.files.Add((TOCItemFile)files[i].Clone());

            return res;
        }

        #endregion

        #region IComparer<TOCItemFil> Members

        public int Compare(TOCItemFile x, TOCItemFile y)
        {
            return x.pos > y.pos ? 1 : x.pos < y.pos ? -1 : 0;
        }

        #endregion
    }

    public class TOCItemFile : ICloneable
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

        public TOCItemFile(int TOCIdx, int dirIdx, int pos, int len, bool isDir, string name, string gamePath,
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
            return new TOCItemFile(TOCIdx, dirIdx, pos, len, isDir, name, gamePath, path);
        }

        #endregion
    }

    #endregion

    public TOCClass toc;

    public (int, int) GetFileDirInfo(sio.DirectoryInfo pDir, int itemNum, int filePos)
    {
        TOCItemFile tif;
        var tocDirIdx = itemNum - 1;

        var dirs = pDir.GetDirectories();
        for (var cnt = 0; cnt < dirs.Length; cnt++)
        {
            if (dirs[cnt].Name.ToLower() == "&&systemdata")
            {
                var temp = dirs[0];
                dirs[0] = dirs[cnt];
                dirs[cnt] = temp;
                break;
            }
        }

        foreach (var dir in dirs)
        {
            tif = new TOCItemFile(itemNum, tocDirIdx, tocDirIdx, 0, true,
                dir.Name, dir.FullName.Replace(RES_PATH, ""), dir.FullName);
            toc.files.Add(tif);
            itemNum += 1;
            toc.dirCount += 1;
            (itemNum, filePos) = GetFileDirInfo(dir, itemNum, filePos);
        }

        var fils = pDir.GetFiles();
        foreach (var file in fils)
        {
            tif = new TOCItemFile(itemNum, tocDirIdx, filePos, (int)file.Length, false,
                file.Name, file.FullName.Replace(RES_PATH, ""), file.FullName);
            toc.files.Add(tif);
            var curFile = toc.files[0];
            curFile.len = toc.files.Count;
            filePos += 2;
            itemNum += 1;
            toc.filCount += 1;
        }

        toc.files[tocDirIdx].len = itemNum;
        return (itemNum, filePos);
    }

    //public void GetFileDirInfo(sio.DirectoryInfo pDir, ref int itemNum, ref int filePos)
    //{
    //    TOCItemFile tif;
    //    var tocDirIdx = itemNum - 1;

    //    var dirs = pDir.GetDirectories();
    //    for (var cnt = 0; cnt < dirs.Length; cnt++)
    //        if (dirs[cnt].Name.ToLower() == "&&systemdata")
    //        {
    //            (dirs[0], dirs[cnt]) = (dirs[cnt], dirs[0]);
    //            break;
    //        }

    //    foreach (var t in dirs)
    //    {
    //        tif = new TOCItemFile(itemNum, tocDirIdx, tocDirIdx, 0, true,
    //            t.Name, t.FullName.Replace(RES_PATH, ""), t.FullName);
    //        toc.files.Add(tif);
    //        itemNum += 1;
    //        toc.dirCount += 1;
    //        GetFileDirInfo(t, ref itemNum, ref filePos);
    //    }

    //    var fils = pDir.GetFiles();
    //    foreach (var t in fils)
    //    {
    //        tif = new TOCItemFile(itemNum, tocDirIdx, filePos, (int)t.Length, false,
    //            t.Name, t.FullName.Replace(RES_PATH, ""), t.FullName);
    //        toc.files.Add(tif);
    //        toc.files[0].len = toc.files.Count;
    //        filePos += 2;
    //        itemNum += 1;
    //        toc.filCount += 1;
    //    }

    //    toc.files[tocDirIdx].len = itemNum;
    //}
    public bool ReadImageTOC()
    {
        sio.FileStream fsr;

        var itemIsDir = false;
        var itemGamePath = "";

        var dirEntry = new int[512];
        var dirEntryCount = 0;
        dirEntry[1] = 99999999;

        var error = false;
        var errorText = "";

        toc = new TOCClass(RES_PATH);
        var itemNum = toc.files.Count;
        var shift = toc.files.Count - 1;

        try
        {
            fsr = new sio.FileStream(IMAGE_PATH, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
        }
        catch (sio.IOException)
        {
            error = true;
            errorText = Resources.CantOpenImage;
            return false;
        }

        var brr = new sio.BinaryReader(fsr, ste.Default);

        if (fsr.Length > 0x0438)
        {
            fsr.Position = 0x0400;
            toc.files[2].pos = 0x0;
            toc.files[2].len = 0x2440;
            toc.files[3].pos = 0x2440;
            toc.files[3].len = brr.ReadInt32BE();
            fsr.Position += 0x1c;
            toc.files[4].pos = brr.ReadInt32BE();
            toc.files[5].pos = brr.ReadInt32BE();
            toc.files[5].len = brr.ReadInt32BE();
            toc.files[4].len = toc.files[5].pos - toc.files[4].pos;
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
            errorText = Resources.ReadImage_String1 + " " + IMAGE_PATH + ": expected length of " + toc.dataStart +
                        " but got " + fsr.Length + ".";
            error = true;
        }

        if (!error)
        {
            fsr.Position = toc.files[5].pos;
            var msr = new sio.MemoryStream(brr.ReadBytes(toc.files[5].len));
            var mbr = new sio.BinaryReader(msr, ste.Default);

            var i = mbr.ReadInt32();
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

            var namesTableEntryCount = mbr.ReadInt32BE() - 1;
            var namesTableStart = namesTableEntryCount * 12 + 12;

            for (var cnt = 0; cnt < namesTableEntryCount; cnt++)
            {
                var itemNamePtr = mbr.ReadInt32BE();
                if (itemNamePtr >> 0x18 == 1) itemIsDir = true;

                itemNamePtr &= 0x00ffffff;
                var itemPos = mbr.ReadInt32BE();
                var itemLen = mbr.ReadInt32BE();
                var prevPos = msr.Position;
                long newPos = namesTableStart + itemNamePtr;
                msr.Position = newPos;
                var itemName = mbr.ReadStringNT();
                msr.Position = prevPos;

                while (dirEntry[dirEntryCount + 1] <= itemNum) dirEntryCount -= 2;

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

                var itemPath = itemName;
                var j = dirEntry[dirEntryCount];
                for (i = 0; i < 256; i++)
                    if (j == 0)
                    {
                        itemGamePath = itemPath;
                        itemPath = RES_PATH + itemPath;
                        break;
                    }
                    else
                    {
                        itemPath = itemPath.Insert(0, toc.files[j].name + sio.Path.DirectorySeparatorChar);
                        j = toc.files[j].dirIdx;
                    }

                if (itemIsDir) itemPath += sio.Path.DirectorySeparatorChar;

                if (RETRIEVE_FILES_INFO)
                {
                    if (!itemIsDir)
                        if (fsr.Length < itemPos + itemLen)
                        {
                            errorText = string.Format(Resources.ReadImage_String3, itemPath);
                            error = true;
                        }

                    if (error) break;
                }

                var tif = new TOCItemFile(itemNum, dirEntry[dirEntryCount], itemPos, itemLen, itemIsDir, itemName,
                    itemGamePath, itemPath);
                toc.files.Add(tif);
                toc.files[0].len = toc.files.Count;

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
    public char IDRegionCode { get; set; }
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

    public async void LoadInfo(bool image)
    {
    }

    #endregion

    #region Constructors
    public Game()
    {

    }
    public Game(string path, bool useXmlTitle)
    {
        Path = path;


        using (var fs = new sio.FileStream(path, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read))
        using (var br = new sio.BinaryReader(fs, ste.Default))
        {
            if (path.EndsWith(".ciso"))
            {
                //CISOReader 
                //ID = CISOReader.GameID(path);
                fs.Seek(0x8000, SeekOrigin.Begin);
            }

            var bb = br.ReadBytes(4);
            IDGameCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            string RegionLetter = Convert.ToChar(bb[3]).ToString().ToLower();
            IDRegionCode = Convert.ToChar(RegionLetter);

            var regionMap = new Dictionary<char, string>
        {
            { 'e', "USA/NTSC-U" },
            { 'j', "JAP/NTSC-J" },
            { 'p', "EUR/PAL" },
        };

            if (regionMap.TryGetValue(IDRegionCode, out string region))
            {
                Region = region;
                REGION = IDRegionCode;
            }
            else
            {
                Region = "UNK";
                REGION = 'n';
            }

            bb = br.ReadBytes(2);
            IDMakerCode = SIOExtensions.ToStringC(ste.Default.GetChars(bb));

            var b = br.ReadByte();
            DiscID = $"0x{b:x2}";

            fs.Position += 0x19;
            InternalName = br.ReadStringNT();
            Title = InternalName;
            ID = IDGameCode + IDMakerCode;

            if (useXmlTitle)
            {
                Title = getXmlTitle(ID);
            }

            Date = br.ReadStringNT();
            var f = new sio.FileInfo(path);
            Extension = f.Extension;
            try
            {
                Size = Convert.ToInt32(f.Length);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    #endregion
    public string getXmlTitle(string id)
    {
        string title = "";
        if (sio.File.Exists(WIITDB_FILE))
        {
            var root = XElement.Load(WIITDB_FILE);
            IEnumerable<XElement> tests = root.Elements("game").AsParallel()
                .Where(el => (string)el.Element("id") == id);
            foreach (var el in tests) title = (string)el.Element("locale")?.Element("title");
        }
        else
        {
            CheckWiiTdbXml();
            title = "error";
        }

        return title;

    }


    #region Methods

    /// <summary>
    ///     Inform the user they should download WiiTDB.
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
    public class CISOReader
    {
        public static string GameID(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException("CISO file not found.", filePath);

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] gameIdBytes = new byte[6];
                fs.Seek(0x8000, SeekOrigin.Begin); // Assuming the CISO header is 32 KB (0x8000) in size
                fs.Read(gameIdBytes, 0, gameIdBytes.Length);
                return Encoding.ASCII.GetString(gameIdBytes);
            }
        }
    }
}