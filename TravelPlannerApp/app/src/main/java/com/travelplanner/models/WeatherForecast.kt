package com.travelplanner.models

import java.time.LocalDateTime

class WeatherForecast(val date: LocalDateTime, val windSpeed: Double, val windDirection: Double,
                      val visibility: Double, val cloudiness: Double, val weather: List<WeatherProperties>,
                      val temperature: Double, val temperatureFeels: Double, val minimalTemperature: Double,
                      val maximalTemperature: Double, val pressure: Double, val humidity: Double)

class WeatherProperties(val weatherName: String, val weatherDescription:String, val weatherIcon: String)