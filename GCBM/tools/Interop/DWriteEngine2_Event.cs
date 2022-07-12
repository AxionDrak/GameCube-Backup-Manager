using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComVisible(false)]
    [ComEventInterface(typeof(DWriteEngine2Events), typeof(DWriteEngine2_EventProvider))]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public interface DWriteEngine2_Event
    {
        // Events
        event DWriteEngine2_EventHandler Update;
    }
}