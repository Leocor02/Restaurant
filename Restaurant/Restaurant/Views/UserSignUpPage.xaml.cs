using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurant.ViewModels;
using Restaurant.Models;

namespace Restaurant.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserSignUpPage : ContentPage
	{
        UserViewModel viewModel;
		public UserSignUpPage ()
		{
			InitializeComponent ();
            //se agrega el bindingContext de la vista contra el viewModel
            BindingContext = viewModel = new UserViewModel ();

            LoadUserRolesList();
            LoadCountryList();
		}

        private async void LoadUserRolesList()
        {
            PckUserRole.ItemsSource = await viewModel.GetUserRoleList();
        }

        private async void LoadCountryList()
        {
            PckCountry.ItemsSource = await viewModel.GetCountryList();
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();    
        }

        //Descomentar después de arreglar el Txtactive
        //Método para verificar que todos los campos se llenen
        private bool UserInputValidation()
        {
            bool R = false;

            if (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim()) &&
                TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()) &&
                TxtBackUpEmail.Text != null && !string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()) &&
                TxtPhone.Text != null && !string.IsNullOrEmpty(TxtPhone.Text.Trim()) &&
                PckUserRole.SelectedIndex > -1 && PckCountry.SelectedIndex > -1)
            {
                R = true;
            }
            else
            {
                //en caso que alguna validación falle se le indica al usaurio que hace falta
                if (TxtName.Text == null || string.IsNullOrEmpty(TxtName.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Name is required", "Ok");
                    TxtName.Focus();
                    return false;
                }

                if (TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Email is required", "Ok");
                    TxtEmail.Focus();
                    return false;
                }

                if (TxtPassword.Text == null || string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Password is required", "Ok");
                    TxtPassword.Focus();
                    return false;
                }

                if (TxtBackUpEmail.Text == null || string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()))
                {
                    DisplayAlert("Validation error", "BackUp email is required", "Ok");
                    TxtBackUpEmail.Focus();
                    return false;
                }

                if (TxtPhone.Text == null || string.IsNullOrEmpty(TxtPhone.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Phone number is required", "Ok");
                    TxtPhone.Focus();
                    return false;
                }

                if (TxtActive.Text == null || string.IsNullOrEmpty(TxtActive.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Active is required", "Ok");
                    TxtActive.Focus();
                    return false;
                }

                if (PckUserRole.SelectedIndex == -1)
                {
                    DisplayAlert("Validation error", "User Role is required", "Ok");
                    PckUserRole.Focus();
                    return false;
                }

                if (PckCountry.SelectedIndex == -1)
                {
                    DisplayAlert("Validation error", "Country is required", "Ok");
                    PckCountry.Focus();
                    return false;
                }

            }

            return R;
        }


        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //Descomentar después de arreglar el Txtactive
            if (UserInputValidation())
            {
                //seleccionar el id de rol de usuario
                UserRole UsrRole = PckUserRole.SelectedItem as UserRole;
                int IdRol = UsrRole.IduserRole;

                //seleccionar el id del país
                Country country = PckCountry.SelectedItem as Country;
                int IdCountry = country.Idcountry;

                //pedir configuración de la acción a realizar

                var answer = await DisplayAlert("confirmation required", "¿Are you sure?", "Yes", "No");

                if (answer)
                {

                    bool Active = true;

                    bool R = await viewModel.AddNewUser(TxtName.Text.Trim(),
                                                TxtEmail.Text.Trim(),
                                                TxtPassword.Text.Trim(),
                                                TxtBackUpEmail.Text.Trim(),
                                                TxtPhone.Text.Trim(),
                                                //Descomentar después de arreglar el Txtactive
                                                IdRol,
                                                IdCountry,
                                                Active
                                                );

                    if (R)
                    {
                        await DisplayAlert(":)", "Everything is ok", "Ok");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert(":(", "Something went wrong", "Ok");
                    }
                }
            }
        }
    }
}