using System;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

[ClassInterface(ClassInterfaceType.None)]
[TypeLibType(TypeLibTypeFlags.FHidden)]
public sealed class DiscMaster2_SinkHelper : DDiscMaster2Events
{
    // Fields

    public DiscMaster2_SinkHelper(DiscMaster2_NotifyDeviceAddedEventHandler eventHandler)
    {
        Cookie = 0;
        NotifyDeviceAddedDelegate =
            eventHandler ?? throw new ArgumentNullException("Delegate (callback function) cannot be null");
    }

    public DiscMaster2_SinkHelper(DiscMaster2_NotifyDeviceRemovedEventHandler eventHandler)
    {
        Cookie = 0;
        NotifyDeviceRemovedDelegate =
            eventHandler ?? throw new ArgumentNullException("Delegate (callback function) cannot be null");
    }

    public int Cookie { get; set; }

    public DiscMaster2_NotifyDeviceAddedEventHandler NotifyDeviceAddedDelegate { get; set; }

    public DiscMaster2_NotifyDeviceRemovedEventHandler NotifyDeviceRemovedDelegate { get; set; }

    public void NotifyDeviceAdded(object sender, string uniqueId)
    {
        NotifyDeviceAddedDelegate(sender, uniqueId);
    }

    public void NotifyDeviceRemoved(object sender, string uniqueId)
    {
        NotifyDeviceRemovedDelegate(sender, uniqueId);
    }
}