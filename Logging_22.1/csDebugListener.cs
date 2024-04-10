using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logging_22._1
{
    /// <summary>
    /// Write debug info into the logging class
    /// </summary>
    public class csDebugListener : TraceListener
    {

        public csLogHelper logHelper;

        public TextWriter TextWriter { get; set; }

        public csDebugListener(csLogHelper _logHelper)
        {
            logHelper = _logHelper;
        }

        public override void Write(string message)
        {
            logHelper.AddLogMessage(message, _logType.Debug);
        }

        public override void WriteLine(string message)
        {
            logHelper.AddLogMessage(message, _logType.Debug);
        }
    }
}
