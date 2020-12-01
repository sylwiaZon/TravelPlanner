package com.travelplanner.di

import com.travelplanner.api.*
import com.travelplanner.api.createRetrofit

object DIContainer{

    private val retrofit = createRetrofit()
    val usersApiService = retrofit.create(UserApiService::class.java)
    val travelApiService = retrofit.create(TravelApiService::class.java)
    val cityWalkApiService = retrofit.create(CityWalkApiService::class.java)
    val dayPlannerApiService = retrofit.create(DayPlannerApiService::class.java)
    val flightsApiService = retrofit.create(FlightsApiService::class.java)
    val hotelsApiService = retrofit.create(HotelsApiService::class.java)
    val locationInfoApiService = retrofit.create(LocationInfoApiService::class.java)
    val tourInformationApiService = retrofit.create(TourInformationApiService::class.java)
    val weatherForecatsApiService = retrofit.create(WeatherForecatsApiService::class.java)
}