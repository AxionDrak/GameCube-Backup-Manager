using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

[ComImport]
[Guid("ED79BA56-5294-4250-8D46-F9AECEE23459")]
[CoClass(typeof(FsiNamedStreamsClass))]
public interface FsiNamedStreams : IFsiNamedStreams
{
}