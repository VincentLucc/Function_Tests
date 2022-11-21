using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraDalsa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            int iServerCount = SapManager.GetServerCount();
            string sName = SapManager.GetServerName(iServerCount - 1);
            int iDevice= SapManager.GetResourceCount(0,SapManager.ResourceType.AcqDevice);
        }
    }
}
