using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Core.Flights;
using DomainFlight = TravelPlanner.Core.DomainModels.Flight;

namespace TravelPlanner.Services.Converters
{
    public class FlightConverter
    {
        public IEnumerable<DomainFlight> ToDomainFlight(FlightsSchedule flight)
        {
            var flights = flight.ScheduleResource.Schedule.SelectMany(schedule => {
                return schedule.Flight.Select(f =>
                    new DomainFlight
                    {
                        FlightDuration = ConvertToFlightDuration(schedule.TotalJourney.Duration),
                        Departure = f.Departure,
                        Arrival = f.Arrival,
                        AirlineId = f.MarketingCarrier.AirlineId,
                        FlightNumber = f.MarketingCarrier.FlightNumber
                    }
                ).ToList();
            });
            return flights;
        }

        public DomainFlight ToDomainFlight(FlightStatusResponse flight)
        {
            var flights = flight.FlightStatusResource.Flights.Flight
                .Select(f =>
                    new DomainFlight
                    {
                        Departure = f.Departure,
                        Arrival = f.Arrival,
                        AirlineId = f.MarketingCarrier.AirlineId,
                        FlightNumber = f.MarketingCarrier.FlightNumber
                    }
                ).ToList();
            if(flights.Any())
                return flights.First();
            return null;
        }

        private FlightDuration ConvertToFlightDuration(string duration)
        {
            var hIndex = duration.IndexOf('H');
            var tIndex = duration.IndexOf('T');
            var dIndex = duration.IndexOf('D');
            var mIndex = duration.IndexOf('M');
            var days = 0;
            var minutes = 0;
            if (dIndex != -1) {
                days = Int32.Parse(duration.Substring(1, dIndex - 1));
            }

            var hours = Int32.Parse(duration.Substring(tIndex + 1, hIndex - tIndex - 1));

            if (mIndex != -1)
            {
                minutes = Int32.Parse(duration.Substring(hIndex + 1, mIndex - hIndex - 1));
            }

            return new FlightDuration
            {
                Days = days,
                Hours = hours,
                Minutes = minutes
            };
        }
    }
}
