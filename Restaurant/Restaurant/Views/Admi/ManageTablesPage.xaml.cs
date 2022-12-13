using Restaurant.Views.Admi.Manage_Employees;
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
    public partial class ManageTablesPage : ContentPage
    {
        public ManageTablesPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //btn agregar mesa
            await Navigation.PushAsync(new addTable());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //btn ver mesas
            await Navigation.PushAsync(new ShowTable(false));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            //btn editar mesa
            await Navigation.PushAsync(new ShowTable(true));
        }
    }
}