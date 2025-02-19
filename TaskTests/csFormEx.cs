using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTests
{
    public class csXtraFormEX : XtraForm
    {
        public bool IsFormLoad;
        public csDevMessage MessageHelper;

        public bool UIExit => !this.Visible ||
                    this.IsDisposed ||
                    this.Disposing;

        public csXtraFormEX()
        {
            MessageHelper = new csDevMessage(this);
        }
 
    }
}
