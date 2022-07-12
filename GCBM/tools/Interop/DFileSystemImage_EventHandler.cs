using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DFileSystemImage_EventHandler([In] [MarshalAs(UnmanagedType.IDispatch)] object sender,
        string currentFile, int copiedSectors, int totalSectors);
}