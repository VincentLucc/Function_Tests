using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBox
{
    public partial class DevListBoxAlignment : DevExpress.XtraEditors.XtraForm
    {
        public DevListBoxAlignment()
        {
            InitializeComponent();
        }

        private void DevListBoxAlignment_Load(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                listBoxControl1.Items.Add("abcdefg_123456_" + i.ToString("D3"));
            }
        }
    }
}