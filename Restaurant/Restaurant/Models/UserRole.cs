using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class UserRole
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public UserRole()
        {
            //Users = new HashSet<User>();
        }

        public int IduserRole { get; set; }
        public string Role { get; set; } = null!;

        //public virtual ICollection<User> Users { get; set; }

        //funciones para el modelo
        //en este caso será una función que llama al controlador que carga todos los roles
        //para luego mostrarlos en un picker (combobox)

        public async Task<List<UserRole>> GetUserRoles()
        {
            try
            {
                string RouteSufix = string.Format("UserRoles");
                string FinalURL = Services.CnnToRApi.ProductionURL + RouteSufix;
                
                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                //agregar la info de segueridad del api, en este caso api key
                request.AddHeader(Services.CnnToRApi.ApiKeyName, Services.CnnToRApi.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    //carga de la info en un json
                    var list = JsonConvert.DeserializeObject<List<UserRole>>(response.Content);
                    return list;
                }
                else
                {
                    return null;
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
