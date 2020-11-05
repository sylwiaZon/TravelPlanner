using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelController : ControllerBase
    {
        private readonly ITravelService TravelService;
        public TravelController()
        {
            TravelService = new TravelService();
        }

        [HttpPost]
        public Task<IEnumerable<Travel>> Get([FromBody] User user)
        {
            return TravelService.GetTravels(user);
        }

        [HttpPost]
        [Route("new")]
        public Task AddTravel([FromBody] NewTravel travel)
        {
            return TravelService.AddTravel(travel);
        }
    }
}
