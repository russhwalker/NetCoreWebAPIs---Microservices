using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NetCoreWebAPIs.Core.Requests;
using NetCoreWebAPIs.Core.Responses;

namespace NetCoreWebAPIs.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<AuthResponse> Post([FromBody]AuthRequest authRequest)
        {
            var response = new AuthResponse();
            var verifyUserResponse = await new Core.APICaller().PostAsync<VerifyUserResponse>(configuration["ApiUrls:User"], authRequest);
            if (verifyUserResponse.Authenticated)
            {
                response.Authenticated = true;
                response.TokenContent = JWTHelper.Create(configuration, verifyUserResponse.UserName, verifyUserResponse.UserFullName);
            }
            return response;
        }
    }
}