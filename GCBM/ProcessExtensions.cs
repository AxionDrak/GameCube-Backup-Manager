using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace GCBM
{
    public static class ProcessExtensions
    {
        public static IList<Process> GetChildProcesses(this Process process) 
            => new ManagementObjectSearcher(
                    $"Select * From Win32_Process Where ParentProcessID={process.Id}")
                .Get()
                .Cast<ManagementObject>()
                .Select(mo =>
                    Process.GetProcessById(Convert.ToInt32(mo["ProcessID"])))
                .ToList();
    }
}
