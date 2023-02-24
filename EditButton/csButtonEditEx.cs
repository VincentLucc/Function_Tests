using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditButton
{

    /// <summary>
    /// Avoid ButtonClick triggred cnacelled by the dialog event
    /// </summary>
    [ToolboxItem(true)]
    public class csButtonEditEx : ButtonEdit
    {
        /// <summary>
        /// Handle the click and button click event
        /// 
        /// </summary>
        public event InternalClickedEventHandler CustomClicked;

        public delegate void InternalClickedEventHandler(object sender, ButtonPressedEventArgs e);

        /// <summary>
        /// Make sure invoke method only trigger once
        /// </summary>
        public bool AllowRaiseClick;

        private ButtonPressedEventArgs clickParameter;
        public csButtonEditEx()
        {
            this.Click += CsEditButtonEx_Click;
            this.ButtonClick += CsButtonEditEx_ButtonClick;
        }

        private void CsButtonEditEx_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            InvokeCustomClick(e);
        }

        private void CsEditButtonEx_Click(object sender, EventArgs e)
        {
            InvokeCustomClick(null);
        }


        /// <summary>
        /// Trigger only once when button clicked
        /// </summary>
        /// <param name="e"></param>
        public void InvokeCustomClick(ButtonPressedEventArgs e)
        {
            //Limit event to only trigger once 
            AllowRaiseClick = true;
            clickParameter = e;

            //Action will start to process when click && button click events both finished
            this.BeginInvoke(new Action(() => {
                if (AllowRaiseClick)
                {
                    AllowRaiseClick = false;
                    CustomClicked?.Invoke(this, clickParameter);
                }
            }));
        }
    }
}
