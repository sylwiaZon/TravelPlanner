using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelPlanner.App.Helpers;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationInfoController : ControllerBase
    {
        private readonly ITravelInfoService _travelInfoService;
        public LocationInfoController(ITravelInfoService travelInfoService)
        {
            _travelInfoService = travelInfoService;
        }

        [Authorize]
        [HttpGet]
        async public Task<Location> GetLocationInfo(string cityName)
        {
            return await _travelInfoService.GetLocationInfoAsync(cityName);
        }
    }
}
