using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Diagram.Core;
using DevExpress.Utils;
using DevExpress.Utils.About;
using DevExpress.XtraDiagram;
using DevExpress.XtraDiagram.Designer;

namespace DevExpress.XtraDiagram.Demos {
    public partial class DesignerFrm : DiagramDesignerForm {
        public DesignerFrm() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            InitializeForm();
        }

        protected void InitializeForm() {
            Icon = LoadDefaultIcon();
            WindowState = FormWindowState.Maximized;
            AddSingleShape();
        }

        protected void AddSingleShape() {
            DiagramShape single = new DiagramShape(BasicShapes.Rectangle, 20, 20, 200, 100);
            Diagram.Items.Add(single);
            Diagram.SelectItem(single);
        }
		protected override Icon LoadDefaultIcon() {
            var assembly = typeof(DesignerFrm).Assembly;
            return ResourceImageHelper.CreateIconFromResources(assembly.GetManifestResourceNames().First(x => x.Contains("DemoIcon.ico")), assembly);
        }
    }
}
