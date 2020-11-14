using Neo4j.Driver;
using Neo4jClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using TravelPlanner.Core.DataBaseModels;
using TravelPlanner.Core.Exceptions;

namespace TravelPlanner.Repositories
{
    public class TourRepository
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;
        private static readonly string LocalEnvUrl = "bolt://40.69.36.20:7687";
        private static readonly string VMEnvUrl = "db";

        public TourRepository()
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_USER_NAME");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(LocalEnvUrl), Login, Password);
        }

        async public Task AddTour(Tour newTour, string travelIdentity)
        {
            await GraphClient.ConnectAsync();
            try
            {
                await GraphClient.Cypher
                    .Create("(tour:Tour $tour)")
                    .WithParam("tour", newTour)
                    .Return(tour => tour.As<Tour>())
                    .ResultsAsync;
            }
            catch (ClientException ce)
            {
                if (!ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                    throw ce;
            }
            var t = await GraphClient.Cypher
                .Match("(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(travel => travel.As<Travel>())
                .ResultsAsync;

            var addedTour = await GraphClient.Cypher
                .Match("(tour:Tour)", "(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .AndWhere((Tour tour) => tour.Id == newTour.Id)
                .Merge("(travel)-[r:HasTour]->(tour)")
                .Return(tour => tour.As<Tour>())
                .ResultsAsync;

            var registeredLocations = await GraphClient.Cypher
                .Match("(location:Location)--(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(location => location.As<Location>())
                .ResultsAsync;

            if (registeredLocations.Any())
            {
                var registeredLocation = registeredLocations.First();
                await GraphClient.Cypher
                .Match("(tour:Tour)", "(location:Location)")
                .Where((Tour tour) => tour.Id == newTour.Id)
                .AndWhere((Location location) => location.LocationId == registeredLocation.LocationId)
                .Merge("(location)-[r:HasTour]->(tour)")
                .Return(tour => tour.As<Tour>())
                .ResultsAsync;
            }
        }

        async public Task<Tour[]> GetTours(string travelIdentity)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(tour:Tour)--(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(tour => tour.As<Tour>())
                .ResultsAsync;
            if (resp.Any())
                return resp.ToArray();
            else
                throw new TravelPlannerException(404, "Tour not found");
        }
    }
}
