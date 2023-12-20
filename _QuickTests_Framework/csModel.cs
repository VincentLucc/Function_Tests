using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace _QuickTests_Framework
{
    class csModel
    {
    }

    [Serializable]
    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Order inside the class room
        /// </summary>
        public int SeatOrder { get; set; }
        public string Class { get; set; }

        public string Message { get; set; }

        public static string TestMessage = "'_QuickTests.exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\6.0.18\\System.Runtime.Numerics.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.";
        public string Grade { get; set; }

        [Browsable(false)]
        public static string StaticText = "500";

        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Text5 { get; set; }

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

        public Student Copy()
        {
            Student sNew = new Student();
            sNew.Age = Age;
            sNew.Name = Name;
            sNew.Description = Description;
            sNew.Class = Class;
            sNew.Message = Message;
            return sNew;
        }

        public Student()
        {

        }

        public Student(int iID)
        {
            Age = iID;
            Name = "Stu_" + iID;
            Description = "Info_" + iID;
            Class = "Class_" + iID / 10;
            Message = "'_QuickTests.exe' (CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\6.0.18\\System.Runtime.Numerics.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.";
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

    public enum SampleEnumTest
    {
        [Description("ABC DESC")]
        ABC,
        [Description("DEF DESC")]
        DEF,
        [Description("GHJ DESC")]
        GHJ,
        [Display(Name = "dfsdf")]
        MNX
    }


    public enum AddDataType
    {
        DuplicationCheck,
        Append,
        Insert
    }

    /// <summary>
    /// Must use [flags]
    /// 0b 二进制
    /// 0x 16进制
    /// </summary>
    [Flags]
    public enum _weekDays
    {
        Monday = 0b00000001,
        Tuesday = 0b00000010,
        Wednesday = 0b00000100,
        Thursday = 0b00001000,
        Friday = 0b00010000,
        Saturday = 0b00100000,
        Sunday = 0b01000000,
        WeekendDays = 0b01100000,
        WorkDays = 0b00011111
    }

}
