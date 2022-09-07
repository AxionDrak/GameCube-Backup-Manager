using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GCBM.tools.Interop;

namespace GCBM.tools.MediaItem;

/// <summary>
/// </summary>
internal class DirectoryItem : IMediaItem
{
    private readonly string displayName;
    private readonly List<IMediaItem> mediaItems = new();

    /// <summary>
    /// </summary>
    /// <param name="directoryPath"></param>
    public DirectoryItem(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
            throw new FileNotFoundException("The directory added to DirectoryItem was not found!", directoryPath);

        Path = directoryPath;
        var fileInfo = new FileInfo(Path);
        displayName = fileInfo.Name;

        //
        // Get all the files in the directory
        //
        var files = Directory.GetFiles(Path);
        foreach (var file in files) mediaItems.Add(new FileItem(file));

        //
        // Get all the subdirectories
        //
        var directories = Directory.GetDirectories(Path);
        foreach (var directory in directories) mediaItems.Add(new DirectoryItem(directory));

        //
        // Get the Directory icon
        //
        var shinfo = new SHFILEINFO();
        _ = Win32.SHGetFileInfo(Path, 0, ref shinfo,
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

            _ = Win32.DestroyIcon(shinfo.hIcon);
        }
    }

    /// <summary>
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// </summary>
    public long SizeOnDisc
    {
        get
        {
            long totalSize = 0;
            foreach (var mediaItem in mediaItems) totalSize += mediaItem.SizeOnDisc;

            return totalSize;
        }
    }

    /// <summary>
    /// </summary>
    public Image FileIconImage { get; }

    /// <summary>
    /// </summary>
    /// <param name="rootItem"></param>
    /// <returns></returns>
    public bool AddToFileSystem(IFsiDirectoryItem rootItem)
    {
        try
        {
            rootItem.AddTree(Path, true);
            return true;
        }
        catch (Exception ex)
        {
            _ = MessageBox.Show(ex.Message, "Error adding folder",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return false;
        }
    }

    /// <summary>
    /// </summary>
    public override string ToString()
    {
        return displayName;
    }
}