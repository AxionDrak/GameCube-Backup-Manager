using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

/// <summary>
///     Provides notification of media erase progress.
/// </summary>
[ComImport]
[TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
[Guid("2735413A-7F64-5B0F-8F00-5D77AFBE261E")]
public interface DDiscFormat2EraseEvents
{
    // Update to current progress
    [DispId(0x200)] // DISPID_IDISCFORMAT2ERASEEVENTS_UPDATE 
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Update([In][MarshalAs(UnmanagedType.IDispatch)] object sender, [In] int elapsedSeconds,
        [In] int estimatedTotalSeconds);
}