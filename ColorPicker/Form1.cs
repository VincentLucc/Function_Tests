﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void colorEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var value = colorEdit1.EditValue;
            var vType = value.GetType();
        }

        private void colorPickEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //Get the color value
            var color = colorPickEdit1.Color;
            Debug.WriteLine($"Color Changed:");
        }
    }
}
