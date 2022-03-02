using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPort_Ink
{
    class csPublic
    {
        /// <summary>
        /// Main form alias
        /// </summary>
        public static Form1 winMain { get; set; }

        public static csInkSystem InkSystem { get; set; }

        public static string TimeString => DateTime.Now.ToString("HH:mm:ss:fff");
    }


    public class GeneralResult
    {
        public bool IsSuccess { get; set; } //Method is succes or not
        /// <summary>
        /// Return int result if value needed
        /// </summary>
        public int IntResult { get; set; }
        /// <summary>
        /// Return string result if value needed
        /// </summary>
        public string StrResult { get; set; }
        public String Message { get; set; }
    }
}
