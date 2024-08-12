using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLTests
{
    public class ParentClass
    {
        public int ParentInt1 { get; set; }

        public int ParentInt2 { get; set; }

        public ParentClass()
        {
            ParentInt1 = 1;
            ParentInt2 = 2;
        }
    }


    public class ChildClass1 : ParentClass
    {
        public int ChildInt1 { get; set; }

        public int ChildInt2 { get; set;}

        public ChildClass1()
        {
            ChildInt1 = 1;
            ChildInt2 = 2;
        }
    }


}
