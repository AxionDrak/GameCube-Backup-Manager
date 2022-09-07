using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

[ComImport]
[CoClass(typeof(MsftDiscRecorder2Class))]
[Guid("27354133-7F64-5B0F-8F00-5D77AFBE261E")]
public interface MsftDiscRecorder2 : IDiscRecorder2
{
}