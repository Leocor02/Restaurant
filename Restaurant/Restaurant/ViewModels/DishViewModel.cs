using Restaurant.Models;
using Restaurant.Models.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public class DishViewModel : BaseViewModel
    {
        public Dish MyDish { get; set; }
        public Country MyCountry { get; set; }

        public DishDTO MyDishDTO { get; set; }
        public DishViewModel() {
        MyDish = new Dish();
        MyCountry = new Country();
        MyDishDTO = new DishDTO();
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

        public async Task<bool> EditDish(int idDish,string ItemPictureUrl, string DishDescription, int Idcountry)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyDishDTO.Iddish= idDish;
                MyDishDTO.ItemPictureUrl = ItemPictureUrl;
                MyDishDTO.DishDescription = DishDescription;
                MyDishDTO.Idcountry = Idcountry;

                bool R = await MyDishDTO.EditDish(idDish);
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

        public async Task<ObservableCollection<DishDTO>> GetDishesList()
        {
            if (IsBusy)
            {
                return null;
            }
            else
            {
                IsBusy = true;

                try
                {
                    ObservableCollection<DishDTO> list = new ObservableCollection<DishDTO>();

                    list = await MyDishDTO.GetDishesList();

                    if (list == null)
                    {
                        return null;
                    }

                    return list;

                }
                catch (Exception)
                {
                    return null;
                }
                finally { IsBusy = false; }

            }





        }

        public async Task<bool> deleteDish(int idDish)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {


                bool R = await MyDish.deleteDish(idDish);



                return R;



            }
            catch (Exception)
            {



                return false;
                throw;
            }
            finally
            { IsBusy = false; }

        }

        public async Task<DishDTO> GetDishData(int idDish)
        {
            try
            {
                DishDTO dish = new DishDTO();

                dish = await MyDishDTO.GetDishData(idDish);

                if (dish == null)
                {
                    return null;
                }
                else
                {
                    return dish;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
