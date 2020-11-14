using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPlanner.Core.DomainModels;
using DomainLocation = TravelPlanner.Core.DomainModels.Location;
using TravelPlanner.Repositories;
using TravelPlanner.Services.Converters;
using System.Linq;
using System;

namespace TravelPlanner.Services
{
    public interface ITravelService
    {
        Task<IEnumerable<NewTravel>> GetTravels(string user);
        Task<NewTravel> AddTravel(NewTravel travel, string userMail);
        Task AddLocation(DomainLocation location, string travelIdentity);
        Task AddFromFlight(Flight flight, string travelIdentity);
        Task AddToFlight(Flight flight, string travelIdentity);
        Task<Flight> GetToFlight(string travelIdentity);
        Task<Flight> GetFromFlight(string travelIdentity);
        Task<DomainLocation> GetLocation(string travelIdentity);
        Task AddHotel(Hotel newHotel, string travelIdentity);
        Task<Hotel> GetHotel(string travelIdentity);
        Task AddCityWalk(CityWalk newHotel, string travelIdentity);
        Task<CityWalk[]> GetCityWalks(string travelIdentity);
        Task AddDayPlan(DayPlan newDayPlan, string travelIdentity);
        Task<DayPlan[]> GetDayPlans(string travelIdentity);
        Task AddTour(Tour newTour, string travelIdentity);
        Task<Tour[]> GetTours(string travelIdentity);
        Task<ToDoItem> AddToDoItem(ToDoItem newItem, string travelIdentity);
        Task<ToDoItem[]> GetToDoItems(string travelIdentity);
        Task<ToDoItem> UpdateToDoItem(ToDoItem newItem);
        Task<ToSeeItem> AddToSeeItem(ToSeeItem newItem, string poiId, string travelIdentity);
        Task<ToSeeItem[]> GetToSeeItem(string travelIdentity);
        Task<ToSeeItem> UpdateToSeeItem(ToSeeItem newItem);
    }

    public class TravelService : ITravelService
    {
        private TravelRepository TravelRepository;
        private LocationRepository LocationRepository;
        private FlightRepository FlightRepository;
        private HotelRepository HotelRepository;
        private CityWalkRepository CityWalkRepository;
        private PoiRepository PoiRepository;
        private DayPlanRepository DayPlanRepository;
        private TourRepository TourRepository;
        private ListsRepository ListsRepository;

        public TravelService()
        {
            TravelRepository = new TravelRepository();
            LocationRepository = new LocationRepository();
            FlightRepository = new FlightRepository();
            HotelRepository = new HotelRepository();
            CityWalkRepository = new CityWalkRepository();
            PoiRepository = new PoiRepository();
            DayPlanRepository = new DayPlanRepository();
            TourRepository = new TourRepository();
            ListsRepository = new ListsRepository();
        }

        public async Task<IEnumerable<NewTravel>> GetTravels(string userMail)
        {
            var response = await TravelRepository.GetTravels(userMail);
            return response.Select(t => TravelConverter.ToDomainTravel(t)).ToList();
        }

        public async Task<NewTravel> AddTravel(NewTravel newTravel, string userMail)
        {
            newTravel.TravelId = userMail + newTravel.TravelDestination.City + newTravel.TravelDestination.Country + newTravel.Date;
            var dbTravel = TravelConverter.ToDbTravel(newTravel);
            var response =  await TravelRepository.AddTravelToUser(dbTravel, userMail);
            return TravelConverter.ToDomainTravel(response);
        }

        public async Task AddLocation(DomainLocation newLocation, string travelIdentity)
        {
            var location = LocationConverter.ToDbLocation(newLocation);
            await LocationRepository.AddLocation(location, travelIdentity);
        }

        public async Task<DomainLocation> GetLocation(string travelIdentity)
        {
            var response = await LocationRepository.GetLocation(travelIdentity);
            return new DomainLocation(response);
        }

        public async Task AddHotel(Hotel newHotel, string travelIdentity)
        {
            var hotel = HotelConverter.ToDbHotel(newHotel);
            await HotelRepository.AddHotel(hotel, travelIdentity);
        }

