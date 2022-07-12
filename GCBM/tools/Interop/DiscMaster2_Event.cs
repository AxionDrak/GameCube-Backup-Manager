using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [ComVisible(false)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ComEventInterface(typeof(DDiscMaster2Events), typeof(DiscMaster2_EventProvider))]
    public interface DiscMaster2_Event
    {
        // Events
        event DiscMaster2_NotifyDeviceAddedEventHandler NotifyDeviceAdded;
        event DiscMaster2_NotifyDeviceRemovedEventHandler NotifyDeviceRemoved;
    }
}