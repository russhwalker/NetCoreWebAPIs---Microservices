using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;

namespace NetCoreWebAPIs.App.Console
{
    class Program
    {
        private static IConfiguration configuration;

        private static void Main(string[] args)
        {
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~NetCoreWebAPIs.App.Console START");
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
            configuration = builder.Build();

            var caller = new Core.APICaller();

            System.Console.WriteLine("--------Weather--------");
            var forecasts = caller.GetAsync<IEnumerable<Core.Models.WeatherReport>>($"{CreateGatewayUrl("Weather")}/29201").Result;
            System.Console.WriteLine(JsonConvert.SerializeObject(forecasts));

            var authRequest = new Core.Requests.AuthRequest
            {
                UserName = "DoeJohn1",
                Password = "abc123"
            };
            var authResponse = caller.PostAsync<Core.Responses.AuthResponse>(CreateGatewayUrl("Auth"), authRequest).Result;

            if (!authResponse.Authenticated)
            {
                System.Console.WriteLine("Authentication Failed.");
                return;
            }

            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(authResponse.TokenContent);
            System.Console.WriteLine("Authentication Success.");
            System.Console.WriteLine($"Valid: {jwtToken.ValidFrom} -- {jwtToken.ValidTo}");

            System.Console.WriteLine("--------Customer--------");
            _ = caller.PostAsync<Core.Models.Customer>(CreateGatewayUrl("Customer"), new Core.Models.Customer { CustomerName = "John Doe" }, authResponse.TokenContent).Result;
            _ = caller.PostAsync<Core.Models.Customer>(CreateGatewayUrl("Customer"), new Core.Models.Customer { CustomerName = "Jane Doe" }, authResponse.TokenContent).Result;
            _ = caller.PostAsync<Core.Models.Customer>(CreateGatewayUrl("Customer"), new Core.Models.Customer { CustomerName = "Timmy Doe" }, authResponse.TokenContent).Result;
            var customers = caller.GetAsync<IEnumerable<Core.Models.Customer>>(CreateGatewayUrl("Customer"), authResponse.TokenContent).Result;
            System.Console.WriteLine(JsonConvert.SerializeObject(customers));

            System.Console.WriteLine("--------Customer--------");

            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~NetCoreWebAPIs.App.Console END");
            System.Console.ReadKey();
        }

        private static string CreateGatewayUrl(string relativeUrl)
        {
            return Path.Combine(configuration["baseUrl"], relativeUrl);
        }
    }
}