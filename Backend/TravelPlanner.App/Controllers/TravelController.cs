using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Services;
using TravelPlanner.Core.Exceptions;

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
        public Task AddLocation([FromBody] Location location, string tarvelIdentity)
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
        [Route("hotel")]
        public Task AddHotel([FromBody] Hotel hotel, string tarvelIdentity)
        {
            return TravelService.AddHotel(hotel, tarvelIdentity);
        }

        [HttpGet]
        [Route("hotel")]
        public Task<Hotel> GetHotel(string tarvelIdentity)
        {
            return TravelService.GetHotel(tarvelIdentity);
        }

        [HttpPost]
        [Route("citywalk")]
        public Task AddCityWalk([FromBody] CityWalk walk, string tarvelIdentity)
        {
            return TravelService.AddCityWalk(walk, tarvelIdentity);
        }

        [HttpGet]
        [Route("citywalk")]
        public Task<CityWalk[]> GetCityWalks(string tarvelIdentity)
        {
            return TravelService.GetCityWalks(tarvelIdentity);
        }

        [HttpPost]
        [Route("dayplan")]
        public Task AddDayPlan([FromBody] DayPlan plan, string tarvelIdentity)
        {
            return TravelService.AddDayPlan(plan, tarvelIdentity);
        }

        [HttpGet]
        [Route("dayplan")]
        public Task<DayPlan[]> GetDayPlans(string tarvelIdentity)
        {
            return TravelService.GetDayPlans(tarvelIdentity);
        }

        [HttpPost]
        [Route("flight")]
        public Task AddFlight([FromBody] Flight flight, string flightType, string tarvelIdentity)
        {
            if(flightType == "to")
            {
                return TravelService.AddToFlight(flight, tarvelIdentity);
            }
            if (flightType == "from")
            {
                return TravelService.AddFromFlight(flight, tarvelIdentity);
            }
            throw new TravelPlannerException(400, "Bad flight type: choose either 'to' or 'from'");
        }
    }
}
