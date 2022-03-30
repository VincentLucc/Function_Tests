using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    class csPublic
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

        public object ObjResult { get; set; }
        public String Message { get; set; }
    }

    public class EditMasks
    {
        /// <summary>
        /// Number type editor
        /// </summary>
        public static string Type1Num = "";
        /// <summary>
        /// Regular express type
        /// </summary>
        public static string Type2Reg = ""; 
    }
}
