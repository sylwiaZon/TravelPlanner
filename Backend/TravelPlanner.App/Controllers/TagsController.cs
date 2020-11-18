using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.App.Helpers;
using TravelPlanner.Core.Triposo;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITravelInfoService _travelInfoService;
        public TagsController(ITravelInfoService travelInfoService)
        {
            this._travelInfoService = travelInfoService;
        }

        [Authorize]
        [HttpGet]
        public Task<CommonTagLabel[]> GetTags()
        {
            return _travelInfoService.GetAvailableTagsAsync();
        }
    }
}
