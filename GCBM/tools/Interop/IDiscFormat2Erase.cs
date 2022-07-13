using System.Runtime.InteropServices;

namespace GCBM.tools.Interop
{
    [ComImport]
    [Guid("27354156-8F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IDiscFormat2Erase
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
        // IDiscFormat2Erase
        //

        // Sets the recorder object to use for an erase operation
        [DispId(0x100)] IDiscRecorder2 Recorder { set; get; }

        // 
        [DispId(0x101)] bool FullErase { set; get; }

        // Get the current physical media type
        [DispId(0x102)] IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { get; }

        // The friendly name of the client (used to determine recorder reservation conflicts)
        [DispId(0x103)] string ClientName { set; get; }

        // Erases the media in the active disc recorder
        [DispId(0x201)]
        void EraseMedia();
    }
}