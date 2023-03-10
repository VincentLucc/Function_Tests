using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGeneration
{
    [Serializable]
    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Class { get; set; }

        [Browsable(false)]
        public static string StaticText = "500";

        /// <summary>
        /// Virtual won't run
        /// </summary>
        /// 
        public virtual void DoSth()
        {
            Debug.WriteLine("Dosth in Base.");
        }

        public void DoSthReal()
        {
            Debug.WriteLine("Dosth in Base.");
        }

        public Student() { }


        public Student(int iID)
        {
            Age = iID;
            Name = "Stu_" + iID;
            Description = "Info_" + iID;
            Class = "Class_" + iID / 10;
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
