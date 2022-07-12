using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct tagCONNECTDATA
    {
        [MarshalAs(UnmanagedType.IUnknown)] public object pUnk;
        public uint dwCookie;
    }
}