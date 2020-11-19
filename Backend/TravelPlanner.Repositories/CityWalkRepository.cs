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
    public class CityWalkRepository
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;

        public CityWalkRepository(DbSettings dbSettings)
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_USER_NAME");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(dbSettings.DbConnectionString), Login, Password);
        }

        async public Task<CityWalk> AddCityWalk(CityWalk newWalk, string travelIdentity, string locationId)
        {
            await GraphClient.ConnectAsync();

            try
            {
                var resp = await GraphClient.Cypher
                    .Match("(travel:Travel)", "(location:Location)")
                    .Where((Location location) => location.LocationId == locationId)
                    .AndWhere((Travel travel) => travel.TravelId == travelIdentity)
                    .Create("(walk:CityWalk $walk)")
                    .WithParam("walk", newWalk)
                    .Create("(travel)-[r:HasCityWalk]->(walk)")
                    .Create("(location)-[k:HasCityWalk]->(walk)")
                    .Return(walk => walk.As<CityWalk>())
                    .ResultsAsync;

                if (resp.Any())
                    return resp.First();
                else return null;
            }
            catch (ClientException ce)
            {
                if (ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                {
                    newWalk.CityWalkId = new Guid().ToString();
                    return await AddCityWalk(newWalk, travelIdentity, locationId);
                }
                else throw ce;
            }
        }

        async public Task<WayPoint> AddWayPoint(WayPoint newPoint, string walkId)
        {
            await GraphClient.ConnectAsync();

            try
            {
                var resp = await GraphClient.Cypher
                    .Match("(walk:CityWalk)")
                    .Where((CityWalk walk) => walk.CityWalkId == walkId)
                    .Create("(point:WayPoint $point)")
                    .WithParam("point", newPoint)
                    .Create("(walk)-[r:HasWayPoint]->(point)")
                    .Return(point => point.As<WayPoint>())
                    .ResultsAsync;

                if (resp.Any())
                    return resp.First();
                else return null;
            }
            catch (ClientException ce)
            {
                if (ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                {
                    newPoint.WayPointId = new Guid().ToString();
                    return await AddWayPoint(newPoint, walkId);
                }
                else throw ce;
            }
        }

        async public Task<CityWalk[]> GetCityWalks(string travelIdentity)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(cityWalk:CityWalk)--(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(cityWalk => cityWalk.As<CityWalk>())
                .ResultsAsync;
            if (resp.Any())
                return resp.ToArray();
            else
                throw new TravelPlannerException(404, "CityWalk not found");
        }

        async public Task<WayPoint[]> GetWayPoints(string cityWalkId)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(cityWalk:CityWalk)--(wayPoint:WayPoint)")
                .Where((CityWalk cityWalk) => cityWalk.CityWalkId == cityWalkId)
                .Return(wayPoint => wayPoint.As<WayPoint>())
                .ResultsAsync;
            if (resp.Any())
                return resp.ToArray();
            else
                throw new TravelPlannerException(404, "WayPoint not found");
        }

        async public Task<Poi> GetPoi(string wayPointId)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(poi:Poi)--(wayPoint:WayPoint)")
                .Where((WayPoint wayPoint) => wayPoint.WayPointId == wayPointId)
                .Return(poi => poi.As<Poi>())
                .ResultsAsync;
            if (resp.Any())
                return resp.First();
            else
                throw new TravelPlannerException(404, "Poi not found");
        }
    }
}
