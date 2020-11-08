using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core.DomainModels;
using TriposoLocation = TravelPlanner.Core.Triposo.Location;
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

        [HttpGet]
        public Task<IEnumerable<NewTravel>> GetTravels(string userMail)
        {
            return TravelService.GetTravels(userMail);
        }

        [HttpPost]
        public Task<NewTravel> AddTravel([FromBody] NewTravel travel, string userMail)
        {
            return TravelService.AddTravel(travel, userMail);
        }

        [HttpPost]
        [Route("location")]
        public Task AddLocation([FromBody] TriposoLocation location, string tarvelIdentity)
        {
            return TravelService.AddLocation(location, tarvelIdentity);
        }

        [HttpGet]
        [Route("location")]
        public Task<Location> GetLocation(string tarvelIdentity)
        {
            return TravelService.GetLocation(tarvelIdentity);
        }

        [HttpPost]
        [Route("flight")]
        public Task AddFlight([FromBody] Flight flight, string tarvelIdentity)
        {
            return TravelService.AddFlight(flight, tarvelIdentity);
        }
    }
}
