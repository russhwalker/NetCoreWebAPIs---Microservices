using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetCoreWebAPIs.Gateway.Requests;

namespace NetCoreWebAPIs.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        public Core.Models.AuthResult Post([FromBody]AuthenticationRequest authRequest)
        {
            //TODO authenticate

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, authRequest.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abacawefwfasdfsd"));
            var token = new JwtSecurityToken(
                issuer: "mytestsite.com",
                audience: "mytestsite.com",
                expires: DateTime.Now,
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
