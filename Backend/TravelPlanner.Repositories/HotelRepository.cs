using Neo4j.Driver;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Core.DataBaseModels;
using TravelPlanner.Core.Exceptions;

namespace TravelPlanner.Repositories
{
    public class HotelRepository
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;
        private static readonly string LocalEnvUrl = "bolt://40.69.36.20:7687";
        private static readonly string VMEnvUrl = "db";

        public HotelRepository()
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_USER_NAME");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(LocalEnvUrl), Login, Password);
        }

        async public Task AddHotel(Hotel newHotel, string travelIdentity)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(travel:Travel)--(hotel:Hotel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(hotel => hotel.As<Hotel>())
                .ResultsAsync;
            if (resp.Any())
                throw new TravelPlannerException(409, "Hotel for this travel already exists");
            try
            {
                await GraphClient.Cypher
                    .Create("(hotel:Hotel $hotel)")
                    .WithParam("hotel", newHotel)
                    .Return(hotel => hotel.As<Hotel>())
                    .ResultsAsync;
            }
            catch (ClientException ce)
            {
                if (!ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                    throw ce;
            }
            await GraphClient.Cypher
                .Match("(hotel:Hotel)", "(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .AndWhere((Hotel hotel) => hotel.HotelId == newHotel.HotelId)
                .Merge("(travel)-[r:HasHotel]->(hotel)")
                .Return(hotel => hotel.As<Hotel>())
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
                .Match("(hotel:Hotel)", "(location:Location)")
                .Where((Hotel hotel) => hotel.HotelId == newHotel.HotelId)
                .AndWhere((Location location) => location.LocationId == registeredLocation.LocationId)
                .Merge("(location)-[r:HasHotel]->(hotel)")
                .Return(hotel => hotel.As<Hotel>())
                .ResultsAsync;
            }
        }

        async public Task<Hotel> GetHotel(string travelIdentity)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(hotel:Hotel)--(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(hotel => hotel.As<Hotel>())
                .ResultsAsync;
            if (resp.Any())
                return resp.First();
            else
                throw new TravelPlannerException(404, "Hotel not found");
        }
    }
}
