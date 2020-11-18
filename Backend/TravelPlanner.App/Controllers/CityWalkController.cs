using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityWalkController : ControllerBase
    {
        private readonly ITravelInfoService TravelInfoService;
        public CityWalkController()
        {
            TravelInfoService = new TravelInfoService();
        }

        [HttpGet]
        public async Task<CityWalk[]> GetCityWalkAsync(string cityName, int totalTime, int? latitude = null, int? longitude = null, bool optimal = false, bool goInside = true, string tagLabels = null)
        {
            if (totalTime < 20 || totalTime > 360) return null;
            return await TravelInfoService.GetCityWalksAsync(cityName, totalTime, optimal, goInside, tagLabels, latitude, longitude);
        }
    }
}
