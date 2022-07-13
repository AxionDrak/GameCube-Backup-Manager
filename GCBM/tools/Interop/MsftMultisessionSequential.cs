using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [ComImport]
    [Guid("27354151-7F64-5B0F-8F00-5D77AFBE261E")]
    [CoClass(typeof(MsftMultisessionSequentialClass))]
    public interface MsftMultisessionSequential : IMultisessionSequential
    {
    }
}