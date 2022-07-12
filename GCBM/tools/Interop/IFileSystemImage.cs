using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     File system image
    /// </summary>
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("2C941FE1-975B-59BE-A960-9A2A262853A5")]
    public interface IFileSystemImage
    {
        // Root directory item
        [DispId(0)] IFsiDirectoryItem Root { get; }

        // Disc start block for the image
        [DispId(1)] int SessionStartBlock { get; set; }

        // Maximum number of blocks available for the image
        [DispId(2)] int FreeMediaBlocks { get; set; }

        // Number of blocks in use
        [DispId(3)] int UsedBlocks { get; }

        // Volume name
        [DispId(4)] string VolumeName { get; set; }

        // Imported Volume name
        [DispId(5)] string ImportedVolumeName { get; }

        // Boot image and boot options
        [DispId(6)] IBootOptions BootImageOptions { get; set; }

        // Number of files in the image
        [DispId(7)] int FileCount { get; }

        // Number of directories in the image
        [DispId(8)] int DirectoryCount { get; }

        // Temp directory for stash files
        [DispId(9)] string WorkingDirectory { get; set; }

        // Change point identifier
        [DispId(10)] int ChangePoint { get; }

        // Strict file system compliance option
        [DispId(11)] bool StrictFileSystemCompliance { get; set; }

        // If true, indicates restricted character set is being used for file and directory names
        [DispId(12)] bool UseRestrictedCharacterSet { get; set; }

        // File systems to create
        [DispId(13)] FsiFileSystems FileSystemsToCreate { get; set; }

        // File systems supported
        [DispId(14)] FsiFileSystems FileSystemsSupported { get; }

        // UDF revision
        [DispId(0x25)] int UDFRevision { set; get; }

        // UDF revision(s) supported
        [DispId(0x1f)] object[] UDFRevisionsSupported { get; }

        // ISO compatibility level to create
        [DispId(0x22)] int ISO9660InterchangeLevel { set; get; }

        // ISO compatibility level(s) supported
        [DispId(0x26)] object[] ISO9660InterchangeLevelsSupported { get; }

        // Volume Name UDF
        [DispId(0x1b)] string VolumeNameUDF { get; }

        // Volume name Joliet
        [DispId(0x1c)] string VolumeNameJoliet { get; }

        // Volume name ISO 9660
        [DispId(0x1d)] string VolumeNameISO9660 { get; }

        // Indicates whether or not IMAPI should stage the filesystem before the burn
        [DispId(30)] bool StageFiles { get; set; }

        // Get array of available multi-session interfaces.
        [DispId(40)] object[] MultisessionInterfaces { get; set; }

        // Set maximum number of blocks available based on the recorder 
        // supported discs. 0 for unknown maximum may be set.
        [DispId(0x24)]
        void SetMaxMediaBlocksFromDevice(IDiscRecorder2 discRecorder);

        // Select filesystem types and image size based on the current media
        [DispId(0x20)]
        void ChooseImageDefaults(IDiscRecorder2 discRecorder);

        // Select filesystem types and image size based on the media type
        [DispId(0x21)]
        void ChooseImageDefaultsForMediaType(IMAPI_MEDIA_PHYSICAL_TYPE value);

        // Create result image stream
        [DispId(15)]
        IFileSystemImageResult CreateResultImage();

        // Check for existance an item in the file system
        [DispId(0x10)]
        FsiItemType Exists(string FullPath);

        // Return a string useful for identifying the current disc
        [DispId(0x12)]
        string CalculateDiscIdentifier();

        // Identify file systems on a given disc
        [DispId(0x13)]
        FsiFileSystems IdentifyFileSystemsOnDisc(IDiscRecorder2 discRecorder);

        // Identify which of the specified file systems would be imported by default
        [DispId(20)]
        FsiFileSystems GetDefaultFileSystemForImport(FsiFileSystems fileSystems);

        // Import the default file system on the current disc
        [DispId(0x15)]
        FsiFileSystems ImportFileSystem();

        // Import a specific file system on the current disc
        [DispId(0x16)]
        void ImportSpecificFileSystem(FsiFileSystems fileSystemToUse);

        // Roll back to the specified change point
        [DispId(0x17)]
        void RollbackToChangePoint(int ChangePoint);

        // Lock in changes
        [DispId(0x18)]
        void LockInChangePoint();

        // Create a directory item with the specified name
        [DispId(0x19)]
        IFsiDirectoryItem CreateDirectoryItem(string Name);

        // Create a file item with the specified name
        [DispId(0x1a)]
        IFsiFileItem CreateFileItem(string Name);
    }
}