using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridControl_19_1
{
    public partial class ucEditForm : EditFormUserControl
    {
        public ucEditForm()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            SetBound();
        }

        private void SetBound()
        {
            //Bind age
            SetBoundFieldName(teAge, nameof(Student.Age));
            SetBoundPropertyName(teAge, nameof(TextBox.Text));

            //Bind enable
            SetBoundFieldName(tsEnable, nameof(Student.Enable));
            SetBoundPropertyName(tsEnable, nameof(tsEnable.IsOn));

 
        }
    }
}
