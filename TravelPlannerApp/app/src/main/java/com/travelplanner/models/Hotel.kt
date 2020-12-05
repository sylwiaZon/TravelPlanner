package com.travelplanner.models

class HotelWithDetails(val hotel: Hotel, val transport: List<HotelTransport>)

class Hotel(val hotelId: String, val geoId: String, val destinationId: String,
            val landmarkCityDestinationId: String, val type: String, val caption: String,
            val redirectPage: String, val latitude: Float, val Longitude: Float, val name: String)

class HotelTransport(val category: String, val transportLocations: List<TransportLocations>)

class TransportLocations(val name: String, val distance: String, val distanceInTime: String)