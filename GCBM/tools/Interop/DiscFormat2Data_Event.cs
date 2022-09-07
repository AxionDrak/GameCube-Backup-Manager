using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

[ComVisible(false)]
[ComEventInterface(typeof(DDiscFormat2DataEvents), typeof(DiscFormat2Data_EventProvider))]
[TypeLibType(TypeLibTypeFlags.FHidden)]
public interface DiscFormat2Data_Event
{
    // Events
    event DiscFormat2Data_EventHandler Update;
}