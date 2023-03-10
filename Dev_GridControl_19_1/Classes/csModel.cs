using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dev_GridControl_19_1
{
    class csModel
    {
    }

    public class Student
    {
        [DisplayName("AgeView")]
        public int Age { get; set; }
        public string Name { get; set; }
        public string DescriptionInfo { get; set; }
        public string Class { get; set; }
        public bool Enable { get; set; }
        public bool Enable2 { get; set; }

        public Student()
        {
            Age = -1;
            Name = "Test";
            Enable = false;
            Enable2 = false;
            Class = "No Class";
        }

    }

    public class AlarmInfo
    {
        public string DeviceName { get; set; }
        public string Alarm { get; set; }

        public bool Checked { get; set; }
    }

    /// <summary>
    /// Used to display detail tag reasons
    /// </summary>
    public class AuxInfoView
    {
        public string DeviceName { get; set; }

        /// <summary>
        /// Maybe show different backgroud of the device name when device is faulty
        /// </summary>
        [Browsable(false)]
        public bool DeviceFaulty { get; set; }

        [DisplayName("Reject Reason")]
        public string TagReason { get; set; }

        [DisplayName("Count")]
        public int NumberOfTaggedProducts { get; set; }

        /// <summary>
        /// Default reson ID when no detail resons present
        /// </summary>
        [Browsable(false)]
        public static string DefaultReason = null;

        public void dd()
        {

        }
    }
}
