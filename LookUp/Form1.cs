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


            //Lookup edit control, base control
            LookupEditInit(sList);



            //Search lookup
            searchLookUpEdit1.Properties.DataSource= sList;

            //Grid lookup control
            GridLookupEditInit(sList);




        }

        private void LookupEditInit(BindingList<string> sList)
        {
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
        }

        private void GridLookupEditInit(BindingList<string> sList)
        {
            //Grid lookup
            gridLookUpEdit1.Properties.DataSource = sList; //single value can be directly bind
            gridLookUpEdit1.EditValue = sEdit;
            gridLookUpEdit1.Properties.ShowFooter = false;

            //Grid lookup customized
            var image = Properties.Resources.Icon;
            //List or bind list won't work, use data table instead
            //BindingList<ImageString> imageStrings = new BindingList<ImageString>();
            //for (int i = 0; i < 5; i++)
            //{
            //    var item = new ImageString();
            //    item.Image = image;
            //    item.Value = "Value_"+i+1;
            //    imageStrings.Add(item);
            //}

            DataTable dt = new DataTable();
            dt.Columns.Add(nameof(ImageString.Image), typeof(Bitmap));
            dt.Columns.Add(nameof(ImageString.Value));
            for (int i = 0; i < 5; i++)
            {
                var dataRow = dt.NewRow();
                dataRow[nameof(ImageString.Image)] = image;
                dataRow[nameof(ImageString.Value)] = "Value_" + i + 1;
                dt.Rows.Add(dataRow);
            }

            gridLookUpEditCustomized.Properties.DataSource = dt; //If use class list must use data table
            var gridView = gridLookUpEditCustomized.Properties.View;
         
            // The field for the editor's display text.
            gridLookUpEditCustomized.Properties.DisplayMember = nameof(ImageString.Value);
            // The field matching the edit value.
            gridLookUpEditCustomized.Properties.ValueMember = nameof(ImageString.Value);
            gridLookUpEditCustomized.EditValue = sEdit;
            gridLookUpEditCustomized.Properties.ShowFooter = false;
            gridView.OptionsView.ShowColumnHeaders = false;//hide column
            gridView.Columns[nameof(ImageString.Image)].MaxWidth = 30;
            //Draw row cell


        }



        private void Properties_CustomDrawButton1(object sender, DevExpress.XtraEditors.Controls.CustomDrawButtonEventArgs e)
        {
            var image = Properties.Resources.Icon;
            e.Graphics.DrawImage(image, -100, 0, 50, 20);
        }

 

        private void LookUpEdit2_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "      " + e.DisplayText;
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
        }


 
    }
}
