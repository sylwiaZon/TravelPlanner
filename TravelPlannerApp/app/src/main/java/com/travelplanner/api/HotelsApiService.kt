package com.travelplanner.api

import com.travelplanner.models.Hotel
import io.reactivex.Single
import retrofit2.http.GET
import retrofit2.http.Query

interface HotelsApiService {
    @GET("hotels")
    fun getHotels(@Query("cityName") cityName: String): Single<List<Hotel>>
}