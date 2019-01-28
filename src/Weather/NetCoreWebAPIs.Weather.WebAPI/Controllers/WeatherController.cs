using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebAPIs.Weather.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet("{zipCode}")]
        public IEnumerable<Core.Models.WeatherReport> Get(string zipCode)
        {
            return new List<Core.Models.WeatherReport>
            {
                new Core.Models.WeatherReport
                {
                    ZipCode = zipCode,
                    Day = DateTime.Today,
                    LowTemparature = 62M,
                    HighTemparature = 79M,
                    TemparatureScale = "F"
                },
                new Core.Models.WeatherReport
                {
                    ZipCode = zipCode,
                    Day = DateTime.Today.AddDays(1),
                    LowTemparature = 49M,
                    HighTemparature = 57M,
                    TemparatureScale = "F"
                }
            };
        }
    }
}