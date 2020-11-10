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
    }

    public class TravelService : ITravelService
    {
        private TravelRepository TravelRepository;
        private LocationRepository LocationRepository;
        private FlightRepository FlightRepository;
        private HotelRepository HotelRepository;

        public TravelService()
        {
            TravelRepository = new TravelRepository();
            LocationRepository = new LocationRepository();
            FlightRepository = new FlightRepository();
            HotelRepository = new HotelRepository();
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
    }
}
