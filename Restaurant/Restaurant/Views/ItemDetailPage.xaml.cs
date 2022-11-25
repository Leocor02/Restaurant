using Restaurant.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Restaurant.Views
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