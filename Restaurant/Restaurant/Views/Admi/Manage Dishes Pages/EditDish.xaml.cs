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
    public partial class EditDish : ContentPage
    {
        DishViewModel viewModel;
        public int idDishVM { get; set; }
        public EditDish(int idDish)
        {
            InitializeComponent();
            BindingContext = viewModel = new DishViewModel();
            LoadCountryList();
            LoadDishData(idDish);
            idDishVM = idDish;
        }

        private async void LoadCountryList()
        {
            PckCountry.ItemsSource = await viewModel.GetCountryList();
        }

        private async void LoadDishData(int idDish)
        {
            DishDTO dishdto = await viewModel.GetDishData(idDish);
            txtItemPicture.Text = dishdto.ItemPictureUrl;
            txtDishDescription.Text = dishdto.DishDescription;
            PckCountry.SelectedIndex = dishdto.Idcountry;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (txtItemPicture.Text == null || string.IsNullOrEmpty(txtItemPicture.Text.Trim()) ||
               txtDishDescription.Text == null || string.IsNullOrEmpty(txtDishDescription.Text.Trim()) ||
               PckCountry.SelectedIndex == -1)
            {
                await DisplayAlert("Validacion!", "Todos los espacios son requeridos", "ok");
                return;
            }

            int idCountry = 0;

            Country countryid = PckCountry.SelectedItem as Country;

            idCountry = countryid.Idcountry;

            bool R = await viewModel.EditDish(
                idDishVM,
                txtItemPicture.Text.Trim(),
                txtDishDescription.Text.Trim(),
                idCountry);

            if (R)
            {
                await DisplayAlert("Exito!", "Platillo Modificado Correctamente", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Hubo Un Error Al Intentar Agregar El Platillo", "Ok");
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}