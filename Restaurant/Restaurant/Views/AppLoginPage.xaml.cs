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
        UserViewModel userVM;
        public AppLoginPage()
        {
            InitializeComponent();
            this.BindingContext = userVM = new UserViewModel();
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
            if (TxtUserName.Text != null && !string.IsNullOrEmpty(TxtUserName.Text.Trim()) &&
               TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                try
                {
                    string email = TxtUserName.Text.Trim();
                    string password = TxtPassword.Text.Trim();
                    R = await userVM.UserAccessValidation(email, password);
                }
                catch (Exception)
                {



                    throw;
                }



            }
            else
            {
                await DisplayAlert("Validation error", "User and password is needed", "OK");
                return;
            }




            if (R)
            {
                try
                {
                    //todo: cargar info en un objeto global tipo user (o userDTO)
                    GlobalItems.GlobalUser = await userVM.getUserData(TxtUserName.Text.Trim());


                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                    return;
                }




                if (GlobalItems.GlobalUser.IduserRole == 1) {
                    await Navigation.PushAsync(new HomeAdmin());
                }else if (GlobalItems.GlobalUser.IduserRole == 2) {
                    await Navigation.PushAsync(new HomeClient());
                }
                else if (GlobalItems.GlobalUser.IduserRole == 3)
                {
                    await Navigation.PushAsync(new EmployeeHomePage());
                }
                else
                {
                   await DisplayAlert("Error!","El rol no corresponde, pongase en contacto con los administradores","ok");
                }
             
                TxtUserName.Text = "";
                TxtPassword.Text = "";
                //todo ; mostrar la page de seleccion de acciones del sistemas
            }
            else
            {
                await DisplayAlert(":c", "Incorrect Username or password", "OK");
            }
        }
    }
}