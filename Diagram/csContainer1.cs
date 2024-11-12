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
        private DevExpress.XtraCharts.Sankey.SankeyDiagramControl sankeyDiagramControl1;

        /// <summary>
        /// Constructor
        /// </summary>
        public Container1(bool StartThread = false)
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

            SizeChanged += ContainerMain_SizeChanged;
            

            if (!StartThread) return;

            Thread t1 = new Thread(ProcessDoSomething);
            t1.IsBackground = false;
            t1.Start();

        }

        private void ContainerMain_SizeChanged(object sender, EventArgs e)
        {
            this.Height = 64;
            this.Width = 64;
        }

        private void ProcessDoSomething()
        {
            while (!this.IsDisposed)
            {
                Thread.Sleep(1000);
                Debug.WriteLine("ProcessDoSomething: I am alive");
            }
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

        private void InitializeComponent()
        {
            this.sankeyDiagramControl1 = new DevExpress.XtraCharts.Sankey.SankeyDiagramControl();
            // 
            // sankeyDiagramControl1
            // 
            this.sankeyDiagramControl1.Location = new System.Drawing.Point(0, 0);
            this.sankeyDiagramControl1.Name = "sankeyDiagramControl1";
            this.sankeyDiagramControl1.Size = new System.Drawing.Size(300, 300);
            this.sankeyDiagramControl1.TabIndex = 0;
            this.sankeyDiagramControl1.Text = "sankeyDiagramControl1";

        }
    }
}
