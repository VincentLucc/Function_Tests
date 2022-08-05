using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormMemory
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        FormTest winTest=new FormTest();

        public FormMain()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            winTest.ShowDialog();
        }

        private void bShow_Click(object sender, EventArgs e)
        {
            using (FormTest testForm = new FormTest())
            {
                testForm.ShowDialog();
                testForm.Close();
            }
          
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            GC.Collect(GC.MaxGeneration,GCCollectionMode.Forced,true);
        }
    }
}
