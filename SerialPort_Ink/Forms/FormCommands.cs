using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPort_Ink
{
    public partial class FormCommands : DevExpress.XtraEditors.XtraForm
    {
        BindingList<CommandInfo> Commands;
        public FormCommands(BindingList<CommandInfo> commands)
        {
            InitializeComponent();
            Commands = commands;
            InitEvents();
        }

        private void InitEvents()
        {
            this.FormClosed += FormCommands_FormClosed;
            gridView1.KeyDown += GridView1_KeyDown;
        }

        private void GridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
 
            if (e.KeyCode == Keys.Delete)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
        }

        private void FormCommands_FormClosed(object sender, FormClosedEventArgs e)
        {
            Commands = null;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCommands_Load(object sender, EventArgs e)
        {
            csUIHelper.InitGridview(gridView1, true, true);
            gridControl1.DataSource = Commands;
        }
    }
}