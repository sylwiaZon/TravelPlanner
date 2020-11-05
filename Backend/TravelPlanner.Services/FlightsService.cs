using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Repositories;
using TravelPlanner.Services.Converters;

namespace TravelPlanner.Services
{
    public interface IFlightsService
    {
        Task<IEnumerable<Flight>> GetSchedule(string origin, string destination, string date);
        Task<Flight> GetFlightStatus(string flightNumber, string date);
    }

    public class FlightsService : IFlightsService
    {
        private static FlightsApiClient FlightsApiClient;
        private FlightConverter FlightConverter;

        public FlightsService()
        {
            FlightsApiClient = new FlightsApiClient();
            FlightConverter = new FlightConverter();
        }

        public async Task<IEnumerable<Flight>> GetSchedule(string origin, string destination, string date)
        {
            var flightResponse = await FlightsApiClient.GetSchedule(origin, destination, date);
            return FlightConverter.ToDomainFlight(flightResponse);
        }

        public async Task<Flight> GetFlightStatus(string flightNumber, string date)
        {
            var flightResponse = await FlightsApiClient.GetFlightStatus(flightNumber, date);
            return FlightConverter.ToDomainFlight(flightResponse);
        }
    }
}
