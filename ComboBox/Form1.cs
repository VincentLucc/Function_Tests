using DevExpress.XtraEditors.Controls;
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

            //Image combobox
            icbTest.Properties.Items.Clear();
            icbTest.Properties.SmallImages = imageCollection1;
            for (int i = 0; i < 2; i++)
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = "Desc_"+i;
                item.ImageIndex = i;
                item.Value = i; //This must have, otherwise value can't be selected
                icbTest.Properties.Items.Add(item);
            }
            icbTest.ShowToolTips = true;
            icbTest.MouseMove += IcbTest_MouseMove;
        }

        private List<Image> GetImageList()
        {
            List<Image> images = new List<Image>();
            images.Add(Properties.Resources.Heart_Monitor);
            images.Add(Properties.Resources.RingDarkBlue);
            return images;
        }

        private void IcbTest_MouseMove(object sender, MouseEventArgs e)
        {
            icbTest.ToolTip = e.Y.ToString();
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
