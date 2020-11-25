using TravelPlanner.Core.DomainModels;
using DbTravel = TravelPlanner.Core.DataBaseModels.Travel;
using DbLocation = TravelPlanner.Core.DataBaseModels.Location;

namespace TravelPlanner.Services.Converters
{
    public class TravelConverter
    {
        public static DbTravel ToDbTravel(NewTravel travel)
        {
            return new DbTravel
            {
                TravelId = travel.TravelId,
                ArrivalDate = travel.ArrivalDate,
                DepartureDate = travel.DepartureDate,
                Children = travel.Participants.Children,
                ChildrenAges = travel.Participants.ChildrenAges,
                Adults = travel.Participants.Adults,
                City = travel.TravelDestination.City,
                Country = travel.TravelDestination.Country
            };
        }

        public static NewTravel ToDomainTravel(DbTravel travel)
        {
            return new NewTravel
            {
                TravelId = travel.TravelId,
                ArrivalDate = travel.ArrivalDate,
                DepartureDate = travel.DepartureDate,
                Participants = new TravelParticipants 
                { 
                    Children = travel.Children,
                    Adults = travel.Adults,
                    ChildrenAges = travel.ChildrenAges
                },
                TravelDestination = new TravelDestination
                {
                    City = travel.City,
                    Country = travel.Country,
                }
            };
        }

        public static TravelsResponse ToDomainTravel(DbTravel travel, DbLocation location)
        {
            return new TravelsResponse
            {
                TravelId = travel.TravelId,
                ArrivalDate = travel.ArrivalDate,
                DepartureDate = travel.DepartureDate,
                Participants = new TravelParticipants
                {
                    Children = travel.Children,
                    Adults = travel.Adults,
                    ChildrenAges = travel.ChildrenAges
                },
                TravelDestination = new TravelDestination
                {
                    City = travel.City,
                    Country = travel.Country,
                },
                PhotoUrl = location.PhotoUrl
            };
        }
    }
}
