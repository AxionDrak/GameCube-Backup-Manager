using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DiscMaster2_NotifyDeviceRemovedEventHandler(
        [In] [MarshalAs(UnmanagedType.IDispatch)]
        object sender, string uniqueId);
}