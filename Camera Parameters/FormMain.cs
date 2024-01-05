using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Camera_Parameters
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {

        public bool isFormLoad;
        public csDevMessage messageHelper;
        public FormMain()
        {
            InitializeComponent();
            this.FormClosed += FormMain_FormClosed;
        }



        private void FormMain_Load(object sender, EventArgs e)
        {
            //Init 
            string sMessage = "";
            messageHelper = new csDevMessage(this);

            if (!csConfigureHelper.LoadOrCreateConfig(out sMessage))
            {
                messageHelper.Info(sMessage);
                this.Close();
                return;
            }


            this.contentPanel.Controls.Clear();
            var calPage = new CalUserControl();
            calPage.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(calPage);


            //Fisnish
            isFormLoad = true;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isFormLoad)
            {
                if (!csConfigureHelper.SaveConfig(out string sMessage))
                {
                    messageHelper.Info(sMessage);
                    return;
                }              
            }
        }
    }
}
