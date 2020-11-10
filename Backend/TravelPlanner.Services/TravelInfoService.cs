using System.Dynamic;
using System.Threading.Tasks;
using DomainLocations = TravelPlanner.Core.DomainModels.Location;
using DomainCityWalk = TravelPlanner.Core.DomainModels.CityWalk;
using TravelPlanner.Repositories;
using TravelPlanner.Core.Triposo;
using TravelPlanner.Services.Converters;

namespace TravelPlanner.Services
{
    public interface ITravelInfoService
    {
        Task<DomainLocations> GetLocationInfoAsync(string cityName);
        Task<Tag[]> GetAvailableTagsAsync(string cityName);
        Task<Article[]> GetArticlesAsync(string cityName, string tag);
        Task<CommonTagLabel[]> GetAvailableTagsAsync();
        Task<DomainCityWalk[]> GetCityWalksAsync(string cityName, int totalTime, bool optimal, bool goInside, string tagLabels, int? latitude = null, int? longitude = null);
        Task<DayPlan[]> GetDayPlanAsync(string locationId, string arrivalTime, string departureTime, string startDate, string endDate, string hotelPoiId, int? itemsPerDay, int? maxDistance);
        Task<LocalHighlights[]> GetLocalHighlights(int latitude, int longitude, int? maxDistance);
        Task<Tour[]> GetTourInformation(string locationIds, string poiId, string tagLabels);
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
            CityWalk cityWalk;
            if (!(latitude is null) && !(longitude is null)) 
                cityWalk = await TriposoApiClient.GetCityWalksWithSpecifiedLocation(cityName, totalTime, optimal, goInside, tagLabels, (int)latitude, (int)longitude );
            else 
                cityWalk = await TriposoApiClient.GetCityWalks(cityName, totalTime, optimal, goInside, tagLabels);
            return 
        }

        async public Task<DayPlan[]> GetDayPlanAsync(string locationId, string arrivalTime, string departureTime, string startDate, string endDate, string hotelPoiId, int? itemsPerDay, int? maxDistance)
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
            return await TriposoApiClient.GetDayPlan(dayPlannerRequest);
        }

        async public Task<LocalHighlights[]> GetLocalHighlights(int latitude, int longitude, int? maxDistance)
        {
            return await TriposoApiClient.GetLocalHighlights(latitude, longitude, maxDistance);
        }

        async public Task<Tour[]> GetTourInformation(string locationIds, string poiId, string tagLabels)
        {
            return await TriposoApiClient.GetTourInformation(locationIds, poiId, tagLabels);
        }
    }
}
