using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebAPIs.Core.Models
{
    public class WeatherReport
    {
        public string ZipCode { get; set; }
        public int Temperature { get; set; }
    }
}