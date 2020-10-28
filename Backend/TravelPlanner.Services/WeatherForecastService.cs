using TravelPlanner.Core;
using System.Collections.Generic;
using TravelPlanner.Repositories;
using System.Threading.Tasks;
using TravelPlanner.Services.Converters;

namespace TravelPlanner.Services
{
    public interface IWeatherForecastService
    {
        public Task<IEnumerable<WeatherForecast>> GetWeather();
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        private WeatherForecastConverter WeatherForecastConverter;

        public WeatherForecastService()
        {
            WeatherForecastConverter = new WeatherForecastConverter();
        }

        async public Task<IEnumerable<WeatherForecast>> GetWeather()
        {
            var repo = new OpenWeatherMapApiClient();
            var resp = await repo.GetWeatherForecast();
            return WeatherForecastConverter.ToWeatherForecast(resp);
        }
    }
}
