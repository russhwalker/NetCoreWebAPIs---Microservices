using System;
using System.IdentityModel.Tokens.Jwt;

namespace NetCoreWebAPIs.App.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var authRequest = new Core.Requests.AuthRequest
            {
                UserName = "uuuu",
                Password = "ppppp"
            };
            var caller = new Core.APICaller();
            var authResponse = caller.PostAsync<Core.Responses.AuthResponse>("https://localhost:44360/api/Auth", authRequest).Result;

            if (!authResponse.Authenticated)
            {
                System.Console.WriteLine("Authentication Failed.");
                return;
            }
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(authResponse.TokenContent);
            System.Console.WriteLine("Authentication Success.");
            System.Console.WriteLine($"Valid: {jwtToken.ValidFrom} -- {jwtToken.ValidTo}");

            var testResponse = caller.GetAsync<Core.Responses.TestResponse>("https://localhost:44360/api/Customer", authResponse.TokenContent).Result;
        }
    }
}