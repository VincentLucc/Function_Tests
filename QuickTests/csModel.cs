using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace QuickTests
{
    class csModel
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

    public class StudentOverWrite : Student
    {
        public override void DoSth()
        {
            Debug.WriteLine("Dosth in StudentOverWrite.");
        }
    }

    public class StudentNew : Student
    {
        public new void DoSth()
        {
            Debug.WriteLine("Dosth in StudentNew.");
        }

        public new void DoSthReal()
        {
            Debug.WriteLine("Dosth in StudentNew.");
        }
    }

    public class StudentEvent
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; NameChanged?.Invoke(); }
        }

        public delegate void NameChangedAction();
        public event NameChangedAction NameChanged;

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; AgeChanged?.Invoke(); }
        }

        public delegate void AgeChangedAction();
        public event AgeChangedAction AgeChanged;

    }


    public class Device
    {
        public int DeviceName { get; set; }
        public bool Connected { get; set; }
    }
}
