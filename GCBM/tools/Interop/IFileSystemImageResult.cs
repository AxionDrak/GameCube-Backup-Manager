using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace GCBM.tools.Interop;

/// <summary>
///     FileSystemImage result stream
/// </summary>
[TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
[Guid("2C941FD8-975B-59BE-A960-9A2A262853A5")]
public interface IFileSystemImageResult
{
    // Image stream
    [DispId(1)] IStream ImageStream { get; }

    // Progress item block mapping collection
    [DispId(2)] IProgressItems ProgressItems { get; }

    // Number of blocks in the result image
    [DispId(3)] int TotalBlocks { get; }

    // Number of bytes in a block
    [DispId(4)] int BlockSize { get; }

    // Disc Identifier (for identifing imported session of multi-session disc)
    [DispId(5)] string DiscId { get; }
}