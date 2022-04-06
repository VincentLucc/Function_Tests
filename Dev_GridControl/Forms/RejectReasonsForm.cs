using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridControl
{
    public partial class RejectReasonsForm : Form
    {
        public RejectReasonsForm()
        {
            InitializeComponent();
        }

        private void RejectReasonsForm_Load(object sender, EventArgs e)
        {
            var sampleData = CreateSampleData();
            gridControl1.DataSource = sampleData;
        }


        private List<AuxInfoView> CreateSampleData()
        {
            List<AuxInfoView> infoList = new List<AuxInfoView>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    AuxInfoView info = new AuxInfoView();
                    info.DeviceName = $"Device_{i}";
                    info.TagReason = $"Reason_{j}";
                    info.NumberOfTaggedProducts = i * j;
                    //info.
                    //infoList.Add(info);
                }
            }

            return infoList;
        }
    }
}
