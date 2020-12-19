using Neo4j.Driver;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelPlanner.Core;
using TravelPlanner.Core.DataBaseModels;
using TravelPlanner.Core.Exceptions;

namespace TravelPlanner.Repositories
{
    public interface ILocationRepository
    {
        Task<Location> AddLocation(Location newLocation, string travelIdentity);
        Task<Location> GetLocation(string travelIdentity);
        Task<IEnumerable<Poi>> GetPoisForLocation(string travelIdentity);
    }

    public class LocationRepository : ILocationRepository
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;

        public LocationRepository(DbSettings dbSettings)
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_USER_NAME");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(dbSettings.DbConnectionString), Login, Password);
        }

        async public Task<Location> AddLocation(Location newLocation, string travelIdentity)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(travel:Travel)--(location:Location)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(location => location.As<Location>())
                .ResultsAsync;
            if (resp.Any())
                throw new TravelPlannerException(409, "Location for this travel already exists");
            try
            {
                await GraphClient.Cypher
                    .Create("(location:Location $location)")
                    .WithParam("location", newLocation)
                    .Return(location => location.As<Location>())
                    .ResultsAsync;
            }
            catch (ClientException ce)
            {
                if (!ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                    throw ce;
            }

            var response = await GraphClient.Cypher
                .Match("(location:Location)", "(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .AndWhere((Location location) => location.LocationId == newLocation.LocationId)
                .Merge("(travel)-[r:HasLocation]->(location)")
                .Return(location => location.As<Location>())
                .ResultsAsync;
            if (response.Any())
            {
                return response.First();
            }
            return null;
        }

        async public Task<Location> GetLocation(string travelIdentity)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(location:Location)--(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(location => location.As<Location>())
                .ResultsAsync;
            if (resp.Any())
                return resp.First();
            else
                throw new TravelPlannerException(404, "Location not found");
        }

        async public Task<IEnumerable<Poi>> GetPoisForLocation(string travelIdentity)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(location:Location)--(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(location => location.As<Location>())
                .ResultsAsync;
            if (resp.Any())
            {
                var locationId = resp.First().LocationId;
                return await GraphClient.Cypher
                .Match("(location:Location)--(poi:Poi)")
                .Where((Location location) => location.LocationId == locationId)
                .Return(poi => poi.As<Poi>())
                .ResultsAsync;
            }
            else
                throw new TravelPlannerException(404, "Location not found");
        }
    }
}
