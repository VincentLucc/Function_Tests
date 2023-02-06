using DevExpress.Utils;
using DevExpress.Utils.Animation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLoad
{
    /// <summary>
    /// Parent form to allow reload
    /// </summary>
    public class FormReloadBaseDev : XtraForm
    {
        private WorkspaceManager workspaceManager1;
        private System.ComponentModel.IContainer components;
        public string WorkSpaceID = "Default";
        public bool IsFirstLoadComplete;
        /// <summary>
        /// Check whether program is running in desgin mode
        /// </summary>
        public bool isDesignMode;
        public FormReloadBaseDev()
        {
            this.InitializeComponent();

            //Init variables
            isDesignMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            this.StartPosition = FormStartPosition.CenterParent;

            //Save init control settings
            workspaceManager1.TargetControl = this;
            workspaceManager1.SaveTargetControlSettings = true;
            // Disable layout load animation effects 
            workspaceManager1.AllowTransitionAnimation = DefaultBoolean.False;

            //Init events
            this.Load += FormReload_Load;
            this.VisibleChanged += FormReloadBaseDev_VisibleChanged;
        }

        private void FormReloadBaseDev_VisibleChanged(object sender, EventArgs e)
        {
            //Reload init state
            //Window state must be set when form is visible to be valid
            if (IsFirstLoadComplete && this.Visible)
            {//Not include control values
                this.SuspendLayout();
                this.workspaceManager1.AllowTransitionAnimation= DefaultBoolean.False;
                this.workspaceManager1.ApplyWorkspace(WorkSpaceID);
                //Works better than FormStartPosition.CenterParent;
                this.CenterToParent();
                this.ResumeLayout();
            }
        }

        private void FormReload_Load(object sender, EventArgs e)
        {
            //Avoid hot load to run this piece of code which could change the source file
            if (isDesignMode) return;

            //Init form settings
            Debug.WriteLine("FormReload_Load");
            if (!IsFirstLoadComplete) workspaceManager1.CaptureWorkspace(WorkSpaceID, true);
 
            //Finish up flag
            IsFirstLoadComplete = true;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.Animation.FadeTransition fadeTransition1 = new DevExpress.Utils.Animation.FadeTransition();
            this.workspaceManager1 = new DevExpress.Utils.WorkspaceManager(this.components);
            this.SuspendLayout();
            // 
            // workspaceManager1
            // 
            this.workspaceManager1.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.workspaceManager1.SaveTargetControlSettings = true;
            this.workspaceManager1.TargetControl = this;
            this.workspaceManager1.TransitionType = fadeTransition1;
            // 
            // FormReloadBaseDev
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormReloadBaseDev";
            this.ResumeLayout(false);

        }
    }
}
