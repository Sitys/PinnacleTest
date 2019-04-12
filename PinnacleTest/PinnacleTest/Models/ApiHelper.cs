using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace PinnacleTest.Models
{
    public class ApiHelper
    {
        public string BaseUrl { get; set; }
        public string City { get; set; }
        public string Days { get; set; }
        public string Country { get; set; }
        public string ScaleUnit { get; set; }
        public string ApiKey { get; set; }


        public ApiHelper(string city, string scaleUnit)
        {
            BaseUrl = ConfigurationManager.AppSettings["16DaysWeatherForecastURL"];
            City = city;
            Days = ConfigurationManager.AppSettings["Days"];
            Country = "Mexico";
            ScaleUnit = scaleUnit;
            ApiKey = ConfigurationManager.AppSettings["ApiKeyValue"];
        }

        public RootObject GetWeatherData()
        {
            RootObject obj = new RootObject();
            using (HttpClient client = new HttpClient())
            {
                string urlParameters = "?city=" + City + "&country=" + Country + "&units=" + ScaleUnit + "&days=" + Days + "&key=" + ApiKey;
               
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<RootObject>(dataObjects);
                }
                else
                {
                    return null;
                }
            }
            return obj;
        }

    }
}