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
        public Task AddLocation([FromBody] Location location, string travelIdentity)
        {
            return TravelService.AddLocation(location, travelIdentity);
        }

        [HttpGet]
        [Route("location")]
        public Task<Location> GetLocation(string travelIdentity)
        {
            return TravelService.GetLocation(travelIdentity);
        }

        [HttpPost]
        [Route("hotel")]
        public Task AddHotel([FromBody] Hotel hotel, string travelIdentity)
        {
            return TravelService.AddHotel(hotel, travelIdentity);
        }

        [HttpGet]
        [Route("hotel")]
        public Task<Hotel> GetHotel(string travelIdentity)
        {
            return TravelService.GetHotel(travelIdentity);
        }

        [HttpPost]
        [Route("citywalk")]
        public Task AddCityWalk([FromBody] CityWalk walk, string travelIdentity)
        {
            return TravelService.AddCityWalk(walk, travelIdentity);
        }

        [HttpGet]
        [Route("citywalk")]
        public Task<CityWalk[]> GetCityWalks(string travelIdentity)
        {
            return TravelService.GetCityWalks(travelIdentity);
        }

        [HttpPost]
        [Route("dayplan")]
        public Task AddDayPlan([FromBody] DayPlan plan, string travelIdentity)
        {
            return TravelService.AddDayPlan(plan, travelIdentity);
        }

        [HttpGet]
        [Route("dayplan")]
        public Task<DayPlan[]> GetDayPlans(string travelIdentity)
        {
            return TravelService.GetDayPlans(travelIdentity);
        }

        [HttpGet]
        [Route("tour")]
        public Task<Tour[]> GetTours(string travelIdentity)
        {
            return TravelService.GetTours(travelIdentity);
        }

        [HttpPost]
        [Route("tour")]
        public Task AddTour([FromBody] Tour tour, string travelIdentity)
        {
            return TravelService.AddTour(tour, travelIdentity);
        }

        [HttpGet]
        [Route("todo")]
        public Task<ToDoItem[]> GetToDoItem(string travelIdentity)
        {
            return TravelService.GetToDoItems(travelIdentity);
        }

        [HttpPost]
        [Route("todo")]
        public Task<ToDoItem> AddToDo([FromBody] ToDoItem item, string travelIdentity)
        {
            return TravelService.AddToDoItem(item, travelIdentity);
        }

        [HttpPatch]
        [Route("todo")]
        public Task<ToDoItem> UpdateToDo([FromBody] ToDoItem item)
        {
            return TravelService.UpdateToDoItem(item);
        }

        [HttpGet]
        [Route("tosee")]
        public Task<ToSeeItem[]> GetToSeeItem(string travelIdentity)
        {
            return TravelService.GetToSeeItem(travelIdentity);
        }

        [HttpPost]
        [Route("tosee")]
        public Task<ToSeeItem> AddToSeeItem([FromBody] ToSeeItem item, string poiId, string travelIdentity)
        {
            return TravelService.AddToSeeItem(item, poiId, travelIdentity);
        }

        [HttpPatch]
        [Route("tosee")]
        public Task<ToSeeItem> UpdateToDo([FromBody] ToSeeItem item)
        {
            return TravelService.UpdateToSeeItem(item);
        }

        [HttpGet]
        [Route("flight")]
        public async Task<Flight> GetFlight(string flightType, string travelIdentity)
        {
            if (flightType == "to")
            {
                return await TravelService.GetToFlight(travelIdentity);
            }
            if (flightType == "from")
            {
                return await TravelService.GetFromFlight(travelIdentity);
            }
            throw new TravelPlannerException(400, "Bad flight type: choose either 'to' or 'from'");
        }

        [HttpPost]
        [Route("flight")]
        public Task AddFlight([FromBody] Flight flight, string flightType, string travelIdentity)
        {
            if(flightType == "to")
            {
                return TravelService.AddToFlight(flight, travelIdentity);
            }
            if (flightType == "from")
            {
                return TravelService.AddFromFlight(flight, travelIdentity);
            }
            throw new TravelPlannerException(400, "Bad flight type: choose either 'to' or 'from'");
        }
    }
}
