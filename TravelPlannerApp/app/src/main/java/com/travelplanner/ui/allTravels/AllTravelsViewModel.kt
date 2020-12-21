package com.travelplanner.ui.allTravels

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Travel
import com.travelplanner.utils.applySchedulers

class AllTravelsViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _travelsList = MutableLiveData<List<Travel>>().apply {
        travelApiService.getTravels()
                .applySchedulers()
                .subscribe ({ t ->
                    value = t
                },{
                    Log.e("AllTravelsViewModel", it.message.toString())
                })
    }
    val travelsList: LiveData<List<Travel>> = _travelsList
}