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

        private void Form1_Load(object sender, EventArgs e)
        {

             uIForm = new UIForm();

            //await Task.Delay(5000);
            //uIForm.ShowInfoDialog("Test");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            uIForm.ShowInfoDialog("Test");
        }

        private async void uiButton1_Click(object sender, EventArgs e)
        {
            FormLoading loading = new FormLoading();
            loading.TransparencyKey = Color.DarkBlue; //Make back ground transparent
            loading.BackColor = Color.DarkBlue;//Pick a color not been used
            loading.Owner = this;
            loading.StartPosition = FormStartPosition.Manual; //Enable manual set
            var pParent=this.PointToScreen(new Point(this.Width/2,this.Height/2)); //Get center position
            loading.Location = new Point(pParent.X - loading.Width / 2, pParent.Y - loading.Height / 2);
            loading.Show();          
            await Task.Delay(2000);
            loading.Close();
        }
    }
}
