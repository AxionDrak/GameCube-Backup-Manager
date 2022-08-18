using System;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DiscFormat2Erase_SinkHelper : DDiscFormat2EraseEvents
    {
        // Fields

        public DiscFormat2Erase_SinkHelper(DiscFormat2Erase_EventHandler eventHandler)
        {
            Cookie = 0;
            UpdateDelegate = eventHandler ?? throw new ArgumentNullException("Delegate (callback function) cannot be null");
        }

        public int Cookie { get; set; }

        public DiscFormat2Erase_EventHandler UpdateDelegate { get; set; }

        public void Update(object sender, int elapsedSeconds, int estimatedTotalSeconds)
        {
            UpdateDelegate(sender, elapsedSeconds, estimatedTotalSeconds);
        }
    }
}