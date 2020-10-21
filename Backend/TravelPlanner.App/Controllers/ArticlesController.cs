using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelPlanner.Core.Triposo;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly TravelInfoService TravelInfoService;
        public ArticlesController()
        {
            TravelInfoService = new TravelInfoService();
        }

        [HttpGet]
        async public Task<Article[]> GetLocationInfo(string cityName, string tag = null)
        {
            return await TravelInfoService.GetArticlesAsync(cityName, tag);
        }
    }
}
