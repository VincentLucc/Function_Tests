using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBox
{
    public class csValueItem
    {
        public string Value { get; set; }
        public string Description { get; set; }
        public object Tag { get; set; }

        public csValueItem()
        {
            Value = "";
        }

        public csValueItem(string sValue, string sDesc = null, object oTag = null)
        {
            Value = sValue;
            Description = sDesc;
            Tag = oTag;
        }
    }
}
