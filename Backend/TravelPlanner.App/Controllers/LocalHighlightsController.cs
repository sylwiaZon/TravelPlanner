using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core.Triposo;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocalHighlightsController : ControllerBase
    {
        private readonly TravelInfoService TravelInfoService;
        public LocalHighlightsController()
        {
            TravelInfoService = new TravelInfoService();
        }

        [HttpGet]
        async public Task<LocalHighlights[]> GetLocalHighlights(int latitude, int longitude, int? maxDistance = null)
        {
            return await TravelInfoService.GetLocalHighlights(latitude, longitude, maxDistance);
        }
    }
}
