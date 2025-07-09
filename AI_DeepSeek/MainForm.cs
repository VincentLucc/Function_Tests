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
using System.Windows.Forms;

namespace AI_DeepSeek
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {

        ChatClient deepSeekClient;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void ConnectBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //Create connection
            var credentail = new ApiKeyCredential("<abc123>");
            var options = new OpenAIClientOptions()
            {
                Endpoint = new Uri("https://api.deepseek.com/v1"),
            };

            deepSeekClient = new ChatClient("MODEL_NAME", credentail, options);



            //Send a request
            ChatCompletion completion = await deepSeekClient.CompleteChatAsync("Say 'this is a test.'");
 
 
        }
    }
}
