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
        [HttpGet]
        public Task<IEnumerable<WeatherForecast>> Get()
        {
            var fs = new WeatherForecastService();
            return fs.GetWeather();
        }
    }
}
