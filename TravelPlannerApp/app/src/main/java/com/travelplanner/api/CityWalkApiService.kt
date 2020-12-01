package com.travelplanner.api

import com.travelplanner.models.CityWalk
import io.reactivex.Single
import retrofit2.http.GET
import retrofit2.http.Query

interface CityWalkApiService {
    @GET("citywalk")
    fun getCityWalks(@Query("cityName") cityName: String, @Query("totalTime") totalTime: Int): Single<List<CityWalk>>
}