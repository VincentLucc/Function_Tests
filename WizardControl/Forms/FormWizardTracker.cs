using DevExpress.XtraEditors;
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
    public partial class FormWizardTracker : DevExpress.XtraEditors.XtraForm
    {

        bool PageChangeEnable { get; set; }
        csDevMessage messageHelper { get; set; }

        public FormWizardTracker()
        {
            InitializeComponent();
            this.Load += FormWizardTracker_Load;
        }

        private void FormWizardTracker_Load(object sender, EventArgs e)
        {
            messageHelper = new csDevMessage(this);
            wizardControl1.ShowBackButton = false;//hide back button, keep it on design page
            welcomeWizardPage1.PageInit += WelcomeWizardPage1_PageInit;
            wizardControl1.SelectedPageChanging += WizardControl1_SelectedPageChanging;
        }

        private void WelcomeWizardPage1_PageInit(object sender, EventArgs e)
        {
            messageHelper.Info("Welcome Page Init.");
        }

        private async void WizardControl1_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            //Check if already checked
            if (PageChangeEnable)
            {
                PageChangeEnable = false;//Trigger only once
                return;
            }

            e.Cancel = true;//Disable auto change, do it before await operations

            //Check target page
            if (e.Page == completionWizardPage1)
            {
                messageHelper.ShowMainLoading();
                await Task.Delay(2000);
                messageHelper.CloseLoadingForm();
                PageChangeEnable = true;
                wizardControl1.SelectedPage = e.Page;
            }
            else
            { //Directly allow change if not specified
                PageChangeEnable = true;
                wizardControl1.SelectedPage = e.Page;
            }

        }
    }
}