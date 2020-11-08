using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPlanner.Core.DomainModels;
using TriposoLocation = TravelPlanner.Core.Triposo.Location;
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
        Task AddLocation(TriposoLocation location, string tarvelIdentity);
        Task AddFlight(Flight flight, string tarvelIdentity);
        Task<DomainLocation> GetLocation(string tarvelIdentity);
    }

    public class TravelService : ITravelService
    {
        private TravelRepository TravelRepository;
        private LocationRepository LocationRepository;
        private FlightRepository FlightRepository;

        public TravelService()
        {
            TravelRepository = new TravelRepository();
            LocationRepository = new LocationRepository();
            FlightRepository = new FlightRepository();
        }

        public async Task<IEnumerable<NewTravel>> GetTravels(string userMail)
        {
            var response = await TravelRepository.GetTravels(userMail);
            return response.Select(t => TravelConverter.ToDomainTravel(t)).ToList();
        }

        public async Task<NewTravel> AddTravel(NewTravel newTravel, string userMail)
        {
            newTravel.TravelIdentity = userMail + newTravel.TravelDestination.City + newTravel.TravelDestination.Country + newTravel.Date;
            var dbTravel = TravelConverter.ToDbTravel(newTravel);
            var response =  await TravelRepository.AddTravelToUser(dbTravel, userMail);
            return TravelConverter.ToDomainTravel(response);
        }

        public async Task AddLocation(TriposoLocation triposoLocation, string tarvelIdentity)
        {
            var location = new DBLocation(triposoLocation);
            await LocationRepository.AddLocation(location, tarvelIdentity);
        }

        public async Task<DomainLocation> GetLocation(string tarvelIdentity)
        {
            var response = await LocationRepository.GetLocation(tarvelIdentity);
            return new DomainLocation(response);
        }

        public async Task AddFlight(Flight flight, string tarvelIdentity)
        {
            var dbFlight = FlightConverter.ToDBFlight(flight);
            var arrivalFlightStatus = FlightConverter.ToDBAirportFlightStatus(flight.Arrival);
            var departureFlightStatus = FlightConverter.ToDBAirportFlightStatus(flight.Departure);
            await FlightRepository.AddFlight(dbFlight, tarvelIdentity);
            await FlightRepository.AddArrivalAirportFlightStatus(arrivalFlightStatus, flight.AirlineId, flight.FlightNumber);
            await FlightRepository.AddDepartureAirportFlightStatus(departureFlightStatus, flight.AirlineId, flight.FlightNumber);
        }
    }
}
