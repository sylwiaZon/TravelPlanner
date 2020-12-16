package com.travelplanner.api

import com.travelplanner.models.*
import io.reactivex.Single
import retrofit2.Response
import retrofit2.http.*

interface TravelApiService {

    @GET("travel")
    fun getTravels(): Single<List<Travel>>

    @POST("travel")
    fun postTravel(@Body travel: Travel): Single<Travel>

    @GET("travel/location")
    fun getLocation(@Query("travelIdentity") travelIdentity: String): Single<Location>

    @POST("travel/location")
    fun postLocation(@Body location: Location, @Query("travelIdentity") travelIdentity: String): Single<Response<String>>

    @GET("travel/poi")
    fun getPois(@Query("travelIdentity") travelIdentity: String): Single<List<Poi>>

    @GET("travel/hotel")
    fun getHotel(@Query("travelIdentity") travelIdentity: String): Single<HotelWithDetails>

    @POST("travel/hotel")
    fun postHotel(@Body hotel: Hotel, @Query("travelIdentity") travelIdentity: String): Single<Response<String>>

    @GET("travel/citywalk")
    fun getCityWalk(@Query("travelIdentity") travelIdentity: String): Single<List<CityWalk>>

    @POST("travel/citywalk")
    fun postCityWalk(@Body cityWalk: CityWalk, @Query("travelIdentity") travelIdentity: String)

    @GET("travel/dayplan")
    fun getDayPlan(@Query("travelIdentity") travelIdentity: String): Single<List<DayPlan>>

    @POST("travel/dayplan")
    fun postDayPlan(@Body dayPlan: DayPlan, @Query("travelIdentity") travelIdentity: String)

    @GET("travel/tour")
    fun getTour(@Query("travelIdentity") travelIdentity: String): Single<List<Tour>>

    @POST("travel/tour")
    fun postTour(@Body tour: Tour, @Query("travelIdentity") travelIdentity: String)

    @GET("travel/todo")
    fun getToDoItem(@Query("travelIdentity") travelIdentity: String): Single<List<ToDoItem>>

    @POST("travel/todo")
    fun postToDoItem(@Query("item") toDoItem: String, @Query("travelIdentity") travelIdentity: String) : Single<ToDoItem>

    @PATCH("travel/todo")
    fun patchToDoItem(@Body toDoItem: ToDoItem): Single<ToDoItem>

    @GET("travel/tosee")
    fun getToSeeItem(@Query("travelIdentity") travelIdentity: String): Single<List<ToSeeItem>>

    @POST("travel/tosee")
    fun postToSeeItem(@Query("poiId") poiId: String, @Query("travelIdentity") travelIdentity: String): Single<ToSeeItem>

    @PATCH("travel/tosee")
    fun patchToSeeItem(@Body toSeeItem: ToSeeItem): Single<ToSeeItem>

    @GET("travel/flight")
    fun getFlight(@Query("flightType") flightType: String, @Query("travelIdentity") travelIdentity: String): Single<Flight>

    @POST("travel/flight")
    fun postFlight(@Body flight: Flight, @Query("flightType") flightType: String, @Query("travelIdentity") travelIdentity: String)
}