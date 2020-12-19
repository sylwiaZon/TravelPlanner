using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Tests.Integration.Utils;

namespace TravelPlanner.Tests.Integration
{
    [TestFixture]
    public class TravelTests
    {
        private TravelPlannerClient _travelPlannerClient;
        
        [OneTimeSetUp]
        public async Task SetUp()
        {
            _travelPlannerClient = new TravelPlannerClient();
            await _travelPlannerClient.Authenticate();
        }

        [Test]
        public async Task ShouldGetTravels()
        {
            var newTravel = new NewTravel
            {
                TravelDestination = new TravelDestination
                {
                    City = "Paris",
                    Country = "France"
                },
                ArrivalDate = DateTime.Now,
                DepartureDate = DateTime.Now.AddDays(3),
                Participants = new TravelParticipants
                {
                    Adults = 2,
                    Children = 0
                }
            };
            var createdTravelResponse = await _travelPlannerClient.HttpClient.PostAsync("/travel", newTravel.AsJson());
            var createdTravel = await createdTravelResponse.ToObject<NewTravel>();
            
            var travelsResponse = await _travelPlannerClient.HttpClient.GetAsync("/travel");
            var travels = await travelsResponse.ToObject<List<TravelsResponse>>();

            travels.Count.Should().BeGreaterThan(0);
            travels.Should().Contain(t => t.TravelId == createdTravel.TravelId);
        }
    }
}