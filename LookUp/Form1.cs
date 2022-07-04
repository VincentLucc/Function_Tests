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
            BindingList<string> sList = new BindingList<string>();
            for (int i = 0; i < 3; i++)
            {
                sList.Add((i + 1).ToString());
            }
            lookUpEdit1.Properties.DataSource = sList;
            lookUpEdit1.EditValue = sEdit;
            lookUpEdit1.Properties.ShowHeader = false;
            lookUpEdit1.Properties.ShowFooter = false;
            lookUpEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;//Enable edit
            lookUpEdit1.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;

            lookUpEdit2.Properties.DataSource = sList;
            lookUpEdit2.EditValue = sEdit;
            lookUpEdit2.CustomDrawLine += LookUpEdit2_CustomDrawLine;

        }

        private void LookUpEdit2_CustomDrawLine(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawLineArgs e)
        {

            var newFont= new Font(new FontFamily("Arial"), 8, FontStyle.Regular);

            e.Graphics.DrawString("123", newFont, csDrawTool.BlueBrush, new Point(0,0));
        }
    }
}
