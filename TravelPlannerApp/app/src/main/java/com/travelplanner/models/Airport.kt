package com.travelplanner.models

class Airport (val airportCode: String, val latitude: Float, val longitude: Float,
               val cityCode: String, val countryCode: String, val locationType: String,
               val names: List<String>, val distanceValue: Float, val distanceUnit: String )

