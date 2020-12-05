package com.travelplanner.ui.cityWalk

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.CityWalk

class CityWalkViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _cityWalk = MutableLiveData<List<CityWalk>>()
    val cityWalk: LiveData<List<CityWalk>> = _cityWalk

    fun setTravelId(travelId: String){
        travelApiService.getCityWalk(travelId)
                .applySchedulers()
                .subscribe { t ->
                    _cityWalk.value = t
                }
    }
}