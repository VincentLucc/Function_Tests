using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test001
{
    public partial class FormMapping : Form
    {
        public FormMapping()
        {
            InitializeComponent();
        }

        private void FormMapping_Load(object sender, EventArgs e)
        {
            MappingGridControl.DataSource = csPublic.winMain.ColumnDefinition;
        }

        private void FormMapping_FormClosing(object sender, FormClosingEventArgs e)
        {
            csPublic.winMapping = null;
        }
    }
}
