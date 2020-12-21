package com.travelplanner.ui.tour

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Poi
import com.travelplanner.models.Tour
import com.travelplanner.utils.applySchedulers

class TourViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _tours = MutableLiveData<List<Tour>>()
    val tours: LiveData<List<Tour>> = _tours

    fun setTravelId(travelId: String){
        travelApiService.getTour(travelId)
                .applySchedulers()
                .subscribe ({ t ->
                    _tours.postValue(t)
                },{
                    Log.e("TourViewModel", it.message.toString())
                })
    }
}