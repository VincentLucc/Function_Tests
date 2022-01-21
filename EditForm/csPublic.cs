using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditForm
{
    class csPublic
    {
    }

    class Student
    {

        public string Name { get; set; }


        public int Age { get; set; }


        public string TextNormal { get; set; }

        public string TextReg { get; set; }


        public string TextNum { get; set; }

        [DisplayName("Toggle Switch Haha")]
        public bool ToggleSwitch { get; set; }

        public bool[] List { get; set; }

        public Student()
        {
            List = new bool[3];
            TextReg = "CE1";
        }
    }

   

}
