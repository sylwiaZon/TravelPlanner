using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core.Triposo;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITravelInfoService TravelInfoService;
        public TagsController()
        {
            TravelInfoService = new TravelInfoService();
        }

        [HttpGet]
        public Task<CommonTagLabel[]> GetTags()
        {
            return TravelInfoService.GetAvailableTagsAsync();
        }
    }
}
