using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors;
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

namespace LookUpEdit_2201
{
    public partial class FormMain : XtraForm
    {

        //List or bind list won't work, use data table instead
        BindingList<ImageString> imageStrings = new BindingList<ImageString>();
        public BindingList<string> sList = new BindingList<string>();

        public FormMain()
        {
            InitializeComponent();
        }

        string sEdit = "";



        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Test:" + lookUpEdit1.EditValue.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Prepare data
            InitData();

            //Lookup edit control
            InitNormalLookupEdit();
            InitCustomDrawLookupEdit();
            InitImageLookupEdit();

            //Search lookup
            searchLookUpEdit1.Properties.DataSource = sList;

            //Grid lookup control
            GridLookupEditInit();
        }

        private void InitData()
        {
            //Simple datat source
            sList = new BindingList<string>();
            for (int i = 0; i < 3; i++)
            {
                sList.Add("Value_" + (i + 1).ToString());
            }

            //List or bind list won't work, use data table instead
            imageStrings = new BindingList<ImageString>();
            for (int i = 0; i < 5; i++)
            {
                var item = new ImageString();
                item.Image = imageCollection1.Images[i];
                item.Value = $"Value_{i + 1}_123abc";
                item.Index = i;
                imageStrings.Add(item);
            }
        }


        private void InitImageLookupEdit()
        {
            ImageLookupEdit.Properties.DataSource = imageStrings;
            ImageLookupEdit.Properties.Columns.Clear();
            ImageLookupEdit.Properties.DropDownRows = imageStrings.Count;
            ImageLookupEdit.Properties.ShowFooter = false;
        }

        private void InitNormalLookupEdit()
        {
            //Normal lookup
            lookUpEdit1.Properties.DataSource = sList;
            lookUpEdit1.EditValue = sEdit;
            lookUpEdit1.Properties.ShowHeader = false;
            lookUpEdit1.Properties.ShowFooter = false;
            lookUpEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;//Enable edit
            lookUpEdit1.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
        }


        private void InitCustomDrawLookupEdit()
        {
            //Lookup with custom draw
            lookUpEdit2.Properties.DataSource = sList;
            lookUpEdit2.EditValue = sEdit;
            lookUpEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;//Enable edit
            lookUpEdit2.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
            lookUpEdit2.CustomDrawCell += LookUpEdit2_CustomDrawCell;
            lookUpEdit2.CustomDisplayText += LookUpEdit2_CustomDisplayText;
            lookUpEdit2.Properties.CustomDrawButton += Properties_CustomDrawButton1;
            lookUpEdit2.EditValueChanged += LookUpEdit2_EditValueChanged;
        }

        private void LookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

            //Setup context image (Image inside the editor)
            string sValue = lookUpEdit2.EditValue.ToString();
            int iIndex = 0;
            if (sList.Contains(sValue))
            {
                iIndex = sList.IndexOf(sValue);
            }
            lookUpEdit2.Properties.ContextImageOptions.Image = imageCollection1.Images[iIndex];
        }

        private void GridLookupEditInit()
        {
            //Grid lookup normal
            gridLookUpEdit1.Properties.DataSource = sList; //single value can be directly bind
            gridLookUpEdit1.EditValue = sEdit;
            gridLookUpEdit1.Properties.ShowFooter = false;

            gridLookUpEditCustomized.Properties.DataSource = imageStrings; //If use class list must use data table
            var gridView = gridLookUpEditCustomized.Properties.PopupView;

            // The field for the editor's display text.
            gridLookUpEditCustomized.Properties.DisplayMember = nameof(ImageString.Value);
            // The field matching the edit value.
            gridLookUpEditCustomized.Properties.ValueMember = nameof(ImageString.Value);
            gridLookUpEditCustomized.EditValue = sEdit;
            gridLookUpEditCustomized.Properties.ShowFooter = false;
            gridView.OptionsView.ShowViewCaption = false;//hide column
            gridView.PopulateColumns();
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
            var rect = e.Bounds; //Get current cell location
            e.Graphics.DrawImage(imageCollection1.Images[iIndex], rect.X, rect.Y, 15, 15);
            //e.Cache.DrawImage(image, 10, 10, 15, 15);
            e.DisplayText = "      " + e.DisplayText;
        }

        private void ImageLookupEdit_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (ImageLookupEdit.EditValue is ImageString)
                {
                    var data = ImageLookupEdit.EditValue as ImageString;
                    ImageLookupEdit.Properties.ContextImageOptions.Image = data.Image;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ImageLookupEdit_EditValueChanged:\r\n" + ex.Message);
            }

        }
    }
}
