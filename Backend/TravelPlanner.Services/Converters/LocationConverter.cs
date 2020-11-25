using System.Linq;
using TravelPlanner.Core.DomainModels;
using DbLocation = TravelPlanner.Core.DataBaseModels.Location;
using TriposoLocation = TravelPlanner.Core.Triposo.Location;

namespace TravelPlanner.Services.Converters
{
    public class LocationConverter
    {
        public static DbLocation ToDbLocation(Location location)
        {
            return new DbLocation
            {
                LocationId = location.Latitude + ":" + location.Longitude + location.Name,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                CountryId = location.CountryId,
                Intro = location.Intro,
                Name = location.Name,
                Names = location.Names,
                ParentId = location.ParentId,
                PartOf = location.PartOf,
                Snippet = location.Snippet,
                TagLabels = location.TagLabels,
                Type = location.Type,
                PhotoUrl = location.PhotoUrl
            };
        }

        public static Location ToDomainLocation(DbLocation location)
        {
            return new Location
            {
                LocationId = location.LocationId,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                CountryId = location.CountryId,
                Intro = location.Intro,
                Name = location.Name,
                Names = location.Names,
                ParentId = location.ParentId,
                PartOf = location.PartOf,
                Snippet = location.Snippet,
                TagLabels = location.TagLabels,
                Type = location.Type,
                PhotoUrl = location.PhotoUrl
            };
        }

        public static Location ToDomainLocation(TriposoLocation location)
        {
            return new Location
            {
                Latitude = location.Coordinates.Latitude,
                Longitude = location.Coordinates.Longitude,
                CountryId = location.CountryId,
                Intro = location.Intro,
                Name = location.Name,
                Names = location.Names,
                ParentId = location.ParentId,
                PartOf = location.PartOf,
                Snippet = location.Snippet,
                TagLabels = location.TagLabels,
                Type = location.Type,
                LocationId = location.Coordinates.Latitude + ":" + location.Coordinates.Longitude + location.Name,
                PhotoUrl = GetPhotoUrl(location)
            };
        }

        private static string GetPhotoUrl(TriposoLocation location)
        {
            if (location.Images?.FirstOrDefault().Sizes.Medium != null)
                return location.Images?.FirstOrDefault().Sizes.Medium.Url;
            else return location.Images?.FirstOrDefault().Sizes.Original.Url;
        }
    }
}
