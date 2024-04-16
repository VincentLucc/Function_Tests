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

namespace Logging_22._1
{
    public partial class Form1 : Form
    {
        public csLogHelper logHelper;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            InitVariables();
        }

        private void InitVariables()
        {
            logHelper = new csLogHelper(this);
            logHelper.Start().Wait();

            csDebugListener debugListener = new csDebugListener(logHelper);
            Debug.Listeners.Add(debugListener);
        }

        private void CreateDebugtButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Debug message");
            Trace.WriteLine("Trace message");
        }

        private void createLogButton_Click(object sender, EventArgs e)
        {
            logHelper.AddLogMessage("Test01");
        }


    }
}
