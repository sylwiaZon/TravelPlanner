using System;
using System.Collections.Generic;
using System.Linq;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Core.Flights;
using DomainFlight = TravelPlanner.Core.DomainModels.Flight;
using DBFlight = TravelPlanner.Core.DataBaseModels.Flight;
using DomainAirportFlightStatus = TravelPlanner.Core.DomainModels.AirportFlightStatus;
using DomainAirport= TravelPlanner.Core.DomainModels.Airport;
using LufthansaAirportFlightStatus = TravelPlanner.Core.Flights.AirportFlightStatus;
using LufthansaNearestAirport = TravelPlanner.Core.Flights.NearestAirport;

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
                        FlightId = f.MarketingCarrier.AirlineId + f.MarketingCarrier.FlightNumber + f.Arrival.ScheduledTimeLocal,
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
                        FlightId = f.MarketingCarrier.AirlineId + f.MarketingCarrier.FlightNumber + f.Arrival.ScheduledTimeLocal.DateTime,
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
                FlightId = domainFlight.FlightId,
                AirlineId = domainFlight.AirlineId,
                FlightNumber = domainFlight.FlightNumber,
                DurationDays = domainFlight.FlightDuration.Days,
                DurationHours = domainFlight.FlightDuration.Hours,
                DurationMinutes = domainFlight.FlightDuration.Minutes,
                ArrivalAirportCode = domainFlight.Arrival.AirportCode,
                ArrivalScheduledTimeLocal = domainFlight.Arrival.ScheduledTimeLocal,
                ArrivalTerminalName = domainFlight.Arrival.TerminalName,
                DepartureAirportCode = domainFlight.Departure.AirportCode,
                DepartureScheduledTimeLocal = domainFlight.Departure.ScheduledTimeLocal,
                DepartureTerminalName = domainFlight.Departure.TerminalName
            };
        }

        public static DomainFlight ToDomainFlight(DBFlight flight)
        {
            return new DomainFlight
            {
                FlightId = flight.FlightId,
                FlightDuration = new FlightDuration
                {
                    Days = flight.DurationDays,
                    Minutes = flight.DurationMinutes,
                    Hours = flight.DurationHours
                },
                AirlineId = flight.AirlineId,
                FlightNumber = flight.FlightNumber,
                Arrival = new DomainAirportFlightStatus
                {
                    AirportCode = flight.ArrivalAirportCode,
                    ScheduledTimeLocal = flight.ArrivalScheduledTimeLocal,
                    TerminalName = flight.ArrivalTerminalName
                },
                Departure = new DomainAirportFlightStatus
                {
                    AirportCode = flight.DepartureAirportCode,
                    ScheduledTimeLocal = flight.DepartureScheduledTimeLocal,
                    TerminalName = flight.DepartureTerminalName
                }
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
                TerminalName = status.Terminal?.Name
            };
        }

        public static IEnumerable<DomainAirport> ToDomainAirport(LufthansaNearestAirport lufthansaNearestAirport)
        {
            return lufthansaNearestAirport.NearestAirportResource.Airports.Airport.Select(a => 
                new DomainAirport
                {
                    AirportCode = a.AirportCode,
                    Latitude = a.Position.Coordinate.Latitude,
                    Longitude = a.Position.Coordinate.Longitude,
                    CityCode = a.CityCode,
                    CountryCode = a.CountryCode, 
                    LocationType = a.LocationType,
                    Names = a.Names.Name.Select(n => new AirportName { LanguageCode = n.LanguageCode, WholeName = n.WholeName}).ToArray(),
                    DistanceUnit = a.Distance.Unit,
                    DistanceValue = a.Distance.Value
                });
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
