using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelPlanner.Core;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Core.Exceptions;

namespace TravelPlanner.Repositories
{
    public class TravelRepository
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;
        private static readonly string LocalEnvUrl = "bolt://40.69.36.20:7687";
        private static readonly string VMEnvUrl = "db";

        public TravelRepository()
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_USER_NAME");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(LocalEnvUrl), Login, Password);
        }

        async public Task AddTravelToUser(Travel travel)
        {
            await GraphClient.ConnectAsync();
            var t = await GraphClient.Cypher
                .Match("(user:User)")
                .Where((User user) => user.Mail == "Mail")
                .Create("(travel:Travel $travel)")
                .WithParam("travel", travel)
                .Create("(user)-[r:HasTravel]->(travel)")
                .Return(travel => travel.As<Travel>())
                .ResultsAsync;
            var k = t;
        }

        async public Task<IEnumerable<Travel>> GetTravels(User searchedUser)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(user:User)--(travel:Travel)")
                .Where((User user) => user.Mail == searchedUser.Mail)
                .Return(travel => travel.As<Travel>())
                .ResultsAsync;
            if (resp.Any())
                return resp;
            else
                throw new TravelPlannerException(404, "Travels not found");
        }
    }
}
