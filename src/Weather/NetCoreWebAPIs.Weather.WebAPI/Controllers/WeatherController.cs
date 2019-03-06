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
        public IEnumerable<Core.Models.WeatherForecast> Get(string zipCode)
        {
            return new List<Core.Models.WeatherForecast>
            {
                new Core.Models.WeatherForecast
                {
                    ZipCode = zipCode,
                    Day = DateTime.Today,
                    LowTemparature = 50M,
                    HighTemparature = 70M,
                    TemparatureScale = "F"
                },
                new Core.Models.WeatherForecast
                {
                    ZipCode = zipCode,
                    Day = DateTime.Today.AddDays(1),
                    LowTemparature = 49M,
                    HighTemparature = 57M,
                    TemparatureScale = "F"
                },
                new Core.Models.WeatherForecast
                {
                    ZipCode = zipCode,
                    Day = DateTime.Today.AddDays(2),
                    LowTemparature = 35M,
                    HighTemparature = 57M,
                    TemparatureScale = "F"
                },
                new Core.Models.WeatherForecast
                {
                    ZipCode = zipCode,
                    Day = DateTime.Today.AddDays(3),
                    LowTemparature = 45M,
                    HighTemparature = 68M,
                    TemparatureScale = "F"
                }
            };
        }
    }
}