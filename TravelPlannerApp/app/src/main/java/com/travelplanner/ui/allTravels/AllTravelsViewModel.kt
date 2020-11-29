package com.travelplanner.ui.allTravels

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Travel
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.schedulers.Schedulers

class AllTravelsViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _travelsList = MutableLiveData<List<Travel>>().apply {
        travelApiService.getTravels()
                .applySchedulers()
                .subscribe { t ->
                    value = t
                }
    }
    val travelsList: LiveData<List<Travel>> = _travelsList
}