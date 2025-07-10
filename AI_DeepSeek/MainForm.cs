using _CommonCode_Framework;
using OpenAI;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AI_DeepSeek
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {

        csDevMessage messageHelper;

        public MainForm()
        {
            InitializeComponent();
            messageHelper = new csDevMessage(this);
        }

        private void ConnectBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            csDeepSeekHelper.Init();

        }

        private async void RequestBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Send a request
            var response = await csDeepSeekHelper.Request("Say 'this is a test.'", 2000);
            if (response.chatCompletion == null)
            {
                messageHelper.Info(response.sError);
                return;
            }

            "HasResponse".TraceRecord();
        }
    }
}
