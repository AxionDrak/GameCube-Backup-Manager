using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

[ComImport]
[CoClass(typeof(MsftDiscFormat2DataClass))]
[Guid("27354153-9F64-5B0F-8F00-5D77AFBE261E")]
public interface MsftDiscFormat2Data : IDiscFormat2Data, DiscFormat2Data_Event
{
}