using System.Threading.Tasks;
using TravelPlanner.Core.Flights;
using TravelPlanner.Repositories;

namespace TravelPlanner.Services
{
    public interface IFlightsService
    {
        Task<FlightsSchedule> GetSchedule(string origin, string destination, string date);
        Task<FlightStatusResponse> GetFlightStatus(string flightNumber, string date);
    }

    public class FlightsService : IFlightsService
    {
        private static FlightsApiClient FlightsApiClient;

        public FlightsService()
        {
            FlightsApiClient = new FlightsApiClient();
        }

        public async Task<FlightsSchedule> GetSchedule(string origin, string destination, string date)
        {
            return await FlightsApiClient.GetSchedule(origin, destination, date);
        }

        public async Task<FlightStatusResponse> GetFlightStatus(string flightNumber, string date)
        {
            return await FlightsApiClient.GetFlightStatus(flightNumber, date);
        }
    }
}
