using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;

namespace _CommonCode_Dev22
{
    public class XtraFormEx : XtraForm
    {
        public csDevMessage messageHelper;
        private bool IsFormLoad;

        public bool UIExit => this == null || this.Disposing || this.IsDisposed;
        public XtraFormEx()
        {
            messageHelper = new csDevMessage(this);
        }
    }


}
