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
    private val _checked = MutableLiveData<Pair<String, Boolean>>()
    val checked: LiveData<Pair<String, Boolean>> = _checked
    private val _toastError = MutableLiveData<String>()
    val toastError: LiveData<String> = _toastError

    fun setTravelId(travelId: String){
        travelApiService.getToSeeItem(travelId)
                .applySchedulers()
                .subscribe ({ t ->
                    _toSeeList.postValue(t)
                },{
                    Log.e("ToSeeListViewModel", it.message.toString())
                })
    }

    fun checkItem(toSee: ToSeeItem){
        travelApiService.patchToSeeItem(toSee)
            .applySchedulers()
            .subscribe ({ t ->
                _checked.value = Pair(t.id, t.checked)
            },{
                _checked.value = Pair(toSee.id, !toSee.checked)
                _toastError.value = "Item not changed. Try again later"
                Log.e("ToSeeListViewModel", it.message.toString())
            })
    }
}