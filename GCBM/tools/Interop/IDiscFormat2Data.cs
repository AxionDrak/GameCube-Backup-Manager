using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace GCBM.tools.Interop;

/// <summary>
///     Data Writer
/// </summary>
[TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
[Guid("27354153-9F64-5B0F-8F00-5D77AFBE261E")]
public interface IDiscFormat2Data
{
    // Determines if the current media is reported as physically blank by the drive
    [DispId(0x700)] bool MediaPhysicallyBlank { get; }

    // Attempts to determine if the media is blank using heuristics (mainly for DVD+RW and DVD-RAM media)
    [DispId(0x701)] bool MediaHeuristicallyBlank { get; }

    // Supported media types
    [DispId(0x702)] object[] SupportedMediaTypes { get; }

    //
    // IDiscFormat2Data
    //

    // The disc recorder to use
    [DispId(0x100)] IDiscRecorder2 Recorder { set; get; }

    // Buffer Underrun Free recording should be disabled
    [DispId(0x101)] bool BufferUnderrunFreeDisabled { set; get; }

    // Postgap is included in image
    [DispId(260)] bool PostgapAlreadyInImage { set; get; }

    // The state (usability) of the current media
    [DispId(0x106)] IMAPI_FORMAT2_DATA_MEDIA_STATE CurrentMediaStatus { get; }

    // The write protection state of the current media
    [DispId(0x107)] IMAPI_MEDIA_WRITE_PROTECT_STATE WriteProtectStatus { get; }

    // Total sectors available on the media (used + free).
    [DispId(0x108)] int TotalSectorsOnMedia { get; }

    // Free sectors available on the media.
    [DispId(0x109)] int FreeSectorsOnMedia { get; }

    // Next writable address on the media (also used sectors)
    [DispId(0x10a)] int NextWritableAddress { get; }

    // The first sector in the previous session on the media
    [DispId(0x10b)] int StartAddressOfPreviousSession { get; }

    // The last sector in the previous session on the media
    [DispId(0x10c)] int LastWrittenAddressOfPreviousSession { get; }

    // Prevent further additions to the file system
    [DispId(0x10d)] bool ForceMediaToBeClosed { set; get; }

    // Default is to maximize compatibility with DVD-ROM.  May be disabled to 
    // reduce time to finish writing the disc or increase usable space on the 
    // media for later writing.
    [DispId(270)] bool DisableConsumerDvdCompatibilityMode { set; get; }

    // Get the current physical media type
    [DispId(0x10f)] IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { get; }

    // The friendly name of the client (used to determine recorder reservation conflicts)
    [DispId(0x110)] string ClientName { set; get; }

    // The last requested write speed
    [DispId(0x111)] int RequestedWriteSpeed { get; }

    // The last requested rotation type
    [DispId(0x112)] bool RequestedRotationTypeIsPureCAV { get; }

    // The drive's current write speed
    [DispId(0x113)] int CurrentWriteSpeed { get; }

    // The drive's current rotation type.
    [DispId(0x114)] bool CurrentRotationTypeIsPureCAV { get; }

    // Gets an array of the write speeds supported for the attached disc recorder and current media
    [DispId(0x115)] object[] SupportedWriteSpeeds { get; }

    // Gets an array of the detailed write configurations supported for the attached disc recorder 
    // and current media
    [DispId(0x116)] object[] SupportedWriteSpeedDescriptors { get; }

    // Forces the Datawriter to overwrite the disc on overwritable media types
    [DispId(0x117)] bool ForceOverwrite { set; get; }

    // Returns the array of available multi-session interfaces. The array shall not be empty
    [DispId(280)] object[] MultisessionInterfaces { get; }
    //
    // IDiscFormat2
    //

    // Determines if the recorder object supports the given format
    [DispId(0x800)]
    bool IsRecorderSupported(IDiscRecorder2 Recorder);

    // Determines if the current media in a supported recorder object supports the given format
    [DispId(0x801)]
    bool IsCurrentMediaSupported(IDiscRecorder2 Recorder);

    // Writes all the data provided in the IStream to the device
    [DispId(0x200)]
    void Write(IStream data);

    // Cancels the current write operation
    [DispId(0x201)]
    void CancelWrite();

    // Sets the write speed (in sectors per second) of the attached disc recorder
    [DispId(0x202)]
    void SetWriteSpeed(int RequestedSectorsPerSecond, bool RotationTypeIsPureCAV);
}