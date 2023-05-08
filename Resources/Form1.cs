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
using DevExpress.Utils.Svg;
using System.Collections;
using System.Diagnostics;
using System.Globalization;

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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //SvgImage svg = SvgImage.FromResources(Properties.Resources.edit11,(this.GetType()).Assembly);

            //SvgImage svg = svgImageCollection["edit11"];
            simpleButton1.ImageOptions.SvgImage = Properties.Resources.edit11;

        }

        private void bResString_Click(object sender, EventArgs e)
        {
            //Read from internal compiled resource
            var resManager = Properties.ResourceStrings.ResourceManager;
            var culture = CultureInfo.InvariantCulture;
            //Must set to true:true
            ResourceSet resourceValue = resManager.GetResourceSet(culture, createIfNotExists:true, tryParents:true);
            if (resourceValue==null)
            {
                Debug.WriteLine("Resource not found.");
                return;
            }
            foreach (DictionaryEntry entry in resourceValue)
            {
                Debug.WriteLine($"Key:{entry.Key},Value:{entry.Value}");
            }


            //Read from a resource file (Extertnal)
            
        }
    }
}
