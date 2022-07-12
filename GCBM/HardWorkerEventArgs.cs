using System;

namespace GCBM
{
    public class HardWorkerEventArgs : EventArgs
    {
        public HardWorkerEventArgs(int progress)
        {
            Progress = progress;
        }

        public int Progress { get; }
    }
}