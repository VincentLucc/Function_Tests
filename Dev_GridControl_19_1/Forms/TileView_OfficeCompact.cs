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
    public partial class TileView_OfficeCompact : DevExpress.XtraEditors.XtraForm
    {
        public TileView_OfficeCompact()
        {
            InitializeComponent();
        }

        private void OfficeCompact_Load(object sender, EventArgs e)
        {
            //Create sample data
            List<Student> students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                string sID = (i + 100).ToString("d3");
                Student student = new Student()
                {
                    Name = $"Stu_{sID}",
                    DescriptionInfo = $"This is student Stu_{sID}.",
                    Age = i + 100

                };
                students.Add(student);
            }

            //Init grid control
            gridControl1.DataSource = students;
            tileView1.PopulateColumns();
            tileView1.OptionsTiles.Orientation = Orientation.Vertical;

            //Config the tile view template
            //In desginer:Setup the order layout
            //In designer: create the TileTempplate only, don't need to create columns, it doesn't automatically match
            //Bind the tiletemplate with code
            //Template item 0
            (tileView1.TileTemplate[0] as TileViewItemElement).Column = tileView1.Columns[nameof(Student.Name)];
            //Template item 1
            (tileView1.TileTemplate[1] as TileViewItemElement).Column = tileView1.Columns[nameof(Student.DescriptionInfo)];
            //Template item 2
            (tileView1.TileTemplate[2] as TileViewItemElement).Column = tileView1.Columns[nameof(Student.Age)];

            //Set check option
            /*tileView1.ColumnSet.CheckedColumn = tileView1.Columns[nameof(Student.Enable)];*/ //Set checked column


        }
    }
}