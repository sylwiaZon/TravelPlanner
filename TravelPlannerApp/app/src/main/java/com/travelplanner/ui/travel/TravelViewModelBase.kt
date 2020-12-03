package com.travelplanner.ui.travel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.map
import com.travelplanner.models.Travel

class TravelViewModel : ViewModel() {
    private val travel: MutableLiveData<Travel> =  MutableLiveData<Travel>()

    fun setTravel(value: Travel){
        travel.value = value
    }
    val date: LiveData<String> = travel.map {
        it.arrivalDate.toString() + " - " + it.departureDate.toString()
    }
}