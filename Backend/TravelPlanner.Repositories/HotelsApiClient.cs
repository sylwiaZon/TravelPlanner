using System;
using System.Net.Http;
using System.Threading.Tasks;
using TravelPlanner.Core.HotelsApi.Details;
using TravelPlanner.Core.HotelsApi.Photos;
using TravelPlanner.Core.HotelsApi.Search;

namespace TravelPlanner.Repositories
{
    public class HotelsApiClient
    {
        private readonly HttpClient Client;
        private readonly string Path = "https://hotels4.p.rapidapi.com/";

        public HotelsApiClient()
        {
            Client = new HttpClient();
            //HOTELS_API_KEY
            var hostEnv = Environment.GetEnvironmentVariable("HOTELS_API_HOST");
            var keyEnv = Environment.GetEnvironmentVariable("HOTELS_API_KEY");
            Client.DefaultRequestHeaders.Add("x-rapidapi-host", hostEnv);
            Client.DefaultRequestHeaders.Add("x-rapidapi-key", keyEnv);
        }

        public async Task<HotelSearch> GetHotels(string cityName)
        {
            var responseMessage = await Client.GetAsync(Path + "locations/search?locale=en_US&query=" + cityName);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsAsync<HotelSearch>();
            }
            return null;
        }

        public async Task<HotelPhotos> GetHotelPhotos(string hotelId)
        {
            var responseMessage = await Client.GetAsync(Path + "properties/get-hotel-photos?id=" + hotelId);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsAsync<HotelPhotos>();
            }
            return null;
        }

        public async Task<HotelDetails> GetHotelDetails(string hotelId, string checkIn, string checkOut, int adultsNumber, string childrenAges)
        {
            var queryPath = Path +
                "properties/get-details?locale=en_US&currency=USD&checkOut=" + checkOut + "&adults1=" +
                adultsNumber + "checkIn=" + checkIn + "&id=" + hotelId;
            if (!(childrenAges is null)) queryPath += "&children1=" + childrenAges;
            var responseMessage = await Client.GetAsync(queryPath);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsAsync<HotelDetails>();
            }
            return null;
        }
    }
}
