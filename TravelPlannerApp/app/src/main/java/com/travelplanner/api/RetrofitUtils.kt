package com.travelplanner.api

import com.google.gson.GsonBuilder
import com.google.gson.JsonDeserializer
import com.travelplanner.api.interceptors.DefaultHeadersInterceptor
import io.reactivex.Single
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.schedulers.Schedulers
import okhttp3.OkHttpClient
import retrofit2.Retrofit
import retrofit2.adapter.rxjava2.RxJava2CallAdapterFactory
import retrofit2.converter.gson.GsonConverterFactory
import java.lang.reflect.Type
import java.time.LocalDate
import java.time.LocalDateTime


internal fun createRetrofit(): Retrofit {

    val client = OkHttpClient.Builder()
            .addInterceptor(DefaultHeadersInterceptor())
            .build()


    val gson = GsonBuilder()
            .registerTypeAdapter(LocalDate::class.java, JsonDeserializer<LocalDate> {  json, _, _ ->
                LocalDate.parse(json.asString)
            })
            .registerTypeAdapter(LocalDateTime::class.java, JsonDeserializer<LocalDateTime> { json, _, _ ->
                LocalDateTime.parse(json.asString)
            })
            .create()

    return Retrofit.Builder()
        .addCallAdapterFactory(
            RxJava2CallAdapterFactory.create())
        .addConverterFactory(
            GsonConverterFactory.create(gson))
        .baseUrl("http://51.141.39.217:5000/")
        .client(client)
        .build()
}

fun <T> Single<T>.applySchedulers(): Single<T> {
    return this.subscribeOn(Schedulers.io())
    .observeOn(AndroidSchedulers.mainThread())
}