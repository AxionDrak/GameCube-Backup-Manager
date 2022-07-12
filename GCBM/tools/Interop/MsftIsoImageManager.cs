using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComImport]
    [Guid("6CA38BE5-FBBB-4800-95A1-A438865EB0D4")]
    [CoClass(typeof(MsftIsoImageManagerClass))]
    public interface MsftIsoImageManager : IIsoImageManager
    {
    }
}