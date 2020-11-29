using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.App.Helpers;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Core.HotelsApi.Details;
using TravelPlanner.Core.HotelsApi.Photos;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsService _hotelsService;
        public HotelsController(IHotelsService hotelsService)
        {
            _hotelsService = hotelsService;
        }

        [Authorize]
        [HttpGet]
        async public Task<IEnumerable<Hotel>> GetHotels(string cityName)
        {
            return await _hotelsService.GetHotels(cityName);
        }

        [Authorize]
        [HttpGet]
        [Route("photos")]
        public async Task<HotelPhotos> GetHotelPhotos(string hotelId)
        {
            return await _hotelsService.GetHotelPhotos(hotelId);
        }

        [Authorize]
        [HttpGet]
        [Route("details")]
        public async Task<HotelDetails> GetHotelDetails(string hotelId, string checkIn, string checkOut, int adultsNumber, string childrenAges)
        {
            return await _hotelsService.GetHotelDetails(hotelId, checkIn, checkOut, adultsNumber, childrenAges);
        }
    }
}
