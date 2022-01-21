using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunnyUI
{
    public partial class Form1 : Form
    {

        UIForm uIForm;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

             uIForm = new UIForm();


            await Task.Delay(5000);
            uIForm.ShowInfoDialog("Test");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            uIForm.ShowInfoDialog("Test");
        }
    }
}
