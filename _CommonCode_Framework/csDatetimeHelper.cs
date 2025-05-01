using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Internal datetime.now is not accurate in enough under ms level
/// System time is about 10~15 ms in accuracy
/// Use this method to get more accurate ticks
/// </summary>

public class csDateTimeHelper
{
    /// <summary>
    /// Record the app start time
    /// </summary>
    public static System.DateTime InitTime = System.DateTime.Now;

    /// <summary>
    /// stop watch is much accurate than the system datetime
    /// </summary>
    public static Stopwatch stopwatch = Stopwatch.StartNew();

    public static System.DateTime CurrentTime => InitTime.Add(stopwatch.Elapsed);
    public static string TimeOnly_ss => CurrentTime.ToString(TimeFormats.HHmmss);
    public static string TimeOnly_fff => CurrentTime.ToString(TimeFormats.HHmmssfff);
    public static string TimeOnly_ffffff => CurrentTime.ToString(TimeFormats.HHmmssffffff);
    public static string DateTime_Display_ss => CurrentTime.ToString(TimeFormats.DisplayFull);

    public static string DateTime_ss => CurrentTime.ToString(TimeFormats.yyyyMMdd_HHmmss);
    public static string DateTime_fff => CurrentTime.ToString(TimeFormats.yyyyMMdd_HHmmss_fff);

    public static string Date_MMddyyyy => CurrentTime.ToString(TimeFormats.MMddyyyy);
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