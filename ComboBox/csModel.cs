using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ComboBox
{
    public class csModel
    {

    }

    public enum _type2
    {
        [XmlEnum("1"), Display(Name = "Disp_01")]
        AB = 0b00000001,
        [XmlEnum("2"), Display(Name = "Disp_02")]
        CD = 0b00000010,
        [XmlEnum("3"), Display(Name = "Disp_03")]
        EF = 0b00000100,
    }
}
