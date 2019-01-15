﻿using System;
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
        public static string Create(IConfiguration configuration, string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
            var token = new JwtSecurityToken(
               issuer: configuration["Tokens:Issuer"],
               audience: configuration["Tokens:Issuer"],
               expires: DateTime.Now.AddSeconds(10),
               claims: claims,
               signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}