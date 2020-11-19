package com.travelplanner.di

import com.travelplanner.api.TravelApiService
import com.travelplanner.api.UserApiService
import com.travelplanner.api.createRetrofit

object DIContainer{

    private val retrofit = createRetrofit()
    val usersApiService = retrofit.create(UserApiService::class.java)
    val travelApiService = retrofit.create(TravelApiService::class.java)
}