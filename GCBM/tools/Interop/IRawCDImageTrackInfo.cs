using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComImport]
    [Guid("25983551-9D65-49CE-B335-40630D901227")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IRawCDImageTrackInfo
    {
        // The LBA of the first user sector in this track
        [DispId(0x100)] int StartingLba { get; }

        // The number of user sectors in this track
        [DispId(0x101)] int SectorCount { get; }

        // The track number assigned for this track
        [DispId(0x102)] int TrackNumber { get; }

        // The type of data being recorded on the current sector.
        [DispId(0x103)] IMAPI_CD_SECTOR_TYPE SectorType { get; }

        // The International Standard Recording Code (ISRC) for this track.
        [DispId(260)] string ISRC { get; set; }

        // The digital audio copy setting for this track
        [DispId(0x105)] IMAPI_CD_TRACK_DIGITAL_COPY_SETTING DigitalAudioCopySetting { get; set; }

        // The audio provided already has preemphasis applied (rare).
        [DispId(0x106)] bool AudioHasPreemphasis { get; set; }

        // The list of current track-relative indexes within the CD track.
        [DispId(0x107)] object[] TrackIndexes { get; }

        // Add the specified LBA (relative to the start of the track) as an index.
        [DispId(0x200)]
        void AddTrackIndex(int lbaOffset);

        // Removes the specified LBA (relative to the start of the track) as an index.
        [DispId(0x201)]
        void ClearTrackIndex(int lbaOffset);
    }
}