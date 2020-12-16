package com.travelplanner.ui.newTravel

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.HotelWithDetails
import com.travelplanner.models.Location
import com.travelplanner.models.Travel

class NewTravelViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _toastError = MutableLiveData<String>()
    val toastError: LiveData<String> = _toastError

    private val _travel = MutableLiveData<Travel>()
    val travel: LiveData<Travel> = _travel

    private val _location = MutableLiveData<String>()
    val location: LiveData<String> = _location

    fun postTravel(travel: Travel){
        travelApiService.postTravel(travel)
                .applySchedulers()
                .subscribe({ t ->
                    _travel.value = t
                }, {
                    _toastError.value = "Travel not added. Try again later"
                })
    }

    fun postLocation(location: Location, travelId: String){
        travelApiService.postLocation(location, travelId)
            .applySchedulers()
            .subscribe ({
                _location.value = ""
            },{
                Log.e("NewTravelViewModel", it.message.toString())
            })
    }
}