using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.IO;
using System.Reflection;

namespace Resources
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get current assembly
            Assembly assembly = Assembly.GetEntryAssembly();
            string[] sResourceList = assembly.GetManifestResourceNames(); //Get all names
            string sReourceName = "Resources.Properties.ResourceStrings.resources"; //Set current name
            var stream = assembly.GetManifestResourceStream(sReourceName); //Get stream
            ResourceReader rReader = new ResourceReader(stream); //Create reader

            




        }


    }
}
