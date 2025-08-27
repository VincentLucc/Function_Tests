using _CommonCode_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Copy
{
    public class csInstanceCopyLog
    {
        /// <summary>
        /// Field or property name
        /// </summary>
        public string PropertyName { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
        public string Message { get; set; }

        public csInstanceCopyLog(string sPropertyName)
        {
            PropertyName = sPropertyName;
        }

        public csInstanceCopyLog(string sPropertyName, string sMessage)
        {
            PropertyName = sPropertyName;
            Message = sMessage;
        }

        public csInstanceCopyLog(string sPropertyName, object oPreviousValue, object oNewValue)
        {
            PropertyName = sPropertyName;
            PreviousValue = oPreviousValue.GetValidString();
            NewValue = oNewValue.GetValidString();
        }
    }
}
