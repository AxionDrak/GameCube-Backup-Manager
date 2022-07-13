using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [ComImport]
    [CoClass(typeof(MsftDiscFormat2RawCDClass))]
    [Guid("27354155-8F64-5B0F-8F00-5D77AFBE261E")]
    public interface MsftDiscFormat2RawCD : IDiscFormat2RawCD, DiscFormat2RawCD_Event
    {
    }
}