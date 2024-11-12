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

namespace DirectXForm_2201
{
    class csItem1 : DiagramShape
    {
        public csItem1()
        {
            //Fix item size
            Width = 64;
            Height = 64;
            CanResize = false;
        }



        public void Draw(CustomDrawItemEventArgs e)
        {
            //Draw item in tool box
            if (e.Context == DiagramDrawingContext.Toolbox)
            {
                e.Graphics.DrawImage(csImages.FunctionsStatistical32, 0, 0, 32, 32);
            }
            //Draw item in back diagram area
            else if (e.Context == DiagramDrawingContext.Canvas)
            {
                e.Graphics.DrawImage(csImages.FunctionsStatistical64, 0, 0, 64, 64);
            }


            //Avoid original draw
            e.Handled = true;
        }
    }
}