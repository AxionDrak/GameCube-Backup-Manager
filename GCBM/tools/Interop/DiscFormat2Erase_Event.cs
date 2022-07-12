using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ComVisible(false)]
    [ComEventInterface(typeof(DDiscFormat2EraseEvents), typeof(DiscFormat2Erase_EventProvider))]
    public interface DiscFormat2Erase_Event
    {
        // Events
        event DiscFormat2Erase_EventHandler Update;
    }
}