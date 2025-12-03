using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevExpress.XtraVerticalGrid;
using Property_RegEditor_22._1;

namespace Hardware
{
    [XmlType("CPUSettings")]
    public class csCPUSettings
    {
        [CustomEditor(_editorType.ToggleSwitch)]
        [DisplayName("Enable CPU Affinity")]
        public bool EnableCPUAffinity { get; set; }

        
        [Browsable(false)]

        public bool[] CPUCoresEnable { get; set; } = new bool[64];

        [DisplayName("CPU Cores")]
        public string CPUCoresEnableView { get; set; }
    }
}
