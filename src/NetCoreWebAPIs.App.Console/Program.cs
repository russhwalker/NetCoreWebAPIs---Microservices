using System;
using System.IdentityModel.Tokens.Jwt;

namespace NetCoreWebAPIs.App.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var caller = new Core.APICaller();
            var obj = new
            {
                userName = "uuuu",
                password = "ppppp"
            };

            var authResult = caller.PostAsync<Core.Models.AuthResult>("https://localhost:44360/api/Auth", obj).Result;
            if (!authResult.Authenticated)
            {
                System.Console.WriteLine("Authentication Failed.");
                return;
            }
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(authResult.TokenContent);
            System.Console.WriteLine("Authentication Success.");
            System.Console.WriteLine($"Valid: {jwtToken.ValidFrom} -- {jwtToken.ValidTo}");
        }
    }
}