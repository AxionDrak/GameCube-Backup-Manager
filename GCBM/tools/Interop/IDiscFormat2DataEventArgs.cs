using System.Runtime.InteropServices;

namespace PluginBurnMedia.Interop
{
    /// <summary>
    ///     Track-at-once Data Writer
    /// </summary>
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FNonExtensible)]
    [Guid("2735413D-7F64-5B0F-8F00-5D77AFBE261E")]
    public interface IDiscFormat2DataEventArgs
    {
        //
        // IWriteEngine2EventArgs
        //

        // The starting logical block address for the current write operation.
        [DispId(0x100)] int StartLba { get; }

        // The number of sectors being written for the current write operation.
        [DispId(0x101)] int SectorCount { get; }

        // The last logical block address of data read for the current write operation.
        [DispId(0x102)] int LastReadLba { get; }

        // The last logical block address of data written for the current write operation
        [DispId(0x103)] int LastWrittenLba { get; }

        // The total bytes available in the system's cache buffer
        [DispId(0x106)] int TotalSystemBuffer { get; }

        // The used bytes in the system's cache buffer
        [DispId(0x107)] int UsedSystemBuffer { get; }

        // The free bytes in the system's cache buffer
        [DispId(0x108)] int FreeSystemBuffer { get; }

        //
        // IDiscFormat2DataEventArgs
        //

        // The total elapsed time for the current write operation
        [DispId(0x300)] int ElapsedTime { get; }

        // The estimated time remaining for the write operation.
        [DispId(0x301)] int RemainingTime { get; }

        // The estimated total time for the write operation.
        [DispId(770)] int TotalTime { get; }

        // The current write action.
        [DispId(0x303)] IMAPI_FORMAT2_DATA_WRITE_ACTION CurrentAction { get; }
    }
}