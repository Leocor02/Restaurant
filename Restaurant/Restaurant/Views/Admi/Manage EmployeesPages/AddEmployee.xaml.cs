using Restaurant.Models;
using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Views.Admi.Manage_Employees
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEmployee : ContentPage
    {
        UserViewModel viewModel;
        public AddEmployee()
        {
            InitializeComponent();

            BindingContext = viewModel = new UserViewModel();

            LoadCountryList();
        }

        private async void LoadCountryList()
        {
            PckCountry.ItemsSource = await viewModel.GetCountryList();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (TxtName.Text.Trim() == "" || TxtEmail.Text.Trim() == ""
                || TxtPassword.Text.Trim() == "" || TxtBackUpEmail.Text.Trim() == ""
                || TxtPhone.Text.Trim() == "")
            {

                await DisplayAlert("Validacion!", "Todos los espacios son requeridos", "Ok");
                return;

            }

            int IdCountry = 1;
            int rolID = 3;//id rol empleado

            Country countryid = PckCountry.SelectedItem as Country;



            IdCountry = countryid.Idcountry;

            bool R = await viewModel.AddNewUser(TxtName.Text.Trim(),
                                                TxtEmail.Text.Trim(),
                                                TxtPassword.Text.Trim(),
                                                TxtBackUpEmail.Text.Trim(),
                                                TxtPhone.Text.Trim(),
                                                rolID,
                                                IdCountry);

            if (R)
            {
                await DisplayAlert("Exito!", "Empleado Agregado Correctamente", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Hubo Un Error Al Intentar Agregar El Empleado", "Ok");
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}