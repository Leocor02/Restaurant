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
    public partial class ShowEmployees : ContentPage
    {
        UserViewModel vm;
        bool isEditPage { get; set; }
        bool isDeletePage { get; set; }
        public ShowEmployees(bool isEdit, bool isDelete)
        {
            InitializeComponent();
            isEditPage = isEdit;
            isDeletePage  = isDelete;
            BindingContext = vm = new UserViewModel();

            LoadItemList();
        }

        private async void LoadItemList()
        {
            listEmployees.ItemsSource = await vm.GetEmployeeList();
        }

        private async void deleteEmployee(int userId)
        {
           bool response = await vm.deleteEmployee(userId);

            if (response)
            {
                await DisplayAlert("Exito", "Empleado Eliminado correctamente", "OK");

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Hubo un error al intentar eliminar el empleado", "OK");
            }
        }
        private async void listEmployees_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (isEditPage || isDeletePage) {
                var selectedItem = e.Item as UserDTO;

                if (selectedItem != null)
                {
                    if (isDeletePage)
                    {
                        var answer = await DisplayAlert("Confirmacion requerida!", "seguro que deseas eliminar este empleado?", "Yes", "Nop");

                        if (answer)
                        {
                            deleteEmployee(selectedItem.Iduser);
                        }
                    }
                     
                    if (isEditPage)
                    {
                        await DisplayAlert("Edit", selectedItem.Iduser.ToString(), "ok");
                    }
                }
            }
        }
    }
}