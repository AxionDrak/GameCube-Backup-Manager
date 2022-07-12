using System.Collections;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     IDiscMaster2 is used to get an enumerator for the set of CD/DVD (optical) devices on the system
    /// </summary>
    [ComImport]
    [Guid("27354130-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IDiscMaster2
    {
        // Enumerates the list of CD/DVD devices on the system (VT_BSTR)
        [DispId(-4)]
        [TypeLibFunc(0x41)]
        IEnumerator GetEnumerator();

        // Gets a single recorder's ID (ZERO BASED INDEX)
        [DispId(0)] string this[int index] { get; }

        // The current number of recorders in the system.
        [DispId(1)] int Count { get; }

        // Whether IMAPI is running in an environment with optical devices and permission to access them.
        [DispId(2)] bool IsSupportedEnvironment { get; }
    }
}