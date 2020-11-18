using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.App.Helpers;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DayPlannerController : ControllerBase
    {
        private readonly ITravelInfoService _travelInfoService;
        public DayPlannerController(ITravelInfoService travelInfoService)
        {
            _travelInfoService = travelInfoService;
        }

        [Authorize]
        [HttpGet]
        public async Task<DayPlan[]> GetDayPlan(string locationId, string arrivalTime, string departureTime, string startDate, string endDate, string hotelPoiId = null, int? itemsPerDay = null, int? maxDistance = null)
        {
            return await _travelInfoService.GetDayPlanAsync(locationId, arrivalTime, departureTime, startDate, endDate, hotelPoiId, itemsPerDay, maxDistance);
        }
    }
}
