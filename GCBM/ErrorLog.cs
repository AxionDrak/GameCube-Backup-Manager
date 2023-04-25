using GCBM.Properties;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace GCBM
{
    public class ErrorLog
    {

        /// <summary>
        ///     Output environment information to the log.
        /// </summary>
        public void WriteHeader(TextBox tbLog)
        {
            var ts = DateTime.Now.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
            var assembly = Assembly.GetExecutingAssembly();
            var _version = assembly.GetName().Version;
            // Log
            tbLog.AppendText(
                "[" + ts + "]" + Resources.RegisterHeaderLog_GcbmLogCreated + Environment.NewLine);
            // Version number of the OS
            tbLog.AppendText("[" + ts + "]" + Resources.RegisterHeaderLog_OSVersion + Environment.OSVersion +
                             Environment.NewLine);
            // Major, minor, build, and revision numbers of the CLR
            tbLog.AppendText("[" + ts + "]" + Resources.RegisterHeaderLog_CLRVersion + Environment.Version +
                             Environment.NewLine);
            // Amount of physical memory mapped to the process context
            tbLog.AppendText("[" + ts + "]" + Resources.RegisterHeaderLog_WorkingSet +
                             Environment.WorkingSet + Environment.NewLine);
            // Array of string containing the names of the logical drives
            tbLog.AppendText("[" + ts + "]" + Resources.RegisterHeaderLog_LogicalUnits +
                             string.Join(", ", Environment.GetLogicalDrives()) + Environment.NewLine);
            // Gets the name of the program.
            tbLog.AppendText("[" + ts + "]" + Resources.RegisterHeaderLog_ProgramName + frmMain.AssemblyProduct +
                             Environment.NewLine);
            // Gets the program version.
            tbLog.AppendText("[" + ts + "]" + Resources.RegisterHeaderLog_ApplicationVersion + _version +
                             Environment.NewLine);
            // Gets the current program directory.
            tbLog.AppendText("[" + ts + "]" + Resources.RegisterHeaderLog_CurrentProgramDirectory +
                             frmMain.GET_CURRENT_PATH + Environment.NewLine);
        }
    }
}