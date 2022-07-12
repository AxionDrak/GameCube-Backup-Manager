using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DiscFormat2RawCD_EventHandler([In] [MarshalAs(UnmanagedType.IDispatch)] object sender,
        [In] [MarshalAs(UnmanagedType.IDispatch)] object progress);
}