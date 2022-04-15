using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonTests
{
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fruit f = new Fruit();
            f.Init();
            string sData = JsonConvert.SerializeObject(f);
        }
    }
}
