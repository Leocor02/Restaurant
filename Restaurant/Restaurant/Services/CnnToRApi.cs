using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Services
{
    public static class CnnToRApi
    {
        //aquí se definen la ¿s rutas de consumo del api
        //además se define la info de api key necesaria
        //para poder consumir los controladores

        public static string ProductionURL = "http://192.168.0.5:45455/api/";
        public static string TestingURL = "http://192.168.0.5:45455/api/";

        public static string ApiKeyName = "RApiKey";
        public static string ApiKeyValue = "RestaurantQwerty123/*";
    }
}
