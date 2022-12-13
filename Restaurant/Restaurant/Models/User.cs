using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class User
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";
        public User()
        {
            //Invoices = new HashSet<Invoice>();
            //Reservations = new HashSet<Reservation>();
        }

        public int Iduser { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string BackUpEmail { get; set; } = null!;
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
        public int IduserRole { get; set; }
        public int Idcountry { get; set; }

        public virtual Country IdcountryNavigation { get; set; } = null!;
        public virtual UserRole IduserRoleNavigation { get; set; } = null!;

        //public virtual ICollection<Invoice> Invoices { get; set; }
        //public virtual ICollection<Reservation> Reservations { get; set; }

        //función paraa agregar un usuario en la base de datos
        public async Task<bool> AddUser()
        {
            try
            {
                string RouteSufix = string.Format("Users");
                string FinalURL = Services.CnnToRApi.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Post);

                request.AddHeader(Services.CnnToRApi.ApiKeyName, Services.CnnToRApi.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;

                string SerialClass = JsonConvert.SerializeObject(this, settings);

                request.AddBody(SerialClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }

        public async Task<bool> deleteEmployee(int userId)
        {

            try
            {

                string RouteSufix = string.Format("Users/{0}",
                   userId);
                string FinalURL = Services.CnnToRApi.ProductionURL + RouteSufix;



                RestClient client = new RestClient(FinalURL);



                request = new RestRequest(FinalURL, Method.Delete);


                request.AddHeader(Services.CnnToRApi.ApiKeyName, Services.CnnToRApi.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);


                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.NoContent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }



        }

        public async Task<bool> ValidateLogin()
        {



            try
            {

                string RouteSufix = string.Format("Users/ValidateUserCredentials?email={0}&password={1}",
                   this.Email, this.UserPassword);
                string FinalURL = Services.CnnToRApi.ProductionURL + RouteSufix;



                RestClient client = new RestClient(FinalURL);



                request = new RestRequest(FinalURL, Method.Get);



                //agregar la info de seguridad del api , aqui va la apikey



                request.AddHeader(Services.CnnToRApi.ApiKeyName, Services.CnnToRApi.ApiKeyValue);
                request.AddHeader(contentType, mimetype);





                RestResponse response = await client.ExecuteAsync(request);



                HttpStatusCode statusCode = response.StatusCode;



                //carga de info en un json




                if (statusCode == HttpStatusCode.OK)
                {
                    //carga de info en un json



                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {



                string msg = ex.Message;



                //to do guardar errores en una bitacora.
                throw;
            }



        }

    }
}
