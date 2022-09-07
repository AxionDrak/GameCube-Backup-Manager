using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

[ComImport]
[Guid("27354135-7F64-5B0F-8F00-5D77AFBE261E")]
[CoClass(typeof(MsftWriteEngine2Class))]
public interface MsftWriteEngine2 : IWriteEngine2, DWriteEngine2_Event
{
}