using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComImport]
    [Guid("D25C30F9-4087-4366-9E24-E55BE286424B")]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    public interface DFileSystemImageImportEvents
    {
        [DispId(0x101)] // DISPID_DFILESYSTEMIMAGEIMPORTEVENTS_UPDATEIMPORT 
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UpdateImport([In] [MarshalAs(UnmanagedType.IDispatch)] object sender, FsiFileSystems fileSystem,
            string currentItem, int importedDirectoryItems, int totalDirectoryItems, int importedFileItems,
            int totalFileItems);
    }
}