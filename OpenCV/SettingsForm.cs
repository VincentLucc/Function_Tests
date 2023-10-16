using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Sharp4
{
    public partial class SettingsForm : DevExpress.XtraEditors.XtraForm
    {
        csPropertyHelper propertyHelper;
        object currentSettings;

 
        public SettingsForm(object settings)
        {
            InitializeComponent();
            currentSettings = settings;
        }



        private void OKSimpleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            propertyHelper = new csPropertyHelper(propertyGridControl1);
            propertyHelper.propertyGrid.SelectedObject = currentSettings;
        }
    }
}