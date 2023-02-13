using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.API.Native;
using System.Diagnostics;
using DevExpress.Office.Utils;
using System.CodeDom.Compiler;
using DevExpress.CodeParser;
using DevExpress.XtraRichEdit.Services;
using System.Threading;
using System.Collections.Concurrent;
using DevExpress.XtraRichEdit.API.Layout;

namespace TextEdit
{
    public partial class RichEditXMLForm : Form
    {
        public bool bAutoAppend;

        public ConcurrentQueue<string> TextBuffer = new ConcurrentQueue<string>();
        public Stopwatch timerWatch = new Stopwatch();
        public string TimeString => DateTime.Now.ToString("HH':'mm':'ss':'fff");

        public int DocumentLineCount = 0;

        public bool UIExit => this.IsDisposed || this.Disposing || !this.Visible;

        public RichEditXMLForm()
        {
            InitializeComponent();
            InitEvents();
            InitControls();
            InitOperation();
        }

        private void InitOperation()
        {
            timer1.Start();
        }

        private void InitControls()
        {
            // Use service substitution to register a custom service that implements syntax highlighting.
            //var syntaxHighLighter = new csSyntaxHighLightService(richEditControl1);
            //syntaxHighLighter.ForceLanguageType = ParserLanguageID.Xml;

            //richEditControl1.ReplaceService<ISyntaxHighlightService>(syntaxHighLighter);
            //Simple or draft mode will Hide borders, pages will also been disabled
            richEditControl1.ActiveViewType = RichEditViewType.Simple;
            richEditControl1.ActiveView.AllowDisplayLineNumbers = true;
            //Allow number to be visible in simple mode or draft mode
            richEditControl1.Views.SimpleView.Padding = new DevExpress.Portable.PortablePadding(60, 20, 20, 20);
            richEditControl1.Views.SimpleView.WordWrap = false;
            //Hide ruler
            richEditControl1.Options.HorizontalRuler.Visibility = RichEditRulerVisibility.Hidden;
            richEditControl1.Options.VerticalRuler.Visibility = RichEditRulerVisibility.Hidden;
          

        }

        private void InitEvents()
        {
            richEditControl1.InitializeDocument += RichEditControl1_InitializeDocument;
            richEditControl1.DocumentLayout.DocumentFormatted += DocumentLayout_DocumentFormatted;
        }

        private void DocumentLayout_DocumentFormatted(object sender, EventArgs e)
        {
            csLayoutVisitor visitor = new csLayoutVisitor(richEditControl1.Document);
            int pageCount = richEditControl1.DocumentLayout.GetFormattedPageCount();

            for (int i = 0; i < pageCount; i++)
            {
                visitor.Visit(richEditControl1.DocumentLayout.GetPage(i));
            }

            DocumentLineCount = visitor.RowIndex;
        }

        private void RichEditControl1_InitializeDocument(object sender, EventArgs e)
        {
            //This only count 999
            Document document = richEditControl1.Document;
            document.BeginUpdate();
            try
            {
                document.DefaultCharacterProperties.FontSize = 10;
                //Add line indicator
                document.Sections[0].LineNumbering.CountBy = 1;
                //Set count from start to end (Default: retsart per page)
                document.Sections[0].LineNumbering.RestartType = LineNumberingRestart.Continuous;
                //Move section up , was 2-300
                document.Sections[0].Margins.Top = 20;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("RichEditXMLForm.RichEditControl1_InitializeDocument:\r\n" + ex.Message);
            }
            document.EndUpdate();
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sFile = ofd.FileName;
                richEditControl1.LoadDocument(sFile, DocumentFormat.PlainText);
            }
        }

        private void bInsert_Click(object sender, EventArgs e)
        {
            //Get input
            string sInput = teInput.Text;
            if (string.IsNullOrEmpty(sInput)) return;
        }

        private void bApend_Click(object sender, EventArgs e)
        {
            //Get input
            string sInput = teInput.Text;
            if (string.IsNullOrEmpty(sInput)) return;


            Document doc = richEditControl1.Document;
            doc.BeginUpdate();
            doc.AppendText(sInput);
            doc.EndUpdate();

        }

        private void RunAddTextTask()
        {
            //Thread.Sleep is affected by the UI thread
            int iLineCount = 0;
            //Use task a gap is detected
            Task.Run(() =>
            {
                while (bAutoAppend && !UIExit)
                {
                    string sTime = DateTime.Now.ToString("HH':'mm':'ss':'fff");
                    string sCount = (iLineCount + 1).ToString("d5");
                    iLineCount++;
                    string sInput = teInput.Text;
                    byte[] bData = new byte[250];
                    for (int i = 0; i < 250; i++)
                    {
                        bData[i] = (byte)i;
                    }
                    string sData = Convert.ToBase64String(bData);
                    string sRecord = $"{sTime} {sCount} {sInput} {sData}\r\n";
                    TextBuffer.Enqueue(sRecord);
                    Thread.Sleep(10);
                }
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var t1 = (System.Windows.Forms.Timer)sender;
            t1.Enabled = false;
            timerWatch.Restart();
            if (UIExit) return;

            try
            {
                //Update document
                if (TextBuffer.Count > 0)
                {
                    Document doc = richEditControl1.Document;
                    richEditControl1.BeginUpdate();
                    while (TextBuffer.Count > 0)
                    {
                        if (TextBuffer.TryDequeue(out string sValue)) doc.AppendText(sValue);
                    }

                    //Limit document length
                    if (DocumentLineCount > 2000)
                    {
                        var delCOunt = doc.Range.Length / 10;
                        var delRange = doc.CreateRange(0, delCOunt);
                        //doc.Delete(delRange);
                        doc.Replace(delRange, "");
                    }

                    doc.CaretPosition = doc.Range.End; //Move caret to the end
                    richEditControl1.ScrollToCaret();  //Set scroll position
                    richEditControl1.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"timer1_Tick:\r\n{ex.Message}");
            }


            //Finish up
            timerWatch.Stop();
            Debug.WriteLine($"{TimeString}:TimerComplete:{timerWatch.ElapsedMilliseconds},Current Lines:{DocumentLineCount}");
            t1.Enabled = true;
        }


        private void tsAutoText_Toggled(object sender, EventArgs e)
        {
            if (tsAutoText.IsOn)
            {
                bAutoAppend = true;
                RunAddTextTask();
            }
            else bAutoAppend = false;

        }
    }
}
