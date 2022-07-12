using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     FileSystemImage item enumerator
    /// </summary>
    [Guid("2C941FDA-975B-59BE-A960-9A2A262853A5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumFsiItems
    {
        // Note: not listed in COM Interface, but it is in Interop.cs
        void Next(uint celt, out IFsiItem rgelt, out uint pceltFetched);

        // Remoting support for Next (allow NULL pointer for item count when requesting single item)
        void RemoteNext(uint celt, out IFsiItem rgelt, out uint pceltFetched);

        // Skip items in the enumeration
        void Skip(uint celt);

        // Reset the enumerator
        void Reset();

        // Make a copy of the enumerator
        void Clone(out IEnumFsiItems ppEnum);
    }
}