﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;
using Restaurant.Models.DTO;
using Xamarin.Forms;

namespace Restaurant.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public UserRole MyUserRole { get; set; }

        public Country MyCountry { get; set; }

        public User MyUser { get; set; }

        public UserDTO MyUserDTO { get; set; }

        public UserViewModel()
        {
            MyUserRole= new UserRole();
            MyCountry= new Country();
            MyUser= new User(); 
            MyUserDTO = new UserDTO();
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
                                           int pIdCountry)
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
                MyUser.Active = true;
                MyUser.IduserRole = 2;
                MyUser.Idcountry = pIdCountry;

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
   
 public async Task<UserDTO> getUserData(string email)
        {

            try
            {
                UserDTO user = new UserDTO();

                user = await MyUserDTO.getUserData(email);

                if (user == null) { return null; } else { return user; }
            }
            catch (Exception)
            {

                return null;
            }
        }


        public async Task<bool> UserAccessValidation(string email, string password)
        {
            if (IsBusy) return false;
            IsBusy = true;



            try
            {
                MyUser.Email = email;
                MyUser.UserPassword = password;



                bool R = await MyUser.ValidateLogin();



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


    }
}