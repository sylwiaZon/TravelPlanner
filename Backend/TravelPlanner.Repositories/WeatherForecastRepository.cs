using Neo4jClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TravelPlanner.Core;

namespace TravelPlanner.Repositories
{
    public class WeatherForecastRepository 
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;
        private static readonly string LocalEnvUrl = "bolt://40.69.36.20:7687";
        private static readonly string VMEnvUrl = "db";

        public WeatherForecastRepository()
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_LOGIN");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(VMEnvUrl), Login, Password);
        }

        async public Task<IEnumerable<WeatherForecast>> GetWeather()
        {
            await GraphClient.ConnectAsync();
            var resp = GraphClient.Cypher.Match("(weather:Forecast)").Return(weather => weather.As<WeatherForecast>()).ResultsAsync;
            return await resp;
        }
    }
}
