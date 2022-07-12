using System;
using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ClassInterface(ClassInterfaceType.None)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public sealed class DiscMaster2_SinkHelper : DDiscMaster2Events
    {
        // Fields

        public DiscMaster2_SinkHelper(DiscMaster2_NotifyDeviceAddedEventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            Cookie = 0;
            NotifyDeviceAddedDelegate = eventHandler;
        }

        public DiscMaster2_SinkHelper(DiscMaster2_NotifyDeviceRemovedEventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            Cookie = 0;
            NotifyDeviceRemovedDelegate = eventHandler;
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
}