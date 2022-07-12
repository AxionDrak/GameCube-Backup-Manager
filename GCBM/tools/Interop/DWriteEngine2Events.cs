using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    /// <summary>
    ///     Provides notification of the progress of the WriteEngine2 writing.
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    [Guid("27354137-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface DWriteEngine2Events
    {
        // Update to current progress
        [DispId(0x100)] // DISPID_DWRITEENGINE2EVENTS_UPDATE 
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Update([In] [MarshalAs(UnmanagedType.IDispatch)] object sender,
            [In] [MarshalAs(UnmanagedType.IDispatch)] object progress);
    }
}