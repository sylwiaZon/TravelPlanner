package com.travelplanner.models

import java.time.LocalDate

class Travel(val travelId: String, val date: LocalDate,  val participants: TravelParticipants, val travelDestination: TravelDestination)

class TravelDestination(val city: String, val country: String)
class TravelParticipants(val children: Int, val childrenAges: List<Int>, val adults: Int )