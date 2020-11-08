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

        async public Task<Travel> AddTravelToUser(Travel travel, string userMail)
        {
            await GraphClient.ConnectAsync();

            try
            {
                var resp = await GraphClient.Cypher
                    .Match("(user:User)")
                    .Where((User user) => user.Mail == userMail)
                    .Create("(travel:Travel $travel)")
                    .WithParam("travel", travel)
                    .Create("(user)-[r:HasTravel]->(travel)")
                    .Return(travel => travel.As<Travel>())
                    .ResultsAsync;
                if (resp.Any())
                    return resp.First();
                else return null;
            }
            catch (ClientException ce)
            {
                if (ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                    throw new TravelPlannerException(409, "Travel already exists");
                else throw ce;
            }
        }

        async public Task<IEnumerable<Travel>> GetTravels(string userMail)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(user:User)--(travel:Travel)")
                .Where((User user) => user.Mail == userMail)
                .Return(travel => travel.As<Travel>())
                .ResultsAsync;
            if (resp.Any())
                return resp;
            else
                throw new TravelPlannerException(404, "Travels not found");
        }
    }
}
