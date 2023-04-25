using GCBM.Properties;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCBM
{
    public class Utility
    {

        #region Current Year and Date

        // Get the date and time
        public string TimeStamp()
        {
            var dt = DateTime.Now;
            //int dts = dt.Millisecond;
            //string dtnew = dt.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "." + dts.ToString();
            var dtnew = dt.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
            return dtnew;
        }
        #endregion
    }
}
