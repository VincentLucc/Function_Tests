using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLoad
{
    /// <summary>
    /// Parent form to allow reload
    /// </summary>
    public class FormReloadBase : Form
    {
        public Size originSize;
        public FormWindowState originState;
        public bool IsFirstLoadComplete;
        public FormReloadBase()
        {
            //Init variables
            originSize = this.Size;
            originState = this.WindowState;

            //Init controls
            this.StartPosition = FormStartPosition.CenterParent;

            //Init events
            this.Load += FormReload_Load;
            this.VisibleChanged += FormReloadBase_VisibleChanged;
        }

        private void FormReloadBase_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            WindowState = originState;
            //Must set after state been set
            this.Size = originSize;
            //Works better than FormStartPosition.CenterParent;
            this.CenterToParent();
        }

        private void FormReload_Load(object sender, EventArgs e)
        {
            IsFirstLoadComplete = true;   
        }


    }
}
