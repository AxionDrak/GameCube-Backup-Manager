using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     FileSystemImage directory item (rev.2)
    /// </summary>
    [ComImport]
    [Guid("F7FB4B9B-6D96-4D7B-9115-201B144811EF")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IFsiDirectoryItem2 : IFsiDirectoryItem
    {
        // Add files and directories from the specified source directory including named streams
        [DispId(0x24)]
        void AddTreeWithNamedStreams(string sourceDirectory, bool includeBaseDirectory);
    }
}