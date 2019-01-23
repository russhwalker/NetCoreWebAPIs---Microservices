using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebAPIs.Core.Models
{
    public class WeatherReport
    {
        public string ZipCode { get; set; }
        public DateTime Day { get; set; }
        public decimal Temperature { get; set; }
    }
}