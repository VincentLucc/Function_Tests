using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        Stopwatch stopwatch = new Stopwatch();
        static WaitTaskDialog instance;



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
            InitVariables();
            InitControl();

            //Init timer
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void InitVariables()
        {
            stopwatch.Restart();
        }

        private void InitControl()
        {
            this.progressPanel1.AutoHeight = true;
        }

        public static T WaitTask<T>(Task<T> _task, string sMessage = null, string sTitle = null)
        {
            using (instance = new WaitTaskDialog(_task))
            {
                UpdateMessage(sMessage, sTitle);
                instance.ShowDialog();
                return _task.Result;
            }
        }

        public static void WaitTask(Task _task, string sMessage = null, string sTitle = null)
        {
            using (instance = new WaitTaskDialog(_task))
            {
                UpdateMessage(sMessage, sTitle);
                instance.ShowDialog();
            }
        }

        public static void UpdateMessage(string sMessage, string sTitle = null)
        {
            if (!string.IsNullOrWhiteSpace(sTitle)) instance.SetCaption(sTitle);
            if (!string.IsNullOrWhiteSpace(sMessage)) instance.SetDescription(sMessage);
        }




        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;

            if (waitTask == null || waitTask.IsCompleted)
            {
                stopwatch.Stop();
                Debug.WriteLine($"Task Complete: {stopwatch.ElapsedMilliseconds}ms");
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