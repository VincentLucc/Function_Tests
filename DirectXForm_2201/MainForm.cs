using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DirectXForm_2201
{
    public partial class MainForm : DevExpress.XtraEditors.DirectXForm
    {
        csFPSHelper fpsHelper;
        Stopwatch watch = new Stopwatch();

        public MainForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += MainForm_Load;
            var diagramHelper = new DiagramHelper(diagramControl1);
            diagramControl1.CustomDrawItem += DiagramControl1_CustomDrawItem;
        }



        private void MainForm_Load(object sender, EventArgs e)
        {

            //FPS
            fpsHelper = new csFPSHelper(2000, 5000);

            timer1.Interval = 10;
            timer1.Start();
        }

        private void DiagramControl1_CustomDrawItem(object sender, DevExpress.XtraDiagram.CustomDrawItemEventArgs e)
        {
            if (e.Item is csItem1)
            {
                (e.Item as csItem1).Draw(e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                watch.Restart();

                var items = diagramControl1.Items.Count;

                diagramControl1.Refresh();
                fpsHelper.AddRecord(watch.Elapsed);

                FPSStaticItem.Caption = $"FPS:{fpsHelper.GetFPS().ToString("f1")}";
                DurationButtonItem.Caption = $"Duration:[Avg:{fpsHelper.GetAverageDuration().ToString("f1")}, Max:{fpsHelper.GetMaxDuration().ToString("f1")}]";
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"timer1_Tick:{ex.Message}");
            }
            finally
            {
                timer1.Enabled = true;
            }
        }
    }
}
