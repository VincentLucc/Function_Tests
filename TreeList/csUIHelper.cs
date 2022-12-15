using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeList
{
    public class csUIHelper
    {
        public static void InitTreeList(DevExpress.XtraTreeList.TreeList treeList)
        {
            treeList.OptionsMenu.EnableColumnMenu = false; //Disable column menu
            treeList.OptionsCustomization.AllowFilter= false; //Disable filter icon
            treeList.OptionsCustomization.AllowSort= false; //Disable column sort
        }
    }
}
