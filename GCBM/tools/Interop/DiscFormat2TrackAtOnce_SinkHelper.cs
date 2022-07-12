using System;
using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DiscFormat2TrackAtOnce_SinkHelper : DDiscFormat2TrackAtOnceEvents
    {
        // Fields

        public DiscFormat2TrackAtOnce_SinkHelper(DiscFormat2TrackAtOnce_EventHandler eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("Delegate (callback function) cannot be null");
            Cookie = 0;
            UpdateDelegate = eventHandler;
        }

        public int Cookie { get; set; }

        public DiscFormat2TrackAtOnce_EventHandler UpdateDelegate { get; set; }

        public void Update(object sender, object progress)
        {
            UpdateDelegate(sender, progress);
        }
    }
}