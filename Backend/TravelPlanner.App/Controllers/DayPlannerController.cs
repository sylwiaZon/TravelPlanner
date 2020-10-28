using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core.Triposo;
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

        public async Task<DayPlan[]> GetDayPlan(string locationId, string arrivalTime = null, string departureTime = null, string startDate = null, string endDate = null, string hotelPoiId = null, int? itemsPerDay = null, int? maxDistance = null)
        {
            return await TravelInfoService.GetDayPlanAsync(locationId, arrivalTime, departureTime, startDate, endDate, hotelPoiId, itemsPerDay, maxDistance);
        }
    }
}
