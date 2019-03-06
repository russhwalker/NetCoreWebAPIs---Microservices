using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NetCoreWebAPIs.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly Core.APICaller caller;

        public WeatherController(IConfiguration configuration)
        {
            this.configuration = configuration;
            caller = new Core.APICaller();
        }

        [HttpGet]
        [Route("{zipCode}")]
        [AllowAnonymous]
        public IEnumerable<Core.Models.WeatherForecast> Get(string zipCode)
        {
            var forecassts = caller.GetAsync<IEnumerable<Core.Models.WeatherForecast>>($"{configuration["ApiUrls:Weather"]}/{zipCode}");
            return forecassts.Result;
        }
    }
}