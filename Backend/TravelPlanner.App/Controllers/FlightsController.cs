﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Core.Flights;
using TravelPlanner.Services;
using Flight = TravelPlanner.Core.DomainModels.Flight;

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
        async public Task<IEnumerable<Flight>> GetSchedule(string origin, string destination, string date)
        {
            return await FlightsService.GetSchedule(origin, destination, date);
        }

        [HttpGet]
        [Route("status")]
        async public Task<Flight> GetStatus(string flightNumber, string date)
        {
            return await FlightsService.GetFlightStatus(flightNumber, date);
        }

        [HttpGet]
        [Route("airports")]
        async public Task<NearestAirport> GetNearestAirport(float latitude, float longitude)
        {
            return await FlightsService.GetNearestAirport(latitude, longitude);
        }
    }
}
