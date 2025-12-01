using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeList
{
    public partial class BindHierachicalData : DevExpress.XtraEditors.XtraForm
    {

        public List<csTreeItem> TreeItems = new List<csTreeItem>();

        public BindHierachicalData()
        {
            InitializeComponent();
            InitEvnets();
        }

        private void BindHierachicalData_Load(object sender, EventArgs e)
        {
            csUIHelper.InitTreeList(treeList1);

            for (int i = 0; i < 3; i++)
            {
                var sItem = new csTreeItem();
                sItem.Name = $"Main_{i}";
                sItem.Icon = imageCollection1.Images[1]; //Eye

                for (int j = 0; j < 3; j++)
                {
                    var subItem = new csTreeItem()
                    {
                        Name = $"Sub_{i}",
                        Icon = imageCollection1.Images[0] //folder
                    };

                    sItem.SubItems.Add(subItem);
                }

                TreeItems.Add(sItem);
            }

            treeList1.ChildListFieldName = nameof(csTreeItem.SubItems);
            treeList1.DataSource = TreeItems;

            //Set the image source
            //# Select Image (1st)
            //# State image (2nd)
            var sizeImage = imageCollection1.Images[0];
            //Must set the source to a image collection to trigger node image display
            treeList1.SelectImageList = imageCollection1;
            //Set 2nd image
            //treeList1.StateImageList = imageCollection1;


            //Custom view settings
            treeList1.OptionsView.ShowVertLines = false;
            treeList1.OptionsView.ShowHorzLines = false;
            treeList1.OptionsView.ShowIndicator = false;
            treeList1.OptionsView.ShowColumns = false;
       
        }

        private void InitEvnets()
        {
            //This doesn't work
            //Use the "TreeList1_CustomColumnDisplayText" instead
            //treeList1.PopulateColumns();
            //treeList1.Columns[nameof(csTreeItem.Icon)].Width = 50;

            //Show hide columns, don't use custom style event (Won't trigger)
            treeList1.CustomColumnDisplayText += TreeList1_CustomColumnDisplayText;

            treeList1.GetSelectImage += TreeList1_GetSelectImage;
            treeList1.GetStateImage += TreeList1_GetStateImage;
            treeList1.CustomDrawNodeCell += TreeList1_CustomDrawNodeCell;
            treeList1.CustomDrawNodeImages += TreeList1_CustomDrawNodeImages;
        }

        /// <summary>
        /// 2nd position image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeList1_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            e.Node.StateImageIndex = -1;
        }

        /// <summary>
        /// First position image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeList1_GetSelectImage(object sender, GetSelectImageEventArgs e)
        {
           e.Node.SelectImageIndex = -1;
        }

        /// <summary>
        /// Include the select image and the state image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeList1_CustomDrawNodeImages(object sender, CustomDrawNodeImagesEventArgs e)
        {
            var imgObject = e.Node.GetValue(nameof(csTreeItem.Icon));
            var nodeImage = imgObject as Image;
            if (nodeImage == null) return;
 
            var brush = e.Cache.GetSolidBrush(Color.Orange);
            //State image area
            e.Cache.DrawImage(nodeImage, e.SelectRect);
            //Select image area
            e.Cache.FillRectangle(brush, e.StateRect);

            //Avoid default draw
            e.Handled = true;
            //
            //e.DefaultDraw();
        }

        private void TreeList1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {

        }

        private void TreeList1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            string sName = e.Column.FieldName;

            if (sName == (nameof(csTreeItem.Tag)))
            {
                e.Column.Visible = false;
            }
            else if (sName == (nameof(csTreeItem.Name)))
            {
                e.Column.OptionsColumn.AllowEdit = false;
            }
            else if (sName == (nameof(csTreeItem.Icon)))
            {
                e.Column.Width = 32;
            }

        }





        private void bAdd_Click(object sender, EventArgs e)
        {
            //Get level
            int iLevel = treeList1.FocusedNode.Level;

            //Add root
            if (iLevel == 0)
            {
                int iCount = TreeItems.Count;

                var newItem = new csTreeItem()
                {
                    Name = $"Eye_{iCount + 1}",
                    Icon = imageCollection1.Images[1], //Eye
                };

                TreeItems.Add(newItem);
            }
            else if (iLevel == 1)
            {
                var parentNode = treeList1.FocusedNode.ParentNode;
                if (parentNode == null) return;
                var parentRecord = (csTreeItem)treeList1.GetDataRecordByNode(parentNode);
                int iCount = treeList1.FocusedNode.ParentNode.Nodes.Count;

                var newItem = new csTreeItem()
                {
                    Name = $"Folder_{iCount + 1}",
                    Icon = imageCollection1.Images[0], //Folder
                };
                parentRecord.SubItems.Add(newItem);
            }
            else
            {
                //DO nothing
            }


        }





        private void AddSubNode_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode == null) return;
            var sRecord = (csTreeItem)treeList1.GetDataRecordByNode(treeList1.FocusedNode);

            //Get level
            int iLevel = treeList1.FocusedNode.Level;
            int iCount = sRecord.SubItems.Count;

            //Add root
            if (iLevel == 0)
            {
                var newItem = new csTreeItem()
                {
                    Name = $"Folder_{iCount + 1}",
                    Icon = imageCollection1.Images[0], //Folder
                };

                sRecord.SubItems.Add(newItem);
            }
            else if (iLevel == 1)
            {
                var newItem = new csTreeItem()
                {
                    Name = $"Tool_{iCount + 1}",
                    Icon = imageCollection1.Images[2], //Bars
                };
                sRecord.SubItems.Add(newItem);
            }

            treeList1.FocusedNode.Expand();
        }

        private void bDeleteItem_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode == null) return;
            treeList1.FocusedNode.Remove();
        }
    }


    /// <summary>
    /// Must define a class like this to directly show the structure
    /// </summary>
    public class csTreeItem : INotifyPropertyChanged
    {

        public bool? Enable { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }
 

        [Browsable(false)]
        public Image Icon { get; set; }
        /// <summary>
        /// Item type
        /// </summary>
        public object Tag { get; set; }

        public BindingList<csTreeItem> SubItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public csTreeItem()
        {
            SubItems = new BindingList<csTreeItem>();
        }

        //This method is called by the Set accessor of each property.
        //The CallerMemberName attribute that is applied to the optional propertyName
        //parameter causes the property name of the caller to be substituted as an argument.
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}