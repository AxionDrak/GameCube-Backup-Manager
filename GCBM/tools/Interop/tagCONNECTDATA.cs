using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct tagCONNECTDATA
    {
        [MarshalAs(UnmanagedType.IUnknown)] public object pUnk;
        public uint dwCookie;
    }
}