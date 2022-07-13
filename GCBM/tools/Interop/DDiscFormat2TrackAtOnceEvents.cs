using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     CD Track-at-Once Audio Writer Events
    /// </summary>
    [ComImport]
    [Guid("2735413F-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    public interface DDiscFormat2TrackAtOnceEvents
    {
        // Update to current progress
        [DispId(0x200)] // DISPID_DDISCFORMAT2TAOEVENTS_UPDATE
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Update([In] [MarshalAs(UnmanagedType.IDispatch)] object sender,
            [In] [MarshalAs(UnmanagedType.IDispatch)]
            object progress);
    }
}