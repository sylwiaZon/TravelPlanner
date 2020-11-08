using TravelPlanner.Core.DomainModels;
using DbTravel = TravelPlanner.Core.DataBaseModels.Travel;

namespace TravelPlanner.Services.Converters
{
    public class TravelConverter
    {
        public static DbTravel ToDbTravel(NewTravel travel)
        {
            return new DbTravel
            {
                TravelIdentity = travel.TravelIdentity,
                Date = travel.Date,
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
                TravelIdentity = travel.TravelIdentity,
                Date = travel.Date,
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
    }
}
