using Neo4j.Driver;
using Neo4jClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using TravelPlanner.Core;
using TravelPlanner.Core.Exceptions;

namespace TravelPlanner.Repositories
{
    public class UserRepository 
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;

        public UserRepository(DbSettings dbSettings)
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_USER_NAME");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(dbSettings.DbConnectionString), Login, Password);
        }

        async public Task RegisterUser(User user)
        {
            await GraphClient.ConnectAsync();
            try
            {
                var resp = await GraphClient.Cypher
                    .Create("(user:User $user)")
                    .WithParam("user", user)
                    .Return(user => user.As<User>())
                    .ResultsAsync;
            } catch (ClientException ce)
            {
                if (ce.Message.Contains("already exists", StringComparison.InvariantCultureIgnoreCase))
                    throw new TravelPlannerException(409, "User already exists");
                else throw ce;
            }
        }

        async public Task<User> GetUser(string mail)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(user:User)")
                .Where((User user) => user.Mail == mail)
                .Return(user => user.As<User>())
                .ResultsAsync;
            if(resp.Any())
                return resp.First();
            else 
                throw new TravelPlannerException(403, "Forbidden");
        }
    }
}
