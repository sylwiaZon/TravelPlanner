using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Core.HotelsApi.Details;
using TravelPlanner.Core.HotelsApi.Photos;
using TravelPlanner.Repositories;
using TravelPlanner.Services.Converters;

namespace TravelPlanner.Services
{
    public interface IHotelsService
    {
        Task<IEnumerable<Hotel>> GetHotels(string cityName);
        Task<HotelPhotos> GetHotelPhotos(string hotelId);
        Task<HotelDetails> GetHotelDetails(string hotelId, string checkIn, string checkOut, int adultsNumber, string childrenAges);
        Task<HotelDetails> GetHotelDetails(string hotelId);
    }

    public class HotelsService : IHotelsService
    {
        private static HotelsApiClient HotelsApiClient;
        
        public HotelsService()
        {
            HotelsApiClient = new HotelsApiClient();
        }

        public async Task<IEnumerable<Hotel>> GetHotels(string cityName)
        {
            var apiResponse = await HotelsApiClient.GetHotels(cityName);
            return HotelConverter.ToDomainHotel(apiResponse);
        }

        public async Task<HotelPhotos> GetHotelPhotos(string hotelId)
        {
            return await HotelsApiClient.GetHotelPhotos(hotelId);
        }

        public async Task<HotelDetails> GetHotelDetails(string hotelId, string checkIn, string checkOut, int adultsNumber, string childrenAges)
        {
            return await HotelsApiClient.GetHotelDetails(hotelId, checkIn, checkOut, adultsNumber, childrenAges);
        }
        
        public async Task<HotelDetails> GetHotelDetails(string hotelId)
        {
            return await HotelsApiClient.GetHotelDetails(hotelId);
        }
    }
}
