using Restaurant.Models;
using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Views.Admi.Manage_Tables_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addTable : ContentPage
    {
        
        TableViewModel viewModel;
        public addTable()
        {
            InitializeComponent();
            BindingContext = viewModel = new TableViewModel();
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            int floorId = 0;
            string floorSelectedName = pickerFloor.SelectedItem as string;
            
            switch (floorSelectedName) {
                case "Primer Piso":
                    floorId = 1;    
                    break;
                case "Segundo Piso":
                    floorId = 2;
                    break;
                case "Terraza":
                    floorId = 3;
                    break;
            }

            if (floorId == 0 || (txtQuantity.Text == null || string.IsNullOrEmpty(txtQuantity.Text.Trim()))) {
               await DisplayAlert("Validacion!", "todos los campos son requeridos", "ok");
                return;
            }

            bool R = await viewModel.AddNewTable(floorId, Int32.Parse(txtQuantity.Text.Trim()));

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