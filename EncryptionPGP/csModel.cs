using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionPGP
{
    internal class csModel
    {

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
        public string Message { get; set; }
    }
    public class ErrorMessageResult
    {
        /// <summary>
        /// Major success flag
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Secondary flag
        /// </summary>
        public bool IsConfirmation { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        

      

    }


}
