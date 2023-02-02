using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBox
{
    public partial class DevListBoxAutoToolTip : DevExpress.XtraEditors.XtraForm
    {
        public DevListBoxAutoToolTip()
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
            listBoxControl1.Appearance.TextOptions.Trimming = Trimming.EllipsisWord;
            //Show tooltip
            listBoxControl1.ShowToolTipForTrimmedText = DefaultBoolean.True;


            for (int i = 0; i < 1000; i++)
            {

                string sMessage = "AABB CCDD EEFF GGHH IIJJ KKLL MMNN OOPP\r\n";

                if (i%2==0)
                {
                    sMessage += BitConverter.ToString(new byte[200]) + "\r\n";
                    sMessage += sMessage;
                    sMessage += sMessage;
                
                }

                var item = new csValueItem(sMessage);
                dataList.Add(item);
            }
            listBoxControl1.DataSource = dataList;
            listBoxControl1.DisplayMember = nameof(csValueItem.Value);
            listBoxControl1.ValueMember= nameof(csValueItem.Description);
        


        }


    }
}