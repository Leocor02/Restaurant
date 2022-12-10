using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Views.Admi.Manage_Tables_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addTable : ContentPage
    {
        public addTable()
        {
            InitializeComponent();
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {

        }
    }
}