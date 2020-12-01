package com.travelplanner.api

import com.travelplanner.models.Tour
import io.reactivex.Single
import retrofit2.http.GET
import retrofit2.http.Query

interface TourInformationApiService {
    @GET("tourinformation")
    fun getTours(@Query("cityName") locationId: String): Single<List<Tour>>
}