        public async Task<Hotel> GetHotel(string travelIdentity)
        {
            var response = await HotelRepository.GetHotel(travelIdentity);
            return HotelConverter.ToDomainHotel(response);
        }

        public async Task AddToFlight(Flight flight, string travelIdentity)
        {
            var dbFlight = FlightConverter.ToDBFlight(flight);
            await FlightRepository.AddToFlight(dbFlight, travelIdentity);
        }

        public async Task AddFromFlight(Flight flight, string travelIdentity)
        {
            var dbFlight = FlightConverter.ToDBFlight(flight);
            await FlightRepository.AddFromFlight(dbFlight, travelIdentity);
        }

        public async Task<Flight> GetToFlight(string travelIdentity)
        {
            var flight = await FlightRepository.GetToFlight(travelIdentity);
            return FlightConverter.ToDomainFlight(flight);
        }

        public async Task<Flight> GetFromFlight(string travelIdentity)
        {
            var flight = await FlightRepository.GetFromFlight(travelIdentity);
            return FlightConverter.ToDomainFlight(flight);
        }

        public async Task AddCityWalk(CityWalk newWalk, string travelIdentity) 
        {
            var location = await LocationRepository.GetLocation(travelIdentity);
            var dbWalk = CityWalkConverter.ToDbCityWalk(newWalk);
            var walk = await CityWalkRepository.AddCityWalk(dbWalk, travelIdentity, location.LocationId);
            foreach(var domainPoint in newWalk.WayPoints)
            {
                var dbPoint = CityWalkConverter.ToDbWayPoint(domainPoint);
                var point = await CityWalkRepository.AddWayPoint(dbPoint, walk.CityWalkId);
                var poi = PoiConverter.ToDbPoi(domainPoint.Poi);
                await PoiRepository.AddPoiToWayPoint(poi, point.WayPointId, location.LocationId);
            }
        }
        
        public async Task<CityWalk[]> GetCityWalks(string travelIdentity)
        {
            var dbWalks = await CityWalkRepository.GetCityWalks(travelIdentity);
            var domainWalks = new List<CityWalk>();
            foreach (var walk in dbWalks)
            {
                var dbPoints = await CityWalkRepository.GetWayPoints(walk.CityWalkId);
                var domainPoints = new List<WayPoint>();
                foreach(var point in dbPoints)
                {
                    var dbPoi = await CityWalkRepository.GetPoi(point.WayPointId);
                    var domainPoint = CityWalkConverter.ToDomainWayPoint(point, dbPoi);
                    domainPoints.Add(domainPoint);
                }
                var domainWalk = CityWalkConverter.ToDomainCityWalk(walk, domainPoints.ToArray());
                domainWalks.Add(domainWalk);
            }
            return domainWalks.ToArray();
        }

        public async Task AddDayPlan(DayPlan newDayPlan, string travelIdentity) 
        {
            var location = await LocationRepository.GetLocation(travelIdentity);
            var dbDayPlan = DayPlanConverter.ToDbDayPlan(newDayPlan);
            await DayPlanRepository.AddDayPlan(dbDayPlan, travelIdentity, location.LocationId);
            foreach(var day in newDayPlan.Days)
            {
                var dbDay = DayPlanConverter.ToDbItinerary(day);
                await DayPlanRepository.AddItinerary(dbDay, newDayPlan.DayPlanId);
                foreach(var item in day.ItineraryItems)
                {
                    var dbItem = DayPlanConverter.ToDbItineraryItem(item);
                    await DayPlanRepository.AddItineraryItem(dbItem, dbDay.ItineraryId);
                    var poi = PoiConverter.ToDbPoi(item.Poi);
                    await PoiRepository.AddPoiToDayItem(poi, item.ItineraryItemId, location.LocationId);
                }
            }

        }

