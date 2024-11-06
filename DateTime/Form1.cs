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

namespace DateTimeProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bTimeGap_Click(object sender, EventArgs e)
        {
            //Date time now ticks is not accurate!!!!
            //08:51:51:088:Ticks: 638134303110961384
            //08:51:51:096:Ticks: 638134303110961384
            //08:51:51:096:Ticks: 638134303110961384
            //08:51:51:096:Ticks: 638134303110961384

            List<string> sList = new List<string>();

            for (int i = 0; i < 1000; i++)
            {
                string sTime = DateTime.Now.ToString(csTimeFormat.Debug);
                string sTimeTick = DateTime.Now.Ticks.ToString();
                sList.Add(sTime + ":Ticks:" + sTimeTick);
            }

            foreach (var item in sList)
            {
                Debug.WriteLine(item);
            }
        }

        private void TimeTicksButton_Click(object sender, EventArgs e)
        {
            //Show min and max time range
            long lValueMin = DateTime.MinValue.Ticks;
            long lValueMax = DateTime.MaxValue.Ticks;
            DateTime dTimeMin = new DateTime(lValueMin);
            DateTime dTimeMax = new DateTime(lValueMax);
            Trace.WriteLine($"Min:{dTimeMin}, Max:{dTimeMax}");
        }

        private void TimeOperationButton_Click(object sender, EventArgs e)
        {
            var timeSpan= DateTime.Now- DateTime.Now.AddHours(1);
            var timeLeft=timeSpan.TotalSeconds;
        }
    }
}
