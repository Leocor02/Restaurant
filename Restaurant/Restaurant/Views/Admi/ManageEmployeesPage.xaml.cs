using Restaurant.Views.Admi.Manage_Employees;
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
    public partial class ManageEmployeesPage : ContentPage
    {
        public ManageEmployeesPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //btn agregar empleado
            await Navigation.PushAsync(new AddEmployee());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //btn ver empleados
            await Navigation.PushAsync(new ShowEmployees(false,false));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            //btn eliminar empleado
            await Navigation.PushAsync(new ShowEmployees(false, true));
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            //btn editar empleado
            await Navigation.PushAsync(new ShowEmployees(true, false));
        }
    }
}