using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Native;
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

namespace TextEdit
{
    public partial class RichTextEditTextSelectForm : DevExpress.XtraEditors.XtraForm
    {
        public RichTextEditTextSelectForm()
        {
            InitializeComponent();
        }

        private void RichTextEditTextSelectForm_Load(object sender, EventArgs e)
        {

            string sTest = "CompositionDiagramControl_MouseDown\r\nThe thread 0x6e64 has exited with code 0 (0x0).\r\nThe thread 0x796c has exited with code 0 (0x0).\r\nThe thread 0x60e0 has exited with code 0 (0x0).\r\nThe thread 0x36b4 has exited with code 0 (0x0).\r\nThe thread 0xa58 has exited with code 0 (0x0).\r\nThe thread 0x2958 has exited with code 0 (0x0).\r\nThe thread 0x12ec has exited with code 0 (0x0).\r\nThe thread 0x73e4 has exited with code 0 (0x0).\r\nThe program '[32472] DeltaX_Tracker.exe' has exited with code -1 (0xffffffff).";
            var bTest = Encoding.UTF8.GetBytes(sTest);
            richEditControl1.LoadDocument(bTest);
            richEditControl1.ReadOnly = false;
     
            //Draft mode no dent
            richEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            //Set width
         

            richEditControl1.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Visible;
            richEditControl1.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Visible;

            richEditControl1.SelectionChanged += RichEditControl1_SelectionChanged;

            richEditControl1.CustomDrawActiveView += RichEditControl1_CustomDrawActiveView;

            FileLoadButtonEdit.Click += FileLoadButtonEdit_Click;




        }


        private void RichEditControl1_CustomDrawActiveView(object sender, DevExpress.XtraRichEdit.RichEditViewCustomDrawEventArgs e)
        {
            //var pStart = richEditControl1.Document.get
            //var pEnd = richEditControl1.GetPositionFromCharIndex(10);
            //var rect = new Rectangle(pStart.X, pStart.Y, pEnd.X - pStart.X, pStart.Y + 10);
            //var rect = new Rectangle(0, 0, 1000, 1000);
            //e.Cache.DrawRectangle(pen, rect);

            var posStart = richEditControl1.Document.CreatePosition(0);
            var posEnd = richEditControl1.Document.CreatePosition(9 + 1);
            var boundryStart = richEditControl1.GetLayoutPhysicalBoundsFromPosition(posStart);
            var boundryEnd = richEditControl1.GetLayoutPhysicalBoundsFromPosition(posEnd);
            int iXStart = boundryStart.X;
            int iYStart = boundryStart.Y;
            int iWidth = Math.Abs(boundryEnd.X - boundryStart.X);
            int iHeight = 1000;
            var rect = new Rectangle(iXStart, iYStart, iWidth, iHeight);
            var color = Color.FromArgb(32, Color.Red);//Set to transparent color
            e.Cache.FillRectangle(color, rect);


            var posStart1 = richEditControl1.Document.CreatePosition(10);
            var posEnd1 = richEditControl1.Document.CreatePosition(19 + 1);
            var boundryStart1 = richEditControl1.GetLayoutPhysicalBoundsFromPosition(posStart1);
            var boundryEnd1 = richEditControl1.GetLayoutPhysicalBoundsFromPosition(posEnd1);
            iXStart = boundryStart1.X;
            iYStart = boundryStart1.Y;
            iWidth = Math.Abs(boundryEnd1.X - boundryStart1.X);
            iHeight = 1000;
            rect = new Rectangle(iXStart, iYStart, iWidth, iHeight);
            color = Color.FromArgb(32, Color.Green);//Set to transparent color
            e.Cache.FillRectangle(color, rect);
        }

        private void DrawSelectionRangle(int iStart, int iLength, DevExpress.XtraRichEdit.RichEditViewCustomDrawEventArgs e)
        {
            var posStart = richEditControl1.Document.CreatePosition(iStart);
            var posEnd = richEditControl1.Document.CreatePosition(iStart + iLength);
            var boundryStart = richEditControl1.GetLayoutPhysicalBoundsFromPosition(posStart);
            var boundryEnd = richEditControl1.GetLayoutPhysicalBoundsFromPosition(posEnd);

            richEditControl1.Document.CreatePosition(iStart);

            int iXStart = boundryStart.X;
            int iYStart = boundryStart.Y;
            int iWidth = Math.Abs(boundryEnd.X - boundryStart.X);
            int iHeight = 1000;
            var rect = new Rectangle(iXStart, iYStart, iWidth, iHeight);
            var color = Color.FromArgb(32, Color.Red);//Set to transparent color
            e.Cache.FillRectangle(color, rect);
        }

        private void RichEditControl1_SelectionChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("RichEditControl1_SelectionChanged");
            var selection = richEditControl1.Document.Selection;


        }

        private void FileLoadButtonEdit_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sPath = openFileDialog.FileName;
                    using (FileStream fileStream = File.OpenRead(sPath))
                    {
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            string sLine = "";
                            int iLimit = 20;
                            int iIndex = 0;
                            StringBuilder builder=new StringBuilder();
                            while ((sLine = reader.ReadLine()) != null)
                            {
                                builder.AppendLine(sLine);
                                iIndex++;
                                if (iIndex > iLimit) break;
                            }
                            var bTest = Encoding.UTF8.GetBytes(builder.ToString());
                            richEditControl1.LoadDocument(bTest);
                        }
                    }
                }
            }
        }

        private void FileLoadButtonEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}