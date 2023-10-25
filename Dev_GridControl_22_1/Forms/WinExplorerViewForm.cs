using DevExpress.ExpressApp.Editors;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.WinExplorer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridControl_22_1.Forms
{
    public partial class WinExplorerViewForm : DevExpress.XtraEditors.XtraForm
    {

        List<viewItem> viewItems = new List<viewItem>();

        public WinExplorerViewForm()
        {
            InitializeComponent();
        }

        private void WinExplorerViewForm_Load(object sender, EventArgs e)
        {
            //Create view items
            viewItems.Add(new viewItem() { name = "item1", image = imageCollection1.Images[0] });
            viewItems.Add(new viewItem() { name = "item2", image = imageCollection1.Images[1] });
            viewItems.Add(new viewItem() { name = "item3", image = imageCollection1.Images[2] });
            viewItems.Add(new viewItem() { name = "item4", image = imageCollection1.Images[3] });

            gridControl1.DataSource = viewItems;

            //Init view
            winExplorerView1.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Medium;
            winExplorerView1.PopulateColumns();
            winExplorerView1.ColumnSet.ExtraLargeImageColumn = winExplorerView1.Columns[nameof(viewItem.image)];
            winExplorerView1.ColumnSet.MediumImageColumn = winExplorerView1.Columns[nameof(viewItem.image)];
            //Text always visible
            winExplorerView1.ColumnSet.TextColumn = winExplorerView1.Columns[nameof(viewItem.name)];
            winExplorerView1.ColumnSet.DescriptionColumn = winExplorerView1.Columns[nameof(viewItem.name)];

            //Set context button
            winExplorerView1.ContextButtonClick += WinExplorerView1_ContextButtonClick;
 

            //Adjust the button position by setting the used panel padding (Default:5)
            winExplorerView1.ContextButtonOptions.TopPanelPadding = new Padding(0);




        }

 

        private void WinExplorerView1_ContextButtonClick(object sender, ContextItemClickEventArgs e)
        {
            string sButton = e.Item.Name;
            int iIndex = (int)e.DataItem;

            //Don't use "FocusedRowHandle", it shows always 0.
            //Use the data item value instead
            var rowData = (winExplorerView1.GetRow(iIndex)) as viewItem;
            if (rowData == null) return;

            if (sButton == "contextButtonDelete")
            {
                viewItems.Remove(rowData);
                //Issue, the buttons not repaint
                //gridControl1.RefreshDataSource();
                gridControl1.Invalidate();
                MessageBox.Show($"Delete：{rowData.name}.");
            }





        }
    }

    public class viewItem
    {
        public string name { get; set; }
        public Image image { get; set; }
    }
}