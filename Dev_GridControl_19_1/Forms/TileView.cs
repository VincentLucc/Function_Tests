using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Tile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridControl_19_1.Forms
{
    public partial class TileView : DevExpress.XtraEditors.XtraForm
    {
        public TileView()
        {
            InitializeComponent();
        }

        private void TileView_Load(object sender, EventArgs e)
        {
           var AlarmList = new List<AlarmInfo>();
            for (int i = 0; i < 5; i++)
            {
                AlarmInfo alarm = new AlarmInfo();

                //Get group ID
                int iGroup = (i / 4) + 1;
                int iOrder = (i % 4) + 1;

                alarm.DeviceName = $"Device_{iGroup}";
                alarm.Alarm = $"Alarm_{iGroup}_{iOrder}";

                AlarmList.Add(alarm);
            }

            gridControl1.DataSource = AlarmList;


            tileView1.ItemClick += TileView1_ItemClick;

            //Set bind elements in the title view to columns
            
            (tileView1.TileTemplate[0] as TileViewItemElement).Column = tileView1.Columns[nameof(AlarmInfo.Alarm)];
            (tileView1.TileTemplate[1] as TileViewItemElement).Column = tileView1.Columns[nameof(AlarmInfo.DeviceName)];
            tileView1.ColumnSet.CheckedColumn = tileView1.Columns[nameof(AlarmInfo.Checked)]; //Set checked column
        }

        private void TileView1_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            e.Item.Checked = !e.Item.Checked;
            tileView1.SetRowCellValue(e.Item.RowHandle, "Selected", e.Item.Checked);
        }
    }
}