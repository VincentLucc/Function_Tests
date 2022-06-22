using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchV2
{
    class csPublic
    {
        public static FormStart winLuanch;
        public static MessageHelper messageHelper;
        public static bool IsFormValid(Form form)
        {
            bool bValue = form != null && !form.IsDisposed && !form.Disposing;
            return bValue;
        }
    
    }

    
}
