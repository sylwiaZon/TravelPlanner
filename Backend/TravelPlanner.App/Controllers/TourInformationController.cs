using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelPlanner.App.Helpers;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TourInformationController : ControllerBase
    {
        private readonly ITravelInfoService _travelInfoService;
        public TourInformationController(ITravelInfoService travelInfoService)
        {
            _travelInfoService = travelInfoService;
        }

        [Authorize]
        [HttpGet]
        public Task<Tour[]> GetTourInformation(string locationId, string poiId, string tagLabels)
        {
            return _travelInfoService.GetTourInformation(locationId, poiId, tagLabels);
        }
    }
}
