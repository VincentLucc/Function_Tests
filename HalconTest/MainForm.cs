using HalconDotNet;
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
using _CommonCode_Dev22;

namespace HalconTest
{
    public partial class MainForm : XtraFormEx
    {
        public MainForm()
        {
            InitializeComponent();
        }


   

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void HTuple1Button_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                HTuple test = new HTuple();
                string sValue= "Test" + i.ToString("d6");
                test.Append(sValue);
            }
            watch.Stop();
            Debug.WriteLine("Htuple Direct use:" + watch.ElapsedMilliseconds);
        }

        private void HtupleValueButton_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                string sValue = "Test" + i.ToString("d6");

                HTuple test = new HTuple();
                test.Append(sValue);
      
                HTuple test1=new HTuple();
                test1.Append(test.S);
            }
            watch.Stop();
            Debug.WriteLine("Htuple convert use:" + watch.ElapsedMilliseconds);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
