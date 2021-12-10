using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagram
{
    public class ClassDiagram
    {
    }

    public class Container : DiagramContainer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Container()
        {
            //Container Basic settings
            ShowHeader = false;
            Padding = new Padding(0, 0, 0, 0); //Clear all padding
            HeaderPadding = new Padding(0);
            CanCopy = false;
            CanEdit = false;
            CanChangeParent = false;
            AdjustBoundsBehavior = AdjustBoundaryBehavior.DisableOutOfBounds;
            MinWidth = 200;
            MinHeight = 200;

            Appearance.Font = new Font("Calibri", 14);
            Appearance.ForeColor = Color.DarkRed;
            Appearance.BackColor = Color.Transparent;

            Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;

           
            

        }
    }
}
