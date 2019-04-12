using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PinnacleTest.Models
{
    public class DataPoint
    {
        public double XAxis { get; set; }
        public double YAxis { get; set; }

        public DataPoint()
        {

        }

        public List<DataPoint> FillDataPointMinTemp(List<WeatherDataModel> model)
        {
            double dayNumber = 1;
            List<DataPoint> list = new List<DataPoint>();

            foreach (var item in model)
            {
                list.Add(new DataPoint { XAxis=dayNumber++, YAxis=item.MinTempValue});
            }
            return list;
        }

        public List<DataPoint> FillDataPointCurrentTemp(List<WeatherDataModel> model)
        {
            double dayNumber = 1;
            List<DataPoint> list = new List<DataPoint>();

            foreach (var item in model)
            {
                list.Add(new DataPoint { XAxis = dayNumber++, YAxis = item.CurrentTemp });
            }
            return list;
        }

        public List<DataPoint> FillDataPointMaxTemp(List<WeatherDataModel> model)
        {
            double dayNumber = 1;
            List<DataPoint> list = new List<DataPoint>();

            foreach (var item in model)
            {
                list.Add(new DataPoint { XAxis = dayNumber++, YAxis = item.MaxTempValue });
            }
            return list;
        }
    }
}