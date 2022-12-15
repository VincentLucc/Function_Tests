using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridControl_22_1
{
    public partial class ucEditForm : DevExpress.XtraEditors.XtraUserControl
    {
        public ucEditForm()
        {
            InitializeComponent();

            InitEvnets();
        }

        private void InitEvnets()
        {
            this.Load += UcEditForm_Load;
            this.VisibleChanged += UcEditForm_VisibleChanged;
            this.ParentChanged += UcEditForm_ParentChanged;
            this.Disposed += UcEditForm_Disposed;
        }

        /// <summary>
        /// Happens when parent form closed (The Form with gridcontrol)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcEditForm_Disposed(object sender, EventArgs e)
        {
            Debug.WriteLine("UcEditForm_Disposed:" + this.IsDisposed);
        }


        /// <summary>
        /// Trigger only once
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcEditForm_ParentChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("UcEditForm_ParentChanged:" + this.Parent);
        }

        /// <summary>
        /// Trigger 3 times when open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcEditForm_VisibleChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("UcEditForm_VisibleChanged:" + this.Visible);
        }


        /// <summary>
        /// Trigger only once
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcEditForm_Load(object sender, EventArgs e)
        { 
            Debug.WriteLine("UcEditForm_Load:"+this.Visible);
        }
    }
}
