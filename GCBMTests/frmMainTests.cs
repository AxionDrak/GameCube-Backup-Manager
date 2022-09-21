using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCBM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GCBM.Tests
{
    [TestClass()]
    public class frmMainTests
    {
        [TestMethod()]
        public Task GetFilesFolderTest()
        {
            frmSplashScreen frmStartup = new frmSplashScreen();
            frmMain mainForm = frmStartup.GetMainForm();
            
            var filesFound = new List<string>();
            // Sets options for displaying root folder images.

            //bool isRecursive = GCBM.Program.ConfigFile.IniReadBool("SEVERAL", "RecursiveMode");

            #region Hardcoded Unit-test values
            bool isRecursive = true;
            string[] filters = { "*.iso" };
            string rootFolder = @"D:\Nintendo\Roms\";
            #endregion
            filesFound = frmMain.GetFilesFolder(rootFolder, filters, isRecursive).Result.ToList();

            //var optionSearch = isRecursive ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly;
            //foreach (var filter in filters)
            //    try
            //    {
            //        filesFound.AddRange(
            //            System.IO.Directory.GetFiles(rootFolder, string.Format("*.{0}", filter), optionSearch));
            //    }
            //    catch (Exception ex)
            //    {
            //        // Not used.
            //        // Just to avoid mistakes.
            //        frmMain.Log.AppendText(ex.Message + Environment.NewLine + ex.StackTrace);
            //    }

            if (filesFound.Count == 32)
            {
                MessageBox.Show("Success");
                return Task.CompletedTask;
            }
            else
            {
                Assert.Fail();
                return Task.CompletedTask.ContinueWith(task
                    => throw new Exception("Failed"));
            }
        }
    }
}