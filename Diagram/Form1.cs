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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set diagram items

            diagramControl1.OptionsBehavior.ShowQuickShapes = false; // Quick shape group won't be shown in this shape tool box
            diagramControl1.OptionsView.MinZoomFactor = 0.3f;
            diagramControl1.OptionsView.MaxZoomFactor = 4;
            diagramControl1.OptionsView.ShowGrid = false;  //Hide grid
            diagramControl1.OptionsView.ShowRulers = false; //hide ruler
            diagramControl1.OptionsBehavior.SnapToGrid = false;  //Snap mode
            diagramControl1.OptionsView.CanvasSizeMode = CanvasSizeMode.Fill; //Hide paper like canvas in center
            diagramControl1.OptionsView.ShowPageBreaks = false; //Hide page division lines
            diagramControl1.OptionsView.ScrollMargin = new Padding(int.MaxValue);//Will hide scroll bar in maximum mode
            diagramControl1.OptionsBehavior.SelectionMode = DevExpress.Diagram.Core.SelectionMode.Single; //Single selection only

            diagramControl1.FitToDrawing(); //No scroll bar

            //Set diagram items
            //diagramControl1.SelectedStencils = new StencilCollection(new string[] { "Machine", "Auxiliary", "Sequence" });
            //default items
            //diagramControl1.OptionsBehavior.SelectedStencils = new StencilCollection(new string[] {
            //"BasicShapes",
            //"BasicFlowchartShapes",
            //"SDLDiagramShapes",
            //"ArrowShapes",
            //"SoftwareIcons",
            //"DecorativeShapes"});

            //Container group
            var stencil = new DiagramStencil("Group1", "Group Containers");
            stencil.RegisterTool(new FactoryItemTool("Tool1", () => "Tool1 Device Name", tool1 => new Container(), new System.Windows.Size(36, 36)));
            stencil.RegisterTool(new FactoryItemTool("Tool2", () => "Tool2 Device Name", tool2 => new Container(), new System.Windows.Size(36, 36)));

            DiagramControl.ItemTypeRegistrator.Register(typeof(Container));
            DiagramToolboxRegistrator.RegisterStencil(stencil);

            diagramControl1.SelectedStencils = new StencilCollection() { "Group1" };

            //Items test
            DiagramShape diagramItem = new DiagramShape(BasicShapes.Can, 100, 100, 200, 100);
            diagramItem.CanResize = false;
            diagramControl1.Items.Add(diagramItem);



            diagramControl1.SelectionChanged += DiagramControl1_SelectionChanged;
            diagramControl1.MouseMove += DiagramControl1_MouseMove;
            diagramControl1.DragDrop += DiagramControl1_DragDrop; //not trigger
            diagramControl1.CustomItemDragResult += DiagramControl1_CustomItemDragResult;
            diagramControl1.CustomItemDrag += DiagramControl1_CustomItemDrag;
            diagramControl1.ItemsMoving += DiagramControl1_ItemsMoving;
            diagramControl1.MouseClick += DiagramControl1_MouseClick;
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
