using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.App.Helpers;
using TravelPlanner.Core.Flights;
using TravelPlanner.Services;
using Flight = TravelPlanner.Core.DomainModels.Flight;
using Airport = TravelPlanner.Core.DomainModels.Airport;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightsService _flightsService;
        public FlightsController(IFlightsService flightsService)
        {
            _flightsService = flightsService;
        }

        [Authorize]
        [HttpGet]
        async public Task<IEnumerable<Flight>> GetSchedule(string origin, string destination, string date)
        {
            return await _flightsService.GetSchedule(origin, destination, date);
        }

        [Authorize]
        [HttpGet]
        [Route("status")]
        async public Task<Flight> GetStatus(string flightNumber, string date)
        {
            return await _flightsService.GetFlightStatus(flightNumber, date);
        }

        [Authorize]
        [HttpGet]
        [Route("airports")]
        async public Task<Airport[]> GetNearestAirport(float latitude, float longitude)
        {
            return await _flightsService.GetNearestAirport(latitude, longitude);
        }
    }
}
