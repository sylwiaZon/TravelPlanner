using DomainPoi = TravelPlanner.Core.DomainModels.Poi;
using TriposoPoi = TravelPlanner.Core.Triposo.Poi;
using DbPoi = TravelPlanner.Core.DataBaseModels.Poi;

namespace TravelPlanner.Services.Converters
{
    public class PoiConverter
    {
        public static DomainPoi ToDomainPoi(TriposoPoi poi)
        {
            return new DomainPoi
            {
                PoiId = poi.Coordinates.Latitude + ":" + poi.Coordinates.Longitude + poi.LocationId,
                Price = poi.BookingInfo?.Price.Amount,
                Currency = poi.BookingInfo?.Price.Currency,
                Latitude = poi.Coordinates.Latitude,
                Longitude = poi.Coordinates.Longitude,
                Id = poi.Id,
                Intro = poi.Intro,
                LocationId = poi.LocationId,
                Name = poi.Name,
                Score = poi.Score,
                Snippet = poi.Snippet
            };
        }

        public static DomainPoi ToDomainPoi(DbPoi poi)
        {
            return new DomainPoi
            {
                PoiId = poi.PoiId,
                Price = poi.Price,
                Currency = poi.Currency,
                Latitude = poi.Latitude,
                Longitude = poi.Longitude,
                Id = poi.Id,
                Intro = poi.Intro,
                LocationId = poi.LocationId,
                Name = poi.Name,
                Score = poi.Score,
                Snippet = poi.Snippet
            };
        }

        public static DbPoi ToDbPoi(DomainPoi poi)
        {
            return new DbPoi
            {
                PoiId = poi.PoiId,
                Price = poi.Price,
                Currency = poi.Currency,
                Latitude = poi.Latitude,
                Longitude = poi.Longitude,
                Id = poi.Id,
                Intro = poi.Intro,
                LocationId = poi.LocationId,
                Name = poi.Name,
                Score = poi.Score,
                Snippet = poi.Snippet
            };
        }
    }
}