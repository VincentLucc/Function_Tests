using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLayout_19_1
{
    class csPublic
    {
    }


    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Class { get; set; }

        /// <summary>
        /// Virtual won't run
        /// </summary>
        public virtual void DoSth()
        {
            Debug.WriteLine("Dosth in Base.");
        }

        public void DoSthReal()
        {
            Debug.WriteLine("Dosth in Base.");
        }

        public Student Copy()
        {
            Student sNew = new Student();
            sNew.Age = Age;
            sNew.Name = Name;
            sNew.Description = Description;
            sNew.Class = Class;

            return sNew;
        }
    }
}
