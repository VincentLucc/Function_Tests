using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace _CommonCode_Dev22
{
    internal static class csDevUIHelper
    {
        internal static void SetVisibility(this LayoutControlItem layoutControl, bool bVisible)
        {
            var visibility = bVisible ? LayoutVisibility.Always : LayoutVisibility.Never;
            layoutControl.Visibility = visibility;
        }
    }
}
