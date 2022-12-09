using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public UserRole MyUserRole { get; set; }

        public Country MyCountry { get; set; }

        public User MyUser { get; set; }

        public UserViewModel()
        {
            MyUserRole= new UserRole();
            MyCountry= new Country();
            MyUser= new User(); 
        }

        public async Task<List<UserRole>> GetUserRoleList()
        {
            try
            {
                List<UserRole> list = new List<UserRole>();

                list = await MyUserRole.GetUserRoles();

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

        //funcion para agregar usuario
        public async Task<bool> AddNewUser(string pName,
                                           string pEmail,
                                           string pPassword,
                                           string pBkpEmail,
                                           string pPhoneNumber,
                                           //Borrar los dos de abajo una vez arreglado lo del TxtActive
                                           //int pUserRole = 2,
                                           //int pCountry = 1
                                           //Descomentar los dos de abajo una vez arreglado lo del TxtActive
                                           int pUserRole,
                                           int pCountry,
                                           bool pActive = true)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Name = pName;
                MyUser.Email = pEmail;
                MyUser.UserPassword = pPassword;
                MyUser.BackUpEmail = pBkpEmail;
                MyUser.PhoneNumber = pPhoneNumber;
                MyUser.Active = pActive;
                MyUser.IduserRole = pUserRole;
                MyUser.Idcountry = pCountry;

                bool R = await MyUser.AddUser();

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

        //función de validación de ingreso de usuario al app
        public async Task<bool> UserAccessValidation(string pEmail,string pUserPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail; 
                MyUser.UserPassword = pUserPassword;

                bool R = await MyUser.ValidateLogin();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; } 

        }
    }
}
