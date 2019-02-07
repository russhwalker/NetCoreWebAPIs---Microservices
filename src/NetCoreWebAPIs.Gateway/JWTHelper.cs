using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace NetCoreWebAPIs.Gateway
{
    public static class JWTHelper
    {
        public static string Create(IConfiguration configuration, string userName, string userFullName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.UserData, userName),
                new Claim(ClaimTypes.Name, userFullName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
            var seconds = int.Parse(configuration["Tokens:ExpiresFutureSeconds"]);
            var token = new JwtSecurityToken(
               issuer: configuration["Tokens:Issuer"],
               audience: configuration["Tokens:Issuer"],
               claims: claims,
               notBefore: DateTime.Now.ToUniversalTime(),
               expires: DateTime.Now.AddSeconds(seconds).ToUniversalTime(),
               signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}