package com.travelplanner.ui.dayPlan

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Itinerary

class DayPlanViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _dayPlan = MutableLiveData<List<Itinerary>>()
    val dayPlan: LiveData<List<Itinerary>> = _dayPlan

    fun setTravelId(travelId: String){
        travelApiService.getDayPlan(travelId)
            .applySchedulers()
            .subscribe { t ->
                _dayPlan.value = t.first().days
            }
    }
}