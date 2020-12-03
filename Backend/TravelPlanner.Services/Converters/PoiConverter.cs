using DomainPoi = TravelPlanner.Core.DomainModels.Poi;
using DomainAttribution = TravelPlanner.Core.DomainModels.Attribution;
using TriposoPoi = TravelPlanner.Core.Triposo.Poi;
using DbPoi = TravelPlanner.Core.DataBaseModels.Poi;
using DbAttribution = TravelPlanner.Core.DataBaseModels.Attribution;
using TriposoAttribution = TravelPlanner.Core.Triposo.Attribution;
using System.Linq;

namespace TravelPlanner.Services.Converters
{
    public class PoiConverter
    {
        public static DomainPoi ToDomainPoi(TriposoPoi poi)
        {
            return new DomainPoi
            {
                PoiId = poi.Coordinates.Latitude + ":" + poi.Coordinates.Longitude + poi.LocationId,
                Price = poi.BookingInfo?.Price.Amount + poi.BookingInfo?.Price.Currency,
                VendorUrl = poi.BookingInfo?.VendorObjectUrl,
                Currency = poi.BookingInfo?.Price.Currency,
                Latitude = poi.Coordinates.Latitude,
                Longitude = poi.Coordinates.Longitude,
                Id = poi.Id,
                Intro = poi.Intro,
                LocationId = poi.LocationId,
                Name = poi.Name,
                Score = poi.Score,
                Snippet = poi.Snippet,
                PhotoUrl = poi.Images.Length > 0 ? poi.Images[0].Sizes.Medium?.Url : null,
                Attribution = poi.Attributions.Select(a => ToDomainAttribution(a)).ToArray()
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
                Snippet = poi.Snippet,
                PhotoUrl = poi.PhotoUrl,
                VendorUrl = poi.VendorUrl
            };
        }

        public static DbAttribution ToDbAttribution(DomainAttribution attribution)
        {
            return new DbAttribution
            {
                Url = attribution.Url,
                Source = attribution.Source
            };
        }

        public static DomainAttribution ToDomainAttribution(DbAttribution attribution)
        {
            return new DomainAttribution
            {
                Url = attribution.Url,
                Source = attribution.Source
            };
        }

        public static DomainAttribution ToDomainAttribution(TriposoAttribution attribution)
        {
            return new DomainAttribution
            {
                Url = attribution.Url,
                Source = attribution.SourceID
            };
        }
    }
}