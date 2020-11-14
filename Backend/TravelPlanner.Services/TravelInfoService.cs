using System.Dynamic;
using System.Threading.Tasks;
using DomainLocations = TravelPlanner.Core.DomainModels.Location;
using DomainDayPlan= TravelPlanner.Core.DomainModels.DayPlan;
using DomainCityWalk = TravelPlanner.Core.DomainModels.CityWalk;
using DomainTour = TravelPlanner.Core.DomainModels.Tour;
using TravelPlanner.Repositories;
using TravelPlanner.Core.Triposo;
using TravelPlanner.Services.Converters;
using System.Collections.Generic;
using System.Linq;

namespace TravelPlanner.Services
{
    public interface ITravelInfoService
    {
        Task<DomainLocations> GetLocationInfoAsync(string cityName);
        Task<Tag[]> GetAvailableTagsAsync(string cityName);
        Task<Article[]> GetArticlesAsync(string cityName, string tag);
        Task<CommonTagLabel[]> GetAvailableTagsAsync();
        Task<DomainCityWalk[]> GetCityWalksAsync(string cityName, int totalTime, bool optimal, bool goInside, string tagLabels, int? latitude = null, int? longitude = null);
        Task<DomainDayPlan[]> GetDayPlanAsync(string locationId, string arrivalTime, string departureTime, string startDate, string endDate, string hotelPoiId, int? itemsPerDay, int? maxDistance);
        Task<LocalHighlights[]> GetLocalHighlights(int latitude, int longitude, int? maxDistance);
        Task<DomainTour[]> GetTourInformation(string locationIds, string poiId, string tagLabels);
    }

    public class TravelInfoService : ITravelInfoService
    {
        private static TriposoApiClient TriposoApiClient;

        public TravelInfoService()
        {
            TriposoApiClient = new TriposoApiClient();
        }

        async public Task<DomainLocations> GetLocationInfoAsync(string cityName)
        {
            var result = await TriposoApiClient.GetLocationInfo(cityName);
            return LocationConverter.ToDomainLocation(result);
        }

        async public Task<Tag[]> GetAvailableTagsAsync(string cityName)
        {
            return await TriposoApiClient.GetAvailableTags(cityName);
        }

        public async Task<CommonTagLabel[]> GetAvailableTagsAsync()
        {
            return await TriposoApiClient.GetCommonTagLabels();
        }

        async public Task<Article[]> GetArticlesAsync(string cityName, string tag)
        {
            if (tag is null)
            {
                return await TriposoApiClient.GetArticles(cityName);
            }
            return await TriposoApiClient.GetArticlesWithSpecifiedTag(cityName, tag); 
        }

        async public Task<DomainCityWalk[]> GetCityWalksAsync(string cityName, int totalTime, bool optimal, bool goInside, string tagLabels, int? latitude = null, int? longitude = null)
        {
            CityWalk[] cityWalks;
            if (!(latitude is null) && !(longitude is null)) 
                cityWalks = await TriposoApiClient.GetCityWalksWithSpecifiedLocation(cityName, totalTime, optimal, goInside, tagLabels, (int)latitude, (int)longitude );
            else 
                cityWalks = await TriposoApiClient.GetCityWalks(cityName, totalTime, optimal, goInside, tagLabels);
            return cityWalks.Select(c => CityWalkConverter.ToDomainCityWalk(c)).ToArray();
        }

        async public Task<DomainDayPlan[]> GetDayPlanAsync(string locationId, string arrivalTime, string departureTime, string startDate, string endDate, string hotelPoiId, int? itemsPerDay, int? maxDistance)
        {
            var dayPlannerRequest = new DayPlannerRequest
            {
                ArrivalTime = arrivalTime,
                DepartureTime = departureTime,
                StartDate = startDate,
                EndDate = endDate,
                HotelPoiId = hotelPoiId,
                ItemsPerDay = itemsPerDay,
                MaxDistance = maxDistance,
                LocationId = locationId
            };
            var response = await TriposoApiClient.GetDayPlan(dayPlannerRequest);
            return response.Select(r => DayPlanConverter.ToDomainDayPlan(r)).ToArray();
        }

        async public Task<LocalHighlights[]> GetLocalHighlights(int latitude, int longitude, int? maxDistance)
        {
            return await TriposoApiClient.GetLocalHighlights(latitude, longitude, maxDistance);
        }

        async public Task<DomainTour[]> GetTourInformation(string locationIds, string poiId, string tagLabels)
        {
            var tours = await TriposoApiClient.GetTourInformation(locationIds, poiId, tagLabels);
            return tours.Select(t => TourConverter.ToDomainTour(t)).ToArray();
        }
    }
}
