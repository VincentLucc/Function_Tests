using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridControl_22_1
{
    public partial class CardViews : DevExpress.XtraEditors.XtraForm
    {
        public List<AlarmInfo> AlarmList;

        public CardViews()
        {
            InitializeComponent();
        }

        private void CardViews_Load(object sender, EventArgs e)
        {
            AlarmList = new List<AlarmInfo>();
            for (int i = 0; i < 15; i++)
            {
                AlarmInfo alarm = new AlarmInfo();

                //Get group ID
                int iGroup = (i / 4)+1;
                int iOrder = (i % 4) + 1;

                alarm.DeviceName = $"Device_{iGroup}";
                alarm.Alarm = $"Alarm_{iGroup}_{iOrder}";

                AlarmList.Add(alarm);
            }

            gridControl1.DataSource = AlarmList;
            
        }

        
    }
}