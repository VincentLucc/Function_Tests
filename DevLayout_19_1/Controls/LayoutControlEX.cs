using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevLayout_19_1
{
    [ToolboxItem(true)]
    public sealed class LayoutControlEx : LayoutControl
    {

        /// <summary>  
        /// Initializes a new instance of the LayoutControlEx class  
        /// </summary>  
        public LayoutControlEx()
            : base()
        {
            Dock = DockStyle.Fill;
        }


        /// <summary>  
        /// On create control event handler  
        /// </summary>  
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            AllowCustomization = false;
        }

    }
}
