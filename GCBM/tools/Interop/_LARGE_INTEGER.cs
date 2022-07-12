using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct _LARGE_INTEGER
    {
        public long QuadPart;
    }
}