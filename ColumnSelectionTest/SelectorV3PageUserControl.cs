using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test001
{
    public partial class SelectorV3PageUserControl : UserControl
    {
        public SelectorV3PageUserControl()
        {
            InitializeComponent();
            //Init evnets
            this.Load += SelectorV3PageUserControl_Load;
        }

        private void SelectorV3PageUserControl_Load(object sender, EventArgs e)
        {
            //Create fake data
            csFileData fileData = new csFileData();
            fileData.DataLines = csPublic.FakeText.Split(new string[] { "\r\n", "\r" }, StringSplitOptions.None).ToList();
            columnSelector.LoadDataRows(fileData);
        }
    }
}
