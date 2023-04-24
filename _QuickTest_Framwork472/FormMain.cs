using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _QuickTest_Framwork472
{
    public partial class FormMain : Form
    {
        private object thread;

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

        private async void bThreadGapTest_Click(object sender, EventArgs e)
        {
            Stopwatch watchMain = new Stopwatch();
            Stopwatch watchStep = new Stopwatch();
            Queue<long> gapList = new Queue<long>();
            long First = -1;
            int iTest = int.Parse(tbGapInput.Text);
            await Task.Run(() =>
            {

                watchMain.Start();
                while (watchMain.ElapsedMilliseconds < 2000)
                {
                    watchStep.Restart();
                    Thread.Sleep(iTest);
                    while (gapList.Count > 100) gapList.Dequeue();
                    watchStep.Stop();
                    if (First == -1) First = watchStep.ElapsedTicks;
                    gapList.Enqueue(watchStep.ElapsedTicks);
                }

            });

            Debug.WriteLine(First / 10000f);

            Debug.WriteLine(gapList.Average() / 10000f);
            MessageBox.Show($"First:{First / 10000f}\r\nAve:{gapList.Average() / 10000f}");
        }

        private void bQUickStringTest_Click(object sender, EventArgs e)
        {
            string sText = richTextBox1.Text;
            var sLines = sText.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var splitResult = Regex.Split(sText, "(\r\n)|\r|\n");

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            long x1 = 100;
            ulong y = 50;
            y = y + (ulong)x1;
            x1 = -10;
            ulong x2 = (ulong)x1;
            y =y + x2;
            
        }
    }
}
