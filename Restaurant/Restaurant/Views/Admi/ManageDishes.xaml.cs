using Restaurant.Views.Admi.Manage_Dishes;
using Restaurant.Views.Admi.Manage_Tables_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Views.Admi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageDishes : ContentPage
    {
        public ManageDishes()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddDishes());
        }
    }
}