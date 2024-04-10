using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevMessage
{
    public partial class WaitTaskDialog : WaitForm
    {
        Task waitTask;
        Timer timer = new Timer();




        /// <summary>
        /// For designer usage only
        /// </summary>
        public WaitTaskDialog()
        {
            InitializeComponent();
            InitEvents();
        }


        public WaitTaskDialog(Task waitTask)
        {
            InitializeComponent();
            InitEvents();
            this.waitTask = waitTask;
        }



        private void InitEvents()
        {
            this.Load += WaitForm1_Load;
        }

        private void WaitForm1_Load(object sender, EventArgs e)
        {
            InitControl();

            //Init timer
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }


        public static object WaitTask<T>(Task<T> _task, string sMessage = null, string sTitle = null)
        {
            using (WaitTaskDialog waitDialog = new WaitTaskDialog(_task))
            {
                if (!string.IsNullOrWhiteSpace(sTitle)) waitDialog.SetCaption(sTitle);
                if (!string.IsNullOrWhiteSpace(sMessage)) waitDialog.SetDescription(sMessage);
                waitDialog.ShowDialog();
                return _task.Result;
            }
        }

        public static void WaitTask(Task _task, string sMessage = null, string sTitle = null)
        {
            using (WaitTaskDialog waitDialog = new WaitTaskDialog(_task))
            {
                if (!string.IsNullOrWhiteSpace(sTitle)) waitDialog.SetCaption(sTitle);
                if (!string.IsNullOrWhiteSpace(sMessage)) waitDialog.SetDescription(sMessage);
                waitDialog.ShowDialog();
            }
        }


        private void InitControl()
        {
            this.progressPanel1.AutoHeight = true;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;

            if (waitTask == null || waitTask.IsCompleted)
            {
                this.Close();
                return;
            }

            timer.Enabled = true;
        }




        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }
    }
}