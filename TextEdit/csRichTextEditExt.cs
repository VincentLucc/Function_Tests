using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEdit
{
    public class csRichTextEditExt : RichEditControl
    {

        public new HorizontalRulerOptions HorizontalRuler;

        public csRichTextEditExt() 
        {
           //this.Options.HorizontalRuler=new HorizontalRulerOptions();
        }

    }
}
