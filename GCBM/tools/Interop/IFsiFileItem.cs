using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     FileSystemImage file item
    /// </summary>
    [Guid("2C941FDB-975B-59BE-A960-9A2A262853A5")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IFsiFileItem
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

        // Name of item in the specified file system
        [DispId(0x11)]
        string FileSystemName(FsiFileSystems fileSystem);

        // Name of item in the specified file system
        [DispId(0x12)]
        string FileSystemPath(FsiFileSystems fileSystem);
    }
}