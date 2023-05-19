using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace ToolBarForm
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {    
            //Init dropdown button
            bPopup.ButtonStyle = BarButtonStyle.DropDown;
            bPopup.DropDownControl = popupMenu1;
            //Whole area can be clicked
            bPopup.ActAsDropDown = true; 
        }
    }
}
