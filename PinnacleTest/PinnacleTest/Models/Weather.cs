using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PinnacleTest.Models
{
    public class Weather
    {
        public string icon { get; set; }
        public int? code { get; set; }
        public string description { get; set; }
    }
}