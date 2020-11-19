package com.travelplanner.api

import com.travelplanner.api.models.Authorize
import io.reactivex.Single
import retrofit2.http.Body
import retrofit2.http.POST

interface UserApiService {

    @POST("user/authorize")
    fun authenticate(@Body req: Authorize.Request): Single<Authorize.Response>
}