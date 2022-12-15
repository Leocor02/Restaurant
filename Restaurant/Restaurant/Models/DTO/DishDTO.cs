using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;

namespace Restaurant.Models.DTO
{
    public partial class DishDTO
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public DishDTO() { }
        public int Iddish { get; set; }
        public string ItemPictureUrl { get; set; } = null!;
        public string DishDescription { get; set; } = null!;
        public int Idcountry { get; set; }

        public async Task<ObservableCollection<DishDTO>> GetDishesList()
        {
            try
            {
                string RouteSufix = string.Format("Dishes/GetDishesList");

                string FinalURL = Services.CnnToRApi.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                //agregar la info de seguridad del api, en este caso ApiKey
                request.AddHeader(Services.CnnToRApi.ApiKeyName, Services.CnnToRApi.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<ObservableCollection<DishDTO>>(response.Content);

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
                //TODO: guardar estos errores en una bitácora para su posterior analisis
                throw;
            }

        }

        public async Task<DishDTO> GetDishData(int idDish)
        {
            try
            {
                string RouteSufix = string.Format("Dishes/GetDishData?idDish={0}", idDish);

                string FinalURL = Services.CnnToRApi.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                //agregar la info de seguridad del api, en este caso ApiKey
                request.AddHeader(Services.CnnToRApi.ApiKeyName, Services.CnnToRApi.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<DishDTO>>(response.Content);

                    var item = list[0];

                    return item;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                //TODO: guardar estos errores en una bitácora para su posterior analisis
                throw;
            }

        }

        public async Task<bool> EditDish(int dishId)
        {
            try
            {
                string RouteSufix = string.Format("Dishes/{0}", dishId);
                string FinalURL = Services.CnnToRApi.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Put); //normalmete se usar PUT o PATCH para actualizar 

                //agregar la info de seguridad del api, en este caso ApiKey
                request.AddHeader(Services.CnnToRApi.ApiKeyName, Services.CnnToRApi.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                //tenemos que serializar la clase para poderla enviar al API
                string SerialClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerialClass, mimetype);

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
                //TODO: guardar estos errores en una bitácora para su posterior analisis
                throw;
            }

        }

    }
}
