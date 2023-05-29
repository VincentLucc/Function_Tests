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
using System.ComponentModel.Design;

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
            ResourceSet resourceValue = resManager.GetResourceSet(culture, createIfNotExists: true, tryParents: true);
            if (resourceValue == null)
            {
                Debug.WriteLine("Resource not found.");
                return;
            }
            foreach (DictionaryEntry entry in resourceValue)
            {
                Debug.WriteLine($"Key:{entry.Key},Value:{entry.Value}");
            }
        }

        private void bCommentRead_Click(object sender, EventArgs e)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            //Get possible resource path
            var paths = assembly.GetManifestResourceNames();
            //Load to stream
            Stream stream = assembly.GetManifestResourceStream("Resources.Properties.ResourceXX.resources");

            ResourceReader reader1 = new ResourceReader(stream);
            var emReader = reader1.GetEnumerator();
            while (emReader.MoveNext())
            {
                var item= emReader.Current;
                var getValue = (ResXDataNode)emReader.Value;
                
            }
   

            //Read stream
            using (ResXResourceReader reader = new ResXResourceReader(stream))
            {
                reader.UseResXDataNodes = true; 

                foreach (System.Collections.DictionaryEntry d in reader)
                {
                    System.Resources.ResXDataNode node = (System.Resources.ResXDataNode)d.Value;
                }

                    var enumerator = reader.GetMetadataEnumerator();
                while (enumerator.MoveNext())
                {
                    ResXDataNode node = (ResXDataNode)enumerator.Value;
                    Debug.WriteLine($"Name:{node.Name},{node.GetValue((ITypeResolutionService)null)},Comment:{node.Comment}");
                }
            }

        }
    }
}
