using System;
using System.Net.Http;
using System.Threading.Tasks;
using TravelPlanner.Core.OpenWeatherMap;

namespace TravelPlanner.Repositories
{
    public class OpenWeatherMapApiClient
    {
        private static readonly HttpClient Client = new HttpClient();
        private static string Token;
        private static readonly string Path = "http://api.openweathermap.org/data/2.5/";

        public OpenWeatherMapApiClient()
        {
            Token = Environment.GetEnvironmentVariable("OPEN_WEATHER_API_KEY");
        }

        public async Task<WeatherForecastApi> GetWeatherForecast(string cityName)
        {
            var responseMessage = await Client.GetAsync(Path + "forecast?q=" + cityName + "& appid=" + Token);
            if (responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine(responseMessage.Content);
                return await responseMessage.Content.ReadAsAsync<WeatherForecastApi>();
            }
            return null;
        }
    }
}
