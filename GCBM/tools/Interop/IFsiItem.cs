using System;
using System.Runtime.InteropServices;

namespace GCBM.tools.Interop;

/// <summary>
///     FileSystemImage item
/// </summary>
[Guid("2C941FD9-975B-59BE-A960-9A2A262853A5")]
[TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
public interface IFsiItem
{
    // Item name
    [DispId(11)] string Name { get; }

    // Full path
    [DispId(12)] string FullPath { get; }

    // Date and time of creation
    [DispId(13)] DateTime CreationTime { get; set; }

    // Date and time of last access
    [DispId(14)] DateTime LastAccessedTime { get; set; }

    // Date and time of last modification
    [DispId(15)] DateTime LastModifiedTime { get; set; }

    // Flag indicating if item is hidden
    [DispId(0x10)] bool IsHidden { get; set; }

    // Name of item in the specified file system
    [DispId(0x11)]
    string FileSystemName(FsiFileSystems fileSystem);

    // Name of item in the specified file system
    [DispId(0x12)]
    string FileSystemPath(FsiFileSystems fileSystem);
}