using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     Provides notification of file system import progress
    /// </summary>
    [ComImport]
    [Guid("2C941FDF-975B-59BE-A960-9A2A262853A5")]
    [TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
    public interface DFileSystemImageEvents
    {
        // Update to current progress
        [DispId(0x100)] // DISPID_DFILESYSTEMIMAGEEVENTS_UPDATE 
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Update([In] [MarshalAs(UnmanagedType.IDispatch)] object sender, string currentFile, [In] int copiedSectors,
            [In] int totalSectors);
    }
}