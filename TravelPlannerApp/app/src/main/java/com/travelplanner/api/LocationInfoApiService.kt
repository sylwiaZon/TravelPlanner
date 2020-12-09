package com.travelplanner.api

import com.travelplanner.models.Location
import io.reactivex.Single
import retrofit2.http.GET
import retrofit2.http.Query

interface LocationInfoApiService {
    @GET("locationinfo")
    fun getLocation(@Query("cityName") cityName: String): List<Location>
}