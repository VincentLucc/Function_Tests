using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraVerticalGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Property_RegEditor_22._1.Forms;
using System.Diagnostics;
using DevExpress.XtraBars.Ribbon;

namespace Property_RegEditor_22._1
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        CustomPropertyPanelForm customPropertyPanelForm;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitListBox();
            InitPropertyGrid();
        }

        private void InitPropertyGrid()
        {
            csPropertyHelper propertyHelper = new csPropertyHelper(MainPropertyGridControl);
            MainPropertyGridControl.ValidatingEditor += PropertyGridControl1_ValidatingEditor;

            csPropertyHelper customPropertyHelper = new csPropertyHelper(CustomPropertyGridControl);
            CustomPropertyGridControl.DataSourceChanged += CustomPropertyGridControl_DataSourceChanged;


            CustomPropertyGridControl.TabIndexChanged += CustomPropertyGridControl_TabIndexChanged;//Doesn't trigger when tab changed
            CustomPropertyGridControl.TabStopChanged += CustomPropertyGridControl_TabStopChanged;//Doesn't trigger when tab changed
            CustomPropertyGridControl.SelectedTabChanged += CustomPropertyGridControl_SelectedTabChanged;
            //Init tabs 
            var generalTab = CustomPropertyGridControl.Tabs[0];
            generalTab.CategoryNames.Add("Test");

            var miscTab = CustomPropertyGridControl.Tabs[1];
            miscTab.CategoryNames.Add("Cert");

        }

        private void CustomPropertyGridControl_SelectedTabChanged(object sender, DevExpress.XtraVerticalGrid.Events.SelectedTabChangedEventArgs e)
        {
            Debug.WriteLine("CustomPropertyGridControl_SelectedTabChanged");
        }

        private void CustomPropertyGridControl_TabStopChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("CustomPropertyGridControl_TabStopChanged");
        }

        private void CustomPropertyGridControl_TabIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("CustomPropertyGridControl_TabIndexChanged");
            UpdateCustomPanel();
        }

        private void CustomPropertyGridControl_DataSourceChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("CustomPropertyGridControl_DataSourceChanged");
            UpdateCustomPanel();
        }

        private void UpdateCustomPanel()
        {
            if (CustomPropertyGridControl.SelectedObject is Student)
            {
                var stu = CustomPropertyGridControl.SelectedObject as Student;
                if (stu == null) return;

                if (stu.Age == 3)
                {
                    CustomContainPanelControl.Controls.Clear();
                    var control = new RepositoryAnyUserControl();
                    control.Dock = DockStyle.Fill;
                    CustomContainPanelControl.Controls.Add(control);
                    CustomContainPanelControl.Visible = true;
                }
                else
                {
                    HideCustomPanel();
                }


            }
            else
            {
                HideCustomPanel();
            }
        }

        private void HideCustomPanel()
        {
            CustomContainPanelControl.Visible = false;
        }

        private void PropertyGridControl1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            BaseRow editRow = (sender as PropertyGridControl).FocusedRow;
            string sFieldName = editRow.Properties.FieldName;
            string sValue = e.Value == null ? "" : e.Value.ToString();

            if (sFieldName == nameof(Student.Text3Num))
            {
                if (int.TryParse(sValue, out int iValue) && iValue >= 0 && iValue < 100)
                {
                    e.Valid = true;
                }
                else
                {
                    e.ErrorText = "Invalid Text3 number";
                    e.Valid = false;
                }
            }
        }

        List<Student> sList = new List<Student>();
        private void InitListBox()
        {

            for (int i = 0; i < 5; i++)
            {
                Student sTemp = new Student();
                sTemp.Name = $"S_{i + 1}";
                sTemp.Age = i + 1;
                sList.Add(sTemp);
            }

            listBoxControl1.DataSource = sList.Select(x => x.Name).ToList();
        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxControl1.SelectedIndex < 0) return;

            var selection = sList[listBoxControl1.SelectedIndex];

            //Update all property control
            MainPropertyGridControl.SelectedObject = selection;
            CustomPropertyGridControl.SelectedObject = selection;
            customPropertyPanelForm?.UpdateSelection(selection);
        }

        private void bCutomized_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //show custom form
            using (customPropertyPanelForm = new CustomPropertyPanelForm())
            {
                customPropertyPanelForm.FormClosed -= CustomPropertyPanelForm_FormClosed;
                customPropertyPanelForm.FormClosed += CustomPropertyPanelForm_FormClosed;
                //customPropertyPanelForm.ShowDialog();
                customPropertyPanelForm.Show(this);
            }
        }

        private void CustomPropertyPanelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            customPropertyPanelForm = null;
        }
    }
}
