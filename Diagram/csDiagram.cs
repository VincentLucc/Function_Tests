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
    public class DiagramHelper
    {
        DiagramControl diagram { get; set; }

        public DiagramHelper(DiagramControl diagramControl)
        {
            diagram = diagramControl;
            InitControl();
            PrepareItems();
            AddTestObjects();
        }


        private void InitControl()
        {
            diagram.OptionsBehavior.ShowQuickShapes = false; // Quick shape group won't be shown in this shape tool box
            diagram.OptionsView.MinZoomFactor = 0.3f;
            diagram.OptionsView.MaxZoomFactor = 4;
            diagram.OptionsView.ShowGrid = false;  //Hide grid
            diagram.OptionsView.ShowRulers = false; //hide ruler
            diagram.OptionsBehavior.SnapToGrid = false;  //Snap mode
            diagram.OptionsView.CanvasSizeMode = CanvasSizeMode.Fill; //Hide paper like canvas in center
            diagram.OptionsView.ShowPageBreaks = false; //Hide page division lines
            diagram.OptionsView.ScrollMargin = new Padding(int.MaxValue);//Will hide scroll bar in maximum mode
            diagram.OptionsBehavior.SelectionMode = DevExpress.Diagram.Core.SelectionMode.Single; //Single selection only
         
            diagram.FitToDrawing(); //No scroll bar
        }

        private void PrepareItems()
        {
            //Container group
            var diagramGroup1 = new DiagramStencil("Group1", "Group Containers");

            //Add tool to group
            diagramGroup1.RegisterTool(new FactoryItemTool("Tool1", () => "Tool1 Device Name", tool1 => new ContainerMain(), new System.Windows.Size(36, 36)));
            diagramGroup1.RegisterTool(new FactoryItemTool("Tool2", () => "Tool2 Device Name", tool2 => new Container1(), new System.Windows.Size(36, 36)));

            //Reg type to diagram so it can be save and load properly
            DiagramControl.ItemTypeRegistrator.Register(typeof(ContainerMain));
            DiagramControl.ItemTypeRegistrator.Register(typeof(Container1));

            //Last step
            DiagramToolboxRegistrator.RegisterStencil(diagramGroup1);

            //Set visible item group
            diagram.SelectedStencils = new StencilCollection() { "Group1" };


        }

        private void AddTestObjects()
        {
            //Items test
            DiagramShape diagramItem = new DiagramShape(BasicShapes.Can, 100, 100, 200, 100);
            diagramItem.CanResize = false;
            diagram.Items.Add(diagramItem);
        }
    }

    



}
