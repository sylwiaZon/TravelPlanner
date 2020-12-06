using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TravelPlanner.Core.Triposo;

namespace TravelPlanner.Repositories
{
    public class TriposoApiClient
    {
        private static readonly HttpClient Client = new HttpClient();
        private static readonly string ApiPath = "https://www.triposo.com/api/20200803/";
        private static string AccountId;
        private static string Token;

        public TriposoApiClient()
        {
            AccountId = Environment.GetEnvironmentVariable("TRIPOSO_ACCOUNTID");
            Token = Environment.GetEnvironmentVariable("TRIPOSO_TOKEN");
        }

        public async Task<Location> GetLocationInfo(string cityName)
        {
            var responseMessage = await Client.GetAsync(ApiPath + "location.json?tag_labels=city&annotate=trigram:" + cityName + "&trigram=>=0.7&account=" + AccountId+"&token="+Token);
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = await responseMessage.Content.ReadAsAsync<ResponseObject<Location>>();
                return response.Results.FirstOrDefault();
            }
            return null;
        }

        public async Task<Tag[]> GetAvailableTags(string cityName)
        {
            var path = ApiPath + "article.json?location_id=" + cityName + "&account=" + AccountId + "&token=" + Token;
            var responseMessage = await Client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = await responseMessage.Content.ReadAsAsync<ResponseObject<Tag>>();
                return response.Results;
            }
            return null;
        }
        
        public async Task<Article[]> GetArticles(string cityName)
        {
            var path = ApiPath + "article.json?location_id=" + cityName + "&account=" + AccountId + "&token=" + Token;
            var responseMessage = await Client.GetAsync(path); 
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = await responseMessage.Content.ReadAsAsync<ResponseObject<Article>>();
                return response.Results;
            }
            return null;
        }

        public async Task<Article[]> GetArticlesWithSpecifiedTag(string cityName, string tag)
        {
            var path = ApiPath + "article.json?location_id=" + cityName + "&tag_labels=" + tag + "&account=" + AccountId + "&token=" + Token;
            var responseMessage = await Client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = await responseMessage.Content.ReadAsAsync<ResponseObject<Article>>();
                return response.Results;
            }
            return null;
        }

        public async Task<CityWalk[]> GetCityWalksWithSpecifiedLocation(string cityName, int totalTime, bool optimal, bool goInside, string tagLabels, int latitude, int longitude)
        {
            var tagl = tagLabels == null ? "" : "&tag_labels=" + tagLabels;
            var path = ApiPath + "city_walk.json?location_id=" + cityName + tagl + "&longitude=" + longitude + "&latitude=" + latitude + "&total_time=" + totalTime + "&optimal=" + optimal + "&go_inside=" + goInside + "&account=" + AccountId + "&token=" + Token;
            var responseMessage = await Client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = await responseMessage.Content.ReadAsAsync<ResponseObject<CityWalk>>();
                return response.Results;
            }
            return null;
        }

        public async Task<CityWalk[]> GetCityWalks(string cityName, int totalTime, bool optimal, bool goInside, string tagLabels)
        {
            var tagl = tagLabels == null ? "" : "&tag_labels=" + tagLabels;
            var path = ApiPath + "city_walk.json?location_id=" + cityName + "&total_time=" + totalTime + "&optimal=" + optimal + tagl + "&go_inside=" + goInside + "&account=" + AccountId + "&token=" + Token;
            var responseMessage = await Client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = await responseMessage.Content.ReadAsAsync<ResponseObject<CityWalk>>();
                return response.Results;
            }
            return null;
        }

        public async Task<DayPlan[]> GetDayPlan(DayPlannerRequest dayPlannerRequest)
        {
            var path = ApiPath + "day_planner.json?location_id=" + dayPlannerRequest.LocationId;
            if (!(dayPlannerRequest.HotelPoiId is null)) path += "&hotel_poi_id=" + dayPlannerRequest.HotelPoiId;
            if (!(dayPlannerRequest.StartDate is null)) path += "&start_date=" + dayPlannerRequest.StartDate;
            if (!(dayPlannerRequest.EndDate is null)) path += "&end_date=" + dayPlannerRequest.EndDate;
            if (!(dayPlannerRequest.ArrivalTime is null)) path += "&arrival_time=" + dayPlannerRequest.ArrivalTime;
            if (!(dayPlannerRequest.DepartureTime is null)) path += "&departure_time=" + dayPlannerRequest.DepartureTime;
            if (!(dayPlannerRequest.ItemsPerDay is null)) path += "&items_per_day=" + dayPlannerRequest.ItemsPerDay;
            if (!(dayPlannerRequest.MaxDistance is null)) path += "&max_distance=" + dayPlannerRequest.MaxDistance;
            path += "&account=" + AccountId + "&token=" + Token;
            var responseMessage = await Client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = await responseMessage.Content.ReadAsAsync<ResponseObject<DayPlan>>();
                return response.Results;
            }
            return null;
        }

        public async Task<CommonTagLabel[]> GetCommonTagLabels()
        {
            var path = ApiPath + "common_tag_labels.json?";
            path += "&account=" + AccountId + "&token=" + Token;
            var responseMessage = await Client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = await responseMessage.Content.ReadAsAsync<ResponseObject<CommonTagLabel>>();
                return response.Results;
            }
            return null;
        }

        public async Task<LocalHighlights[]> GetLocalHighlights(int latitude, int longitude, int? maxDistance)
        {
            var path = ApiPath + "local_highlights.json?&latitude=" + latitude + "&longitude=" + longitude;
            if (!(maxDistance is null)) path += "&max_distance=" + maxDistance;
            path += "&account=" + AccountId + "&token=" + Token;
            var responseMessage = await Client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = await responseMessage.Content.ReadAsAsync<ResponseObject<LocalHighlights>>();
                return response.Results;
            }
            return null;
        }

        public async Task<Tour[]> GetTourInformation(string locationIds, string poiId, string tagLabels)
        {
            var path = ApiPath + "tour.json?";
            if (!(locationIds is null)) path += "&location_ids=" + locationIds;
            if (!(poiId is null)) path += "&poi_id=" + poiId;
            if (!(tagLabels is null)) path += "&tag_labels=" + tagLabels;
            path += "&account=" + AccountId + "&token=" + Token;
            var responseMessage = await Client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = await responseMessage.Content.ReadAsAsync<ResponseObject<Tour>>();
                return response.Results;
            }
            return null;
        }

        public async Task<Tour[]> GetTourInformation(string locationIds)
        {
            var path = ApiPath + "tour.json?";
            if (!(locationIds is null)) path += "&location_ids=" + locationIds;
            path += "&account=" + AccountId + "&token=" + Token;
            var responseMessage = await Client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = await responseMessage.Content.ReadAsAsync<ResponseObject<Tour>>();
                return response.Results;
            }
            return null;
        }
    }
}
