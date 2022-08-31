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
        public static FormLoadTest winLoadTest;

        public static void ShowEventForm()
        {
            if (winEvent == null)
            {
                winEvent = new FormEvent();
            }

            winEvent.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            winEvent.ShowDialog();
        }

        public static void ShowLoadTest()
        {
            if (winLoadTest == null)
            {
                winLoadTest = new FormLoadTest();
            }

            winLoadTest.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            winLoadTest.ShowDialog();
        }
    }
}
