package com.travelplanner.ui.newTravel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel

class NewTravelViewModel : ViewModel() {

    private val _text = MutableLiveData<String>().apply {
        value = "This is New Travel Fragment"
    }
    val text: LiveData<String> = _text
}