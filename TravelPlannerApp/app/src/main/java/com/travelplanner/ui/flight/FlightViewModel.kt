package com.travelplanner.ui.flight

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Flight

class FlightViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _toFlight = MutableLiveData<Flight?>()
    private val _fromFlight = MutableLiveData<Flight?>()
    val toFlight: LiveData<Flight?> = _toFlight
    val fromFlight: LiveData<Flight?> = _fromFlight

    fun setTravelId(travelId: String) {
        travelApiService.getFlight("to", travelId)
                .applySchedulers()
                .subscribe ({ t ->
                    _toFlight.value = t
                },{
                    _toFlight.value = null
                })
        travelApiService.getFlight("from", travelId)
                .applySchedulers()
                .subscribe ({ t ->
                    _fromFlight.value = t
                },{
                    _fromFlight.value = null
                })
    }
}