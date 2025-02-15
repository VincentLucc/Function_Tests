﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperationBlock
{
    public partial class FormMain : Form
    {

        public LoopBlocker Blocker { get; set; }

        public ButtonOperationGroup ButtonOperation { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
            t1.Interval = 100;
            t1.Tick += T1_Tick;
            t1.Start();


            Blocker = new LoopBlocker();
            ButtonOperation = new ButtonOperationGroup();

            bButtonBlock2.MouseDown += BButtonBlock2_MouseDown;
        }

        private void BButtonBlock2_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private async void bButtonBlock_Click(object sender, EventArgs e)
        {
            if (!ButtonOperation.RequestButtonOperation("bButtonBlock_Click")) return;

            await Task.Delay(3000);

            //Finish up
            ButtonOperation.IsOperating = false;
        }

        private async void bButtonBlock2_Click(object sender, EventArgs e)
        {
            if (!ButtonOperation.RequestButtonOperation("bButtonBlock2_Click")) return;

            await Task.Delay(3000);

            //Finish up
            ButtonOperation.IsOperating = false;
        }

        private async void T1_Tick(object sender, EventArgs e)
        {
            //Add overflow protection
            var t1 = (System.Windows.Forms.Timer)sender;
            t1.Enabled = false;

            //Check pause flag
            if (Blocker.EnableBlock)
            {
                Blocker.IsBlocked = true;
                t1.Enabled = true;
                return;
            }

            await Task.Delay(300);
            Debug.WriteLine("Did sth 1");

            //Operation trigger
            if (Blocker.EnableBlock)
            {
                t1.Enabled = true;
                return;
            }
            await Task.Delay(300);
            Debug.WriteLine("Did sth 2");

            //Operation trigger
            if (Blocker.EnableBlock)
            {
                t1.Enabled = true;
                return;
            }
            await Task.Delay(300);
            Debug.WriteLine("Did sth 3");

            //Operation trigger
            if (Blocker.EnableBlock)
            {
                t1.Enabled = true;
                return;
            }
            await Task.Delay(300);
            Debug.WriteLine("Did sth 4");

            //Operation trigger
            if (Blocker.EnableBlock)
            {
                t1.Enabled = true;
                return;
            }
            await Task.Delay(300);
            Debug.WriteLine("Did sth 5");

            t1.Enabled = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Blocker.StartBlock();
            await Blocker.WaitForBlockAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Blocker.EnableBlock = false;
        }


    }
}
