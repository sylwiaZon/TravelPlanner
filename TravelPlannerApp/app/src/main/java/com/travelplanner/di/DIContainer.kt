package com.travelplanner.di

import com.travelplanner.api.*
import com.travelplanner.api.createRetrofit
import com.travelplanner.utils.RxSchedulers

interface IDIContainer {
    val schedulers: RxSchedulers
    val usersApiService: UserApiService
    var travelApiService: TravelApiService
    val cityWalkApiService: CityWalkApiService
    val dayPlannerApiService: DayPlannerApiService
    val flightsApiService: FlightsApiService
    val hotelsApiService: HotelsApiService
    val locationInfoApiService: LocationInfoApiService
    val tourInformationApiService: TourInformationApiService
    val weatherForecastApiService: WeatherForecastApiService
}

object DIContainer : IDIContainer{

    private val retrofit = createRetrofit()
    override val schedulers: RxSchedulers = RxSchedulers()
    override val usersApiService = retrofit.create(UserApiService::class.java)
    override var travelApiService = retrofit.create(TravelApiService::class.java)
    override val cityWalkApiService = retrofit.create(CityWalkApiService::class.java)
    override val dayPlannerApiService = retrofit.create(DayPlannerApiService::class.java)
    override val flightsApiService = retrofit.create(FlightsApiService::class.java)
    override val hotelsApiService = retrofit.create(HotelsApiService::class.java)
    override val locationInfoApiService = retrofit.create(LocationInfoApiService::class.java)
    override val tourInformationApiService = retrofit.create(TourInformationApiService::class.java)
    override val weatherForecastApiService = retrofit.create(WeatherForecastApiService::class.java)
}