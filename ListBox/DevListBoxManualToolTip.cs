using DevExpress.Utils;
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
            List<csValueItem> dataList = new List<csValueItem>();

            //Trim option
            //Trimming.Default trim by length except "\r\n"
            //Trimming.Character trim by length, include "\r\n"
            //Trimming.EllipsisCharacter trim by length, include "\r\n", add "...", "AABBCCDDEEFF"=>"AABBCC...."
            //Trimming.EllipsisPath trim by length, replace in center include "\r\n", add "...", "AABBCCDDEEFF"=>"AABB...EEFF"
            //Trimming.EllipsisWord trim by length, replace in last include "\r\n", add "...", "AABB CCDD EEFF GGHH IIJJ KKLL MMNN OOPP"=>"AABB CCDD EEFF GGHH IIJJ..."
            listBoxControl1.Appearance.TextOptions.Trimming = Trimming.EllipsisCharacter;//Enable this to allow text shrink based on control size
            //Show tooltip, only allow manual tooltip, auto ones now can be wrong
            //listBoxControl1.ShowToolTipForTrimmedText = DefaultBoolean.True;
            

            for (int i = 0; i < 1000; i++)
            {

                string sMessage = "AABB CCDD EEFF GGHH IIJJ KKLL MMNN OOPP\r\n";
                string sDisplay = "";

                if (i % 2 == 0)
                {
                    sMessage += BitConverter.ToString(new byte[200]) + "\r\n";
                    sMessage += sMessage;
                    sMessage += sMessage;
                }

                //Limit maximum display length
                if (sMessage.Length > 100) sDisplay = sMessage.Substring(0, 97) + "...";
 
                //Keeps only one line in the data area
                if (sDisplay.Contains("\n")) sDisplay = sDisplay.Substring(0, sDisplay.IndexOf('\n')) + "...";

                //Check if display been set
                if (sDisplay=="") sDisplay = sMessage;

                var item = new csValueItem(sMessage, sDisplay);
                dataList.Add(item);
            }
            listBoxControl1.DataSource = dataList;
            listBoxControl1.DisplayMember = nameof(csValueItem.Description);
            listBoxControl1.ValueMember = nameof(csValueItem.Value);

            toolTipController1.GetActiveObjectInfo += ToolTipController1_GetActiveObjectInfo;
        }

        private void ToolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            try
            {
                ListBoxControl listBoxControl = e.SelectedControl as ListBoxControl;
                if (listBoxControl == null) return;
                int index = listBoxControl.IndexFromPoint(e.ControlMousePosition);
                if (index < 0) return;
                var item = listBoxControl.GetItem(index) as csValueItem;
                e.Info = new ToolTipControlInfo(item.Value, item.Value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DevListBoxManualToolTip.ToolTipController1_GetActiveObjectInfo:\r\n" + ex.Message);
            }

           
        }
    }
}