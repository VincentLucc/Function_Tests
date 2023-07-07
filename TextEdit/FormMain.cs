﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEdit
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void bRichEditXML_Click(object sender, EventArgs e)
        {
            var winRichEdit=new RichEditXMLForm();
            winRichEdit.ShowDialog();
        }

        private void TextSelectionSimpleButton1_Click(object sender, EventArgs e)
        {
            var winRichEdit = new RichTextEditTextSelectForm();
            winRichEdit.ShowDialog();
        }
    }
}
