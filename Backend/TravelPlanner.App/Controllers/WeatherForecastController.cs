﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.App.Helpers;
using TravelPlanner.DomainModels;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [Authorize]
        [HttpGet]
        public Task<IEnumerable<WeatherForecast>> Get(string cityName)
        {
            return _weatherForecastService.GetWeather(cityName);
        }
    }
}
