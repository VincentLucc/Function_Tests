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
    public partial class WinListBox : Form
    {
        public WinListBox()
        {
            InitializeComponent();
        }

        private void WinListBox_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                listBox1.Items.Add("abcdefg_123456_"+i.ToString("D3"));
            }

            
        }
    }
}
