using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Math.Pow(i, j);
                }
                this.OnProgressChanged(i);
            }
            this.OnHardWorkDone();
        }
        private void OnProgressChanged(int progress)
        {
            var handler = this.ProgressChanged;
            if (handler != null)
            {
                handler(this, new HardWorkerEventArgs(progress));
            }
        }
        private void OnHardWorkDone()
        {
            var handler = this.HardWorkDone;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
    public class HardWorkerEventArgs : EventArgs
    {
        public HardWorkerEventArgs(int progress)
        {
            this.Progress = progress;
        }
        public int Progress
        {
            get;
            private set;
        }
    }
}
