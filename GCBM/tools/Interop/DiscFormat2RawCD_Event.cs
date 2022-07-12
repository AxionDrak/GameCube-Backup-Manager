using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComEventInterface(typeof(DDiscFormat2RawCDEvents), typeof(DiscFormat2RawCD_EventProvider))]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ComVisible(false)]
    public interface DiscFormat2RawCD_Event
    {
        // Events
        event DiscFormat2RawCD_EventHandler Update;
    }
}