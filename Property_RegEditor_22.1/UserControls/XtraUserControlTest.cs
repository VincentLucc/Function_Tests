using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.CustomEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Property_RegEditor_22._1
{
    public partial class RepositoryAnyUserControl : DevExpress.XtraEditors.XtraUserControl, IAnyControlEdit
    {

        public object EditValue { get; set; }

        public bool SupportsDraw { get; set; }

        public bool AllowBorder { get; set; }

        public bool AllowBitmapCache { get; set; }

        public event EventHandler EditValueChanged;

        public RepositoryAnyUserControl()
        {
            InitializeComponent();
        }



        public bool AllowClick(Point point)
        {
            return true;
        }

        public Size CalcSize(Graphics g)
        {
            return new Size(0, 0);
        }

        public void Draw(GraphicsCache cache, AnyControlEditViewInfo viewInfo)
        {
            
        }

        public string GetDisplayText(object EditValue)
        {
            return null;
        }

        public bool IsNeededKey(KeyEventArgs e)
        {
            return false;
        }

        public void SetupAsDrawControl()
        {
            
        }

        public void SetupAsEditControl()
        {
             
        }
    }
}
