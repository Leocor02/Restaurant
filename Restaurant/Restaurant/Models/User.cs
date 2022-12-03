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

        public virtual Country? IdcountryNavigation { get; set; } = null!;
        public virtual UserRole? IduserRoleNavigation { get; set; } = null!;

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

                //agregar la info de segueridad del api, en este caso api key
                request.AddHeader(Services.CnnToRApi.ApiKeyName, Services.CnnToRApi.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                //serializar la clase para poder enviarla al api
                string SerialClass = JsonConvert.SerializeObject(this);

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

    }
}
