using DevExpress.XtraWizard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizardControl
{
    public partial class FormMain : Form
    {

        public bool PageChangeEnable { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


   




        private void bWizardControlDefault_Click(object sender, EventArgs e)
        {
            FormWizardControlDefault formWizardControl = new FormWizardControlDefault();
            formWizardControl.Show();
        }

        private void bWizardFormDefault_Click(object sender, EventArgs e)
        {
            WizardForm1 wazardForm = new WizardForm1();
            wazardForm.Show();
        }

        private void bWizardControlTracker_Click(object sender, EventArgs e)
        {
            FormWizardTracker wazardTracker = new FormWizardTracker();
            wazardTracker.Show();
        }
    }
}
