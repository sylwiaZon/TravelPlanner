package com.travelplanner.models

import java.time.LocalDate
import java.time.LocalDateTime

class DayPlan(val dayPlanId: String, val days: List<Itinerary>)

class Itinerary(val itineraryId: String, val date: LocalDate, val itineraryItems: List<ItineraryItem>)

class ItineraryItem(val itineraryItemId: String, val description: String, val poi: Poi, val title: String)