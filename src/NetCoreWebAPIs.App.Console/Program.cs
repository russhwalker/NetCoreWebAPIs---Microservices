using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace NetCoreWebAPIs.App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string createUrl(string relativeUrl)
            {
                return System.IO.Path.Combine("https://localhost:44360/api/", relativeUrl);
            }

            var authRequest = new Core.Requests.AuthRequest
            {
                UserName = "DoeJohn1",
                Password = "abc123"
            };
            var caller = new Core.APICaller();
            var authResponse = caller.PostAsync<Core.Responses.AuthResponse>(createUrl("Auth"), authRequest).Result;

            if (!authResponse.Authenticated)
            {
                System.Console.WriteLine("Authentication Failed.");
                return;
            }
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(authResponse.TokenContent);
            System.Console.WriteLine("Authentication Success.");
            System.Console.WriteLine($"Valid: {jwtToken.ValidFrom} -- {jwtToken.ValidTo}");

            System.Console.WriteLine("--------Customer--------");
            var addCust = caller.PostAsync<Core.Models.Customer>(createUrl("Customer"), new Core.Models.Customer { CustomerName = "Some Guy" }).Result;
            var customers = caller.GetAsync<IEnumerable<Core.Models.Customer>>(createUrl("Customer"), authResponse.TokenContent).Result;
            System.Console.WriteLine(JsonConvert.SerializeObject(customers));
        }
    }
}