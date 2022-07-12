using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using PluginBurnMedia.Interop;

namespace PluginBurnMedia.MediaItem
{
    /// <summary>
    /// </summary>
    internal class FileItem : IMediaItem
    {
        private const long SECTOR_SIZE = 2048;
        private readonly string displayName;

        private readonly long m_fileLength;

        public FileItem(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("The file added to FileItem was not found!", path);

            Path = path;

            var fileInfo = new FileInfo(Path);
            displayName = fileInfo.Name;
            m_fileLength = fileInfo.Length;

            //
            // Get the File icon
            //
            var shinfo = new SHFILEINFO();
            var hImg = Win32.SHGetFileInfo(Path, 0, ref shinfo,
                (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);

            if (shinfo.hIcon != null)
            {
                //The icon is returned in the hIcon member of the shinfo struct
                var imageConverter = new IconConverter();
                var icon = Icon.FromHandle(shinfo.hIcon);
                try
                {
                    FileIconImage = (Image)
                        imageConverter.ConvertTo(icon, typeof(Image));
                }
                catch (NotSupportedException)
                {
                }

                Win32.DestroyIcon(shinfo.hIcon);
            }
        }

        /// <summary>
        /// </summary>
        public long SizeOnDisc
        {
            get
            {
                if (m_fileLength > 0) return (m_fileLength / SECTOR_SIZE + 1) * SECTOR_SIZE;

                return 0;
            }
        }

        /// <summary>
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// </summary>
        public Image FileIconImage { get; }

        public bool AddToFileSystem(IFsiDirectoryItem rootItem)
        {
            IStream stream = null;

            try
            {
                Win32.SHCreateStreamOnFile(Path, Win32.STGM_READ | Win32.STGM_SHARE_DENY_WRITE, ref stream);

                if (stream != null)
                {
                    rootItem.AddFile(displayName, stream);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding file",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (stream != null) Marshal.FinalReleaseComObject(stream);
            }

            return false;
        }


        /// <summary>
        /// </summary>
        public override string ToString()
        {
            return displayName;
        }
    }
}