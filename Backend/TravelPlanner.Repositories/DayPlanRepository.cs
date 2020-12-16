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
    public class DayPlanRepository
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;

        public DayPlanRepository(DbSettings dbSettings)
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_USER_NAME");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(dbSettings.DbConnectionString), Login, Password);
        }

        public async Task<DayPlan> AddDayPlan(DayPlan newPlan, string travelIdentity, string locationId)
        {
            await GraphClient.ConnectAsync();

            try
            {
                var resp = await GraphClient.Cypher
                    .Match("(travel:Travel)", "(location:Location)")
                    .Where((Location location) => location.LocationId == locationId)
                    .AndWhere((Travel travel) => travel.TravelId == travelIdentity)
                    .Create("(plan:DayPlan $plan)")
                    .WithParam("plan", newPlan)
                    .Create("(travel)-[r:HasDayPlan]->(plan)")
                    .Create("(location)-[k:HasDayPlan]->(plan)")
                    .Return(plan => plan.As<DayPlan>())
                    .ResultsAsync;

                if (resp.Any())
                    return resp.First();
                else return null;
            }
            catch (ClientException ce)
            {
                if (ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                {
                    newPlan.DayPlanId = new Guid().ToString();
                    return await AddDayPlan(newPlan, travelIdentity, locationId);
                }
                else throw ce;
            }
        }

        public async Task<Itinerary> AddItinerary(Itinerary newDay, string dayPlanId)
        {
            await GraphClient.ConnectAsync();

            try
            {
                var resp = await GraphClient.Cypher
                    .Match("(plan:DayPlan)")
                    .Where((DayPlan plan) => plan.DayPlanId == dayPlanId)
                    .Create("(day:Day $day)")
                    .WithParam("day", newDay)
                    .Create("(plan)-[r:HasDay]->(day)")
                    .Return(plan => plan.As<Itinerary>())
                    .ResultsAsync;

                if (resp.Any())
                    return resp.First();
                else return null;
            }
            catch (ClientException ce)
            {
                if (ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                {
                    newDay.ItineraryId = new Guid().ToString();
                    return await AddItinerary(newDay, dayPlanId);
                }
                else throw ce;
            }
        }

        public async Task<ItineraryItem> AddItineraryItem(ItineraryItem newItem, string itineraryId)
        {
            await GraphClient.ConnectAsync();

            try
            {
                var resp = await GraphClient.Cypher
                    .Match("(day:Day)")
                    .Where((Itinerary day) => day.ItineraryId == itineraryId)
                    .Create("(item:DayPlanItem $item)")
                    .WithParam("item", newItem)
                    .Create("(day)-[r:HasDayPlanItem]->(item)")
                    .Return(day => day.As<ItineraryItem>())
                    .ResultsAsync;

                if (resp.Any())
                    return resp.First();
                else return null;
            }
            catch (ClientException ce)
            {
                if (ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                {
                    newItem.ItineraryItemId = new Guid().ToString();
                    return await AddItineraryItem(newItem, itineraryId);
                }
                else throw ce;
            }
        }

        public async Task<IEnumerable<DayPlan>> GetDayPlans(string travelIdentity)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(dayPlan:DayPlan)--(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(dayPlan => dayPlan.As<DayPlan>())
                .ResultsAsync;
            if (resp.Any())
                return resp.ToArray();
            else
                return new List<DayPlan>();
        }

        public async Task<Itinerary[]> GetItineraries(string dayPlanId)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(dayPlan:DayPlan)--(day:Day)")
                .Where((DayPlan dayPlan) => dayPlan.DayPlanId == dayPlanId)
                .Return(day => day.As<Itinerary>())
                .ResultsAsync;
            if (resp.Any())
                return resp.ToArray();
            else
                throw new TravelPlannerException(404, "Itinerary not found");
        }

        public async Task<ItineraryItem[]> GetItinerariyItems(string itineraryId)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(item:DayPlanItem)--(day:Day)")
                .Where((Itinerary day) => day.ItineraryId == itineraryId)
                .Return(item => item.As<ItineraryItem>())
                .ResultsAsync;
            if (resp.Any())
                return resp.ToArray();
            else
                throw new TravelPlannerException(404, "ItineraryItem not found");
        }

        async public Task<Poi> GetPoi(string itineraryItemId)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(poi:Poi)--(item:DayPlanItem)")
                .Where((ItineraryItem item) => item.ItineraryItemId == itineraryItemId)
                .Return(poi => poi.As<Poi>())
                .ResultsAsync;
            if (resp.Any())
                return resp.First();
            else
                throw new TravelPlannerException(404, "Poi not found");
        }
    }
}
