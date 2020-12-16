using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Services;
using TravelPlanner.Core.Exceptions;
using TravelPlanner.App.Helpers;

namespace TravelPlanner.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelController : ControllerBase
    {
        private readonly ITravelService _travelService;
        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }

        [Authorize]
        [HttpGet]
        public Task<IEnumerable<TravelsResponse>> GetTravels()
        {
            var userMail = (string)HttpContext.Items["User"];
            return _travelService.GetTravels(userMail);
        }

        [Authorize]
        [HttpPost]
        public Task<NewTravel> AddTravel([FromBody] NewTravel travel)
        {
            var userMail = (string)HttpContext.Items["User"];
            return _travelService.AddTravel(travel, userMail);
        }

        [Authorize]
        [HttpPost]
        [Route("location")]
        public Task AddLocation([FromBody] Location location, string travelIdentity)
        {
            return _travelService.AddLocation(location, travelIdentity);
        }

        [Authorize]
        [HttpGet]
        [Route("location")]
        public Task<Location> GetLocation(string travelIdentity)
        {
            return _travelService.GetLocation(travelIdentity);
        }

        [Authorize]
        [HttpGet]
        [Route("poi")]
        public Task<Poi[]> GetPois(string travelIdentity)
        {
            return _travelService.GetPoisForTravel(travelIdentity);
        }

        [Authorize]
        [HttpPost]
        [Route("hotel")]
        public Task AddHotel([FromBody] Hotel hotel, string travelIdentity)
        {
            return _travelService.AddHotel(hotel, travelIdentity);
        }

        [Authorize]
        [HttpGet]
        [Route("hotel")]
        public Task<HotelWithDetails> GetHotel(string travelIdentity)
        {
            return _travelService.GetHotel(travelIdentity);
        }

        [Authorize]
        [HttpPost]
        [Route("citywalk")]
        public Task AddCityWalk([FromBody] CityWalk walk, string travelIdentity)
        {
            return _travelService.AddCityWalk(walk, travelIdentity);
        }

        [Authorize]
        [HttpGet]
        [Route("citywalk")]
        public Task<IEnumerable<CityWalk>> GetCityWalks(string travelIdentity)
        {
            return _travelService.GetCityWalks(travelIdentity);
        }

        [Authorize]
        [HttpPost]
        [Route("dayplan")]
        public Task AddDayPlan([FromBody] DayPlan plan, string travelIdentity)
        {
            return _travelService.AddDayPlan(plan, travelIdentity);
        }

        [Authorize]
        [HttpGet]
        [Route("dayplan")]
        public Task<IEnumerable<DayPlan>> GetDayPlans(string travelIdentity)
        {
            return _travelService.GetDayPlans(travelIdentity);
        }

        [Authorize]
        [HttpGet]
        [Route("tour")]
        public Task<Tour[]> GetTours(string travelIdentity)
        {
            return _travelService.GetTours(travelIdentity);
        }

        [Authorize]
        [HttpPost]
        [Route("tour")]
        public Task AddTour([FromBody] Tour tour, string travelIdentity)
        {
            return _travelService.AddTour(tour, travelIdentity);
        }

        [HttpGet]
        [Route("todo")]
        public Task<ToDoItem[]> GetToDoItem(string travelIdentity)
        {
            return _travelService.GetToDoItems(travelIdentity);
        }

        [Authorize]
        [HttpPost]
        [Route("todo")]
        public Task<ToDoItem> AddToDo(string item, string travelIdentity)
        {
            return _travelService.AddToDoItem(item, travelIdentity);
        }

        [Authorize]
        [HttpPatch]
        [Route("todo")]
        public Task<ToDoItem> UpdateToDo([FromBody] ToDoItem item)
        {
            return _travelService.UpdateToDoItem(item);
        }

        [Authorize]
        [HttpGet]
        [Route("tosee")]
        public Task<ToSeeItem[]> GetToSeeItem(string travelIdentity)
        {
            return _travelService.GetToSeeItem(travelIdentity);
        }

        [Authorize]
        [HttpPost]
        [Route("tosee")]
        public Task<ToSeeItem> AddToSeeItem(string poiId, string travelIdentity)
        {
            return _travelService.AddToSeeItem(poiId, travelIdentity);
        }

        [Authorize]
        [HttpPatch]
        [Route("tosee")]
        public Task<ToSeeItem> UpdateToSeeItem([FromBody] ToSeeItem item)
        {
            return _travelService.UpdateToSeeItem(item);
        }

        [Authorize]
        [HttpGet]
        [Route("flight")]
        public async Task<Flight> GetFlight(string flightType, string travelIdentity)
        {
            if (flightType == "to")
            {
                return await _travelService.GetToFlight(travelIdentity);
            }
            if (flightType == "from")
            {
                return await _travelService.GetFromFlight(travelIdentity);
            }
            throw new TravelPlannerException(400, "Bad flight type: choose either 'to' or 'from'");
        }

        [Authorize]
        [HttpPost]
        [Route("flight")]
        public Task AddFlight([FromBody] Flight flight, string flightType, string travelIdentity)
        {
            if(flightType == "to")
            {
                return _travelService.AddToFlight(flight, travelIdentity);
            }
            if (flightType == "from")
            {
                return _travelService.AddFromFlight(flight, travelIdentity);
            }
            throw new TravelPlannerException(400, "Bad flight type: choose either 'to' or 'from'");
        }
    }
}
