package com.travelplanner.ui.localHighlights

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.HotelWithDetails
import com.travelplanner.models.Poi

class LocalHighlightsViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _localHighlights = MutableLiveData<List<Poi>>()
    val localHighlights: LiveData<List<Poi>> = _localHighlights

    fun setTravelId(travelId: String){
        travelApiService.getPois(travelId)
                .applySchedulers()
                .subscribe ({ t ->
                    _localHighlights.value = t
                },{
                    Log.e("LocalHighlightsViewModel", it.message.toString())
                })
    }
}