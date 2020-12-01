package com.travelplanner.api

import com.travelplanner.models.DayPlan
import io.reactivex.Single
import retrofit2.http.GET
import retrofit2.http.Query

interface DayPlannerApiService {
    @GET("dayplanner")
    fun getDayPlan(@Query("locationId") cityName: String, @Query("arrivalTime") arrivalTime: String,
                   @Query("departureTime") departureTime: String, @Query("startDate") startDate: String,
                   @Query("string") string: String): Single<List<DayPlan>>
}