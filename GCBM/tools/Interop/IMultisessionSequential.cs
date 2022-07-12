using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComImport]
    [Guid("27354151-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IMultisessionSequential
    {
        //
        // IMultisession
        //
        // Is it possible to write this multi-session type on the current media in its present state
        [DispId(0x100)] bool IsSupportedOnCurrentMediaState { get; }

        // Is this multi-session type the one to use on current media
        [DispId(0x101)] bool InUse { set; get; }

        // The disc recorder to use to import previous session(s)
        [DispId(0x102)] MsftDiscRecorder2 ImportRecorder { get; }

        //
        // IMultisessionSequential
        //

        // Is this the first data session on the media?
        [DispId(0x200)] bool IsFirstDataSession { get; }

        // The first sector in the previous session on the media.
        [DispId(0x201)] int StartAddressOfPreviousSession { get; }

        // The last sector in the previous session on the media
        [DispId(0x202)] int LastWrittenAddressOfPreviousSession { get; }

        // Next writable address on the media (also used sectors).
        [DispId(0x203)] int NextWritableAddress { get; }

        // Free sectors available on the media
        [DispId(0x204)] int FreeSectorsOnMedia { get; }
    }
}