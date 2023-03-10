using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EditForm
{
    public partial class ucEditForm : EditFormUserControl
    {
        public ucEditForm()
        {
            InitializeComponent();

            //Set data bind
            SetBoundFieldName(tbName,nameof(Student.Name));
            SetBoundFieldName(toggleSwitch1, nameof(Student.ToggleSwitch));
        }

        private void ucEditForm_Load(object sender, EventArgs e)
        {
            //Get edit row
            
        }
    }
}
