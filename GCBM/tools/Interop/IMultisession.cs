using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    [ComImport]
    [Guid("27354150-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IMultisession
    {
        // Is it possible to write this multi-session type on the current media in its present state
        [DispId(0x100)] bool IsSupportedOnCurrentMediaState { get; }

        // Is this multi-session type the one to use on current media
        [DispId(0x101)] bool InUse { set; get; }

        // The disc recorder to use to import previous session(s)
        [DispId(0x102)] MsftDiscRecorder2 ImportRecorder { get; }
    }
}