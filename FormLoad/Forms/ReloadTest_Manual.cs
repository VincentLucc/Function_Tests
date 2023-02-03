using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLoad
{
    public partial class ReloadTest_Manual : FormReloadBaseManual
    {
        public static ReloadTest_Manual instance;

        public ReloadTest_Manual()
        {
            InitializeComponent();
        }

        public static DialogResult ShowReloadForm()
        {
            if (instance == null)
            {
                instance = new ReloadTest_Manual();
            }

            return instance.ShowDialog();
        }
    }
}
