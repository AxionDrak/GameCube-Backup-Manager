using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     CD Disc-At-Once RAW Writer Events
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    [Guid("27354142-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface DDiscFormat2RawCDEvents
    {
        // Update to current progress
        [DispId(0x200)] // DISPID_DDISCFORMAT2RAWCDEVENTS_UPDATE 
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Update([In][MarshalAs(UnmanagedType.IDispatch)] object sender,
            [In] [MarshalAs(UnmanagedType.IDispatch)]
            object progress);
    }
}