using DevExpress.Utils;
using DevExpress.Utils.Html.Internal;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraEditors.ViewInfo.CheckedListBoxViewInfo;

namespace ListBox
{
    public partial class DevListBoxManualToolTip : DevExpress.XtraEditors.XtraForm
    {
        public DevListBoxManualToolTip()
        {
            InitializeComponent();
        }

        private void DevListBox_Load(object sender, EventArgs e)
        {
            //Generate list
            List<string> dataList = new List<string>();

            //Trim option
            //Trimming.Default trim by length except "\r\n"
            //Trimming.Character trim by length, include "\r\n"
            //Trimming.EllipsisCharacter trim by length, include "\r\n", add "...", "AABBCCDDEEFF"=>"AABBCC...."
            //Trimming.EllipsisPath trim by length, replace in center include "\r\n", add "...", "AABBCCDDEEFF"=>"AABB...EEFF"
            //Trimming.EllipsisWord trim by length, replace in last include "\r\n", add "...", "AABB CCDD EEFF GGHH IIJJ KKLL MMNN OOPP"=>"AABB CCDD EEFF GGHH IIJJ..."
            //Enable this to allow text shrink based on control size
            listBoxControl1.Appearance.TextOptions.Trimming = Trimming.EllipsisCharacter;
            //Show tooltip, only allow manual tooltip, auto ones now can be wrong
            //listBoxControl1.ShowToolTipForTrimmedText = DefaultBoolean.True;
            

            for (int i = 0; i < 1000; i++)
            {
                string sMessage = "AABB CCDD EEFF GGHH IIJJ KKLL MMNN OOPP\r\n";
                if (i % 2 == 0)
                {
                    sMessage += BitConverter.ToString(new byte[200]) + "\r\n";
                    sMessage += sMessage;
                    sMessage += sMessage;
                }
                dataList.Add(sMessage);
            }
            listBoxControl1.DataSource = dataList;

            listBoxControl1.CustomItemDisplayText += ListBoxControl1_CustomItemDisplayText;
            toolTipController1.GetActiveObjectInfo += ToolTipController1_GetActiveObjectInfo;
        }

        private void ListBoxControl1_CustomItemDisplayText(object sender, CustomItemDisplayTextEventArgs e)
        {
            //Init variables
            if (e.Value == null) return;
            string sValue = e.Value.ToString();

            //Limit maximum display length
            if (sValue.Length > 100) sValue = sValue.Substring(0, 97) + "...";

            //Keeps only one line in the data area
            if (sValue.Contains("\n")) sValue = sValue.Substring(0, sValue.IndexOf('\n')) + "...";

            e.DisplayText = sValue;
        }

        private void ToolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            try
            {
                ListBoxControl listBoxControl = e.SelectedControl as ListBoxControl;
                if (listBoxControl == null) return;
                int index = listBoxControl.IndexFromPoint(e.ControlMousePosition);
                if (index < 0) return;
                var item = listBoxControl.GetItem(index) as string;
                e.Info = new ToolTipControlInfo(item, item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DevListBoxManualToolTip.ToolTipController1_GetActiveObjectInfo:\r\n" + ex.Message);
            }

           
        }
    }
}