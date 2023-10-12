using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeList
{

    public class Student
    {
        public string name { get; set; }
        public int id { get; set; }
        public int age { get; set; }

        public bool Enable { get; set; }
        public Image image { get; set; }

    }

    public class StudentString
    {
        public string id { get; set; }
        public string name { get; set; }
        public string age { get; set; }

    }
}
