using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public class DishViewModel : BaseViewModel
    {
        public Dish MyDish { get; set; }
        public Country MyCountry { get; set; }
        public DishViewModel() {
        MyDish = new Dish();
        MyCountry = new Country();
        }

        public async Task<List<Country>> GetCountryList()
        {
            try
            {
                List<Country> list = new List<Country>();

                list = await MyCountry.GetCountries();

                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> AddNewDish(string ItemPictureUrl,string DishDescription, int Idcountry)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyDish.ItemPictureUrl = ItemPictureUrl;
                MyDish.DishDescription =DishDescription;
                MyDish.Idcountry = Idcountry;

                bool R = await MyDish.AddDish();

                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
