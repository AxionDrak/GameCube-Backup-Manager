using System;

namespace GCBM
{
    public class Hardworker
    {
        public event EventHandler<HardWorkerEventArgs> ProgressChanged;
        public event EventHandler HardWorkDone;

        public void DoHardWork()
        {
            for (var i = 1; i <= 100; i++)
            {
                for (var j = 1; j <= 500000; j++) Math.Pow(i, j);
                OnProgressChanged(i);
            }

            OnHardWorkDone();
        }

        private void OnProgressChanged(int progress)
        {
            var handler = ProgressChanged;
            if (handler != null) handler(this, new HardWorkerEventArgs(progress));
        }

        private void OnHardWorkDone()
        {
            var handler = HardWorkDone;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}