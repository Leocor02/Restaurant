﻿using Restaurant.Views.Admi;
using Restaurant.Views.Admi.Manage_Dishes_Pages;
using Restaurant.Views.Admi.Manage_Reservation_Pages;
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
    public partial class HomeClient : ContentPage
    {
        public HomeClient()
        {
            InitializeComponent();
            this.Title = "Bienvenido! " + GlobalItems.GlobalUser.Name;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddReservationPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowDishes(false,false));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowRevervationsPage(true));
        }
    }
}