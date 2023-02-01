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
    public partial class FormReloadTest : FormReloadBase
    {
        public static FormReloadTest instance;

        public FormReloadTest()
        {
            InitializeComponent();
        }

        public static DialogResult ShowReloadForm()
        {
            if (instance == null)
            {
                instance = new FormReloadTest();
            }

            return instance.ShowDialog();
        }
    }
}
