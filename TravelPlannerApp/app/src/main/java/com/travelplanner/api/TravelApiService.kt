package com.travelplanner.api

import com.travelplanner.models.Travel
import io.reactivex.Single
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Query

interface TravelApiService {

    @GET("travel")
    fun getTravels(): Single<List<Travel>>
}