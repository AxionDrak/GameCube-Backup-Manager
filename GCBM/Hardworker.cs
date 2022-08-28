using System;

namespace GCBM
{
    public class Hardworker
    {
        public event EventHandler<HardWorkerEventArgs> ProgressChanged;
        public event EventHandler HardWorkDone;

        public void DoHardWork()
        {
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 500000; j++)
                {
                    _ = Math.Pow(i, j);
                }

                OnProgressChanged(i);
            }

            OnHardWorkDone();
        }

        private void OnProgressChanged(int progress)
        {
            ProgressChanged?.Invoke(this, new HardWorkerEventArgs(progress));
        }

        private void OnHardWorkDone()
        {
            HardWorkDone?.Invoke(this, EventArgs.Empty);
        }
    }
}