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
            var token = caller.Post<JwtSecurityToken>("https://localhost:44360/api/Auth", obj);
            //var result = caller.PostAsync<string>("https://localhost:44360/api/Auth", obj).Result;
        }
    }
}