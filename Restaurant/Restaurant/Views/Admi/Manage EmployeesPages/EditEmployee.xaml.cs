using Restaurant.Models;
using Restaurant.Models.DTO;
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
    public partial class EditEmployee : ContentPage
    {
        UserViewModel viewModel;
        public int idUserVM { get; set; }
        public EditEmployee(int idUser)
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
            LoadCountryList();
            LoadEmployeeData(idUser);
            idUserVM = idUser;
        }

        private async void LoadCountryList()
        {
            PckCountry.ItemsSource = await viewModel.GetCountryList();
        }

        private async void LoadEmployeeData(int idUser)
        {
            UserDTO userdto = await viewModel.GetEmployeeData(idUser);
            TxtName.Text = userdto.Name;
            TxtEmail.Text = userdto.Email;
            TxtPassword.Text = userdto.UserPassword;
            TxtBackUpEmail.Text = userdto.BackUpEmail;
            TxtPhone.Text = userdto.PhoneNumber;
            PckCountry.SelectedIndex = userdto.Idcountry;
            //todo preguntar por como cambiar la vaina sin enviar las contrasenia
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}