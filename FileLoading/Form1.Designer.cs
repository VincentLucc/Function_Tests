
namespace FileLoading
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bLoad = new Sunny.UI.UIButton();
            this.lMessage = new Sunny.UI.UILabel();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.lProcessTime = new Sunny.UI.UILabel();
            this.lPath = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            this.bLoadPartial = new Sunny.UI.UIButton();
            this.bLoadProcessList = new Sunny.UI.UIButton();
            this.bLoadThread = new Sunny.UI.UIButton();
            this.bLoadProcess = new Sunny.UI.UIButton();
            this.bTRackerLoad = new Sunny.UI.UIButton();
            this.bLoadUnManaged = new Sunny.UI.UIButton();
            this.bLoadOnly = new Sunny.UI.UIButton();
            this.uiTitlePanel1.SuspendLayout();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.uiTitlePanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bLoad
            // 
            this.bLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLoad.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoad.Location = new System.Drawing.Point(32, 62);
            this.bLoad.MinimumSize = new System.Drawing.Size(1, 1);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(134, 35);
            this.bLoad.TabIndex = 0;
            this.bLoad.Text = "Load All Bytes";
            this.bLoad.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoad.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // lMessage
            // 
            this.lMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMessage.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lMessage.Location = new System.Drawing.Point(235, 157);
            this.lMessage.Name = "lMessage";
            this.lMessage.Size = new System.Drawing.Size(527, 68);
            this.lMessage.TabIndex = 1;
            this.lMessage.Text = "N/A";
            this.lMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lMessage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.uiTableLayoutPanel1);
            this.uiTitlePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanel1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel1.Location = new System.Drawing.Point(0, 236);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.Size = new System.Drawing.Size(786, 282);
            this.uiTitlePanel1.TabIndex = 3;
            this.uiTitlePanel1.Text = "Load Result";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 4;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.45218F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.54782F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel1.Controls.Add(this.lProcessTime, 2, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.lPath, 2, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.lMessage, 2, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel2, 1, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel1, 1, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel3, 1, 2);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 5;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.01361F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.65306F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(786, 247);
            this.uiTableLayoutPanel1.TabIndex = 0;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // lProcessTime
            // 
            this.lProcessTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lProcessTime.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lProcessTime.Location = new System.Drawing.Point(235, 90);
            this.lProcessTime.Name = "lProcessTime";
            this.lProcessTime.Size = new System.Drawing.Size(527, 67);
            this.lProcessTime.TabIndex = 6;
            this.lProcessTime.Text = "N/A";
            this.lProcessTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lProcessTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lPath
            // 
            this.lPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lPath.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lPath.Location = new System.Drawing.Point(235, 20);
            this.lPath.Name = "lPath";
            this.lPath.Size = new System.Drawing.Size(527, 70);
            this.lPath.TabIndex = 4;
            this.lPath.Text = "N/A";
            this.lPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiLabel2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(76, 43);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 3;
            this.uiLabel2.Text = "Path:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(66, 160);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(120, 61);
            this.uiLabel1.TabIndex = 2;
            this.uiLabel1.Text = "Message:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiLabel3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(59, 112);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(134, 23);
            this.uiLabel3.TabIndex = 5;
            this.uiLabel3.Text = "Process Time:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTitlePanel2
            // 
            this.uiTitlePanel2.Controls.Add(this.bLoadOnly);
            this.uiTitlePanel2.Controls.Add(this.bLoadUnManaged);
            this.uiTitlePanel2.Controls.Add(this.bTRackerLoad);
            this.uiTitlePanel2.Controls.Add(this.bLoadPartial);
            this.uiTitlePanel2.Controls.Add(this.bLoadProcessList);
            this.uiTitlePanel2.Controls.Add(this.bLoadThread);
            this.uiTitlePanel2.Controls.Add(this.bLoadProcess);
            this.uiTitlePanel2.Controls.Add(this.bLoad);
            this.uiTitlePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTitlePanel2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel2.Location = new System.Drawing.Point(0, 35);
            this.uiTitlePanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel2.Name = "uiTitlePanel2";
            this.uiTitlePanel2.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel2.ShowText = false;
            this.uiTitlePanel2.Size = new System.Drawing.Size(786, 201);
            this.uiTitlePanel2.TabIndex = 4;
            this.uiTitlePanel2.Text = "Load Methods";
            this.uiTitlePanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // bLoadPartial
            // 
            this.bLoadPartial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLoadPartial.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoadPartial.Location = new System.Drawing.Point(262, 62);
            this.bLoadPartial.MinimumSize = new System.Drawing.Size(1, 1);
            this.bLoadPartial.Name = "bLoadPartial";
            this.bLoadPartial.Size = new System.Drawing.Size(187, 35);
            this.bLoadPartial.TabIndex = 4;
            this.bLoadPartial.Text = "Load & Process Partial";
            this.bLoadPartial.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoadPartial.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bLoadPartial.Click += new System.EventHandler(this.bLoadPartial_Click);
            // 
            // bLoadProcessList
            // 
            this.bLoadProcessList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLoadProcessList.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoadProcessList.Location = new System.Drawing.Point(32, 152);
            this.bLoadProcessList.MinimumSize = new System.Drawing.Size(1, 1);
            this.bLoadProcessList.Name = "bLoadProcessList";
            this.bLoadProcessList.Size = new System.Drawing.Size(216, 35);
            this.bLoadProcessList.TabIndex = 3;
            this.bLoadProcessList.Text = "Load & Process List";
            this.bLoadProcessList.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoadProcessList.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bLoadProcessList.Click += new System.EventHandler(this.bLoadProcessList_Click);
            // 
            // bLoadThread
            // 
            this.bLoadThread.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLoadThread.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoadThread.Location = new System.Drawing.Point(262, 111);
            this.bLoadThread.MinimumSize = new System.Drawing.Size(1, 1);
            this.bLoadThread.Name = "bLoadThread";
            this.bLoadThread.Size = new System.Drawing.Size(134, 35);
            this.bLoadThread.TabIndex = 2;
            this.bLoadThread.Text = "Load in Thread";
            this.bLoadThread.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoadThread.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bLoadThread.Click += new System.EventHandler(this.bLoadThread_Click);
            // 
            // bLoadProcess
            // 
            this.bLoadProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLoadProcess.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoadProcess.Location = new System.Drawing.Point(32, 111);
            this.bLoadProcess.MinimumSize = new System.Drawing.Size(1, 1);
            this.bLoadProcess.Name = "bLoadProcess";
            this.bLoadProcess.Size = new System.Drawing.Size(216, 35);
            this.bLoadProcess.TabIndex = 1;
            this.bLoadProcess.Text = "Load & Process DataTable";
            this.bLoadProcess.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoadProcess.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bLoadProcess.Click += new System.EventHandler(this.bLoadProcess_Click);
            // 
            // bTRackerLoad
            // 
            this.bTRackerLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bTRackerLoad.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bTRackerLoad.Location = new System.Drawing.Point(478, 62);
            this.bTRackerLoad.MinimumSize = new System.Drawing.Size(1, 1);
            this.bTRackerLoad.Name = "bTRackerLoad";
            this.bTRackerLoad.Size = new System.Drawing.Size(164, 35);
            this.bTRackerLoad.TabIndex = 5;
            this.bTRackerLoad.Text = "Load In Tacker";
            this.bTRackerLoad.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bTRackerLoad.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bTRackerLoad.Click += new System.EventHandler(this.bTRackerLoad_Click);
            // 
            // bLoadUnManaged
            // 
            this.bLoadUnManaged.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLoadUnManaged.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoadUnManaged.Location = new System.Drawing.Point(478, 111);
            this.bLoadUnManaged.MinimumSize = new System.Drawing.Size(1, 1);
            this.bLoadUnManaged.Name = "bLoadUnManaged";
            this.bLoadUnManaged.Size = new System.Drawing.Size(240, 35);
            this.bLoadUnManaged.TabIndex = 6;
            this.bLoadUnManaged.Text = "Load In Tacker (Unmanaged)";
            this.bLoadUnManaged.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoadUnManaged.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bLoadUnManaged.Click += new System.EventHandler(this.bLoadUnManaged_Click);
            // 
            // bLoadOnly
            // 
            this.bLoadOnly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLoadOnly.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoadOnly.Location = new System.Drawing.Point(478, 152);
            this.bLoadOnly.MinimumSize = new System.Drawing.Size(1, 1);
            this.bLoadOnly.Name = "bLoadOnly";
            this.bLoadOnly.Size = new System.Drawing.Size(164, 35);
            this.bLoadOnly.TabIndex = 7;
            this.bLoadOnly.Text = "Load Only";
            this.bLoadOnly.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bLoadOnly.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bLoadOnly.Click += new System.EventHandler(this.bLoadOnly_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(786, 518);
            this.Controls.Add(this.uiTitlePanel1);
            this.Controls.Add(this.uiTitlePanel2);
            this.Name = "Form1";
            this.Text = "Loading";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiTitlePanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton bLoad;
        private Sunny.UI.UILabel lMessage;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private Sunny.UI.UILabel lPath;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel lProcessTime;
        private Sunny.UI.UIButton bLoadProcess;
        private Sunny.UI.UIButton bLoadThread;
        private Sunny.UI.UIButton bLoadProcessList;
        private Sunny.UI.UIButton bLoadPartial;
        private Sunny.UI.UIButton bTRackerLoad;
        private Sunny.UI.UIButton bLoadUnManaged;
        private Sunny.UI.UIButton bLoadOnly;
    }
}

