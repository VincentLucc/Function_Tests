using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMemory
{
    public partial class FormTest : DevExpress.XtraEditors.XtraForm
    {
        public bool UIExit => this == null || this.Disposing || this.IsDisposed||!this.Visible;

        public Timer tTest { get; set; }

        bool IsLoaded { get; set; }

        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Test form loaded.");

            if (!IsLoaded)
            {
                tTest = new Timer();
                tTest.Interval = 100;
                tTest.Tick += TTest_Tick;
            }
 

            tTest.Enabled = true;

            IsLoaded = true;
        }

        private void TTest_Tick(object sender, EventArgs e)
        {
            tTest.Enabled = false;

            if (UIExit)
            {
                Debug.WriteLine("Test Exit");
                return;
            }


            tTest.Enabled = true;
        }
    }
}