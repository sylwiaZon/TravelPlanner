using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelPlanner.App.Helpers;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityWalkController : ControllerBase
    {
        private readonly ITravelInfoService _travelInfoService;
        public CityWalkController(ITravelInfoService travelInfoService)
        {
            _travelInfoService = travelInfoService;
        }

        [Authorize]
        [HttpGet]
        public async Task<CityWalk[]> GetCityWalkAsync(string cityName, int totalTime, int? latitude = null, int? longitude = null, bool optimal = false, bool goInside = true, string tagLabels = null)
        {
            if (totalTime < 20 || totalTime > 360) return null;
            return await _travelInfoService.GetCityWalksAsync(cityName, totalTime, optimal, goInside, tagLabels, latitude, longitude);
        }
    }
}
