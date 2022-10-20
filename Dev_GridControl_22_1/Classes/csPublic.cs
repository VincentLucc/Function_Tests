using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_GridControl_22_1
{
    class csPublic
    {
        public static void InitGridviewWithDefaultSettings(GridView View, bool EnableEdit = false)
        {
            //Basic settings
            View.OptionsView.ShowGroupPanel = false; //User don't see group panel
            View.OptionsView.ShowIndicator = false; //Hide row header
            View.OptionsCustomization.AllowSort = false;//Disable sort
            View.OptionsCustomization.AllowFilter = false;//distable filter
            View.OptionsCustomization.AllowQuickHideColumns = false;//User can't drag and hide the column
            View.OptionsBehavior.AlignGroupSummaryInGroupRow = DefaultBoolean.True;//Display the summary in column lane         
            View.OptionsDetail.EnableMasterViewMode = false; //Disable group


            //Alignments
            View.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            View.Appearance.Row.TextOptions.HAlignment = HorzAlignment.Center;
            View.Appearance.GroupFooter.TextOptions.HAlignment = HorzAlignment.Center;//Center the display

            //Editable
            View.OptionsBehavior.Editable = EnableEdit; //Disable edit
            View.OptionsView.NewItemRowPosition = EnableEdit ? NewItemRowPosition.Bottom : NewItemRowPosition.None; //Hide new function row
        }
    }
}
