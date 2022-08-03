using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevDispose
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(teCount.Text, out int iCount))
            {
                for (int i = 0; i < iCount; i++)
                {
                    //FormEmpty empty = new FormEmpty();
                    //empty.ShowDialog();
                    //empty.Close();
                    //empty.Dispose();

                    using (FormEmpty empty = new FormEmpty())
                    {
                        empty.ShowDialog();
                        empty.Close();
                    }


                    // Ryn an operation with leakyObject
                    GC.Collect();
                }

                //Parallel.For(0, iCount, i => {

                //    using (FormEmpty empty = new FormEmpty())
                //    {
                //        empty.ShowDialog();
                //        //empty.Dispose();
                //        //GC.SuppressFinalize(empty);
                //    }
                //});
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }

        private void teCount_EditValueChanged(object sender, EventArgs e)
        {

           
        }
    }
}
