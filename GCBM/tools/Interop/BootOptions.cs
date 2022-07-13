using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [ComImport]
    [CoClass(typeof(BootOptionsClass))]
    [Guid("2C941FD4-975B-59BE-A960-9A2A262853A5")]
    public interface BootOptions : IBootOptions
    {
    }
}