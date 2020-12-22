package com.travelplanner.ui.allTravels

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import com.travelplanner.api.TravelApiService
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Travel
import com.travelplanner.utils.applySchedulers

class AllTravelViewModelFactory(private val travelApiService: TravelApiService): ViewModelProvider.Factory {
    override fun <T : ViewModel?> create(modelClass: Class<T>): T {
        return AllTravelsViewModel(travelApiService) as T
    }
}

class AllTravelsViewModel(private val travelApiService: TravelApiService) : ViewModel() {
    private val _travelsList = MutableLiveData<List<Travel>>().apply {
        travelApiService
                .getTravels()
                .applySchedulers()
                .subscribe ({ t ->
                    value = t
                },{
                    Log.e("AllTravelsViewModel", it.message.toString())
                })
    }
    val travelsList: LiveData<List<Travel>> = _travelsList
}