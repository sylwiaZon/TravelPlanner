using System;
using System.Collections.Generic;
using System.Linq;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Core.Flights;
using DomainFlight = TravelPlanner.Core.DomainModels.Flight;
using DBFlight = TravelPlanner.Core.DataBaseModels.Flight;
using DBAirportFlightStatus = TravelPlanner.Core.DataBaseModels.AirportFlightStatus;
using DomainAirportFlightStatus = TravelPlanner.Core.DomainModels.AirportFlightStatus;
using LufthansaAirportFlightStatus = TravelPlanner.Core.Flights.AirportFlightStatus;
using TravelPlanner.Core.DataBaseModels;

namespace TravelPlanner.Services.Converters
{
    public class FlightConverter
    {
        public static IEnumerable<DomainFlight> ToDomainFlights(FlightsSchedule flight)
        {
            var flights = flight.ScheduleResource.Schedule.SelectMany(schedule => {
                return schedule.Flight.Select(f =>
                    new DomainFlight
                    {
                        FlightDuration = ConvertToFlightDuration(schedule.TotalJourney.Duration),
                        Departure = ToDomainAirportFlightStatus(f.Departure),
                        Arrival = ToDomainAirportFlightStatus(f.Arrival),
                        AirlineId = f.MarketingCarrier.AirlineId,
                        FlightNumber = f.MarketingCarrier.FlightNumber
                    }
                ).ToList();
            });
            return flights;
        }

        public static DomainFlight ToDomainFlight(FlightStatusResponse flight)
        {
            var flights = flight.FlightStatusResource.Flights.Flight
                .Select(f =>
                    new DomainFlight
                    {
                        Departure = ToDomainAirportFlightStatus(f.Departure),
                        Arrival = ToDomainAirportFlightStatus(f.Arrival),
                        AirlineId = f.MarketingCarrier.AirlineId,
                        FlightNumber = f.MarketingCarrier.FlightNumber
                    }
                ).ToList();
            if(flights.Any())
                return flights.First();
            return null;
        }

        public static DBFlight ToDBFlight(DomainFlight domainFlight)
        {
            return new DBFlight
            {
                AirlineId = domainFlight.AirlineId,
                FlightNumber = domainFlight.FlightNumber,
                DurationDays = domainFlight.FlightDuration.Days,
                DurationHours = domainFlight.FlightDuration.Hours,
                DurationMinutes = domainFlight.FlightDuration.Minutes
            };
        }

        public static DomainFlight ToDomainFlight(DBFlight flight, DBAirportFlightStatus departure, DBAirportFlightStatus arrival)
        {
            return new DomainFlight
            {
                FlightDuration = new FlightDuration
                {
                    Days = flight.DurationDays,
                    Minutes = flight.DurationMinutes,
                    Hours = flight.DurationHours
                },
                AirlineId = flight.AirlineId,
                FlightNumber = flight.FlightNumber,
                Departure = ToDomainAirportFlightStatus(departure),
                Arrival = ToDomainAirportFlightStatus(arrival)
            };
        }

        public static DomainAirportFlightStatus ToDomainAirportFlightStatus(DBAirportFlightStatus status)
        {
            return new DomainAirportFlightStatus
            {
                AirportCode = status.AirportCode,
                ScheduledTimeLocal = status.ScheduledTimeLocal,
                TerminalName = status.TerminalName
            };
        }

        public static DBAirportFlightStatus ToDBAirportFlightStatus(DomainAirportFlightStatus status)
        {
            return new DBAirportFlightStatus
            {
                AirportCode = status.AirportCode,
                ScheduledTimeLocal = status.ScheduledTimeLocal,
                TerminalName = status.TerminalName
            };
        }

        public static LufthansaAirportFlightStatus ToLufthansaAirportFlightStatus(DomainAirportFlightStatus status)
        {
            return new LufthansaAirportFlightStatus
            {
                AirportCode = status.AirportCode,
                ScheduledTimeLocal = new ScheduledTime
                {
                    DateTime = status.ScheduledTimeLocal.ToString()
                },
                Terminal = new Terminal
                {
                    Name = status.TerminalName
                }
            };
        }

        public static DomainAirportFlightStatus ToDomainAirportFlightStatus(LufthansaAirportFlightStatus status)
        {
            return new DomainAirportFlightStatus
            {
                AirportCode = status.AirportCode,
                ScheduledTimeLocal = DateTime.Parse(status.ScheduledTimeLocal.DateTime),
                TerminalName = status.Terminal.Name
            };
        }

        private static FlightDuration ConvertToFlightDuration(string duration)
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
