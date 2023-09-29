
namespace Test001
{
    partial class FormMapping
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MappingGridControl = new DevExpress.XtraGrid.GridControl();
            this.MappingGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.MappingGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MappingGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MappingGridControl
            // 
            this.MappingGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MappingGridControl.Location = new System.Drawing.Point(0, 0);
            this.MappingGridControl.MainView = this.MappingGridView;
            this.MappingGridControl.Name = "MappingGridControl";
            this.MappingGridControl.Size = new System.Drawing.Size(800, 450);
            this.MappingGridControl.TabIndex = 2;
            this.MappingGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MappingGridView});
            // 
            // MappingGridView
            // 
            this.MappingGridView.GridControl = this.MappingGridControl;
            this.MappingGridView.Name = "MappingGridView";
            this.MappingGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.MappingGridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplaceHideCurrentRow;
            this.MappingGridView.OptionsCustomization.AllowColumnMoving = false;
            this.MappingGridView.OptionsCustomization.AllowFilter = false;
            this.MappingGridView.OptionsCustomization.AllowGroup = false;
            this.MappingGridView.OptionsCustomization.AllowSort = false;
            this.MappingGridView.OptionsMenu.EnableColumnMenu = false;
            this.MappingGridView.OptionsMenu.EnableFooterMenu = false;
            this.MappingGridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.MappingGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.MappingGridView.OptionsView.ShowGroupPanel = false;
            // 
            // FormMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MappingGridControl);
            this.Name = "FormMapping";
            this.Text = "FormMapping";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMapping_FormClosing);
            this.Load += new System.EventHandler(this.FormMapping_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MappingGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MappingGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl MappingGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView MappingGridView;
    }
}