package com.travelplanner.models

import java.time.LocalDateTime

class Travel(val travelId: String, val arrivalDate: LocalDateTime, val departureDate: LocalDateTime, val participants: TravelParticipants, val travelDestination: TravelDestination, val photoUrl: String)

class TravelDestination(val city: String, val country: String)
class TravelParticipants(val children: Int, val childrenAges: List<Int>, val adults: Int )