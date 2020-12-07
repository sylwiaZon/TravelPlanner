package com.travelplanner.ui.poi

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Poi
import com.travelplanner.models.ToSeeItem

class PoiViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _liked = MutableLiveData<Unit>()
    val liked: LiveData<Unit> = _liked

    fun addToFavourites(poiId: String, travelId: String){
        travelApiService.postToSeeItem(poiId, travelId)
            .applySchedulers()
            .subscribe ({ t ->
                _liked.value = Unit
            },{
                Log.e("ToSeeListViewModel", it.message.toString())
            })
    }
}