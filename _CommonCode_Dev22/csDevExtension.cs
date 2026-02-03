using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CommonCode_Dev22
{
    public static class csDevExtension
    {
        public static void ForceVisible(this GridView gridView, int iSourceIndex)
        {
            if (iSourceIndex < 0) return;
            if (!(gridView.GetViewInfo() is GridViewInfo viewInfo)) return;

            //Get info
            int iTotalVisible = viewInfo.RowsInfo.Count;
            int iTopRowIndex = gridView.TopRowIndex;
            int iEndRowIndex = iTopRowIndex + iTotalVisible-1;
            if (gridView.OptionsView.ShowColumnHeaders) iEndRowIndex -= 1;
  
            
            //Item is visible
            if (iSourceIndex >= iTopRowIndex && iSourceIndex <= iEndRowIndex) return;
            //Item out of range
            if (iSourceIndex >= gridView.RowCount) return;
            //Set
            gridView.TopRowIndex = iSourceIndex;
        }
    }
}
