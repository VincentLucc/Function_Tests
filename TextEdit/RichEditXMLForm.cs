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

namespace TextEdit
{
    public partial class RichEditXMLForm : Form
    {
        public RichEditXMLForm()
        {
            InitializeComponent();
            InitEvents();
            InitControls();
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
            //Disable edit
            richEditControl1.ReadOnly = true;

        }

        private void InitEvents()
        {
            richEditControl1.InitializeDocument += RichEditControl1_InitializeDocument;
        }

        private void RichEditControl1_InitializeDocument(object sender, EventArgs e)
        {
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
    }
}
