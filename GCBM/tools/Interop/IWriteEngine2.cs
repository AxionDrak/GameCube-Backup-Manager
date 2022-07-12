using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace PluginBurnMedia.Interop
{
    /// <summary>
    ///     Write Engine
    /// </summary>
    [ComImport]
    [Guid("27354135-7F64-5B0F-8F00-5D77AFBE261E")]
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    public interface IWriteEngine2
    {
        // Writes data provided in the IStream to the device
        [DispId(0x200)]
        void WriteSection(IStream data, int startingBlockAddress, int numberOfBlocks);

        // Cancels the current write operation
        [DispId(0x201)]
        void CancelWrite();

        // The disc recorder to use
        [DispId(0x100)] IDiscRecorder2Ex Recorder { set; get; }

        // If true, uses WRITE12 with the AV bit set to one; else uses WRITE10
        [DispId(0x101)] bool UseStreamingWrite12 { set; get; }

        // The approximate number of sectors per second the device can write at
        // the start of the write process.  This is used to optimize sleep time
        // in the write engine.
        [DispId(0x102)] int StartingSectorsPerSecond { set; get; }

        // The approximate number of sectors per second the device can write at
        // the end of the write process.  This is used to optimize sleep time 
        // in the write engine.
        [DispId(0x103)] int EndingSectorsPerSecond { set; get; }

        // The number of bytes to use for each sector during writing.
        [DispId(260)] int BytesPerSector { set; get; }

        // Simple check to see if the object is currently writing to media.
        [DispId(0x105)] bool WriteInProgress { get; }
    }
}