using DevExpress.XtraBars.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dev_Theme
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Form1()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            accordionControl1.CustomDrawElement += AccordionControl1_CustomDrawElement;
        }

        private void AccordionControl1_CustomDrawElement(object sender, DevExpress.XtraBars.Navigation.CustomDrawElementEventArgs e)
        {
           
        }

        private void accordionControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
