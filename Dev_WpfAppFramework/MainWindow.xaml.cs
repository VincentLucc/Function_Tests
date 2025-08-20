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

namespace Dev_WpfAppFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<csAccordingItem> accordingItems = new List<csAccordingItem>();

        public MainWindow()
        {
            InitializeComponent();

            //Events
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ////Prepare data
            //for (int i = 0; i < 3; i++)
            //{
            //    var newItem = new csAccordingItem() { Name=$"Name_{i.ToString("d2")}"};
            //    accordingItems.Add(newItem);
            //}

            //accordion01.ItemsSource = accordingItems;
        }
    }
}
