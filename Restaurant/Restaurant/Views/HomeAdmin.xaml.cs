using Restaurant.Models;
using Restaurant.Models.DTO;
using Restaurant.ViewModels;
using Restaurant.Views.Admi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeAdmin : ContentPage
    {
        public HomeAdmin()
        {
            InitializeComponent();
            this.Title = "Bienvenido! " + GlobalItems.GlobalUser.Name;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert(":v",GlobalItems.GlobalUser.Name,"ok");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //btn Administrar empleados
            await Navigation.PushAsync(new ManageEmployeesPage());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            //btn Administrar Mesas
            await Navigation.PushAsync(new ManageTablesPage());
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            //btn Ver Reservaciones
            await Navigation.PushAsync(new ShowRevervationsPage());
        }

        private async void Button_Clicked_4(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManageDishes());
        }
    }
}