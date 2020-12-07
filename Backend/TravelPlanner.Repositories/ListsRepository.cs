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
    public class ListsRepository
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;

        public ListsRepository(DbSettings dbSettings)
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_USER_NAME");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(dbSettings.DbConnectionString), Login, Password);
        }

        public async Task<ToDoItem> AddToDoItem(ToDoItem newItem, string travelIdentity)
        {
            await GraphClient.ConnectAsync();

            try
            {
                var resp = await GraphClient.Cypher
                    .Match("(travel:Travel)")
                    .Where((Travel travel) => travel.TravelId == travelIdentity)
                    .Create("(toDoItem:ToDoItem $newItem)")
                    .WithParam("newItem", newItem)
                    .Create("(travel)-[r:HasToDoItem]->(toDoItem)")
                    .Return(toDoItem => toDoItem.As<ToDoItem>())
                    .ResultsAsync;

                if (resp.Any())
                    return resp.First();
                else return null;
            }
            catch (ClientException ce)
            {
                if (ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                {
                    newItem.Id = new Guid().ToString();
                    return await AddToDoItem(newItem, travelIdentity);
                }
                else throw ce;
            }
        }

        public async Task<ToDoItem> EditToDoItem(ToDoItem editedItem)
        {
            await GraphClient.ConnectAsync();

            var resp = await GraphClient.Cypher
                .Match("(item:ToDoItem)")
                .Where((ToDoItem item) => item.Id == editedItem.Id)
                .Set("item.Checked = $checked")
                .WithParam("checked", editedItem.Checked)
                .Return(item => item.As<ToDoItem>())
                .ResultsAsync;

            if (resp.Any())
                return resp.First();
            else
                throw new TravelPlannerException(404, "ToDoItem not found");
        }

        public async Task<IEnumerable<ToDoItem>> GetToDoItems(string travelIdentity)
        {
            await GraphClient.ConnectAsync();

            var resp = await GraphClient.Cypher
                .Match("(item:ToDoItem)--(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(item => item.As<ToDoItem>())
                .ResultsAsync;

            if (resp.Any())
                return resp;
            else
                return new List<ToDoItem>();
        }

        public async Task<ToSeeItem> AddToSeeItem(ToSeeItem newItem, string travelIdentity)
        {
            await GraphClient.ConnectAsync();

            try
            {
                var resp = await GraphClient.Cypher
                    .Match("(travel:Travel)", "(poi:Poi)")
                    .Where((Travel travel) => travel.TravelId == travelIdentity)
                    .AndWhere((Poi poi) => poi.PoiId == newItem.Name)
                    .Create("(item:ToSeeItem $newItem)")
                    .WithParam("newItem", newItem)
                    .Create("(travel)-[r:HasToSeeItem]->(item)")
                    .Create("(item)-[t:HasPoi]->(poi)")
                    .Return(item => item.As<ToSeeItem>())
                    .ResultsAsync;

                if (resp.Any())
                    return resp.First();
                else return null;
            }
            catch (ClientException ce)
            {
                if (ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                {
                    newItem.Id = new Guid().ToString();
                    return await AddToSeeItem(newItem, travelIdentity);
                }
                else throw ce;
            }
        }

        public async Task<ToSeeItem> EditToSeeItem(ToSeeItem editedItem)
        {
            await GraphClient.ConnectAsync();

            var resp = await GraphClient.Cypher
                .Match("(item:ToSeeItem)")
                .Where((ToSeeItem item) => item.Id == editedItem.Id)
                .Set("item.Checked = $checked")
                .WithParam("checked", editedItem.Checked)
                .Return(item => item.As<ToSeeItem>())
                .ResultsAsync;

            if (resp.Any())
                return resp.First();
            else
                throw new TravelPlannerException(404, "ToSeeItem not found");
        }

        public async Task<IEnumerable<ToSeeItem>> GetToSeeItems(string travelIdentity)
        {
            await GraphClient.ConnectAsync();

            var resp = await GraphClient.Cypher
                .Match("(item:ToSeeItem)--(travel:Travel)")
                .Where((Travel travel) => travel.TravelId == travelIdentity)
                .Return(item => item.As<ToSeeItem>())
                .ResultsAsync;

            if (resp.Any())
                return resp;
            else
                return new List<ToSeeItem>();
        }

        public async Task<Poi> GetToSeeItemPoi(string itemId)
        {
            await GraphClient.ConnectAsync();

            var resp = await GraphClient.Cypher
                .Match("(item:ToSeeItem)--(poi:Poi)")
                .Where((ToSeeItem item) => item.Id == itemId)
                .Return(poi => poi.As<Poi>())
                .ResultsAsync;

            if (resp.Any())
                return resp.First();
            else
                throw new TravelPlannerException(404, "ToSee Pois' not found");
        }
    }
}
