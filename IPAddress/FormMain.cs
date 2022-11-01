

using System.Net;

namespace IPAddressHelper
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void bCheck_Click(object sender, EventArgs e)
        {
            if (!csIPHelper.ParseIPv4WithMask(IPAddressMaskTextEdit.Text, out string newAddress, out string newMask))
            {
                return;
            }

            if (!csIPHelper.ParseIPv4WithMask(IPAddressMaskTextEdit.Text, out IPAddress IP, out IPAddress Mask))
            {
                return;
            }
        }

        private void CheckSimpleButon_Click(object sender, EventArgs e)
        {
            if (!IPAddress.TryParse(IPAddressSimpleTextEdit.Text, out IPAddress? newAddress))
            {
                return;
            }

            string sValue= newAddress.ToString();
        }
    }
}