using Neo4j.Driver;
using Neo4jClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TravelPlanner.Core.DataBaseModels;
using TravelPlanner.Core.Exceptions;

namespace TravelPlanner.Repositories
{
    public class FlightRepository
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;
        private static readonly string LocalEnvUrl = "bolt://40.69.36.20:7687";
        private static readonly string VMEnvUrl = "db";

        public FlightRepository()
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_USER_NAME");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(LocalEnvUrl), Login, Password);
        }

        async public Task AddToFlight(Flight newFlight, string travelIdentity)
        {
            await AddFlight(newFlight, travelIdentity, "HasToFlight");
        }

        async public Task AddFromFlight(Flight newFlight, string travelIdentity)
        {
            await AddFlight(newFlight, travelIdentity, "HasFromFlight");
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
                .Merge($"(travel)-[r:{relationName}]->(flight)")
                .Return(flight => flight.As<Flight>())
                .ResultsAsync;
        }

        async public Task<Flight> GetFlight(string travelIdentity)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(flight:Flight)--(travel:Travel)")
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
