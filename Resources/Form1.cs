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

namespace ResourcesTest
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
            //ResourceReader rReader = new ResourceReader(stream); //Create reader

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //SvgImage svg = SvgImage.FromResources(Properties.Resources.edit11,(this.GetType()).Assembly);

            //SvgImage svg = svgImageCollection["edit11"];
            //simpleButton1.ImageOptions.SvgImage = Properties.Resources.edit11;

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
            assembly = this.GetType().Assembly;
            //Get possible resource path
            var paths = assembly.GetManifestResourceNames();
            //Build resource 为 Resource
            string sPath = "ResourcesTest.g.resources";
            var resInfo = assembly.GetManifestResourceInfo(sPath);

            string sOutput = "";
            //Load to stream
            //C#中则是：项目命名空间.资源文件所在文件夹名.资源文件名 
            using (Stream stream = assembly.GetManifestResourceStream(sPath))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    //Content stream, modify the content if required
                    //Not a pure xml start from something wierld
                    //"���\u0001\0\0\0�\0\0\0lSystem.Resources.ResourceReader, 
                    //mscorlib, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089
                    //# System.Resources.RuntimeResourceSet\u0002\0\0\0\u0001\0\0\0\0\0\0\0PADPADPS���\0\0\0\0�\0\0\04p\0r\0o\0p\0e\0r\0t\0i\0e\0s\0/\0r\0e\0s\0o\0u\0r\0c\0e\0x\0x\0.\0r\0e\0s\0x\0\0\0\0\0!\u0012\u0018\0\0
                    //<? xml version =\"1.0\" encoding=\"utf-8\"?>\r\n
                    sOutput = reader.ReadToEnd();
                    //Grab only xml format
                    sOutput = sOutput.Substring(sOutput.IndexOf("﻿<?xml version"));
                }
            }

            //Fixed stream in XML ｆｏｒｍａｔ
            byte[] byteArray = Encoding.ASCII.GetBytes(sOutput);
            using (MemoryStream modified = new MemoryStream(byteArray))
            {
                using (ResXResourceReader resxReader = new ResXResourceReader(modified))
                {
                    resxReader.UseResXDataNodes = true;
                    IDictionaryEnumerator enumerator = resxReader.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ResXDataNode node = (ResXDataNode)enumerator.Value;
                        Debug.WriteLine($"Name:{node.Name},{node.GetValue((ITypeResolutionService)null)},Comment:{node.Comment}");
                    }
                }

            }

        }

        private void bDirectCall_Click(object sender, EventArgs e)
        {
            string abc = Properties.ResourceStrings.Name100;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames();
            string sTest = Properties.Resources.ResourceStrings;
            // [NameSpace].
            byte[] byteArray = Encoding.ASCII.GetBytes(sTest);
            using (MemoryStream modified = new MemoryStream(byteArray))
            {
                using (ResXResourceReader resxReader = new ResXResourceReader(modified))
                {
                    resxReader.UseResXDataNodes = true;
                    IDictionaryEnumerator enumerator = resxReader.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ResXDataNode node = (ResXDataNode)enumerator.Value;
                        Debug.WriteLine($"Name:{node.Name},{node.GetValue((ITypeResolutionService)null)},Comment:{node.Comment}");
                    }
                }

            }
        }
    }
}
