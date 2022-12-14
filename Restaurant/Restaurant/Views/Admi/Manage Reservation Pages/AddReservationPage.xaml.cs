using Restaurant.Models;
using Restaurant.Models.DTO;
using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Restaurant.Views.Admi.Manage_Reservation_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddReservationPage : ContentPage
    {
        TableViewModel vm;
        ReservationViewModel vmR;
        public AddReservationPage()
        {
            InitializeComponent();
            BindingContext = vm = new TableViewModel();
            vmR = new ReservationViewModel();
            LoadTablesList();
        }

        private async void LoadTablesList()
        {
            pickerTable.ItemsSource = await vm.GetTablesList();
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            var selectedItem = datePicker.Date.ToString("dd-MM-yyyy");

            if (txtDinnersQuantity.Text == null || string.IsNullOrEmpty(txtDinnersQuantity.Text.Trim()) ||
                pickerTable.SelectedIndex == -1 ||
                datePicker.Date.ToString() == null || string.IsNullOrEmpty(datePicker.Date.ToString())) {

                await DisplayAlert(":)", "Fill all the fields", "Ok");
                return;
            }

            if (datePicker.Date < DateTime.Now) {
                await DisplayAlert(":)", "la fecha de reservacion debe ser un dia siguiente a la fecha actual", "Ok");
                return;
            }


            int tableIdSelected = 0;

            TableDTO tableId = pickerTable.SelectedItem as TableDTO;

            if (Int32.Parse(txtDinnersQuantity.Text.Trim()) > tableId.ChairQuantity) {
                await DisplayAlert(":)", "la cantidad de personas no puede superar la cantidad maxima de la mesa", "Ok");
                return;
            }


            tableIdSelected = tableId.Idtable;

            bool R = await vmR.AddNewReservation(
                datePicker.Date,
                Int32.Parse(txtDinnersQuantity.Text.Trim()),
               tableIdSelected
                );

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