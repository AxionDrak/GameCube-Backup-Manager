using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace GCBM
{
    internal class ExceptionHelper
    {
        #region File Not Found
        
        public void NewFileNotFoundException(Exception ex,int intQueuePos)
        {//Setup variables to store information about the file browser dialog, show the dialog and ask the user to locate the file, then check if it is the same file. 
            string strPath = "";
            string description = "Unable to locate the specified file at \"{0}\". Please locate the folder containing \"{1}\" and select it.";
            string file = LocateFile(ex, intQueuePos);
            if (file != null)
            {
                strPath = file;
            }
            else
            {
                strPath = null;
            }

            //proceed return the path, or, if canceled, continue to the next position in Queue
            if (strPath != null)
            {
                //if the file is found, replace the old path with the new one
                if (strPath != null)
                {
                    //replace the old path with the new one
                    GCBM.Properties.Settings.Default.strMissingFilePath = strPath;
                    GCBM.Properties.Settings.Default.Save();
                    //MessageBox.Show("The file was found at " + strPath);
                    //Resume the queue
                    //QueueManager.ResumeQueue();
                }
            }
            else
            {
                //if the file is not found, continue to the next position in Queue
                intQueuePos++;
            }

        }

        private string LocateFile(Exception ex, int intQueuePos)
        {

            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Title = "File Not Found",
                Filter = "ISO Image File (*.iso)|*.iso",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                FileName = ex.Message.Substring(ex.Message.IndexOf("at ") + 3),
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true
            };
            var result =  fileDialog.ShowDialog();
            if (result == true)
            {
                if (fileDialog.FileName == ex.Message.Substring(ex.Message.IndexOf("at ") + 3))
                {
                    return fileDialog.FileName;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
