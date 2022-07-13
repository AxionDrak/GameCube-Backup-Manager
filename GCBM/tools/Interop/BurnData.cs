namespace GCBM.tools.Interop
{
    public class BurnData
    {
        // IWriteEngine2EventArgs Interface
        public IMAPI_FORMAT2_DATA_WRITE_ACTION currentAction;

        // IDiscFormat2DataEventArgs Interface
        public long elapsedTime; // Elapsed time in seconds
        public long freeSystemBuffer; // size of the free system buffer
        public long lastReadLba; // the last read lba address
        public long lastWrittenLba; // the last written lba address
        public long remainingTime; // Remaining time in seconds
        public long sectorCount; // the total sectors to write in the current operation
        public long startLba; // the starting lba of the current operation
        public string statusMessage;
        public BURN_MEDIA_TASK task;
        public long totalSystemBuffer; // total size of the system buffer
        public long totalTime; // total estimated time in seconds
        public string uniqueRecorderId;
        public long usedSystemBuffer; // size of used system buffer
    }
}