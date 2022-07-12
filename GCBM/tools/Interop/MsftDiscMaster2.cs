using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     Microsoft IMAPIv2 Disc Master
    /// </summary>
    [ComImport]
    [Guid("27354130-7F64-5B0F-8F00-5D77AFBE261E")]
    [CoClass(typeof(MsftDiscMaster2Class))]
    public interface MsftDiscMaster2 : IDiscMaster2 //, DiscMaster2_Event
    {
    }
}