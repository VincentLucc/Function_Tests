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

namespace Socket_Tool.Forms
{
    public partial class FormServerEdit : XtraForm
    {
        public static FormServerEdit Instance;

        public string IPAddress { get; set; }
        public int Port { get; set; }

        public FormServerEdit()
        {
            InitializeComponent();
            InitEvents();
            InitControls();
        }

        private void InitControls()
        {
            sePort.Properties.IsFloatValue = false;
            sePort.Properties.MinValue = 0;
            sePort.Properties.MaxValue = 65535;
        }

        private void InitEvents()
        {
            sePort.ValueChanged += SePort_ValueChanged;
        }

        private void SePort_ValueChanged(object sender, EventArgs e)
        {
            Port = (int)sePort.Value;
        }

        public static DialogResult ShowForm(string sTitle, string ip = null, int port = -1)
        {
            if (Instance == null)
            {
                Instance = new FormServerEdit();
                Instance.StartPosition = FormStartPosition.CenterParent;
            }

            Instance.LoadVariable(sTitle, ip, port);

            return Instance.ShowDialog();
        }

        private void FormServerAdd_Load(object sender, EventArgs e)
        {
            teIP.Text = IPAddress;
            sePort.Value = Port;
        }

        public void LoadVariable(string sTitle, string ip = null, int port = -1)
        {
            if (ip == null)
            {
                IPAddress = "127.0.0.1";
                Port = 0;
            }
            else
            {
                IPAddress = ip;
                Port = port;
            }

            Text = sTitle;
        }


        private void teIP_EditValueChanged(object sender, EventArgs e)
        {
            IPAddress = teIP.Text;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}