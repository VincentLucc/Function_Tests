using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Serialization_48
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void SerializeButton_Click(object sender, EventArgs e)
        {
            var testValue = new Test();
            testValue.IntValue = 1;
            testValue.StrValue = "abc";
            for (int i = 0; i < 3; i++)
            {
                testValue.TagReasons.Add($"Reason_{i + 1}", i + 1);
            }

            string sSerial = csPublic.SerializeObjectIgnoreNull(testValue);
        }
    }
}
