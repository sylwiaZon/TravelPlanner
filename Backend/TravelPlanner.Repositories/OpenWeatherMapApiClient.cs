using System;
using System.Net.Http;
using System.Threading.Tasks;
using TravelPlanner.Core.OpenWeatherMap;

namespace TravelPlanner.Repositories
{
    public class OpenWeatherMapApiClient
    {
        static readonly HttpClient Client = new HttpClient();

        public async Task<WeatherForecastApi> GetWeatherForecast()
        {
            var responseMessage = await Client.GetAsync("http://api.openweathermap.org/data/2.5/forecast?q=Krakow&appid=18d25a9c31d163de33c8be953d20f040");
            if (responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine(responseMessage.Content);
                return await responseMessage.Content.ReadAsAsync<WeatherForecastApi>();
            }
            return null;
        }
    }
}