        public async Task<DayPlan[]> GetDayPlans(string travelIdentity) 
        {
            var dbPlans = await DayPlanRepository.GetDayPlans(travelIdentity);
            var domainDayPlans = new List<DayPlan>();
            foreach (var plan in dbPlans)
            {
                var dbDays = await DayPlanRepository.GetItineraries(plan.DayPlanId);
                var domainDays = new List<Itinerary>();
                foreach (var day in dbDays)
                {
                    var dbDayItems = await DayPlanRepository.GetItinerariyItems(day.ItineraryId);
                    var domainItems = new List<ItineraryItem>();
                    foreach (var item in dbDayItems)
                    {
                        var dbPoi = await DayPlanRepository.GetPoi(item.ItineraryItemId);
                        var poi = PoiConverter.ToDomainPoi(dbPoi);
                        var domainItem = DayPlanConverter.ToDomainItineraryItem(item, poi);
                        domainItems.Add(domainItem);
                    }
                    var domainDay = DayPlanConverter.ToDomainItinerary(day, domainItems.ToArray());
                    domainDays.Add(domainDay);
                }
                var domainDayPlan = DayPlanConverter.ToDomainDayPlan(plan, domainDays.ToArray());
                domainDayPlans.Add(domainDayPlan);
            }
            return domainDayPlans.ToArray();
        }

        public async Task AddTour(Tour newTour, string travelIdentity)
        {
            var dbTour = TourConverter.ToDbTour(newTour);
            await TourRepository.AddTour(dbTour, travelIdentity);
        }

        public async Task<Tour[]> GetTours(string travelIdentity)
        {
            var tours = await TourRepository.GetTours(travelIdentity);
            return tours.Select(t => TourConverter.ToDomainTour(t)).ToArray();
        }

        public async Task<ToDoItem> AddToDoItem(ToDoItem newItem, string travelIdentity)
        {
            var toDo = ToDoItemConverter.ToDbToDoItem(newItem);
            if(toDo.Id == null)
            {
                toDo.Id = Guid.NewGuid().ToString();
            }
            var addedItem = await ListsRepository.AddToDoItem(toDo, travelIdentity);
            return ToDoItemConverter.ToDomainToDoItem(addedItem);
        }

        public async Task<ToDoItem[]> GetToDoItems(string travelIdentity)
        {
            var items = await ListsRepository.GetToDoItems(travelIdentity);
            return items.Select(i => ToDoItemConverter.ToDomainToDoItem(i)).ToArray();
        }

        public async Task<ToDoItem> UpdateToDoItem(ToDoItem newItem)
        {
            var item = ToDoItemConverter.ToDbToDoItem(newItem);
            var resp = await ListsRepository.EditToDoItem(item);
            return ToDoItemConverter.ToDomainToDoItem(resp);
        }

        public async Task<ToSeeItem> AddToSeeItem(ToSeeItem newItem, string poiId, string travelIdentity)
        {
            var toDo = ToSeeItemConverter.ToDbToSeeItem(newItem);
            if (toDo.Id == null)
            {
                toDo.Id = Guid.NewGuid().ToString();
            }
            var addedItem = await ListsRepository.AddToSeeItem(toDo, poiId, travelIdentity);
            var poi = await ListsRepository.GetToSeeItemPoi(addedItem.Id);
            var convertedPoi = PoiConverter.ToDomainPoi(poi);
            return ToSeeItemConverter.ToDomainToSeeItem(addedItem, convertedPoi);
        }

        public async Task<ToSeeItem[]> GetToSeeItem(string travelIdentity)
        {
            var items = await ListsRepository.GetToSeeItems(travelIdentity);
            var domainItems = new List<ToSeeItem>();
            foreach(var item in items)
            {
                var poi = await ListsRepository.GetToSeeItemPoi(item.Id);
                var convertedPoi = PoiConverter.ToDomainPoi(poi);
                var domainItem = ToSeeItemConverter.ToDomainToSeeItem(item, convertedPoi);
                domainItems.Add(domainItem);
            }
            return domainItems.ToArray();
        }

        public async Task<ToSeeItem> UpdateToSeeItem(ToSeeItem newItem)
        {
            var item = ToSeeItemConverter.ToDbToSeeItem(newItem);
            var resp = await ListsRepository.EditToSeeItem(item);
            var poi = await ListsRepository.GetToSeeItemPoi(resp.Id);
            var convertedPoi = PoiConverter.ToDomainPoi(poi);
            return ToSeeItemConverter.ToDomainToSeeItem(resp, convertedPoi);
        }
    }
}
