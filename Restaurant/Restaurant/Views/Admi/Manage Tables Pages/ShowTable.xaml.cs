using Restaurant.Models.DTO;
using Restaurant.ViewModels;
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
    public partial class ShowTable : ContentPage
    {
        TableViewModel vm;

        bool isEditPage { get; set; }

        public ShowTable(bool isEdit)
        {
            InitializeComponent();
            isEditPage = isEdit;
            BindingContext = vm = new TableViewModel();
            LoadItemList();
        }

        private async void LoadItemList()
        {
            listTables.ItemsSource = await vm.GetTablesList();
        }

        private async void listTables_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (isEditPage)
            {

                var selectedItem = e.Item as TableDTO;

                if (selectedItem != null)
                {
                    await DisplayAlert("Edit", selectedItem.Idtable.ToString(), "ok");
                }
            }
        }
    }
}