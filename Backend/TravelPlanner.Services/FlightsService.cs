using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Core.Flights;
using TravelPlanner.Repositories;
using TravelPlanner.Services.Converters;
using Flight = TravelPlanner.Core.DomainModels.Flight;
using Airport = TravelPlanner.Core.DomainModels.Airport;
using System.Linq;

namespace TravelPlanner.Services
{
    public interface IFlightsService
    {
        Task<IEnumerable<Flight>> GetSchedule(string origin, string destination, string date);
        Task<Flight> GetFlightStatus(string flightNumber, string date);
        Task<Airport[]> GetNearestAirport(float latitude, float longitude);
    }

    public class FlightsService : IFlightsService
    {
        private static FlightsApiClient FlightsApiClient;

        public FlightsService()
        {
            FlightsApiClient = new FlightsApiClient();
        }

        public async Task<IEnumerable<Flight>> GetSchedule(string origin, string destination, string date)
        {
            var flightResponse = await FlightsApiClient.GetSchedule(origin, destination, date);
            return FlightConverter.ToDomainFlights(flightResponse);
        }

        public async Task<Flight> GetFlightStatus(string flightNumber, string date)
        {
            var flightResponse = await FlightsApiClient.GetFlightStatus(flightNumber, date);
            return FlightConverter.ToDomainFlight(flightResponse);
        }

        public async Task<Airport[]> GetNearestAirport(float latitude, float longitude)
        {
            var response = await FlightsApiClient.GetNearestAirports(latitude, longitude);
            return FlightConverter.ToDomainAirport(response).ToArray();
        }
    }
}
