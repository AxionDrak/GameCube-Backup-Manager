using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DFileSystemImage_EventHandler([In][MarshalAs(UnmanagedType.IDispatch)] object sender,
        string currentFile, int copiedSectors, int totalSectors);
}