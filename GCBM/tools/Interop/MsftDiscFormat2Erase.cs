using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComImport]
    [Guid("27354156-8F64-5B0F-8F00-5D77AFBE261E")]
    [CoClass(typeof(MsftDiscFormat2EraseClass))]
    public interface MsftDiscFormat2Erase : IDiscFormat2Erase, DiscFormat2Erase_Event
    {
    }
}