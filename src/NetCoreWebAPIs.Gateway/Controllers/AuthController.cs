using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace NetCoreWebAPIs.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public string Post(string userName = "", string password = "")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abacawefwfasdfsd"));
            var token = new JwtSecurityToken(
                issuer: "netcorewebapisSite.com",
                audience: "netcorewebapisSite.com",
                expires: DateTime.Now.AddSeconds(5),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                );
            var x = new JwtSecurityTokenHandler();
            return x.WriteToken(token);
            //return $"u:{userName};p:{password}";
        }
    }
}
