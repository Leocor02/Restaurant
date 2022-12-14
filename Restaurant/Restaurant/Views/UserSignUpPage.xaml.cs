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

            LoadCountryList();
		}

        private async void LoadCountryList()
        {
            PckCountry.ItemsSource = await viewModel.GetCountryList();
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();    
        }

        private bool UserInputValidation()
        {
            bool R = false;

            if (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim()) &&
                TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()) &&
                TxtBackUpEmail.Text != null && !string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()) &&
                TxtPhone.Text != null && !string.IsNullOrEmpty(TxtPhone.Text.Trim()))
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
            if (TxtName.Text == null || string.IsNullOrEmpty(TxtName.Text.Trim()) || 
                TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()) ||
                TxtPassword.Text == null || string.IsNullOrEmpty(TxtPassword.Text.Trim()) ||
                TxtBackUpEmail.Text == null || string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()) ||
                TxtPhone.Text.Trim() == null || string.IsNullOrEmpty(TxtPhone.Text.Trim()) ||
                PckCountry.SelectedIndex == -1) {

                await DisplayAlert(":)", "Fill all the fields", "Ok");
                return;

            }

            int IdCountry;
            int rolID = 2;//id rol cliente

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