using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization_48
{
    internal class csModel
    {
    }

    public class Test
    {
        public int IntValue { get; set; }
        public string? StrValue { get; set; }
        public Dictionary<string,int> TagReasons { get; set; }

        public Test ()
        {
            TagReasons=new Dictionary<string, int> ();
        }
    }
}
