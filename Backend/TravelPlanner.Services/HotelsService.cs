using System.Threading.Tasks;
using TravelPlanner.Core.HotelsApi.Details;
using TravelPlanner.Core.HotelsApi.Photos;
using TravelPlanner.Core.HotelsApi.Search;
using TravelPlanner.Repositories;

namespace TravelPlanner.Services
{
    public interface IHotelsService
    {
        Task<HotelSearch> GetHotels(string cityName);
        Task<HotelPhotos> GetHotelPhotos(string hotelId);
        Task<HotelDetails> GetHotelDetails(string hotelId, string checkIn, string checkOut, int adultsNumber, string childrenAges);
    }

    public class HotelsService : IHotelsService
    {
        private static HotelsApiClient HotelsApiClient;
        
        public HotelsService()
        {
            HotelsApiClient = new HotelsApiClient();
        }

        public async Task<HotelSearch> GetHotels(string cityName)
        {
            return await HotelsApiClient.GetHotels(cityName);
        }

        public async Task<HotelPhotos> GetHotelPhotos(string hotelId)
        {
            return await HotelsApiClient.GetHotelPhotos(hotelId);
        }

        public async Task<HotelDetails> GetHotelDetails(string hotelId, string checkIn, string checkOut, int adultsNumber, string childrenAges)
        {
            return await HotelsApiClient.GetHotelDetails(hotelId, checkIn, checkOut, adultsNumber, childrenAges);
        }
    }
}
