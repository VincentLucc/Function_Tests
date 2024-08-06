using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextModifier
{
    /// <summary>
    /// Allow to load large than 1G file
    /// </summary>
    public partial class LargeTextUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public List<string> Lines = new List<string>();

        public LargeTextUserControl()
        {
            InitializeComponent();
            this.Load += RichEditLargeUserControl_Load;
        }



        private void RichEditLargeUserControl_Load(object sender, EventArgs e)
        {

        }

        public string LoadFile(byte[] bData)
        {
            //Init 
            long lTotal;
            long lPre = 0;
            Stopwatch watch = Stopwatch.StartNew();

            //Read to list
            Lines.Clear();
            using (MemoryStream stream = new MemoryStream(bData))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string sLine = null;
                    while ((sLine = reader.ReadLine()) != null)
                    {
                        Lines.Add(sLine);
                    }
                }
            }

            //Show time spending
            lTotal = watch.ElapsedMilliseconds;
            Trace.WriteLine($"Large Text Control.Process lines:{lTotal - lPre}ms/{lTotal}ms");
            lPre = lTotal;

            //Load to doc
            LoadDisplay();

            //Show time spending
           lTotal = watch.ElapsedMilliseconds;
            Trace.WriteLine($"Large Text Control.LoadDisplay:{lTotal - lPre}ms/{lTotal}ms");
            lPre = lTotal;

        
            //No error
            return null;
        }

        private void LoadDisplay()
        {
            int iHeight = memoEdit1.Height;
            int iVisibleLines = iHeight / 5;
            Trace.WriteLine($"Height:{iHeight}, Line Visible:{iVisibleLines}, Line All:{Lines.Count}");

            //Get visible area
            string sABC = string.Empty;
            int iDataCount = iVisibleLines < Lines.Count ? iVisibleLines : Lines.Count;
            string sVisibleText = string.Join("\r\n", Lines.GetRange(0, iDataCount));

            //Show 
            memoEdit1.Text = sVisibleText;
        }
    }
}
