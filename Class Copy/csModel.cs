using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Copy
{
    public class csModel
    {
    }

    public class Test1
    {
        public string A01 { get; set; }
        public string A02 { get; set; }
        public string A03 { get; set; }
        public Sub1 Sub1 { get; set; }

        public List<string> ListString { get; set; }

        public List<Sub1> ListSub { get; set; }

        public Test1()
        {
            Sub1 = new Sub1();
        }

    }

    public class Test2
    {
        public string A01 { get; set; }
        public string A02 { get; set; }
        public string A03 { get; set; }

        public string A04 { get; set; }

        public Sub2 Sub1 { get; set; }

        public List<string> ListString { get; set; }

        public List<Sub2> ListSub { get; set; }
    }

    public class Sub1
    {
        public string ABC { get; set; }
        public string A03 { get; set; }
    }

    public class Sub2
    {
        public string ABC { get; set; }
        public string A03 { get; set; }

        public Sub2()
        {
            ABC = DateTime.Now.ToString();
            A03 = DateTime.Now.ToString();
        }
    }
}
