using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComVisible(false)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ComEventInterface(typeof(DDiscFormat2TrackAtOnceEvents), typeof(DiscFormat2TrackAtOnce_EventProvider))]
    public interface DiscFormat2TrackAtOnce_Event
    {
        // Events
        event DiscFormat2TrackAtOnce_EventHandler Update;
    }
}