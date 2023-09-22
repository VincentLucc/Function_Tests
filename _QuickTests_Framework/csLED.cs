using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _QuickTests_Framework
{
    public class csLED
    {
        /// <summary>
        /// Class enable/disable flag
        /// </summary>
        private bool ClassEnable { get; set; }
        public bool SignalState { get; set; }   //ON/OFF status
        private int Interval { get; set; } //Interval for each gap

        /// <summary>
        /// Division of the signal
        /// </summary>
        private int Division { get; set; } 



        /// <summary>
        /// Used to mark current LED states
        /// </summary>
        public bool LEDGreenState { get; set; } 
        public bool LEDRedState { get; set; } 

        /// <summary>
        /// Signal loop thread
        /// </summary>
        private Thread tSignal { get; set; } 
        /// <summary>
        /// Watch used to count time
        /// </summary>
        private Stopwatch Watch { get; set; } 

        /// <summary>
        /// Used to guaranty exit
        /// </summary>
        private Control ParentControl { get; set; }

        private bool UIExit => ParentControl == null || ParentControl.IsDisposed || ParentControl.Disposing;

        public csLED(Control control, int IntervalInMilliseconds,  int iDivision)
        {
            //Init variables
            ParentControl = control;
            Watch = new Stopwatch();
            Division = iDivision;

            //verify input
            if (IntervalInMilliseconds <= 0)
            {
                Exception e = new Exception("Invalid Interval Value.");
                throw e;
            }
            Interval = IntervalInMilliseconds / iDivision;

            //start counting thread
            tSignal = new Thread(ProcessSignal);
            ClassEnable = true;
            tSignal.IsBackground = true;
            tSignal.Start();
        }

        /// <summary>
        /// Signal loop process
        /// </summary>
        private void ProcessSignal()
        {
            while (ClassEnable)
            {
                //Auto exit
                if (UIExit) return;

                //On
                SignalState = true;
                DelayTimeWithExitFlag(Interval);

                //Off
                SignalState = false;
                DelayTimeWithExitFlag(Interval*(Division-1));             
            }
        }

        public void Stop()
        {
            ClassEnable = false;
        }

        private void DelayTimeWithExitFlag(int ms)
        {
            Watch.Restart();
            while (Watch.ElapsedMilliseconds < ms)
            {
                Thread.Sleep(5);

                //Exist flag
                if (!ClassEnable || UIExit) return;
            }
        }
    }
}
