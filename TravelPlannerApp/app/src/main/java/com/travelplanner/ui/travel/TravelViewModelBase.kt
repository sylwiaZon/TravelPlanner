package com.travelplanner.ui.travel

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.map
import com.travelplanner.models.Travel
import io.reactivex.Observable

abstract class TravelViewModelBase : ViewModel() {
    private val _travel = MutableLiveData<Travel>()
    val travel: LiveData<Travel?> = _travel
    val date: LiveData<String> = travel.map {
        "${it?.arrivalDate.toString()} - ${it?.departureDate.toString()}"
    }

    fun initTravel() {
        loadTravel().subscribe({
            _travel.value = it
        }, {
            Log.e("TravelViewModelBase", it.message.toString())
        })
    }

    protected abstract fun loadTravel(): Observable<Travel?>
}