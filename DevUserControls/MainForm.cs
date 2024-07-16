using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevUserControls
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ContentPanelControl.Controls.Clear();

            var test1=new Test01UserControl();
            test1.Dock = DockStyle.Fill;
            ContentPanelControl.Controls.Add(test1);
        }
    }
}
