using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DayPlannerController : ControllerBase
    {
        private readonly ITravelInfoService TravelInfoService;
        public DayPlannerController()
        {
            TravelInfoService = new TravelInfoService();
        }

        [HttpGet]
        public async Task<DayPlan[]> GetDayPlan(string locationId, string arrivalTime, string departureTime, string startDate, string endDate, string hotelPoiId = null, int? itemsPerDay = null, int? maxDistance = null)
        {
            return await TravelInfoService.GetDayPlanAsync(locationId, arrivalTime, departureTime, startDate, endDate, hotelPoiId, itemsPerDay, maxDistance);
        }
    }
}
