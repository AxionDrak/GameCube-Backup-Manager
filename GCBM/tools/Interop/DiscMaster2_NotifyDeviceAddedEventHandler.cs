using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DiscMaster2_NotifyDeviceAddedEventHandler(
        [In] [MarshalAs(UnmanagedType.IDispatch)] object sender, string uniqueId);
}