using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> sList = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                sList.Add($"Test{i}");
            }

            cbTest01.DataSource = sList;
            cbTest01.SelectedIndex = 3;
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            List<string> sList = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                sList.Add($"ABC{i}");
            }

            cbTest01.DataSource= sList;
            cbTest01.SelectedIndex = -1;
        }
    }
}
