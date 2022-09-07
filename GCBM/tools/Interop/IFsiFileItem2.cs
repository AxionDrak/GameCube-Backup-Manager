using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace GCBM.tools.Interop;

/// <summary>
///     FileSystemImage file item (rev.2)
/// </summary>
[ComImport]
[Guid("199D0C19-11E1-40EB-8EC2-C8C822A07792")]
[TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
public interface IFsiFileItem2
{
    //
    // IFsiItem
    //

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

    //
    // IFsiFileItem
    //

    // Data byte count
    [DispId(0x29)] long DataSize { get; }

    // Lower 32 bits of the data byte count
    [DispId(0x2a)] int DataSize32BitLow { get; }

    // Upper 32 bits of the data byte count
    [DispId(0x2b)] int DataSize32BitHigh { get; }

    // Data stream
    [DispId(0x2c)] IStream Data { get; set; }

    //
    // IFsiFileItem2
    //

    // Get the list of the named streams of the file
    [DispId(0x2d)] FsiNamedStreams FsiNamedStreams { get; }

    // Flag indicating if file item is a named stream of a file
    [DispId(0x2e)] bool IsNamedStream { get; }

    // Add a new named stream to the collection
    [DispId(0x2f)]
    void AddStream(string Name, FsiStream streamData);

    // Remove a specific named stream from the collection
    [DispId(0x30)]
    void RemoveStream(string Name);

    // Flag indicating if file is Real-Time
    [DispId(0x31)] bool IsRealTime { get; set; }
}