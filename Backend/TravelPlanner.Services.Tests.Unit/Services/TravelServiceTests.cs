using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Core.HotelsApi.Details;
using TravelPlanner.Repositories;
using TravelPlanner.Services;
using TravelPlanner.Services.Converters;
using HotelTransport = TravelPlanner.Core.DataBaseModels.HotelTransport;
using TransportLocation = TravelPlanner.Core.DataBaseModels.TransportLocation;
using Travel = TravelPlanner.Core.DataBaseModels.Travel;

namespace TravelPlanner.Tests.Unit.Services
{
    [TestFixture]
    public class TravelServiceTests
    {
        private ITravelRepository _travelRepository;
        private ILocationRepository _locationRepository;
        private IFlightRepository _flightRepository;
        private IHotelRepository _hotelRepository;
        private ICityWalkRepository _cityWalkRepository;
        private IPoiRepository _poiRepository;
        private IDayPlanRepository _dayPlanRepository;
        private ITourRepository _tourRepository;
        private IListsRepository _listsRepository;
        private IHotelsApiClient _hotelsApiClient;
        private ITriposoApiClient _triposoApiClient;
        private TravelService _travelService;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _travelRepository = Substitute.For<ITravelRepository>();
            _locationRepository = Substitute.For<ILocationRepository>();
            _flightRepository = Substitute.For<IFlightRepository>();
            _hotelRepository = Substitute.For<IHotelRepository>();
            _cityWalkRepository = Substitute.For<ICityWalkRepository>();
            _poiRepository = Substitute.For<IPoiRepository>();
            _dayPlanRepository = Substitute.For<IDayPlanRepository>();
            _tourRepository = Substitute.For<ITourRepository>();
            _listsRepository = Substitute.For<IListsRepository>();
            _hotelsApiClient = Substitute.For<IHotelsApiClient>();
            _triposoApiClient = Substitute.For<ITriposoApiClient>();
            _travelService = new TravelService(
                _travelRepository,
                _locationRepository,
                _flightRepository,
                _hotelRepository,
                _cityWalkRepository,
                _poiRepository,
                _dayPlanRepository,
                _tourRepository,
                _listsRepository,
                _hotelsApiClient,
                _triposoApiClient
            );
            _fixture = new Fixture();
        }

        [Test]
        public async Task AddTravel_ShouldAddTravel_WithProperId()
        {
            var destination = _fixture.Build<TravelDestination>()
                .With(d => d.City, "BestCity")
                .With(d => d.Country, "SecondStartingWithO")
                .Create();
            var newTravel = _fixture.Build<NewTravel>()
                .With(t => t.TravelDestination, destination)
                .With(t => t.ArrivalDate, new DateTime(2020,01,04))
                .Create();
            var userMail = "username";
            var response = _fixture.Create<Travel>();
            _travelRepository.AddTravelToUser(
                Arg.Is<Travel>(t => t.TravelId == "usernameBestCitySecondStartingWithO1/4/2020 12:00:00 AM"), 
                Arg.Is(userMail)
            ).Returns(response);
            
            var result = await _travelService.AddTravel(newTravel, userMail);

            result.Should().BeEquivalentTo(TravelConverter.ToDomainTravel(response));
        }

        [Test]
        public async Task AddHotel_ShouldGetDetailsAndSave()
        {
            var hotel = _fixture.Create<Hotel>();
            var travelId = _fixture.Create<string>();
            var hotelDetails = _fixture.Create<HotelDetails>();

            _hotelsApiClient.GetHotelDetails(Arg.Is(hotel.DestinationId))
                .Returns(hotelDetails);
            
            await _travelService.AddHotel(hotel, travelId);

            await _hotelRepository.Received(1)
                .AddHotel(Arg.Is<Core.DataBaseModels.Hotel>(h => h.DestinationId == hotel.DestinationId), Arg.Is(travelId));
            foreach (var transport in hotelDetails.Transportation.TransportLocations)
            {
                await _hotelRepository.AddHotelTransport(
                    Arg.Is(hotel.HotelId),
                    Arg.Is<HotelTransport>(ht => ht.Category == transport.Category),
                    Arg.Any<TransportLocation[]>());
            }
        }
    }
}