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
using DevExpress.XtraDiagram.Commands;

namespace DiagramDemo
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
            diagramControl1.ItemsMoving += DiagramControl1_ItemsMoving;//Main method 1 do something
            diagramControl1.AddingNewItem += DiagramControl1_AddingNewItem;//Main method 2 do something
            diagramControl1.MouseClick += DiagramControl1_MouseClick;
            diagramControl1.CustomDrawItem += DiagramControl1_CustomDrawItem;

            //Disable diagram control shortcut
            DisableDiagramControlShortCuts(diagramControl1);
        }

        public void DisableDiagramControlShortCuts(DiagramControl diagram)
        {
            diagram.Commands.RegisterHotKeys(x => {
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

        private void DiagramControl1_AddingNewItem(object sender, DiagramAddingNewItemEventArgs e)
        {
            if (e.Item is DiagramImage)
            {
                ImageAddOperation(e, (DiagramImage)e.Item);
            }
        }


        private void ImageAddOperation(DiagramAddingNewItemEventArgs e, DiagramImage image)
        {
            //Ignore if put into empty space
            if (e.Parent == null || e.Parent is DiagramRoot) return;

            //Put inside other controls
            e.Cancel = true;

            //Create new image to add
            DiagramImage imageNew = new DiagramImage();
            imageNew.Image = image.Image;
            imageNew.Size = image.Size;

            //Get new location and add
            imageNew.X = e.Parent.X;
            imageNew.Y = e.Parent.Y + e.Parent.Height;
            diagramControl1.Items.Add(imageNew);
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

            //Only process when drag and drop finished
            if (e.Stage != DiagramActionStage.Finished) return;

            //Only process mouse operation
            if (e.ActionSource != ItemsActionSource.Mouse) return;

            //Debug
            Debug.WriteLine("CompositionDiagramControl_ItemsMoving.Finished");
            Debug.WriteLine($"End From:{ e.Items[0].OldDiagramPosition} to {e.Items[0].NewDiagramPosition}");
            float x = e.Items[0].NewDiagramPosition.X - e.Items[0].NewParent.X - 8;
            float y = e.Items[0].NewDiagramPosition.Y - e.Items[0].NewParent.Y - 8;
            Debug.WriteLine($"End Inner,X:{ (int)x} Y:{(int)y}");

            //Handle movement based on device type
            foreach (var movingItem in e.Items)
            {
                if (movingItem.Item is DiagramImage)
                {
                    //Image can only sit in root
                    if (!(movingItem.NewParent is DiagramRoot))
                    {
                        e.Cancel = true;
                        return;
                    }
                }

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
