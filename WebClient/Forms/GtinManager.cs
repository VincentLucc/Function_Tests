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
using WebClient.Forms;

namespace WebClient
{
    public partial class GtinManager : DevExpress.XtraEditors.XtraForm
    {
        public GtinManager()
        {
            InitializeComponent();
        }

        private void GtinManager_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = csConfigureHelper.config.GTINs;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (GTINEditForm gtinEdit = new GTINEditForm(null))
            {
                if (gtinEdit.ShowDialog() == DialogResult.OK)
                {
                    csConfigureHelper.config.GTINs.Add(gtinEdit.GTINInfo);
                }
            }
        }

        private void DeleteButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


    }
}