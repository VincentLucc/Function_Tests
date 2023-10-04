namespace Test001
{
    partial class ColumnSelectorControlV3
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MainPanel = new System.Windows.Forms.Panel();
            this.RulerPanel = new DevExpress.XtraEditors.PanelControl();
            this.ContentRichEditControl = new DevExpress.XtraRichEdit.RichEditControl();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RulerPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.RulerPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(4, 4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(437, 353);
            this.MainPanel.TabIndex = 2;
            // 
            // RulerPanel
            // 
            this.RulerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RulerPanel.Location = new System.Drawing.Point(0, 0);
            this.RulerPanel.Name = "RulerPanel";
            this.RulerPanel.Size = new System.Drawing.Size(437, 52);
            this.RulerPanel.TabIndex = 1;
            // 
            // ContentRichEditControl
            // 
            this.ContentRichEditControl.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.ContentRichEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentRichEditControl.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.ContentRichEditControl.Location = new System.Drawing.Point(4, 4);
            this.ContentRichEditControl.Margin = new System.Windows.Forms.Padding(0);
            this.ContentRichEditControl.Name = "ContentRichEditControl";
            this.ContentRichEditControl.Options.HorizontalRuler.ShowTabs = false;
            this.ContentRichEditControl.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.ContentRichEditControl.ReadOnly = true;
            this.ContentRichEditControl.ShowCaretInReadOnly = false;
            this.ContentRichEditControl.Size = new System.Drawing.Size(437, 353);
            this.ContentRichEditControl.TabIndex = 0;
            this.ContentRichEditControl.Text = "richEditControl1";
            this.ContentRichEditControl.Views.SimpleView.Padding = new System.Windows.Forms.Padding(0);
            this.ContentRichEditControl.Views.SimpleView.WordWrap = false;
            // 
            // ColumnSelectorControlV3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.ContentRichEditControl);
            this.Controls.Add(this.MainPanel);
            this.Location = new System.Drawing.Point(0, 26);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ColumnSelectorControlV3";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(445, 361);
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RulerPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraRichEdit.RichEditControl ContentRichEditControl;
        private DevExpress.XtraEditors.PanelControl RulerPanel;
        private System.Windows.Forms.Panel MainPanel;
    }
}
