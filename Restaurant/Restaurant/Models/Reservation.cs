using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Reservation
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public Reservation() { }   

        public int Idreservation { get; set; }
        public DateTime Date { get; set; }
        public int DinersQuantity { get; set; }
        public int Iduser { get; set; }
        public int Idtable { get; set; }

        public virtual Table IdtableNavigation { get; set; } = null!;
        public virtual User IduserNavigation { get; set; } = null!;

        public async Task<bool> AddReservation()
        {
            try
            {
                string RouteSufix = string.Format("Reservations");
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
    }
}
