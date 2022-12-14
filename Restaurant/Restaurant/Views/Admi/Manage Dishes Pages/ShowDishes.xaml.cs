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

namespace Restaurant.Views.Admi.Manage_Dishes_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowDishes : ContentPage
    {
        bool isEditPage { get; set; }
        bool isDeletePage { get; set; }

        DishViewModel vm;
        public ShowDishes(bool isEdit, bool isDelete)
        {
            InitializeComponent();
            isEditPage = isEdit;
            isDeletePage = isDelete;
            BindingContext = vm = new DishViewModel();
            LoadItemList();
        }

        private async void LoadItemList()
        {
            listDishes.ItemsSource = await vm.GetDishesList();
        }
        private async void deleteDish(int idDish) {

            bool response = await vm.deleteDish(idDish);

            if (response)
            {
                await DisplayAlert("Exito", "Platillo Eliminado correctamente", "OK");

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Hubo un error al intentar eliminar el platillo", "OK");
            }

        }
        private async void listDishes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (isEditPage || isDeletePage)
            {
                var selectedItem = e.Item as DishDTO;

                if (selectedItem != null)
                {
                    if (isDeletePage)
                    {
                        var answer = await DisplayAlert("Confirmacion requerida!", "seguro que deseas eliminar este platillo?", "Yes", "Nop");

                        if (answer)
                        {
                            deleteDish(selectedItem.Iddish);
                        }
                    }

                    if (isEditPage)
                    {
                        await DisplayAlert("Edit", selectedItem.Iddish.ToString(), "ok");
                    }
                }
            }
        }
    }
}