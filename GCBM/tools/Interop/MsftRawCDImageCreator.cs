using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [ComImport]
    [Guid("25983550-9D65-49CE-B335-40630D901227")]
    [CoClass(typeof(MsftRawCDImageCreatorClass))]
    public interface MsftRawCDImageCreator : IRawCDImageCreator
    {
    }
}