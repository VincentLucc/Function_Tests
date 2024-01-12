using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace DevMessage
{
    class csPublic
    {
        public static FormMain formMain;

        public static string timeString => DateTime.Now.ToString("HH:mm:ss.fff");
    }

    public class UIHelper
    {
        /// <summary>
        /// Some cases the SplashScreenManager.ShowDefaultWaitForm() won't show message, use this wrapper to show message instead 
        /// </summary>
        /// <param name="sMessage"></param>
        public static void ShowMainLoading(string sMessage, string sCaptain = "Loading...")
        {
            var ParentForm = csPublic.formMain;
            //Null or "" will be replaced to "loading", use " " instead if bottom line not needed.
            SplashScreenManager.ShowDefaultWaitForm(ParentForm, true, false, sCaptain, sMessage);
        }

        public static void ShowMainLoading()
        {
            var ParentForm = csPublic.formMain;
            //Null or "" will be replaced to "loading", use " " instead if bottom line not needed.
            SplashScreenManager.ShowDefaultWaitForm(ParentForm, true, false, "Loading...", "Please wait.");
        }

        public static void CloseLoadingForm()
        {
            SplashScreenManager.CloseForm(false);
        }

        public static void ShowInfo(string text, string caption)
        {
            XtraMessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowInfo2(string text, string caption)
        {
            XtraMessageBox.Show(csPublic.formMain, text, caption,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void InitGridview(GridView View, bool EnableEdit = false, bool ShowNewRow = false)
        {
            //Basic settings
            View.OptionsView.ShowGroupPanel = false; //User don't see group panel
            View.OptionsView.ShowIndicator = false; //Hide row header
            View.OptionsCustomization.AllowSort = false;//Disable sort
            View.OptionsCustomization.AllowFilter = false;//distable filter
            View.OptionsCustomization.AllowQuickHideColumns = false;//User can't drag and hide the column
            View.OptionsBehavior.AlignGroupSummaryInGroupRow = DefaultBoolean.True;//Display the summary in column lane         
            View.OptionsDetail.EnableMasterViewMode = false; //Disable group
            View.OptionsMenu.EnableColumnMenu = false; //Hide column menu

            //Editable
            //Disable edit(Notice: All editors in grid will be affected include Buttons, ComboBox)
            //To set editable for seperate items, enable edit first, then disable edit in specific column
            //nameColumn.OptionsColumn.AllowEdit = false;
            View.OptionsBehavior.Editable = EnableEdit;

            //New row
            if (ShowNewRow)
            {
                View.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                View.OptionsView.ShowIndicator = true; //User can distinguish new row
            }
            else
            {
                View.OptionsView.NewItemRowPosition = NewItemRowPosition.None; //Hide new function row
                View.OptionsView.ShowIndicator = false; //Hide row header
            }
        }
    }
}
