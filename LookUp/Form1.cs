using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LookUp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string sEdit = "";

        private void simpleButton1_Click(object sender, EventArgs e)
        {

           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Test:"+sEdit.ToString());
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Test:" + lookUpEdit1.EditValue.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Prepare data
            BindingList<string> sList = new BindingList<string>();
            for (int i = 0; i < 3; i++)
            {
                sList.Add("Value_"+(i + 1).ToString());
            }


            //Normal lookup
            lookUpEdit1.Properties.DataSource = sList;
            lookUpEdit1.EditValue = sEdit;
            lookUpEdit1.Properties.ShowHeader = false;
            lookUpEdit1.Properties.ShowFooter = false;
            lookUpEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;//Enable edit
            lookUpEdit1.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;

            //Lookup with costom draw
            lookUpEdit2.Properties.DataSource = sList;
            lookUpEdit2.EditValue = sEdit;
            lookUpEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;//Enable edit
            lookUpEdit2.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
            lookUpEdit2.CustomDrawCell += LookUpEdit2_CustomDrawCell;
            lookUpEdit2.CustomDisplayText += LookUpEdit2_CustomDisplayText;
            lookUpEdit2.Properties.CustomDrawButton += Properties_CustomDrawButton1;

            //Search lookup
            searchLookUpEdit1.Properties.DataSource= sList;

            //Grid lookup
            gridLookUpEdit1.Properties.DataSource = sList;
            gridLookUpEdit1.EditValue = sEdit;
            gridLookUpEdit1.Properties.ShowFooter = false;



        }

        private void Properties_CustomDrawButton1(object sender, DevExpress.XtraEditors.Controls.CustomDrawButtonEventArgs e)
        {
            var image = Properties.Resources.Icon;
            e.Graphics.DrawImage(image, 0, 0, 50, 15);
        }

 

        private void LookUpEdit2_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            
        }

        private void LookUpEdit2_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            int iIndex = e.RowIndex;
            //var newFont = new Font(new FontFamily("Arial"), 8, FontStyle.Regular);
            var image = Properties.Resources.Icon;
            var rect = e.Bounds; //Get current cell location
            e.Graphics.DrawImage(image, rect.X, rect.Y, 15, 15);
            //e.Cache.DrawImage(image, 10, 10, 15, 15);
            e.DisplayText = "      " + e.DisplayText;


            //e.DefaultDraw();
            //e.Handled = true;
        }


 
    }
}
