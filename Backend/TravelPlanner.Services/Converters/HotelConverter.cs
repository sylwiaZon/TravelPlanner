using TravelPlanner.Core.HotelsApi.Details;
using DbHotel = TravelPlanner.Core.DataBaseModels.Hotel;
using DomainHotel = TravelPlanner.Core.DomainModels.Hotel;

namespace TravelPlanner.Services.Converters
{
    public class HotelConverter
    {
        public static DomainHotel ToDomainHotel (DbHotel hotel)
        {
            return new DomainHotel
            {
                GeoId = hotel.GeoId,
                DestinationId = hotel.DestinationId,
                LandmarkCityDestinationId = hotel.LandmarkCityDestinationId,
                Type = hotel.Type,
                Caption = hotel.Caption,
                RedirectPage = hotel.RedirectPage,
                Latitude = hotel.Latitude,
                Longitude = hotel.Longitude,
                Name = hotel.Name,
                HotelId = hotel.Latitude + hotel.Longitude + hotel.Name
            };
        }

        public static DbHotel ToDbHotel(DomainHotel hotel)
        {
            return new DbHotel
            {
                GeoId = hotel.GeoId,
                DestinationId = hotel.DestinationId,
                LandmarkCityDestinationId = hotel.LandmarkCityDestinationId,
                Type = hotel.Type,
                Caption = hotel.Caption,
                RedirectPage = hotel.RedirectPage,
                Latitude = hotel.Latitude,
                Longitude = hotel.Longitude,
                Name = hotel.Name,
                HotelId = hotel.Latitude + ":" + hotel.Longitude + hotel.Name
            };
        }
    }
}
