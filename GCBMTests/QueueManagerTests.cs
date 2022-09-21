using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCBM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM.Tests
{
    [TestClass()]
    public class QueueManagerTests
    {
        [TestMethod()]
        public void BuildInstallQueueTest()
        {
            frmSplashScreen frmStartup = new frmSplashScreen();
            frmMain mainForm = frmStartup.GetMainForm();
            frmMain.LoadConfigFile();
            QueueManager qm = QueueManager.qmInstance;
            string[] paths = frmMain.GetFilesFolder(@"D:\Nintendo\Roms\Gamecube\Animal Crossing [GAFE01]",new []{"*.iso"}, true).Result;
            qm.BuildInstallQueue(paths);
            Assert.IsTrue(qm.InstallQueue.Count > 0);
        }
    }
}