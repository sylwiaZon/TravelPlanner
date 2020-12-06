package com.travelplanner.ui.weatherForecast

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.WeatherForecast

class WeatherForecastViewModel : ViewModel() {
    private val weatherForecastApiService = DIContainer.weatherForecastApiService
    private val _weatherForecast = MutableLiveData<List<WeatherForecast>>()
    val weatherForecast: LiveData<List<WeatherForecast>> = _weatherForecast

    fun setCityName(cityName: String){
        weatherForecastApiService.getWeatherForecast(cityName)
                .applySchedulers()
                .subscribe ({ t ->
                    _weatherForecast.value = t
                },{
                    Log.e("WeatherForecastViewModel", it.message.toString())
                })
    }
}