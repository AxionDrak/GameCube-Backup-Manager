using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace GCBM.tools.Interop;

[TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
[ComImport]
[Guid("27354154-8F64-5B0F-8F00-5D77AFBE261E")]
public interface IDiscFormat2TrackAtOnce
{
    //
    // IDiscFormat2
    //

    // Determines if the recorder object supports the given format
    [DispId(0x800)]
    bool IsRecorderSupported(IDiscRecorder2 Recorder);

    // Determines if the current media in a supported recorder object supports the given format
    [DispId(0x801)]
    bool IsCurrentMediaSupported(IDiscRecorder2 Recorder);

    // Determines if the current media is reported as physically blank by the drive
    [DispId(0x700)] bool MediaPhysicallyBlank { get; }

    // Attempts to determine if the media is blank using heuristics (mainly for DVD+RW and DVD-RAM media)
    [DispId(0x701)] bool MediaHeuristicallyBlank { get; }

    // Supported media types
    [DispId(0x702)] object[] SupportedMediaTypes { get; }

    //
    // IDiscFormat2TrackAtOnce
    //

    // Locks the current media for use by this writer.
    [DispId(0x200)]
    void PrepareMedia();

    // Immediately writes a new audio track to the locked media
    [DispId(0x201)]
    void AddAudioTrack(IStream data);

    // Cancels the current addition of a track
    [DispId(0x202)]
    void CancelAddTrack();

    // Finishes use of the locked media
    [DispId(0x203)]
    void ReleaseMedia();

    // Sets the write speed (in sectors per second) of the attached disc recorder
    [DispId(0x204)]
    void SetWriteSpeed(int RequestedSectorsPerSecond, bool RotationTypeIsPureCAV);

    // The disc recorder to use
    [DispId(0x100)] IDiscRecorder2 Recorder { set; get; }

    // Buffer Underrun Free recording should be disabled
    [DispId(0x102)] bool BufferUnderrunFreeDisabled { set; get; }

    // Number of tracks already written to the locked media
    [DispId(0x103)] int NumberOfExistingTracks { get; }

    // Total sectors available on locked media if writing one continuous audio track
    [DispId(260)] int TotalSectorsOnMedia { get; }

    // Number of sectors available for adding a new track to the media
    [DispId(0x105)] int FreeSectorsOnMedia { get; }

    // Number of sectors used on the locked media, including overhead (space between tracks)
    [DispId(0x106)] int UsedSectorsOnMedia { get; }

    // Set the media to be left 'open' after writing, to allow multisession discs
    [DispId(0x107)] bool DoNotFinalizeMedia { set; get; }

    // Get the current physical media type
    [DispId(0x10a)] object[] ExpectedTableOfContents { get; }

    // Get the current physical media type
    [DispId(0x10b)] IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { get; }

    // The friendly name of the client (used to determine recorder reservation conflicts)
    [DispId(270)] string ClientName { set; get; }

    // The last requested write speed
    [DispId(0x10f)] int RequestedWriteSpeed { get; }

    // The last requested rotation type.
    [DispId(0x110)] bool RequestedRotationTypeIsPureCAV { get; }

    // The drive's current write speed.
    [DispId(0x111)] int CurrentWriteSpeed { get; }

    // The drive's current rotation type.
    [DispId(0x112)] bool CurrentRotationTypeIsPureCAV { get; }

    // Gets an array of the write speeds supported for the attached disc recorder and current media
    [DispId(0x113)] object[] SupportedWriteSpeeds { get; }

    // Gets an array of the detailed write configurations supported for the attached disc recorder and current media
    [DispId(0x114)] object[] SupportedWriteSpeedDescriptors { get; }
}