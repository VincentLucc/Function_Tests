using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Docking
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bDockManager1_Click(object sender, EventArgs e)
        {
            DockManagerDocking winDoc = new DockManagerDocking();
            winDoc.Show();
        }

        private void bDockPanel_Click(object sender, EventArgs e)
        {
            FormDockPanel winDoc = new FormDockPanel();
            winDoc.Show();
        }

        private void bDocumentWidget_Click(object sender, EventArgs e)
        {
            DocumentManagerWidgetViewForm winDoc = new DocumentManagerWidgetViewForm();
            winDoc.Show();
        }
    }
}
