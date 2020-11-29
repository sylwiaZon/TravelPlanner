using DbHotel = TravelPlanner.Core.DataBaseModels.Hotel;
using DbTransport = TravelPlanner.Core.DataBaseModels.TransportLocation;
using DomainHotel = TravelPlanner.Core.DomainModels.Hotel;
using DomainTransport = TravelPlanner.Core.DomainModels.HotelTransport;
using DomainTransportLocation = TravelPlanner.Core.DomainModels.TransportLocation;
using TriposoLocation = TravelPlanner.Core.HotelsApi.Details.Location;
using TravelPlanner.Core.HotelsApi.Search;
using System.Collections.Generic;
using System.Linq;
using System;
using TravelPlanner.Core.HotelsApi.Details;

namespace TravelPlanner.Services.Converters
{
    public class HotelConverter
    {
        public static IEnumerable<DomainHotel> ToDomainHotel(HotelSearch hotelSearch)
        {
            var hotelsList = new List<DomainHotel>();
            foreach(var h in hotelSearch.Suggestions)
            {
                var hotels = h.Entities.Where(e => e.Type == "HOTEL");
                hotelsList.AddRange(hotels.Select(e => new DomainHotel
                {
                    GeoId = e.GeoId,
                    DestinationId = e.DestinationId,
                    LandmarkCityDestinationId = e.LandmarkCityDestinationId,
                    Type = e.Type,
                    Caption = e.Caption,
                    RedirectPage = e.RedirectPage,
                    Latitude = e.Latitude,
                    Longitude = e.Longitude,
                    Name = e.Name,
                    HotelId = e.Latitude + e.Longitude + e.Name
                }));
            }
            return hotelsList;
        }

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

        public static IEnumerable<DomainTransport> ToDomainHotelTransport(HotelDetails details)
        {
            return details.Transportation.TransportLocations.Select(t =>
                new DomainTransport
                {
                    Category = t.Category,
                    TransportLocations = t.Locations.Select(l =>
                    new DomainTransportLocation
                    {
                        Name = l.Name,
                        Distance = l.Distance,
                        DistanceInTime = l.DistanceInTime
                    }).ToArray()
                });
        }

        public static DomainTransportLocation ToDomainTransportLocation(DbTransport transport)
        {
            return new DomainTransportLocation
                {
                    Name = transport.Name,
                    Distance = transport.Distance,
                    DistanceInTime = transport.DistanceInTime
                };
        }

        public static DbTransport ToDbTransportLocation(DomainTransportLocation transport)
        {
            return new DbTransport
            {
                Name = transport.Name,
                Distance = transport.Distance,
                DistanceInTime = transport.DistanceInTime
            };
        }

        public static DbTransport ToDbTransportLocation(TriposoLocation transport)
        {
            return new DbTransport
            {
                Name = transport.Name,
                Distance = transport.Distance,
                DistanceInTime = transport.DistanceInTime
            };
        }
    }
}
