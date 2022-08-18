using System;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [ClassInterface(ClassInterfaceType.None)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public sealed class DFileSystemImage_SinkHelper : DFileSystemImageEvents
    {
        // Fields

        public DFileSystemImage_SinkHelper(DFileSystemImage_EventHandler eventHandler)
        {
            Cookie = 0;
            UpdateDelegate = eventHandler ?? throw new ArgumentNullException("Delegate (callback function) cannot be null");
        }

        public int Cookie { get; set; }

        public DFileSystemImage_EventHandler UpdateDelegate { get; set; }

        public void Update(object sender, string currentFile, int copiedSectors, int totalSectors)
        {
            UpdateDelegate(sender, currentFile, copiedSectors, totalSectors);
        }
    }
}