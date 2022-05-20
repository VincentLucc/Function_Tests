using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _QuickTests
{
    public class FlashSignal
    {
        public bool State { get; set; }   //ON/OFF status
        private int Interval { get; set; } //Interval for each gap
        public bool ActionEnable { get; set; } //Used to mark trigger the action only once

        private bool Enable { get; set; }  //Signal is enable or not
        private Thread tSignal { get; set; } //Signal loop thread

        private Stopwatch Watch { get; set; } = new Stopwatch(); //Watch used to count time

        /// <summary>
        /// Used to guaranty exit
        /// </summary>
        private Control ParentControl { get; set; }

        private bool UIExit => ParentControl == null || ParentControl.IsDisposed || ParentControl.Disposing;

        public FlashSignal(int IntervalInMilliseconds, Control control)
        {
            //Init variables
            ParentControl = control;

            //verify input
            if (IntervalInMilliseconds <= 0)
            {
                Exception e = new Exception("Invalid Interval Value.");
                throw e;
            }
            Interval = IntervalInMilliseconds / 2;

            //start counting thread
            tSignal = new Thread(ProcessSignal);
            Enable = true;
            tSignal.IsBackground = true;
            tSignal.Start();
        }

        /// <summary>
        /// Signal loop process
        /// </summary>
        private void ProcessSignal()
        {
            while (Enable)
            {
                //Auto exit
                if (UIExit) return;

                //On
                DelayTimeWithExitFlag(Interval);
                State = true;

                //Off
                DelayTimeWithExitFlag(Interval);
                State = false;

                //Enable the action again
                ActionEnable = true;
            }
        }

        public void Stop()
        {
            Enable = false;
        }

        private void DelayTimeWithExitFlag(int ms)
        {
            Watch.Restart();
            while (Watch.ElapsedMilliseconds < ms)
            {
                Thread.Sleep(5);

                //Exist flag
                if (!Enable || UIExit) return;
            }
        }
    }
}
