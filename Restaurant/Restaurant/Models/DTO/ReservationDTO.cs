using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models.DTO
{
    public class ReservationDTO
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public int Idreservation { get; set; }
        public DateTime Date { get; set; }
        public int DinersQuantity { get; set; }
        public int Iduser { get; set; }
        public int Idtable { get; set; }

        public ReservationDTO() { }

        public async Task<ObservableCollection<ReservationDTO>> GetAllReservationsList()
        {
            try
            {
                string RouteSufix = string.Format("Reservations/GetAllReservationsList");

                string FinalURL = Services.CnnToRApi.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                request.AddHeader(Services.CnnToRApi.ApiKeyName, Services.CnnToRApi.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<ObservableCollection<ReservationDTO>>(response.Content);

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

        public async Task<ObservableCollection<ReservationDTO>> GetUserReservationsList()
        {
            try
            {
                string RouteSufix = string.Format("Reservations/GetUserReservationsList/{0}",
                    GlobalItems.GlobalUser.Iduser);

                string FinalURL = Services.CnnToRApi.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                request.AddHeader(Services.CnnToRApi.ApiKeyName, Services.CnnToRApi.ApiKeyValue);
                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<ObservableCollection<ReservationDTO>>(response.Content);

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
