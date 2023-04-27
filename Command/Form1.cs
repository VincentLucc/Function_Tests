using _CommonCode_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Command
{
    public partial class Form1 : Form
    {
        public Form1(string[] sCommands)
        {
            InitializeComponent();
            LoadCommand(sCommands);
        }

        private void LoadCommand(string[] sCommand)
        {
            //Notice all command stored in array treated as a string and seperated by " "
            //
            if (sCommand != null && sCommand.Length > 0)
            {
                StringBuilder sBuilder = new StringBuilder();
                foreach (string sCmd in sCommand)
                {
                    sBuilder.AppendLine(sCmd);
                }
                MessageBox.Show(sBuilder.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
