using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using _CommonCode_Framework;

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
            var testValue = Test.CreateSmple();
 
            string sSerial = csPublic.SerializeObjectIgnoreNull(testValue);
            sSerial.TraceRecord();
        }

        private void SystemJsonSerializeButton_Click(object sender, EventArgs e)
        {
            var testValue = Test.CreateSmple();

            var options = new JsonSerializerOptions
            {
                WriteIndented = false, //Allow format
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull//Ignore null object
            };

            string json = JsonSerializer.Serialize(testValue, options);
            json.TraceRecord();
        }
    }
}
