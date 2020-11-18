using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelPlanner.App.Helpers;
using TravelPlanner.Core.Triposo;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ITravelInfoService _travelInfoService;
        public ArticlesController(ITravelInfoService travelInfoService)
        {
            _travelInfoService = travelInfoService;
        }

        [Authorize]
        [HttpGet]
        async public Task<Article[]> GetLocationInfo(string cityName, string tag = null)
        {
            return await _travelInfoService.GetArticlesAsync(cityName, tag);
        }
    }
}
