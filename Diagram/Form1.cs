using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using DevExpress.XtraEditors;
using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagram
{
    public partial class Form1 : XtraForm
    {

        DiagramHelper diagramHelper { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set diagram items
            diagramHelper = new DiagramHelper(diagramControl1);
            //Add diagram events
            diagramControl1.SelectionChanged += DiagramControl1_SelectionChanged;
            diagramControl1.MouseMove += DiagramControl1_MouseMove;
            diagramControl1.DragDrop += DiagramControl1_DragDrop; //not trigger
            diagramControl1.CustomItemDragResult += DiagramControl1_CustomItemDragResult;
            diagramControl1.CustomItemDrag += DiagramControl1_CustomItemDrag;
            diagramControl1.ItemsMoving += DiagramControl1_ItemsMoving;
            diagramControl1.MouseClick += DiagramControl1_MouseClick;
            diagramControl1.CustomDrawItem += DiagramControl1_CustomDrawItem;
        }

        private void DiagramControl1_CustomDrawItem(object sender, CustomDrawItemEventArgs e)
        {
            if (e.Item is ContainerMain)
            {
                ((ContainerMain)e.Item).Draw(e);
            }
            else if (e.Item is Container1)
            {
               (e.Item as Container1).Draw(e);
            }
        }

        private void DiagramControl1_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Mouse Click:" + e.Button);

            if (e.Button == MouseButtons.Right)
            {
                diagramControl1.FitToDrawing();
            }
        }




        private void DiagramControl1_CustomItemDrag(object sender, DiagramCustomItemDragEventArgs e)
        {

        }

        private void DiagramControl1_CustomItemDragResult(object sender, DiagramCustomItemDragResultEventArgs e)
        {
            Debug.WriteLine("Custom Drag and Drop Complete");
            Debug.WriteLine("End X:" + e.Items[0].X);

            GetLocation();

        }

        private void DiagramControl1_ItemsMoving(object sender, DiagramItemsMovingEventArgs e)
        {
            switch (e.Stage)
            {
                case DiagramActionStage.Start:
                    Debug.WriteLine("Start X:" + e.Items[0].Item.X);
                    break;
                case DiagramActionStage.Continue:
                    //Do nothing
                    break;
                case DiagramActionStage.Finished:
                    Debug.WriteLine($"Stage:{e.Stage}");
                    Debug.WriteLine($"End From:{ e.Items[0].OldDiagramPosition} to {e.Items[0].NewDiagramPosition}");
                    float x = e.Items[0].NewDiagramPosition.X - e.Items[0].NewParent.X - 8;
                    float y = e.Items[0].NewDiagramPosition.Y - e.Items[0].NewParent.Y - 8;
                    Debug.WriteLine($"End Inner,X:{ (int)x} Y:{(int)y}");
                    //if (e.Items[0].NewDiagramPosition.X>300)
                    //{
                    //    e.Cancel = true;
                    //}


                    break;
                case DiagramActionStage.Canceled:
                    break;
                default:
                    break;
            }

            // Debug.WriteLine($"ItemsMoving.Action Source:{e.ActionSource}");
            e.Cancel = false;

        }



        private void DiagramControl1_DragDrop(object sender, DragEventArgs e)
        {
            GetLocation();   //Not trigger
            Debug.WriteLine("Drag and Drop Complete");
        }

        private void DiagramControl1_MouseMove(object sender, MouseEventArgs e)
        {


        }

        private void DiagramControl1_SelectionChanged(object sender, DiagramSelectionChangedEventArgs e)
        {
            GetLocation();
        }

        private void memoEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void diagramControl1_Click(object sender, EventArgs e)
        {

        }

        private void diagramControl1_ItemsMoving(object sender, DiagramItemsMovingEventArgs e)
        {
            // GetLocation();   //use mouse moving instead

        }


        private void GetLocation()
        {
            //Get selected object 
            var selection = diagramControl1.SelectedItems;

            //Check length
            if (selection.Count < 1)
            {
                return;
            }

            //Get item
            DiagramItem item = selection[0];
            memoEdit1.Text = item.Position.ToString();
        }
    }
}
