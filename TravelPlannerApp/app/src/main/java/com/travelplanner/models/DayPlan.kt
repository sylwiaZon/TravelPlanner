package com.travelplanner.models

import java.time.LocalDateTime

class DayPlan(val dayPlanId: String, val days: List<Itinerary>)

class Itinerary(val itineraryId: String, val date: LocalDateTime, val dayItems: List<ItineraryItem>)

class ItineraryItem(val itineraryItemId: String, val description: String, val poi: Poi, val title: String)