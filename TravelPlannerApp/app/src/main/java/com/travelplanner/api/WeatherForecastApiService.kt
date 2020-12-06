package com.travelplanner.api

import com.travelplanner.models.WeatherForecast
import io.reactivex.Single
import retrofit2.http.GET
import retrofit2.http.Query

interface WeatherForecastApiService {
    @GET("weatherforecast")
    fun getWeatherForecast(@Query("cityName") locationId: String): Single<List<WeatherForecast>>
}