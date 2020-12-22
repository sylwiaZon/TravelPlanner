package com.travelplanner

import android.app.Application
import androidx.test.runner.AndroidJUnitRunner
import com.nhaarman.mockitokotlin2.mock
import com.travelplanner.api.*
import com.travelplanner.di.IDIContainer
import com.travelplanner.utils.RxSchedulers

class TravelPlannerRunner: AndroidJUnitRunner() {
    override fun callApplicationOnCreate(app: Application?) {
        super.callApplicationOnCreate(app)
        (app as TravelPlannerApplication).diContainer = di
    }

    companion object {
        val di = object : IDIContainer {
            private lateinit var _travelApiService: TravelApiService

            override val schedulers: RxSchedulers
                get() = mock()
            override val usersApiService: UserApiService
                get() = TODO("Not yet implemented")
            override var travelApiService: TravelApiService
                get() = _travelApiService
                set(value) { _travelApiService = value }
            override val cityWalkApiService: CityWalkApiService
                get() = TODO("Not yet implemented")
            override val dayPlannerApiService: DayPlannerApiService
                get() = TODO("Not yet implemented")
            override val flightsApiService: FlightsApiService
                get() = TODO("Not yet implemented")
            override val hotelsApiService: HotelsApiService
                get() = TODO("Not yet implemented")
            override val locationInfoApiService: LocationInfoApiService
                get() = TODO("Not yet implemented")
            override val tourInformationApiService: TourInformationApiService
                get() = TODO("Not yet implemented")
            override val weatherForecastApiService: WeatherForecastApiService
                get() = TODO("Not yet implemented")

        }
    }
}