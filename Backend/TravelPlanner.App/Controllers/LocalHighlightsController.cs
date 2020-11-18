using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.App.Helpers;
using TravelPlanner.Core.Triposo;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocalHighlightsController : ControllerBase
    {
        private readonly ITravelInfoService _travelInfoService;
        public LocalHighlightsController(ITravelInfoService travelInfoService)
        {
            _travelInfoService = travelInfoService;
        }

        [Authorize]
        [HttpGet]
        async public Task<LocalHighlights[]> GetLocalHighlights(int latitude, int longitude, int? maxDistance = null)
        {
            return await _travelInfoService.GetLocalHighlights(latitude, longitude, maxDistance);
        }
    }
}
