using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHFSDKTest
{
    class csPublic
    {
        /// <summary>
        /// Reader device
        /// </summary>
        public static csReader RFIDReader=new csReader();
        public static string RFIDDeviceID="xxxxx";


    }

    public class GeneralResult
    {
        public bool IsSuccess { get; set; } //Method is succes or not
        /// <summary>
        /// Return int result if value needed
        /// </summary>
        public int IntValue { get; set; }
        /// <summary>
        /// Return string result if value needed
        /// </summary>
        public string StrValue { get; set; }

        public object ObjValue { get; set; }
        public string Message { get; set; }
    }

}
