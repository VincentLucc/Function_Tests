using DevExpress.XtraRichEdit.API.Layout;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEdit
{
    public class csLayoutVisitor : LayoutVisitor
    {

        Document document;

        public int RowIndex { get; private set; }

        public csLayoutVisitor(Document doc)
        {
            this.document = doc;
            RowIndex = 0;
        }

        protected override void VisitRow(LayoutRow row)
        {
            RowIndex++;
            base.VisitRow(row);
        }
    }
}
