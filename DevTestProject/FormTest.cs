using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class FormTest : DevExpress.XtraEditors.XtraForm
    {

        public MailSample SampleData { get; set; }

        public FormTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitProperties();
        }

        private void FormTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClassPublic.winTest = null;
        }

        private void FormTest_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        
        /// <summary>
        /// Init property data
        /// </summary>
        private void InitProperties()
        {
            propertyGridControl1.ActiveViewType = DevExpress.XtraVerticalGrid.PropertyGridView.Office; //Set layout to be office type
            propertyDescriptionControl1.PropertyGrid = propertyGridControl1; //Set description panel                                                                                                        
            SampleData = new MailSample() {MailID=100, Title = "dfhaskjhfksdahfksdjhf", Sender = "dfasdfdsfad", Content = "dfsfsafdsf" };
            propertyGridControl1.SelectedObject = SampleData;

           
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {

        }
    }
}
