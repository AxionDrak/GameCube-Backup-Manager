using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComImport]
    [CoClass(typeof(FsiFileItemClass))]
    [Guid("199D0C19-11E1-40EB-8EC2-C8C822A07792")]
    public interface FsiFileItem : IFsiFileItem2
    {
    }
}