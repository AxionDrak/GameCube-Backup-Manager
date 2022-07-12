using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComVisible(false)]
    [ComEventInterface(typeof(DFileSystemImageEvents), typeof(DFileSystemImage_EventProvider))]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public interface DFileSystemImage_Event
    {
        // Events
        event DFileSystemImage_EventHandler Update;
    }
}