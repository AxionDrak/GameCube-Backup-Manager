using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

/// <summary>
///     FileSystemImageResult progress item
/// </summary>
[TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
[Guid("2C941FD5-975B-59BE-A960-9A2A262853A5")]
public interface IProgressItem
{
    // Progress item description
    [DispId(1)] string Description { get; }

    // First block in the range of blocks used by the progress item
    [DispId(2)] uint FirstBlock { get; }

    // Last block in the range of blocks used by the progress item
    [DispId(3)] uint LastBlock { get; }

    // Number of blocks used by the progress item
    [DispId(4)] uint BlockCount { get; }
}