﻿using Neo4j.Driver;
using Neo4jClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using TravelPlanner.Core.DataBaseModels;
using TravelPlanner.Core.Exceptions;

namespace TravelPlanner.Repositories
{
    public class LocationRepository
    {
        private static string Login;
        private static string Password;
        private static BoltGraphClient GraphClient;
        private static readonly string LocalEnvUrl = "bolt://40.69.36.20:7687";
        private static readonly string VMEnvUrl = "db";

        public LocationRepository()
        {
            Login = Environment.GetEnvironmentVariable("NEO4J_USER_NAME");
            Password = Environment.GetEnvironmentVariable("NEO4J_PASSWORD");
            GraphClient = new BoltGraphClient(new Uri(LocalEnvUrl), Login, Password);
        }

        async public Task AddLocation(Location newLocation, string travelIdentity)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(travel:Travel)--(location:Location)")
                .Where((Travel travel) => travel.TravelIdentity == travelIdentity)
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
            await GraphClient.Cypher
                .Match("(location:Location)", "(travel:Travel)")
                .Where((Travel travel) => travel.TravelIdentity == travelIdentity)
                .AndWhere((Location location) => location.Name == newLocation.Name)
                .Merge("(travel)-[r:HasLocation]->(location)")
                .Return(location => location.As<Location>())
                .ResultsAsync;
        }

        async public Task<Location> GetLocation(string travelIdentity)
        {
            await GraphClient.ConnectAsync();
            var resp = await GraphClient.Cypher
                .Match("(location:Location)--(travel:Travel)")
                .Where((Travel travel) => travel.TravelIdentity == travelIdentity)
                .Return(location => location.As<Location>())
                .ResultsAsync;
            if (resp.Any())
                return resp.First();
            else
                throw new TravelPlannerException(404, "Location not found");
        }
    }
}
