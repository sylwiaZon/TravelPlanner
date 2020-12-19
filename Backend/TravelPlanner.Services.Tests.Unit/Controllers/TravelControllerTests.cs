using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TravelPlanner.App.Controllers;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Core.Exceptions;
using TravelPlanner.Services;

namespace TravelPlanner.Tests.Unit.Controllers
{
    [TestFixture]
    public class TravelControllerTests
    {
        private ITravelService _travelService;
        private TravelController _controller;
        private Fixture _fixture;

        private const string Username = "user1";

        [SetUp]
        public void SetUp()
        {
            _travelService = Substitute.For<ITravelService>();
            _controller = new TravelController(_travelService);
            _controller.SetupDefaultContextWithUser(Username);
            _fixture = new Fixture();
        }

        [Test]
        public async Task GetTravels_ShouldReturnTravelsFromService()
        {
            var travels = _fixture.CreateMany<TravelsResponse>().ToList();
            _travelService.GetTravels(Arg.Is(Username))
                .Returns(travels);
            
            var result = await _controller.GetTravels();

            result.Should().BeEquivalentTo(travels);
        }
        
        [Test]
        public async Task AddFlight_WhenToFlight_ShouldCallProperServiceMethod()
        {
            var flight = _fixture.Create<Flight>();
            const string flightType = "to";
            var travelId = _fixture.Create<string>();
            
            await _controller.AddFlight(flight, flightType, travelId);

            await _travelService.Received(1)
                .AddToFlight(Arg.Is(flight), Arg.Is(travelId));
        }
        
        [Test]
        public async Task AddFlight_WhenFromFlight_ShouldCallProperServiceMethod()
        {
            var flight = _fixture.Create<Flight>();
            const string flightType = "from";
            var travelId = _fixture.Create<string>();
            
            await _controller.AddFlight(flight, flightType, travelId);

            await _travelService.Received(1)
                .AddFromFlight(Arg.Is(flight), Arg.Is(travelId));
        }
        
        [Test]
        public async Task AddFlight_WhenUnknownFlightType_ShouldThrow()
        {
            var flight = _fixture.Create<Flight>();
            const string flightType = "unknown one";
            var travelId = _fixture.Create<string>();
            
            Func<Task> action = async () => await _controller.AddFlight(flight, flightType, travelId);

            (await action.Should().ThrowAsync<TravelPlannerException>())
                .WithMessage("Bad flight type: choose either 'to' or 'from'")
                .Which.StatusCode.Should().Be(400);
        }
    }
}