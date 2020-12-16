package com.travelplanner.ui.dayPlan

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.DayPlan
import com.travelplanner.models.Itinerary

class DayPlanViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _dayPlan = MutableLiveData<List<DayPlan>>()
    val dayPlan: LiveData<List<DayPlan>> = _dayPlan
    private val _liked = MutableLiveData<Boolean>()
    val liked: LiveData<Boolean> = _liked
    
    fun setTravelId(travelId: String){
        travelApiService.getDayPlan(travelId)
            .applySchedulers()
            .subscribe { t ->
                _dayPlan.value = t
            }
    }

    fun addToFavourites(poiId: String?, travelId: String?){
        if(poiId == null || travelId == null ) return
        DIContainer.travelApiService.postToSeeItem(poiId, travelId)
            .applySchedulers()
            .subscribe ({
                _liked.value = true
            },{
                Log.e("ToSeeListViewModel", it.message.toString())
            })
    }
}