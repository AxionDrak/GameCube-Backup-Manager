using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace GCBM.tools.Interop;

[Guid("2C941FDC-975B-59BE-A960-9A2A262853A5")]
[TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
public interface IFsiDirectoryItem
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

    // Get the item with the given relative path
    [DispId(0)] IFsiItem this[string path] { get; }

    // Number of items in the collection
    [DispId(1)] int Count { get; }

    // Get a non-variant enumerator
    [DispId(2)] IEnumFsiItems EnumFsiItems { get; }

    // Name of item in the specified file system
    [DispId(0x11)]
    string FileSystemName(FsiFileSystems fileSystem);

    // Name of item in the specified file system
    [DispId(0x12)]
    string FileSystemPath(FsiFileSystems fileSystem);

    //
    // IFsiDirectoryItem
    //

    // Get an enumerator for the collection
    [TypeLibFunc(0x41)]
    [DispId(-4)]
    IEnumerator GetEnumerator();

    // Add a directory with the specified relative path
    [DispId(30)]
    void AddDirectory(string path);

    // Add a file with the specified relative path and data
    [DispId(0x1f)]
    void AddFile(string path, IStream fileData);

    // Add files and directories from the specified source directory
    [DispId(0x20)]
    void AddTree(string sourceDirectory, bool includeBaseDirectory);

    // Add an item
    [DispId(0x21)]
    void Add(IFsiItem Item);

    // Remove an item with the specified relative path
    [DispId(0x22)]
    void Remove(string path);

    // Remove a subtree with the specified relative path
    [DispId(0x23)]
    void RemoveTree(string path);
}