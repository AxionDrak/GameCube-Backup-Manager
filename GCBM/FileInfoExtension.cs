using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCBM
{
    public static class FileInfoExtension
    {
        public static void CopyTo(this FileInfo file, FileInfo destination, Action<int> progressCallback)
        {
            const int bufferSize = 1024 * 1024;
            byte[] buffer = new byte[bufferSize], buffer2 = new byte[bufferSize];
            bool swap = false;
            //int progress = 0, reportedProgress = 0, read = 0;
            int reportedProgress = 0;
            // Validar argumentos de métodos públicos
            // #pragma warning disable CA1062
            long len = file.Length;
            // Validar argumentos de métodos públicos
            // #pragma warning restore CA1062
            float flen = len;
            Task writer = null;

            //string.IsNullOrEmpty(destination);

            using (var source = file.OpenRead())
            using (var dest = destination?.OpenWrite())
            {
                dest.SetLength(source.Length);
                int read;
                for (long size = 0; size < len; size += read)
                {
                    int progress;
                    if ((progress = ((int)((size / flen) * 100))) != reportedProgress)
                        progressCallback(reportedProgress = progress);
                    read = source.Read(swap ? buffer : buffer2, 0, bufferSize);
                    writer?.Wait();
                    writer = dest.WriteAsync(swap ? buffer : buffer2, 0, read);
                    swap = !swap;
                }
                writer?.Wait();
            }
        }
    }
}
