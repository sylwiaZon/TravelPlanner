package com.travelplanner.models

import java.time.LocalDateTime

class Flight(val flightId: String, val flightDuration: FlightDuration,
             val departure: AirportFlightStatus, val arrival: AirportFlightStatus,
             val airlineId: String, val flightNumber: String)

class FlightDuration(val days: Int, val hours: Int, val minutes: Int)

class AirportFlightStatus(val airportCode: String, val scheduledTimeLocal: LocalDateTime, val terminalName: String)