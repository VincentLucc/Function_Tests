using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public class FormReloadBaseManual : Form
    {
        public Size originSize;
        public FormWindowState originState;
        public bool IsFirstLoadComplete;
        /// <summary>
        /// Check whether program is running in desgin mode
        /// </summary>
        public bool isDesignMode;
        public FormReloadBaseManual()
        {
            //Init variables
            isDesignMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            this.StartPosition = FormStartPosition.CenterParent;

            //Init events
            this.Load += FormReload_Load;
            this.VisibleChanged += FormReloadBaseManual_VisibleChanged;
        }

        private void FormReloadBaseManual_VisibleChanged(object sender, EventArgs e)
        {
            //Reload init state
            //Window state must be set when form is visible to be valid
            if (IsFirstLoadComplete && this.Visible)
            {
                WindowState = originState;
                //Must set after state been set
                this.Size = originSize;
                //Works better than FormStartPosition.CenterParent;
                this.CenterToParent();
            }
        }

        private void FormReload_Load(object sender, EventArgs e)
        {
            //Avoid hot load to run this piece of code which could change the source file
            if (isDesignMode) return;

            //Save init state
            //Window state must be set when form is visible to be valid
            if (!IsFirstLoadComplete)
            {
                originSize = this.Size;
                originState = this.WindowState;
                this.StartPosition = FormStartPosition.CenterParent;
            }

            Debug.WriteLine("FormReload_Load");
            IsFirstLoadComplete = true;   
        }
    }
}
