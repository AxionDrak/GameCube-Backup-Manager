using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct _LARGE_INTEGER
    {
        public long QuadPart;
    }
}