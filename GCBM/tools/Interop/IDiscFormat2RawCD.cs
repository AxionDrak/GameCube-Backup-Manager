using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace GCBM.tools.Interop
{
    /// <summary>
    ///     CD Disc-At-Once RAW Writer
    /// </summary>
    [ComImport]
    [Guid("27354155-8F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IDiscFormat2RawCD
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
        // IDiscFormat2RawCD
        //

        // Locks the current media for use by this writer
        [DispId(0x200)]
        void PrepareMedia();

        // Writes a RAW image that starts at 95:00:00 (MSF) to the currently inserted blank CD media
        [DispId(0x201)]
        void WriteMedia(IStream data);

        // Writes a RAW image to the currently inserted blank CD media.  A stream starting at 95:00:00
        // (-5 minutes) would use 5*60*75 + 150 sectors pregap == 22,650 for the number of sectors
        [DispId(0x202)]
        void WriteMedia2(IStream data, int streamLeadInSectors);

        // Cancels the current write.
        [DispId(0x203)]
        void CancelWrite();

        // Finishes use of the locked media.
        [DispId(0x204)]
        void ReleaseMedia();

        // Sets the write speed (in sectors per second) of the attached disc recorder
        [DispId(0x205)]
        void SetWriteSpeed(int RequestedSectorsPerSecond, bool RotationTypeIsPureCAV);

        // The disc recorder to use
        [DispId(0x100)] IDiscRecorder2 Recorder { set; get; }

        // Buffer Underrun Free recording should be disabled
        [DispId(0x102)] bool BufferUnderrunFreeDisabled { set; get; }

        // The first sector of the next session.  May be negative for blank media
        [DispId(0x103)] int StartOfNextSession { get; }

        // The last possible start for the leadout area.  Can be used to 
        // calculate available space on media
        [DispId(260)] int LastPossibleStartOfLeadout { get; }

        // Get the current physical media type
        [DispId(0x105)] IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { get; }

        // Supported data sector types for the current recorder
        [DispId(0x108)] object[] SupportedSectorTypes { get; }

        // Requested data sector to use during write of the stream
        [DispId(0x109)] IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE RequestedSectorType { set; get; }

        // The friendly name of the client (used to determine recorder reservation conflicts).
        [DispId(0x10a)] string ClientName { set; get; }

        // The last requested write speed
        [DispId(0x10b)] int RequestedWriteSpeed { get; }

        // The last requested rotation type.
        [DispId(0x10c)] bool RequestedRotationTypeIsPureCAV { get; }

        // The drive's current write speed.
        [DispId(0x10d)] int CurrentWriteSpeed { get; }

        // The drive's current rotation type
        [DispId(270)] bool CurrentRotationTypeIsPureCAV { get; }

        // Gets an array of the write speeds supported for the attached disc 
        // recorder and current media
        [DispId(0x10f)] object[] SupportedWriteSpeeds { get; }

        // Gets an array of the detailed write configurations supported for the 
        // attached disc recorder and current media
        [DispId(0x110)] object[] SupportedWriteSpeedDescriptors { get; }
    }
}