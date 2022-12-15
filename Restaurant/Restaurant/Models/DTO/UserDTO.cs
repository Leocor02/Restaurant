using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;
using System.Collections.ObjectModel;

namespace Restaurant.Models.DTO
{
    public partial class UserDTO
    {

        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public int Iduser { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string BackUpEmail { get; set; } = null!;
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
        public int IduserRole { get; set; }
        public int Idcountry { get; set; }

        public async Task<UserDTO> getUserData(string userEmail)
        {



            try
            {
                string RouteSufix = string.Format("Users/GetUserInfo?email={0}",
                    userEmail);
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
                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);
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



                //to do guardar errores en una bitacora.
                throw;
            }



        }

        public async Task<UserDTO> GetEmployeeData(int idUser)
        {
            try
            {
                string RouteSufix = string.Format("Users/GetEmployeeData?idUser={0}", idUser);

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
                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);

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

        public async Task<ObservableCollection<UserDTO>> GetEmployeeList()
        {
            try
            {
                string RouteSufix = string.Format("Users/GetEmployeeList");

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
                    var list = JsonConvert.DeserializeObject<ObservableCollection<UserDTO>>(response.Content);

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
    }
}
