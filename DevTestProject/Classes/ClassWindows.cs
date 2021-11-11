using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class DisplayForm
    {
        /// <summary>
        /// Show test window
        /// </summary>
        public  static void Test()
        {
            if (ClassPublic.winTest == null)
            {
                ClassPublic.winTest = new FormTest();
                ClassPublic.winTest.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                ClassPublic.winTest.Show();
            }

            ClassPublic.winTest.BringToFront();
        }
    }
}
