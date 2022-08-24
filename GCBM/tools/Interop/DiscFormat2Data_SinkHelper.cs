using System;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [ClassInterface(ClassInterfaceType.None)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public sealed class DiscFormat2Data_SinkHelper : DDiscFormat2DataEvents
    {
        // Fields

        // Methods
        internal DiscFormat2Data_SinkHelper(DiscFormat2Data_EventHandler eventHandler)
        {
            Cookie = 0;
            UpdateDelegate = eventHandler ?? throw new ArgumentNullException("Delegate (callback function) cannot be null");
        }

        public int Cookie { get; set; }

        public DiscFormat2Data_EventHandler UpdateDelegate { get; set; }

        public void Update(object sender, object args)
        {
            UpdateDelegate(sender, args);
        }
    }
}