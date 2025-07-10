using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CommonCode_Framework
{
    public static class csCommonExtension
    {
        public static double GetDoubleValue(this object oValue)
        {
            if (oValue == null) return -1;
            if (!double.TryParse(oValue.ToString(), out double dValue)) return -1;
            return dValue;
        }

        public static int GetIntValue(this object oValue)
        {
            if (oValue == null) return -1;
            //Int try-parse might get -1 for decimal values, use double instead
            string sValue = oValue.ToString();
            if (!double.TryParse(sValue, out double dValue)) return -1;
            int iValue = (int)dValue;
            return iValue;
        }

        public static string GetValidString(this object oValue)
        {
            if (oValue == null) return string.Empty;
            return oValue.ToString();
        }

        public static int GetValidLength(this object oValue)
        {
            if (oValue is string sValue)
            {
                return sValue.Length;
            }
            else
            {
                return 0;
            }

        }

        public static void TraceRecord(this string sMessage)
        {
            Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} {sMessage}");
        }

        /// <summary>
        /// Trace common exception
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="sMessage"></param>
        public static void TraceException(this Exception ex, string sMessage)
        {
            string sOutput = $"{csDateTimeHelper.TimeOnly_fff} {sMessage}.Exception:{ex.GetMessageDetail()}";
            Trace.WriteLine(sOutput);
        }

        internal static string GetMessageDetail(this Exception exception)
        {
            if (exception == null) return string.Empty;
            string msg = exception.Message;
            if (exception.InnerException != null)
            {
                msg += $"\r\n{exception.InnerException.Message}";
            }

            //Show stack trace
            if (!string.IsNullOrWhiteSpace(exception.StackTrace))
            {
                msg += $"\r\n{exception.StackTrace}";
            }

            return msg;
        }
    }
}
