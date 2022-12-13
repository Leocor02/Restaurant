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
    public partial class ShowEmployees : ContentPage
    {
        UserViewModel vm;
        public ShowEmployees()
        {
            InitializeComponent();

            BindingContext = vm = new UserViewModel();

            LoadItemList();
        }

        private async void LoadItemList()
        {
            listEmployees.ItemsSource = await vm.GetEmployeeList();
        }

        private async void listEmployees_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as UserDTO;

            if (selectedItem != null)
            {
               await  DisplayAlert("ID", selectedItem.Iduser.ToString(), "ok");
            }
        }
    }
}