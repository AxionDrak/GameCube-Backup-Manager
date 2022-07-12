using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    /// <summary>
    ///     Common Disc Format (writer) Operations
    /// </summary>
    [ComImport]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("27354152-8F64-5B0F-8F00-5D77AFBE261E")]
    public interface IDiscFormat2
    {
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
    }
}