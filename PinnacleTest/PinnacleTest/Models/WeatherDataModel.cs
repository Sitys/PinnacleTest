using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PinnacleTest.Models
{
    public class WeatherDataModel
    {
        public string DateValue { get; set; }
        public double MaxTempValue { get; set; }
        public double MinTempValue { get; set; }
        public double CurrentTemp { get; set; }

        public WeatherDataModel()
        {

        }
        public WeatherDataModel(string date, double maxtemp, double mintemp, double currentTemp)
        {
            DateValue = date;
            MaxTempValue = maxtemp;
            MinTempValue = mintemp;
            CurrentTemp = currentTemp;
        }

        public List<WeatherDataModel> GetWeaterForecastList(RootObject model)
        {
            List<WeatherDataModel> list = new List<WeatherDataModel>();

            foreach (var item in model.data)
            {
                list.Add(new WeatherDataModel(DateValue = item.valid_date, MaxTempValue = (double)item.max_temp, MinTempValue = (double)item.min_temp, CurrentTemp = (double)item.temp));
            }
            return list;
        }
    }
}