using DevExpress.ClipboardSource.SpreadsheetML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PathEdit_2201
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Whwen the scope is process, it can be set dynamically
        /// </summary>
        EnvironmentVariableTarget environmentScope = EnvironmentVariableTarget.Machine;
        csDevMessage messageHelper;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Init common variables
            messageHelper = new csDevMessage(this);

            //Init scope
            var scopeOptions = Enum.GetValues(typeof(EnvironmentVariableTarget));
            ScopeLookUpEdit.Properties.DataSource = scopeOptions;
            ScopeLookUpEdit.Properties.DropDownRows = scopeOptions.Length;
            ScopeLookUpEdit.Properties.ShowFooter = false;
            ScopeLookUpEdit.EditValue = environmentScope;
            ScopeLookUpEdit.EditValueChanged += ScopeLookUpEdit_EditValueChanged;
        }

        private void ScopeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ScopeLookUpEdit.EditValue is EnvironmentVariableTarget)
            {
                environmentScope = (EnvironmentVariableTarget)ScopeLookUpEdit.EditValue;
            }
        }

        private void GetEnvironmentPathButton_Click(object sender, EventArgs e)
        {
            LoadFilePath();
        }

        private void LoadFilePath()
        {
            string sPathValue = Environment.GetEnvironmentVariable("path", environmentScope);
            var data = sPathValue.Split(new string[] { ";" }, StringSplitOptions.None).ToList();
            gridControl1.DataSource = data;
        }

        private void AddBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Check input
            if (string.IsNullOrWhiteSpace(NewVariableMemoEdit.Text))
            {
                messageHelper.Info("Input is empty.");
                return;
            }

            //Check existance
            if (!Directory.Exists(NewVariableMemoEdit.Text))
            {
                messageHelper.Info("Variable path doesn't exist.");
                return;
            }

            LoadFilePath();

            var pathList = gridControl1.DataSource as List<string>;
            pathList.Add(NewVariableMemoEdit.Text);
            Environment.SetEnvironmentVariable("path",string.Join(";", pathList), environmentScope);
            messageHelper.Info($"Added {environmentScope} variable.\r\n{NewVariableMemoEdit.Text}");
        }

        private void RemoveButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadFilePath();
        }

        private void ReloadVariablesButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadFilePath();
        }
    }
}
