using Restaurant.Views.Admi.Manage_Dishes;
using Restaurant.Views.Admi.Manage_Dishes_Pages;
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
            //btn agregar platillo
            await Navigation.PushAsync(new AddDishes());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //btn ver platillos
            await Navigation.PushAsync(new ShowDishes(false,false));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            //btn modificar platillos
            await Navigation.PushAsync(new ShowDishes(true, false));
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            //btn eliminar platillo
            await Navigation.PushAsync(new ShowDishes(false,true));
        }
    }
}