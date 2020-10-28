using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService WeatherForecastService;
        public WeatherForecastController()
        {
            WeatherForecastService = new WeatherForecastService();
        }

        [HttpGet]
        public Task<IEnumerable<WeatherForecast>> Get()
        {
            return WeatherForecastService.GetWeather();
        }
    }
}
