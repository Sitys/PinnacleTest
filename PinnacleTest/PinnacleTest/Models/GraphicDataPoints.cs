using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PinnacleTest.Models
{
    public class GraphicDataPoints
    {
        public List<DataPoint> MinTempList { get; set; }
        public List<DataPoint> CurrentTempList { get; set; }
        public List<DataPoint> MaxTempList { get; set; }

        public GraphicDataPoints()
        {
                
        }

        public GraphicDataPoints GetDataPointObject(List<WeatherDataModel> model)
        {
            GraphicDataPoints gdp = new GraphicDataPoints();

            DataPoint dp = new DataPoint();
            gdp.MinTempList = dp.FillDataPointMinTemp(model);
            gdp.CurrentTempList = dp.FillDataPointCurrentTemp(model);
            gdp.MaxTempList = dp.FillDataPointMaxTemp(model);

            return gdp;
        }
    }
}