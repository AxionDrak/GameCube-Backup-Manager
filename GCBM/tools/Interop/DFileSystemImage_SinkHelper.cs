using System;
using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ClassInterface(ClassInterfaceType.None)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public sealed class DFileSystemImage_SinkHelper : DFileSystemImageEvents
    {
        // Fields

        public DFileSystemImage_SinkHelper(DFileSystemImage_EventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            Cookie = 0;
            UpdateDelegate = eventHandler;
        }

        public int Cookie { get; set; }

        public DFileSystemImage_EventHandler UpdateDelegate { get; set; }

        public void Update(object sender, string currentFile, int copiedSectors, int totalSectors)
        {
            UpdateDelegate(sender, currentFile, copiedSectors, totalSectors);
        }
    }
}