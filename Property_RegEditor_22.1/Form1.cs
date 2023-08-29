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

namespace Property_RegEditor_22._1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
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
            csPropertyHelper propertyHelper = new csPropertyHelper(propertyGridControl1);
            propertyGridControl1.ValidatingEditor += PropertyGridControl1_ValidatingEditor;

        }

        private void PropertyGridControl1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            BaseRow editRow = (sender as PropertyGridControl).FocusedRow;
            string sFieldName = editRow.Properties.FieldName;
            string sValue = e.Value == null ? "" : e.Value.ToString();

            if (sFieldName == nameof(Student.Text3Num))
            {
                if (!int.TryParse(sValue, out int iValue) || iValue > 100)
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

            propertyGridControl1.SelectedObject = sList[listBoxControl1.SelectedIndex];
        }
    }
}
