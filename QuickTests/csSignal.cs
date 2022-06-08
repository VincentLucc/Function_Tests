using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QuickTests
{
    public class FlashSignal
    {
        /// <summary>
        /// ON/OFF status
        /// </summary>
        public bool State { get; set; }  
        /// <summary>
        /// Interval for each gap
        /// </summary>
        private int Interval { get; set; }

        /// <summary>
        /// Ratio signal in ON
        /// </summary>
        private double SignalOnRatio { get; set; }

        private int IntervalON => (int)(Interval * SignalOnRatio);

        private int IntervalOFF => (int)(Interval * (1- SignalOnRatio));
        /// <summary>
        /// Used to mark trigger the action only once
        /// </summary>
        public bool ActionEnable { get; set; } 

        /// <summary>
        /// Signal is enable or not
        /// </summary>
        private bool Enable { get; set; }  

        /// <summary>
        /// Signal loop thread
        /// </summary>
        private Thread tSignal { get; set; } 

        /// <summary>
        /// Watch used to count time
        /// </summary>
        private Stopwatch Watch { get; set; } = new Stopwatch(); 

        /// <summary>
        /// Used to guaranty exit
        /// </summary>
        private Control ParentControl { get; set; }

        private bool UIExit => ParentControl == null || ParentControl.IsDisposed || ParentControl.Disposing;

        public FlashSignal(Control control, int IntervalInMilliseconds, double _onRatio =0.5)
        {
            //Init variables
            ParentControl = control;
         
            //verify input interval
            if (IntervalInMilliseconds <= 0)
            {
                Exception e = new Exception("Invalid Interval Value.");
                throw e;
            }
            Interval = IntervalInMilliseconds;

            //Verify input ration
            if (_onRatio>=1|| _onRatio<=0)
            {
                Exception e = new Exception("Invalid Ratio Value.");
                throw e;
            }
            SignalOnRatio = _onRatio;

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
                State = true;
                DelayTimeWithExitFlag(IntervalON);

                //Off
                State = false;
                DelayTimeWithExitFlag(IntervalOFF);

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
