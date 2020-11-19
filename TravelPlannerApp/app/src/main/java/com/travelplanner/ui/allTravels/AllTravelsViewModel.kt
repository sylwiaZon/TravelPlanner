package com.travelplanner.ui.allTravels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Travel

class AllTravelsViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _travelsList = MutableLiveData<List<Travel>>().apply {
        travelApiService.getTravels("Mailek").subscribe { t ->
            value = t
        }
    }
    val travelsList: LiveData<List<Travel>> = _travelsList
}