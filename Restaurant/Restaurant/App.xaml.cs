using Restaurant.Services;
using Restaurant.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //Vista en la cual inicia el app
            MainPage = new NavigationPage(new AppLoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
