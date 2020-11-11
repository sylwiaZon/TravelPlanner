using TriposoDayPlan = TravelPlanner.Core.Triposo.DayPlan;
using TriposoItinerary = TravelPlanner.Core.Triposo.Itinerary;
using TriposoItineraryItem = TravelPlanner.Core.Triposo.ItineraryItem;
using DomainDayPlan = TravelPlanner.Core.DomainModels.DayPlan;
using DomainItinerary = TravelPlanner.Core.DomainModels.Itinerary;
using DomainItineraryItem = TravelPlanner.Core.DomainModels.ItineraryItem;
using DbDayPlan = TravelPlanner.Core.DataBaseModels.DayPlan;
using DbItinerary = TravelPlanner.Core.DataBaseModels.Itinerary;
using DbItineraryItem = TravelPlanner.Core.DataBaseModels.ItineraryItem;
using System;
using System.Linq;
using TravelPlanner.Core.DomainModels;

namespace TravelPlanner.Services.Converters
{
    public class DayPlanConverter
    {
        public static DomainDayPlan ToDomainDayPlan(TriposoDayPlan plan)
        {
            return new DomainDayPlan
            {
                DayPlanId = Guid.NewGuid().ToString(),
                Days = plan.Days.Select(p => ToDomainItinerary(p)).ToArray()
            };
        }

        public static DomainItinerary ToDomainItinerary(TriposoItinerary it)
        {
            return new DomainItinerary
            {
                ItineraryId = Guid.NewGuid().ToString(),
                Date = it.Date,
                ItineraryItems = it.ItineraryItems.Select(i => ToDomainItineraryItem(i)).ToArray()
            };
        }

        public static DomainItineraryItem ToDomainItineraryItem(TriposoItineraryItem it)
        {
            return new DomainItineraryItem
            {
                ItineraryItemId = Guid.NewGuid().ToString(),
                Description = it.Description,
                Title = it.Title,
                Poi = PoiConverter.ToDomainPoi(it.Poi)
            };
        }

        public static DomainDayPlan ToDomainDayPlan(DbDayPlan plan, DomainItinerary[] itineraries)
        {
            return new DomainDayPlan
            {
                DayPlanId = plan.DayPlanId,
                Days = itineraries
            };
        }

        public static DomainItinerary ToDomainItinerary(DbItinerary it, DomainItineraryItem[] items)
        {
            return new DomainItinerary
            {
                ItineraryId = it.ItineraryId,
                Date = it.Date,
                ItineraryItems = items
            };
        }

        public static DomainItineraryItem ToDomainItineraryItem(DbItineraryItem it, Poi poi)
        {
            return new DomainItineraryItem
            {
                ItineraryItemId = it.ItineraryItemId,
                Description = it.Description,
                Title = it.Title,
                Poi = poi
            };
        }

        public static DbDayPlan ToDbDayPlan(DomainDayPlan plan)
        {
            return new DbDayPlan
            {
                DayPlanId = plan.DayPlanId
            };
        }

        public static DbItinerary ToDbItinerary(DomainItinerary it)
        {
            return new DbItinerary
            {
                ItineraryId = it.ItineraryId,
                Date = it.Date
            };
        }

        public static DbItineraryItem ToDbItineraryItem(DomainItineraryItem it)
        {
            return new DbItineraryItem
            {
                ItineraryItemId = it.ItineraryItemId,
                Description = it.Description,
                Title = it.Title
            };
        }
    }
}
