package com.travelplanner.models

class Airport (val airportCode: String, val latitude: Float, val longitude: Float,
               val cityCode: String, val countryCode: String, val locationType: String,
               val name: List<AirportName>, val distanceValue: Float, val distanceUnit: String )

class AirportName(val languageCode: String, val wholeName: String)