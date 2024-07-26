using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUserControls
{
    public class csUserControlItem
    {
        public XtraUserControl UserControl { get; set; }

        public string DisplayName { get; set; }

        public csUserControlItem()
        {

        }

        public csUserControlItem(XtraUserControl userControl, string displayName)
        {
            UserControl = userControl;
            DisplayName = displayName;
        }
    }

}
