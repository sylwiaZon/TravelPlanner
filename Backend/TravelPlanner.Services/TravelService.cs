using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPlanner.Core.DomainModels;
using DBLocation = TravelPlanner.Core.DataBaseModels.Location;
using DomainLocation = TravelPlanner.Core.DomainModels.Location;
using TravelPlanner.Repositories;
using TravelPlanner.Services.Converters;
using System.Linq;

namespace TravelPlanner.Services
{
    public interface ITravelService
    {
        Task<IEnumerable<NewTravel>> GetTravels(string user);
        Task<NewTravel> AddTravel(NewTravel travel, string userMail);
        Task AddLocation(DomainLocation location, string tarvelIdentity);
        Task AddFromFlight(Flight flight, string tarvelIdentity);
        Task AddToFlight(Flight flight, string tarvelIdentity);
        Task<DomainLocation> GetLocation(string tarvelIdentity);
        Task AddHotel(Hotel newHotel, string tarvelIdentity);
        Task<Hotel> GetHotel(string tarvelIdentity);
        Task AddCityWalk(CityWalk newHotel, string tarvelIdentity);
        Task<CityWalk[]> GetCityWalks(string tarvelIdentity);
        Task AddDayPlan(DayPlan newDayPlan, string tarvelIdentity);
        Task<DayPlan[]> GetDayPlans(string tarvelIdentity);
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

        public TravelService()
        {
            TravelRepository = new TravelRepository();
            LocationRepository = new LocationRepository();
            FlightRepository = new FlightRepository();
            HotelRepository = new HotelRepository();
            CityWalkRepository = new CityWalkRepository();
            PoiRepository = new PoiRepository();
            DayPlanRepository = new DayPlanRepository();
            DayPlanRepository = new DayPlanRepository();
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

        public async Task AddLocation(DomainLocation newLocation, string tarvelIdentity)
        {
            var location = LocationConverter.ToDbLocation(newLocation);
            await LocationRepository.AddLocation(location, tarvelIdentity);
        }

        public async Task<DomainLocation> GetLocation(string tarvelIdentity)
        {
            var response = await LocationRepository.GetLocation(tarvelIdentity);
            return new DomainLocation(response);
        }

        public async Task AddHotel(Hotel newHotel, string tarvelIdentity)
        {
            var hotel = HotelConverter.ToDbHotel(newHotel);
            await HotelRepository.AddHotel(hotel, tarvelIdentity);
        }

        public async Task<Hotel> GetHotel(string tarvelIdentity)
        {
            var response = await HotelRepository.GetHotel(tarvelIdentity);
            return HotelConverter.ToDomainHotel(response);
        }

        public async Task AddToFlight(Flight flight, string tarvelIdentity)
        {
            var dbFlight = FlightConverter.ToDBFlight(flight);
            await FlightRepository.AddToFlight(dbFlight, tarvelIdentity);
        }

        public async Task AddFromFlight(Flight flight, string tarvelIdentity)
        {
            var dbFlight = FlightConverter.ToDBFlight(flight);
            await FlightRepository.AddFromFlight(dbFlight, tarvelIdentity);
        }

        public async Task AddCityWalk(CityWalk newWalk, string tarvelIdentity) 
        {
            var location = await LocationRepository.GetLocation(tarvelIdentity);
            var dbWalk = CityWalkConverter.ToDbCityWalk(newWalk);
            var walk = await CityWalkRepository.AddCityWalk(dbWalk, tarvelIdentity, location.LocationId);
            foreach(var domainPoint in newWalk.WayPoints)
            {
                var dbPoint = CityWalkConverter.ToDbWayPoint(domainPoint);
                var point = await CityWalkRepository.AddWayPoint(dbPoint, walk.CityWalkId);
                var poi = PoiConverter.ToDbPoi(domainPoint.Poi);
                await PoiRepository.AddPoiToWayPoint(poi, point.WayPointId, location.LocationId);
            }
        }
        
        public async Task<CityWalk[]> GetCityWalks(string tarvelIdentity)
        {
            var dbWalks = await CityWalkRepository.GetCityWalks(tarvelIdentity);
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

        public async Task AddDayPlan(DayPlan newDayPlan, string tarvelIdentity) 
        {
            var location = await LocationRepository.GetLocation(tarvelIdentity);
            var dbDayPlan = DayPlanConverter.ToDbDayPlan(newDayPlan);
            await DayPlanRepository.AddDayPlan(dbDayPlan, tarvelIdentity, location.LocationId);
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

        public async Task<DayPlan[]> GetDayPlans(string tarvelIdentity) 
        {
            var dbPlans = await DayPlanRepository.GetDayPlans(tarvelIdentity);
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
    }
}
