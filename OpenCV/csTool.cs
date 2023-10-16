using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Sharp4
{
    public class csTool
    {
        [Category(Catagaories.General),CustomEditor(_editorType.ToggleSwitch)]
        public bool Enable { get; set; }

    }
}
