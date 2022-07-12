using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComImport]
    [CoClass(typeof(MsftFileSystemImageClass))]
    [Guid("2C941FE1-975B-59BE-A960-9A2A262853A5")]
    public interface MsftFileSystemImage : IFileSystemImage, DFileSystemImage_Event
    {
    }
}