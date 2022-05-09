using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lock
{
    public partial class FormNewTimer : Form
    {
        
        Timer tOperation { get; set; }

        public FormNewTimer()
        {
            InitializeComponent();
        }

        private void FormNewTimer_Load(object sender, EventArgs e)
        {
            tOperation = new Timer();
            tOperation.Interval = 100;
            tOperation.Tick += TOperation_Tick;
            tOperation.Start();

        }

        private void TOperation_Tick(object sender, EventArgs e)
        {
            csPublic.winMain.DoSth();
        }
    }
}
