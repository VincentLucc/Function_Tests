using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;

namespace SocketTool_Framework.Forms
{
    public partial class AboutDialog : XtraForm
    {
        public AboutDialog()
        {
            InitializeComponent();

            Assembly assembly = Assembly.GetEntryAssembly();

            AssemblyProductAttribute productAttr = GetAssemblyAttribute<AssemblyProductAttribute>(assembly);
            if (productAttr != null) NameLabel.Text = productAttr.Product;

            AssemblyCopyrightAttribute copyrightAttr = GetAssemblyAttribute<AssemblyCopyrightAttribute>(assembly);
            if (copyrightAttr != null) CopyrightLabel.Text = copyrightAttr.Copyright;

            VersionLabel.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString(); ;

            EmailLabel.Text = "vincent.cc.lu@gmail.com";
        }

        public static T GetAssemblyAttribute<T>(Assembly assembly)
            where T : Attribute
        {
            object[] attributes =
                assembly.GetCustomAttributes(typeof(T), true);

            if ((attributes == null) || (attributes.Length == 0))
                return null;

            return (T)attributes[0];
        }
    }
}