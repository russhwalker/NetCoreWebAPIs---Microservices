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
using NetCoreWebAPIs.Gateway.Requests;

namespace NetCoreWebAPIs.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public Core.Models.AuthResult Post([FromBody]AuthenticationRequest authRequest)
        {
            //TODO authenticate

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, authRequest.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
            var token = new JwtSecurityToken(
                issuer: configuration["Tokens:Issuer"],
                audience: configuration["Tokens:Issuer"],
                expires: DateTime.Now.AddSeconds(10),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                );
            return new Core.Models.AuthResult
            {
                Authenticated = true,
                TokenContent = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
