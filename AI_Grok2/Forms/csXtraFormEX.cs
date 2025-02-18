using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Grok2
{
    internal class csXtraFormEX : XtraForm
    {
        public bool IsFormLoad;
        public csDevMessage MessageHelper;

        public csXtraFormEX()
        {
            MessageHelper = new csDevMessage(this);
        }
    }
}
