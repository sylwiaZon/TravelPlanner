package com.travelplanner.ui.travel

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.map
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Travel
import io.reactivex.Observable
import java.time.LocalDate
import java.time.LocalDateTime
import java.util.*

class IncomingTravelViewModel : TravelViewModelBase() {

    private val travelStream = DIContainer.travelApiService.getTravels()
        .applySchedulers()
        .map {
            Optional.ofNullable(it.filter { t -> t.arrivalDate > LocalDateTime.now() }
                .minBy { t -> t.arrivalDate })
        }

    val isNewTravelScreen: LiveData<Boolean> = MutableLiveData<Boolean>().apply {
        travelStream.subscribe({
            this.value = !it.isPresent
        }, {
            Log.e("IncomingTravelViewModel", it.message.toString())
        })
    }


    override fun loadTravel(): Observable<Travel?> {
        return travelStream
            .filter { it.isPresent }
            .map { it.get() }
            .toObservable()
    }
}