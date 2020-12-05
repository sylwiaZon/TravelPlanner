package com.travelplanner.ui.travel

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.map
import com.travelplanner.models.Travel
import io.reactivex.Observable
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle

abstract class TravelViewModelBase : ViewModel() {
    private val _travel = MutableLiveData<Travel>()
    val travel: LiveData<Travel?> = _travel
    val formatter = DateTimeFormatter.ofLocalizedDate(FormatStyle.LONG)
    val date: LiveData<String> = travel.map {
        "${it?.arrivalDate?.format(formatter)} - ${it?.departureDate?.format(formatter)}"
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