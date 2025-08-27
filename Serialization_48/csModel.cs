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
        public string StrValue { get; set; }
        public string StrValueEmpty { get; set; }
        public Dictionary<string,int> TagReasons { get; set; }

        public Test ()
        {
            TagReasons=new Dictionary<string, int> ();
        }

        public static Test CreateSmple()
        {
            var test = new Test();
            test.IntValue = 1;
            test.StrValue = "abc";
            for (int i = 0; i < 3; i++)
            {
                test.TagReasons.Add($"Reason_{i + 1}", i + 1);
            }

            return test;
        }

    }
}
