using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormLoad
{
    public class csUIHelper
    {
        public static FormEvent winEvent;
        public static FormLoad_NormalManual winLoadTest;
        public static FormLoad_DevAuto winLoadAutoTest;

        public static void ShowEventForm()
        {
            if (winEvent == null)
            {
                winEvent = new FormEvent();
            }

            winEvent.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            winEvent.ShowDialog();
        }

        public static void ShowManualReload()
        {
            if (winLoadTest == null)
            {
                winLoadTest = new FormLoad_NormalManual();
            }

            winLoadTest.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            winLoadTest.ShowDialog();
        }

        public static void ShowAutoReload()
        {
            if (winLoadAutoTest == null)
            {
                winLoadAutoTest = new FormLoad_DevAuto();
            }

            winLoadAutoTest.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            winLoadAutoTest.ShowDialog();
        }
    }
}
