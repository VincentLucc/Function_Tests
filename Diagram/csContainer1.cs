using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DiagramDemo
{
    public class Container1 : DiagramContainer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Container1()
        {
            //Container Basic settings
            ShowHeader = false;
            Padding = new Padding(0, 0, 0, 0); //Clear all padding
            HeaderPadding = new Padding(0);
            CanCopy = false;
            CanEdit = false;
            CanChangeParent = false;
            AdjustBoundsBehavior = AdjustBoundaryBehavior.DisableOutOfBounds;
            MinWidth = 64;
            MinHeight = 64;

            Appearance.Font = new Font("Calibri", 14);
            Appearance.ForeColor = Color.DarkRed;
            Appearance.BackColor = Color.Transparent;
            Appearance.BorderSize = 0; //Hide border

            Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;

            CanResize = false;
        }

        public void Draw(CustomDrawItemEventArgs e)
        {
            //Draw item in tool box
            if (e.Context == DiagramDrawingContext.Toolbox)
            {
                e.Graphics.DrawImage(Properties.Resources.objects_color_globe, 0, 0, 32, 32);
            }
            //Draw item in back diagram area
            else if (e.Context == DiagramDrawingContext.Canvas)
            {
                e.Graphics.DrawImage(Properties.Resources.objects_color_globe, 0, 0, 64, 64);
            }
        }
    }
}
