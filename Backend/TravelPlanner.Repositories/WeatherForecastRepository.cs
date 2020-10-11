using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPlanner.Core;

namespace TravelPlanner.Repositories
{
    public class WeatherForecastRepository 
    {

        async public Task<IEnumerable<WeatherForecast>> GetWeather()
        {
            var graphClient = new BoltGraphClient(new Uri("bolt://40.69.36.20:7687"), "neo4j", "tpPass");
            await graphClient.ConnectAsync();
            var resp = graphClient.Cypher.Match("(weather:Forecast)").Return(weather => weather.As<WeatherForecast>()).ResultsAsync;
            return await resp;
        }
    }
}
