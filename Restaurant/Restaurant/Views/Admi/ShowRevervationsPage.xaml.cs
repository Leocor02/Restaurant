using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Views.Admi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowRevervationsPage : ContentPage
    {
        ReservationViewModel vm;
        public ShowRevervationsPage(bool listUserReservationsOnly)
        {
            InitializeComponent();
            BindingContext = vm = new ReservationViewModel();
            LoadItemList(listUserReservationsOnly);
        }

        private async void LoadItemList(bool listUserReservationsOnly)
        {
            listReservations.ItemsSource = await vm.GetAllReservationsList(listUserReservationsOnly);
        }
    }
}