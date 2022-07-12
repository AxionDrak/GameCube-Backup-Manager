using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DWriteEngine2_EventHandler([In] [MarshalAs(UnmanagedType.IDispatch)] object sender,
        [In] [MarshalAs(UnmanagedType.IDispatch)] object progress);
}