using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core.Flights;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightsService FlightsService;
        public FlightsController()
        {
            FlightsService = new FlightsService();
        }

        [HttpGet]
        async public Task<FlightsSchedule> GetSchedule(string origin, string destination, string date)
        {
            return await FlightsService.GetSchedule(origin, destination, date);
        }

        [HttpGet]
        [Route("status")]
        async public Task<FlightStatusResponse> GetStatus(string flightNumber, string date)
        {
            return await FlightsService.GetFlightStatus(flightNumber, date);
        }
    }
}
