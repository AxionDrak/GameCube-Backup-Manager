using System;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [ClassInterface(ClassInterfaceType.None)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public sealed class DiscFormat2RawCD_SinkHelper : DDiscFormat2RawCDEvents
    {
        // Fields

        public DiscFormat2RawCD_SinkHelper(DiscFormat2RawCD_EventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            Cookie = 0;
            UpdateDelegate = eventHandler;
        }

        public int Cookie { get; set; }

        public DiscFormat2RawCD_EventHandler UpdateDelegate { get; set; }

        public void Update(object sender, object progress)
        {
            UpdateDelegate(sender, progress);
        }
    }
}