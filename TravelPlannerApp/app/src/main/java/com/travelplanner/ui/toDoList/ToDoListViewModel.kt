package com.travelplanner.ui.toDoList

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.ToDoItem
import com.travelplanner.models.ToSeeItem

class ToDoListViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _toDoList = MutableLiveData<List<ToDoItem>>()
    val toDoList: LiveData<List<ToDoItem>> = _toDoList
    private val _checked = MutableLiveData<Pair<String, Boolean>>()
    val checked: LiveData<Pair<String, Boolean>> = _checked
    private val _toastError = MutableLiveData<String>()
    val toastError: LiveData<String> = _toastError
    private val _addItemToastError = MutableLiveData<String>()
    val addItemToastError: LiveData<String> = _addItemToastError
    private val _added = MutableLiveData<Boolean>()
    val added: LiveData<Boolean> = _added

    fun setTravelId(travelId: String){
        travelApiService.getToDoItem(travelId)
                .applySchedulers()
                .subscribe ({ t ->
                    _toDoList.postValue(t)
                },{
                    Log.e("ToDoListViewModel", it.message.toString())
                })
    }

    fun checkItem(toDo: ToDoItem){
        travelApiService.patchToDoItem(toDo)
            .applySchedulers()
            .subscribe ({ t ->
                _checked.value = Pair(t.id, t.checked)
            },{
                _checked.value = Pair(toDo.id, !toDo.checked)
                _toastError.value = "Item not changed. Try again later"
                Log.e("ToDoListViewModel", it.message.toString())
            })
    }

    fun addToFavourites(toDo: String?, travelId: String?){
        if(toDo == null || travelId == null ) return
        DIContainer.travelApiService.postToDoItem(toDo, travelId)
            .applySchedulers()
            .flatMap { travelApiService.getToDoItem(travelId)  }
            .subscribe ({
                _added.value = true
                _toDoList.value = it
            },{
                _addItemToastError.value = "Item not changed. Try again later"
                Log.e("ToDoListViewModel", it.message.toString())
            })
    }
}