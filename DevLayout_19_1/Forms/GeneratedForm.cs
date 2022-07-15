using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevLayout_19_1
{
    public partial class GeneratedForm : DevExpress.XtraEditors.XtraForm
    {
        public GeneratedForm()
        {
            InitializeComponent();
        }

        private void GeneratedForm_Load(object sender, EventArgs e)
        {
            var uc1 = new ucGridDemo();

            var uc2 = new ucSample();
            tableLayoutPanel1.Controls.Add(uc1, 1, 1);
            tableLayoutPanel1.Controls.Add(uc2, 2, 1);


            var uc3 = new ucGridDemo();
            LayoutControl layoutControl3 = new LayoutControl();
            layoutControl3.Dock = DockStyle.Fill;
            layoutControl3.Controls.Add(uc3);

            tableLayoutPanel1.Controls.Add(layoutControl3, 1, 2);



            var uc4 = new ucSample();
            LayoutControl layoutControl4 = new LayoutControl();
            layoutControl4.Dock = DockStyle.Fill;
            layoutControl4.OptionsView.DrawItemBorders = true;
            layoutControl4.Controls.Add(uc4);
            layoutControl4.OptionsView.ItemBorderColor = Color.Red;
            uc4.Dock = DockStyle.Fill;
            layoutControl4.OptionsView.AllowItemSkinning = true;
            var layoutItem = layoutControl4.GetItemByControl(uc4);
         
            tableLayoutPanel1.Controls.Add(layoutControl4, 2, 2);
        }
    }
}