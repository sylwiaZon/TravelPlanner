using System.Dynamic;
using System.Threading.Tasks;
using TravelPlanner.Core.Triposo;
using TravelPlanner.Repositories;

namespace TravelPlanner.Services
{
    public interface ITravelInfoService
    {
        Task<Location> GetLocationInfoAsync(string cityName);
        Task<Tag[]> GetAvailableTagsAsync(string cityName);
        Task<Article[]> GetArticlesAsync(string cityName, string tag);
        Task<CommonTagLabel[]> GetAvailableTagsAsync();
        Task<CityWalk[]> GetCityWalksAsync(string cityName, int totalTime, bool optimal, bool goInside, string tagLabels, int? latitude = null, int? longitude = null);
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

        async public Task<Location> GetLocationInfoAsync(string cityName)
        {
            return await TriposoApiClient.GetTripInfo(cityName);
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

        async public Task<CityWalk[]> GetCityWalksAsync(string cityName, int totalTime, bool optimal, bool goInside, string tagLabels, int? latitude = null, int? longitude = null)
        {
            if (!(latitude is null) && !(longitude is null)) return await TriposoApiClient.GetCityWalksWithSpecifiedLocation(cityName, totalTime, optimal, goInside, tagLabels, (int)latitude, (int)longitude );
            return await TriposoApiClient.GetCityWalks(cityName, totalTime, optimal, goInside, tagLabels);
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
