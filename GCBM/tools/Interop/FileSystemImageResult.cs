using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComImport]
    [Guid("2C941FD8-975B-59BE-A960-9A2A262853A5")]
    [CoClass(typeof(FileSystemImageResultClass))]
    public interface FileSystemImageResult : IFileSystemImageResult
    {
    }
}