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

        public BindingList<csTreeItem> TreeItems = new BindingList<csTreeItem>();

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
            treeList1.CustomColumnDisplayText += TreeList1_CustomColumnDisplayText; ;
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
                    Name = $"Folder_{iCount+1}",
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

        public Image Icon { get; set; }

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

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}