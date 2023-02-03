using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLoad
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            InitControls();

            this.Load += FormMain_Load1;
        }


        /// <summary>
        /// Event will tigger twice if put in here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load1(object sender, EventArgs e)
        {
            ApplyControls();
        }

        private void InitControls()
        {

        }

        private void ApplyControls()
        {
            
        }

        private void bFormEvent_Click(object sender, EventArgs e)
        {
            csUIHelper.ShowEventForm();
        }


        private void bReload_Click(object sender, EventArgs e)
        {
            csUIHelper.ShowManualReload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            csUIHelper.ShowAutoReload();
        }
    }
}
