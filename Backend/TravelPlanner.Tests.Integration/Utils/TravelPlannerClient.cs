using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using TravelPlanner.Core;
using TravelPlanner.Core.DomainModels;

namespace TravelPlanner.Tests.Integration.Utils
{
    public class TravelPlannerClient
    {
        public readonly HttpClient HttpClient;
        public readonly User User = new User
        {
            Mail = "testowy@test.com",
            Name = "name",
            Password = "pass"
        };

        public TravelPlannerClient()
        {
            var conf = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(conf["BaseUrl"])
            };
        }

        public async Task Authenticate()
        {
            //var response = await HttpClient.PostAsync("/user/register", User.AsJson());
            
            var tokenResponse = await HttpClient.PostAsync("/user/authenticate", new AuthenticateRequest
            {
                Mail = User.Mail,
                Password = User.Password
            }.AsJson());
            var response = await tokenResponse.ToObject<AuthenticateResponse>();
            HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer "+response.Token);
        }
    }
}