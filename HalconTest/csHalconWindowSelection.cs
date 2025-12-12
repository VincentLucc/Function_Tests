using _CommonCode_Framework;
using DevExpress.XtraDialogs.FileExplorerExtensions;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconTest
{
    /// <summary>
    /// User selection data on the window
    /// </summary>
    public class csHalconWindowSelection
    {

        /// <summary>
        /// Current tool selection
        /// </summary>
        public string FocusedToolID;

        /// <summary>
        /// indicate user selection on the window
        /// </summary>
        public csDisplayHObject FocusedDispObject;

        /// <summary>
        /// 0: All
        /// 1~n: subitem
        /// </summary>
        public int FocusedDispObjectItemOrder;

 

    }
}
