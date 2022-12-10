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

        private void Cancel_Clicked(object sender, EventArgs e)
        {

        }

        private void Cancel_Clicked_1(object sender, EventArgs e)
        {

        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();    
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (TxtName.Text.Trim() == "" || TxtEmail.Text.Trim() == "" 
                || TxtPassword.Text.Trim() == "" || TxtBackUpEmail.Text.Trim() == "" 
                || TxtPhone.Text.Trim() == "") {

                await DisplayAlert(":)", "Fill all the fields", "Ok");
                return;

            }

            int IdCountry = 1;

            Country countryid = PckCountry.SelectedItem as Country;



            IdCountry = countryid.Idcountry;

            bool R = await viewModel.AddNewUser(TxtName.Text.Trim(),
                                                TxtEmail.Text.Trim(),
                                                TxtPassword.Text.Trim(),
                                                TxtBackUpEmail.Text.Trim(),
                                                TxtPhone.Text.Trim(),
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