using System.Windows.Forms;
using GCBM.Properties;
using sio = System.IO;
using ste = System.Text.Encoding;

namespace GCBM
{
    public partial class frmMain : Form
    {
        private bool ReadImageTOC()
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
            var itemIsDir = false;
            int itemPos;
            int itemLen;
            string itemName;
            var itemGamePath = "";
            string itemPath;

            int itemNum;
            int shift;
            var dirEntry = new int[512];
            var dirEntryCount = 0;
            dirEntry[1] = 99999999;

            var error = false;
            var errorText = "";
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

            if (fsr.Length < toc.dataStart)
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
                namesTableStart = namesTableEntryCount * 12 + 12;

                for (var cnt = 0; cnt < namesTableEntryCount; cnt++)
                {
                    itemNamePtr = mbr.ReadInt32BE();
                    if (itemNamePtr >> 0x18 == 1)
                        itemIsDir = true;
                    itemNamePtr &= 0x00ffffff;
                    itemPos = mbr.ReadInt32BE();
                    itemLen = mbr.ReadInt32BE();
                    prevPos = msr.Position;
                    newPos = namesTableStart + itemNamePtr;
                    msr.Position = newPos;
                    itemName = mbr.ReadStringNT();
                    msr.Position = prevPos;

                    while (dirEntry[dirEntryCount + 1] <= itemNum)
                        dirEntryCount -= 2;

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

                    if (itemIsDir)
                        itemPath += sio.Path.DirectorySeparatorChar;

                    if (RETRIEVE_FILES_INFO)
                    {
                        if (!itemIsDir)
                            if (fsr.Length < itemPos + itemLen)
                            {
                                errorText = string.Format(Resources.ReadImage_String3, itemPath);
                                error = true;
                            }

                        if (error)
                            break;
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
                MessageBox.Show(errorText, Resources.ReadImage_String4, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            error = GenerateTreeView(FILENAME_SORT);

            ROOT_OPENED = false;
            LoadInfo(!ROOT_OPENED);

            return error;
        }

        //*****************************
        private bool ReadImageDiscTOC()
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
            var itemIsDir = false;
            int itemPos;
            int itemLen;
            string itemName;
            var itemGamePath = "";
            string itemPath;

            int itemNum;
            int shift;
            var dirEntry = new int[512];
            var dirEntryCount = 0;
            dirEntry[1] = 99999999;

            var error = false;
            var errorText = "";
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

            if (fsr.Length < toc.dataStart)
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
                namesTableStart = namesTableEntryCount * 12 + 12;

                for (var cnt = 0; cnt < namesTableEntryCount; cnt++)
                {
                    itemNamePtr = mbr.ReadInt32BE();
                    if (itemNamePtr >> 0x18 == 1)
                        itemIsDir = true;
                    itemNamePtr &= 0x00ffffff;
                    itemPos = mbr.ReadInt32BE();
                    itemLen = mbr.ReadInt32BE();
                    prevPos = msr.Position;
                    newPos = namesTableStart + itemNamePtr;
                    msr.Position = newPos;
                    itemName = mbr.ReadStringNT();
                    msr.Position = prevPos;

                    while (dirEntry[dirEntryCount + 1] <= itemNum)
                        dirEntryCount -= 2;

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

                    if (itemIsDir)
                        itemPath += sio.Path.DirectorySeparatorChar;

                    if (RETRIEVE_FILES_INFO)
                    {
                        if (!itemIsDir)
                            if (fsr.Length < itemPos + itemLen)
                            {
                                errorText = string.Format(Resources.ReadImage_String3, itemPath);
                                error = true;
                            }

                        if (error)
                            break;
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
                MessageBox.Show(errorText, Resources.ReadImage_String4, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            error = GenerateTreeView(FILENAME_SORT);

            ROOT_OPENED = false;
            LoadInfoDisc(!ROOT_OPENED);

            return error;
        }

        private delegate string ShowMTFolderDialogCB(string path);

        private delegate bool ShowMTMBoxCB(string text, string caption, MessageBoxButtons btns, MessageBoxIcon icon,
            MessageBoxDefaultButton defBtn, DialogResult desRes);
    } //frmMain
}