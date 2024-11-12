using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectXForm_2201
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
            DisableDiagramControlShortCuts(diagram);
            diagram.FitToDrawing(); //No scroll bar
        }

        public void DisableDiagramControlShortCuts(DiagramControl diagram)
        {


            diagram.Commands.RegisterHotKeys(x =>
            {
                x.ClearHotKeys(DiagramCommandsBase.UndoCommand);//Ctrl+Z
                x.ClearHotKeys(DiagramCommandsBase.RedoCommand);
                x.ClearHotKeys(DiagramCommandsBase.CopyCommand); //Ctrl+C
                x.ClearHotKeys(DiagramCommandsBase.PasteCommand);//Ctrl+V
                x.ClearHotKeys(DiagramCommandsBase.CutCommand);//Ctrl+X
                x.ClearHotKeys(DiagramCommandsBase.NewFileCommand);//Ctrl+N
                x.ClearHotKeys(DiagramCommandsBase.OpenFileCommand);//Ctrl+O
                x.ClearHotKeys(DiagramCommandsBase.RotateCommand);//Ctrl+R
                x.ClearHotKeys(DiagramCommandsBase.InsertImageCommand);
                x.ClearHotKeys(DiagramCommandsBase.ToggleFontBoldCommand);//Ctrl+B
                x.ClearHotKeys(DiagramCommandsBase.ToggleFontUnderlineCommand);//Ctrl+U
                x.ClearHotKeys(DiagramCommandsBase.ToggleFontItalicCommand);//Ctrl+I
                x.ClearHotKeys(DiagramCommandsBase.ToggleFontStrikethroughCommand);
                x.ClearHotKeys(DiagramCommandsBase.ToggleSubordinatesVisibilityCommand);
                x.ClearHotKeys(DiagramCommandsBase.PrintCommand);
                x.ClearHotKeys(DiagramCommandsBase.QuickPrintCommand);
                x.ClearHotKeys(DiagramCommandsBase.ShowPrintPreviewCommand); // Ctrl+P
                x.ClearHotKeys(DiagramCommandsBase.SaveFileAsCommand);
                x.ClearHotKeys(DiagramCommandsBase.SaveFileCommand);
                x.ClearHotKeys(DiagramCommandsBase.SelectAllCommand);
                x.ClearHotKeys(DiagramCommandsBase.ChangeConnectorTypeCommand);
            });
        }

        private void PrepareItems()
        {
            //Reg type to diagram so it can be save and load properly
            //DiagramControl.ItemTypeRegistrator.Register(typeof(Container1));
            //DiagramControl.ItemTypeRegistrator.Register(typeof(Container2));
            DiagramControl.ItemTypeRegistrator.Register(typeof(csItem1));

            //Container group
            var diagramGroup1 = new DiagramStencil("Group1", "Group Containers");

            ////Add tool to group
            //diagramGroup1.RegisterTool(new FactoryItemTool("Tool1", () => "Tool1DisName", tool1 => new Container1(), new System.Windows.Size(36, 36)));
            //diagramGroup1.RegisterTool(new FactoryItemTool("Tool2", () => "Tool2DisName", tool2 => new Container2(), new System.Windows.Size(36, 36)));

            //Last Step
            DiagramToolboxRegistrator.RegisterStencil(diagramGroup1);

            //Items
            var diagramGroup2 = new DiagramStencil("Items11", "Items11");
            diagramGroup2.RegisterTool(new FactoryItemTool("Item1", () => "Item1", tool1 => new csItem1(), new System.Windows.Size(36, 36)));
            DiagramToolboxRegistrator.RegisterStencil(diagramGroup2);

            //Set default selected item group
            diagram.SelectedStencils = new StencilCollection() { diagramGroup1.Id, diagramGroup2.Id };
        }

        private void AddTestObjects()
        {
            //Items test
            DiagramShape diagramItem = new DiagramShape(BasicShapes.Can, 100, 100, 200, 100);
            diagramItem.CanResize = false;
            diagram.Items.Add(diagramItem);

            var newItem = new csItem1();
            newItem.Position = new DevExpress.Utils.PointFloat(200, 200);
            diagram.Items.Add(newItem);
        }
    }
}
