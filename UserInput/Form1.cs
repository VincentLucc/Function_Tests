using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInput
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TestButtonEdit.EditValue = 100;//Current value
            TestButtonEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            TestButtonEdit.ButtonClick += TestButtonEdit_ButtonClick;
        }

        private void TestButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var result = GetUserInput(TestButtonEdit.EditValue, "");
            if (result.IsSuccess)
            {
                MessageBox.Show($"New Value:{result.ObjResult}");
            }
        }

        private GeneralResult GetUserInput(object EditValue, string sEditMask, string sCaptain = "Enter New Setpoint", string sPrompt = "Change Setpoint")
        {
            GeneralResult result = new GeneralResult();

            XtraInputBoxArgs inputBox = new XtraInputBoxArgs();

            inputBox.Caption = sCaptain;
            inputBox.Prompt = sPrompt;
            inputBox.DefaultButtonIndex = 0;
            inputBox.DefaultResponse = EditValue;

            SpinEdit spinEdit = new SpinEdit();
            spinEdit.Properties.Mask.EditMask = sEditMask;
            inputBox.Editor = spinEdit;

            var response = XtraInputBox.Show(inputBox);

            if (response!=null)
            {
                if (EditValue==null)
                {
                    result.ObjResult = response;
                    result.IsSuccess = true;
                    return result;
                }
                else
                {
                    if (response.ToString() != EditValue.ToString())
                    {
                        result.ObjResult = response;
                        result.IsSuccess = true;
                        return result;
                    }
                }
            }

            //No success
            return result;
        }
    }
}
