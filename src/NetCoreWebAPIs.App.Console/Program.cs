using System;
using System.IdentityModel.Tokens.Jwt;

namespace NetCoreWebAPIs.App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            var caller = new Core.APICaller();
            var obj = new
            {
                userName = "uuuu",
                password = "ppppp"
            };
            //var authResult = caller.Post<Core.Models.AuthResult>("https://localhost:44360/api/Auth", obj);
            var authResult = caller.PostAsync<Core.Models.AuthResult>("https://localhost:44360/api/Auth", obj).Result;
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(authResult.TokenContent);
        }
    }
}