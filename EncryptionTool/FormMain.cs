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
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public csDevMessage messageHelper { get; set; }

        public byte[] SourceBytes { get; set; }

       

        public FormMain()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.FormClosed += FormMain_FormClosed;

        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (csConfigureHelper.IsLoad)
            {
                if (!csConfigureHelper.SaveConfig(out string sMessage))
                {
                    messageHelper.Error(sMessage);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!InitVariables())
            {
                this.Close();
                return;
            }

            InitControls();
        }

        private bool InitVariables()
        {
            string sMessage = "";
            messageHelper = new csDevMessage(this);

            //Manual create config

            //csConfigureHelper.Config = new csConfig();
            //csConfigureHelper.Config.Encryptions.Add(csConfigureHelper.Config.Encryption);
            //csConfigureHelper.Config.Encryptions.Add(csConfigureHelper.Config.Encryption);
            //csConfigureHelper.SaveConfig(out sMessage);


            if (!csConfigureHelper.LoadConfig(out sMessage))
            {
                messageHelper.Error(sMessage);
                return false;
            }

            //Pass all steps
            return true;
        }

        private void InitControls()
        {
            //Input/output
            var typeList = Enum.GetValues(typeof(_TextType));
            InitLookupEdit(InputLookUpEdit);
            InputLookUpEdit.Properties.DataSource = typeList;
            InputLookUpEdit.Properties.DropDownRows = typeList.Length; //Limit rows
            InputLookUpEdit.EditValue = csConfigureHelper.Config.InputType;
            InputLookUpEdit.EditValueChanged += InputLookUpEdit_EditValueChanged;



            InitLookupEdit(OutputLookUpEdit);
            OutputLookUpEdit.Properties.DataSource = typeList;
            OutputLookUpEdit.Properties.DropDownRows = typeList.Length; //Limit rows
            OutputLookUpEdit.EditValue = csConfigureHelper.Config.OutputType;
            OutputLookUpEdit.EditValueChanged += OutputLookUpEdit_EditValueChanged;

            InitLookupEdit(EncryptionListLookUpEdit);
            var itemList = csConfigureHelper.Config.Encryptions.Select(a => a.Description).ToList();
            EncryptionListLookUpEdit.Properties.DataSource = itemList;
            EncryptionListLookUpEdit.Properties.DropDownRows = itemList.Count(); //Limit rows
            EncryptionListLookUpEdit.EditValue = itemList[0];

        }

        private void OutputLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (OutputLookUpEdit.EditValue is _TextType)
            {
                csConfigureHelper.Config.OutputType = (_TextType)OutputLookUpEdit.EditValue;
            }
        }

        private void InputLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (InputLookUpEdit.EditValue is _TextType)
            {
                csConfigureHelper.Config.InputType = (_TextType)InputLookUpEdit.EditValue;
                if (csConfigureHelper.Config.InputType == _TextType.FileStream)
                {
                    UpdateFileStreamMode(true);
                }
                else
                {
                    UpdateFileStreamMode(false);
                }
            }
        }

        private void UpdateFileStreamMode(bool isFileStream)
        {
            if (isFileStream)
            {
                InputMemoEdit.ReadOnly = true;
            }
            else
            {
                InputMemoEdit.ReadOnly = false;
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
            if (csConfigureHelper.Config.InputType == _TextType.Hex)
            {

            }
            else if (csConfigureHelper.Config.InputType == _TextType.FileStream)
            {
                bData = Encoding.UTF8.GetBytes(sInput);
            }

            var encryption = csConfigureHelper.Config.Encryption;
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
                    string sInput = File.ReadAllText(sPath);
                    InputMemoEdit.Text = sInput;

                    var encryption = csConfigureHelper.Config.Encryption;
                    string sResult = encryption.DecryptFromAesByte(bData);
                    OutputMemoEdit.Text = sResult;
                }
            }
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            FormAesConfig winConfig = new FormAesConfig();
            winConfig.StartPosition = FormStartPosition.CenterParent;
            winConfig.ShowDialog();
        }
    }
}
