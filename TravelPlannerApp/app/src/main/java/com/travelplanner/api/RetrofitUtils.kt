package com.travelplanner.api

import retrofit2.Retrofit
import retrofit2.adapter.rxjava2.RxJava2CallAdapterFactory
import retrofit2.converter.gson.GsonConverterFactory

fun createRetrofit(): Retrofit {

    return Retrofit.Builder()
        .addCallAdapterFactory(
            RxJava2CallAdapterFactory.create())
        .addConverterFactory(
            GsonConverterFactory.create())
        .baseUrl("http://40.69.36.20:5000/")
        .build()
}