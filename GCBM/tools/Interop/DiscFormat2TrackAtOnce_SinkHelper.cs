using System;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DiscFormat2TrackAtOnce_SinkHelper : DDiscFormat2TrackAtOnceEvents
    {
        // Fields

        public DiscFormat2TrackAtOnce_SinkHelper(DiscFormat2TrackAtOnce_EventHandler eventHandler)
        {
            Cookie = 0;
            UpdateDelegate = eventHandler ?? throw new ArgumentNullException("Delegate (callback function) cannot be null");
        }

        public int Cookie { get; set; }

        public DiscFormat2TrackAtOnce_EventHandler UpdateDelegate { get; set; }

        public void Update(object sender, object progress)
        {
            UpdateDelegate(sender, progress);
        }
    }
}