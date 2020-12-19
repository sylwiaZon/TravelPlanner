using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Services.Converters;
using Travel = TravelPlanner.Core.DataBaseModels.Travel;

namespace TravelPlanner.Tests.Unit.Services.Converters
{
    [TestFixture]
    public class TravelConverterTests
    {
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void ToDomainTravel_ShouldAssignCorrectProperties()
        {
            var dbTravel = _fixture.Create<Travel>();

            var result = TravelConverter.ToDomainTravel(dbTravel);

            result.Should().BeEquivalentTo(new NewTravel
            {
                TravelId = dbTravel.TravelId,
                ArrivalDate = dbTravel.ArrivalDate,
                DepartureDate = dbTravel.DepartureDate,
                Participants = new TravelParticipants
                {
                    Adults = dbTravel.Adults,
                    Children = dbTravel.Children,
                    ChildrenAges = dbTravel.ChildrenAges
                },
                TravelDestination = new TravelDestination
                {
                    City = dbTravel.City,
                    Country = dbTravel.Country
                }
            });
        }
        
        [Test]
        public void ToDbTravel_ShouldAssignCorrectProperties()
        {
            var newTravel = _fixture.Create<NewTravel>();

            var result = TravelConverter.ToDbTravel(newTravel);

            result.Should().BeEquivalentTo(new Travel
            {
                TravelId = newTravel.TravelId,
                ArrivalDate = newTravel.ArrivalDate,
                DepartureDate = newTravel.DepartureDate,
                Adults = newTravel.Participants.Adults,
                Children = newTravel.Participants.Children,
                ChildrenAges = newTravel.Participants.ChildrenAges,
                City = newTravel.TravelDestination.City,
                Country = newTravel.TravelDestination.Country
            });
        }
    }
}