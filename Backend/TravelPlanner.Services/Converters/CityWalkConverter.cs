using TriposoWayPoint = TravelPlanner.Core.Triposo.WayPoint;
using TriposoCityWalk = TravelPlanner.Core.Triposo.CityWalk;
using DbCityWalk = TravelPlanner.Core.DataBaseModels.CityWalk;
using DbWayPoint = TravelPlanner.Core.DataBaseModels.WayPoint;
using DomainWayPoint = TravelPlanner.Core.DomainModels.WayPoint;
using DomainCityWalk = TravelPlanner.Core.DomainModels.CityWalk;
using System.Linq;
using System;
using TravelPlanner.Core.DomainModels;

namespace TravelPlanner.Services.Converters
{
    public class CityWalkConverter
    {
        public static DomainCityWalk ToDomainCityWalk(TriposoCityWalk cityWalk)
        {
            return new DomainCityWalk
            {
                CityWalkId = Guid.NewGuid().ToString(),
                Seed = cityWalk.Seed,
                TotalDuration = cityWalk.TotalDuration,
                WalkDistance = cityWalk.WalkDistance,
                WalkDuration = cityWalk.WalkDuration,
                WayPoints = cityWalk.WayPoints.Select(w => ToDomainWayPoint(w)).ToArray()
            };
        }

        public static DomainCityWalk ToDomainCityWalk(DbCityWalk cityWalk, DomainWayPoint[] wayPoints )
        {
            return new DomainCityWalk
            {
                Seed = cityWalk.Seed,
                CityWalkId = cityWalk.CityWalkId,
                TotalDuration = cityWalk.TotalDuration,
                WalkDistance = cityWalk.WalkDistance,
                WalkDuration = cityWalk.WalkDuration,
                WayPoints = wayPoints
            };
        }

        public static DbCityWalk ToDbCityWalk(DomainCityWalk cityWalk)
        {
            return new DbCityWalk
            {
                Seed = cityWalk.Seed,
                CityWalkId = cityWalk.CityWalkId,
                TotalDuration = cityWalk.TotalDuration,
                WalkDistance = cityWalk.WalkDistance,
                WalkDuration = cityWalk.WalkDuration
            };
        }

        public static DbWayPoint ToDbWayPoint(DomainWayPoint point)
        {
            return new DbWayPoint
            {
                Latitude = point.Latitude,
                WayPointId = point.WayPointId,
                Longitude = point.Longitude,
                VisitTime = point.VisitTime,
                WalkToNextDistance = point.WalkToNextDistance,
                WalkToNextDuration = point.WalkToNextDuration
            };
        }

        public static DomainWayPoint ToDomainWayPoint(TriposoWayPoint point)
        {
            return new DomainWayPoint
            {
                WayPointId = Guid.NewGuid().ToString(),
                Latitude = point.Coordinates.Latitude,
                Longitude = point.Coordinates.Longitude,
                Poi = PoiConverter.ToDomainPoi(point.Poi),
                VisitTime = point.VisitTime,
                WalkToNextDistance = point.WalkToNextDistance,
                WalkToNextDuration = point.WalkToNextDuration
            };
        }

        public static DomainWayPoint ToDomainWayPoint(DbWayPoint point, Poi poi)
        {
            return new DomainWayPoint
            {
                Latitude = point.Latitude,
                Longitude = point.Longitude,
                Poi = poi,
                VisitTime = point.VisitTime,
                WalkToNextDistance = point.WalkToNextDistance,
                WalkToNextDuration = point.WalkToNextDuration,
                WayPointId = point.WayPointId
            };
        }
    }
}
