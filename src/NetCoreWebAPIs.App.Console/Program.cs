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
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
            configuration = builder.Build();

            var caller = new Core.APICaller();

            var weatherForecasts = caller.GetAsync<IEnumerable<Core.Models.WeatherReport>>(CreateGatewayUrl("Weather")).Result;

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
            var addCust = caller.PostAsync<Core.Models.Customer>(CreateGatewayUrl("Customer"), new Core.Models.Customer { CustomerName = "John Doe" }).Result;
            var customers = caller.GetAsync<IEnumerable<Core.Models.Customer>>(CreateGatewayUrl("Customer"), authResponse.TokenContent).Result;
            System.Console.WriteLine(JsonConvert.SerializeObject(customers));
        }

        private static string CreateGatewayUrl(string relativeUrl)
        {
            return Path.Combine(configuration["baseUrl"], relativeUrl);
        }
    }
}