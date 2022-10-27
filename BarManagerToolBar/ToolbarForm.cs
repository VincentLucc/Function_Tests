using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarManagerToolBar
{
    public partial class ToolbarForm : DevExpress.XtraEditors.XtraForm
    {
        public ToolbarForm()
        {
            InitializeComponent();
        }

        private void ToolbarForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                 //var item = new CheckedListBoxItem(widgetName,true);
                CheckedComboBoxEditTest.Items.Add($"Test{i}", CheckState.Checked, true);
            }
        }
    }
}