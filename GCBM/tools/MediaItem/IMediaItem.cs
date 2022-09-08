using GCBM.tools.Interop;
using System.Drawing;

namespace GCBM.tools.MediaItem;

internal interface IMediaItem
{
    /// <summary>
    ///     Returns the full path of the file or directory
    /// </summary>
    string Path { get; }

    /// <summary>
    ///     Returns the size of the file or directory to the next largest sector
    /// </summary>
    long SizeOnDisc { get; }

    /// <summary>
    ///     Returns the Icon of the file or directory
    /// </summary>
    Image FileIconImage { get; }

    // Adds the file or directory to the directory item, usually the root.
    bool AddToFileSystem(IFsiDirectoryItem rootItem);
}