using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [ComVisible(false)]
    [ComEventInterface(typeof(DFileSystemImageImportEvents), typeof(DFileSystemImageImport_EventProvider))]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public interface DFileSystemImageImport_Event
    {
        // Events
        event DFileSystemImageImport_EventHandler UpdateImport;
    }
}