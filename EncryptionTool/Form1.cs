using _CommonCode_Framework;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EncryptionTool
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitVariables();
            InitControls();
        }

        private void InitVariables()
        {
            csPublic.Config = new csConfig();

        }

        private void InitControls()
        {
            //Input/output
            var typeList = Enum.GetValues(typeof(_TextType));
            InitLookupEdit(InputLookUpEdit);
            InputLookUpEdit.Properties.DataSource = typeList;
            InputLookUpEdit.Properties.DropDownRows = typeList.Length; //Limit rows
            InputLookUpEdit.EditValue = csPublic.Config.InputType;
            InputLookUpEdit.EditValueChanged += InputLookUpEdit_EditValueChanged;



            InitLookupEdit(OutputLookUpEdit);
            OutputLookUpEdit.Properties.DataSource = typeList;
            OutputLookUpEdit.Properties.DropDownRows = typeList.Length; //Limit rows
            OutputLookUpEdit.EditValue = csPublic.Config.OutputType;
            OutputLookUpEdit.EditValueChanged += OutputLookUpEdit_EditValueChanged;


        }

        private void OutputLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (OutputLookUpEdit.EditValue is _TextType)
            {
                csPublic.Config.OutputType = (_TextType)OutputLookUpEdit.EditValue;
            }
        }

        private void InputLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (InputLookUpEdit.EditValue is _TextType)
            {
                csPublic.Config.InputType = (_TextType)InputLookUpEdit.EditValue;
            }
        }

        private void InitLookupEdit(LookUpEdit lookUpEdit)
        {
            lookUpEdit.Properties.ShowFooter = false; //Hide X
            lookUpEdit.Properties.NullText = ""; //Hide default null text
            lookUpEdit.CustomDisplayText += LookUpEdit_CustomDisplayText;
        }

        private void LookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            string sDescription = "";
            if (e.Value is _TextType)
            {
                sDescription = csEnumHelper<_TextType>.GetDescription((_TextType)e.Value);
            }

            if (!string.IsNullOrWhiteSpace(sDescription))
            {
                e.DisplayText = sDescription;
            }
        }

        private void bCOnvert_Click(object sender, EventArgs e)
        {
            string sInput = InputMemoEdit.Text;
            if (string.IsNullOrWhiteSpace(sInput))
            {
                MessageBox.Show("Empty inputs");
                return;
            }

            //Convert input to bytes
            byte[] bData = null;
            if (csPublic.Config.InputType == _TextType.Hex)
            {

            }
            else if (csPublic.Config.InputType == _TextType.Raw)
            {
                bData = Encoding.UTF8.GetBytes(sInput);
            }

            var encryption = csPublic.Config.Encryption;
            string sResult = encryption.DecryptFromAesByte(bData);

            OutputMemoEdit.Text = sResult;
        }

        private void bLoadFile_Click(object sender, EventArgs e)
        {
            byte[] bData = null;
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string sPath = dialog.FileName;
                    bData = File.ReadAllBytes(sPath);
                    string sInput=File.ReadAllText(sPath);
                    InputMemoEdit.Text = sInput;

                    var encryption = csPublic.Config.Encryption;
                    string sResult = encryption.DecryptFromAesByte(bData);
                    OutputMemoEdit.Text = sResult;
                }
            }
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            FormAesConfig winConfig = new FormAesConfig();
            winConfig.StartPosition= FormStartPosition.CenterParent;
            winConfig.ShowDialog();
        }
    }
}
