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
    public class PoiRepository
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;

        public PoiRepository(DbSettings dbSettings)
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_USER_NAME");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(dbSettings.DbConnectionString), Login, Password);
        }

        async public Task AddPoi(Poi poi)
        {
            await GraphClient.ConnectAsync();
            try
            {
                var resp = await GraphClient.Cypher
                    .Create("(poi:Poi $poi)")
                    .WithParam("poi", poi)
                    .Return(poi => poi.As<Poi>())
                    .ResultsAsync;
            }
            catch (ClientException ce)
            {
                if (ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                    throw new TravelPlannerException(409, "Poi already exists");
                else throw ce;
            }
        }

        async public Task AddPoiToWayPoint(Poi newPoi, IEnumerable<Attribution> attributions, string pointId, string locationId)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match($"(poi:Poi)--(point:WayPoint)")
                .Where((WayPoint point) => point.WayPointId == pointId)
                .Return(point => point.As<WayPoint>())
                .ResultsAsync;
            if (resp.Any())
                throw new TravelPlannerException(409, "Poi for this point already exists");

            try
            {
                await GraphClient.Cypher
                    .Create("(poi:Poi $poi)")
                    .WithParam("poi", newPoi)
                    .Return(poi => poi.As<Poi>())
                    .ResultsAsync;
            }
            catch (ClientException ce)
            {
                if (!ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                    throw ce;
            }

            await GraphClient.Cypher
                .Match("(poi:Poi)", "(point:WayPoint)", "(location:Location)")
                .Where((WayPoint point) => point.WayPointId == pointId)
                .AndWhere((Poi poi) => poi.PoiId == newPoi.PoiId)
                .AndWhere((Location location) => location.LocationId == locationId)
                .Merge($"(point)-[r:HasPoi]->(poi)")
                .Merge($"(location)-[k:HasPoi]->(poi)")
                .Return(poi => poi.As<Poi>())
                .ResultsAsync;
        }

        async public Task AddAttributionToPoi(string poiId, IEnumerable<Attribution> attributions)
        {
            foreach (var attr in attributions)
            {
                await GraphClient.Cypher
                    .Match("(poi:Poi)")
                    .Where((Poi poi) => poi.PoiId == poiId)
                    .Create("(attribution:Attribution $attr)")
                    .WithParam("attr", attr)
                    .Create("(poi)-[r:HasAttribution]->(attribution)")
                    .Return(attribution => attribution.As<Attribution>())
                    .ResultsAsync;
            }
        }

        async public Task<IEnumerable<Attribution>> GetPoiAttributions(string poiId)
        {
            await GraphClient.ConnectAsync();
            return await GraphClient.Cypher
                .Match("(attribution:Attribution)--(poi:Poi)")
                .Where((Poi poi) => poi.PoiId == poiId)
                .Return(attribution => attribution.As<Attribution>())
                .ResultsAsync;
        }

        async public Task AddPoiToDayItem(Poi newPoi, string dayPlanItem, string locationId)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match($"(poi:Poi)--(planItem:DayPlanItem)")
                .Where((ItineraryItem planItem) => planItem.ItineraryItemId == dayPlanItem)
                .Return(planItem => planItem.As<ItineraryItem>())
                .ResultsAsync;
            if (resp.Any())
                throw new TravelPlannerException(409, "Poi for this point already exists");

            try
            {
                await GraphClient.Cypher
                    .Create("(poi:Poi $poi)")
                    .WithParam("poi", newPoi)
                    .Return(poi => poi.As<Poi>())
                    .ResultsAsync;
            }
            catch (ClientException ce)
            {
                if (!ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                    throw ce;
            }

            await GraphClient.Cypher
                .Match("(poi:Poi)", "(planItem:DayPlanItem)", "(location:Location)")
                .Where((ItineraryItem planItem) => planItem.ItineraryItemId == dayPlanItem)
                .AndWhere((Poi poi) => poi.Id == newPoi.Id)
                .AndWhere((Location location) => location.LocationId == locationId)
                .Merge($"(planItem)-[r:HasPoi]->(poi)")
                .Merge($"(location)-[k:HasPoi]->(poi)")
                .Return(poi => poi.As<Poi>())
                .ResultsAsync;
        }

        public async Task<Poi> GetPoi(string id)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(poi:Poi)")
                .Where((Poi poi) => poi.PoiId == id)
                .Return(poi => poi.As<Poi>())
                .ResultsAsync;
            if (resp.Any())
                return resp.First();
            else
                throw new TravelPlannerException(404, "Poi not found");
        }
    }
}
