using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Socket_Tool.Forms;

namespace Socket_Tool
{
    public class csLayoutHelper
    {
        //Alias
        public static FormMain winMain;
        public static FormServerAdd winServerAdd;

        public static void ShowServerAdd()
        {
            if (winServerAdd==null)
            {
                winServerAdd = new FormServerAdd();
                winServerAdd.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            }
            winServerAdd.ShowDialog();
        }
    }
}
