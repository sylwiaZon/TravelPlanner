package com.travelplanner.api

import com.travelplanner.models.Travel
import io.reactivex.Single
import retrofit2.http.POST
import retrofit2.http.Query

interface TravelApiService {

    @POST("travel")
    fun getTravels(@Query("userMail") userMail: String): Single<List<Travel>>
}