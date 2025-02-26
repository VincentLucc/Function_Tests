using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeProject
{

    internal class csDateTimeHelper
    {
        /// <summary>
        /// Record the app start time
        /// </summary>
        private static System.DateTime InitTime = System.DateTime.Now;

        /// <summary>
        /// stop watch is much accurate than the system datetime
        /// </summary>
        internal static Stopwatch stopwatch = Stopwatch.StartNew();

        internal static System.DateTime CurrentTime => InitTime.Add(stopwatch.Elapsed);
        internal static string TimeOnly_ss => CurrentTime.ToString(TimeFormats.HHmmss);
        internal static string TimeOnly_fff => CurrentTime.ToString(TimeFormats.HHmmssfff);
        internal static string TimeOnly_ffffff => CurrentTime.ToString(TimeFormats.HHmmssffffff);
        internal static string DateTime_Display_ss => CurrentTime.ToString(TimeFormats.DisplayFull);

        internal static string DateTime_ss => CurrentTime.ToString(TimeFormats.yyyyMMdd_HHmmss);
        internal static string DateTime_fff => CurrentTime.ToString(TimeFormats.yyyyMMdd_HHmmss_fff);

        internal static string Date_MMddyyyy => CurrentTime.ToString(TimeFormats.MMddyyyy);
    }


    public class TimeFormats
    {
        public const string MMddyyyy = "MMddyyyy";
        public const string HHmmss = "HHmmss";
        public const string HHmmssfff = "HH:mm:ss.fff";
        public const string HHmmssffffff = "HH:mm:ss.ffffff";
        public const string yyyyMMdd_HHmmss = "yyyyMMdd_HHmmss";
        public const string yyyyMMdd_HHmmss_fff = "yyyyMMdd_HHmmss_fff";
        public const string DisplayFull = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
    }
}
