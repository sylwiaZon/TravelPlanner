using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core.HotelsApi.Details;
using TravelPlanner.Core.HotelsApi.Photos;
using TravelPlanner.Core.HotelsApi.Search;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsService HotelsService;
        public HotelsController()
        {
            HotelsService = new HotelsService();
        }

        [HttpGet]
        async public Task<HotelSearch> GetHotels(string cityName)
        {
            return await HotelsService.GetHotels(cityName);
        }

        [HttpGet]
        [Route("photos")]
        public async Task<HotelPhotos> GetHotelPhotos(string hotelId)
        {
            return await HotelsService.GetHotelPhotos(hotelId);
        }

        [HttpGet]
        [Route("details")]
        public async Task<HotelDetails> GetHotelDetails(string hotelId, string checkIn, string checkOut, int adultsNumber, string childrenAges)
        {
            return await HotelsService.GetHotelDetails(hotelId, checkIn, checkOut, adultsNumber, childrenAges);
        }
    }
}
