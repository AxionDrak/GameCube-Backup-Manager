using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace GCBM.tools.Interop
{
    [ComImport]
    [Guid("0000000C-0000-0000-C000-000000000046")]
    [CoClass(typeof(FsiStreamClass))]
    public interface FsiStream : IStream
    {
    }
}