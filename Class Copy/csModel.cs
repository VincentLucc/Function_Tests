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
        public string Property01 { get; set; }
        public string Property02 { get; set; }
        public string Field01;
        public Sub1 SubItem { get; set; }

        public List<string> ListString { get; set; } = new List<string>();

        public List<Sub1> ListSubItem { get; set; } = new List<Sub1>();

        public EnumTest Test01 { get; set; }

        public Test1()
        {
            SubItem = new Sub1();
            Test01 = EnumTest.Level3;
        }

    }

    public class Test2
    {
        public string Property01 { get; set; }
        public string Property02 { get; set; }
        public string Field01;

        public string A04 { get; set; }

        public Sub2 SubItem { get; set; }

        public List<string> ListString { get; set; } = new List<string>();

        public List<Sub2> ListSubItem { get; set; } = new List<Sub2>();

        public EnumTest Test01 { get; set; }
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

    public enum EnumTest
    {
        Level1=1, 
        Level2=2, 
        Level3=3, 
        Level4=4, 
        Level5=5,
    }
}
