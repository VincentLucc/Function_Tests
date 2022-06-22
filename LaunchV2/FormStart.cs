using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchV2
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
            this.Shown += FormStart_Shown;
            this.Load += FormStart_Load;
            this.FormClosed += FormStart_FormClosed;
        }

        private void FormStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (true)
            {

            }
        }

        /// <summary>
        /// Better to use none-async method to avoid possible issue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormStart_Load(object sender, EventArgs e)
        {
            MainForm winMain = new MainForm(); //Show notify icon

            Task tPreLoad = Task.Run(()=>winMain.PreLoadProcess());
            tPreLoad.Wait();
            

            winMain.ShowDialog();
        }

        private void FormStart_Shown(object sender, EventArgs e)
        {
            Hide();
        }

    }
}
