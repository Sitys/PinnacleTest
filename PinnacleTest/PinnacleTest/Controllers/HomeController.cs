using Newtonsoft.Json;
using PinnacleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PinnacleTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<CityStateCountry> cityList = new List<CityStateCountry>();
            cityList.Add(new CityStateCountry
            {
                City = "Ciudad obregon"
            });
            cityList.Add(new CityStateCountry
            {
                City = "Navojoa"
            });
            cityList.Add(new CityStateCountry
            {
                City = "Hermosillo"
            });
            cityList.Add(new CityStateCountry
            {
                City = "Nogales"
            });

            List<TempScale> tempScale = new List<TempScale>();
            tempScale.Add(new TempScale
            {
                Name = "Celsius",
                Value = "M"
            });
            tempScale.Add(new TempScale
            {
                Name = "Fahrenheit",
                Value = "I",
            });

            ViewBag.Cities = cityList;
            ViewBag.ScaleUnit = tempScale;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult GetGraphic(string city, string scaleUnit)
        {
            var apiHelper = new ApiHelper(city, scaleUnit);
            var rootObjectItem = apiHelper.GetWeatherData();

            var weatherModel = new WeatherDataModel();
            var weatherModelList = weatherModel.GetWeaterForecastList(rootObjectItem);

            ViewBag.WeatherList = weatherModelList;

            return PartialView();
        }

        [HttpGet]
        public JsonResult GetDataPoints(string city, string scaleUnit)
        {
            var apiHelper = new ApiHelper(city, scaleUnit);
            var rootObjectItem = apiHelper.GetWeatherData();

            var weatherModel = new WeatherDataModel();
            var weatherModelList = weatherModel.GetWeaterForecastList(rootObjectItem);
            GraphicDataPoints gdp = new GraphicDataPoints();
            var result = gdp.GetDataPointObject(weatherModelList);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}