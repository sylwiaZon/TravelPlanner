using Neo4j.Driver;
using Neo4jClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using TravelPlanner.Core;
using TravelPlanner.Core.DataBaseModels;
using TravelPlanner.Core.Exceptions;

namespace TravelPlanner.Repositories
{
    public interface IFlightRepository
    {
        Task AddToFlight(Flight newFlight, string travelIdentity);
        Task AddFromFlight(Flight newFlight, string travelIdentity);
        Task<Flight> GetToFlight(string travelIdentity);
        Task<Flight> GetFromFlight(string travelIdentity);
    }

    public class FlightRepository : IFlightRepository
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;

        public FlightRepository(DbSettings dbSettings)
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_USER_NAME");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(dbSettings.DbConnectionString), Login, Password);
        }

        async public Task AddToFlight(Flight newFlight, string travelIdentity)
        {
            await AddFlight(newFlight, travelIdentity, "HasToFlight");
        }

        async public Task AddFromFlight(Flight newFlight, string travelIdentity)
        {
            await AddFlight(newFlight, travelIdentity, "HasFromFlight");
        }

        async public Task<Flight> GetToFlight(string travelIdentity)
        {
            return await GetFlight(travelIdentity, "HasToFlight");
        }

        async public Task<Flight> GetFromFlight(string travelIdentity)
        {
            return await GetFlight(travelIdentity, "HasFromFlight");
        }

        async private Task AddFlight(Flight newFlight, string travelIdentity, string relationName)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match($"(travel:Travel)-[:{relationName}]-(flight:Flight)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(flight => flight.As<Flight>())
                .ResultsAsync;
            if (resp.Any())
                throw new TravelPlannerException(409, "Flight for this travel already exists");

            try
            {
                await GraphClient.Cypher
                    .Create("(flight:Flight $flight)")
                    .WithParam("flight", newFlight)
                    .Return(flight => flight.As<Flight>())
                    .ResultsAsync;
            }
            catch (ClientException ce)
            {
                if (!ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                    throw ce;
            }

            await GraphClient.Cypher
                .Match("(flight:Flight)", "(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .AndWhere((Flight flight) => flight.FlightId == newFlight.FlightId)
                .Merge($"(travel)-[:{relationName}]->(flight)")
                .Return(flight => flight.As<Flight>())
                .ResultsAsync;
        }

        async private Task<Flight> GetFlight(string travelIdentity, string relationName)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match($"(travel:Travel)-[:{relationName}]-(flight:Flight)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(flight => flight.As<Flight>())
                .ResultsAsync;
            if (resp.Any())
                return resp.First();
            else
                throw new TravelPlannerException(404, "Flight not found");
        }
    }
}
