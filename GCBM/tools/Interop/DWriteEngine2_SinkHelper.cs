using System;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DWriteEngine2_SinkHelper : DWriteEngine2Events
    {
        // Fields

        public DWriteEngine2_SinkHelper(DWriteEngine2_EventHandler eventHandler)
        {
            Cookie = 0;
            UpdateDelegate = eventHandler ?? throw new ArgumentNullException("Delegate (callback function) cannot be null");
        }

        public int Cookie { get; set; }

        public DWriteEngine2_EventHandler UpdateDelegate { get; set; }

        public void Update(object sender, object progress)
        {
            UpdateDelegate(sender, progress);
        }
    }
}