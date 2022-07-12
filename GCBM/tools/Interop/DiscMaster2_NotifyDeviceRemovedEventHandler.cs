using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DiscMaster2_NotifyDeviceRemovedEventHandler(
        [In] [MarshalAs(UnmanagedType.IDispatch)] object sender, string uniqueId);
}