using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebAPIs.User.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public Core.Responses.AuthResponse Post([FromBody] Core.Requests.AuthRequest request)
        {

            return new Core.Responses.AuthResponse
            {
                Authenticated = true
            };
        }
    }
}