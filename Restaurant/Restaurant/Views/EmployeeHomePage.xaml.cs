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
    public partial class EmployeeHomePage : ContentPage
    {
        public EmployeeHomePage()
        {
            InitializeComponent();
            this.Title = "Bienvenido! " + GlobalItems.GlobalUser.Name;
        }
    }
}