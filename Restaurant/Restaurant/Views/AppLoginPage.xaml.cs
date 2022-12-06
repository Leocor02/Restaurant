using Restaurant.ViewModels;
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
    public partial class AppLoginPage : ContentPage
    {
        UserViewModel vm;

        public AppLoginPage()
        {
            InitializeComponent();

            this.BindingContext = vm = new UserViewModel();
        }

        private void CmdWatchPassword(object sender, ToggledEventArgs e)
        {
            if (SwWatchPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }
        }

        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserSignUpPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool R = false;

            if (TxtUserName.Text != null && !string.IsNullOrEmpty(TxtUserName.Text) && 
                TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text))
            {
                string u = TxtUserName.Text;
                string p = TxtPassword.Text;

                R = await vm.UserAccessValidation(u, p);
            }
            else
            {
                await DisplayAlert("Validation error", "Username and password are required", "Ok");
                return;
            }

            if (R) 
            {
                await DisplayAlert(":)", "User Ok", "Ok");
                //TODO: mostrar página de selección de acciones en el sistema
            }
            else
            {
                await DisplayAlert(":(", "Incorrect Username or Password", "Ok");
            }
        }
    }
}