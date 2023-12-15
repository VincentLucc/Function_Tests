using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Classes
{
    internal class csModels
    {
    }

    public class csStringValue
    {
        public string Value { get; set; }

        public static List<csStringValue> FromListString(List<string> stringList)
        {
            var valueList=new List<csStringValue>();
            foreach (var stringValue in stringList)
            {
                valueList.Add(new csStringValue() {Value= stringValue });
            }
            return valueList;
        }
    } 

}
