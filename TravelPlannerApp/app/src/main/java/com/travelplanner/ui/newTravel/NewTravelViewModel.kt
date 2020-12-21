package com.travelplanner.ui.newTravel

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import com.travelplanner.api.LocationInfoApiService
import com.travelplanner.api.TravelApiService
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Location
import com.travelplanner.models.Travel

class NewTravelViewModelFactory() : ViewModelProvider.Factory {
    override fun <T : ViewModel?> create(modelClass: Class<T>): T {
        return NewTravelViewModel(
            DIContainer.travelApiService,
            DIContainer.locationInfoApiService
        ) as T
    }
}

open class NewTravelViewModel(
    private val travelApiService: TravelApiService,
    private val locationInfoApiService: LocationInfoApiService
) : ViewModel() {

    private val _toastError = MutableLiveData<String>()
    open val toastError: LiveData<String> = _toastError

    private val _travel = MutableLiveData<Travel>()
    open val travel: LiveData<Travel> = _travel

    private val _location = MutableLiveData<String>()
    open val location: LiveData<String> = _location

    private val _locations = MutableLiveData<List<Location>>()
    open val locations: LiveData<List<Location>> = _locations

    fun postTravel(travel: Travel) {
        travelApiService.postTravel(travel)
            .applySchedulers()
            .subscribe({ t ->
                _travel.postValue(t)
            }, {
                _toastError.value = "Travel not added. Try again later"
            })
    }

    open fun getLocations(cityName: String) {
        locationInfoApiService.getLocation(cityName)
            .applySchedulers()
            .subscribe({
                _locations.postValue(it)
            }, {
                Log.e("showLocationDialog", it.message.toString())
            })
    }

    fun postLocation(location: Location, travelId: String) {
        travelApiService.postLocation(location, travelId)
            .applySchedulers()
            .subscribe({
                _location.value = ""
            }, {
                Log.e("NewTravelViewModel", it.message.toString())
            })
    }
}