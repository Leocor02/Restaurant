using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Dish
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public Dish() { }
        public int Iddish { get; set; }
        public string ItemPictureUrl { get; set; } = null!;
        public string DishDescription { get; set; } = null!;
        public int Idcountry { get; set; }

        public virtual Country IdcountryNavigation { get; set; } = null!;

        public async Task<bool> AddDish()
        {
            try
            {
                string RouteSufix = string.Format("Dishes");
                string FinalURL = Services.CnnToRApi.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Post);

                //agregar la info de segueridad del api, en este caso api key
                request.AddHeader(Services.CnnToRApi.ApiKeyName, Services.CnnToRApi.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                //serializar la clase para poder enviarla al api
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
    }
}
