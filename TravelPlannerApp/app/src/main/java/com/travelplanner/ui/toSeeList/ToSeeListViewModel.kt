package com.travelplanner.ui.toSeeList

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.ToDoItem
import com.travelplanner.models.ToSeeItem

class ToSeeListViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _toSeeList = MutableLiveData<List<ToSeeItem>>()
    val toSeeList: LiveData<List<ToSeeItem>> = _toSeeList

    fun setTravelId(travelId: String){
        travelApiService.getToSeeItem(travelId)
                .applySchedulers()
                .subscribe ({ t ->
                    _toSeeList.value = t
                },{
                    Log.e("ToSeeListViewModel", it.message.toString())
                })
    }
}