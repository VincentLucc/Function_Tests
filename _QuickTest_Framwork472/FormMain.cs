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

namespace _QuickTest_Framwork472
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void bDateTimeOffset_Click(object sender, EventArgs e)
        {
            DateTimeOffset dtToronto = DateTimeOffset.Now;
            var offset = dtToronto.Offset; // -4 hours
            //var dtBeiJing = new DateTimeOffset(dtToronto.UtcDateTime, new TimeSpan(8, 0, 0));
            //Debug.WriteLine(dtBeiJing.ToString());

            var timeZoneBeijing = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(a => a.DisplayName.ToUpper().Contains("BEIJING"));
            var tzBeijing = TimeZoneInfo.CreateCustomTimeZone("zBeiJing", new TimeSpan(8, 0, 0), "Beijing", "Beijing");
            var converted = TimeZoneInfo.ConvertTime(dtToronto, tzBeijing);


        }
    }
}
