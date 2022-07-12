using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace GCBM.tools.Interop
{
    [ComImport]
    [Guid("25983550-9D65-49CE-B335-40630D901227")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IRawCDImageCreator
    {
        // Creates the result stream
        [DispId(0x200)]
        IStream CreateResultImage();

        // Adds a track to the media (defaults to audio, always 2352 bytes/sector)
        [DispId(0x201)]
        int AddTrack(IMAPI_CD_SECTOR_TYPE dataType, [In] [MarshalAs(UnmanagedType.Interface)] IStream data);

        // Adds a special pregap to the first track, and implies an audio CD
        [DispId(0x202)]
        void AddSpecialPregap([In] [MarshalAs(UnmanagedType.Interface)] IStream data);

        // Adds an R-W subcode generation object to supply R-W subcode (i.e. CD-Text or CD-G).
        [DispId(0x203)]
        void AddSubcodeRWGenerator([In] [MarshalAs(UnmanagedType.Interface)] IStream subcode);

        [DispId(0x100)] IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE ResultingImageType { set; get; }

        // Equal to (final user LBA+1), defines minimum disc size image can be written to.
        [DispId(0x101)] int StartOfLeadout { get; }

        // 
        [DispId(0x102)] int StartOfLeadoutLimit { set; get; }

        // Disables gapless recording of consecutive audio tracks
        [DispId(0x103)] bool DisableGaplessAudio { set; get; }

        // The Media Catalog Number for the CD image
        [DispId(260)] string MediaCatalogNumber { set; get; }

        // The starting track number (only for pure audio CDs)
        [DispId(0x105)] int StartingTrackNumber { set; get; }

        [DispId(0x106)] IRawCDImageTrackInfo this[int trackIndex] { [DispId(0x106)] get; }

        [DispId(0x107)] int NumberOfExistingTracks { get; }

        [DispId(0x108)] int LastUsedUserSectorInImage { get; }

        [DispId(0x109)] object[] ExpectedTableOfContents { get; }
    }
}