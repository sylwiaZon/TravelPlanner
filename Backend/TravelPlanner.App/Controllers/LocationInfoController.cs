using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelPlanner.Core.Triposo;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationInfoController : ControllerBase
    {
        private readonly ITravelInfoService TravelInfoService;
        public LocationInfoController()
        {
            TravelInfoService = new TravelInfoService();
        }

        [HttpGet]
        async public Task<Location> GetLocationInfo(string cityName)
        {
            return await TravelInfoService.GetLocationInfoAsync(cityName);
        }

        [HttpGet("tags")]
        async public Task<Tag[]> GetAvailableTags(string cityName)
        {
            return await TravelInfoService.GetAvailableTagsAsync(cityName);
        }
    }
}
