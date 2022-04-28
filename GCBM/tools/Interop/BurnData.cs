using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBurnMedia.Interop
{
    public enum BURN_MEDIA_TASK
    {
        BURN_MEDIA_TASK_FILE_SYSTEM,
        BURN_MEDIA_TASK_WRITING
    }

    public class BurnData
    {
        public string uniqueRecorderId;
        public string statusMessage;
        public BURN_MEDIA_TASK task;

        // IDiscFormat2DataEventArgs Interface
        public long elapsedTime;		// Elapsed time in seconds
        public long remainingTime;		// Remaining time in seconds
        public long totalTime;			// total estimated time in seconds
        // IWriteEngine2EventArgs Interface
        public IMAPI_FORMAT2_DATA_WRITE_ACTION currentAction;
        public long startLba;			// the starting lba of the current operation
        public long sectorCount;		// the total sectors to write in the current operation
        public long lastReadLba;		// the last read lba address
        public long lastWrittenLba;	// the last written lba address
        public long totalSystemBuffer;	// total size of the system buffer
        public long usedSystemBuffer;	// size of used system buffer
        public long freeSystemBuffer;	// size of the free system buffer
    }

}
