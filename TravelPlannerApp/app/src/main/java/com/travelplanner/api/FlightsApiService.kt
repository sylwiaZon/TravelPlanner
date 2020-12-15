package com.travelplanner.api

import com.travelplanner.models.Airport
import com.travelplanner.models.Flight
import io.reactivex.Single
import retrofit2.http.GET
import retrofit2.http.Query

interface FlightsApiService {
    @GET("flights")
    fun getFlights(@Query("origin") origin: String, @Query("destination") destination: String, @Query("date") date: String): Single<List<Flight>>

    @GET("flights/airports")
    fun getNearestAirports(@Query("latitude") latitude: String, @Query("longitude") longitude: String): Single<List<Airport>>
}