using System.ComponentModel;
using Xamarin.Forms;
using XamarinFormTest.ViewModels;

namespace XamarinFormTest.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}