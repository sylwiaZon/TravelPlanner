using System;
using System.Collections.Generic;
using System.Linq;
using TravelPlanner.Core.OpenWeatherMap;
using TravelPlanner.DomainModels;
using static TravelPlanner.DomainModels.WeatherForecast;

namespace TravelPlanner.Services.Converters
{
    public class WeatherForecastConverter
    {
        public static IEnumerable<WeatherForecast> ToWeatherForecast(WeatherForecastApi weatherForecast)
        {
            return weatherForecast.List.Select(el =>
                new WeatherForecast
                {
                    Date = new DateTime(el.Date),
                    WindSpeed = el.Wind.Speed,
                    WindDirection = el.Wind.Deg,
                    Visibility = el.Visibility,
                    Cloudiness = el.Clouds.All,
                    Temperature = el.Main.Temp,
                    TemperatureFeels = el.Main.FeelsLike,
                    MaximalTemperature = el.Main.TempMax,
                    MinimalTemperature = el.Main.TempMin,
                    Pressure = el.Main.Preassure,
                    Humidity = el.Main.Humidity,
                    Weather = el.Weather.Select(w => 
                        new WeatherProperties 
                        { 
                            WeatherDescription = w.Description, 
                            WeatherIcon = "openweathermap.org/img/w/" + w.Icon + "n.png",
                            WeatherName = w.Main
                            }).ToList()
                });
        }
    }
}
