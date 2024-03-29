﻿
using Dev_GridControl_19_1.Forms;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridControl_19_1
{
    public partial class FormMain : XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

          
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GroupView view = new GroupView();
            view.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomEditor customEditor = new CustomEditor();
            customEditor.StartPosition = FormStartPosition.CenterParent;
            customEditor.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            CardViews winCard = new CardViews();
            winCard.StartPosition = FormStartPosition.CenterParent;
            winCard.ShowDialog();
        }

        private void bRejectReasons_Click(object sender, EventArgs e)
        {
            var winReject = new RejectReasonsForm();
            winReject.Show();
        }

        private void bBigDataUpdate_Click(object sender, EventArgs e)
        {
            BigDataUpdate winBigData = new BigDataUpdate();
            winBigData.Show();

        }

        private void bTileView_Click(object sender, EventArgs e)
        {
            TileView winTile = new TileView();
            winTile.Show();
        }

        private void bSizeCompare_Click(object sender, EventArgs e)
        {
            using (CollectionSourceForm collectionForm = new CollectionSourceForm())
            {
                collectionForm.ShowDialog();
            }  
        }

        private void bEditForm_Click(object sender, EventArgs e)
        {
            using (EditForm editForm = new EditForm())
            {
                editForm.StartPosition = FormStartPosition.CenterParent;
                editForm.ShowDialog();
            }
        }

        private void bTooltip_Click(object sender, EventArgs e)
        {
            var winTooltip = new FormToolTip();
            winTooltip.ShowDialog();
        }

        private void bOfficeCompact_Click(object sender, EventArgs e)
        {
            using (TileView_OfficeCompact office=new TileView_OfficeCompact())
            {
                office.ShowDialog();
            }
        }
    }
}
