using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_GridControl
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
        [DisplayName("theClass")]
        public string Class { get; set; }
    }

    public class AlarmInfo
    {
        public string DeviceName { get; set; }
        public string Alarm { get; set; }
    }
}
