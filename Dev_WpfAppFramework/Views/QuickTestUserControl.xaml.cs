using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dev_WpfAppFramework.Views
{
    /// <summary>
    /// Interaction logic for QuickTestUserControl.xaml
    /// </summary>
    public partial class QuickTestUserControl : UserControl
    {
        public string TestStr1 { get; set; } = "Value1";

        public QuickTestUserControl()
        {
            InitializeComponent();
        }
    }
}
