using System.Collections.Generic;
using TravelPlanner.Repositories;
using System.Threading.Tasks;
using TravelPlanner.Services.Converters;
using TravelPlanner.DomainModels;

namespace TravelPlanner.Services
{
    public interface IWeatherForecastService
    {
        public Task<IEnumerable<WeatherForecast>> GetWeather(string cityName);
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        async public Task<IEnumerable<WeatherForecast>> GetWeather(string cityName)
        {
            var repo = new OpenWeatherMapApiClient();
            var resp = await repo.GetWeatherForecast(cityName);
            return WeatherForecastConverter.ToWeatherForecast(resp);
        }
    }
}
