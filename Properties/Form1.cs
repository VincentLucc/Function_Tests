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

namespace Properties
{
    public partial class Form1 : Form
    {
        List<Student> sList;
        public Form1()
        {
            InitializeComponent();
        }

        private void propertyGridControl1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sList = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                Student sTemp = new Student();
                sTemp.Name = $"S_{i+1}";
                sTemp.Age = i + 1;
                sList.Add(sTemp);
                listBox1.Items.Add(i+1);
            }

            listBox1.DataSource = sList.Select(x=>x.Name).ToList();

            //Define custom editor
            propertyGridControl1.CustomRecordCellEdit += PropertyGridControl1_CustomRecordCellEdit;

            //tests
            textEdit1.Validating += TextEdit1_Validating;
        }

        private void TextEdit1_Validating(object sender, CancelEventArgs e)
        {
            Debug.WriteLine("Validating");
        }

        private void PropertyGridControl1_CustomRecordCellEdit(object sender, DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs e)
        {
            Debug.WriteLine("Custom Edit Trigger:");

       
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Verify index
            if (listBox1.SelectedIndex < 0) return;
            propertyGridControl1.SelectedObject = sList[listBox1.SelectedIndex];

            
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
