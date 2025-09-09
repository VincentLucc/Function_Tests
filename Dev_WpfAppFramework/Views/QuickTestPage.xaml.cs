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
    /// Interaction logic for QuickTestPage.xaml
    /// </summary>
    public partial class QuickTestPage : Page
    {
        public string TestProperty01 { get; set; } = "TestValue1";
        public QuickTestPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
