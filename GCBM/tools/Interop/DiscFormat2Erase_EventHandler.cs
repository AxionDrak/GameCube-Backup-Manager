using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DiscFormat2Erase_EventHandler([In] [MarshalAs(UnmanagedType.IDispatch)] object sender,
        [In] int elapsedSeconds, [In] int estimatedTotalSeconds);
}