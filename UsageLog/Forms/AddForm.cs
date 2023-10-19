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
using DevExpress.XtraLayout.Utils;

namespace UsageLog
{
    public partial class AddForm : DevExpress.XtraEditors.XtraForm
    {

        public csRecord Record { get; set; }

        public long ParentID;

        public AddForm(long parentID)
        {
            InitializeComponent();
            ParentID = parentID;
        }


        private void AddForm_Load(object sender, EventArgs e)
        {
            Record = new csRecord();
            Record.ParentID = ParentID;
            Record.RecordType = _recordType.Catagory;

            //Record Type          
            TypeLookUpEdit.Properties.DataSource = Enum.GetValues(typeof(_recordType));
            TypeLookUpEdit.EditValue = Record.RecordType;
            TypeLookUpEdit.EditValueChanged += TypeLookUpEdit_EditValueChanged;

            catagoryTextEdit.Text = Record.Catagory;

            UpdateVisibility();
        }

        private void UpdateVisibility()
        {
            if (Record.RecordType == _recordType.Catagory)
            {
                ValuelayoutControlItem.Visibility = LayoutVisibility.Never;
            }
            else if (Record.RecordType == _recordType.Item)
            {
                ValuelayoutControlItem.Visibility= LayoutVisibility.Always;
            }
          
        }

        private void TypeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
           
            if (TypeLookUpEdit.EditValue is _recordType)
            {
                var recordType = (_recordType)TypeLookUpEdit.EditValue;
                Record.RecordType= recordType;
                UpdateVisibility();
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.OK;
            this.Close();
        }

        private void catagoryTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            Record.Catagory = catagoryTextEdit.Text;
        }
    }
}