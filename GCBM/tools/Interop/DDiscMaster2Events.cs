using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     Provides notification of the arrival/removal of CD/DVD (optical) devices.
    /// </summary>
    [ComImport]
    [Guid("27354131-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    public interface DDiscMaster2Events
    {
        // A device was added to the system
        [DispId(0x100)] // DISPID_DDISCMASTER2EVENTS_DEVICEADDED
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NotifyDeviceAdded([In][MarshalAs(UnmanagedType.IDispatch)] object sender, string uniqueId);

        // A device was removed from the system
        [DispId(0x101)] // DISPID_DDISCMASTER2EVENTS_DEVICEREMOVED
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NotifyDeviceRemoved([In][MarshalAs(UnmanagedType.IDispatch)] object sender, string uniqueId);
    }
}