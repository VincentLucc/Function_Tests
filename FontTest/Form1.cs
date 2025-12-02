using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Office;
using DevExpress.XtraRichEdit;

namespace FontTest
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Cascadia Code
        /// Cascadia Mono
        /// </summary>
        private string FontName = "Cascadia Mono";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richEditControl1.ActiveViewType = RichEditViewType.Simple;
            richEditControl1.ActiveView.AllowDisplayLineNumbers = true;
            //richEditControl1.LoadDocument(csFontHelper.DemoText);
            richEditControl1.Document.Text = csFontHelper.DemoText;

            memoEdit1.Text = csFontHelper.DemoText;
        }

        private void LoadFontSimpleButton_Click(object sender, EventArgs e)
        {
            //string sFilePath = $"{Application.StartupPath}\\fonts\\consola.ttf";
            //var newFont = csFontHelper.LoadFont(sFilePath, out string sMessage);
            //if (newFont == null)
            //{
            //    MessageBox.Show(sMessage);
            //    return;
            //}

            //UI控件绘制字体，不是文档字体
            var newFont = new Font(new FontFamily(FontName), 8, FontStyle.Regular);
            richEditControl1.Appearance.Text.Font = newFont;
            //richEditControl1.Appearance.Text.Options.UseFont = true;

            //真正的文档字体
            //richEditControl1.Document.DefaultCharacterProperties.
            richEditControl1.Document.DefaultCharacterProperties.FontName = FontName;

            
         
            
            memoEdit1.Font = newFont; 
            
        }
    }
}
